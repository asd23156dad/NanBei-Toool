namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x02000004 RID: 4
	public partial class loadxml : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000A RID: 10 RVA: 0x000026DC File Offset: 0x000008DC
		[global::System.Diagnostics.DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				bool flag = disposing && this.components != null;
				if (flag)
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000272C File Offset: 0x0000092C
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.Button2 = new global::System.Windows.Forms.Button();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.ListView1 = new global::System.Windows.Forms.ListView();
			this.CheckBox1 = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.Button2.Location = new global::System.Drawing.Point(384, 166);
			this.Button2.Name = "Button2";
			this.Button2.Size = new global::System.Drawing.Size(75, 23);
			this.Button2.TabIndex = 18;
			this.Button2.Text = "Cancel";
			this.Button2.UseVisualStyleBackColor = true;
			this.Button2.Click += new global::System.EventHandler(this.Button2_Click);
			this.Button1.Location = new global::System.Drawing.Point(13, 166);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(133, 23);
			this.Button1.TabIndex = 17;
			this.Button1.Text = "Load Selected XML";
			this.Button1.UseVisualStyleBackColor = true;
			this.Button1.Click += new global::System.EventHandler(this.Button1_Click);
			this.ListView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.ListView1.HideSelection = false;
			this.ListView1.Location = new global::System.Drawing.Point(0, 0);
			this.ListView1.Name = "ListView1";
			this.ListView1.Size = new global::System.Drawing.Size(464, 195);
			this.ListView1.TabIndex = 16;
			this.ListView1.UseCompatibleStateImageBehavior = false;
			this.ListView1.SelectedIndexChanged += new global::System.EventHandler(this.ListView1_SelectedIndexChanged);
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.Location = new global::System.Drawing.Point(6, 10);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new global::System.Drawing.Size(15, 14);
			this.CheckBox1.TabIndex = 19;
			this.CheckBox1.UseVisualStyleBackColor = true;
			this.CheckBox1.CheckedChanged += new global::System.EventHandler(this.CheckBox1_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(464, 195);
			base.Controls.Add(this.CheckBox1);
			base.Controls.Add(this.Button2);
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.ListView1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "loadxml";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "loadxml";
			base.Load += new global::System.EventHandler(this.LoadMenu);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000009 RID: 9
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000A RID: 10
		internal global::System.Windows.Forms.Button Button2;

		// Token: 0x0400000B RID: 11
		internal global::System.Windows.Forms.Button Button1;

		// Token: 0x0400000C RID: 12
		internal global::System.Windows.Forms.ListView ListView1;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.CheckBox CheckBox1;
	}
}
