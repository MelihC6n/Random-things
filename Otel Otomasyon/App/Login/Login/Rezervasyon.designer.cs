namespace Login
{
    partial class Rezervasyon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rezervasyon));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.ToggleSwitch.ToggleState toggleState4 = new Bunifu.ToggleSwitch.ToggleState();
            Bunifu.ToggleSwitch.ToggleState toggleState5 = new Bunifu.ToggleSwitch.ToggleState();
            Bunifu.ToggleSwitch.ToggleState toggleState6 = new Bunifu.ToggleSwitch.ToggleState();
            this.ara = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tc_noveyaad = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.radiotc = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.radioyabanci = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gel_tar = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.rapor = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uyruk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.gel_aralik = new Bunifu.ToggleSwitch.BunifuToggleSwitch();
            this.label7 = new System.Windows.Forms.Label();
            this.gel_tar2 = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.Rapor_Goster = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label6 = new System.Windows.Forms.Label();
            this.radio_hepsi = new Bunifu.UI.WinForms.BunifuRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rapor)).BeginInit();
            this.SuspendLayout();
            // 
            // ara
            // 
            this.ara.Image = ((System.Drawing.Image)(resources.GetObject("ara.Image")));
            this.ara.Location = new System.Drawing.Point(415, 30);
            this.ara.Name = "ara";
            this.ara.Size = new System.Drawing.Size(29, 25);
            this.ara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ara.TabIndex = 10;
            this.ara.TabStop = false;
            this.ara.Click += new System.EventHandler(this.Ara_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 20);
            this.label5.TabIndex = 8;
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
            this.tc_noveyaad.Location = new System.Drawing.Point(228, 24);
            this.tc_noveyaad.Margin = new System.Windows.Forms.Padding(4);
            this.tc_noveyaad.MaxLength = 32767;
            this.tc_noveyaad.Name = "tc_noveyaad";
            this.tc_noveyaad.Size = new System.Drawing.Size(180, 31);
            this.tc_noveyaad.TabIndex = 9;
            this.tc_noveyaad.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tc_noveyaad.OnValueChanged += new System.EventHandler(this.Tc_noveyaad_OnValueChanged);
            // 
            // radiotc
            // 
            this.radiotc.Checked = false;
            this.radiotc.Location = new System.Drawing.Point(201, 133);
            this.radiotc.Name = "radiotc";
            this.radiotc.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radiotc.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radiotc.Size = new System.Drawing.Size(20, 20);
            this.radiotc.TabIndex = 11;
            this.radiotc.Text = null;
            // 
            // radioyabanci
            // 
            this.radioyabanci.Checked = false;
            this.radioyabanci.Location = new System.Drawing.Point(310, 133);
            this.radioyabanci.Name = "radioyabanci";
            this.radioyabanci.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioyabanci.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioyabanci.Size = new System.Drawing.Size(20, 20);
            this.radioyabanci.TabIndex = 12;
            this.radioyabanci.Text = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Uyruğu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(83, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "T.C. Vatandaşı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(236, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Yabancı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Geliş Tarihi:";
            // 
            // gel_tar
            // 
            this.gel_tar.BorderRadius = 1;
            this.gel_tar.Color = System.Drawing.Color.Green;
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
            this.gel_tar.Location = new System.Drawing.Point(105, 83);
            this.gel_tar.MinimumSize = new System.Drawing.Size(225, 32);
            this.gel_tar.Name = "gel_tar";
            this.gel_tar.Size = new System.Drawing.Size(225, 32);
            this.gel_tar.TabIndex = 17;
            this.gel_tar.ValueChanged += new System.EventHandler(this.Gel_tar_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 19);
            this.label11.TabIndex = 101;
            this.label11.Text = "REZERVASYON\r\n";
            // 
            // rapor
            // 
            this.rapor.AllowUserToAddRows = false;
            this.rapor.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rapor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.rapor.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.rapor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rapor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rapor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            this.rapor.Location = new System.Drawing.Point(0, 216);
            this.rapor.Name = "rapor";
            this.rapor.ReadOnly = true;
            this.rapor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.rapor.RowHeadersWidth = 20;
            this.rapor.Size = new System.Drawing.Size(1040, 424);
            this.rapor.TabIndex = 102;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(615, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(207, 20);
            this.label9.TabIndex = 106;
            this.label9.Text = "Geliş Tarihinde Aralık Kullan:";
            // 
            // gel_aralik
            // 
            this.gel_aralik.Animation = 5;
            this.gel_aralik.BackColor = System.Drawing.Color.Transparent;
            this.gel_aralik.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gel_aralik.BackgroundImage")));
            this.gel_aralik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gel_aralik.Location = new System.Drawing.Point(828, 90);
            this.gel_aralik.Name = "gel_aralik";
            this.gel_aralik.Size = new System.Drawing.Size(35, 20);
            this.gel_aralik.TabIndex = 105;
            toggleState4.BackColor = System.Drawing.Color.Empty;
            toggleState4.BackColorInner = System.Drawing.Color.Empty;
            toggleState4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(0)))), ((int)(((byte)(140)))));
            toggleState4.BorderColorInner = System.Drawing.Color.Empty;
            toggleState4.BorderRadius = 1;
            toggleState4.BorderRadiusInner = 1;
            toggleState4.BorderThickness = 1;
            toggleState4.BorderThicknessInner = 1;
            this.gel_aralik.ToggleStateDisabled = toggleState4;
            toggleState5.BackColor = System.Drawing.Color.Empty;
            toggleState5.BackColorInner = System.Drawing.Color.Empty;
            toggleState5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            toggleState5.BorderColorInner = System.Drawing.Color.Empty;
            toggleState5.BorderRadius = 1;
            toggleState5.BorderRadiusInner = 1;
            toggleState5.BorderThickness = 1;
            toggleState5.BorderThicknessInner = 1;
            this.gel_aralik.ToggleStateOff = toggleState5;
            toggleState6.BackColor = System.Drawing.Color.Green;
            toggleState6.BackColorInner = System.Drawing.Color.White;
            toggleState6.BorderColor = System.Drawing.Color.Green;
            toggleState6.BorderColorInner = System.Drawing.Color.White;
            toggleState6.BorderRadius = 17;
            toggleState6.BorderRadiusInner = 15;
            toggleState6.BorderThickness = 1;
            toggleState6.BorderThicknessInner = 1;
            this.gel_aralik.ToggleStateOn = toggleState6;
            this.gel_aralik.Value = true;
            this.gel_aralik.OnValuechange += new System.EventHandler(this.Gel_aralik_OnValuechange);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(339, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 20);
            this.label7.TabIndex = 104;
            this.label7.Text = "İle";
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
            this.gel_tar2.Location = new System.Drawing.Point(372, 83);
            this.gel_tar2.MinimumSize = new System.Drawing.Size(225, 32);
            this.gel_tar2.Name = "gel_tar2";
            this.gel_tar2.Size = new System.Drawing.Size(225, 32);
            this.gel_tar2.TabIndex = 103;
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
            this.Rapor_Goster.Location = new System.Drawing.Point(458, 179);
            this.Rapor_Goster.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Rapor_Goster.Name = "Rapor_Goster";
            this.Rapor_Goster.Normalcolor = System.Drawing.Color.Silver;
            this.Rapor_Goster.OnHovercolor = System.Drawing.Color.Teal;
            this.Rapor_Goster.OnHoverTextColor = System.Drawing.Color.White;
            this.Rapor_Goster.selected = false;
            this.Rapor_Goster.Size = new System.Drawing.Size(139, 30);
            this.Rapor_Goster.TabIndex = 108;
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
            this.label6.Location = new System.Drawing.Point(350, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 111;
            this.label6.Text = "Hepsi";
            // 
            // radio_hepsi
            // 
            this.radio_hepsi.Checked = true;
            this.radio_hepsi.Location = new System.Drawing.Point(404, 133);
            this.radio_hepsi.Name = "radio_hepsi";
            this.radio_hepsi.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radio_hepsi.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radio_hepsi.Size = new System.Drawing.Size(20, 20);
            this.radio_hepsi.TabIndex = 110;
            this.radio_hepsi.Text = null;
            // 
            // Rezervasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radio_hepsi);
            this.Controls.Add(this.Rapor_Goster);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gel_aralik);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gel_tar2);
            this.Controls.Add(this.rapor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gel_tar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioyabanci);
            this.Controls.Add(this.radiotc);
            this.Controls.Add(this.ara);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tc_noveyaad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Rezervasyon";
            this.Text = "Resepsiyon";
            this.Load += new System.EventHandler(this.Rezervasyon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rapor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox ara;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuMaterialTextbox tc_noveyaad;
        private Bunifu.UI.WinForms.BunifuRadioButton radiotc;
        private Bunifu.UI.WinForms.BunifuRadioButton radioyabanci;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuDatePicker gel_tar;
        private System.Windows.Forms.Label label11;
        private Bunifu.Framework.UI.BunifuCustomDataGrid rapor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uyruk;
        private System.Windows.Forms.Label label9;
        private Bunifu.ToggleSwitch.BunifuToggleSwitch gel_aralik;
        private System.Windows.Forms.Label label7;
        private Bunifu.UI.WinForms.BunifuDatePicker gel_tar2;
        private Bunifu.Framework.UI.BunifuFlatButton Rapor_Goster;
        private System.Windows.Forms.Label label6;
        private Bunifu.UI.WinForms.BunifuRadioButton radio_hepsi;
    }
}