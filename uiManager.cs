using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x02000009 RID: 9
	public static class uiManager
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00009D28 File Offset: 0x00007F28
		[STAThread]
		public static void DisplayData(uiManager.MessageType type, string msg, bool bold)
		{
			Main.DelegateFunction.RichTextBox.Invoke(new EventHandler(delegate(object sender, EventArgs e)
			{
				Main.DelegateFunction.RichTextBox.SelectionStart = Main.DelegateFunction.RichTextBox.TextLength;
				Main.DelegateFunction.RichTextBox.SelectionLength = 0;
				Main.DelegateFunction.RichTextBox.SelectionColor = uiManager.MessageColor[Convert.ToInt32(type)];
				bool bold2 = bold;
				if (bold2)
				{
					Main.DelegateFunction.RichTextBox.SelectionFont = new Font(Main.DelegateFunction.RichTextBox.SelectionFont, FontStyle.Regular);
				}
				else
				{
					Main.DelegateFunction.RichTextBox.SelectionFont = new Font(Main.DelegateFunction.RichTextBox.SelectionFont, FontStyle.Bold);
				}
				Main.DelegateFunction.RichTextBox.SelectionBullet = false;
				Main.DelegateFunction.RichTextBox.AppendText(msg);
				Main.DelegateFunction.RichTextBox.ScrollToCaret();
			}));
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00009D70 File Offset: 0x00007F70
		public static void logs(string Textlogs, bool newline, uiManager.MessageType warna)
		{
			bool flag = !newline;
			if (flag)
			{
				uiManager.DisplayData(warna, Textlogs, true);
			}
			else
			{
				uiManager.DisplayData(warna, Textlogs + "\r\n", true);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00009DA8 File Offset: 0x00007FA8
		public static void Logs1(string msg, Color Color)
		{
			try
			{
				Main.DelegateFunction.RichTextBox.Invoke(new MethodInvoker(delegate()
				{
					Main.DelegateFunction.RichTextBox.SelectionColor = Color;
					Main.DelegateFunction.RichTextBox.SelectionBullet = false;
					Main.DelegateFunction.RichTextBox.AppendText(msg);
					Main.DelegateFunction.RichTextBox.SelectionStart = Main.DelegateFunction.RichTextBox.TextLength;
					Main.DelegateFunction.RichTextBox.ScrollToCaret();
				}));
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00009E00 File Offset: 0x00008000
		public static void Log2(string s, Color color, bool isBold, bool newline = false)
		{
			bool flag = newline && Main.DelegateFunction.RichTextBox.TextLength > 0;
			if (flag)
			{
				Main.DelegateFunction.RichTextBox.AppendText("\r\n");
			}
			Main.DelegateFunction.RichTextBox.SelectionStart = Main.DelegateFunction.RichTextBox.Text.Length;
			Color selectionColor = Main.DelegateFunction.RichTextBox.SelectionColor;
			Main.DelegateFunction.RichTextBox.SelectionColor = color;
			if (isBold)
			{
				Main.DelegateFunction.RichTextBox.SelectionFont = new Font(Main.DelegateFunction.RichTextBox.Font, FontStyle.Regular);
			}
			Main.DelegateFunction.RichTextBox.AppendText(s);
			Main.DelegateFunction.RichTextBox.SelectionColor = selectionColor;
			Main.DelegateFunction.RichTextBox.SelectionFont = new Font(Main.DelegateFunction.RichTextBox.Font, FontStyle.Regular);
			Main.DelegateFunction.RichTextBox.ScrollToCaret();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00009F09 File Offset: 0x00008109
		public static void RtbClear()
		{
			Main.DelegateFunction.RichTextBox.Clear();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00009F1C File Offset: 0x0000811C
		public static void ProcessBar1(long Process, long total)
		{
			Main.DelegateFunction.ProgressBar2.Invoke(new Action(delegate()
			{
				Main.DelegateFunction.ProgressBar2.Value = Convert.ToInt32(Math.Round((double)(checked(Process * 100L)) / (double)total));
			}));
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00009F5C File Offset: 0x0000815C
		public static void ProcessBar2(long Process, long total)
		{
			Main.DelegateFunction.ProgressBar1.Invoke(new Action(delegate()
			{
				Main.DelegateFunction.ProgressBar1.Value = Convert.ToInt32(Math.Round((double)(checked(Process * 100L)) / (double)total));
			}));
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00009F9A File Offset: 0x0000819A
		public static void Setwaktu()
		{
			Main.DelegateFunction.Invoke(new MethodInvoker(delegate()
			{
				FIREHOSE_MANAGER.WaktuCari = 60;
				Main.DelegateFunction.Label1.Text = FIREHOSE_MANAGER.WaktuCari.ToString();
				Main.DelegateFunction.Label1.Visible = true;
				uiManager.Watch.Start();
				uiManager.Watch.Restart();
			}));
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00009FC8 File Offset: 0x000081C8
		public static void Delay(double dblSecs)
		{
			DateTime.Now.AddSeconds(1.15740740740741E-05);
			DateTime t = DateTime.Now.AddSeconds(1.15740740740741E-05).AddSeconds(dblSecs);
			while (DateTime.Compare(DateTime.Now, t) <= 0)
			{
				Application.DoEvents();
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000A02A File Offset: 0x0000822A
		public static void TransferRate(long TheSize)
		{
			checked
			{
				uiManager.checktransferrate += 1L;
				uiManager.transferspeed += TheSize;
			}
		}

		// Token: 0x04000069 RID: 105
		public static Stopwatch Watch = new Stopwatch();

		// Token: 0x0400006A RID: 106
		public static long DataTransfered = 0L;

		// Token: 0x0400006B RID: 107
		public static long transferspeed = 0L;

		// Token: 0x0400006C RID: 108
		public static long checktransferrate = 0L;

		// Token: 0x0400006D RID: 109
		public static object Putih = uiManager.MessageType.Incoming;

		// Token: 0x0400006E RID: 110
		public static object Hitam = uiManager.MessageType.Outgoing;

		// Token: 0x0400006F RID: 111
		public static object Hijau = uiManager.MessageType.ok;

		// Token: 0x04000070 RID: 112
		public static object Kuning = uiManager.MessageType.Warning;

		// Token: 0x04000071 RID: 113
		public static object Merah = uiManager.MessageType.Error;

		// Token: 0x04000072 RID: 114
		public static Color[] MessageColor = new Color[]
		{
			Color.White,
			Color.Black,
			Color.LimeGreen,
			Color.LimeGreen,
			Color.Orange,
			Color.Red
		};

		// Token: 0x02000018 RID: 24
		public enum MessageType
		{
			// Token: 0x040000D8 RID: 216
			Incoming,
			// Token: 0x040000D9 RID: 217
			Outgoing,
			// Token: 0x040000DA RID: 218
			ok,
			// Token: 0x040000DB RID: 219
			Warning,
			// Token: 0x040000DC RID: 220
			Error
		}
	}
}
