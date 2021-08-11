namespace Login
{
    partial class Istatistikler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Istatistikler));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            Bunifu.ToggleSwitch.ToggleState toggleState13 = new Bunifu.ToggleSwitch.ToggleState();
            Bunifu.ToggleSwitch.ToggleState toggleState14 = new Bunifu.ToggleSwitch.ToggleState();
            Bunifu.ToggleSwitch.ToggleState toggleState15 = new Bunifu.ToggleSwitch.ToggleState();
            this.PanelOdaSayi = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.DoluOda = new System.Windows.Forms.Label();
            this.DateMevcut = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.PanelRezervasyon = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.RezSayi = new System.Windows.Forms.Label();
            this.PanelCiro = new System.Windows.Forms.Panel();
            this.Ciro = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.PanelMisafir = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Misafirler = new System.Windows.Forms.Label();
            this.PanelUrun = new System.Windows.Forms.Panel();
            this.UrunGelir = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.PanelKonaklama = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.KonaklamaGelir = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DateKarsi = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bunifuToggleSwitch1 = new Bunifu.ToggleSwitch.BunifuToggleSwitch();
            this.label15 = new System.Windows.Forms.Label();
            this.RadioAy = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.RadioYil = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.RadioGun = new Bunifu.UI.WinForms.BunifuRadioButton();
            this.PanelOdaSayi.SuspendLayout();
            this.PanelRezervasyon.SuspendLayout();
            this.PanelCiro.SuspendLayout();
            this.PanelMisafir.SuspendLayout();
            this.PanelUrun.SuspendLayout();
            this.PanelKonaklama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelOdaSayi
            // 
            this.PanelOdaSayi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(111)))), ((int)(((byte)(249)))));
            this.PanelOdaSayi.Controls.Add(this.label3);
            this.PanelOdaSayi.Controls.Add(this.DoluOda);
            this.PanelOdaSayi.Location = new System.Drawing.Point(12, 12);
            this.PanelOdaSayi.Name = "PanelOdaSayi";
            this.PanelOdaSayi.Size = new System.Drawing.Size(238, 85);
            this.PanelOdaSayi.TabIndex = 4;
            this.PanelOdaSayi.Click += new System.EventHandler(this.PanelOdaSayi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Dolu Oda Sayısı";
            this.label3.Click += new System.EventHandler(this.PanelOdaSayi_Click);
            // 
            // DoluOda
            // 
            this.DoluOda.AutoSize = true;
            this.DoluOda.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DoluOda.ForeColor = System.Drawing.Color.White;
            this.DoluOda.Location = new System.Drawing.Point(178, 24);
            this.DoluOda.Name = "DoluOda";
            this.DoluOda.Size = new System.Drawing.Size(60, 33);
            this.DoluOda.TabIndex = 0;
            this.DoluOda.Text = "240";
            this.DoluOda.Click += new System.EventHandler(this.PanelOdaSayi_Click);
            // 
            // DateMevcut
            // 
            this.DateMevcut.BorderRadius = 1;
            this.DateMevcut.Color = System.Drawing.Color.Magenta;
            this.DateMevcut.CustomFormat = "yyyy-MM-dd";
            this.DateMevcut.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.DateMevcut.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.DateMevcut.DisabledColor = System.Drawing.Color.Gray;
            this.DateMevcut.DisplayWeekNumbers = false;
            this.DateMevcut.DPHeight = 0;
            this.DateMevcut.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DateMevcut.FillDatePicker = false;
            this.DateMevcut.ForeColor = System.Drawing.Color.Magenta;
            this.DateMevcut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateMevcut.Icon = ((System.Drawing.Image)(resources.GetObject("DateMevcut.Icon")));
            this.DateMevcut.IconColor = System.Drawing.Color.Magenta;
            this.DateMevcut.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.DateMevcut.Location = new System.Drawing.Point(789, 114);
            this.DateMevcut.MinimumSize = new System.Drawing.Size(238, 32);
            this.DateMevcut.Name = "DateMevcut";
            this.DateMevcut.Size = new System.Drawing.Size(238, 32);
            this.DateMevcut.TabIndex = 10;
            this.DateMevcut.ValueChanged += new System.EventHandler(this.DateMevcut_ValueChanged);
            // 
            // PanelRezervasyon
            // 
            this.PanelRezervasyon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(111)))), ((int)(((byte)(249)))));
            this.PanelRezervasyon.Controls.Add(this.label1);
            this.PanelRezervasyon.Controls.Add(this.label22);
            this.PanelRezervasyon.Controls.Add(this.label23);
            this.PanelRezervasyon.Controls.Add(this.RezSayi);
            this.PanelRezervasyon.Location = new System.Drawing.Point(271, 12);
            this.PanelRezervasyon.Name = "PanelRezervasyon";
            this.PanelRezervasyon.Size = new System.Drawing.Size(238, 85);
            this.PanelRezervasyon.TabIndex = 11;
            this.PanelRezervasyon.Click += new System.EventHandler(this.PanelRezervasyon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rezervasyon";
            this.label1.Click += new System.EventHandler(this.PanelRezervasyon_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(3, 45);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 21);
            this.label22.TabIndex = 5;
            this.label22.Text = "Sayısı";
            this.label22.Click += new System.EventHandler(this.PanelRezervasyon_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(3, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(107, 21);
            this.label23.TabIndex = 7;
            this.label23.Text = "Bugün Çıkış";
            // 
            // RezSayi
            // 
            this.RezSayi.AutoSize = true;
            this.RezSayi.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RezSayi.ForeColor = System.Drawing.Color.White;
            this.RezSayi.Location = new System.Drawing.Point(175, 25);
            this.RezSayi.Name = "RezSayi";
            this.RezSayi.Size = new System.Drawing.Size(60, 33);
            this.RezSayi.TabIndex = 0;
            this.RezSayi.Text = "240";
            this.RezSayi.Click += new System.EventHandler(this.PanelRezervasyon_Click);
            // 
            // PanelCiro
            // 
            this.PanelCiro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(111)))), ((int)(((byte)(249)))));
            this.PanelCiro.Controls.Add(this.Ciro);
            this.PanelCiro.Controls.Add(this.label19);
            this.PanelCiro.Location = new System.Drawing.Point(530, 12);
            this.PanelCiro.Name = "PanelCiro";
            this.PanelCiro.Size = new System.Drawing.Size(238, 85);
            this.PanelCiro.TabIndex = 12;
            this.PanelCiro.Click += new System.EventHandler(this.PanelCiro_Click);
            // 
            // Ciro
            // 
            this.Ciro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(111)))), ((int)(((byte)(249)))));
            this.Ciro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ciro.Font = new System.Drawing.Font("Century Gothic", 20.25F);
            this.Ciro.ForeColor = System.Drawing.Color.White;
            this.Ciro.Location = new System.Drawing.Point(138, 25);
            this.Ciro.Name = "Ciro";
            this.Ciro.ReadOnly = true;
            this.Ciro.Size = new System.Drawing.Size(100, 34);
            this.Ciro.TabIndex = 133;
            this.Ciro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Ciro.Click += new System.EventHandler(this.PanelCiro_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(3, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 21);
            this.label19.TabIndex = 2;
            this.label19.Text = "Ciro";
            this.label19.Click += new System.EventHandler(this.PanelCiro_Click);
            // 
            // PanelMisafir
            // 
            this.PanelMisafir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(111)))), ((int)(((byte)(249)))));
            this.PanelMisafir.Controls.Add(this.label2);
            this.PanelMisafir.Controls.Add(this.label20);
            this.PanelMisafir.Controls.Add(this.label7);
            this.PanelMisafir.Controls.Add(this.Misafirler);
            this.PanelMisafir.Location = new System.Drawing.Point(789, 12);
            this.PanelMisafir.Name = "PanelMisafir";
            this.PanelMisafir.Size = new System.Drawing.Size(238, 85);
            this.PanelMisafir.TabIndex = 5;
            this.PanelMisafir.Click += new System.EventHandler(this.PanelMisafir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(141, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Türk/Yabancı";
            this.label2.Click += new System.EventHandler(this.PanelMisafir_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(3, 35);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 21);
            this.label20.TabIndex = 4;
            this.label20.Text = "Misafirler";
            this.label20.Click += new System.EventHandler(this.PanelMisafir_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 21);
            this.label7.TabIndex = 1;
            // 
            // Misafirler
            // 
            this.Misafirler.AutoSize = true;
            this.Misafirler.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Misafirler.ForeColor = System.Drawing.Color.White;
            this.Misafirler.Location = new System.Drawing.Point(175, 25);
            this.Misafirler.Name = "Misafirler";
            this.Misafirler.Size = new System.Drawing.Size(60, 33);
            this.Misafirler.TabIndex = 0;
            this.Misafirler.Text = "240";
            this.Misafirler.Click += new System.EventHandler(this.PanelMisafir_Click);
            // 
            // PanelUrun
            // 
            this.PanelUrun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(111)))), ((int)(((byte)(249)))));
            this.PanelUrun.Controls.Add(this.UrunGelir);
            this.PanelUrun.Controls.Add(this.label11);
            this.PanelUrun.Location = new System.Drawing.Point(271, 114);
            this.PanelUrun.Name = "PanelUrun";
            this.PanelUrun.Size = new System.Drawing.Size(238, 85);
            this.PanelUrun.TabIndex = 14;
            this.PanelUrun.Click += new System.EventHandler(this.PanelUrun_Click);
            // 
            // UrunGelir
            // 
            this.UrunGelir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(111)))), ((int)(((byte)(249)))));
            this.UrunGelir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UrunGelir.Font = new System.Drawing.Font("Century Gothic", 20.25F);
            this.UrunGelir.ForeColor = System.Drawing.Color.White;
            this.UrunGelir.Location = new System.Drawing.Point(135, 24);
            this.UrunGelir.Name = "UrunGelir";
            this.UrunGelir.ReadOnly = true;
            this.UrunGelir.Size = new System.Drawing.Size(100, 34);
            this.UrunGelir.TabIndex = 2;
            this.UrunGelir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UrunGelir.Click += new System.EventHandler(this.PanelUrun_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(3, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "Ürün Geliri";
            this.label11.Click += new System.EventHandler(this.PanelUrun_Click);
            // 
            // PanelKonaklama
            // 
            this.PanelKonaklama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(111)))), ((int)(((byte)(249)))));
            this.PanelKonaklama.Controls.Add(this.label4);
            this.PanelKonaklama.Controls.Add(this.label5);
            this.PanelKonaklama.Controls.Add(this.KonaklamaGelir);
            this.PanelKonaklama.Location = new System.Drawing.Point(12, 114);
            this.PanelKonaklama.Name = "PanelKonaklama";
            this.PanelKonaklama.Size = new System.Drawing.Size(238, 85);
            this.PanelKonaklama.TabIndex = 13;
            this.PanelKonaklama.Click += new System.EventHandler(this.PanelKonaklama_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 21);
            this.label4.TabIndex = 135;
            this.label4.Text = "Konaklama";
            this.label4.Click += new System.EventHandler(this.PanelKonaklama_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 134;
            this.label5.Text = "Geliri";
            this.label5.Click += new System.EventHandler(this.PanelKonaklama_Click);
            // 
            // KonaklamaGelir
            // 
            this.KonaklamaGelir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(111)))), ((int)(((byte)(249)))));
            this.KonaklamaGelir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KonaklamaGelir.Font = new System.Drawing.Font("Century Gothic", 20.25F);
            this.KonaklamaGelir.ForeColor = System.Drawing.Color.White;
            this.KonaklamaGelir.Location = new System.Drawing.Point(138, 24);
            this.KonaklamaGelir.Name = "KonaklamaGelir";
            this.KonaklamaGelir.ReadOnly = true;
            this.KonaklamaGelir.Size = new System.Drawing.Size(100, 34);
            this.KonaklamaGelir.TabIndex = 133;
            this.KonaklamaGelir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.KonaklamaGelir.Click += new System.EventHandler(this.PanelKonaklama_Click);
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(12, 205);
            this.chart1.Name = "chart1";
            series5.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series5.BorderColor = System.Drawing.Color.DodgerBlue;
            series5.ChartArea = "ChartArea1";
            series5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(1)), true);
            series5.LabelBackColor = System.Drawing.Color.White;
            series5.LabelBorderColor = System.Drawing.Color.White;
            series5.LabelBorderWidth = 2;
            series5.LabelForeColor = System.Drawing.Color.Magenta;
            series5.Legend = "Legend1";
            series5.Name = "Grafik";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(911, 332);
            this.chart1.TabIndex = 16;
            this.chart1.Text = "chart1";
            // 
            // DateKarsi
            // 
            this.DateKarsi.BorderRadius = 1;
            this.DateKarsi.Color = System.Drawing.Color.Magenta;
            this.DateKarsi.CustomFormat = "yyyy-MM-dd";
            this.DateKarsi.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thick;
            this.DateKarsi.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.DateKarsi.DisabledColor = System.Drawing.Color.Gray;
            this.DateKarsi.DisplayWeekNumbers = false;
            this.DateKarsi.DPHeight = 0;
            this.DateKarsi.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DateKarsi.FillDatePicker = false;
            this.DateKarsi.ForeColor = System.Drawing.Color.Magenta;
            this.DateKarsi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateKarsi.Icon = ((System.Drawing.Image)(resources.GetObject("DateKarsi.Icon")));
            this.DateKarsi.IconColor = System.Drawing.Color.Magenta;
            this.DateKarsi.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.DateKarsi.Location = new System.Drawing.Point(790, 167);
            this.DateKarsi.MinimumSize = new System.Drawing.Size(238, 32);
            this.DateKarsi.Name = "DateKarsi";
            this.DateKarsi.Size = new System.Drawing.Size(238, 32);
            this.DateKarsi.TabIndex = 17;
            this.DateKarsi.ValueChanged += new System.EventHandler(this.DateKarsi_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(658, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 20);
            this.label9.TabIndex = 104;
            this.label9.Text = "Mevcut Tarih : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(606, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 20);
            this.label10.TabIndex = 105;
            this.label10.Text = "Karşılaştırılacak Tarih :";
            // 
            // bunifuToggleSwitch1
            // 
            this.bunifuToggleSwitch1.Animation = 5;
            this.bunifuToggleSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuToggleSwitch1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuToggleSwitch1.BackgroundImage")));
            this.bunifuToggleSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuToggleSwitch1.Location = new System.Drawing.Point(565, 174);
            this.bunifuToggleSwitch1.Name = "bunifuToggleSwitch1";
            this.bunifuToggleSwitch1.Size = new System.Drawing.Size(35, 20);
            this.bunifuToggleSwitch1.TabIndex = 123;
            toggleState13.BackColor = System.Drawing.Color.Empty;
            toggleState13.BackColorInner = System.Drawing.Color.Empty;
            toggleState13.BorderColor = System.Drawing.Color.Empty;
            toggleState13.BorderColorInner = System.Drawing.Color.Empty;
            toggleState13.BorderRadius = 1;
            toggleState13.BorderRadiusInner = 1;
            toggleState13.BorderThickness = 1;
            toggleState13.BorderThicknessInner = 1;
            this.bunifuToggleSwitch1.ToggleStateDisabled = toggleState13;
            toggleState14.BackColor = System.Drawing.Color.Gray;
            toggleState14.BackColorInner = System.Drawing.Color.White;
            toggleState14.BorderColor = System.Drawing.Color.Gray;
            toggleState14.BorderColorInner = System.Drawing.Color.White;
            toggleState14.BorderRadius = 17;
            toggleState14.BorderRadiusInner = 15;
            toggleState14.BorderThickness = 1;
            toggleState14.BorderThicknessInner = 1;
            this.bunifuToggleSwitch1.ToggleStateOff = toggleState14;
            toggleState15.BackColor = System.Drawing.Color.Magenta;
            toggleState15.BackColorInner = System.Drawing.Color.White;
            toggleState15.BorderColor = System.Drawing.Color.Magenta;
            toggleState15.BorderColorInner = System.Drawing.Color.White;
            toggleState15.BorderRadius = 17;
            toggleState15.BorderRadiusInner = 15;
            toggleState15.BorderThickness = 1;
            toggleState15.BorderThicknessInner = 1;
            this.bunifuToggleSwitch1.ToggleStateOn = toggleState15;
            this.bunifuToggleSwitch1.Value = true;
            this.bunifuToggleSwitch1.OnValuechange += new System.EventHandler(this.bunifuToggleSwitch1_OnValuechange);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(175, 556);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 20);
            this.label15.TabIndex = 124;
            this.label15.Text = "Günlük : ";
            // 
            // RadioAy
            // 
            this.RadioAy.Checked = false;
            this.RadioAy.Location = new System.Drawing.Point(380, 556);
            this.RadioAy.Name = "RadioAy";
            this.RadioAy.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.RadioAy.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.RadioAy.Size = new System.Drawing.Size(23, 23);
            this.RadioAy.TabIndex = 129;
            this.RadioAy.Text = null;
            this.RadioAy.Click += new System.EventHandler(this.RadioAy_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.Location = new System.Drawing.Point(320, 556);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 20);
            this.label16.TabIndex = 128;
            this.label16.Text = "Aylık : ";
            // 
            // RadioYil
            // 
            this.RadioYil.Checked = false;
            this.RadioYil.Location = new System.Drawing.Point(497, 556);
            this.RadioYil.Name = "RadioYil";
            this.RadioYil.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.RadioYil.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.RadioYil.Size = new System.Drawing.Size(23, 23);
            this.RadioYil.TabIndex = 131;
            this.RadioYil.Text = null;
            this.RadioYil.Click += new System.EventHandler(this.RadioYil_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.Location = new System.Drawing.Point(447, 556);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 20);
            this.label17.TabIndex = 130;
            this.label17.Text = "Yıllık :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.Location = new System.Drawing.Point(12, 556);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(103, 20);
            this.label18.TabIndex = 132;
            this.label18.Text = "Tarih Biçimi = ";
            // 
            // RadioGun
            // 
            this.RadioGun.Checked = true;
            this.RadioGun.Location = new System.Drawing.Point(253, 556);
            this.RadioGun.Name = "RadioGun";
            this.RadioGun.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.RadioGun.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.RadioGun.Size = new System.Drawing.Size(23, 23);
            this.RadioGun.TabIndex = 127;
            this.RadioGun.Text = null;
            this.RadioGun.Click += new System.EventHandler(this.RadioGun_Click);
            // 
            // Istatistikler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.RadioYil);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.RadioAy);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.RadioGun);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.bunifuToggleSwitch1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DateKarsi);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.PanelUrun);
            this.Controls.Add(this.PanelKonaklama);
            this.Controls.Add(this.PanelMisafir);
            this.Controls.Add(this.PanelCiro);
            this.Controls.Add(this.PanelRezervasyon);
            this.Controls.Add(this.DateMevcut);
            this.Controls.Add(this.PanelOdaSayi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Istatistikler";
            this.Text = "Raporlar";
            this.Load += new System.EventHandler(this.Istatistikler_Load);
            this.PanelOdaSayi.ResumeLayout(false);
            this.PanelOdaSayi.PerformLayout();
            this.PanelRezervasyon.ResumeLayout(false);
            this.PanelRezervasyon.PerformLayout();
            this.PanelCiro.ResumeLayout(false);
            this.PanelCiro.PerformLayout();
            this.PanelMisafir.ResumeLayout(false);
            this.PanelMisafir.PerformLayout();
            this.PanelUrun.ResumeLayout(false);
            this.PanelUrun.PerformLayout();
            this.PanelKonaklama.ResumeLayout(false);
            this.PanelKonaklama.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelOdaSayi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DoluOda;
        private Bunifu.UI.WinForms.BunifuDatePicker DateMevcut;
        private System.Windows.Forms.Panel PanelRezervasyon;
        private System.Windows.Forms.Label RezSayi;
        private System.Windows.Forms.Panel PanelCiro;
        private System.Windows.Forms.Panel PanelMisafir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Misafirler;
        private System.Windows.Forms.Panel PanelUrun;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel PanelKonaklama;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Bunifu.UI.WinForms.BunifuDatePicker DateKarsi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Bunifu.ToggleSwitch.BunifuToggleSwitch bunifuToggleSwitch1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private Bunifu.UI.WinForms.BunifuRadioButton RadioAy;
        private System.Windows.Forms.Label label16;
        private Bunifu.UI.WinForms.BunifuRadioButton RadioYil;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuRadioButton RadioGun;
        private System.Windows.Forms.TextBox UrunGelir;
        private System.Windows.Forms.TextBox KonaklamaGelir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Ciro;
    }
}