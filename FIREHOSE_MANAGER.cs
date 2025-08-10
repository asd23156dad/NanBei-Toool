using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x0200000B RID: 11
	public static class FIREHOSE_MANAGER
	{
		// Token: 0x0600006C RID: 108 RVA: 0x0000BA98 File Offset: 0x00009C98
		public static void CariPorts()
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_PnPEntity  WHERE Name LIKE '%9008%'  "))
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator();
				while (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					Main.DelegateFunction.CariPortQcom.Stop();
					string str = managementObject["Name"].ToString();
					string text = managementObject["Name"].ToString().Substring(checked(managementObject["Name"].ToString().IndexOf("(COM") + 4));
					PortIOMe.PortCOM = Conversions.ToInteger(text.TrimEnd(new char[]
					{
						')'
					}));
					Main.DelegateFunction.ComboBox3.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.ComboBox3.Text = str;
					}));
					uiManager.logs("Found at COM" + Conversions.ToString(PortIOMe.PortCOM), true, (uiManager.MessageType)uiManager.Kuning);
					BackgroundWorker backgroundWorker = new BackgroundWorker();
					backgroundWorker.DoWork += SAHARA_MANAGER.SaharaConnect;
					backgroundWorker.RunWorkerCompleted += FIREHOSE_MANAGER.sendingloaderDone;
					backgroundWorker.ProgressChanged += FIREHOSE_MANAGER.ProcessSendingLoader;
					backgroundWorker.RunWorkerAsync();
					backgroundWorker.Dispose();
				}
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000BC24 File Offset: 0x00009E24
		public static void ProcessSendingLoader(object sender, ProgressChangedEventArgs e)
		{
			uiManager.logs(e.ToString(), true, (uiManager.MessageType)uiManager.Hitam);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000BC3E File Offset: 0x00009E3E
		public static void sendingLoader(object sender, DoWorkEventArgs e)
		{
			Thread.Sleep(500);
			Thread.Sleep(500);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000BC58 File Offset: 0x00009E58
		public static void sendingloaderDone(object sender, RunWorkerCompletedEventArgs e)
		{
			bool flag = !SAHARA_MANAGER.sendingloaderStatus;
			if (flag)
			{
				uiManager.logs("Done With Error", true, (uiManager.MessageType)uiManager.Merah);
			}
			else
			{
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.DoWork += FIREHOSE_MANAGER.ConnectToFlashLoader;
				backgroundWorker.RunWorkerCompleted += FIREHOSE_MANAGER.EdlDone;
				backgroundWorker.ProgressChanged += FIREHOSE_MANAGER.ProcessSendingLoader;
				backgroundWorker.RunWorkerAsync();
				backgroundWorker.Dispose();
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000BCDB File Offset: 0x00009EDB
		public static void EdlDone(object sender, RunWorkerCompletedEventArgs e)
		{
			DiskWriter.Close();
			FIREHOSE_MANAGER.AllDone(sender, e);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000BCEC File Offset: 0x00009EEC
		public static void AllDone(object sender, RunWorkerCompletedEventArgs e)
		{
			uiManager.transferspeed = 0L;
			Main.DelegateFunction.ProgressBar2.Invoke(new Action(delegate()
			{
				Main.DelegateFunction.ProgressBar2.Value = 100;
			}));
			Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
			{
				Main.DelegateFunction.ProgressBar1.Value = 100;
			}));
			Main.Elapsed(uiManager.Watch);
			uiManager.Watch.Stop();
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000BD78 File Offset: 0x00009F78
		public static bool IsAckFast()
		{
			bool result;
			try
			{
				byte[] array = DiskWriter.DiskRead(0);
				string @string = Encoding.UTF8.GetString(array, 0, array.Length);
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000BDC8 File Offset: 0x00009FC8
		public static bool IsAck()
		{
			bool result;
			try
			{
				string @string;
				for (;;)
				{
					byte[] array = DiskWriter.DiskRead(0);
					@string = Encoding.UTF8.GetString(array, 0, array.Length);
					bool flag = @string.Contains("\"ACK\"");
					if (flag)
					{
						break;
					}
					bool flag2 = @string.Contains("\"NAK\"");
					if (flag2)
					{
						goto Block_2;
					}
				}
				return true;
				Block_2:
				uiManager.logs(@string, true, (uiManager.MessageType)uiManager.Merah);
				result = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000BE58 File Offset: 0x0000A058
		public static void SendXmlFast(string xml)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(xml);
			DiskWriter.DiskWrite(bytes);
			FIREHOSE_MANAGER.IsAckFast();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000BE80 File Offset: 0x0000A080
		public static void SendXml(string xml)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(xml);
			DiskWriter.DiskWrite(bytes);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000BEA4 File Offset: 0x0000A0A4
		public static string CekResponseConfig()
		{
			int num = 0;
			checked
			{
				string result;
				try
				{
					string @string;
					for (;;)
					{
						byte[] array = DiskWriter.DiskRead(0);
						@string = Encoding.UTF8.GetString(array, 0, array.Length);
						bool flag = @string.ToUpper().Contains("\"ACK\"");
						if (flag)
						{
							break;
						}
						bool flag2 = @string.ToUpper().Contains("\"NAK\"");
						if (flag2)
						{
							goto Block_3;
						}
						num++;
						Thread.Sleep(300);
						bool flag3 = num == 3;
						if (flag3)
						{
							goto Block_4;
						}
					}
					return "ack";
					Block_3:
					return @string;
					Block_4:
					result = "failed";
				}
				catch (Exception ex)
				{
					result = "failed";
				}
				return result;
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000BF50 File Offset: 0x0000A150
		public static void ConnectToFlashLoader(object sender, DoWorkEventArgs e)
		{
			checked
			{
				try
				{
					uiManager.logs("Connect To Flash Storage : ... ", true, (uiManager.MessageType)uiManager.Hitam);
					bool flag = !DiskWriter.Openport("\\\\.\\COM" + PortIOMe.PortCOM.ToString(), FIREHOSE_MANAGER.backgroundWorker, e);
					if (flag)
					{
						uiManager.logs("Failed to Open Flash Storage", true, (uiManager.MessageType)uiManager.Merah);
					}
					else
					{
						bool flag2 = FIREHOSE_MANAGER.MenuEx == FIREHOSE_MANAGER.MenuEksekusi.oneclick;
						if (flag2)
						{
							XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(FIREHOSE_MANAGER.StringXml));
							while (xmlTextReader.Read())
							{
								bool flag3 = (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name.ToLower() == "program") || xmlTextReader.Name.ToLower() == "erase" || xmlTextReader.Name.ToLower() == "patch";
								if (flag3)
								{
									FIREHOSE_MANAGER.SectorSize = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES");
									break;
								}
							}
							bool flag4 = FIREHOSE_MANAGER.SectorSize == "512";
							if (flag4)
							{
								FIREHOSE_MANAGER.TypeMemory = "emmc";
							}
							else
							{
								bool flag5 = FIREHOSE_MANAGER.SectorSize == "4096";
								if (!flag5)
								{
									uiManager.logs("Failed Get Sector Size From data Server", true, (uiManager.MessageType)uiManager.Merah);
									return;
								}
								FIREHOSE_MANAGER.TypeMemory = "ufs";
							}
						}
						string xml = FIREHOSE.pkt_fhConfig(FIREHOSE_MANAGER.TypeMemory);
						uiManager.logs("Sending Congigure : ", false, (uiManager.MessageType)uiManager.Hitam);
						FIREHOSE_MANAGER.SendXml(xml);
						uiManager.logs("OK ", true, (uiManager.MessageType)uiManager.Hijau);
						string text = FIREHOSE_MANAGER.CekResponseConfig();
						uiManager.logs("Get Response : ", false, (uiManager.MessageType)uiManager.Hitam);
						bool flag6 = text.ToLower().Contains("ack");
						if (flag6)
						{
							uiManager.logs(" Configured", true, (uiManager.MessageType)uiManager.Kuning);
						}
						else
						{
							bool flag7 = !text.Contains("xml");
							if (flag7)
							{
								return;
							}
							bool flag8 = text.Contains("Only nop and sig tag");
							if (flag8)
							{
								uiManager.logs("Only nop and sig tag Before Authentification", true, (uiManager.MessageType)uiManager.Kuning);
								uiManager.logs("Try Bypassing Auth", true, (uiManager.MessageType)uiManager.Kuning);
								string xml2 = "<?xml version=\"1.0\" ?><data><sig TargetName=\"sig\" size_in_bytes=\"256\" verbose=\"1\"/></data>";
								uiManager.logs("Sending auth : ", false, (uiManager.MessageType)uiManager.Kuning);
								FIREHOSE_MANAGER.SendXml(xml2);
								bool flag9 = FIREHOSE_MANAGER.IsAck();
								bool flag10 = !flag9;
								if (flag10)
								{
									uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
									return;
								}
								byte[] data = File.ReadAllBytes(Application.StartupPath + "\\Data\\XIAOMI\\skip");
								DiskWriter.DiskWrite(data);
								bool flag11 = !FIREHOSE_MANAGER.IsAck();
								if (flag11)
								{
									uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
									return;
								}
								uiManager.logs("Re Sending Configure : ", false, (uiManager.MessageType)uiManager.Hitam);
								FIREHOSE_MANAGER.SendXml(xml);
								bool flag12 = FIREHOSE_MANAGER.IsAck();
								bool flag13 = !flag12;
								if (flag13)
								{
									uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
									return;
								}
								uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
							}
						}
						bool flag14 = FIREHOSE_MANAGER.MenuEx == FIREHOSE_MANAGER.MenuEksekusi.manual;
						if (flag14)
						{
							bool flag15 = FIREHOSE_MANAGER.MenuMan == FIREHOSE_MANAGER.MenuManual.ident;
							if (flag15)
							{
								bool flag16 = FIREHOSE_MANAGER.TypeMemory.ToLower() == "emmc";
								if (flag16)
								{
									Thread.Sleep(500);
									uiManager.logs("Reading Partition : ", false, (uiManager.MessageType)uiManager.Hitam);
									bool flag17 = FIREHOSE_MANAGER.ParseGPT(FIREHOSE_MANAGER.TypeMemory, "0");
									if (flag17)
									{
										Thread.Sleep(500);
										FIREHOSE_MANAGER.ParsePartions(FIREHOSE.gpt.header.starting_lba_pe, FIREHOSE_MANAGER.TypeMemory, "0");
									}
								}
								else
								{
									bool flag18 = FIREHOSE_MANAGER.TypeMemory.ToLower() == "ufs";
									if (flag18)
									{
										bool flag19 = FIREHOSE_MANAGER.ParseGPT(FIREHOSE_MANAGER.TypeMemory, "0");
										if (flag19)
										{
											Thread.Sleep(500);
											FIREHOSE_MANAGER.ParsePartions(FIREHOSE.gpt.header.starting_lba_pe, FIREHOSE_MANAGER.TypeMemory, "0");
										}
										Thread.Sleep(500);
										bool flag20 = FIREHOSE_MANAGER.ParseGPT(FIREHOSE_MANAGER.TypeMemory, "1");
										if (flag20)
										{
											Thread.Sleep(500);
											FIREHOSE_MANAGER.ParsePartions(FIREHOSE.gpt.header.starting_lba_pe, FIREHOSE_MANAGER.TypeMemory, "1");
										}
										Thread.Sleep(500);
										bool flag21 = FIREHOSE_MANAGER.ParseGPT(FIREHOSE_MANAGER.TypeMemory, "2");
										if (flag21)
										{
											Thread.Sleep(500);
											FIREHOSE_MANAGER.ParsePartions(FIREHOSE.gpt.header.starting_lba_pe, FIREHOSE_MANAGER.TypeMemory, "2");
										}
										Thread.Sleep(500);
										bool flag22 = FIREHOSE_MANAGER.ParseGPT(FIREHOSE_MANAGER.TypeMemory, "3");
										if (flag22)
										{
											Thread.Sleep(500);
											FIREHOSE_MANAGER.ParsePartions(FIREHOSE.gpt.header.starting_lba_pe, FIREHOSE_MANAGER.TypeMemory, "3");
										}
										Thread.Sleep(500);
										bool flag23 = FIREHOSE_MANAGER.ParseGPT(FIREHOSE_MANAGER.TypeMemory, "4");
										if (flag23)
										{
											Thread.Sleep(500);
											FIREHOSE_MANAGER.ParsePartions(FIREHOSE.gpt.header.starting_lba_pe, FIREHOSE_MANAGER.TypeMemory, "4");
										}
										Thread.Sleep(500);
										bool flag24 = FIREHOSE_MANAGER.ParseGPT(FIREHOSE_MANAGER.TypeMemory, "5");
										if (flag24)
										{
											Thread.Sleep(500);
											FIREHOSE_MANAGER.ParsePartions(FIREHOSE.gpt.header.starting_lba_pe, FIREHOSE_MANAGER.TypeMemory, "5");
										}
									}
								}
							}
							else
							{
								bool flag25 = FIREHOSE_MANAGER.MenuMan == FIREHOSE_MANAGER.MenuManual.flash;
								if (flag25)
								{
									uiManager.logs(" ", true, (uiManager.MessageType)uiManager.Kuning);
									int num = 0;
									XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(FIREHOSE_MANAGER.StringXml));
									while (xmlTextReader.Read())
									{
										bool flag26 = xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "program";
										if (flag26)
										{
											FIREHOSE_MANAGER.SectorSize = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES");
											string attribute = xmlTextReader.GetAttribute("num_partition_sectors");
											string attribute2 = xmlTextReader.GetAttribute("label");
											string attribute3 = xmlTextReader.GetAttribute("filename");
											string attribute4 = xmlTextReader.GetAttribute("physical_partition_number");
											string attribute5 = xmlTextReader.GetAttribute("start_sector");
											bool flag27 = string.IsNullOrEmpty(attribute3);
											if (flag27)
											{
												num++;
											}
											else
											{
												bool flag28 = File.Exists(attribute3);
												if (flag28)
												{
													num++;
													bool flag29 = FIREHOSE_MANAGER.WriteEmmc(FIREHOSE_MANAGER.SectorSize, attribute, attribute4, attribute5, ref attribute2, attribute3);
													bool flag30 = !flag29;
													if (flag30)
													{
														uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
														return;
													}
													uiManager.logs("Done", true, (uiManager.MessageType)uiManager.Kuning);
												}
												else
												{
													uiManager.logs("File Not exist , skiping\r\n", true, (uiManager.MessageType)uiManager.Kuning);
													num++;
												}
											}
											unchecked
											{
												uiManager.ProcessBar2((long)num, (long)FIREHOSE_MANAGER.totalchecked);
											}
										}
									}
									bool flag31 = !string.IsNullOrEmpty(Main.DelegateFunction.txtrawxml.Text);
									if (flag31)
									{
										string[] array = FIREHOSE_MANAGER.PatchString.Split(new char[]
										{
											','
										});
										for (int i = 0; i < array.Length - 1; i++)
										{
											string text2 = array[i];
											bool flag32 = string.IsNullOrEmpty(text2);
											if (flag32)
											{
												break;
											}
											uiManager.logs("[ i ] Applying Patch -> ", true, (uiManager.MessageType)uiManager.Hitam);
											xmlTextReader = new XmlTextReader(new StringReader(File.ReadAllText(Main.LoadFolderXml + "\\" + text2)));
											while (xmlTextReader.Read())
											{
												bool flag33 = xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "patch";
												if (flag33)
												{
													string attribute6 = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES");
													string attribute7 = xmlTextReader.GetAttribute("byte_offset");
													string attribute8 = xmlTextReader.GetAttribute("filename");
													string attribute9 = xmlTextReader.GetAttribute("physical_partition_number");
													string attribute10 = xmlTextReader.GetAttribute("size_in_bytes");
													string attribute11 = xmlTextReader.GetAttribute("start_sector");
													string attribute12 = xmlTextReader.GetAttribute("value");
													string attribute13 = xmlTextReader.GetAttribute("what");
													uiManager.logs("          " + attribute13, true, (uiManager.MessageType)uiManager.Hijau);
													bool flag34 = attribute8.ToUpper().Contains("DISK");
													if (flag34)
													{
														string xml3 = FIREHOSE.pkt_patch(attribute6, attribute7, attribute8, attribute9, attribute10, attribute11, attribute12, attribute13);
														FIREHOSE_MANAGER.SendXml(xml3);
														bool flag35 = FIREHOSE_MANAGER.IsAckFast();
														if (!flag35)
														{
															return;
														}
													}
												}
											}
											uiManager.logs("[ i ] Patch Applied : ", false, (uiManager.MessageType)uiManager.Hitam);
											uiManager.logs("Done", true, (uiManager.MessageType)uiManager.Hijau);
										}
									}
									bool @checked = Main.DelegateFunction.cbsetboot.Checked;
									if (@checked)
									{
										FIREHOSE_MANAGER.SendXml(FIREHOSE.BootConf());
										bool flag36 = FIREHOSE_MANAGER.IsAck();
										bool flag37 = flag36;
										if (!flag37)
										{
											return;
										}
									}
									bool checked2 = Main.DelegateFunction.cbreboot.Checked;
									if (checked2)
									{
										FIREHOSE_MANAGER.SendXml(FIREHOSE.pkt_sendReset());
									}
								}
								else
								{
									bool flag38 = FIREHOSE_MANAGER.MenuMan == FIREHOSE_MANAGER.MenuManual.hapus;
									if (flag38)
									{
										uiManager.logs(" ", true, (uiManager.MessageType)uiManager.Kuning);
										int num2 = FIREHOSE_MANAGER.totalchecked;
										int num3 = 0;
										XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(FIREHOSE_MANAGER.StringXml));
										while (xmlTextReader.Read())
										{
											bool flag39 = xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "program";
											if (flag39)
											{
												FIREHOSE_MANAGER.SectorSize = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES");
												string attribute14 = xmlTextReader.GetAttribute("num_partition_sectors");
												string attribute15 = xmlTextReader.GetAttribute("label");
												string attribute16 = xmlTextReader.GetAttribute("filename");
												string attribute17 = xmlTextReader.GetAttribute("physical_partition_number");
												string attribute18 = xmlTextReader.GetAttribute("start_sector");
												bool flag40 = string.IsNullOrEmpty(attribute16);
												if (flag40)
												{
													num3++;
												}
												else
												{
													uiManager.logs("Erasing " + attribute15 + " : ", false, (uiManager.MessageType)uiManager.Hitam);
													num3++;
													bool flag41 = FIREHOSE_MANAGER.EraseParts(FIREHOSE_MANAGER.SectorSize, attribute14, attribute17, attribute18, ref attribute15);
													bool flag42 = !flag41;
													if (flag42)
													{
														uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
														break;
													}
													uiManager.logs("Done", true, (uiManager.MessageType)uiManager.Kuning);
												}
												unchecked
												{
													uiManager.ProcessBar2((long)num3, (long)num2);
												}
											}
										}
									}
									else
									{
										bool flag43 = FIREHOSE_MANAGER.MenuMan == FIREHOSE_MANAGER.MenuManual.read;
										if (flag43)
										{
											uiManager.logs(" ", true, (uiManager.MessageType)uiManager.Kuning);
											int num4 = FIREHOSE_MANAGER.totalchecked;
											int num5 = 0;
											bool flag44 = File.Exists(FIREHOSE_MANAGER.foldersave + "\\rawprogram.xml");
											if (flag44)
											{
												File.Delete(FIREHOSE_MANAGER.foldersave + "\\rawprogram.xml");
											}
											StreamWriter streamWriter = new StreamWriter(FIREHOSE_MANAGER.foldersave + "\\rawprogram.xml", true, Encoding.UTF8);
											streamWriter.WriteLine("<?xml version=\"1.0\" ?>");
											streamWriter.WriteLine("<data>");
											streamWriter.WriteLine("<!--NOTE: genererated by iReverse Tool @HadikIT **-->");
											try
											{
												XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(FIREHOSE_MANAGER.StringXml));
												while (xmlTextReader.Read())
												{
													bool flag45 = xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "read";
													if (flag45)
													{
														string attribute19 = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES");
														string attribute20 = xmlTextReader.GetAttribute("num_partition_sectors");
														string attribute21 = xmlTextReader.GetAttribute("label");
														string attribute22 = xmlTextReader.GetAttribute("physical_partition_number");
														string attribute23 = xmlTextReader.GetAttribute("start_sector");
														uiManager.logs(string.Concat(new string[]
														{
															"[",
															attribute22,
															"] Reading ",
															attribute21,
															" -> ",
															FIREHOSE_MANAGER.getfilenames(attribute21),
															" [raw]: "
														}), false, (uiManager.MessageType)uiManager.Hitam);
														bool flag46 = FIREHOSE_MANAGER.ReadPart(attribute23, attribute20, attribute19, attribute22, ref attribute21);
														bool flag47 = flag46;
														if (flag47)
														{
															uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
															streamWriter.WriteLine(string.Concat(new string[]
															{
																"<program SECTOR_SIZE_IN_BYTES=\"",
																FIREHOSE_MANAGER.SectorSize,
																"\" file_sector_offset=\"0\" filename=\"",
																FIREHOSE_MANAGER.getfilenames(attribute21),
																"\" label=\"",
																attribute21,
																"\" num_partition_sectors=\"",
																attribute20,
																"\"  physical_partition_number=\"",
																attribute22,
																"\"  start_sector=\"",
																attribute23,
																"\" />"
															}));
															num5++;
														}
														else
														{
															uiManager.logs("Failed", false, (uiManager.MessageType)uiManager.Merah);
															num5++;
														}
														unchecked
														{
															uiManager.ProcessBar2((long)num5, (long)num4);
														}
													}
												}
												streamWriter.WriteLine("</data>");
												streamWriter.Flush();
												streamWriter.Close();
												bool checked3 = Main.DelegateFunction.cbreboot.Checked;
												if (checked3)
												{
													string xml4 = FIREHOSE.pkt_sendReset();
													FIREHOSE_MANAGER.SendXml(xml4);
												}
											}
											catch (Exception ex)
											{
												MessageBox.Show(ex.ToString());
											}
										}
										else
										{
											bool flag48 = FIREHOSE_MANAGER.MenuMan == FIREHOSE_MANAGER.MenuManual.reboot;
											if (flag48)
											{
												string xml5 = FIREHOSE.pkt_sendReset();
												FIREHOSE_MANAGER.SendXml(xml5);
											}
										}
									}
								}
							}
						}
						else
						{
							bool flag49 = Directory.Exists("temp");
							if (flag49)
							{
								Directory.Delete("temp", true);
								Directory.CreateDirectory("temp");
							}
							else
							{
								Directory.CreateDirectory("temp");
							}
							long num6 = 0L;
							long num7 = 0L;
							bool flag50 = FIREHOSE_MANAGER.StringXml.ToLower().Contains("patch");
							XmlTextReader xmlTextReader;
							if (flag50)
							{
								xmlTextReader = new XmlTextReader(new StringReader(FIREHOSE_MANAGER.StringXml));
								while (xmlTextReader.Read())
								{
									bool flag51 = xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "patch";
									if (flag51)
									{
										string attribute24 = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES");
										string attribute25 = xmlTextReader.GetAttribute("byte_offset");
										string attribute26 = xmlTextReader.GetAttribute("filename");
										string attribute27 = xmlTextReader.GetAttribute("physical_partition_number");
										string attribute28 = xmlTextReader.GetAttribute("size_in_bytes");
										string attribute29 = xmlTextReader.GetAttribute("start_sector");
										string attribute30 = xmlTextReader.GetAttribute("value");
										string attribute31 = xmlTextReader.GetAttribute("what");
										bool flag52 = attribute26.ToLower().Contains("disk");
										if (flag52)
										{
											num6 += 1L;
										}
									}
								}
							}
							xmlTextReader = new XmlTextReader(new StringReader(FIREHOSE_MANAGER.StringXml));
							while (xmlTextReader.Read())
							{
								bool flag53 = xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "patch";
								if (flag53)
								{
									string attribute32 = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES");
									string attribute33 = xmlTextReader.GetAttribute("byte_offset");
									string attribute34 = xmlTextReader.GetAttribute("filename");
									string attribute35 = xmlTextReader.GetAttribute("physical_partition_number");
									string attribute36 = xmlTextReader.GetAttribute("size_in_bytes");
									string attribute37 = xmlTextReader.GetAttribute("start_sector");
									string attribute38 = xmlTextReader.GetAttribute("value");
									string attribute39 = xmlTextReader.GetAttribute("what");
									bool flag54 = attribute34.ToLower().Contains("disk");
									if (flag54)
									{
										string xml6 = FIREHOSE.pkt_patch(attribute32, attribute33, attribute34, attribute35, attribute36, attribute37, attribute38, attribute39);
										num7 += 1L;
										bool flag55 = num7 == 1L;
										if (flag55)
										{
											uiManager.logs("Patch Partition Data : ", false, (uiManager.MessageType)uiManager.Hitam);
											FIREHOSE_MANAGER.SendXml(xml6);
											bool flag56 = FIREHOSE_MANAGER.IsAck();
											bool flag57 = !flag56;
											if (flag57)
											{
												return;
											}
											uiManager.ProcessBar1(num7, num6);
										}
										else
										{
											FIREHOSE_MANAGER.SendXmlFast(xml6);
										}
										bool flag58 = num7 == num6;
										if (flag58)
										{
											uiManager.ProcessBar1(num6, num6);
											uiManager.logs("Done ", true, (uiManager.MessageType)uiManager.Kuning);
										}
									}
								}
								bool flag59 = xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "erase";
								if (flag59)
								{
									string attribute40 = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES");
									string attribute41 = xmlTextReader.GetAttribute("num_partition_sectors");
									string attribute42 = xmlTextReader.GetAttribute("physical_partition_number");
									string attribute43 = xmlTextReader.GetAttribute("start_sector");
									string attribute44 = xmlTextReader.GetAttribute("label");
									uiManager.logs("Erase Sector " + attribute43 + ": ", false, (uiManager.MessageType)uiManager.Hitam);
									bool flag60 = FIREHOSE_MANAGER.EraseParts(attribute40, attribute41, attribute42, attribute43, ref attribute44);
									bool flag61 = !flag60;
									if (flag61)
									{
										uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
										return;
									}
									uiManager.logs("Done", true, (uiManager.MessageType)uiManager.Kuning);
								}
								bool flag62 = xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "program";
								if (flag62)
								{
									string attribute45 = xmlTextReader.GetAttribute("SECTOR_SIZE_IN_BYTES");
									string attribute46 = xmlTextReader.GetAttribute("num_partition_sectors");
									string attribute47 = xmlTextReader.GetAttribute("filename");
									string attribute48 = xmlTextReader.GetAttribute("physical_partition_number");
									string attribute49 = xmlTextReader.GetAttribute("label");
									string attribute50 = xmlTextReader.GetAttribute("start_sector");
									bool flag63 = string.IsNullOrEmpty(attribute47);
									if (flag63)
									{
										uiManager.logs("Writing data : ", false, (uiManager.MessageType)uiManager.Hitam);
										bool flag64 = FIREHOSE_MANAGER.EraseParts(attribute45, attribute46, attribute48, attribute50, ref attribute49);
										bool flag65 = !flag64;
										if (flag65)
										{
											uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
											return;
										}
										uiManager.logs("Done", true, (uiManager.MessageType)uiManager.Kuning);
									}
									else
									{
										bool flag66 = !string.IsNullOrEmpty(FIREHOSE_MANAGER.SelectedExecution);
										if (flag66)
										{
											bool flag67 = FIREHOSE_MANAGER.SelectedExecution.ToLower().Contains("xiaomi");
											if (flag67)
											{
												FIREHOSE_MANAGER.foldersave = "temp";
												bool flag68 = attribute49.Contains("modem");
												if (flag68)
												{
													uiManager.logs("Reading Data : ", false, (uiManager.MessageType)uiManager.Hitam);
													bool flag69 = FIREHOSE_MANAGER.ReadPart(attribute50, attribute46, attribute45, attribute48, ref attribute49);
													bool flag70 = !flag69;
													if (flag70)
													{
														uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
														return;
													}
													uiManager.logs("Done", true, (uiManager.MessageType)uiManager.Hijau);
													bool flag71 = File.Exists("temp/" + FIREHOSE_MANAGER.getfilenames(attribute49));
													if (flag71)
													{
														uiManager.logs("Patching Data : ", false, (uiManager.MessageType)uiManager.Hitam);
														FIREHOSE_MANAGER.FilesOneClick = FIREHOSE_MANAGER.HexReplace("temp/" + FIREHOSE_MANAGER.getfilenames(attribute49), "CARDAPP", "SLOTAPP");
														bool flag72 = FIREHOSE_MANAGER.FilesOneClick.Length == 0;
														if (flag72)
														{
															uiManager.logs("No Security Founds", true, (uiManager.MessageType)uiManager.Merah);
															continue;
														}
														uiManager.logs("Done", true, (uiManager.MessageType)uiManager.Kuning);
														bool flag73 = FIREHOSE_MANAGER.WriteEmmc(attribute45, attribute46, attribute48, attribute50, ref attribute49, attribute47);
														bool flag74 = !flag73;
														if (flag74)
														{
															uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
															return;
														}
														uiManager.logs("Done", true, (uiManager.MessageType)uiManager.Kuning);
													}
													else
													{
														uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
													}
												}
												bool flag75 = attribute49 == "persist";
												if (flag75)
												{
													uiManager.logs("Reading Data : ", false, (uiManager.MessageType)uiManager.Hitam);
													bool flag69 = FIREHOSE_MANAGER.ReadPart(attribute50, attribute46, attribute45, attribute48, ref attribute49);
													bool flag76 = !flag69;
													if (flag76)
													{
														uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
														return;
													}
													uiManager.logs("Done", true, (uiManager.MessageType)uiManager.Kuning);
													bool flag77 = File.Exists("temp/persist.img");
													if (flag77)
													{
														uiManager.logs("Patching Data : ", false, (uiManager.MessageType)uiManager.Hitam);
														FIREHOSE_MANAGER.FilesOneClick = FIREHOSE_MANAGER.HexReplace("temp/persist.img", "fdsd", "ftst");
														bool flag78 = FIREHOSE_MANAGER.FilesOneClick.Length == 0;
														if (flag78)
														{
															uiManager.logs("No Acounts Founds", true, (uiManager.MessageType)uiManager.Merah);
														}
														else
														{
															uiManager.logs("Done", true, (uiManager.MessageType)uiManager.Kuning);
															bool flag79 = FIREHOSE_MANAGER.WriteEmmc(attribute45, attribute46, attribute48, attribute50, ref attribute49, attribute47);
															bool flag80 = !flag79;
															if (flag80)
															{
																uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
																return;
															}
															uiManager.logs("Done", true, (uiManager.MessageType)uiManager.Kuning);
														}
													}
													else
													{
														uiManager.logs("Failed", true, (uiManager.MessageType)uiManager.Merah);
													}
												}
											}
										}
									}
								}
							}
							bool checked4 = Main.DelegateFunction.cbreboot.Checked;
							if (checked4)
							{
								FIREHOSE_MANAGER.SendXml(FIREHOSE.pkt_sendReset());
							}
						}
					}
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.ToString());
				}
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000D580 File Offset: 0x0000B780
		public static bool CekSparse(byte[] DataFiles)
		{
			bool result = false;
			bool flag = DataFiles.Length == 0;
			if (flag)
			{
				result = false;
			}
			else
			{
				Stream stream = new MemoryStream(DataFiles);
				byte[] array = new byte[1024];
				using (BinaryReader binaryReader = new BinaryReader(stream))
				{
					binaryReader.Read(array, 0, 28);
					FIREHOSE.sparseheader = FIREHOSE.parsingheader(array);
					int dwMagic = FIREHOSE.sparseheader.dwMagic;
					long num = Convert.ToInt64(Math.Round(NumericHelper.Val("&HE" + Convert.ToString(dwMagic, 16).ToUpper())));
					bool flag2 = num == 64108298042L;
					if (flag2)
					{
						FIREHOSE_MANAGER.totalchunk = FIREHOSE.sparseheader.dwTotalChunks;
						stream.Flush();
						stream.Close();
						binaryReader.Close();
						result = true;
					}
					else
					{
						stream.Flush();
						stream.Close();
						binaryReader.Close();
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000D68C File Offset: 0x0000B88C
		public static long bulat(double number)
		{
			return Convert.ToInt64(Math.Round(-Math.Floor(-number)));
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000D6B0 File Offset: 0x0000B8B0
		public static bool WriteEmmc(string SectSize, string NumSect, string Physical, string StartSect, ref string label, string Filename)
		{
			DiskWriter.FlushFileBuffers(DiskWriter.OpenWritePort);
			string text = "";
			Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate()
			{
				Main.DelegateFunction.label_totalsize.Text = FIREHOSE_MANAGER.GetFileSizes(checked(Convert.ToInt64(NumSect) * Convert.ToInt64(SectSize)));
			}));
			byte[] array = new byte[1048576];
			Stream stream = new MemoryStream(array);
			bool flag = FIREHOSE_MANAGER.MenuEx == FIREHOSE_MANAGER.MenuEksekusi.manual;
			if (flag)
			{
				bool flag2 = !File.Exists(Filename);
				if (flag2)
				{
					return true;
				}
				stream = new FileStream(Filename, FileMode.Open, FileAccess.Read);
				stream.Read(array, 0, array.Length);
				text = Path.GetFileName(Filename);
			}
			else
			{
				bool flag3 = FIREHOSE_MANAGER.MenuEx == FIREHOSE_MANAGER.MenuEksekusi.oneclick;
				if (flag3)
				{
					stream = new MemoryStream(FIREHOSE_MANAGER.FilesOneClick);
					stream.Read(array, 0, array.Length);
					text = "Data";
				}
			}
			Console.WriteLine(string.Concat(new string[]
			{
				SectSize + " ",
				NumSect + " ",
				Physical + " ",
				StartSect + " ",
				label + " ",
				Filename
			}));
			stream.Seek(0L, SeekOrigin.Begin);
			bool flag4 = FIREHOSE_MANAGER.CekSparse(array);
			bool result;
			if (flag4)
			{
				uiManager.logs(string.Concat(new string[]
				{
					"[",
					Physical,
					"] Writing ",
					label,
					" -> ",
					text,
					" [sparse]: "
				}), false, (uiManager.MessageType)uiManager.Hitam);
				long num = 0L;
				long num2 = 0L;
				int num3 = 0;
				long num4 = 0L;
				long num5 = 0L;
				bool flag5 = FIREHOSE_MANAGER.totalchunk > 0;
				if (flag5)
				{
					int num6 = 0;
					using (BinaryReader binaryReader = new BinaryReader(stream))
					{
						byte[] array2 = new byte[1048576];
						Stopwatch stopwatch = new Stopwatch();
						stopwatch.Start();
						FIREHOSE.chunkheader = default(FIREHOSE.CHUNK_HEADER);
						for (;;)
						{
							try
							{
								bool flag6 = num6 == 0;
								bool flag15;
								checked
								{
									double num7;
									long num9;
									if (flag6)
									{
										binaryReader.BaseStream.Seek(28L, SeekOrigin.Begin);
										binaryReader.Read(array2, 0, 12);
										FIREHOSE.chunkheader.wChunkType = BitConverter.ToInt16(array2.Skip(0).Take(2).ToArray<byte>(), 0);
										FIREHOSE.chunkheader.dwChunkSize = BitConverter.ToInt32(array2.Skip(4).Take(4).ToArray<byte>(), 0);
										FIREHOSE.chunkheader.dwTotalSize = BitConverter.ToInt32(array2.Skip(8).Take(4).ToArray<byte>(), 0);
										short wChunkType = FIREHOSE.chunkheader.wChunkType;
										num7 = NumericHelper.Val("&HE" + Convert.ToString(wChunkType, 16).ToUpper());
										int dwTotalSize = FIREHOSE.chunkheader.dwTotalSize;
										long num8 = unchecked((long)FIREHOSE.chunkheader.dwChunkSize);
										num9 = num8 * unchecked((long)FIREHOSE.sparseheader.dwBlockSize);
										num += unchecked((long)FIREHOSE.chunkheader.dwTotalSize);
										num2 = 0L;
									}
									else
									{
										binaryReader.BaseStream.Seek(num + 28L, SeekOrigin.Begin);
										binaryReader.Read(array2, 0, 12);
										FIREHOSE.chunkheader.wChunkType = BitConverter.ToInt16(array2.Skip(0).Take(12).ToArray<byte>(), 0);
										FIREHOSE.chunkheader.dwChunkSize = BitConverter.ToInt32(array2.Skip(4).Take(4).ToArray<byte>(), 0);
										FIREHOSE.chunkheader.dwTotalSize = BitConverter.ToInt32(array2.Skip(8).Take(4).ToArray<byte>(), 0);
										short wChunkType = FIREHOSE.chunkheader.wChunkType;
										num7 = NumericHelper.Val("&HE" + Convert.ToString(wChunkType, 16).ToUpper());
										int dwTotalSize = FIREHOSE.chunkheader.dwTotalSize;
										num += unchecked((long)FIREHOSE.chunkheader.dwTotalSize);
										long num8 = unchecked((long)FIREHOSE.chunkheader.dwChunkSize);
										num9 = num8 * unchecked((long)FIREHOSE.sparseheader.dwBlockSize);
										num2 += num9 / unchecked((long)Convert.ToInt32(SectSize));
									}
									bool flag7 = num7 == 969409.0;
									if (flag7)
									{
										num3++;
										int num10 = 1048576;
										long num11;
										bool flag8;
										long bytesWritten;
										unchecked
										{
											num11 = num9 / (long)Convert.ToInt32(SectSize);
											bytesWritten = 0L;
											flag8 = (num9 <= (long)num10);
										}
										if (flag8)
										{
											num10 = (int)num9;
										}
										int num12 = 0;
										string xml = FIREHOSE.pkt_Program(SectSize, num11.ToString(), Physical, StartSect + num4.ToString());
										num4 += num11;
										FIREHOSE_MANAGER.SendXml(xml);
										bool flag9 = !FIREHOSE_MANAGER.IsAckFast();
										if (flag9)
										{
											uiManager.logs("Failed ", false, (uiManager.MessageType)uiManager.Merah);
											return false;
										}
                                        var lbl = Main.DelegateFunction.label_writensize;

                                        // 2. 缓存更新 UI 的委托，只创建一次
                                        Action updateUI = () =>
                                        {
                                            if (lbl != null)
                                                lbl.Text = FIREHOSE_MANAGER.GetFileSizes(bytesWritten);
                                        };
                                        for (;;)
										{
											bool flag10 = num9 - bytesWritten < unchecked((long)num10);
											if (flag10)
											{
												num10 = (int)(num9 - bytesWritten);
											}
											bool flag11 = bytesWritten == num9;
											if (flag11)
											{
												bool flag12 = FIREHOSE_MANAGER.IsAckFast();
												if (flag12)
												{
													break;
												}
											}
											byte[] array3 = new byte[num10];
											binaryReader.Read(array3, 0, num10);
											DiskWriter.DiskWrite(array3);
											num5 += unchecked((long)array3.Length);
											bytesWritten += unchecked((long)array3.Length);
											num12 += array3.Length;
                                            if (lbl.InvokeRequired)
                                                lbl.Invoke(updateUI);
                                            else
                                                updateUI();
                                            TimeSpan elapsed = stopwatch.Elapsed;
											double speed = (double)bytesWritten / elapsed.TotalSeconds;
											Main.DelegateFunction.label_transferrate.Invoke(new Action(delegate()
											{
												Main.DelegateFunction.label_transferrate.Text = FIREHOSE_MANAGER.GetFileSizes(Convert.ToInt64(speed)) + " /s";
											}));
											uiManager.ProcessBar1(bytesWritten, num9);
										}
										stopwatch.Stop();
										Main.DelegateFunction.label_transferrate.Invoke(new Action(delegate()
										{
											Main.DelegateFunction.label_transferrate.Text = "0.00 Bytes / s";
										}));
									}
									else
									{
										bool flag13 = num7 == 969410.0;
										if (flag13)
										{
											long num13 = num9 / unchecked((long)Convert.ToInt32(SectSize));
											num4 += num13;
										}
										else
										{
											bool flag14 = num7 == 969411.0;
											if (flag14)
											{
												long num14 = num9 / unchecked((long)Convert.ToInt32(SectSize));
												num4 += num14;
											}
										}
									}
									num6++;
									flag15 = (num6 == FIREHOSE_MANAGER.totalchunk);
								}
								if (flag15)
								{
									uiManager.ProcessBar2((long)num6, (long)FIREHOSE_MANAGER.totalchunk);
									stream.Flush();
									stream.Close();
									binaryReader.Close();
									return true;
								}
								uiManager.ProcessBar2((long)num6, (long)FIREHOSE_MANAGER.totalchunk);
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.ToString());
								stream.Flush();
								stream.Close();
								return false;
							}
						}
					}
				}
				Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.label_totalsize.Text = "0.00 Bytes           ";
				}));
				Main.DelegateFunction.label_writensize.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.label_writensize.Text = "0.00 Bytes           ";
				}));
				stream.Flush();
				stream.Close();
				result = false;
			}
			else
			{
				stream.Seek(0L, SeekOrigin.Begin);
				uiManager.logs(string.Concat(new string[]
				{
					"[",
					Physical,
					"] Writing ",
					label,
					" -> ",
					text,
					" [raw]: "
				}), false, (uiManager.MessageType)uiManager.Hitam);
				long num15 = 0L;
				bool flag16 = FIREHOSE_MANAGER.MenuEx == FIREHOSE_MANAGER.MenuEksekusi.manual;
				if (flag16)
				{
					FileInfo fileInfo = new FileInfo(Filename);
					num15 = fileInfo.Length;
				}
				else
				{
					bool flag17 = FIREHOSE_MANAGER.MenuEx == FIREHOSE_MANAGER.MenuEksekusi.oneclick;
					if (flag17)
					{
						num15 = (long)FIREHOSE_MANAGER.FilesOneClick.Length;
					}
				}
				int num16 = 1048576;
				long num17 = FIREHOSE_MANAGER.bulat((double)(num15 / (long)Convert.ToInt32(SectSize)));
				long num18 = checked(num17 * unchecked((long)Convert.ToInt32(SectSize)));
				bool flag18 = string.CompareOrdinal(num15.ToString(), SectSize) < 0;
				if (flag18)
				{
					num17 = 1L;
					num18 = (long)Convert.ToInt32(SectSize);
					num16 = 512;
				}
				string xml2 = FIREHOSE.pkt_Program(SectSize, num17.ToString(), Physical, StartSect);
				FIREHOSE_MANAGER.SendXml(xml2);
				bool flag19 = FIREHOSE_MANAGER.IsAck();
				bool flag20 = flag19;
				checked
				{
					if (flag20)
					{
						long TotalWriten = 0L;
						using (BinaryReader binaryReader2 = new BinaryReader(stream))
						{
							Stopwatch stopwatch2 = new Stopwatch();
							stopwatch2.Start();
                            try
                            {
                                // 用一个局部变量缓存匿名方法即可通过编译
                                Action cachedUpdateSize1 = null;
                                Action cachedUpdateSize2 = null;

                                for (; ; )
                                {
                                    if (TotalWriten == num18)
                                        break;

                                    bool flag22 = num18 - TotalWriten < unchecked((long)num16);
                                    if (flag22)
                                    {
                                        num16 = (int)(num18 - TotalWriten);
                                        byte[] array4 = new byte[num16];
                                        binaryReader2.Read(array4, 0, num16);
                                        DiskWriter.DiskWrite(array4);
                                        TotalWriten += unchecked((long)array4.Length);

                                        Control label_writensize2 = Main.DelegateFunction.label_writensize;
                                        label_writensize2.Invoke(
                                            cachedUpdateSize1 ?? (cachedUpdateSize1 = new Action(delegate ()
                                            {
                                                Main.DelegateFunction.label_writensize.Text =
                                                    FIREHOSE_MANAGER.GetFileSizes(TotalWriten);
                                            }))
                                        );

                                        TimeSpan elapsed2 = stopwatch2.Elapsed;
                                        double speed = (double)TotalWriten / elapsed2.TotalSeconds;
                                        Main.DelegateFunction.label_transferrate.Invoke(
                                            new Action(delegate ()
                                            {
                                                Main.DelegateFunction.label_transferrate.Text =
                                                    FIREHOSE_MANAGER.GetFileSizes(Convert.ToInt64(speed)) + " /s";
                                            })
                                        );

                                        uiManager.ProcessBar1(TotalWriten, num18);
                                    }
                                    else
                                    {
                                        byte[] array5 = new byte[num16];
                                        binaryReader2.Read(array5, 0, num16);
                                        DiskWriter.DiskWrite(array5);
                                        TotalWriten += unchecked((long)array5.Length);

                                        Control label_writensize3 = Main.DelegateFunction.label_writensize;
                                        label_writensize3.Invoke(
                                            cachedUpdateSize2 ?? (cachedUpdateSize2 = new Action(delegate ()
                                            {
                                                Main.DelegateFunction.label_writensize.Text =
                                                    FIREHOSE_MANAGER.GetFileSizes(TotalWriten);
                                            }))
                                        );

                                        TimeSpan elapsed3 = stopwatch2.Elapsed;
                                        double speed = (double)TotalWriten / elapsed3.TotalSeconds;
                                        Main.DelegateFunction.label_transferrate.Invoke(
                                            new Action(delegate ()
                                            {
                                                Main.DelegateFunction.label_transferrate.Text =
                                                    FIREHOSE_MANAGER.GetFileSizes(Convert.ToInt64(speed)) + " /s";
                                            })
                                        );

                                        uiManager.ProcessBar1(TotalWriten, num18);
                                    }
                                }

                                if (FIREHOSE_MANAGER.IsAck())
                                {
                                    Main.DelegateFunction.label_totalsize.Invoke(
                                        new Action(delegate ()
                                        {
                                            Main.DelegateFunction.label_totalsize.Text = "0.00 Bytes           ";
                                        })
                                    );
                                    Main.DelegateFunction.label_writensize.Invoke(
                                        new Action(delegate ()
                                        {
                                            Main.DelegateFunction.label_writensize.Text = "0.00 Bytes           ";
                                        })
                                    );
                                    binaryReader2.Close();
                                    return true;
                                }

                                binaryReader2.Close();
                                return false;
                            }
                            catch (Exception ex2)
                            {
                                stream.Flush();
                                stream.Close();
                                uiManager.logs(ex2.ToString(), false, (uiManager.MessageType)uiManager.Merah);
                                return false;
                            }
                        }
					}
					uiManager.logs("Failed ", false, (uiManager.MessageType)uiManager.Merah);
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000E2B8 File Offset: 0x0000C4B8
		public static string ReadPartWarning(string NumPartition, string pname)
		{
			return "Read " + pname + " skipped!";
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000E2DC File Offset: 0x0000C4DC
		public static bool ReadPart(string Startsector, string NumPartition, string SectSize, string physical, ref string pname)
		{
			bool flag = string.CompareOrdinal(NumPartition, "1") < 0;
			checked
			{
				bool result;
				if (flag)
				{
					uiManager.logs(FIREHOSE_MANAGER.ReadPartWarning(NumPartition, pname), true, (uiManager.MessageType)uiManager.Kuning);
					result = true;
				}
				else
				{
                    try
                    {
                        DiskWriter.FlushFileBuffers(DiskWriter.OpenWritePort);
                        int num = 0;
                        long BYTES_TO_READ = Convert.ToInt64(NumPartition) * Convert.ToInt64(SectSize);
                        long fileOffset = 0L;
                        long num2 = 0L;

                        Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                        {
                            Main.DelegateFunction.label_totalsize.Text = FIREHOSE_MANAGER.GetFileSizes(BYTES_TO_READ);
                        }));

                        string xml = FIREHOSE.pkt_read(SectSize, NumPartition, physical, Startsector);
                        FileStream fileStream = new FileStream(FIREHOSE_MANAGER.foldersave + "\\" + FIREHOSE_MANAGER.getfilenames(pname), FileMode.Append, FileAccess.Write);
                        using (fileStream)
                        {
                            byte[] array = new byte[8192];
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            FIREHOSE_MANAGER.SendXml(xml);
                            byte[] array2 = FIREHOSE_MANAGER.readByte();
                            bool flag2 = array2.Length != 0;
                            if (flag2)
                            {
                                fileOffset += unchecked((long)array2.Length);
                                num2 -= unchecked((long)array2.Length);
                                bool flag3 = fileOffset >= BYTES_TO_READ;
                                if (flag3)
                                {
                                    fileStream.Write(array2, 0, (int)BYTES_TO_READ);
                                    uiManager.ProcessBar1(BYTES_TO_READ, BYTES_TO_READ);
                                    fileStream.Flush();
                                    fileStream.Close();
                                    return true;
                                }
                                fileStream.Write(array2, 0, array2.Length);
                                uiManager.ProcessBar1(fileOffset, BYTES_TO_READ);
                            }

                            // 唯一改动：用一个局部变量替换编译器生成的 <>9__4
                            Action cachedUpdateSize = null;

                            for (; ; )
                            {
                                array = DiskWriter.DiskRead(0);
                                fileOffset += unchecked((long)array.Length);

                                Control label_writensize = Main.DelegateFunction.label_writensize;
                                label_writensize.Invoke(
                                    cachedUpdateSize ?? (cachedUpdateSize = new Action(delegate ()
                                    {
                                        Main.DelegateFunction.label_writensize.Text = FIREHOSE_MANAGER.GetFileSizes(Convert.ToInt64(fileOffset));
                                    }))
                                );

                                TimeSpan elapsed = stopwatch.Elapsed;
                                double speed = (double)fileOffset / elapsed.TotalSeconds;
                                Main.DelegateFunction.label_transferrate.Invoke(new Action(delegate ()
                                {
                                    Main.DelegateFunction.label_transferrate.Text = FIREHOSE_MANAGER.GetFileSizes(Convert.ToInt64(speed)) + " /s";
                                }));

                                bool flag4 = fileOffset > BYTES_TO_READ;
                                if (flag4)
                                    break;

                                fileStream.Write(array, 0, array.Length);
                                uiManager.ProcessBar1(fileOffset, BYTES_TO_READ);
                                num++;
                            }

                            long num3 = fileOffset - BYTES_TO_READ;
                            long num4 = unchecked((long)array.Length) - num3;
                            byte[] array3 = array.Take((int)num4).ToArray<byte>();
                            fileStream.Write(array3, 0, array3.Length);
                            uiManager.ProcessBar1(fileOffset - num3, BYTES_TO_READ);
                            fileStream.Flush();
                            fileStream.Close();
                            stopwatch.Stop();

                            Main.DelegateFunction.label_transferrate.Invoke(new Action(delegate ()
                            {
                                Main.DelegateFunction.label_transferrate.Text = "0.00 Bytes / s";
                            }));
                        }

                        Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate ()
                        {
                            Main.DelegateFunction.label_totalsize.Text = "0.00 Bytes           ";
                        }));

                        Main.DelegateFunction.label_writensize.Invoke(new Action(delegate ()
                        {
                            Main.DelegateFunction.label_writensize.Text = "0.00 Bytes           ";
                        }));

                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return false;
                    }
                }
				return result;
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000E694 File Offset: 0x0000C894
		public static bool EraseParts(string SectSize, string numPartSect, string PhysicalPartition, string startSector, ref string label)
		{
			DiskWriter.FlushFileBuffers(DiskWriter.OpenWritePort);
			Main.DelegateFunction.label_totalsize.Invoke(new Action(delegate()
			{
				Main.DelegateFunction.label_totalsize.Text = FIREHOSE_MANAGER.GetFileSizes(checked(Convert.ToInt64(numPartSect) * Convert.ToInt64(SectSize)));
			}));
			int num = 1048576;
			int num2 = 1048576;
			bool flag = Convert.ToSingle(numPartSect) * (float)string.CompareOrdinal(SectSize, num.ToString()) >= 0f;
			long num3;
			if (flag)
			{
				num3 = (long)(num / Convert.ToInt32(SectSize));
			}
			else
			{
				num3 = Convert.ToInt64(numPartSect);
			}
			bool flag2 = numPartSect == "0";
			if (flag2)
			{
				num3 = (long)(num / Convert.ToInt32(SectSize));
			}
			checked
			{
				long num4 = num3 * unchecked((long)Convert.ToInt32(SectSize));
				long num5 = 0L;
				long num6 = 0L;
				int num7 = 0;
				string xml = FIREHOSE.pkt_Program(FIREHOSE_MANAGER.SectorSize, num3.ToString(), PhysicalPartition, startSector);
				FIREHOSE_MANAGER.SendXml(xml);
				bool flag3 = !FIREHOSE_MANAGER.IsAck();
				bool result;
				if (flag3)
				{
					result = false;
				}
				else
				{
					try
					{
						for (;;)
						{
							bool flag4 = num5 == num4;
							if (flag4)
							{
								break;
							}
							bool flag5 = num4 - num5 < unchecked((long)num2);
							if (flag5)
							{
								num2 = (int)(num4 - num5);
							}
							byte[] array = new byte[num2];
							DiskWriter.DiskWrite(array);
							num5 += unchecked((long)array.Length);
							num6 += unchecked((long)array.Length);
							num7++;
						}
						bool flag6 = FIREHOSE_MANAGER.IsAck();
						if (flag6)
						{
							result = true;
						}
						else
						{
							result = false;
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
						result = false;
					}
				}
				return result;
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000E848 File Offset: 0x0000CA48
		public static void ParsePartions(int startingLbaPe, string storage, string lun)
		{
			FIREHOSE_MANAGER.ListPartitionName.Items.Clear();
			FIREHOSE_MANAGER.ListStartSector.Items.Clear();
			FIREHOSE_MANAGER.ListLastSector.Items.Clear();
			FIREHOSE_MANAGER.listSectorSize.Items.Clear();
			FIREHOSE_MANAGER.listPhysicalPartition.Items.Clear();
			bool flag = storage.ToLower() == "emmc";
			checked
			{
				if (flag)
				{
					FIREHOSE_MANAGER.SendXml(FIREHOSE.pkt_read("512", "100", lun, "2"));
					byte[] source = FIREHOSE_MANAGER.readByte(51200);
					int num = 0;
					FIREHOSE.gpt.entries = new List<FIREHOSE.gpt_partition_entry>();
					for (;;)
					{
						try
						{
							FIREHOSE.gpt_partition_entry gpt_partition_entry = default(FIREHOSE.gpt_partition_entry);
							bool flag2 = num > 128;
							if (!flag2)
							{
								bool flag3 = num == 0;
								if (flag3)
								{
									gpt_partition_entry.partTypeGUID = Encoding.UTF8.GetString(source.Skip(0).Take(16).ToArray<byte>(), 0, 16);
									gpt_partition_entry.partID = Encoding.UTF8.GetString(source.Skip(16).Take(16).ToArray<byte>(), 0, 16);
									gpt_partition_entry.first_lba = BitConverter.ToInt32(source.Skip(32).Take(8).ToArray<byte>(), 0);
									gpt_partition_entry.last_lba = BitConverter.ToInt32(source.Skip(40).Take(8).ToArray<byte>(), 0);
									gpt_partition_entry.flags = source.Skip(48).Take(8).ToArray<byte>();
									gpt_partition_entry.partName = Encoding.UTF8.GetString(source.Skip(56).Take(72).ToArray<byte>(), 0, 72).Trim(new char[1]);
									gpt_partition_entry.partName = gpt_partition_entry.partName.Replace("\0", "");
								}
								else
								{
									int num2 = num * 128;
									gpt_partition_entry.partTypeGUID = Encoding.UTF8.GetString(source.Skip(num2).Take(16).ToArray<byte>(), 0, 16);
									gpt_partition_entry.partID = Encoding.UTF8.GetString(source.Skip(num2 + 16).Take(16).ToArray<byte>(), 0, 16);
									gpt_partition_entry.first_lba = BitConverter.ToInt32(source.Skip(num2 + 32).Take(8).ToArray<byte>(), 0);
									gpt_partition_entry.last_lba = BitConverter.ToInt32(source.Skip(num2 + 40).Take(8).ToArray<byte>(), 0);
									gpt_partition_entry.flags = source.Skip(num2 + 48).Take(8).ToArray<byte>();
									gpt_partition_entry.partName = Encoding.ASCII.GetString(source.Skip(num2 + 56).Take(72).ToArray<byte>()).Trim(new char[1]);
									gpt_partition_entry.partName = gpt_partition_entry.partName.Replace("\0", "");
								}
								bool flag4 = string.IsNullOrEmpty(gpt_partition_entry.partName);
								if (!flag4)
								{
									bool flag5 = !string.IsNullOrEmpty(gpt_partition_entry.partName);
									if (flag5)
									{
										FIREHOSE_MANAGER.ListPartitionName.Items.Add(gpt_partition_entry.partName);
										FIREHOSE_MANAGER.ListStartSector.Items.Add(gpt_partition_entry.first_lba.ToString());
										FIREHOSE_MANAGER.ListLastSector.Items.Add(gpt_partition_entry.last_lba.ToString());
										FIREHOSE_MANAGER.listSectorSize.Items.Add("512");
										FIREHOSE_MANAGER.listPhysicalPartition.Items.Add("0");
										num++;
										continue;
									}
								}
							}
						}
						catch (Exception ex)
						{
						}
						break;
					}
					Main.DelegateFunction.DataView.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.DataView.Rows.Add(new object[]
						{
							false,
							"PrimaryGPT",
							"Double click to add file...",
							"0",
							"34",
							"0",
							"512"
						});
					}));
					Main.DelegateFunction.DataView.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.DataView.Rows.Add(new object[]
						{
							false,
							"BackupGPT",
							"Double click to add file...",
							"NUM_DISK_SECTORS-33.",
							"33",
							"0",
							"512"
						});
					}));
					int kk2;
					int kk;
					for (kk = 0; kk < FIREHOSE_MANAGER.ListPartitionName.Items.Count; kk = kk2 + 1)
					{
						Console.WriteLine(string.Concat(new object[]
						{
							"false",
							" ",
							FIREHOSE_MANAGER.ListPartitionName.Items[kk],
							" ",
							"Double click to add file...",
							" ",
							FIREHOSE_MANAGER.ListStartSector.Items[kk],
							" ",
							Convert.ToInt32(FIREHOSE_MANAGER.ListLastSector.Items[kk].ToString()) - Convert.ToInt32(FIREHOSE_MANAGER.ListStartSector.Items[kk].ToString()) + 1,
							" ",
							FIREHOSE_MANAGER.listPhysicalPartition.Items[kk],
							" ",
							"512"
						}));
						Main.DelegateFunction.DataView.Invoke(new Action(delegate()
						{
							Main.DelegateFunction.DataView.Rows.Add(new object[]
							{
								false,
								FIREHOSE_MANAGER.ListPartitionName.Items[kk].ToString(),
								"Double click to add file...",
								FIREHOSE_MANAGER.ListStartSector.Items[kk].ToString(),
								(Convert.ToInt32(FIREHOSE_MANAGER.ListLastSector.Items[kk]) - Convert.ToInt32(FIREHOSE_MANAGER.ListStartSector.Items[kk]) + 1).ToString(),
								FIREHOSE_MANAGER.listPhysicalPartition.Items[kk].ToString(),
								"512"
							});
						}));
						kk2 = kk;
					}
				}
				else
				{
					bool flag6 = storage.ToLower() == "ufs";
					if (flag6)
					{
						FIREHOSE_MANAGER.SendXml(FIREHOSE.pkt_read("4096", "100", lun, "2"));
						byte[] source2 = FIREHOSE_MANAGER.readByte(409600);
						int num3 = 0;
						FIREHOSE.gpt.entries = new List<FIREHOSE.gpt_partition_entry>();
						for (;;)
						{
							try
							{
								FIREHOSE.gpt_partition_entry gpt_partition_entry2 = default(FIREHOSE.gpt_partition_entry);
								bool flag7 = num3 > 128;
								if (!flag7)
								{
									bool flag8 = num3 == 0;
									if (flag8)
									{
										gpt_partition_entry2.partTypeGUID = Encoding.UTF8.GetString(source2.Skip(0).Take(16).ToArray<byte>(), 0, 16);
										gpt_partition_entry2.partID = Encoding.UTF8.GetString(source2.Skip(16).Take(16).ToArray<byte>(), 0, 16);
										gpt_partition_entry2.first_lba = BitConverter.ToInt32(source2.Skip(32).Take(8).ToArray<byte>(), 0);
										gpt_partition_entry2.last_lba = BitConverter.ToInt32(source2.Skip(40).Take(8).ToArray<byte>(), 0);
										gpt_partition_entry2.flags = source2.Skip(48).Take(8).ToArray<byte>();
										gpt_partition_entry2.partName = Encoding.UTF8.GetString(source2.Skip(56).Take(72).ToArray<byte>(), 0, 72).Trim(new char[1]);
										gpt_partition_entry2.partName = gpt_partition_entry2.partName.Replace("\0", "");
									}
									else
									{
										int num4 = num3 * 128;
										gpt_partition_entry2.partTypeGUID = Encoding.UTF8.GetString(source2.Skip(num4).Take(16).ToArray<byte>(), 0, 16);
										gpt_partition_entry2.partID = Encoding.UTF8.GetString(source2.Skip(num4 + 16).Take(16).ToArray<byte>(), 0, 16);
										gpt_partition_entry2.first_lba = BitConverter.ToInt32(source2.Skip(num4 + 32).Take(8).ToArray<byte>(), 0);
										gpt_partition_entry2.last_lba = BitConverter.ToInt32(source2.Skip(num4 + 40).Take(8).ToArray<byte>(), 0);
										gpt_partition_entry2.flags = source2.Skip(num4 + 48).Take(8).ToArray<byte>();
										gpt_partition_entry2.partName = Encoding.ASCII.GetString(source2.Skip(num4 + 56).Take(72).ToArray<byte>()).Trim(new char[1]);
										gpt_partition_entry2.partName = gpt_partition_entry2.partName.Replace("\0", "");
									}
									bool flag9 = string.IsNullOrEmpty(gpt_partition_entry2.partName);
									if (!flag9)
									{
										bool flag10 = !string.IsNullOrEmpty(gpt_partition_entry2.partName);
										if (flag10)
										{
											FIREHOSE_MANAGER.ListPartitionName.Items.Add(gpt_partition_entry2.partName);
											FIREHOSE_MANAGER.ListStartSector.Items.Add(gpt_partition_entry2.first_lba.ToString());
											FIREHOSE_MANAGER.ListLastSector.Items.Add(gpt_partition_entry2.last_lba.ToString());
											FIREHOSE_MANAGER.listSectorSize.Items.Add("4096");
											FIREHOSE_MANAGER.listPhysicalPartition.Items.Add(lun);
											num3++;
											continue;
										}
									}
								}
							}
							catch (Exception ex2)
							{
							}
							break;
						}
						Main.DelegateFunction.DataView.Invoke(new Action(delegate()
						{
							Main.DelegateFunction.DataView.Rows.Add(new object[]
							{
								false,
								"0",
								"4096",
								"PrimaryGPT",
								"0",
								"6",
								"Double click to add file..."
							});
						}));
						Main.DelegateFunction.DataView.Invoke(new Action(delegate()
						{
							Main.DelegateFunction.DataView.Rows.Add(new object[]
							{
								false,
								"0",
								"4096",
								"BackupGPT",
								"NUM_DISK_SECTORS-5.",
								"5",
								"Double click to add file..."
							});
						}));
						int kk2;
						int kk;
						for (kk = 0; kk < FIREHOSE_MANAGER.ListPartitionName.Items.Count; kk = kk2 + 1)
						{
							Console.WriteLine(string.Concat(new object[]
							{
								"false",
								" ",
								FIREHOSE_MANAGER.ListPartitionName.Items[kk],
								" ",
								"Double click to add file...",
								" ",
								FIREHOSE_MANAGER.ListStartSector.Items[kk],
								" ",
								Convert.ToInt32(FIREHOSE_MANAGER.ListLastSector.Items[kk].ToString()) - Convert.ToInt32(FIREHOSE_MANAGER.ListStartSector.Items[kk].ToString()) + 1,
								" ",
								FIREHOSE_MANAGER.listPhysicalPartition.Items[kk],
								" ",
								"4096"
							}));
							Main.DelegateFunction.DataView.Invoke(new Action(delegate()
							{
								Main.DelegateFunction.DataView.Rows.Add(new object[]
								{
									false,
									FIREHOSE_MANAGER.ListPartitionName.Items[kk].ToString(),
									"Double click to add file...",
									FIREHOSE_MANAGER.ListStartSector.Items[kk].ToString(),
									(Convert.ToInt32(FIREHOSE_MANAGER.ListLastSector.Items[kk]) - Convert.ToInt32(FIREHOSE_MANAGER.ListStartSector.Items[kk]) + 1).ToString(),
									FIREHOSE_MANAGER.listPhysicalPartition.Items[kk].ToString(),
									"4096"
								});
							}));
							kk2 = kk;
						}
					}
				}
				foreach (object obj in ((IEnumerable)Main.DelegateFunction.DataView.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					bool flag11 = dataGridViewRow.Cells[1].Value.ToString() == "modem" || dataGridViewRow.Cells[1].Value.ToString() == "modemst1" || dataGridViewRow.Cells[1].Value.ToString() == "modemst2" || dataGridViewRow.Cells[1].Value.ToString() == "fsg";
					if (flag11)
					{
						Console.WriteLine(dataGridViewRow.Cells[1].Value.ToString());
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.Red;
					}
				}
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000F420 File Offset: 0x0000D620
		public static bool ParseGPT(string storage, string lun)
		{
			bool flag = storage.ToLower() == "emmc";
			checked
			{
				if (flag)
				{
					FIREHOSE_MANAGER.SendXml(FIREHOSE.pkt_read(FIREHOSE_MANAGER.SectorSize, "1", lun, "1"));
					byte[] array = FIREHOSE_MANAGER.readByte(512);
					bool flag2 = array.Length > 200;
					if (flag2)
					{
						string @string = Encoding.UTF8.GetString(array, 0, array.Length);
						bool flag3 = !@string.Contains("EFI");
						if (flag3)
						{
							uiManager.logs("No Valid Gpt", true, (uiManager.MessageType)uiManager.Merah);
							return false;
						}
						FIREHOSE.gpt.header = new FIREHOSE.gpt_header
						{
							signature = Encoding.UTF8.GetString(array.Skip(0).Take(8).ToArray<byte>(), 0, 8),
							revision = BitConverter.ToInt32(array.Skip(8).Take(4).ToArray<byte>(), 0),
							header_size = BitConverter.ToInt32(array.Skip(12).Take(4).ToArray<byte>(), 0),
							crc_header = BitConverter.ToInt32(array.Skip(16).Take(4).ToArray<byte>(), 0),
							reserved = BitConverter.ToInt32(array.Skip(20).Take(4).ToArray<byte>(), 0),
							current_lba = BitConverter.ToInt32(array.Skip(24).Take(8).ToArray<byte>(), 0),
							backup_lba = BitConverter.ToInt32(array.Skip(32).Take(8).ToArray<byte>(), 0),
							first_usable_lba = BitConverter.ToInt32(array.Skip(40).Take(8).ToArray<byte>(), 0),
							last_usable_lba = unchecked((long)BitConverter.ToInt32(array.Skip(48).Take(8).ToArray<byte>(), 0)),
							disk_guid = array.Skip(56).Take(16).ToArray<byte>(),
							starting_lba_pe = BitConverter.ToInt32(array.Skip(72).Take(8).ToArray<byte>(), 0)
						};
						byte[] array2 = array.Skip(80).Take(4).ToArray<byte>();
						FIREHOSE.gpt.header.number_partitions = BitConverter.ToInt32(array.Skip(80).Take(4).ToArray<byte>(), 0);
						FIREHOSE.gpt.header.size_partition_entries = BitConverter.ToInt32(array.Skip(84).Take(4).ToArray<byte>(), 0);
						uiManager.logs("Found eMMC Storage " + FIREHOSE_MANAGER.GetFileSizes(FIREHOSE.gpt.header.last_usable_lba * unchecked((long)Convert.ToInt32(FIREHOSE_MANAGER.SectorSize))), true, (uiManager.MessageType)uiManager.Hitam);
						return true;
					}
				}
				else
				{
					bool flag4 = storage.ToLower() == "ufs";
					if (flag4)
					{
						int num = 0;
						byte[] array3;
						for (;;)
						{
							bool flag5 = num == 3;
							if (flag5)
							{
								break;
							}
							FIREHOSE_MANAGER.SendXml(FIREHOSE.pkt_read(FIREHOSE_MANAGER.SectorSize, "1", lun, (1 + num).ToString()));
							array3 = FIREHOSE_MANAGER.readByte(4096);
							bool flag6 = array3.Length > 200;
							if (flag6)
							{
								string string2 = Encoding.UTF8.GetString(array3, 0, array3.Length);
								bool flag7 = !string2.Contains("EFI");
								if (!flag7)
								{
									goto IL_39D;
								}
								uiManager.logs("Sector " + (1 + num).ToString() + " is not Have Valid Gpt", true, (uiManager.MessageType)uiManager.Merah);
							}
							else
							{
								num++;
							}
						}
						uiManager.logs("Gpt Is Not Founds", true, (uiManager.MessageType)uiManager.Merah);
						return false;
						IL_39D:
						FIREHOSE.gpt.header = new FIREHOSE.gpt_header
						{
							signature = Encoding.UTF8.GetString(array3.Skip(0).Take(8).ToArray<byte>(), 0, 8),
							revision = BitConverter.ToInt32(array3.Skip(8).Take(4).ToArray<byte>(), 0),
							header_size = BitConverter.ToInt32(array3.Skip(12).Take(4).ToArray<byte>(), 0),
							crc_header = BitConverter.ToInt32(array3.Skip(16).Take(4).ToArray<byte>(), 0),
							reserved = BitConverter.ToInt32(array3.Skip(20).Take(4).ToArray<byte>(), 0),
							current_lba = BitConverter.ToInt32(array3.Skip(24).Take(8).ToArray<byte>(), 0),
							backup_lba = BitConverter.ToInt32(array3.Skip(32).Take(8).ToArray<byte>(), 0),
							first_usable_lba = BitConverter.ToInt32(array3.Skip(40).Take(8).ToArray<byte>(), 0),
							last_usable_lba = unchecked((long)BitConverter.ToInt32(array3.Skip(48).Take(8).ToArray<byte>(), 0)),
							disk_guid = array3.Skip(56).Take(16).ToArray<byte>(),
							starting_lba_pe = BitConverter.ToInt32(array3.Skip(72).Take(8).ToArray<byte>(), 0)
						};
						byte[] array4 = array3.Skip(80).Take(4).ToArray<byte>();
						FIREHOSE.gpt.header.number_partitions = BitConverter.ToInt32(array3.Skip(80).Take(4).ToArray<byte>(), 0);
						FIREHOSE.gpt.header.size_partition_entries = BitConverter.ToInt32(array3.Skip(84).Take(4).ToArray<byte>(), 0);
						uiManager.logs("Found UFS Storage " + FIREHOSE_MANAGER.GetFileSizes(FIREHOSE.gpt.header.last_usable_lba * unchecked((long)Convert.ToInt32(FIREHOSE_MANAGER.SectorSize))), true, (uiManager.MessageType)uiManager.Hitam);
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000FA08 File Offset: 0x0000DC08
		public static void ConvertByteArrayToHexString(byte[] ByteArrayIn, int StrLength, out string StringOut)
		{
			string[] array = new string[2];
			StringOut = "";
			checked
			{
				int num = StrLength - 1;
				for (int i = 0; i <= num; i++)
				{
					bool flag = ByteArrayIn != null && ByteArrayIn.Length > i;
					if (flag)
					{
						byte b = Convert.ToByte(ByteArrayIn[i]);
						byte value = Convert.ToByte((int)(b & 15));
						byte value2 = Convert.ToByte((b & 240) >> 4);
						array[0] = Convert.ToString(value, 16);
						array[1] = Convert.ToString(value2, 16);
						StringOut = StringOut + array[1].ToUpper() + array[0].ToUpper();
					}
				}
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000FAAC File Offset: 0x0000DCAC
		public static bool GetInfDrive()
		{
			ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = null;
			try
			{
				try
				{
					foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\" and Name LIKE '%Qualcomm HS-USB QDLoader 9008%'").Get())
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						uiManager.logs("Download Port : ", false, (uiManager.MessageType)uiManager.Hitam);
						uiManager.Log2(managementObject.GetPropertyValue("Name").ToString() + "\r\n", Color.Orange, true, false);
						FIREHOSE_MANAGER.Booln = true;
						uiManager.logs("Driver Manufacturer : ", false, (uiManager.MessageType)uiManager.Hitam);
						uiManager.Log2(managementObject.GetPropertyValue("Manufacturer").ToString() + "\r\n", Color.Red, true, false);
						uiManager.logs("Connection USB    : ", false, (uiManager.MessageType)uiManager.Hitam);
						uiManager.Log2("XHCI:HUB:USB 2.00 ", Color.Orange, true, false);
						uiManager.Log2("High-Speed\r\n", Color.LimeGreen, true, false);
					}
				}
				finally
				{
					bool flag = managementObjectEnumerator != null;
					if (flag)
					{
						((IDisposable)managementObjectEnumerator).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				FIREHOSE_MANAGER.Booln = false;
			}
			return FIREHOSE_MANAGER.Booln;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000FC34 File Offset: 0x0000DE34
		public static byte[] GetFiles(string namafile, bool pbar)
		{
			string address = "https://hadikhoirudin.github.io/ireverse/assets/datatool/autoloader/" + namafile + ".bin";
			checked
			{
				byte[] result;
				try
				{
					using (WebClient webClient = new WebClient())
					{
						using (Stream stream = webClient.OpenRead(address))
						{
							byte[] array = new byte[4096];
							using (MemoryStream memoryStream = new MemoryStream())
							{
								long num = 0L;
								int num2;
								while ((num2 = stream.Read(array, 0, array.Length)) > 0)
								{
									memoryStream.Write(array, 0, num2);
									num += unchecked((long)num2);
									if (pbar)
									{
										uiManager.ProcessBar1(num, -1L);
									}
								}
								result = memoryStream.ToArray();
							}
						}
					}
				}
				catch (Exception ex)
				{
					result = new byte[0];
				}
				return result;
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000FD40 File Offset: 0x0000DF40
		public static string getfilenames(string label)
		{
			bool flag = label == "aboot";
			string result;
			if (flag)
			{
				result = "emmc_appsboot.mbn";
			}
			else
			{
				bool flag2 = label == "abootbak";
				if (flag2)
				{
					result = "emmc_appsbootbak.mbn";
				}
				else
				{
					bool flag3 = label == "apdp";
					if (flag3)
					{
						result = "dpAP.mbn";
					}
					else
					{
						bool flag4 = label == "BackupGPT";
						if (flag4)
						{
							result = "gpt_backup0.bin";
						}
						else
						{
							bool flag5 = label == "boot";
							if (flag5)
							{
								result = "boot.img";
							}
							else
							{
								bool flag6 = label == "cache";
								if (flag6)
								{
									result = "cache.img";
								}
								else
								{
									bool flag7 = label == "cmnlib";
									if (flag7)
									{
										result = "cmnlib.mbn";
									}
									else
									{
										bool flag8 = label == "cmnlibbak";
										if (flag8)
										{
											result = "cmnlibbak.mbn";
										}
										else
										{
											bool flag9 = label == "cmnlib64";
											if (flag9)
											{
												result = "cmnlib64.mbn";
											}
											else
											{
												bool flag10 = label == "cmnlib64bak";
												if (flag10)
												{
													result = "cmnlib64bak.mbn";
												}
												else
												{
													bool flag11 = label == "devcfg";
													if (flag11)
													{
														result = "devcfg.mbn";
													}
													else
													{
														bool flag12 = label == "devcfgbak";
														if (flag12)
														{
															result = "devcfgbak.mbn";
														}
														else
														{
															bool flag13 = label == "DRIVER";
															if (flag13)
															{
																result = "DRIVER.ISO";
															}
															else
															{
																bool flag14 = label == "dsp";
																if (flag14)
																{
																	result = "adspso.bin";
																}
																else
																{
																	bool flag15 = label == "dtbo";
																	if (flag15)
																	{
																		result = "dtbo.img";
																	}
																	else
																	{
																		bool flag16 = label == "keymaster" && SAHARA_MANAGER.cpu64;
																		if (flag16)
																		{
																			result = "keymaster64.mbn";
																		}
																		else
																		{
																			bool flag17 = label == "keymasterbak" && SAHARA_MANAGER.cpu64;
																			if (flag17)
																			{
																				result = "keymasterbak64.mbn";
																			}
																			else
																			{
																				bool flag18 = label == "keymaster" && !SAHARA_MANAGER.cpu64;
																				if (flag18)
																				{
																					result = "keymaster.mbn";
																				}
																				else
																				{
																					bool flag19 = label == "keymasterbak" && !SAHARA_MANAGER.cpu64;
																					if (flag19)
																					{
																						result = "keymasterbak.mbn";
																					}
																					else
																					{
																						bool flag20 = label == "lksecapp";
																						if (flag20)
																						{
																							result = "lksecapp.mbn";
																						}
																						else
																						{
																							bool flag21 = label == "lksecappbak";
																							if (flag21)
																							{
																								result = "lksecappbak.mbn";
																							}
																							else
																							{
																								bool flag22 = label == "LOGO";
																								if (flag22)
																								{
																									result = "logo.bin";
																								}
																								else
																								{
																									bool flag23 = label == "mdtp";
																									if (flag23)
																									{
																										result = "mdtp.img";
																									}
																									else
																									{
																										bool flag24 = label == "misc";
																										if (flag24)
																										{
																											result = "misc.img";
																										}
																										else
																										{
																											bool flag25 = label == "modem";
																											if (flag25)
																											{
																												result = "NON - HLOS.bin";
																											}
																											else
																											{
																												bool flag26 = label == "oppodycnvbk";
																												if (flag26)
																												{
																													result = "dynamic_nvbk.bin";
																												}
																												else
																												{
																													bool flag27 = label == "opporeserve1";
																													if (flag27)
																													{
																														result = "emmc_fw.bin";
																													}
																													else
																													{
																														bool flag28 = label == "opporeserve2";
																														if (flag28)
																														{
																															result = "opporeserve2.img";
																														}
																														else
																														{
																															bool flag29 = label == "oppostanvbk";
																															if (flag29)
																															{
																																result = "static_nvbk.bin";
																															}
																															else
																															{
																																bool flag30 = label == "persist";
																																if (flag30)
																																{
																																	result = "persist.img";
																																}
																																else
																																{
																																	bool flag31 = label == "PrimaryGPT";
																																	if (flag31)
																																	{
																																		result = "gpt_main0.bin";
																																	}
																																	else
																																	{
																																		bool flag32 = label == "recovery";
																																		if (flag32)
																																		{
																																			result = "recovery.img";
																																		}
																																		else
																																		{
																																			bool flag33 = label == "rpm";
																																			if (flag33)
																																			{
																																				result = "rpm.mbn";
																																			}
																																			else
																																			{
																																				bool flag34 = label == "rpmbak";
																																				if (flag34)
																																				{
																																					result = "rpmbak.mbn";
																																				}
																																				else
																																				{
																																					bool flag35 = label == "sbl1";
																																					if (flag35)
																																					{
																																						result = "sbl1.mbn";
																																					}
																																					else
																																					{
																																						bool flag36 = label == "sbl1bak";
																																						if (flag36)
																																						{
																																							result = "sbl1bak.mbn";
																																						}
																																						else
																																						{
																																							bool flag37 = label == "sec";
																																							if (flag37)
																																							{
																																								result = "sec.dat";
																																							}
																																							else
																																							{
																																								bool flag38 = label == "system";
																																								if (flag38)
																																								{
																																									result = "system.img";
																																								}
																																								else
																																								{
																																									bool flag39 = label == "tz";
																																									if (flag39)
																																									{
																																										result = "tz.mbn";
																																									}
																																									else
																																									{
																																										bool flag40 = label == "tzbak";
																																										if (flag40)
																																										{
																																											result = "tzbak.mbn";
																																										}
																																										else
																																										{
																																											bool flag41 = label == "userdata";
																																											if (flag41)
																																											{
																																												result = "userdata.img";
																																											}
																																											else
																																											{
																																												bool flag42 = label == "vbmeta";
																																												if (flag42)
																																												{
																																													result = "vbmeta.img";
																																												}
																																												else
																																												{
																																													bool flag43 = label == "vendor";
																																													if (flag43)
																																													{
																																														result = "vendor.img";
																																													}
																																													else
																																													{
																																														result = label + ".bin";
																																													}
																																												}
																																											}
																																										}
																																									}
																																								}
																																							}
																																						}
																																					}
																																				}
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00010258 File Offset: 0x0000E458
		public static byte[] readByte()
		{
			FIREHOSE_MANAGER.tot = 0;
			checked
			{
				byte[] result;
				try
				{
					byte[] array = new byte[0];
					byte[] array2;
					for (;;)
					{
						array2 = DiskWriter.DiskRead(0);
						bool flag = !Encoding.UTF8.GetString(array2).ToLower().Contains("ack");
						if (!flag)
						{
							bool flag2 = Encoding.UTF8.GetString(array2).ToLower().Contains("nak");
							if (flag2)
							{
								break;
							}
							bool flag3 = Encoding.UTF8.GetString(array2).ToLower().Contains("ack");
							if (flag3)
							{
								goto Block_5;
							}
						}
					}
					uiManager.logs(Encoding.UTF8.GetString(array2), true, (uiManager.MessageType)uiManager.Merah);
					throw new Exception(Encoding.UTF8.GetString(array2));
					Block_5:
					FIREHOSE_MANAGER.findOffset(array2.Take(512).ToArray<byte>(), "</data>");
					int count = FIREHOSE_MANAGER.lb.Items.Count;
					bool flag4 = count == 0;
					if (!flag4)
					{
						int num = Convert.ToInt32(FIREHOSE_MANAGER.lb.Items[count - 1]);
						array = array2.Skip(num + 7).ToArray<byte>();
					}
					result = array;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					result = new byte[0];
				}
				return result;
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000103C0 File Offset: 0x0000E5C0
		public static byte[] readByte(int len)
		{
			FIREHOSE_MANAGER.tot = 0;
			byte[] result;
			try
			{
				int num = 0;
				long num2 = (long)len;
				int num3 = 0;
				checked
				{
					byte[] array = new byte[len + 512 - 1];
					byte[] array2 = new byte[0];
					for (;;)
					{
						bool flag = num == 0;
						if (!flag)
						{
							array2 = DiskWriter.DiskRead(0);
							goto IL_10B;
						}
						byte[] array3 = DiskWriter.DiskRead(0);
						bool flag2 = Encoding.UTF8.GetString(array3).ToLower().Contains("nak");
						if (flag2)
						{
							break;
						}
						bool flag3 = !Encoding.UTF8.GetString(array3).ToLower().Contains("ack");
						if (!flag3)
						{
							FIREHOSE_MANAGER.findOffset(array3.Take(200).ToArray<byte>(), "</data>");
							int count = FIREHOSE_MANAGER.lb.Items.Count;
							bool flag4 = count == 0;
							if (!flag4)
							{
								int num4 = Convert.ToInt32(FIREHOSE_MANAGER.lb.Items[count - 1]);
								array2 = array3.Skip(num4 + 7).ToArray<byte>();
							}
							goto IL_10B;
						}
						continue;
						IL_10B:
						Buffer.BlockCopy(array2, 0, array, num3, array2.Length);
						num3 += array2.Length;
						num++;
						bool flag5 = unchecked((long)num3) > num2;
						if (flag5)
						{
							goto Block_7;
						}
					}
					throw new Exception("Error nak");
					Block_7:
					result = array.Take(len).ToArray<byte>();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				result = new byte[0];
			}
			return result;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00010554 File Offset: 0x0000E754
		public static object findOffset(byte[] inpubytes, string oldstring)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(oldstring);
			FIREHOSE_MANAGER.lb.Items.Clear();
			FIREHOSE_MANAGER.lb = new ListBox();
			using (BinaryReader binaryReader = new BinaryReader(new MemoryStream(inpubytes)))
			{
				long length = binaryReader.BaseStream.Length;
				bool flag = (long)bytes.Length <= length;
				checked
				{
					if (flag)
					{
						byte[] array = binaryReader.ReadBytes(bytes.Length);
						bool flag2 = false;
						for (int i = 0; i < bytes.Length - 1; i++)
						{
							bool flag3 = array[i] != bytes[i];
							if (flag3)
							{
								flag2 = false;
								break;
							}
							flag2 = true;
						}
						bool flag4 = flag2;
						if (flag4)
						{
							return 0;
						}
						int num = bytes.Length;
						while (unchecked((long)num) < length - 1L)
						{
							Array.Copy(array, 1, array, 0, array.Length - 1);
							array[array.Length - 1] = binaryReader.ReadByte();
							for (int j = 0; j < bytes.Length - 1; j++)
							{
								bool flag5 = array[j] != bytes[j];
								if (flag5)
								{
									flag2 = false;
									break;
								}
								flag2 = true;
							}
							bool flag6 = flag2;
							if (flag6)
							{
								FIREHOSE_MANAGER.lb.Items.Add((num - (bytes.Length - 1)).ToString());
							}
							num++;
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000106F4 File Offset: 0x0000E8F4
		public static byte[] HexReplace(string filereplace, string oldstring, string newstring)
		{
			FIREHOSE_MANAGER.lb.Items.Clear();
			byte[] array = File.ReadAllBytes(filereplace);
			byte[] array2 = new byte[array.Length];
			long num = 0L;
			object obj = FIREHOSE_MANAGER.findOffset(array, oldstring);
			int count = FIREHOSE_MANAGER.lb.Items.Count;
			bool flag = count == 0;
			checked
			{
				byte[] result;
				if (flag)
				{
					uiManager.logs("Device Has Not any accounts Lock", true, (uiManager.MessageType)uiManager.Merah);
					result = new byte[0];
				}
				else
				{
					for (int i = 0; i < FIREHOSE_MANAGER.lb.Items.Count - 1; i++)
					{
						using (MemoryStream memoryStream = new MemoryStream(array))
						{
							bool flag2 = i == 0;
							if (flag2)
							{
								byte[] array3 = new byte[(int)FIREHOSE_MANAGER.lb.Items[i] - 1];
								memoryStream.Seek(0L, SeekOrigin.Begin);
								memoryStream.Read(array3, 0, array3.Length);
								Buffer.BlockCopy(array3, 0, array2, 0, array3.Length);
								num += unchecked((long)array3.Length);
								byte[] bytes = Encoding.UTF8.GetBytes(newstring);
								Buffer.BlockCopy(bytes, 0, array2, (int)num, bytes.Length);
								num += unchecked((long)bytes.Length);
							}
							else
							{
								long num2 = Convert.ToInt64((int)FIREHOSE_MANAGER.lb.Items[i] - (int)FIREHOSE_MANAGER.lb.Items[i - 1] - oldstring.Length);
								byte[] array4 = new byte[num2 - 1L];
								memoryStream.Seek(num, SeekOrigin.Begin);
								memoryStream.Read(array4, 0, array4.Length);
								Buffer.BlockCopy(array4, 0, array2, (int)num, array4.Length);
								num += unchecked((long)array4.Length);
								byte[] bytes2 = Encoding.UTF8.GetBytes(newstring);
								Buffer.BlockCopy(bytes2, 0, array2, (int)num, bytes2.Length);
								num += unchecked((long)bytes2.Length);
							}
						}
					}
					using (MemoryStream memoryStream2 = new MemoryStream(array))
					{
						memoryStream2.Seek(num, SeekOrigin.Begin);
						long num3 = unchecked((long)array.Length) - num;
						byte[] array5 = new byte[num3 - 1L];
						memoryStream2.Read(array5, 0, array5.Length);
						Buffer.BlockCopy(array5, 0, array2, (int)num, array5.Length);
					}
					result = array2;
				}
				return result;
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00010970 File Offset: 0x0000EB70
		public static string GetFileSizes(long TheSize)
		{
			string text = null;
			try
			{
				bool flag = TheSize >= 1099511627776L;
				if (flag)
				{
					FIREHOSE_MANAGER.DoubleBytes = (double)TheSize / 1099511627776.0;
					text = Strings.FormatNumber(FIREHOSE_MANAGER.DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault) + " TB";
				}
				else
				{
					bool flag2 = TheSize >= 1073741824L && TheSize <= 1099511627775L;
					if (flag2)
					{
						FIREHOSE_MANAGER.DoubleBytes = (double)TheSize / 1073741824.0;
						text = Strings.FormatNumber(FIREHOSE_MANAGER.DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault) + " GB";
					}
					else
					{
						bool flag3 = TheSize >= 1048576L && TheSize <= 1073741823L;
						if (flag3)
						{
							FIREHOSE_MANAGER.DoubleBytes = (double)TheSize / 1048576.0;
							text = Strings.FormatNumber(FIREHOSE_MANAGER.DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault) + " MB";
						}
						else
						{
							bool flag4 = TheSize >= 1024L && TheSize <= 1048575L;
							if (flag4)
							{
								FIREHOSE_MANAGER.DoubleBytes = (double)TheSize / 1024.0;
								text = Strings.FormatNumber(FIREHOSE_MANAGER.DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault) + " KB";
							}
							else
							{
								bool flag5 = TheSize < 0L || TheSize > 1023L;
								if (flag5)
								{
									text = "";
								}
								else
								{
									FIREHOSE_MANAGER.DoubleBytes = (double)TheSize;
									text = Strings.FormatNumber(FIREHOSE_MANAGER.DoubleBytes, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault) + " bytes";
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				text = "";
			}
			return text.Replace(",", ".");
		}

		// Token: 0x0400007F RID: 127
		public static string PatchString;

		// Token: 0x04000080 RID: 128
		public static string SelectedExecution = "";

		// Token: 0x04000081 RID: 129
		public static string StringXml;

		// Token: 0x04000082 RID: 130
		public static FIREHOSE_MANAGER.MenuEksekusi MenuEx = FIREHOSE_MANAGER.MenuEksekusi.manual;

		// Token: 0x04000083 RID: 131
		public static FIREHOSE_MANAGER.MenuManual MenuMan = FIREHOSE_MANAGER.MenuManual.ident;

		// Token: 0x04000084 RID: 132
		public static string SectorSize = "512";

		// Token: 0x04000085 RID: 133
		public static string TypeMemory = "emmc";

		// Token: 0x04000086 RID: 134
		public static string typeterpilih = "";

		// Token: 0x04000087 RID: 135
		public static string modelterpilih = "";

		// Token: 0x04000088 RID: 136
		public const long SPARSE_DONT_CARE = 969411L;

		// Token: 0x04000089 RID: 137
		public const long SPARSE_FILL_CHUNK = 969410L;

		// Token: 0x0400008A RID: 138
		public const long SPARSE_MAGIC = 64108298042L;

		// Token: 0x0400008B RID: 139
		public const long SPARSE_RAW_CHUNK = 969409L;

		// Token: 0x0400008C RID: 140
		public static ListBox lb = new ListBox();

		// Token: 0x0400008D RID: 141
		public static ListBox ListPartitionName = new ListBox();

		// Token: 0x0400008E RID: 142
		public static ListBox ListLastSector = new ListBox();

		// Token: 0x0400008F RID: 143
		public static ListBox listPhysicalPartition = new ListBox();

		// Token: 0x04000090 RID: 144
		public static ListBox listSectorSize = new ListBox();

		// Token: 0x04000091 RID: 145
		public static ListBox ListStartSector = new ListBox();

		// Token: 0x04000092 RID: 146
		public static int skipbyte = 0;

		// Token: 0x04000093 RID: 147
		public static string tanggalexpired = "";

		// Token: 0x04000094 RID: 148
		public static string bta;

		// Token: 0x04000095 RID: 149
		public static int CheckKelar;

		// Token: 0x04000096 RID: 150
		public static string datafile;

		// Token: 0x04000097 RID: 151
		public static bool DeviceExist = false;

		// Token: 0x04000098 RID: 152
		public static double DoubleBytes;

		// Token: 0x04000099 RID: 153
		public static byte[] EncryptedDownloadData;

		// Token: 0x0400009A RID: 154
		public static bool EncryptedLoader = false;

		// Token: 0x0400009B RID: 155
		public static string foldersave;

		// Token: 0x0400009C RID: 156
		public static long NumDigestsFound;

		// Token: 0x0400009D RID: 157
		public static string server;

		// Token: 0x0400009E RID: 158
		public static string serverFolderFile;

		// Token: 0x0400009F RID: 159
		public static string xmlpatch;

		// Token: 0x040000A0 RID: 160
		public static string SnAdb;

		// Token: 0x040000A1 RID: 161
		public static int tot;

		// Token: 0x040000A2 RID: 162
		public static int totalchecked;

		// Token: 0x040000A3 RID: 163
		public static int totalchunk;

		// Token: 0x040000A4 RID: 164
		public static int WaktuCari;

		// Token: 0x040000A5 RID: 165
		public static byte[] FilesOneClick;

		// Token: 0x040000A6 RID: 166
		public static string MerkTerpilih;

		// Token: 0x040000A7 RID: 167
		public static byte[] OutDecripted = new byte[0];

		// Token: 0x040000A8 RID: 168
		public static string Namafilenya;

		// Token: 0x040000A9 RID: 169
		public static long LenFile;

		// Token: 0x040000AA RID: 170
		public static bool Booln;

		// Token: 0x040000AB RID: 171
		public static BackgroundWorker backgroundWorker = new BackgroundWorker();

		// Token: 0x040000AC RID: 172
		private static WebBrowser webBrowser1;

		// Token: 0x02000021 RID: 33
		public enum MenuEksekusi
		{
			// Token: 0x04000114 RID: 276
			manual,
			// Token: 0x04000115 RID: 277
			oneclick
		}

		// Token: 0x02000022 RID: 34
		public enum MenuManual
		{
			// Token: 0x04000117 RID: 279
			ident,
			// Token: 0x04000118 RID: 280
			flash,
			// Token: 0x04000119 RID: 281
			read,
			// Token: 0x0400011A RID: 282
			hapus,
			// Token: 0x0400011B RID: 283
			reboot,
			// Token: 0x0400011C RID: 284
			userdata
		}
	}
}
