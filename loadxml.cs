using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x02000004 RID: 4
	public partial class loadxml : Form
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002A53 File Offset: 0x00000C53
		public loadxml()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002A64 File Offset: 0x00000C64
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002A6C File Offset: 0x00000C6C
		private ListViewItem lvi { get; set; }

		// Token: 0x0600000F RID: 15 RVA: 0x00002A78 File Offset: 0x00000C78
		public void LoadMenu(object sender, EventArgs e)
		{
			loadxml.LoadFolder = Main.LoadFolderXml;
			DirectoryInfo directoryInfo = new DirectoryInfo(loadxml.LoadFolder);
			this.ListView1.Columns.Add("", 20);
			this.ListView1.Columns.Add("File XML", 280, HorizontalAlignment.Left);
			this.ListView1.View = View.Details;
			this.ListView1.CheckBoxes = true;
			this.ListView1.FullRowSelect = true;
			List<FileInfo> list = new List<FileInfo>();
			foreach (FileInfo fileInfo in directoryInfo.GetFiles())
			{
				bool flag = fileInfo != null;
				if (flag)
				{
					bool flag2 = Path.GetExtension(fileInfo.ToString().ToLower()) == ".xml";
					if (flag2)
					{
						this.lvi = new ListViewItem();
						this.lvi.SubItems.Add(fileInfo.ToString());
						this.ListView1.Items.Add(this.lvi);
					}
				}
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002B84 File Offset: 0x00000D84
		private void Button1_Click(object sender, EventArgs e)
		{
			string text = "";
			foreach (object obj in this.ListView1.CheckedItems)
			{
				ListViewItem listViewItem = (ListViewItem)obj;
				text = text + listViewItem.SubItems[1].Text + ",";
			}
			Main.DelegateFunction.Loadsss(text);
			base.Close();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002C18 File Offset: 0x00000E18
		private void Button2_Click(object sender, EventArgs e)
		{
			Main.DelegateFunction.CancelLOad();
			base.Close();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002C2D File Offset: 0x00000E2D
		private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002C30 File Offset: 0x00000E30
		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = this.ListView1.Items.Count == 0;
			if (flag)
			{
				MessageBox.Show("Kosong", "Info!", MessageBoxButtons.OK);
			}
			else
			{
				bool flag2 = !this.CheckBox1.Checked;
				if (flag2)
				{
					foreach (object obj in this.ListView1.Items)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						listViewItem.Checked = false;
					}
				}
				else
				{
					foreach (object obj2 in this.ListView1.Items)
					{
						ListViewItem listViewItem2 = (ListViewItem)obj2;
						listViewItem2.Checked = true;
					}
				}
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002D3C File Offset: 0x00000F3C
		public static loadxml DefaultInstance
		{
			get
			{
				bool flag = loadxml._DefaultInstance == null || loadxml._DefaultInstance.IsDisposed;
				if (flag)
				{
					loadxml._DefaultInstance = new loadxml();
				}
				return loadxml._DefaultInstance;
			}
		}

		// Token: 0x0400000F RID: 15
		public static string LoadFolder = "";

		// Token: 0x04000010 RID: 16
		private static loadxml _DefaultInstance;
	}
}
