namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x02000003 RID: 3
	public partial class Info : global::System.Windows.Forms.Form
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002298 File Offset: 0x00000498
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000022D0 File Offset: 0x000004D0
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.richTextBox1 = new global::System.Windows.Forms.RichTextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.richTextBox1);
			this.groupBox1.Location = new global::System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(406, 157);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Info :";
			this.richTextBox1.Location = new global::System.Drawing.Point(6, 89);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new global::System.Drawing.Size(394, 68);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(3, 73);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(46, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "HWID : ";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(6, 20);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(337, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Dukung channel YouTube @HadiK-IT dengan subscribe channelnya.";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(6, 33);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(373, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Kirimkan bukti subscribe berserta HWIDnya melalui Facebook Hadi Khoirudin.";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(6, 46);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(308, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Dan terimakasih banyak telah mendukung channel HadiK IT ini.";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.Window;
			base.ClientSize = new global::System.Drawing.Size(431, 182);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Info";
			base.Opacity = 0.96;
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Not Registered!";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000002 RID: 2
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.RichTextBox richTextBox1;
	}
}
