using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x02000003 RID: 3
	public partial class Info : Form
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002215 File Offset: 0x00000415
		public Info()
		{
			this.InitializeComponent();
			this.richTextBox1.Text = Main.Get_HWID();
			base.FormClosing += this.Info_FormClosing;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002251 File Offset: 0x00000451
		private void Info_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000225C File Offset: 0x0000045C
		public static Info DefaultInstance
		{
			get
			{
				bool flag = Info._DefaultInstance == null || Info._DefaultInstance.IsDisposed;
				if (flag)
				{
					Info._DefaultInstance = new Info();
				}
				return Info._DefaultInstance;
			}
		}

		// Token: 0x04000001 RID: 1
		private static Info _DefaultInstance;
	}
}
