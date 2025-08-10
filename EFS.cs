using System;
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using QC.QMSLPhone;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x0200000A RID: 10
	public static class EFS
	{
		// Token: 0x06000059 RID: 89 RVA: 0x0000A100 File Offset: 0x00008300
		public static void WriteQcn()
		{
			checked
			{
				try
				{
					bool flag = !EFS.IsConnect(10);
					if (!flag)
					{
						int num = 0;
						int num2 = -1;
						EFS.QCphone.SetLibraryMode(LibraryModeEnum.QPhoneMS);
						uiManager.logs("Connect To server     : ", false, (uiManager.MessageType)uiManager.Hitam);
						EFS.QCphone.ConnectToServer(PortIOMe.PortCOM, EFS.timeout);
						uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
						uiManager.logs("Sending SPC : ", false, (uiManager.MessageType)uiManager.Hitam);
						EFS.QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"));
						uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
						uiManager.logs("Loading Qcn From File : ", false, (uiManager.MessageType)uiManager.Hitam);
						EFS.QCphone.LoadNVsFromQCN(Main.DelegateFunction.TextBox8.Text, ref num, out num2);
						uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
						int num3 = 10;
						bool flag2 = false;
						uiManager.logs("Writing EFS : ", false, (uiManager.MessageType)uiManager.Hitam);
						while (!flag2 && num3 > 0)
						{
							num3--;
							try
							{
								EFS.QCphone.NV_WriteNVsToMobile(ref num2);
								flag2 = true;
							}
							catch (Exception ex)
							{
								uiManager.logs(ex.ToString(), true, (uiManager.MessageType)uiManager.Merah);
							}
						}
						uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
						bool flag3 = !flag2;
						bool flag4 = flag3;
						if (flag4)
						{
							uiManager.logs("Fail", true, (uiManager.MessageType)uiManager.Merah);
						}
						uiManager.logs("Sync EFS : ", false, (uiManager.MessageType)uiManager.Hitam);
						EFS.QCphone.EFS_SyncWithWait(10000);
						uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
					}
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.ToString());
				}
				finally
				{
					EFS.QCphone.DisconnectServer();
				}
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000A354 File Offset: 0x00008554
		public static bool IsConnect(int tries)
		{
			bool flag = EFS.QCphone.IsPhoneConnected();
			checked
			{
				while (!flag && tries > 0)
				{
					Thread.Sleep(1000);
					tries--;
					flag = EFS.QCphone.IsPhoneConnected();
				}
				return flag;
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000A3A0 File Offset: 0x000085A0
		public static void WriteIMEI(string imei, int numimei)
		{
			try
			{
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 40;
				}));
				EFS.QCphone.SetLibraryMode(LibraryModeEnum.QPhoneMS);
				EFS.QCphone.ConnectToServer(PortIOMe.PortCOM, EFS.timeout);
				EFS.QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"));
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 80;
				}));
				EFS.QCphone.WriteIMEI_DualSIM(imei, numimei);
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 100;
				}));
			}
			catch (Exception ex)
			{
				bool flag = ex.Message.Contains("NV item is Read Only");
				if (flag)
				{
					uiManager.logs("Can't Write IMEI! NV item is Protected.", true, (uiManager.MessageType)uiManager.Merah);
					uiManager.logs("Please Backup QCN and then reset EFS Before Write IMEI.", true, (uiManager.MessageType)uiManager.Kuning);
				}
			}
			finally
			{
				EFS.QCphone.DisconnectServer();
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000A514 File Offset: 0x00008714
		public static void WriteMEID(string meid)
		{
			try
			{
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 40;
				}));
				EFS.QCphone.SetLibraryMode(LibraryModeEnum.QPhoneMS);
				EFS.QCphone.ConnectToServer(PortIOMe.PortCOM, EFS.timeout);
				EFS.QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"));
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 80;
				}));
				EFS.QCphone.WriteMEIDNumber(meid);
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 100;
				}));
				Main.Elapsed(uiManager.Watch);
				uiManager.Watch.Stop();
			}
			catch (Exception ex)
			{
			}
			finally
			{
				EFS.QCphone.DisconnectServer();
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000A644 File Offset: 0x00008844
		public static void Writeimei(string imei)
		{
			try
			{
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 40;
				}));
				EFS.QCphone.SetLibraryMode(LibraryModeEnum.QPhoneMS);
				EFS.QCphone.ConnectToServer(PortIOMe.PortCOM, EFS.timeout);
				EFS.QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"));
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 80;
				}));
				EFS.QCphone.WriteIMEI(imei);
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 100;
				}));
				Main.Elapsed(uiManager.Watch);
				uiManager.Watch.Stop();
			}
			catch (Exception ex)
			{
			}
			finally
			{
				EFS.QCphone.DisconnectServer();
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000A774 File Offset: 0x00008974
		public static void ReadQCN()
		{
			try
			{
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 40;
				}));
				uiManager.logs("Mencari Ports Diag : ", false, (uiManager.MessageType)uiManager.Hitam);
				bool flag = !EFS.ProcesCariPortDiags();
				if (flag)
				{
					Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.ProgressBar1.Value = 100;
					}));
				}
				else
				{
					Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.ProgressBar1.Value = 60;
					}));
					EFS.QCphone.SetLibraryMode(LibraryModeEnum.QPhoneMS);
					EFS.QCphone.ConnectToServer(PortIOMe.PortCOM, EFS.timeout);
					EFS.Readinfo();
					int num = -1;
					EFS.QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"));
					Thread.Sleep(50);
					Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.ProgressBar1.Value = 80;
					}));
					uiManager.logs("", true, (uiManager.MessageType)uiManager.Hitam);
					uiManager.logs("Reading NV network data, please wait ... ", true, (uiManager.MessageType)uiManager.Hitam);
					EFS.QCphone.EnableQcnNvItemCallBacks();
					EFS.QCphone.EnableQcnNvItemCallBacks();
					Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.ProgressBar1.Value = 90;
					}));
					EFS.QCphone.BackupNVFromMobileToQCN(string.Concat(new string[]
					{
						FIREHOSE_MANAGER.foldersave,
						"\\",
						EFS.imei1,
						"_",
						EFS.imei2,
						"-backup.qcn"
					}), ref num);
					uiManager.logs("Saved To : ", false, (uiManager.MessageType)uiManager.Hitam);
					uiManager.logs(string.Concat(new string[]
					{
						FIREHOSE_MANAGER.foldersave,
						"\\",
						EFS.imei1,
						"_",
						EFS.imei2,
						"-backup.qcn"
					}), true, (uiManager.MessageType)uiManager.Hitam);
					Main.Elapsed(uiManager.Watch);
					uiManager.Watch.Stop();
					Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.ProgressBar1.Value = 100;
					}));
				}
			}
			catch
			{
			}
			finally
			{
				EFS.QCphone.DisableQcnNvItemCallBacks();
				EFS.QCphone.DisconnectServer();
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000AA6C File Offset: 0x00008C6C
		public static void readSN()
		{
			string text = "";
			EFS.QCphone.ReadSN(out text);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000AA90 File Offset: 0x00008C90
		public static void readEmei()
		{
			Imei_Info imei_Info = default(Imei_Info);
			Imei_Info imei_Info2 = default(Imei_Info);
			try
			{
				EFS.QCphone.ReadIMEI_DualSIM(out imei_Info, 0);
				EFS.QCphone.ReadIMEI_DualSIM(out imei_Info2, 1);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
			EFS.imei1 = imei_Info.imei;
			EFS.imei2 = imei_Info2.imei;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000AB04 File Offset: 0x00008D04
		public static void readMac()
		{
			byte[] array = new byte[6];
			int strLength = 6;
			bool flag = true;
			try
			{
				EFS.macLoc = EFS.MACADD_Location.NV4678;
				bool flag2 = EFS.macLoc == EFS.MACADD_Location.AP_PERSIST;
				bool flag3 = flag2;
				if (flag3)
				{
					array = EFS.QCphone.FTM_WLAN_GEN6_GET_MAC_ADDRESS();
				}
				else
				{
					bool flag4 = EFS.macLoc == EFS.MACADD_Location.NV4678;
					bool flag5 = flag4;
					if (flag5)
					{
						EFS.QCphone.NVRead(EFS.nvitemtype, array, 128);
					}
				}
			}
			catch (Exception ex)
			{
				flag = false;
				throw new Exception(ex.ToString());
			}
			bool flag6 = flag;
			bool flag7 = flag6;
			if (flag7)
			{
				EFS.ConvertByteArrayToHexString(array, strLength, out EFS.mac);
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000ABB0 File Offset: 0x00008DB0
		public static void ConvertByteArrayToHexString(byte[] ByteArrayIn, int StrLength, out string StringOut)
		{
			string[] array = new string[StrLength];
			string[] array2 = new string[2];
			StringOut = "";
			checked
			{
				for (int i = 0; i < StrLength; i++)
				{
					bool flag = ByteArrayIn != null && ByteArrayIn.Length > i;
					bool flag2 = flag;
					if (flag2)
					{
						byte b = Convert.ToByte(ByteArrayIn[i]);
						byte value = Convert.ToByte((int)(b & 15));
						byte value2 = Convert.ToByte((b & 240) >> 4);
						array2[0] = Convert.ToString(value, 16);
						array2[1] = Convert.ToString(value2, 16);
						StringOut = StringOut + array2[1].ToUpper() + array2[0].ToUpper();
					}
				}
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000AC58 File Offset: 0x00008E58
		public static void readBTa()
		{
			bool flag = true;
			byte[] array = new byte[6];
			byte[] array2 = new byte[6];
			string[] array3 = new string[6];
			int num = 6;
			try
			{
				EFS.QCphone.NVRead(EFS.skl, array, 128);
			}
			catch (Exception ex)
			{
				flag = false;
				throw new Exception(ex.ToString());
			}
			bool flag2 = flag;
			bool flag3 = flag2;
			checked
			{
				if (flag3)
				{
					int i = 0;
					int num2 = num - 1;
					while (i <= num - 1)
					{
						array2[i] = array[num2];
						i++;
						num2--;
					}
					EFS.ConvertByteArrayToHexString(array2, num, out EFS.bta);
					EFS.bta = EFS.bta.ToUpper();
				}
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000AD18 File Offset: 0x00008F18
		public static void Readinfo()
		{
			try
			{
				EFS.readSN();
				EFS.readMeid();
				EFS.readEmei();
				EFS.readMac();
				EFS.readBTa();
				string str = "";
				string text = "";
				string text2 = "";
				EFS.QCphone.GetPhoneVersionInfo(out str, out text);
				EFS.QCphone.ReadTrackingInfo(out text2);
				uiManager.logs("", true, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs("Reading selected port info ... ", true, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs("Software Version : \r\n" + str, true, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs("MEID \t: " + EFS.meid, true, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs("IMEI 1 \t: " + EFS.imei1, true, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs("IMEI 2 \t: " + EFS.imei2, true, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs("MAC \t: " + EFS.mac, true, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs("BTA \t: " + EFS.bta, true, (uiManager.MessageType)uiManager.Hitam);
				uiManager.logs("", true, (uiManager.MessageType)uiManager.Hitam);
			}
			catch (Exception ex)
			{
				uiManager.logs(ex.Message, true, (uiManager.MessageType)uiManager.Merah);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000AEAC File Offset: 0x000090AC
		public static void readMeid()
		{
			EFS.QCphone.ReadMEID(out EFS.meid_Info);
			EFS.meid = EFS.meid_Info.RR + EFS.meid_Info.MAC + EFS.meid_Info.SNR;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000AEE8 File Offset: 0x000090E8
		public static bool CariPortsDiag()
		{
			bool result;
			try
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_PnPEntity  WHERE Name LIKE '%Diagnostics%'  ");
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						string portNameData = managementObject["Name"].ToString();
						string text = managementObject["Name"].ToString().Substring(checked(managementObject["Name"].ToString().IndexOf("(COM") + 4));
						text = text.TrimEnd(new char[]
						{
							')'
						});
						PortIOMe.PortCOM = Convert.ToInt32(text);
						Main.DelegateFunction.ComboBox3.Invoke(new Action(delegate()
						{
							Main.DelegateFunction.ComboBox3.Text = portNameData;
						}));
						uiManager.logs("Found at COM" + PortIOMe.PortCOM.ToString(), true, (uiManager.MessageType)uiManager.Kuning);
						return true;
					}
				}
				result = false;
			}
			catch (ManagementException ex)
			{
				MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
				result = false;
			}
			return result;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000B054 File Offset: 0x00009254
		public static bool ProcesCariPortDiags()
		{
			uiManager.Setwaktu();
			int i = 0;
			checked
			{
				while (i <= FIREHOSE_MANAGER.WaktuCari)
				{
					bool flag = EFS.CariPortsDiag();
					bool result;
					if (flag)
					{
						result = true;
					}
					else
					{
						Thread.Sleep(1000);
						FIREHOSE_MANAGER.WaktuCari--;
						bool flag2 = FIREHOSE_MANAGER.WaktuCari == 0;
						if (!flag2)
						{
							Main.DelegateFunction.Label1.Invoke(new Action(delegate()
							{
								Main.DelegateFunction.Label1.Text = FIREHOSE_MANAGER.WaktuCari.ToString();
							}));
							i++;
							continue;
						}
						uiManager.logs("Not Found", true, (uiManager.MessageType)uiManager.Merah);
						Main.DelegateFunction.Label1.Invoke(new Action(delegate()
						{
							Main.DelegateFunction.Label1.Text = FIREHOSE_MANAGER.WaktuCari.ToString();
						}));
						Main.Elapsed(uiManager.Watch);
						uiManager.Watch.Stop();
						result = false;
					}
					return result;
				}
				uiManager.logs("Not Found", true, (uiManager.MessageType)uiManager.Merah);
				Main.Elapsed(uiManager.Watch);
				uiManager.Watch.Stop();
				return false;
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000B180 File Offset: 0x00009380
		public static void WriteQcnExec()
		{
			uiManager.logs("Searching Ports Diag : ", false, (uiManager.MessageType)uiManager.Hitam);
			Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
			{
				Main.DelegateFunction.ProgressBar1.Value = 20;
			}));
			bool flag = !EFS.ProcesCariPortDiags();
			checked
			{
				if (!flag)
				{
					Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.ProgressBar1.Value = 40;
					}));
					try
					{
						int num = 0;
						int num2 = -1;
						EFS.QCphone.SetLibraryMode(LibraryModeEnum.QPhoneMS);
						uiManager.logs("Connect To server     : ", false, (uiManager.MessageType)uiManager.Hitam);
						EFS.QCphone.ConnectToServer(PortIOMe.PortCOM, EFS.timeout);
						uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
						Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
						{
							Main.DelegateFunction.ProgressBar1.Value = 60;
						}));
						bool flag2 = !EFS.IsConnect(10);
						if (flag2)
						{
							Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
							{
								Main.DelegateFunction.ProgressBar1.Value = 100;
							}));
						}
						else
						{
							EFS.Readinfo();
							Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
							{
								Main.DelegateFunction.ProgressBar1.Value = 70;
							}));
							uiManager.logs("Sending SPC : ", false, (uiManager.MessageType)uiManager.Hitam);
							EFS.QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"));
							uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
							Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
							{
								Main.DelegateFunction.ProgressBar1.Value = 80;
							}));
							uiManager.logs("Loading Qcn From File : ", false, (uiManager.MessageType)uiManager.Hitam);
							EFS.QCphone.LoadNVsFromQCN(Main.DelegateFunction.TextBox8.Text, ref num, out num2);
							uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
							int num3 = 10;
							bool flag3 = false;
							uiManager.logs("Writing EFS : ", false, (uiManager.MessageType)uiManager.Hitam);
							while (!flag3 && num3 > 0)
							{
								num3--;
								try
								{
									EFS.QCphone.NV_WriteNVsToMobile(ref num2);
									flag3 = true;
								}
								catch (Exception ex)
								{
									uiManager.logs(ex.ToString(), true, (uiManager.MessageType)uiManager.Merah);
								}
							}
							Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
							{
								Main.DelegateFunction.ProgressBar1.Value = 90;
							}));
							uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
							bool flag4 = !flag3;
							bool flag5 = flag4;
							if (flag5)
							{
								uiManager.logs("Fail", true, (uiManager.MessageType)uiManager.Merah);
								Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
								{
									Main.DelegateFunction.ProgressBar1.Value = 100;
								}));
							}
							uiManager.logs("Sync EFS : ", false, (uiManager.MessageType)uiManager.Hitam);
							EFS.QCphone.EFS_SyncWithWait(10000);
							uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
							Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
							{
								Main.DelegateFunction.ProgressBar1.Value = 100;
							}));
							Main.Elapsed(uiManager.Watch);
							uiManager.Watch.Stop();
						}
					}
					catch (Exception ex2)
					{
						uiManager.logs(ex2.ToString(), true, (uiManager.MessageType)uiManager.Merah);
					}
					finally
					{
						EFS.QCphone.DisconnectServer();
					}
				}
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000B5D0 File Offset: 0x000097D0
		public static void WriteImeiExec()
		{
			uiManager.logs("Mencari Ports Diag : ", false, (uiManager.MessageType)uiManager.Hitam);
			Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
			{
				Main.DelegateFunction.ProgressBar1.Value = 40;
			}));
			bool flag = !EFS.ProcesCariPortDiags();
			if (flag)
			{
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 100;
				}));
			}
			else
			{
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 60;
				}));
				try
				{
					Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.ProgressBar1.Value = 70;
					}));
					EFS.QCphone.SetLibraryMode(LibraryModeEnum.QPhoneMS);
					EFS.QCphone.ConnectToServer(PortIOMe.PortCOM, EFS.timeout);
					EFS.Readinfo();
					EFS.QCphone.SendSPC(Encoding.ASCII.GetBytes("000000"));
					Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.ProgressBar1.Value = 80;
					}));
					bool @checked = Main.DelegateFunction.CheckBox6.Checked;
					if (@checked)
					{
						EFS.WriteIMEI(Main.DelegateFunction.TextBox9.Text, 0);
					}
					Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.ProgressBar1.Value = 90;
					}));
					bool checked2 = Main.DelegateFunction.CheckBox7.Checked;
					if (checked2)
					{
						EFS.WriteIMEI(Main.DelegateFunction.TextBox10.Text, 1);
					}
					Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
					{
						Main.DelegateFunction.ProgressBar1.Value = 100;
					}));
					Main.Elapsed(uiManager.Watch);
					uiManager.Watch.Stop();
				}
				catch (Exception ex)
				{
					uiManager.logs(ex.ToString(), true, (uiManager.MessageType)uiManager.Merah);
				}
				finally
				{
					EFS.QCphone.DisconnectServer();
				}
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000B864 File Offset: 0x00009A64
		public static void ReadIMEI12()
		{
			uiManager.logs("Searching Ports Diag : ", false, (uiManager.MessageType)uiManager.Hitam);
			Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
			{
				Main.DelegateFunction.ProgressBar1.Value = 0;
			}));
			bool flag = !EFS.ProcesCariPortDiags();
			if (!flag)
			{
				Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
				{
					Main.DelegateFunction.ProgressBar1.Value = 80;
				}));
				try
				{
					EFS.QCphone.SetLibraryMode(LibraryModeEnum.QPhoneMS);
					uiManager.logs("Connect To server     : ", false, (uiManager.MessageType)uiManager.Hitam);
					EFS.QCphone.ConnectToServer(PortIOMe.PortCOM, EFS.timeout);
					uiManager.logs("OK", true, (uiManager.MessageType)uiManager.Hijau);
					bool flag2 = !EFS.IsConnect(10);
					if (!flag2)
					{
						EFS.Readinfo();
						Main.DelegateFunction.TextBox9.Invoke(new Action(delegate()
						{
							Main.DelegateFunction.TextBox9.Text = EFS.imei1;
						}));
						Main.DelegateFunction.TextBox10.Invoke(new Action(delegate()
						{
							Main.DelegateFunction.TextBox10.Text = EFS.imei2;
						}));
						Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
						{
							Main.DelegateFunction.ProgressBar1.Value = 100;
						}));
						Main.Elapsed(uiManager.Watch);
						uiManager.Watch.Stop();
					}
				}
				catch (Exception ex)
				{
					uiManager.logs(ex.ToString(), true, (uiManager.MessageType)uiManager.Merah);
				}
				finally
				{
					EFS.QCphone.DisconnectServer();
				}
			}
		}

		// Token: 0x04000073 RID: 115
		public static Phone QCphone = new Phone();

		// Token: 0x04000074 RID: 116
		public static string meid;

		// Token: 0x04000075 RID: 117
		public static uint timeout = 10000U;

		// Token: 0x04000076 RID: 118
		public static string mac;

		// Token: 0x04000077 RID: 119
		public static string bta;

		// Token: 0x04000078 RID: 120
		public static string sn;

		// Token: 0x04000079 RID: 121
		public static string imei1;

		// Token: 0x0400007A RID: 122
		public static string imei2;

		// Token: 0x0400007B RID: 123
		public static EFS.MACADD_Location macLoc;

		// Token: 0x0400007C RID: 124
		public static nv_items_enum_type nvitemtype = nv_items_enum_type.NV_WLAN_MAC_ADDRESS_I;

		// Token: 0x0400007D RID: 125
		public static nv_items_enum_type skl = nv_items_enum_type.NV_BD_ADDR_I;

		// Token: 0x0400007E RID: 126
		public static Meid_Info meid_Info;

		// Token: 0x0200001E RID: 30
		public enum MACADD_Location
		{
			// Token: 0x040000E9 RID: 233
			AP_PERSIST,
			// Token: 0x040000EA RID: 234
			NV4678
		}
	}
}
