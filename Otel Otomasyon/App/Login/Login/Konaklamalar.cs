using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Login
{
    public partial class Konaklamalar : Form
    {
        public int OtelID = Login.id;
        public Konaklamalar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Login.veritabani);

        private void Konaklama_Load(object sender, EventArgs e)
        {
            gel_aralik.Value = false;
            gid_aralik.Value = false;
            gel_tar2.MinDate = gel_tar.Value;
            gid_tar2.MinDate = gel_tar.Value;
            radio_ayrilan.Checked = false;
            radio_icerde_blnn.Checked = false;
            radio_hepsi.Checked = true;
            tc.MaxLength = 11;
        }

        private void bunifuToggleSwitch1_OnValuechange(object sender, EventArgs e)
        {
            if (gel_aralik.Value == true)
            {
                gel_tar2.Enabled = true;
                gel_tar2.IconColor = Color.Green;
            }
            else
            {
                gel_tar2.Enabled = false;
                gel_tar2.IconColor = Color.Gray;
            }
        }

        private void bunifuToggleSwitch2_OnValuechange(object sender, EventArgs e)
        {
            if (gid_aralik.Value == true)
            {
                gid_tar2.Enabled = true;
                gid_tar2.IconColor = Color.Green;
            }
            else
            {
                gid_tar2.Enabled = false;
                gid_tar2.IconColor = Color.Gray;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                rapor.Rows.Clear();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * from KonaklamaRapor where TcKimlik='" + Convert.ToInt64(tc.Text) + "' and OtelID='" + OtelID + "'", baglanti);
                SqlDataReader sa = komut.ExecuteReader();
                int a = 0;
                while (sa.Read())
                {
                    rapor.Rows.Add();
                    rapor.Rows[a].Cells[0].Value = sa[0].ToString();
                    rapor.Rows[a].Cells[1].Value = sa[1].ToString().Substring(0, 10);
                    rapor.Rows[a].Cells[2].Value = sa[2].ToString().Substring(0, 10);
                    rapor.Rows[a].Cells[3].Value = sa[3].ToString();
                    rapor.Rows[a].Cells[4].Value = sa[4].ToString();
                    rapor.Rows[a].Cells[5].Value = sa[5].ToString();
                    a++;
                }
                baglanti.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Tc_OnValueChanged(object sender, EventArgs e)
        {

            if (tc.Text.Length > 0)
            {
                radio_ayrilan.Enabled = false;
                radio_icerde_blnn.Enabled = false;
                radio_hepsi.Enabled = false;

                gel_tar.Enabled = false;
                gel_tar.IconColor = Color.Gray;
                gel_tar2.Enabled = false;
                gel_tar2.IconColor = Color.Gray;
                gel_aralik.Value = false;
                gid_tar.Enabled = false;
                gid_tar.IconColor = Color.Gray;
                gid_tar2.Enabled = false;
                gid_tar2.IconColor = Color.Gray;
                gid_aralik.Value = false;
            }

            else
            {
                gel_tar.Enabled = true;
                gel_tar.IconColor = Color.Green;
                gid_tar.Enabled = true;
                gid_tar.IconColor = Color.Green;
                rapor.Rows.Clear();
            }

        }

        private void Rapor_Goster_Click(object sender, EventArgs e)
        {
            if (gel_aralik.Value == true && gid_aralik.Value == true)
            {
                aralik();
                if (radio_ayrilan.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from KonaklamaRapor where (GelisTarihi BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and (GidisTarihi BETWEEN '" + gid_tar.Text + "' and '" + gid_tar2.Text + "') and Durum=0 and OtelID='" + OtelID + "'", baglanti);
                    getir1(komut);
                }
                else if (radio_icerde_blnn.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from KonaklamaRapor where (GelisTarihi BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and (GidisTarihi BETWEEN '" + gid_tar.Text + "' and '" + gid_tar2.Text + "') and Durum=1 and OtelID='" + OtelID + "'", baglanti);
                    getir1(komut);
                }
                else if (radio_hepsi.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from KonaklamaRapor where (GelisTarihi BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and (GidisTarihi BETWEEN '" + gid_tar.Text + "' and '" + gid_tar2.Text + "') and (Durum=0 or Durum=1) and OtelID='" + OtelID + "'", baglanti);
                    getir1(komut);
                }
                aralik2();
            }
            else if (gel_aralik.Value == true && gid_aralik.Value == false)
            {
                aralik();
                if (radio_ayrilan.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from KonaklamaRapor where (GelisTarihi BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and (GidisTarihi<='" + gid_tar.Text + "') and Durum=0 and OtelID='" + OtelID + "' ", baglanti);
                    getir1(komut);
                }
                else if (radio_icerde_blnn.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from KonaklamaRapor where (GelisTarihi BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and (GidisTarihi<='" + gid_tar.Text + "') and Durum=1 and OtelID='" + OtelID + "'", baglanti);
                    getir1(komut);
                }
                else if (radio_hepsi.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from KonaklamaRapor where (GelisTarihi BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and (GidisTarihi<='" + gid_tar.Text + "') and (Durum=0 or Durum=1) and OtelID='" + OtelID + "'", baglanti);
                    getir1(komut);
                }
                aralik2();
            }
            else if (gel_aralik.Value == false && gid_aralik.Value == true)
            {
                aralik();
                if (radio_ayrilan.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from Konaklamarapor where GelisTarihi>='" + gel_tar.Text + "' and (GidisTarihi BETWEEN '" + gid_tar.Text + "' and '" + gid_tar2.Text + "') and Durum=0 and OtelID='" + OtelID + "'", baglanti);
                    getir1(komut);
                }
                else if (radio_icerde_blnn.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from Konaklamarapor where GelisTarihi>='" + gel_tar.Text + "' and (GidisTarihi BETWEEN '" + gid_tar.Text + "' and '" + gid_tar2.Text + "') and Durum=1 and OtelID='" + OtelID + "'", baglanti);
                    getir1(komut);
                }
                else if (radio_hepsi.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from Konaklamarapor where GelisTarihi>='" + gel_tar.Text + "' and (GidisTarihi BETWEEN '" + gid_tar.Text + "' and '" + gid_tar2.Text + "') and (Durum=0 or Durum=1) and OtelID='" + OtelID + "'", baglanti);
                    getir1(komut);
                }
                aralik2();
            }
            else if(gel_aralik.Value == false && gid_aralik.Value == false)
            {
                aralik();
                if (radio_ayrilan.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from Konaklamarapor where (GelisTarihi>='" + gel_tar.Text + "' and GidisTarihi<='" + gid_tar.Text + "') and Durum=0 and OtelID='" + OtelID + "'", baglanti);
                    getir1(komut);
                }
                else if (radio_icerde_blnn.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from Konaklamarapor where (GelisTarihi>='" + gel_tar.Text + "' and GidisTarihi<='" + gid_tar.Text + "') and Durum=1 and OtelID='" + OtelID + "'", baglanti);
                    getir1(komut);
                }
                else if (radio_hepsi.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("SELECT * from Konaklamarapor where (GelisTarihi>='" + gel_tar.Text + "' and GidisTarihi<='" + gid_tar.Text + "') and (Durum=0 or Durum=1) and OtelID='" + OtelID + "'", baglanti);
                    getir1(komut);
                }
                aralik2();
            }
                
        } 
               
        void aralik()
        {
            gel_tar.CustomFormat = "MM/dd/yyyy";
            gel_tar2.CustomFormat = "MM/dd/yyyy";
            gid_tar.CustomFormat = "MM/dd/yyyy";
            gid_tar2.CustomFormat = "MM/dd/yyyy";
            gel_tar.Format = DateTimePickerFormat.Custom;
            gel_tar2.Format = DateTimePickerFormat.Custom;
            gid_tar.Format = DateTimePickerFormat.Custom;
            gid_tar2.Format = DateTimePickerFormat.Custom;

        }
        void aralik2()
        {
            gel_tar.Format = DateTimePickerFormat.Long;
            gel_tar2.Format = DateTimePickerFormat.Long;
            gid_tar.Format = DateTimePickerFormat.Long;
            gid_tar2.Format = DateTimePickerFormat.Long;
        }
        void getir1(SqlCommand a)
        {
            rapor.Rows.Clear();
            baglanti.Open();
                SqlDataReader oku = a.ExecuteReader();
                aralik2();
                int sayac = 0;
            while (oku.Read())
            {
                rapor.Rows.Add();
                rapor.Rows[sayac].Cells[0].Value = oku[0].ToString();
                rapor.Rows[sayac].Cells[1].Value = oku[1].ToString().Substring(0, 10);
                rapor.Rows[sayac].Cells[2].Value = oku[2].ToString().Substring(0, 10);
                rapor.Rows[sayac].Cells[3].Value = oku[3].ToString();
                rapor.Rows[sayac].Cells[4].Value = oku[4].ToString();
                rapor.Rows[sayac].Cells[5].Value = oku[5].ToString();
                sayac++;
            }
            baglanti.Close();
        }

        private void Gel_tar_ValueChanged(object sender, EventArgs e)
        {
            gel_tar2.MinDate = gel_tar.Value;
            gel_tar2.Value = gel_tar.Value;

            gid_tar.MinDate = gel_tar.Value;
            gid_tar.Value = gel_tar.Value;
            
        }

        private void Gid_tar_ValueChanged(object sender, EventArgs e)
        {
            gid_tar2.MinDate = gid_tar.MinDate;
            gid_tar2.Value = gid_tar.Value;
 
        }


        //Yazdırma İşlemi
        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int iLeftMargin = e.MarginBounds.Left;
                int iTopMargin = e.MarginBounds.Top;
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                bFirstPage = true;

                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in rapor.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;


                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }

                while (iRow <= rapor.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = rapor.Rows[iRow];

                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;

                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {

                            e.Graphics.DrawString("Konaklama Raporu", new Font(rapor.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Konaklama Raporu", new Font(rapor.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

                            e.Graphics.DrawString(strDate, new Font(rapor.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(rapor.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Konaklama Raporu", new Font(new Font(rapor.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);


                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in rapor.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;

                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }

                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }


                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in rapor.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Gel_tar2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
