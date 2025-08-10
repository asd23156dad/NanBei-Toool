namespace iReverse_Qualcomm_Tool_Lite
{
	// Token: 0x02000005 RID: 5
	internal partial class Main : global::MetroFramework.Forms.MetroForm
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002D84 File Offset: 0x00000F84
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

		// Token: 0x06000017 RID: 23 RVA: 0x00002DD4 File Offset: 0x00000FD4
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MetroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.ProgressBar2 = new MetroFramework.Controls.MetroProgressBar();
            this.MetroTabControl = new MetroFramework.Controls.MetroTabControl();
            this.MetroTabPageFlashing = new MetroFramework.Controls.MetroTabPage();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPageQualcommFlash = new MetroFramework.Controls.MetroTabPage();
            this.Guna2ImageButton_xml = new Guna.UI2.WinForms.Guna2ImageButton();
            this.txtrawxml = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbstorage = new System.Windows.Forms.ComboBox();
            this.Guna2ImageButton_loader = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.CheckBoxAutoCleanAccount = new System.Windows.Forms.CheckBox();
            this.CheckBoxAutoCleanUserdata = new System.Windows.Forms.CheckBox();
            this.btiden = new Guna.UI2.WinForms.Guna2GradientButton();
            this.BTNERASE = new Guna.UI2.WinForms.Guna2GradientButton();
            this.BTNREAD = new Guna.UI2.WinForms.Guna2GradientButton();
            this.BTNFLASH = new Guna.UI2.WinForms.Guna2GradientButton();
            this.CheckBox3 = new System.Windows.Forms.CheckBox();
            this.DataView = new MetroFramework.Controls.MetroGrid();
            this.checkboxlist = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_sector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_partition_sectors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.physical_partition_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECTOR_SIZE_IN_BYTES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtloader = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.MetroTabPageNetworking = new MetroFramework.Controls.MetroTabPage();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.Button_write_nv = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Button_read_nv = new Guna.UI2.WinForms.Guna2GradientButton();
            this.CheckBox7 = new System.Windows.Forms.CheckBox();
            this.LabelIMEI2 = new System.Windows.Forms.Label();
            this.TextBox10 = new System.Windows.Forms.TextBox();
            this.CheckBox6 = new System.Windows.Forms.CheckBox();
            this.LabelIMEI1 = new System.Windows.Forms.Label();
            this.TextBox9 = new System.Windows.Forms.TextBox();
            this.Guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.Button_write_qcn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Button_read_qcn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.LabelQCN = new System.Windows.Forms.Label();
            this.TextBox8 = new System.Windows.Forms.TextBox();
            this.ProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            this.CariPortQcom = new System.Windows.Forms.Timer(this.components);
            this.cbsetboot = new System.Windows.Forms.CheckBox();
            this.ComboBox3 = new System.Windows.Forms.ComboBox();
            this.cbreboot = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label_transferrate = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.label_writensize = new System.Windows.Forms.Label();
            this.lblhwid = new System.Windows.Forms.Label();
            this.label_totalsize = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2GradientButtonSTOP = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.MetroStyleManager1)).BeginInit();
            this.MetroTabControl.SuspendLayout();
            this.MetroTabPageFlashing.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPageQualcommFlash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.MetroTabPageNetworking.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.Guna2GroupBox1.SuspendLayout();
            this.Guna2GradientPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MetroStyleManager1
            // 
            this.MetroStyleManager1.Owner = null;
            this.MetroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ProgressBar2
            // 
            this.ProgressBar2.FontSize = MetroFramework.MetroProgressBarSize.Small;
            this.ProgressBar2.FontWeight = MetroFramework.MetroProgressBarWeight.Bold;
            this.ProgressBar2.HideProgressText = false;
            this.ProgressBar2.Location = new System.Drawing.Point(27, 653);
            this.ProgressBar2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ProgressBar2.Name = "ProgressBar2";
            this.ProgressBar2.Size = new System.Drawing.Size(1157, 16);
            this.ProgressBar2.Style = MetroFramework.MetroColorStyle.Red;
            this.ProgressBar2.TabIndex = 0;
            this.ProgressBar2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProgressBar2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ProgressBar2.UseCustomBackColor = true;
            this.ProgressBar2.Value = 100;
            // 
            // MetroTabControl
            // 
            this.MetroTabControl.Controls.Add(this.MetroTabPageFlashing);
            this.MetroTabControl.Controls.Add(this.MetroTabPageNetworking);
            this.MetroTabControl.Location = new System.Drawing.Point(20, 73);
            this.MetroTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MetroTabControl.Name = "MetroTabControl";
            this.MetroTabControl.Padding = new System.Drawing.Point(6, 8);
            this.MetroTabControl.SelectedIndex = 0;
            this.MetroTabControl.Size = new System.Drawing.Size(1273, 531);
            this.MetroTabControl.Style = MetroFramework.MetroColorStyle.Red;
            this.MetroTabControl.TabIndex = 0;
            this.MetroTabControl.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MetroTabControl.UseSelectable = true;
            this.MetroTabControl.SelectedIndexChanged += new System.EventHandler(this.MetroTabControl_SelectedIndexChanged);
            // 
            // MetroTabPageFlashing
            // 
            this.MetroTabPageFlashing.Controls.Add(this.metroTabControl1);
            this.MetroTabPageFlashing.Controls.Add(this.guna2GradientButton1);
            this.MetroTabPageFlashing.Enabled = true;
            this.MetroTabPageFlashing.HorizontalScrollbarBarColor = true;
            this.MetroTabPageFlashing.HorizontalScrollbarHighlightOnWheel = false;
            this.MetroTabPageFlashing.HorizontalScrollbarSize = 12;
            this.MetroTabPageFlashing.Location = new System.Drawing.Point(4, 38);
            this.MetroTabPageFlashing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MetroTabPageFlashing.Name = "MetroTabPageFlashing";
            this.MetroTabPageFlashing.Size = new System.Drawing.Size(1265, 489);
            this.MetroTabPageFlashing.Style = MetroFramework.MetroColorStyle.Red;
            this.MetroTabPageFlashing.TabIndex = 0;
            this.MetroTabPageFlashing.Text = "DOWNLOAD";
            this.MetroTabPageFlashing.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MetroTabPageFlashing.VerticalScrollbarBarColor = true;
            this.MetroTabPageFlashing.VerticalScrollbarHighlightOnWheel = false;
            this.MetroTabPageFlashing.VerticalScrollbarSize = 13;
            this.MetroTabPageFlashing.Visible = true;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPageQualcommFlash);
            this.metroTabControl1.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Padding = new System.Drawing.Point(6, 8);
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(713, 487);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTabControl1.TabIndex = 249;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPageQualcommFlash
            // 
            this.metroTabPageQualcommFlash.Controls.Add(this.Guna2ImageButton_xml);
            this.metroTabPageQualcommFlash.Controls.Add(this.txtrawxml);
            this.metroTabPageQualcommFlash.Controls.Add(this.cbstorage);
            this.metroTabPageQualcommFlash.Controls.Add(this.Guna2ImageButton_loader);
            this.metroTabPageQualcommFlash.Controls.Add(this.guna2GradientButton2);
            this.metroTabPageQualcommFlash.Controls.Add(this.CheckBoxAutoCleanAccount);
            this.metroTabPageQualcommFlash.Controls.Add(this.CheckBoxAutoCleanUserdata);
            this.metroTabPageQualcommFlash.Controls.Add(this.btiden);
            this.metroTabPageQualcommFlash.Controls.Add(this.BTNERASE);
            this.metroTabPageQualcommFlash.Controls.Add(this.BTNREAD);
            this.metroTabPageQualcommFlash.Controls.Add(this.BTNFLASH);
            this.metroTabPageQualcommFlash.Controls.Add(this.CheckBox3);
            this.metroTabPageQualcommFlash.Controls.Add(this.DataView);
            this.metroTabPageQualcommFlash.Controls.Add(this.txtloader);
            this.metroTabPageQualcommFlash.Enabled = true;
            this.metroTabPageQualcommFlash.HorizontalScrollbarBarColor = true;
            this.metroTabPageQualcommFlash.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPageQualcommFlash.HorizontalScrollbarSize = 12;
            this.metroTabPageQualcommFlash.Location = new System.Drawing.Point(4, 38);
            this.metroTabPageQualcommFlash.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.metroTabPageQualcommFlash.Name = "metroTabPageQualcommFlash";
            this.metroTabPageQualcommFlash.Size = new System.Drawing.Size(705, 445);
            this.metroTabPageQualcommFlash.TabIndex = 0;
            this.metroTabPageQualcommFlash.Text = "FLASH";
            this.metroTabPageQualcommFlash.VerticalScrollbarBarColor = true;
            this.metroTabPageQualcommFlash.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPageQualcommFlash.VerticalScrollbarSize = 13;
            this.metroTabPageQualcommFlash.Visible = true;
            // 
            // Guna2ImageButton_xml
            // 
            this.Guna2ImageButton_xml.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Guna2ImageButton_xml.HoverState.ImageSize = new System.Drawing.Size(21, 21);
            this.Guna2ImageButton_xml.Image = ((System.Drawing.Image)(resources.GetObject("Guna2ImageButton_xml.Image")));
            this.Guna2ImageButton_xml.ImageOffset = new System.Drawing.Point(0, 0);
            this.Guna2ImageButton_xml.ImageRotate = 0F;
            this.Guna2ImageButton_xml.ImageSize = new System.Drawing.Size(20, 20);
            this.Guna2ImageButton_xml.IndicateFocus = true;
            this.Guna2ImageButton_xml.Location = new System.Drawing.Point(560, 408);
            this.Guna2ImageButton_xml.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Guna2ImageButton_xml.Name = "Guna2ImageButton_xml";
            this.Guna2ImageButton_xml.PressedState.ImageSize = new System.Drawing.Size(18, 18);
            this.Guna2ImageButton_xml.Size = new System.Drawing.Size(23, 20);
            this.Guna2ImageButton_xml.TabIndex = 273;
            this.Guna2ImageButton_xml.Click += new System.EventHandler(this.Guna2ImageButton_xml_Click);
            // 
            // txtrawxml
            // 
            this.txtrawxml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtrawxml.BorderColor = System.Drawing.Color.Gray;
            this.txtrawxml.BorderRadius = 1;
            this.txtrawxml.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtrawxml.DefaultText = "";
            this.txtrawxml.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtrawxml.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtrawxml.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtrawxml.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtrawxml.FocusedState.BorderColor = System.Drawing.Color.Red;
            this.txtrawxml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrawxml.ForeColor = System.Drawing.Color.DarkRed;
            this.txtrawxml.HoverState.BorderColor = System.Drawing.Color.Red;
            this.txtrawxml.Location = new System.Drawing.Point(1, 407);
            this.txtrawxml.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtrawxml.Name = "txtrawxml";
            this.txtrawxml.PasswordChar = '\0';
            this.txtrawxml.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtrawxml.PlaceholderText = "Browse *xml file...";
            this.txtrawxml.SelectedText = "";
            this.txtrawxml.Size = new System.Drawing.Size(587, 22);
            this.txtrawxml.TabIndex = 274;
            // 
            // cbstorage
            // 
            this.cbstorage.ForeColor = System.Drawing.Color.DarkRed;
            this.cbstorage.FormattingEnabled = true;
            this.cbstorage.Items.AddRange(new object[] {
            "emmc",
            "ufs"});
            this.cbstorage.Location = new System.Drawing.Point(596, 406);
            this.cbstorage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbstorage.Name = "cbstorage";
            this.cbstorage.Size = new System.Drawing.Size(97, 23);
            this.cbstorage.TabIndex = 272;
            this.cbstorage.SelectedIndexChanged += new System.EventHandler(this.cbstorage_SelectedIndexChanged);
            // 
            // Guna2ImageButton_loader
            // 
            this.Guna2ImageButton_loader.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Guna2ImageButton_loader.HoverState.ImageSize = new System.Drawing.Size(21, 21);
            this.Guna2ImageButton_loader.Image = ((System.Drawing.Image)(resources.GetObject("Guna2ImageButton_loader.Image")));
            this.Guna2ImageButton_loader.ImageOffset = new System.Drawing.Point(0, 0);
            this.Guna2ImageButton_loader.ImageRotate = 0F;
            this.Guna2ImageButton_loader.ImageSize = new System.Drawing.Size(20, 20);
            this.Guna2ImageButton_loader.IndicateFocus = true;
            this.Guna2ImageButton_loader.Location = new System.Drawing.Point(557, 380);
            this.Guna2ImageButton_loader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Guna2ImageButton_loader.Name = "Guna2ImageButton_loader";
            this.Guna2ImageButton_loader.Size = new System.Drawing.Size(24, 20);
            this.Guna2ImageButton_loader.TabIndex = 270;
            this.Guna2ImageButton_loader.Click += new System.EventHandler(this.Guna2ImageButton_loader_Click);
            // 
            // guna2GradientButton2
            // 
            this.guna2GradientButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientButton2.Animated = true;
            this.guna2GradientButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2GradientButton2.BorderRadius = 4;
            this.guna2GradientButton2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton2.FillColor = System.Drawing.Color.Red;
            this.guna2GradientButton2.FillColor2 = System.Drawing.Color.Gray;
            this.guna2GradientButton2.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.guna2GradientButton2.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.guna2GradientButton2.HoverState.BorderColor = System.Drawing.Color.Red;
            this.guna2GradientButton2.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2GradientButton2.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2GradientButton2.HoverState.FillColor2 = System.Drawing.Color.Red;
            this.guna2GradientButton2.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2GradientButton2.ImageSize = new System.Drawing.Size(18, 18);
            this.guna2GradientButton2.IndicateFocus = true;
            this.guna2GradientButton2.Location = new System.Drawing.Point(273, 347);
            this.guna2GradientButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2GradientButton2.Name = "guna2GradientButton2";
            this.guna2GradientButton2.Size = new System.Drawing.Size(100, 24);
            this.guna2GradientButton2.TabIndex = 266;
            this.guna2GradientButton2.Text = "Reboot";
            this.guna2GradientButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2GradientButton2.Click += new System.EventHandler(this.guna2GradientButton2_Click);
            // 
            // CheckBoxAutoCleanAccount
            // 
            this.CheckBoxAutoCleanAccount.AutoSize = true;
            this.CheckBoxAutoCleanAccount.BackColor = System.Drawing.SystemColors.Window;
            this.CheckBoxAutoCleanAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBoxAutoCleanAccount.Location = new System.Drawing.Point(143, 352);
            this.CheckBoxAutoCleanAccount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckBoxAutoCleanAccount.Name = "CheckBoxAutoCleanAccount";
            this.CheckBoxAutoCleanAccount.Size = new System.Drawing.Size(129, 19);
            this.CheckBoxAutoCleanAccount.TabIndex = 265;
            this.CheckBoxAutoCleanAccount.Text = "Clean Account";
            this.CheckBoxAutoCleanAccount.UseVisualStyleBackColor = false;
            // 
            // CheckBoxAutoCleanUserdata
            // 
            this.CheckBoxAutoCleanUserdata.AutoSize = true;
            this.CheckBoxAutoCleanUserdata.BackColor = System.Drawing.SystemColors.Window;
            this.CheckBoxAutoCleanUserdata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBoxAutoCleanUserdata.Location = new System.Drawing.Point(1, 352);
            this.CheckBoxAutoCleanUserdata.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckBoxAutoCleanUserdata.Name = "CheckBoxAutoCleanUserdata";
            this.CheckBoxAutoCleanUserdata.Size = new System.Drawing.Size(137, 19);
            this.CheckBoxAutoCleanUserdata.TabIndex = 264;
            this.CheckBoxAutoCleanUserdata.Text = "Clean Userdata";
            this.CheckBoxAutoCleanUserdata.UseVisualStyleBackColor = false;
            // 
            // btiden
            // 
            this.btiden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btiden.Animated = true;
            this.btiden.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btiden.BorderRadius = 4;
            this.btiden.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btiden.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btiden.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btiden.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btiden.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btiden.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btiden.FillColor = System.Drawing.Color.Red;
            this.btiden.FillColor2 = System.Drawing.Color.Gray;
            this.btiden.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btiden.ForeColor = System.Drawing.Color.White;
            this.btiden.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.btiden.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btiden.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.btiden.HoverState.FillColor = System.Drawing.Color.Red;
            this.btiden.HoverState.FillColor2 = System.Drawing.Color.Red;
            this.btiden.HoverState.ForeColor = System.Drawing.Color.White;
            this.btiden.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btiden.ImageSize = new System.Drawing.Size(18, 18);
            this.btiden.IndicateFocus = true;
            this.btiden.Location = new System.Drawing.Point(596, 376);
            this.btiden.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btiden.Name = "btiden";
            this.btiden.Size = new System.Drawing.Size(100, 24);
            this.btiden.TabIndex = 261;
            this.btiden.Text = "Read GPT";
            this.btiden.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btiden.Click += new System.EventHandler(this.btiden_Click);
            // 
            // BTNERASE
            // 
            this.BTNERASE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNERASE.Animated = true;
            this.BTNERASE.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTNERASE.BorderRadius = 4;
            this.BTNERASE.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTNERASE.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BTNERASE.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BTNERASE.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BTNERASE.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BTNERASE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BTNERASE.FillColor = System.Drawing.Color.Red;
            this.BTNERASE.FillColor2 = System.Drawing.Color.Gray;
            this.BTNERASE.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.BTNERASE.ForeColor = System.Drawing.Color.White;
            this.BTNERASE.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.BTNERASE.HoverState.BorderColor = System.Drawing.Color.Red;
            this.BTNERASE.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.BTNERASE.HoverState.FillColor = System.Drawing.Color.Red;
            this.BTNERASE.HoverState.FillColor2 = System.Drawing.Color.Red;
            this.BTNERASE.HoverState.ForeColor = System.Drawing.Color.White;
            this.BTNERASE.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BTNERASE.ImageSize = new System.Drawing.Size(18, 18);
            this.BTNERASE.IndicateFocus = true;
            this.BTNERASE.Location = new System.Drawing.Point(381, 347);
            this.BTNERASE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTNERASE.Name = "BTNERASE";
            this.BTNERASE.Size = new System.Drawing.Size(100, 24);
            this.BTNERASE.TabIndex = 260;
            this.BTNERASE.Text = "Erase";
            this.BTNERASE.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BTNERASE.Click += new System.EventHandler(this.BTNERASE_Click);
            // 
            // BTNREAD
            // 
            this.BTNREAD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNREAD.Animated = true;
            this.BTNREAD.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTNREAD.BorderRadius = 4;
            this.BTNREAD.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTNREAD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BTNREAD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BTNREAD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BTNREAD.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BTNREAD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BTNREAD.FillColor = System.Drawing.Color.Red;
            this.BTNREAD.FillColor2 = System.Drawing.Color.Gray;
            this.BTNREAD.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.BTNREAD.ForeColor = System.Drawing.Color.White;
            this.BTNREAD.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.BTNREAD.HoverState.BorderColor = System.Drawing.Color.Red;
            this.BTNREAD.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.BTNREAD.HoverState.FillColor = System.Drawing.Color.Red;
            this.BTNREAD.HoverState.FillColor2 = System.Drawing.Color.Red;
            this.BTNREAD.HoverState.ForeColor = System.Drawing.Color.White;
            this.BTNREAD.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BTNREAD.ImageSize = new System.Drawing.Size(18, 18);
            this.BTNREAD.IndicateFocus = true;
            this.BTNREAD.Location = new System.Drawing.Point(488, 347);
            this.BTNREAD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTNREAD.Name = "BTNREAD";
            this.BTNREAD.Size = new System.Drawing.Size(100, 24);
            this.BTNREAD.TabIndex = 258;
            this.BTNREAD.Text = "Backup";
            this.BTNREAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BTNREAD.Click += new System.EventHandler(this.BTNREAD_Click);
            // 
            // BTNFLASH
            // 
            this.BTNFLASH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNFLASH.Animated = true;
            this.BTNFLASH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTNFLASH.BorderRadius = 4;
            this.BTNFLASH.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTNFLASH.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BTNFLASH.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BTNFLASH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BTNFLASH.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BTNFLASH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BTNFLASH.FillColor = System.Drawing.Color.Red;
            this.BTNFLASH.FillColor2 = System.Drawing.Color.Gray;
            this.BTNFLASH.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.BTNFLASH.ForeColor = System.Drawing.Color.White;
            this.BTNFLASH.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.BTNFLASH.HoverState.BorderColor = System.Drawing.Color.Red;
            this.BTNFLASH.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.BTNFLASH.HoverState.FillColor = System.Drawing.Color.Red;
            this.BTNFLASH.HoverState.FillColor2 = System.Drawing.Color.Red;
            this.BTNFLASH.HoverState.ForeColor = System.Drawing.Color.White;
            this.BTNFLASH.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BTNFLASH.ImageSize = new System.Drawing.Size(18, 18);
            this.BTNFLASH.IndicateFocus = true;
            this.BTNFLASH.Location = new System.Drawing.Point(596, 347);
            this.BTNFLASH.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BTNFLASH.Name = "BTNFLASH";
            this.BTNFLASH.Size = new System.Drawing.Size(100, 24);
            this.BTNFLASH.TabIndex = 257;
            this.BTNFLASH.Text = "Flash";
            this.BTNFLASH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BTNFLASH.Click += new System.EventHandler(this.BTNFLASH_Click);
            // 
            // CheckBox3
            // 
            this.CheckBox3.AutoSize = true;
            this.CheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CheckBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox3.FlatAppearance.BorderSize = 0;
            this.CheckBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.CheckBox3.Location = new System.Drawing.Point(7, 6);
            this.CheckBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckBox3.Name = "CheckBox3";
            this.CheckBox3.Size = new System.Drawing.Size(14, 13);
            this.CheckBox3.TabIndex = 256;
            this.CheckBox3.UseVisualStyleBackColor = false;
            this.CheckBox3.CheckedChanged += new System.EventHandler(this.CheckBox3_CheckedChanged);
            // 
            // DataView
            // 
            this.DataView.AllowUserToAddRows = false;
            this.DataView.AllowUserToDeleteRows = false;
            this.DataView.AllowUserToResizeRows = false;
            this.DataView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkboxlist,
            this.label,
            this.filename,
            this.start_sector,
            this.num_partition_sectors,
            this.physical_partition_number,
            this.SECTOR_SIZE_IN_BYTES});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataView.DefaultCellStyle = dataGridViewCellStyle19;
            this.DataView.EnableHeadersVisualStyles = false;
            this.DataView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DataView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DataView.Location = new System.Drawing.Point(1, 3);
            this.DataView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DataView.Name = "DataView";
            this.DataView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.DataView.RowHeadersVisible = false;
            this.DataView.RowHeadersWidth = 51;
            this.DataView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataView.Size = new System.Drawing.Size(700, 337);
            this.DataView.Style = MetroFramework.MetroColorStyle.Red;
            this.DataView.TabIndex = 252;
            this.DataView.Theme = MetroFramework.MetroThemeStyle.Light;
            this.DataView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_CellDoubleClick);
            // 
            // checkboxlist
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle12.NullValue = false;
            this.checkboxlist.DefaultCellStyle = dataGridViewCellStyle12;
            this.checkboxlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkboxlist.HeaderText = " ";
            this.checkboxlist.MinimumWidth = 6;
            this.checkboxlist.Name = "checkboxlist";
            this.checkboxlist.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.checkboxlist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.checkboxlist.Width = 20;
            // 
            // label
            // 
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.label.DefaultCellStyle = dataGridViewCellStyle13;
            this.label.HeaderText = "Partition";
            this.label.MinimumWidth = 6;
            this.label.Name = "label";
            this.label.Width = 80;
            // 
            // filename
            // 
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            this.filename.DefaultCellStyle = dataGridViewCellStyle14;
            this.filename.HeaderText = "Filename";
            this.filename.MinimumWidth = 6;
            this.filename.Name = "filename";
            this.filename.Width = 80;
            // 
            // start_sector
            // 
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            this.start_sector.DefaultCellStyle = dataGridViewCellStyle15;
            this.start_sector.HeaderText = "Start Sector";
            this.start_sector.MinimumWidth = 6;
            this.start_sector.Name = "start_sector";
            this.start_sector.Width = 125;
            // 
            // num_partition_sectors
            // 
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            this.num_partition_sectors.DefaultCellStyle = dataGridViewCellStyle16;
            this.num_partition_sectors.HeaderText = "Num Sector";
            this.num_partition_sectors.MinimumWidth = 6;
            this.num_partition_sectors.Name = "num_partition_sectors";
            this.num_partition_sectors.Width = 125;
            // 
            // physical_partition_number
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            this.physical_partition_number.DefaultCellStyle = dataGridViewCellStyle17;
            this.physical_partition_number.HeaderText = "LUN";
            this.physical_partition_number.MinimumWidth = 6;
            this.physical_partition_number.Name = "physical_partition_number";
            this.physical_partition_number.Width = 34;
            // 
            // SECTOR_SIZE_IN_BYTES
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            this.SECTOR_SIZE_IN_BYTES.DefaultCellStyle = dataGridViewCellStyle18;
            this.SECTOR_SIZE_IN_BYTES.HeaderText = "Sector Size";
            this.SECTOR_SIZE_IN_BYTES.MinimumWidth = 6;
            this.SECTOR_SIZE_IN_BYTES.Name = "SECTOR_SIZE_IN_BYTES";
            this.SECTOR_SIZE_IN_BYTES.Width = 90;
            // 
            // txtloader
            // 
            this.txtloader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtloader.BorderColor = System.Drawing.Color.Gray;
            this.txtloader.BorderRadius = 1;
            this.txtloader.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtloader.DefaultText = "";
            this.txtloader.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtloader.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtloader.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtloader.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtloader.FocusedState.BorderColor = System.Drawing.Color.Red;
            this.txtloader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.txtloader.ForeColor = System.Drawing.Color.DarkRed;
            this.txtloader.HoverState.BorderColor = System.Drawing.Color.Red;
            this.txtloader.Location = new System.Drawing.Point(0, 378);
            this.txtloader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtloader.Name = "txtloader";
            this.txtloader.PasswordChar = '\0';
            this.txtloader.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtloader.PlaceholderText = "Browse firehose programmer file...";
            this.txtloader.SelectedText = "";
            this.txtloader.Size = new System.Drawing.Size(588, 22);
            this.txtloader.TabIndex = 271;
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientButton1.Animated = true;
            this.guna2GradientButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2GradientButton1.BorderRadius = 4;
            this.guna2GradientButton1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.Red;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.Gray;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.guna2GradientButton1.HoverState.BorderColor = System.Drawing.Color.Red;
            this.guna2GradientButton1.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2GradientButton1.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2GradientButton1.HoverState.FillColor2 = System.Drawing.Color.Red;
            this.guna2GradientButton1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2GradientButton1.ImageSize = new System.Drawing.Size(18, 18);
            this.guna2GradientButton1.IndicateFocus = true;
            this.guna2GradientButton1.Location = new System.Drawing.Point(821, 418);
            this.guna2GradientButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(100, 27);
            this.guna2GradientButton1.TabIndex = 248;
            this.guna2GradientButton1.Text = "Flash";
            this.guna2GradientButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // MetroTabPageNetworking
            // 
            this.MetroTabPageNetworking.Controls.Add(this.guna2GroupBox2);
            this.MetroTabPageNetworking.Controls.Add(this.Guna2GroupBox1);
            this.MetroTabPageNetworking.Enabled = true;
            this.MetroTabPageNetworking.HorizontalScrollbarBarColor = true;
            this.MetroTabPageNetworking.HorizontalScrollbarHighlightOnWheel = false;
            this.MetroTabPageNetworking.HorizontalScrollbarSize = 12;
            this.MetroTabPageNetworking.Location = new System.Drawing.Point(4, 38);
            this.MetroTabPageNetworking.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MetroTabPageNetworking.Name = "MetroTabPageNetworking";
            this.MetroTabPageNetworking.Size = new System.Drawing.Size(1265, 489);
            this.MetroTabPageNetworking.TabIndex = 3;
            this.MetroTabPageNetworking.Text = "SERVICES";
            this.MetroTabPageNetworking.VerticalScrollbarBarColor = true;
            this.MetroTabPageNetworking.VerticalScrollbarHighlightOnWheel = false;
            this.MetroTabPageNetworking.VerticalScrollbarSize = 13;
            this.MetroTabPageNetworking.Visible = false;
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox2.BackColor = System.Drawing.SystemColors.Window;
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.guna2GroupBox2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2GroupBox2.Controls.Add(this.Button_write_nv);
            this.guna2GroupBox2.Controls.Add(this.Button_read_nv);
            this.guna2GroupBox2.Controls.Add(this.CheckBox7);
            this.guna2GroupBox2.Controls.Add(this.LabelIMEI2);
            this.guna2GroupBox2.Controls.Add(this.TextBox10);
            this.guna2GroupBox2.Controls.Add(this.CheckBox6);
            this.guna2GroupBox2.Controls.Add(this.LabelIMEI1);
            this.guna2GroupBox2.Controls.Add(this.TextBox9);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.Red;
            this.guna2GroupBox2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.guna2GroupBox2.FillColor = System.Drawing.SystemColors.Window;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox2.Location = new System.Drawing.Point(7, 258);
            this.guna2GroupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(700, 219);
            this.guna2GroupBox2.TabIndex = 232;
            this.guna2GroupBox2.Text = "Read Write NV Item";
            this.guna2GroupBox2.TextOffset = new System.Drawing.Point(0, -10);
            // 
            // Button_write_nv
            // 
            this.Button_write_nv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_write_nv.Animated = true;
            this.Button_write_nv.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_write_nv.BorderRadius = 4;
            this.Button_write_nv.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_write_nv.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_write_nv.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_write_nv.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_write_nv.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_write_nv.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_write_nv.FillColor = System.Drawing.Color.Red;
            this.Button_write_nv.FillColor2 = System.Drawing.Color.Gray;
            this.Button_write_nv.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.Button_write_nv.ForeColor = System.Drawing.Color.White;
            this.Button_write_nv.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.Button_write_nv.HoverState.BorderColor = System.Drawing.Color.Red;
            this.Button_write_nv.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.Button_write_nv.HoverState.FillColor = System.Drawing.Color.Red;
            this.Button_write_nv.HoverState.FillColor2 = System.Drawing.Color.Red;
            this.Button_write_nv.HoverState.ForeColor = System.Drawing.Color.White;
            this.Button_write_nv.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Button_write_nv.ImageSize = new System.Drawing.Size(18, 18);
            this.Button_write_nv.IndicateFocus = true;
            this.Button_write_nv.Location = new System.Drawing.Point(543, 140);
            this.Button_write_nv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Button_write_nv.Name = "Button_write_nv";
            this.Button_write_nv.Size = new System.Drawing.Size(147, 27);
            this.Button_write_nv.TabIndex = 247;
            this.Button_write_nv.Text = "Write NV";
            this.Button_write_nv.Click += new System.EventHandler(this.Button_write_nv_Click);
            // 
            // Button_read_nv
            // 
            this.Button_read_nv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_read_nv.Animated = true;
            this.Button_read_nv.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_read_nv.BorderRadius = 4;
            this.Button_read_nv.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_read_nv.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_read_nv.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_read_nv.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_read_nv.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_read_nv.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_read_nv.FillColor = System.Drawing.Color.Red;
            this.Button_read_nv.FillColor2 = System.Drawing.Color.Gray;
            this.Button_read_nv.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.Button_read_nv.ForeColor = System.Drawing.Color.White;
            this.Button_read_nv.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.Button_read_nv.HoverState.BorderColor = System.Drawing.Color.Red;
            this.Button_read_nv.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.Button_read_nv.HoverState.FillColor = System.Drawing.Color.Red;
            this.Button_read_nv.HoverState.FillColor2 = System.Drawing.Color.Red;
            this.Button_read_nv.HoverState.ForeColor = System.Drawing.Color.White;
            this.Button_read_nv.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Button_read_nv.ImageSize = new System.Drawing.Size(18, 18);
            this.Button_read_nv.IndicateFocus = true;
            this.Button_read_nv.Location = new System.Drawing.Point(79, 140);
            this.Button_read_nv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Button_read_nv.Name = "Button_read_nv";
            this.Button_read_nv.Size = new System.Drawing.Size(147, 27);
            this.Button_read_nv.TabIndex = 246;
            this.Button_read_nv.Text = "Read NV";
            this.Button_read_nv.Click += new System.EventHandler(this.Button_read_nv_Click);
            // 
            // CheckBox7
            // 
            this.CheckBox7.AutoSize = true;
            this.CheckBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBox7.ForeColor = System.Drawing.Color.DarkRed;
            this.CheckBox7.Location = new System.Drawing.Point(673, 112);
            this.CheckBox7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckBox7.Name = "CheckBox7";
            this.CheckBox7.Size = new System.Drawing.Size(14, 13);
            this.CheckBox7.TabIndex = 245;
            this.CheckBox7.UseVisualStyleBackColor = true;
            // 
            // LabelIMEI2
            // 
            this.LabelIMEI2.AutoSize = true;
            this.LabelIMEI2.BackColor = System.Drawing.SystemColors.Window;
            this.LabelIMEI2.ForeColor = System.Drawing.Color.DarkRed;
            this.LabelIMEI2.Location = new System.Drawing.Point(5, 111);
            this.LabelIMEI2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelIMEI2.Name = "LabelIMEI2";
            this.LabelIMEI2.Size = new System.Drawing.Size(49, 19);
            this.LabelIMEI2.TabIndex = 244;
            this.LabelIMEI2.Text = "IMEI 2";
            // 
            // TextBox10
            // 
            this.TextBox10.Location = new System.Drawing.Point(79, 107);
            this.TextBox10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.Size = new System.Drawing.Size(609, 26);
            this.TextBox10.TabIndex = 243;
            // 
            // CheckBox6
            // 
            this.CheckBox6.AutoSize = true;
            this.CheckBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBox6.ForeColor = System.Drawing.Color.DarkRed;
            this.CheckBox6.Location = new System.Drawing.Point(673, 82);
            this.CheckBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CheckBox6.Name = "CheckBox6";
            this.CheckBox6.Size = new System.Drawing.Size(14, 13);
            this.CheckBox6.TabIndex = 242;
            this.CheckBox6.UseVisualStyleBackColor = true;
            // 
            // LabelIMEI1
            // 
            this.LabelIMEI1.AutoSize = true;
            this.LabelIMEI1.BackColor = System.Drawing.SystemColors.Window;
            this.LabelIMEI1.ForeColor = System.Drawing.Color.DarkRed;
            this.LabelIMEI1.Location = new System.Drawing.Point(5, 81);
            this.LabelIMEI1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelIMEI1.Name = "LabelIMEI1";
            this.LabelIMEI1.Size = new System.Drawing.Size(49, 19);
            this.LabelIMEI1.TabIndex = 241;
            this.LabelIMEI1.Text = "IMEI 1";
            // 
            // TextBox9
            // 
            this.TextBox9.Location = new System.Drawing.Point(79, 77);
            this.TextBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.Size = new System.Drawing.Size(609, 26);
            this.TextBox9.TabIndex = 240;
            // 
            // Guna2GroupBox1
            // 
            this.Guna2GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Guna2GroupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.Guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Guna2GroupBox1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.Guna2GroupBox1.Controls.Add(this.Button_write_qcn);
            this.Guna2GroupBox1.Controls.Add(this.Button_read_qcn);
            this.Guna2GroupBox1.Controls.Add(this.LabelQCN);
            this.Guna2GroupBox1.Controls.Add(this.TextBox8);
            this.Guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Red;
            this.Guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.Guna2GroupBox1.FillColor = System.Drawing.SystemColors.Window;
            this.Guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.Guna2GroupBox1.Location = new System.Drawing.Point(7, 15);
            this.Guna2GroupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Guna2GroupBox1.Name = "Guna2GroupBox1";
            this.Guna2GroupBox1.Size = new System.Drawing.Size(700, 219);
            this.Guna2GroupBox1.TabIndex = 231;
            this.Guna2GroupBox1.Text = "Read Write QCN";
            this.Guna2GroupBox1.TextOffset = new System.Drawing.Point(0, -10);
            // 
            // Button_write_qcn
            // 
            this.Button_write_qcn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_write_qcn.Animated = true;
            this.Button_write_qcn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_write_qcn.BorderRadius = 4;
            this.Button_write_qcn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_write_qcn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_write_qcn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_write_qcn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_write_qcn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_write_qcn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_write_qcn.FillColor = System.Drawing.Color.Red;
            this.Button_write_qcn.FillColor2 = System.Drawing.Color.Gray;
            this.Button_write_qcn.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.Button_write_qcn.ForeColor = System.Drawing.Color.White;
            this.Button_write_qcn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.Button_write_qcn.HoverState.BorderColor = System.Drawing.Color.Red;
            this.Button_write_qcn.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.Button_write_qcn.HoverState.FillColor = System.Drawing.Color.Red;
            this.Button_write_qcn.HoverState.FillColor2 = System.Drawing.Color.Red;
            this.Button_write_qcn.HoverState.ForeColor = System.Drawing.Color.White;
            this.Button_write_qcn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Button_write_qcn.ImageSize = new System.Drawing.Size(18, 18);
            this.Button_write_qcn.IndicateFocus = true;
            this.Button_write_qcn.Location = new System.Drawing.Point(543, 119);
            this.Button_write_qcn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Button_write_qcn.Name = "Button_write_qcn";
            this.Button_write_qcn.Size = new System.Drawing.Size(147, 27);
            this.Button_write_qcn.TabIndex = 242;
            this.Button_write_qcn.Text = "Write QCN";
            this.Button_write_qcn.Click += new System.EventHandler(this.Button_write_qcn_Click);
            // 
            // Button_read_qcn
            // 
            this.Button_read_qcn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_read_qcn.Animated = true;
            this.Button_read_qcn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_read_qcn.BorderRadius = 4;
            this.Button_read_qcn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_read_qcn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_read_qcn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_read_qcn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_read_qcn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_read_qcn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_read_qcn.FillColor = System.Drawing.Color.Red;
            this.Button_read_qcn.FillColor2 = System.Drawing.Color.Gray;
            this.Button_read_qcn.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.Button_read_qcn.ForeColor = System.Drawing.Color.White;
            this.Button_read_qcn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.Button_read_qcn.HoverState.BorderColor = System.Drawing.Color.Red;
            this.Button_read_qcn.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.Button_read_qcn.HoverState.FillColor = System.Drawing.Color.Red;
            this.Button_read_qcn.HoverState.FillColor2 = System.Drawing.Color.Red;
            this.Button_read_qcn.HoverState.ForeColor = System.Drawing.Color.White;
            this.Button_read_qcn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Button_read_qcn.ImageSize = new System.Drawing.Size(18, 18);
            this.Button_read_qcn.IndicateFocus = true;
            this.Button_read_qcn.Location = new System.Drawing.Point(79, 119);
            this.Button_read_qcn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Button_read_qcn.Name = "Button_read_qcn";
            this.Button_read_qcn.Size = new System.Drawing.Size(147, 27);
            this.Button_read_qcn.TabIndex = 241;
            this.Button_read_qcn.Text = "Read QCN";
            this.Button_read_qcn.Click += new System.EventHandler(this.Button_read_qcn_Click);
            // 
            // LabelQCN
            // 
            this.LabelQCN.AutoSize = true;
            this.LabelQCN.BackColor = System.Drawing.SystemColors.Window;
            this.LabelQCN.ForeColor = System.Drawing.Color.DarkRed;
            this.LabelQCN.Location = new System.Drawing.Point(5, 90);
            this.LabelQCN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelQCN.Name = "LabelQCN";
            this.LabelQCN.Size = new System.Drawing.Size(63, 19);
            this.LabelQCN.TabIndex = 240;
            this.LabelQCN.Text = "QCN File";
            // 
            // TextBox8
            // 
            this.TextBox8.Location = new System.Drawing.Point(79, 87);
            this.TextBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Size = new System.Drawing.Size(609, 26);
            this.TextBox8.TabIndex = 239;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.FontSize = MetroFramework.MetroProgressBarSize.Small;
            this.ProgressBar1.FontWeight = MetroFramework.MetroProgressBarWeight.Bold;
            this.ProgressBar1.HideProgressText = false;
            this.ProgressBar1.Location = new System.Drawing.Point(27, 637);
            this.ProgressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(1157, 16);
            this.ProgressBar1.Style = MetroFramework.MetroColorStyle.Red;
            this.ProgressBar1.TabIndex = 2;
            this.ProgressBar1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProgressBar1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ProgressBar1.UseCustomBackColor = true;
            this.ProgressBar1.Value = 100;
            // 
            // RichTextBox
            // 
            this.RichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox.Location = new System.Drawing.Point(747, 151);
            this.RichTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.RichTextBox.Size = new System.Drawing.Size(531, 443);
            this.RichTextBox.TabIndex = 4;
            this.RichTextBox.Text = "";
            this.RichTextBox.TextChanged += new System.EventHandler(this.RichTextBox_TextChanged);
            // 
            // CariPortQcom
            // 
            this.CariPortQcom.Interval = 1000;
            this.CariPortQcom.Tick += new System.EventHandler(this.CariPortQcom_Tick);
            // 
            // cbsetboot
            // 
            this.cbsetboot.AutoSize = true;
            this.cbsetboot.BackColor = System.Drawing.SystemColors.Window;
            this.cbsetboot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbsetboot.Location = new System.Drawing.Point(873, 125);
            this.cbsetboot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbsetboot.Name = "cbsetboot";
            this.cbsetboot.Size = new System.Drawing.Size(89, 19);
            this.cbsetboot.TabIndex = 44;
            this.cbsetboot.Text = "Set Boot";
            this.cbsetboot.UseVisualStyleBackColor = false;
            // 
            // ComboBox3
            // 
            this.ComboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.ComboBox3.FormattingEnabled = true;
            this.ComboBox3.Location = new System.Drawing.Point(973, 122);
            this.ComboBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ComboBox3.Name = "ComboBox3";
            this.ComboBox3.Size = new System.Drawing.Size(304, 23);
            this.ComboBox3.TabIndex = 42;
            // 
            // cbreboot
            // 
            this.cbreboot.AutoSize = true;
            this.cbreboot.BackColor = System.Drawing.SystemColors.Window;
            this.cbreboot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbreboot.Location = new System.Drawing.Point(747, 125);
            this.cbreboot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbreboot.Name = "cbreboot";
            this.cbreboot.Size = new System.Drawing.Size(113, 19);
            this.cbreboot.TabIndex = 43;
            this.cbreboot.Text = "Auto Reboot";
            this.cbreboot.UseVisualStyleBackColor = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.Label1.Location = new System.Drawing.Point(1251, 126);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(27, 16);
            this.Label1.TabIndex = 86;
            this.Label1.Text = "[    ]";
            this.Label1.Visible = false;
            // 
            // Guna2GradientPanel3
            // 
            this.Guna2GradientPanel3.BackColor = System.Drawing.SystemColors.Window;
            this.Guna2GradientPanel3.Controls.Add(this.label_transferrate);
            this.Guna2GradientPanel3.Controls.Add(this.Label16);
            this.Guna2GradientPanel3.Controls.Add(this.Label18);
            this.Guna2GradientPanel3.Controls.Add(this.lbldate);
            this.Guna2GradientPanel3.Controls.Add(this.Label4);
            this.Guna2GradientPanel3.Controls.Add(this.label_writensize);
            this.Guna2GradientPanel3.Controls.Add(this.lblhwid);
            this.Guna2GradientPanel3.Controls.Add(this.label_totalsize);
            this.Guna2GradientPanel3.Controls.Add(this.Label12);
            this.Guna2GradientPanel3.Controls.Add(this.Label14);
            this.Guna2GradientPanel3.Controls.Add(this.label5);
            this.Guna2GradientPanel3.Controls.Add(this.Label17);
            this.Guna2GradientPanel3.Controls.Add(this.label6);
            this.Guna2GradientPanel3.Controls.Add(this.label7);
            this.Guna2GradientPanel3.Location = new System.Drawing.Point(27, 612);
            this.Guna2GradientPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Guna2GradientPanel3.Name = "Guna2GradientPanel3";
            this.Guna2GradientPanel3.Size = new System.Drawing.Size(1260, 25);
            this.Guna2GradientPanel3.TabIndex = 89;
            // 
            // label_transferrate
            // 
            this.label_transferrate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_transferrate.AutoSize = true;
            this.label_transferrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_transferrate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_transferrate.ForeColor = System.Drawing.Color.Black;
            this.label_transferrate.Location = new System.Drawing.Point(584, 6);
            this.label_transferrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_transferrate.Name = "label_transferrate";
            this.label_transferrate.Size = new System.Drawing.Size(133, 19);
            this.label_transferrate.TabIndex = 33;
            this.label_transferrate.Text = "0.00 Bytes /s           ";
            // 
            // Label16
            // 
            this.Label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label16.AutoSize = true;
            this.Label16.BackColor = System.Drawing.Color.Transparent;
            this.Label16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.ForeColor = System.Drawing.Color.Gainsboro;
            this.Label16.Location = new System.Drawing.Point(1155, 6);
            this.Label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(13, 19);
            this.Label16.TabIndex = 32;
            this.Label16.Text = ":";
            // 
            // Label18
            // 
            this.Label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label18.AutoSize = true;
            this.Label18.BackColor = System.Drawing.Color.Transparent;
            this.Label18.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Label18.ForeColor = System.Drawing.Color.DarkRed;
            this.Label18.Location = new System.Drawing.Point(1093, 6);
            this.Label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(65, 19);
            this.Label18.TabIndex = 31;
            this.Label18.Text = "Version : ";
            // 
            // lbldate
            // 
            this.lbldate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbldate.AutoSize = true;
            this.lbldate.BackColor = System.Drawing.Color.Transparent;
            this.lbldate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbldate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbldate.ForeColor = System.Drawing.Color.Black;
            this.lbldate.Location = new System.Drawing.Point(1176, 6);
            this.lbldate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(64, 19);
            this.lbldate.TabIndex = 30;
            this.lbldate.Text = "Release I";
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Label4.ForeColor = System.Drawing.Color.DarkRed;
            this.Label4.Location = new System.Drawing.Point(465, 6);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(99, 19);
            this.Label4.TabIndex = 15;
            this.Label4.Text = "Transfer Rate : ";
            // 
            // label_writensize
            // 
            this.label_writensize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_writensize.AutoSize = true;
            this.label_writensize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_writensize.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_writensize.ForeColor = System.Drawing.Color.Black;
            this.label_writensize.Location = new System.Drawing.Point(335, 6);
            this.label_writensize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_writensize.Name = "label_writensize";
            this.label_writensize.Size = new System.Drawing.Size(117, 19);
            this.label_writensize.TabIndex = 14;
            this.label_writensize.Text = "0.00 Bytes           ";
            // 
            // lblhwid
            // 
            this.lblhwid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblhwid.AutoSize = true;
            this.lblhwid.BackColor = System.Drawing.Color.Transparent;
            this.lblhwid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblhwid.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblhwid.ForeColor = System.Drawing.Color.Black;
            this.lblhwid.Location = new System.Drawing.Point(779, 6);
            this.lblhwid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhwid.Name = "lblhwid";
            this.lblhwid.Size = new System.Drawing.Size(48, 19);
            this.lblhwid.TabIndex = 28;
            this.lblhwid.Text = "Active";
            // 
            // label_totalsize
            // 
            this.label_totalsize.AutoSize = true;
            this.label_totalsize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_totalsize.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_totalsize.ForeColor = System.Drawing.Color.Black;
            this.label_totalsize.Location = new System.Drawing.Point(97, 6);
            this.label_totalsize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_totalsize.Name = "label_totalsize";
            this.label_totalsize.Size = new System.Drawing.Size(117, 19);
            this.label_totalsize.TabIndex = 12;
            this.label_totalsize.Text = "0.00 Bytes           ";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Label12.ForeColor = System.Drawing.Color.DarkRed;
            this.Label12.Location = new System.Drawing.Point(4, 6);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(76, 19);
            this.Label12.TabIndex = 11;
            this.Label12.Text = "Total Size : ";
            // 
            // Label14
            // 
            this.Label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label14.AutoSize = true;
            this.Label14.BackColor = System.Drawing.Color.Transparent;
            this.Label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.Color.Gainsboro;
            this.Label14.Location = new System.Drawing.Point(912, 6);
            this.Label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(13, 19);
            this.Label14.TabIndex = 26;
            this.Label14.Text = ":";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(228, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Writen Size : ";
            // 
            // Label17
            // 
            this.Label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label17.AutoSize = true;
            this.Label17.BackColor = System.Drawing.Color.Transparent;
            this.Label17.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Label17.ForeColor = System.Drawing.Color.DarkRed;
            this.Label17.Location = new System.Drawing.Point(723, 6);
            this.Label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(42, 19);
            this.Label17.TabIndex = 27;
            this.Label17.Text = "RID : ";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1049, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 19);
            this.label6.TabIndex = 22;
            this.label6.Text = "Lite";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(1003, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 19);
            this.label7.TabIndex = 21;
            this.label7.Text = "QTY : ";
            // 
            // guna2GradientButtonSTOP
            // 
            this.guna2GradientButtonSTOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientButtonSTOP.Animated = true;
            this.guna2GradientButtonSTOP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2GradientButtonSTOP.BorderRadius = 4;
            this.guna2GradientButtonSTOP.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2GradientButtonSTOP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButtonSTOP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButtonSTOP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButtonSTOP.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButtonSTOP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButtonSTOP.FillColor = System.Drawing.Color.Red;
            this.guna2GradientButtonSTOP.FillColor2 = System.Drawing.Color.Gray;
            this.guna2GradientButtonSTOP.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.guna2GradientButtonSTOP.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButtonSTOP.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.guna2GradientButtonSTOP.HoverState.BorderColor = System.Drawing.Color.Red;
            this.guna2GradientButtonSTOP.HoverState.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2GradientButtonSTOP.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2GradientButtonSTOP.HoverState.FillColor2 = System.Drawing.Color.Red;
            this.guna2GradientButtonSTOP.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButtonSTOP.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2GradientButtonSTOP.ImageSize = new System.Drawing.Size(18, 18);
            this.guna2GradientButtonSTOP.IndicateFocus = true;
            this.guna2GradientButtonSTOP.Location = new System.Drawing.Point(1185, 637);
            this.guna2GradientButtonSTOP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guna2GradientButtonSTOP.Name = "guna2GradientButtonSTOP";
            this.guna2GradientButtonSTOP.Size = new System.Drawing.Size(101, 32);
            this.guna2GradientButtonSTOP.TabIndex = 275;
            this.guna2GradientButtonSTOP.Text = "      STOP";
            this.guna2GradientButtonSTOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2GradientButtonSTOP.Click += new System.EventHandler(this.guna2GradientButtonSTOP_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1313, 692);
            this.Controls.Add(this.Guna2GradientPanel3);
            this.Controls.Add(this.guna2GradientButtonSTOP);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cbsetboot);
            this.Controls.Add(this.ComboBox3);
            this.Controls.Add(this.cbreboot);
            this.Controls.Add(this.RichTextBox);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.MetroTabControl);
            this.Controls.Add(this.ProgressBar2);
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Opacity = 0.96D;
            this.Padding = new System.Windows.Forms.Padding(27, 69, 27, 23);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "iREVERSE Qualcomm Tool Lite - @HadiK IT - [ C# Version ]";
            ((System.ComponentModel.ISupportInitialize)(this.MetroStyleManager1)).EndInit();
            this.MetroTabControl.ResumeLayout(false);
            this.MetroTabPageFlashing.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPageQualcommFlash.ResumeLayout(false);
            this.metroTabPageQualcommFlash.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.MetroTabPageNetworking.ResumeLayout(false);
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.Guna2GroupBox1.ResumeLayout(false);
            this.Guna2GroupBox1.PerformLayout();
            this.Guna2GradientPanel3.ResumeLayout(false);
            this.Guna2GradientPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000011 RID: 17
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000012 RID: 18
		internal global::MetroFramework.Components.MetroStyleManager MetroStyleManager1;

		// Token: 0x04000013 RID: 19
		internal global::MetroFramework.Controls.MetroProgressBar ProgressBar2;

		// Token: 0x04000014 RID: 20
		internal global::MetroFramework.Controls.MetroTabControl MetroTabControl;

		// Token: 0x04000015 RID: 21
		internal global::MetroFramework.Controls.MetroTabPage MetroTabPageFlashing;

		// Token: 0x04000016 RID: 22
		internal global::MetroFramework.Controls.MetroProgressBar ProgressBar1;

		// Token: 0x04000017 RID: 23
		internal global::System.Windows.Forms.RichTextBox RichTextBox;

		// Token: 0x04000018 RID: 24
		internal global::System.Windows.Forms.Timer CariPortQcom;

		// Token: 0x04000019 RID: 25
		internal global::System.Windows.Forms.CheckBox cbsetboot;

		// Token: 0x0400001A RID: 26
		internal global::System.Windows.Forms.ComboBox ComboBox3;

		// Token: 0x0400001B RID: 27
		internal global::System.Windows.Forms.CheckBox cbreboot;

		// Token: 0x0400001C RID: 28
		internal global::System.Windows.Forms.Label Label1;

		// Token: 0x0400001D RID: 29
		internal global::MetroFramework.Controls.MetroTabPage MetroTabPageNetworking;

		// Token: 0x0400001F RID: 31
		internal global::Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;

		// Token: 0x04000020 RID: 32
		internal global::Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;

		// Token: 0x04000021 RID: 33
		internal global::Guna.UI2.WinForms.Guna2GradientButton Button_write_nv;

		// Token: 0x04000022 RID: 34
		internal global::Guna.UI2.WinForms.Guna2GradientButton Button_read_nv;

		// Token: 0x04000023 RID: 35
		internal global::System.Windows.Forms.CheckBox CheckBox7;

		// Token: 0x04000024 RID: 36
		internal global::System.Windows.Forms.Label LabelIMEI2;

		// Token: 0x04000025 RID: 37
		internal global::System.Windows.Forms.TextBox TextBox10;

		// Token: 0x04000026 RID: 38
		internal global::System.Windows.Forms.CheckBox CheckBox6;

		// Token: 0x04000027 RID: 39
		internal global::System.Windows.Forms.Label LabelIMEI1;

		// Token: 0x04000028 RID: 40
		internal global::System.Windows.Forms.TextBox TextBox9;

		// Token: 0x04000029 RID: 41
		internal global::Guna.UI2.WinForms.Guna2GroupBox Guna2GroupBox1;

		// Token: 0x0400002A RID: 42
		internal global::Guna.UI2.WinForms.Guna2GradientButton Button_write_qcn;

		// Token: 0x0400002B RID: 43
		internal global::Guna.UI2.WinForms.Guna2GradientButton Button_read_qcn;

		// Token: 0x0400002C RID: 44
		internal global::System.Windows.Forms.Label LabelQCN;

		// Token: 0x0400002D RID: 45
		internal global::System.Windows.Forms.TextBox TextBox8;

		// Token: 0x0400002E RID: 46
		private global::MetroFramework.Controls.MetroTabControl metroTabControl1;

		// Token: 0x0400002F RID: 47
		private global::MetroFramework.Controls.MetroTabPage metroTabPageQualcommFlash;

		// Token: 0x04000030 RID: 48
		internal global::Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;

		// Token: 0x04000031 RID: 49
		internal global::System.Windows.Forms.CheckBox CheckBoxAutoCleanAccount;

		// Token: 0x04000032 RID: 50
		internal global::System.Windows.Forms.CheckBox CheckBoxAutoCleanUserdata;

		// Token: 0x04000033 RID: 51
		internal global::Guna.UI2.WinForms.Guna2GradientButton btiden;

		// Token: 0x04000034 RID: 52
		internal global::Guna.UI2.WinForms.Guna2GradientButton BTNERASE;

		// Token: 0x04000035 RID: 53
		internal global::Guna.UI2.WinForms.Guna2GradientButton BTNREAD;

		// Token: 0x04000036 RID: 54
		internal global::Guna.UI2.WinForms.Guna2GradientButton BTNFLASH;

		// Token: 0x04000037 RID: 55
		internal global::System.Windows.Forms.CheckBox CheckBox3;

		// Token: 0x04000038 RID: 56
		internal global::MetroFramework.Controls.MetroGrid DataView;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn checkboxlist;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.DataGridViewTextBoxColumn label;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.DataGridViewTextBoxColumn filename;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.DataGridViewTextBoxColumn start_sector;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.DataGridViewTextBoxColumn num_partition_sectors;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.DataGridViewTextBoxColumn physical_partition_number;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.DataGridViewTextBoxColumn SECTOR_SIZE_IN_BYTES;

		// Token: 0x04000040 RID: 64
		internal global::Guna.UI2.WinForms.Guna2GradientPanel Guna2GradientPanel3;

		// Token: 0x04000041 RID: 65
		internal global::System.Windows.Forms.Label Label16;

		// Token: 0x04000042 RID: 66
		internal global::System.Windows.Forms.Label Label18;

		// Token: 0x04000043 RID: 67
		internal global::System.Windows.Forms.Label lbldate;

		// Token: 0x04000044 RID: 68
		internal global::System.Windows.Forms.Label Label4;

		// Token: 0x04000045 RID: 69
		internal global::System.Windows.Forms.Label label_writensize;

		// Token: 0x04000046 RID: 70
		internal global::System.Windows.Forms.Label lblhwid;

		// Token: 0x04000047 RID: 71
		internal global::System.Windows.Forms.Label label_totalsize;

		// Token: 0x04000048 RID: 72
		internal global::System.Windows.Forms.Label Label12;

		// Token: 0x04000049 RID: 73
		internal global::System.Windows.Forms.Label Label14;

		// Token: 0x0400004A RID: 74
		internal global::System.Windows.Forms.Label label5;

		// Token: 0x0400004B RID: 75
		internal global::System.Windows.Forms.Label Label17;

		// Token: 0x0400004C RID: 76
		internal global::System.Windows.Forms.Label label6;

		// Token: 0x0400004D RID: 77
		internal global::System.Windows.Forms.Label label7;

		// Token: 0x0400004E RID: 78
		internal global::System.Windows.Forms.Label label_transferrate;

		// Token: 0x0400004F RID: 79
		internal global::Guna.UI2.WinForms.Guna2ImageButton Guna2ImageButton_loader;

		// Token: 0x04000050 RID: 80
		internal global::Guna.UI2.WinForms.Guna2TextBox txtloader;

		// Token: 0x04000051 RID: 81
		internal global::Guna.UI2.WinForms.Guna2ImageButton Guna2ImageButton_xml;

		// Token: 0x04000052 RID: 82
		internal global::Guna.UI2.WinForms.Guna2TextBox txtrawxml;

		// Token: 0x04000053 RID: 83
		public global::System.Windows.Forms.ComboBox cbstorage;

		// Token: 0x04000054 RID: 84
		internal global::Guna.UI2.WinForms.Guna2GradientButton guna2GradientButtonSTOP;
	}
}
