namespace Login
{
    partial class RezRapor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RezRapor));
            Bunifu.ToggleSwitch.ToggleState toggleState1 = new Bunifu.ToggleSwitch.ToggleState();
            Bunifu.ToggleSwitch.ToggleState toggleState2 = new Bunifu.ToggleSwitch.ToggleState();
            Bunifu.ToggleSwitch.ToggleState toggleState3 = new Bunifu.ToggleSwitch.ToggleState();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gel_tar = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tc_noveyaad = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.gel_tar2 = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.gel_aralik = new Bunifu.ToggleSwitch.BunifuToggleSwitch();
            this.label9 = new System.Windows.Forms.Label();
            this.Excel_Aktar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Yazdir = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label11 = new System.Windows.Forms.Label();
            this.rapor = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uyruk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radio_yabanci = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.radio_tc = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.Rapor_Goster = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label6 = new System.Windows.Forms.Label();
            this.radio_hepsi = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rapor)).BeginInit();
            this.SuspendLayout();
            // 
            // gel_tar
            // 
            this.gel_tar.BorderRadius = 1;
            this.gel_tar.Color = System.Drawing.Color.Green;
            this.gel_tar.CustomFormat = "";
            this.gel_tar.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.gel_tar.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.gel_tar.DisabledColor = System.Drawing.Color.Gray;
            this.gel_tar.DisplayWeekNumbers = false;
            this.gel_tar.DPHeight = 0;
            this.gel_tar.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.gel_tar.FillDatePicker = false;
            this.gel_tar.ForeColor = System.Drawing.Color.Green;
            this.gel_tar.Icon = ((System.Drawing.Image)(resources.GetObject("gel_tar.Icon")));
            this.gel_tar.IconColor = System.Drawing.Color.Green;
            this.gel_tar.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.gel_tar.Location = new System.Drawing.Point(105, 80);
            this.gel_tar.MinimumSize = new System.Drawing.Size(225, 32);
            this.gel_tar.Name = "gel_tar";
            this.gel_tar.Size = new System.Drawing.Size(225, 32);
            this.gel_tar.TabIndex = 28;
            this.gel_tar.ValueChanged += new System.EventHandler(this.Gel_tar_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Geliş Tarihi:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(415, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Misafir Adı veya TC No Girin:";
            // 
            // tc_noveyaad
            // 
            this.tc_noveyaad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tc_noveyaad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tc_noveyaad.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tc_noveyaad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tc_noveyaad.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.tc_noveyaad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tc_noveyaad.HintForeColor = System.Drawing.Color.Red;
            this.tc_noveyaad.HintText = "";
            this.tc_noveyaad.isPassword = false;
            this.tc_noveyaad.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tc_noveyaad.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tc_noveyaad.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tc_noveyaad.LineThickness = 3;
            this.tc_noveyaad.Location = new System.Drawing.Point(228, 34);
            this.tc_noveyaad.Margin = new System.Windows.Forms.Padding(4);
            this.tc_noveyaad.MaxLength = 32767;
            this.tc_noveyaad.Name = "tc_noveyaad";
            this.tc_noveyaad.Size = new System.Drawing.Size(180, 31);
            this.tc_noveyaad.TabIndex = 20;
            this.tc_noveyaad.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tc_noveyaad.OnValueChanged += new System.EventHandler(this.Tc_noveyaad_OnValueChanged);
            // 
            // gel_tar2
            // 
            this.gel_tar2.BorderRadius = 1;
            this.gel_tar2.Color = System.Drawing.Color.Green;
            this.gel_tar2.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.gel_tar2.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.gel_tar2.DisabledColor = System.Drawing.Color.Gray;
            this.gel_tar2.DisplayWeekNumbers = false;
            this.gel_tar2.DPHeight = 0;
            this.gel_tar2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.gel_tar2.FillDatePicker = false;
            this.gel_tar2.ForeColor = System.Drawing.Color.Green;
            this.gel_tar2.Icon = ((System.Drawing.Image)(resources.GetObject("gel_tar2.Icon")));
            this.gel_tar2.IconColor = System.Drawing.Color.Green;
            this.gel_tar2.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.gel_tar2.Location = new System.Drawing.Point(369, 80);
            this.gel_tar2.MinimumSize = new System.Drawing.Size(225, 32);
            this.gel_tar2.Name = "gel_tar2";
            this.gel_tar2.Size = new System.Drawing.Size(225, 32);
            this.gel_tar2.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(336, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "İle";
            // 
            // gel_aralik
            // 
            this.gel_aralik.Animation = 5;
            this.gel_aralik.BackColor = System.Drawing.Color.Transparent;
            this.gel_aralik.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gel_aralik.BackgroundImage")));
            this.gel_aralik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gel_aralik.Location = new System.Drawing.Point(825, 87);
            this.gel_aralik.Name = "gel_aralik";
            this.gel_aralik.Size = new System.Drawing.Size(35, 20);
            this.gel_aralik.TabIndex = 35;
            toggleState1.BackColor = System.Drawing.Color.Empty;
            toggleState1.BackColorInner = System.Drawing.Color.Empty;
            toggleState1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(0)))), ((int)(((byte)(140)))));
            toggleState1.BorderColorInner = System.Drawing.Color.Empty;
            toggleState1.BorderRadius = 1;
            toggleState1.BorderRadiusInner = 1;
            toggleState1.BorderThickness = 1;
            toggleState1.BorderThicknessInner = 1;
            this.gel_aralik.ToggleStateDisabled = toggleState1;
            toggleState2.BackColor = System.Drawing.Color.Empty;
            toggleState2.BackColorInner = System.Drawing.Color.Empty;
            toggleState2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            toggleState2.BorderColorInner = System.Drawing.Color.Empty;
            toggleState2.BorderRadius = 1;
            toggleState2.BorderRadiusInner = 1;
            toggleState2.BorderThickness = 1;
            toggleState2.BorderThicknessInner = 1;
            this.gel_aralik.ToggleStateOff = toggleState2;
            toggleState3.BackColor = System.Drawing.Color.Green;
            toggleState3.BackColorInner = System.Drawing.Color.White;
            toggleState3.BorderColor = System.Drawing.Color.Green;
            toggleState3.BorderColorInner = System.Drawing.Color.White;
            toggleState3.BorderRadius = 17;
            toggleState3.BorderRadiusInner = 15;
            toggleState3.BorderThickness = 1;
            toggleState3.BorderThicknessInner = 1;
            this.gel_aralik.ToggleStateOn = toggleState3;
            this.gel_aralik.Value = true;
            this.gel_aralik.OnValuechange += new System.EventHandler(this.bunifuToggleSwitch1_OnValuechange);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(612, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(207, 20);
            this.label9.TabIndex = 36;
            this.label9.Text = "Geliş Tarihinde Aralık Kullan:";
            // 
            // Excel_Aktar
            // 
            this.Excel_Aktar.Active = false;
            this.Excel_Aktar.Activecolor = System.Drawing.Color.Transparent;
            this.Excel_Aktar.BackColor = System.Drawing.Color.Silver;
            this.Excel_Aktar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Excel_Aktar.BorderRadius = 0;
            this.Excel_Aktar.ButtonText = "Raporu Excel\'e Aktar";
            this.Excel_Aktar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Excel_Aktar.DisabledColor = System.Drawing.Color.DarkGray;
            this.Excel_Aktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Excel_Aktar.Iconcolor = System.Drawing.Color.Transparent;
            this.Excel_Aktar.Iconimage = ((System.Drawing.Image)(resources.GetObject("Excel_Aktar.Iconimage")));
            this.Excel_Aktar.Iconimage_right = null;
            this.Excel_Aktar.Iconimage_right_Selected = null;
            this.Excel_Aktar.Iconimage_Selected = null;
            this.Excel_Aktar.IconMarginLeft = 0;
            this.Excel_Aktar.IconMarginRight = 0;
            this.Excel_Aktar.IconRightVisible = true;
            this.Excel_Aktar.IconRightZoom = 0D;
            this.Excel_Aktar.IconVisible = true;
            this.Excel_Aktar.IconZoom = 70D;
            this.Excel_Aktar.IsTab = false;
            this.Excel_Aktar.Location = new System.Drawing.Point(896, 13);
            this.Excel_Aktar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Excel_Aktar.Name = "Excel_Aktar";
            this.Excel_Aktar.Normalcolor = System.Drawing.Color.Silver;
            this.Excel_Aktar.OnHovercolor = System.Drawing.Color.Green;
            this.Excel_Aktar.OnHoverTextColor = System.Drawing.Color.White;
            this.Excel_Aktar.selected = false;
            this.Excel_Aktar.Size = new System.Drawing.Size(144, 38);
            this.Excel_Aktar.TabIndex = 98;
            this.Excel_Aktar.Text = "Raporu Excel\'e Aktar";
            this.Excel_Aktar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Excel_Aktar.Textcolor = System.Drawing.Color.Black;
            this.Excel_Aktar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Excel_Aktar.Click += new System.EventHandler(this.Excel_Aktar_Click);
            // 
            // Yazdir
            // 
            this.Yazdir.Active = false;
            this.Yazdir.Activecolor = System.Drawing.Color.LightSeaGreen;
            this.Yazdir.BackColor = System.Drawing.Color.Silver;
            this.Yazdir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Yazdir.BorderRadius = 0;
            this.Yazdir.ButtonText = "Raporu Yazdır";
            this.Yazdir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Yazdir.DisabledColor = System.Drawing.Color.DarkGray;
            this.Yazdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Yazdir.Iconcolor = System.Drawing.Color.Transparent;
            this.Yazdir.Iconimage = ((System.Drawing.Image)(resources.GetObject("Yazdir.Iconimage")));
            this.Yazdir.Iconimage_right = null;
            this.Yazdir.Iconimage_right_Selected = null;
            this.Yazdir.Iconimage_Selected = null;
            this.Yazdir.IconMarginLeft = 0;
            this.Yazdir.IconMarginRight = 0;
            this.Yazdir.IconRightVisible = true;
            this.Yazdir.IconRightZoom = 0D;
            this.Yazdir.IconVisible = true;
            this.Yazdir.IconZoom = 70D;
            this.Yazdir.IsTab = false;
            this.Yazdir.Location = new System.Drawing.Point(896, 59);
            this.Yazdir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Yazdir.Name = "Yazdir";
            this.Yazdir.Normalcolor = System.Drawing.Color.Silver;
            this.Yazdir.OnHovercolor = System.Drawing.Color.LightSeaGreen;
            this.Yazdir.OnHoverTextColor = System.Drawing.Color.White;
            this.Yazdir.selected = false;
            this.Yazdir.Size = new System.Drawing.Size(144, 38);
            this.Yazdir.TabIndex = 99;
            this.Yazdir.Text = "Raporu Yazdır";
            this.Yazdir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Yazdir.Textcolor = System.Drawing.Color.Black;
            this.Yazdir.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Yazdir.Click += new System.EventHandler(this.Yazdir_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(13, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(205, 19);
            this.label11.TabIndex = 100;
            this.label11.Text = "REZERVASYON RAPORLARI";
            // 
            // rapor
            // 
            this.rapor.AllowUserToAddRows = false;
            this.rapor.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rapor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.rapor.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.rapor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rapor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rapor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.rapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rapor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Uyruk});
            this.rapor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rapor.DoubleBuffered = true;
            this.rapor.EnableHeadersVisualStyles = false;
            this.rapor.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.rapor.HeaderForeColor = System.Drawing.Color.White;
            this.rapor.Location = new System.Drawing.Point(0, 190);
            this.rapor.Name = "rapor";
            this.rapor.ReadOnly = true;
            this.rapor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.rapor.RowHeadersWidth = 20;
            this.rapor.Size = new System.Drawing.Size(1040, 450);
            this.rapor.TabIndex = 101;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 200F;
            this.Column1.HeaderText = "Kimlik Numarası";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 200F;
            this.Column2.HeaderText = "Gelis Tarihi";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 220F;
            this.Column3.HeaderText = "Adı";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 220;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 220F;
            this.Column4.HeaderText = "Soyadı";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 220;
            // 
            // Uyruk
            // 
            this.Uyruk.FillWeight = 190F;
            this.Uyruk.HeaderText = "Uyruğu";
            this.Uyruk.Name = "Uyruk";
            this.Uyruk.ReadOnly = true;
            this.Uyruk.Width = 190;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(237, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 106;
            this.label3.Text = "Yabancı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(84, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 105;
            this.label2.Text = "T.C. Vatandaşı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 104;
            this.label1.Text = "Uyruğu:";
            // 
            // radio_yabanci
            // 
            this.radio_yabanci.Checked = false;
            this.radio_yabanci.Location = new System.Drawing.Point(311, 129);
            this.radio_yabanci.Name = "radio_yabanci";
            this.radio_yabanci.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radio_yabanci.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radio_yabanci.Size = new System.Drawing.Size(20, 20);
            this.radio_yabanci.TabIndex = 103;
            this.radio_yabanci.Text = null;
            // 
            // radio_tc
            // 
            this.radio_tc.Checked = true;
            this.radio_tc.Location = new System.Drawing.Point(202, 129);
            this.radio_tc.Name = "radio_tc";
            this.radio_tc.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radio_tc.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radio_tc.Size = new System.Drawing.Size(20, 20);
            this.radio_tc.TabIndex = 102;
            this.radio_tc.Text = null;
            this.radio_tc.Click += new System.EventHandler(this.radio_tc_Click);
            // 
            // Rapor_Goster
            // 
            this.Rapor_Goster.Active = false;
            this.Rapor_Goster.Activecolor = System.Drawing.Color.Teal;
            this.Rapor_Goster.BackColor = System.Drawing.Color.Silver;
            this.Rapor_Goster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Rapor_Goster.BorderRadius = 0;
            this.Rapor_Goster.ButtonText = "Göster";
            this.Rapor_Goster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rapor_Goster.DisabledColor = System.Drawing.Color.DarkGray;
            this.Rapor_Goster.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Rapor_Goster.Iconcolor = System.Drawing.Color.Transparent;
            this.Rapor_Goster.Iconimage = null;
            this.Rapor_Goster.Iconimage_right = null;
            this.Rapor_Goster.Iconimage_right_Selected = null;
            this.Rapor_Goster.Iconimage_Selected = null;
            this.Rapor_Goster.IconMarginLeft = 0;
            this.Rapor_Goster.IconMarginRight = 0;
            this.Rapor_Goster.IconRightVisible = true;
            this.Rapor_Goster.IconRightZoom = 0D;
            this.Rapor_Goster.IconVisible = true;
            this.Rapor_Goster.IconZoom = 60D;
            this.Rapor_Goster.IsTab = false;
            this.Rapor_Goster.Location = new System.Drawing.Point(721, 153);
            this.Rapor_Goster.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Rapor_Goster.Name = "Rapor_Goster";
            this.Rapor_Goster.Normalcolor = System.Drawing.Color.Silver;
            this.Rapor_Goster.OnHovercolor = System.Drawing.Color.Teal;
            this.Rapor_Goster.OnHoverTextColor = System.Drawing.Color.White;
            this.Rapor_Goster.selected = false;
            this.Rapor_Goster.Size = new System.Drawing.Size(139, 30);
            this.Rapor_Goster.TabIndex = 107;
            this.Rapor_Goster.Text = "Göster";
            this.Rapor_Goster.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Rapor_Goster.Textcolor = System.Drawing.Color.Black;
            this.Rapor_Goster.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Rapor_Goster.Click += new System.EventHandler(this.Rapor_Goster_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(340, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 109;
            this.label6.Text = "Hepsi";
            // 
            // radio_hepsi
            // 
            this.radio_hepsi.Checked = false;
            this.radio_hepsi.Location = new System.Drawing.Point(394, 129);
            this.radio_hepsi.Name = "radio_hepsi";
            this.radio_hepsi.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radio_hepsi.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radio_hepsi.Size = new System.Drawing.Size(20, 20);
            this.radio_hepsi.TabIndex = 108;
            this.radio_hepsi.Text = null;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.PrintDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1_PrintPage);
            // 
            // RezRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radio_hepsi);
            this.Controls.Add(this.Rapor_Goster);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radio_yabanci);
            this.Controls.Add(this.radio_tc);
            this.Controls.Add(this.rapor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Yazdir);
            this.Controls.Add(this.Excel_Aktar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gel_aralik);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gel_tar2);
            this.Controls.Add(this.gel_tar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tc_noveyaad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RezRapor";
            this.Text = "RezRapor";
            this.Load += new System.EventHandler(this.RezRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rapor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuDatePicker gel_tar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuMaterialTextbox tc_noveyaad;
        private Bunifu.UI.WinForms.BunifuDatePicker gel_tar2;
        private System.Windows.Forms.Label label7;
        private Bunifu.ToggleSwitch.BunifuToggleSwitch gel_aralik;
        private System.Windows.Forms.Label label9;
        private Bunifu.Framework.UI.BunifuFlatButton Excel_Aktar;
        private Bunifu.Framework.UI.BunifuFlatButton Yazdir;
        private System.Windows.Forms.Label label11;
        private Bunifu.Framework.UI.BunifuCustomDataGrid rapor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuRadioButton radio_yabanci;
        private Bunifu.UI.WinForms.BunifuRadioButton radio_tc;
        private Bunifu.Framework.UI.BunifuFlatButton Rapor_Goster;
        private System.Windows.Forms.Label label6;
        private Bunifu.UI.WinForms.BunifuRadioButton radio_hepsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uyruk;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}