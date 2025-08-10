using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Guna.UI2.WinForms;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x02000005 RID: 5
	internal partial class Main : MetroForm
	{
		// Token: 0x06000018 RID: 24 RVA: 0x000079E8 File Offset: 0x00005BE8
		public Main()
		{
			using (WebClient webClient = new WebClient())
			{
				
				bool flag3 = true; // Simulating a valid HWID check
                if (flag3)
				{
					base.Load += this.LoadFlashing;
					base.FormClosing += this.Main_FormClosing;
					Main.DelegateFunction = this;
					FIREHOSE_MANAGER.WaktuCari = 60;
					FIREHOSE_MANAGER.tot = 0;
					FIREHOSE_MANAGER.foldersave = "";
					Main.DelegateFunction = this;
					this.InitializeComponent();
					
					//uiManager.logs("Wellcome ... ", true, (uiManager.MessageType)uiManager.Hitam);
				}
				else
				{
					base.Hide();
					base.WindowState = FormWindowState.Minimized;
					Info.DefaultInstance.Show();
				}
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00007BFC File Offset: 0x00005DFC
		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00007C00 File Offset: 0x00005E00
		public static string Get_HWID()
		{
			ClsComputerInfo clsComputerInfo = new ClsComputerInfo();
			string processorId = clsComputerInfo.GetProcessorId();
			string motherBoardID = clsComputerInfo.GetMotherBoardID();
			clsComputerInfo.GetMACAddress();
			clsComputerInfo.GetMACAddress();
			return Main.GenerateSHA512String(processorId + motherBoardID);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00007C40 File Offset: 0x00005E40
		public static string GenerateSHA512String(object inputString)
		{
			SHA512 sha = SHA512.Create();
			Encoding utf = Encoding.UTF8;
			object[] array = new object[]
			{
				inputString
			};
			object[] array2 = array;
			bool[] array3 = new bool[]
			{
				true
			};
			bool[] array4 = array3;
			object obj = NewLateBinding.LateGet(utf, null, "GetBytes", array, null, null, array3);
			bool flag = array4[0];
			if (flag)
			{
				inputString = RuntimeHelpers.GetObjectValue(array2[0]);
			}
			byte[] array5 = sha.ComputeHash((byte[])obj);
			StringBuilder stringBuilder = new StringBuilder();
			checked
			{
				int num = array5.Length - 1;
				int num2 = 0;
				do
				{
					stringBuilder.Append(array5[num2].ToString("X2"));
					num2++;
				}
				while (num2 <= num);
				return stringBuilder.ToString();
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00007CFE File Offset: 0x00005EFE
		private void guna2GradientButtonSTOP_Click(object sender, EventArgs e)
		{
			FIREHOSE_MANAGER.WaktuCari = 1;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00007D07 File Offset: 0x00005F07
		public void RichTextBox_TextChanged(object sender, EventArgs e)
		{
			this.RichTextBox.SelectionStart = this.RichTextBox.Text.Length;
			this.RichTextBox.ScrollToCaret();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00007D34 File Offset: 0x00005F34
		public void LoadFlashing(object sender, EventArgs e)
		{
			PortIOMe.PortCOM = 0;
			SAHARA_MANAGER.sendingloaderStatus = false;
			FIREHOSE_MANAGER.MenuEx = FIREHOSE_MANAGER.MenuEksekusi.manual;
			FIREHOSE_MANAGER.MenuEx = FIREHOSE_MANAGER.MenuEksekusi.manual;
			FIREHOSE_MANAGER.TypeMemory = "emmc";
			FIREHOSE_MANAGER.SectorSize = "512";
			FIREHOSE_MANAGER.ListPartitionName = new ListBox();
			FIREHOSE_MANAGER.listSectorSize = new ListBox();
			FIREHOSE_MANAGER.ListStartSector = new ListBox();
			FIREHOSE_MANAGER.ListLastSector = new ListBox();
			FIREHOSE_MANAGER.listPhysicalPartition = new ListBox();
			FIREHOSE_MANAGER.skipbyte = 91;
			this.cbstorage.Text = "emmc";
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00007DBC File Offset: 0x00005FBC
		public static void Elapsed(Stopwatch Watch)
		{
			TimeSpan elapsed = Watch.Elapsed;
			uiManager.logs(Environment.NewLine, false, (uiManager.MessageType)uiManager.Hitam);
			uiManager.logs("_______________________________________________________________", true, (uiManager.MessageType)uiManager.Hitam);
			uiManager.logs(Environment.NewLine, false, (uiManager.MessageType)uiManager.Hijau);
			uiManager.logs(" iReverse Qualcomm Tool Lite - ", false, (uiManager.MessageType)uiManager.Hitam);
			uiManager.logs(DateTime.Now.ToString("ddd, dd MMM yyyy HH:mm:ss"), true, (uiManager.MessageType)uiManager.Hitam);
			string str = string.Format("{0:00m}: {1:00s}", elapsed.Minutes, elapsed.Seconds);
			uiManager.logs(" All Tasks Is Completed", false, (uiManager.MessageType)uiManager.Hitam);
			uiManager.logs("      <  >      ", false, (uiManager.MessageType)uiManager.Hitam);
			uiManager.logs("Elapsed Time : " + str, true, (uiManager.MessageType)uiManager.Kuning);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00007EB8 File Offset: 0x000060B8
		private void MetroTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.MetroTabControl.SelectedIndex == 0;
			if (flag)
			{
				Console.WriteLine("Selected Tab Manual");
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00007EE8 File Offset: 0x000060E8
		public void CariPortQcom_Tick(object sender, EventArgs e)
		{
			int waktuCari = FIREHOSE_MANAGER.WaktuCari;
			FIREHOSE_MANAGER.WaktuCari = checked(waktuCari - 1);
			bool flag = FIREHOSE_MANAGER.WaktuCari == 0;
			if (flag)
			{
				uiManager.logs("Not Found...", true, (uiManager.MessageType)uiManager.Merah);
				Main.Elapsed(uiManager.Watch);
				uiManager.Watch.Stop();
				this.Label1.Visible = false;
				this.CariPortQcom.Stop();
			}
			this.Label1.Visible = true;
			this.Label1.Text = Conversions.ToString(FIREHOSE_MANAGER.WaktuCari);
			FIREHOSE_MANAGER.CariPorts();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00007F80 File Offset: 0x00006180
		public void DataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = this.DataView.Rows.Count > 0;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 2;
				if (flag2)
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Title = "PILIH FILE PARTISI " + this.DataView.CurrentRow.Cells[1].Value.ToString();
					openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
					openFileDialog.FileName = "*.*";
					openFileDialog.Filter = "ALL FILE  (*.*)|*.*";
					openFileDialog.FilterIndex = 2;
					openFileDialog.RestoreDirectory = true;
					bool flag3 = openFileDialog.ShowDialog() == DialogResult.OK;
					if (flag3)
					{
						this.DataView.CurrentRow.Cells[0].Value = true;
						this.DataView.CurrentRow.Cells[2].Value = openFileDialog.FileName;
					}
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000807C File Offset: 0x0000627C
		public void cbstorage_SelectedIndexChanged(object sender, EventArgs e)
		{
			FIREHOSE_MANAGER.MenuEx = FIREHOSE_MANAGER.MenuEksekusi.manual;
			bool flag = Operators.CompareString(this.cbstorage.Text, "emmc", false) == 0;
			if (flag)
			{
				FIREHOSE_MANAGER.SectorSize = "512";
				FIREHOSE_MANAGER.TypeMemory = "emmc";
			}
			else
			{
				FIREHOSE_MANAGER.SectorSize = "4096";
				FIREHOSE_MANAGER.TypeMemory = "ufs";
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000080DB File Offset: 0x000062DB
		public void Loadsss(string xml)
		{
			this.LoadXmlFolder(xml);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000080E8 File Offset: 0x000062E8
		private void LoadXmlFolder(string xml)
		{
			this.DataView.Rows.Clear();
			FIREHOSE_MANAGER.PatchString = "";
			foreach (string text in xml.Split(new char[]
			{
				','
			}))
			{
				bool flag = string.IsNullOrEmpty(text);
				if (flag)
				{
					break;
				}
				string text2 = "";
				XmlReader xmlReader = XmlReader.Create(Main.LoadFolderXml + "\\" + text);
				while (xmlReader.Read())
				{
					bool flag2 = xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "program";
					if (flag2)
					{
						bool flag3 = Operators.CompareString(xmlReader.GetAttribute("filename"), "", false) != 0;
						string text3;
						if (flag3)
						{
							text3 = Main.LoadFolderXml + "\\" + xmlReader.GetAttribute("filename");
						}
						else
						{
							text3 = "Double click to add file...";
						}
						this.DataView.Rows.Add(new object[]
						{
							false,
							xmlReader.GetAttribute("label"),
							text3,
							xmlReader.GetAttribute("start_sector"),
							xmlReader.GetAttribute("num_partition_sectors"),
							xmlReader.GetAttribute("physical_partition_number"),
							xmlReader.GetAttribute("SECTOR_SIZE_IN_BYTES")
						});
						text2 = xmlReader.GetAttribute("SECTOR_SIZE_IN_BYTES");
					}
					bool flag4 = xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "patch";
					if (flag4)
					{
						FIREHOSE_MANAGER.PatchString = FIREHOSE_MANAGER.PatchString + text + ",";
						break;
					}
				}
				foreach (object obj in ((IEnumerable)this.DataView.Rows))
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					bool flag5 = Convert.ToString(dataGridViewRow.Cells[2].Value) == "Double click to add file...";
					if (flag5)
					{
						dataGridViewRow.Cells[0].Value = false;
					}
					else
					{
						dataGridViewRow.Cells[0].Value = true;
					}
				}
				bool flag6 = text2.Contains("512");
				if (flag6)
				{
					this.cbstorage.SelectedItem = "emmc";
					FIREHOSE_MANAGER.TypeMemory = "emmc";
					FIREHOSE_MANAGER.SectorSize = "512";
				}
				else
				{
					bool flag7 = text2.Contains("4096");
					if (flag7)
					{
						this.cbstorage.SelectedItem = "ufs";
						FIREHOSE_MANAGER.TypeMemory = "ufs";
						FIREHOSE_MANAGER.SectorSize = "4096";
					}
				}
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000083EC File Offset: 0x000065EC
		public void CancelLOad()
		{
			this.txtrawxml.Clear();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000083FC File Offset: 0x000065FC
		public void BTNFLASH_Click(object sender, EventArgs e)
		{
			FIREHOSE_MANAGER.MenuEx = FIREHOSE_MANAGER.MenuEksekusi.manual;
			FIREHOSE_MANAGER.MenuMan = FIREHOSE_MANAGER.MenuManual.flash;
			bool flag = false;
			foreach (object obj in ((IEnumerable)this.DataView.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				bool @checked = this.CheckBoxAutoCleanUserdata.Checked;
				if (@checked)
				{
					bool flag2 = Convert.ToString(dataGridViewRow.Cells[this.DataView.Columns[1].Index].Value) == "misc";
					if (flag2)
					{
						bool flag3 = FIREHOSE_MANAGER.SectorSize == "512";
						if (flag3)
						{
							dataGridViewRow.Cells[this.DataView.Columns[2].Index].Value = Application.StartupPath + "\\Data\\Process\\Reset\\misc_emmc.img";
						}
						else
						{
							dataGridViewRow.Cells[this.DataView.Columns[2].Index].Value = Application.StartupPath + "\\Data\\Process\\Reset\\misc_ufs.img";
						}
						dataGridViewRow.Cells[this.DataView.Columns[0].Index].Value = true;
					}
				}
				bool checked2 = this.CheckBoxAutoCleanAccount.Checked;
				if (checked2)
				{
					bool flag4 = Convert.ToString(dataGridViewRow.Cells[this.DataView.Columns[1].Index].Value) == "frp";
					if (flag4)
					{
						dataGridViewRow.Cells[this.DataView.Columns[2].Index].Value = Application.StartupPath + "\\Data\\Process\\Reset\\frp.bin";
						dataGridViewRow.Cells[this.DataView.Columns[0].Index].Value = true;
					}
					else
					{
						bool flag5 = Convert.ToString(dataGridViewRow.Cells[this.DataView.Columns[1].Index].Value) == "config";
						if (flag5)
						{
							dataGridViewRow.Cells[this.DataView.Columns[2].Index].Value = Application.StartupPath + "\\Data\\Process\\Reset\\config.bin";
							dataGridViewRow.Cells[this.DataView.Columns[0].Index].Value = true;
						}
					}
				}
				bool flag6 = Convert.ToBoolean(dataGridViewRow.Cells[0].Value);
				if (flag6)
				{
					flag = true;
				}
			}
			bool flag7 = flag;
			checked
			{
				if (flag7)
				{
					Thread.Sleep(500);
					bool flag8 = string.IsNullOrEmpty(this.txtloader.Text);
					if (flag8)
					{
						uiManager.RtbClear();
						uiManager.Setwaktu();
						FIREHOSE_MANAGER.StringXml = "";
						Main.IsAutoLoader = true;
					}
					else
					{
						uiManager.RtbClear();
						uiManager.Setwaktu();
						FIREHOSE_MANAGER.StringXml = "";
						SAHARA_MANAGER.loader = File.ReadAllBytes(this.txtloader.Text);
						bool flag9 = !Encoding.UTF8.GetString(SAHARA_MANAGER.loader).Contains("ELF");
						if (flag9)
						{
							uiManager.logs("Loader is Invalid Or Encrypted  ", false, (uiManager.MessageType)uiManager.Merah);
							return;
						}
					}
					FIREHOSE_MANAGER.StringXml += "<?xml version=\"1.0\" ?>\r\n";
					FIREHOSE_MANAGER.StringXml += "<data>\r\n";
					FIREHOSE_MANAGER.totalchecked = 0;
					foreach (object obj2 in ((IEnumerable)this.DataView.Rows))
					{
						DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
						bool flag10 = Convert.ToBoolean(dataGridViewRow2.Cells[this.DataView.Columns[0].Index].Value);
						if (flag10)
						{
							FIREHOSE_MANAGER.totalchecked++;
							FIREHOSE_MANAGER.StringXml = FIREHOSE_MANAGER.StringXml + string.Format("<program SECTOR_SIZE_IN_BYTES=\"{0}\" file_sector_offset=\"0\" filename=\"{1}\" label=\"{2}\" num_partition_sectors=\"{3}\" physical_partition_number=\"{4}\" start_sector=\"{5}\"/>", new object[]
							{
								FIREHOSE_MANAGER.SectorSize,
								dataGridViewRow2.Cells[this.DataView.Columns[2].Index].Value,
								dataGridViewRow2.Cells[this.DataView.Columns[1].Index].Value,
								dataGridViewRow2.Cells[this.DataView.Columns[4].Index].Value,
								dataGridViewRow2.Cells[this.DataView.Columns[5].Index].Value,
								dataGridViewRow2.Cells[this.DataView.Columns[3].Index].Value
							}) + "\r\n";
						}
					}
					FIREHOSE_MANAGER.StringXml += "</data>";
					FIREHOSE_MANAGER.GetInfDrive();
					uiManager.logs("Searching Qualcomm Usb Devices : ", false, (uiManager.MessageType)uiManager.Hitam);
					this.CariPortQcom.Start();
				}
				else
				{
					MessageBox.Show("Silahkan masukan Raw XML / Identify terlebih dahulu!", null, MessageBoxButtons.OK);
				}
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000089D8 File Offset: 0x00006BD8
		private void btiden_Click(object sender, EventArgs e)
		{
			FIREHOSE_MANAGER.MenuEx = FIREHOSE_MANAGER.MenuEksekusi.manual;
			FIREHOSE_MANAGER.MenuMan = FIREHOSE_MANAGER.MenuManual.ident;
			bool flag = string.IsNullOrEmpty(this.txtloader.Text);
			if (flag)
			{
				this.DataView.Rows.Clear();
				uiManager.RtbClear();
				uiManager.Setwaktu();
				FIREHOSE_MANAGER.StringXml = "";
				Main.IsAutoLoader = true;
			}
			else
			{
				this.DataView.Rows.Clear();
				uiManager.RtbClear();
				uiManager.Setwaktu();
				FIREHOSE_MANAGER.StringXml = "";
				this.txtrawxml.Text = "";
				SAHARA_MANAGER.loader = File.ReadAllBytes(this.txtloader.Text);
				bool flag2 = !Encoding.UTF8.GetString(SAHARA_MANAGER.loader).Contains("ELF");
				if (flag2)
				{
					uiManager.logs("Loader is Invalid Or Encrypted  ", false, (uiManager.MessageType)uiManager.Merah);
					return;
				}
			}
			FIREHOSE_MANAGER.GetInfDrive();
			uiManager.logs("Searching Qualcomm Usb Devices : ", false, (uiManager.MessageType)uiManager.Hitam);
			this.CariPortQcom.Start();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00008AEC File Offset: 0x00006CEC
		public void CheckBox3_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = this.CheckBox3.CheckState == CheckState.Checked;
			checked
			{
				if (flag)
				{
					foreach (object obj in ((IEnumerable)this.DataView.Rows))
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
						{
							dataGridViewRow.Cells[0].Value = true;
						}
					}
				}
				else
				{
					foreach (object obj2 in ((IEnumerable)this.DataView.Rows))
					{
						DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
						for (int j = 0; j < dataGridViewRow2.Cells.Count; j++)
						{
							dataGridViewRow2.Cells[0].Value = false;
						}
					}
				}
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00008C2C File Offset: 0x00006E2C
		private void BTNREAD_Click(object sender, EventArgs e)
		{
			FIREHOSE_MANAGER.MenuEx = FIREHOSE_MANAGER.MenuEksekusi.manual;
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
			{
				ShowNewFolderButton = true
			};
			bool flag = folderBrowserDialog.ShowDialog() == DialogResult.OK;
			checked
			{
				if (flag)
				{
					FIREHOSE_MANAGER.foldersave = "";
					FIREHOSE_MANAGER.foldersave = folderBrowserDialog.SelectedPath;
					bool flag2 = false;
					foreach (object obj in ((IEnumerable)this.DataView.Rows))
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						bool flag3 = Convert.ToBoolean(dataGridViewRow.Cells[0].Value);
						if (flag3)
						{
							flag2 = true;
						}
					}
					bool flag4 = flag2;
					if (flag4)
					{
						FIREHOSE_MANAGER.MenuMan = FIREHOSE_MANAGER.MenuManual.read;
						Thread.Sleep(500);
						bool flag5 = string.IsNullOrEmpty(this.txtloader.Text);
						if (flag5)
						{
							uiManager.RtbClear();
							uiManager.Setwaktu();
							FIREHOSE_MANAGER.StringXml = "";
							Main.IsAutoLoader = true;
						}
						else
						{
							uiManager.RtbClear();
							uiManager.Setwaktu();
							FIREHOSE_MANAGER.StringXml = "";
							SAHARA_MANAGER.loader = File.ReadAllBytes(this.txtloader.Text);
							bool flag6 = !Encoding.UTF8.GetString(SAHARA_MANAGER.loader).Contains("ELF");
							if (flag6)
							{
								uiManager.logs("Loader is Invalid Or Encrypted  ", false, (uiManager.MessageType)uiManager.Merah);
								return;
							}
						}
						FIREHOSE_MANAGER.StringXml += "<?xml version=\"1.0\" ?>\r\n";
						FIREHOSE_MANAGER.StringXml += "<data>\r\n";
						FIREHOSE_MANAGER.totalchecked = 0;
						foreach (object obj2 in ((IEnumerable)this.DataView.Rows))
						{
							DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
							bool flag7 = Convert.ToBoolean(dataGridViewRow2.Cells[this.DataView.Columns[0].Index].Value);
							if (flag7)
							{
								FIREHOSE_MANAGER.totalchecked++;
								FIREHOSE_MANAGER.StringXml = FIREHOSE_MANAGER.StringXml + string.Format("<read SECTOR_SIZE_IN_BYTES=\"{0}\" file_sector_offset=\"0\" filename=\"{1}\" label=\"{2}\" num_partition_sectors=\"{3}\" physical_partition_number=\"{4}\" start_sector=\"{5}\"/>", new object[]
								{
									FIREHOSE_MANAGER.SectorSize,
									dataGridViewRow2.Cells[this.DataView.Columns[2].Index].Value,
									dataGridViewRow2.Cells[this.DataView.Columns[1].Index].Value,
									dataGridViewRow2.Cells[this.DataView.Columns[4].Index].Value,
									dataGridViewRow2.Cells[this.DataView.Columns[5].Index].Value,
									dataGridViewRow2.Cells[this.DataView.Columns[3].Index].Value
								}) + "\r\n";
							}
						}
						FIREHOSE_MANAGER.StringXml += "</data>";
						FIREHOSE_MANAGER.GetInfDrive();
						uiManager.logs("Searching Qualcomm Usb Devices : ", false, (uiManager.MessageType)uiManager.Hitam);
						this.CariPortQcom.Start();
					}
					else
					{
						MessageBox.Show("Silahkan masukan Raw XML / Identify terlebih dahulu!", null, MessageBoxButtons.OK);
					}
				}
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00008FD8 File Offset: 0x000071D8
		private void BTNERASE_Click(object sender, EventArgs e)
		{
			FIREHOSE_MANAGER.MenuEx = FIREHOSE_MANAGER.MenuEksekusi.manual;
			bool flag = false;
			foreach (object obj in ((IEnumerable)this.DataView.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				bool flag2 = Convert.ToBoolean(dataGridViewRow.Cells[0].Value);
				if (flag2)
				{
					flag = true;
				}
			}
			bool flag3 = flag;
			checked
			{
				if (flag3)
				{
					FIREHOSE_MANAGER.MenuMan = FIREHOSE_MANAGER.MenuManual.hapus;
					Thread.Sleep(500);
					bool flag4 = string.IsNullOrEmpty(this.txtloader.Text);
					if (flag4)
					{
						uiManager.RtbClear();
						uiManager.Setwaktu();
						FIREHOSE_MANAGER.StringXml = "";
						Main.IsAutoLoader = true;
					}
					else
					{
						uiManager.RtbClear();
						uiManager.Setwaktu();
						FIREHOSE_MANAGER.StringXml = "";
						SAHARA_MANAGER.loader = File.ReadAllBytes(this.txtloader.Text);
						bool flag5 = !Encoding.UTF8.GetString(SAHARA_MANAGER.loader).Contains("ELF");
						if (flag5)
						{
							uiManager.logs("Loader is Invalid Or Encrypted  ", false, (uiManager.MessageType)uiManager.Merah);
							return;
						}
					}
					FIREHOSE_MANAGER.StringXml += "<?xml version=\"1.0\" ?>\r\n";
					FIREHOSE_MANAGER.StringXml += "<data>\r\n";
					FIREHOSE_MANAGER.totalchecked = 0;
					foreach (object obj2 in ((IEnumerable)this.DataView.Rows))
					{
						DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
						bool flag6 = Convert.ToBoolean(dataGridViewRow2.Cells[this.DataView.Columns[0].Index].Value);
						if (flag6)
						{
							FIREHOSE_MANAGER.totalchecked++;
							FIREHOSE_MANAGER.StringXml = FIREHOSE_MANAGER.StringXml + string.Format("<program SECTOR_SIZE_IN_BYTES=\"{0}\" file_sector_offset=\"0\" filename=\"{1}\" label=\"{2}\" num_partition_sectors=\"{3}\" physical_partition_number=\"{4}\" start_sector=\"{5}\"/>", new object[]
							{
								FIREHOSE_MANAGER.SectorSize,
								dataGridViewRow2.Cells[this.DataView.Columns[2].Index].Value,
								dataGridViewRow2.Cells[this.DataView.Columns[1].Index].Value,
								dataGridViewRow2.Cells[this.DataView.Columns[4].Index].Value,
								dataGridViewRow2.Cells[this.DataView.Columns[5].Index].Value,
								dataGridViewRow2.Cells[this.DataView.Columns[3].Index].Value
							}) + "\r\n";
						}
					}
					FIREHOSE_MANAGER.StringXml += "</data>";
					FIREHOSE_MANAGER.GetInfDrive();
					uiManager.logs("Searching Qualcomm Usb Devices : ", false, (uiManager.MessageType)uiManager.Hitam);
					this.CariPortQcom.Start();
				}
				else
				{
					MessageBox.Show("Silahkan masukan Raw XML / Identify terlebih dahulu!", null, MessageBoxButtons.OK);
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00009348 File Offset: 0x00007548
		private void Guna2ImageButton_loader_Click(object sender, EventArgs e)
		{
			FIREHOSE_MANAGER.MenuEx = FIREHOSE_MANAGER.MenuEksekusi.manual;
			this.txtloader.Text = "";
			SAHARA_MANAGER.loader = new byte[0];
			FIREHOSE_MANAGER.datafile = "";
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "loader",
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
				FileName = "*.*",
				Filter = "all file |*.*;*.* ",
				FilterIndex = 2,
				RestoreDirectory = true
			};
			bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.txtloader.Text = openFileDialog.FileName;
				FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000093F8 File Offset: 0x000075F8
		private void Guna2ImageButton_xml_Click(object sender, EventArgs e)
		{
			FIREHOSE_MANAGER.MenuEx = FIREHOSE_MANAGER.MenuEksekusi.manual;
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.ShowNewFolderButton = true;
			bool flag = folderBrowserDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				Main.LoadFolderXml = folderBrowserDialog.SelectedPath;
				loadxml.DefaultInstance.Show();
				this.txtrawxml.Text = Main.LoadFolderXml;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00009450 File Offset: 0x00007650
		private void guna2GradientButton2_Click(object sender, EventArgs e)
		{
			FIREHOSE_MANAGER.MenuEx = FIREHOSE_MANAGER.MenuEksekusi.manual;
			FIREHOSE_MANAGER.MenuMan = FIREHOSE_MANAGER.MenuManual.reboot;
			Thread.Sleep(500);
			bool flag = string.IsNullOrEmpty(this.txtloader.Text);
			if (flag)
			{
				uiManager.RtbClear();
				uiManager.Setwaktu();
				FIREHOSE_MANAGER.StringXml = "";
				Main.IsAutoLoader = true;
			}
			else
			{
				uiManager.RtbClear();
				uiManager.Setwaktu();
				FIREHOSE_MANAGER.StringXml = "";
				SAHARA_MANAGER.loader = File.ReadAllBytes(this.txtloader.Text);
				bool flag2 = !Encoding.UTF8.GetString(SAHARA_MANAGER.loader).Contains("ELF");
				if (flag2)
				{
					uiManager.logs("Loader is Invalid Or Encrypted  ", false, (uiManager.MessageType)uiManager.Merah);
					return;
				}
			}
			FIREHOSE_MANAGER.GetInfDrive();
			uiManager.logs("Searching Qualcomm Usb Devices : ", false, (uiManager.MessageType)uiManager.Hitam);
			this.CariPortQcom.Start();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00009538 File Offset: 0x00007738
		private void Button_read_qcn_Click(object sender, EventArgs e)
		{
			uiManager.RtbClear();
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.ShowNewFolderButton = true;
			bool flag = folderBrowserDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				FIREHOSE_MANAGER.foldersave = "";
				FIREHOSE_MANAGER.foldersave = folderBrowserDialog.SelectedPath;
				Thread thread = new Thread(new ThreadStart(EFS.ReadQCN));
				thread.Start();
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00009598 File Offset: 0x00007798
		private void Button_write_qcn_Click(object sender, EventArgs e)
		{
			uiManager.RtbClear();
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "qcn";
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
			openFileDialog.FileName = "*.*";
			openFileDialog.Filter = "all file |*.qcn;*.xqcn ";
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;
			bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.TextBox8.Text = openFileDialog.FileName;
				FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
				bool flag2 = string.IsNullOrEmpty(this.TextBox8.Text);
				if (flag2)
				{
					uiManager.logs(" Please browse QCN File!", true, (uiManager.MessageType)uiManager.Merah);
				}
				else
				{
					Thread thread = new Thread(new ThreadStart(EFS.WriteQcnExec));
					thread.Start();
				}
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000966C File Offset: 0x0000786C
		private void Button_read_nv_Click(object sender, EventArgs e)
		{
			uiManager.RtbClear();
			Thread thread = new Thread(new ThreadStart(EFS.ReadIMEI12));
			thread.Start();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000969C File Offset: 0x0000789C
		private void Button_write_nv_Click(object sender, EventArgs e)
		{
			uiManager.RtbClear();
			bool flag = !this.CheckBox6.Checked && !this.CheckBox7.Checked;
			if (flag)
			{
				uiManager.logs("Please Select Imei To write", true, (uiManager.MessageType)uiManager.Merah);
			}
			else
			{
				bool flag2 = this.CheckBox6.Checked && string.IsNullOrEmpty(this.TextBox9.Text);
				if (flag2)
				{
					uiManager.logs("Please insert imei 1", true, (uiManager.MessageType)uiManager.Merah);
				}
				else
				{
					bool flag3 = this.CheckBox7.Checked && string.IsNullOrEmpty(this.TextBox10.Text);
					if (flag3)
					{
						uiManager.logs("Please insert imei 2", true, (uiManager.MessageType)uiManager.Merah);
					}
					else
					{
						bool flag4 = this.TextBox9.TextLength < 15 && !(this.TextBox9.Text == "0");
						if (flag4)
						{
							uiManager.logs("Please insert 15 Digits number on Imei 1", true, (uiManager.MessageType)uiManager.Merah);
						}
						else
						{
							bool flag5 = this.TextBox10.TextLength < 15;
							if (flag5)
							{
								uiManager.logs("Please insert 15 Digits number on Imei 2", true, (uiManager.MessageType)uiManager.Merah);
							}
							else
							{
								Thread thread = new Thread(new ThreadStart(EFS.WriteImeiExec));
								thread.Start();
							}
						}
					}
				}
			}
		}

		// Token: 0x04000055 RID: 85
		public bool Booln = false;

		// Token: 0x04000056 RID: 86
		internal static Main DelegateFunction;

		// Token: 0x04000057 RID: 87
		public static bool IsAutoLoader;

		// Token: 0x04000058 RID: 88
		public static string LoadFolderXml;

		// Token: 0x04000059 RID: 89
		public static byte[] OutDecripted = new byte[0];

		// Token: 0x0400005A RID: 90
		public static string keyEncrypt = "iReverse-Tool";
	}
}
