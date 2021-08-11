namespace Login
{
    partial class Rez_Sil
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.veri = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.veri)).BeginInit();
            this.SuspendLayout();
            // 
            // veri
            // 
            this.veri.AllowUserToAddRows = false;
            this.veri.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.veri.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.veri.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.veri.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.veri.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.veri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.veri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.veri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.veri.DoubleBuffered = true;
            this.veri.EnableHeadersVisualStyles = false;
            this.veri.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.veri.HeaderForeColor = System.Drawing.Color.White;
            this.veri.Location = new System.Drawing.Point(0, 0);
            this.veri.Name = "veri";
            this.veri.ReadOnly = true;
            this.veri.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.veri.RowHeadersWidth = 20;
            this.veri.Size = new System.Drawing.Size(820, 296);
            this.veri.TabIndex = 102;
            this.veri.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Veri_CellDoubleClick);
            // 
            // Rez_Sil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(820, 296);
            this.Controls.Add(this.veri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Rez_Sil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rezervasyon Sil";
            this.Load += new System.EventHandler(this.Rez_Sil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.veri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid veri;
    }
}