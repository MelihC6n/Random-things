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
    public partial class RezRapor : Form
    {
        public int OtelID = Login.id;
        public RezRapor()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Login.veritabani);
        SqlConnection baglanti2 = new SqlConnection(Login.veritabani);

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
        private void RezRapor_Load(object sender, EventArgs e)
        {
            gel_tar.MinDate = DateTime.Now;
            gel_tar2.MinDate = gel_tar.Value;
            gel_aralik.Value = false;
            radio_hepsi.Checked = true;
            radio_tc.Checked = false;
            baglanti.Open();
            gel_tar.CustomFormat = "MM/dd/yyyy";
            gel_tar2.CustomFormat = "MM/dd/yyyy";
            gel_tar.Format = DateTimePickerFormat.Custom;
            gel_tar2.Format = DateTimePickerFormat.Custom;
            SqlCommand komut = new SqlCommand("select TcNo,GelisTarih,ad,soyad,Uyruk from RezRaporV where GelisTarih='" + gel_tar.Text + "' and OtelID='" + OtelID + "' ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            gel_tar.Format = DateTimePickerFormat.Long;
            gel_tar2.Format = DateTimePickerFormat.Long;
            int sayac = 0;
            while (oku.Read())
            {
                rapor.Rows.Add();
                rapor.Rows[sayac].Cells[0].Value = oku[0].ToString();
                rapor.Rows[sayac].Cells[1].Value = oku[1].ToString().Substring(0, 10);
                rapor.Rows[sayac].Cells[2].Value = oku[2].ToString();
                rapor.Rows[sayac].Cells[3].Value = oku[3].ToString();
                rapor.Rows[sayac].Cells[4].Value = oku[4].ToString();
                sayac++;
            }
            baglanti.Close();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            rapor.Rows.Clear();
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where (TcNo='" + tc_noveyaad.Text + "' or ad='" + tc_noveyaad.Text + "') and OtelID='" + OtelID + "' ", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                int syc = 0;
                while (dr.Read())
                {
                    rapor.Rows.Add();
                    rapor.Rows[syc].Cells[0].Value = dr[0].ToString();
                    rapor.Rows[syc].Cells[1].Value = dr[1].ToString();
                    rapor.Rows[syc].Cells[2].Value = dr[2].ToString();
                    rapor.Rows[syc].Cells[3].Value = dr[3].ToString();
                    rapor.Rows[syc].Cells[4].Value = dr[4].ToString();
                    syc++;
                }
                baglanti.Close();
            }
            catch (Exception)
            {
                baglanti2.Open();
                SqlCommand da = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where ad='" + tc_noveyaad.Text + "' and OtelID='" + OtelID + "' ", baglanti2);
                SqlDataReader sa = da.ExecuteReader();
                int a = 0;
                while (sa.Read())
                {
                    rapor.Rows.Add();
                    rapor.Rows[a].Cells[0].Value = sa[0].ToString();
                    rapor.Rows[a].Cells[1].Value = sa[1].ToString();
                    rapor.Rows[a].Cells[2].Value = sa[2].ToString();
                    rapor.Rows[a].Cells[3].Value = sa[3].ToString();
                    rapor.Rows[a].Cells[4].Value = sa[4].ToString();
                    a++;
                }
                baglanti2.Close();
            }



        }

        private void Tc_noveyaad_OnValueChanged(object sender, EventArgs e)
        {
            if (tc_noveyaad.Text.Length > 0)
            {
                gel_aralik.Value = false;
                radio_tc.Enabled = false;
                radio_tc.Checked = false;
                radio_yabanci.Enabled = false;
                radio_yabanci.Checked = false;
                gel_tar.Enabled = false;
                gel_tar.IconColor = Color.Gray;
                gel_tar2.Enabled = false;
                gel_tar2.IconColor = Color.Gray;
                gel_tar2.Enabled = false;
            }
            else
            {
                gel_aralik.Value = true;
                radio_tc.Enabled = true;
                radio_yabanci.Enabled = true;
                gel_tar.Enabled = true;
                gel_tar.IconColor = Color.Green;
                gel_tar2.Enabled = true;
                gel_tar2.IconColor = Color.Green;
                gel_tar2.Enabled = true;
            }
        }

        private void Gel_tar_ValueChanged(object sender, EventArgs e)
        {
            gel_tar2.MinDate = gel_tar.MinDate;
        }
        private void Rapor_Goster_Click(object sender, EventArgs e)
        {
            try
            {
                if (gel_aralik.Value == true)
                {
                    gel_tar.CustomFormat = "MM/dd/yyyy";
                    gel_tar2.CustomFormat = "MM/dd/yyyy";
                    gel_tar.Format = DateTimePickerFormat.Custom;
                    gel_tar2.Format = DateTimePickerFormat.Custom;

                    if (radio_tc.Checked == true)
                    {
                        SqlCommand komut = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where (GelisTarih BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and uyruk='Turkey' and OtelID='" + OtelID + "'", baglanti);
                        getir1(komut);
                    }
                    else if (radio_yabanci.Checked == true)
                    {
                        SqlCommand komut = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where (GelisTarih BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and uyruk<>'Turkey' and OtelID='" + OtelID + "'", baglanti);
                        getir1(komut);
                    }
                    else if (radio_hepsi.Checked == true)
                    {
                        SqlCommand komut = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where (GelisTarih BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and (uyruk='Turkey' or uyruk<>'Turkey') and OtelID='" + OtelID + "'", baglanti);
                        getir1(komut);
                    }
                    gel_tar.Format = DateTimePickerFormat.Long;
                    gel_tar2.Format = DateTimePickerFormat.Long;
                }
                else
                {
                    gel_tar.CustomFormat = "MM/dd/yyyy";
                    gel_tar.Format = DateTimePickerFormat.Custom;
                    if (radio_tc.Checked == true)
                    {
                        SqlCommand komut = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where GelisTarih='" + gel_tar.Text + "' and uyruk='Turkey' and OtelID='" + OtelID + "' ", baglanti);
                        getir2(komut);
                    }
                    else if (radio_yabanci.Checked == true)
                    {
                        SqlCommand komut = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where GelisTarih='" + gel_tar.Text + "' and uyruk<>'Turkey' and OtelID='" + OtelID + "'", baglanti);
                        getir2(komut);
                    }
                    else if (radio_hepsi.Checked == true)
                    {
                        SqlCommand komut = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where GelisTarih='" + gel_tar.Text + "' and (uyruk='Turkey' or uyruk<>'Turkey') and OtelID='" + OtelID + "'", baglanti);
                        getir2(komut);
                    }
                    gel_tar.Format = DateTimePickerFormat.Long;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        void getir1(SqlCommand a)
        {
            rapor.Rows.Clear();
            baglanti.Open();
            gel_tar.CustomFormat = "MM/dd/yyyy";
            gel_tar2.CustomFormat = "MM/dd/yyyy";
            gel_tar.Format = DateTimePickerFormat.Custom;
            gel_tar2.Format = DateTimePickerFormat.Custom;
            SqlDataReader oku = a.ExecuteReader();
            gel_tar.Format = DateTimePickerFormat.Long;
            gel_tar2.Format = DateTimePickerFormat.Long;
            int sayac = 0;
            while (oku.Read())
            {
                rapor.Rows.Add();
                rapor.Rows[sayac].Cells[0].Value = oku[0].ToString();
                rapor.Rows[sayac].Cells[1].Value = oku[1].ToString().Substring(0, 10);
                rapor.Rows[sayac].Cells[2].Value = oku[2].ToString();
                rapor.Rows[sayac].Cells[3].Value = oku[3].ToString();
                rapor.Rows[sayac].Cells[4].Value = oku[4].ToString();
                sayac++;
            }
            baglanti.Close();
        }
        void getir2(SqlCommand b)
        {
            rapor.Rows.Clear();
            baglanti.Open();
            gel_tar.CustomFormat = "MM/dd/yyyy";
            gel_tar.Format = DateTimePickerFormat.Custom;
            SqlDataReader oku = b.ExecuteReader();
            gel_tar.Format = DateTimePickerFormat.Long;
            int sayac = 0;
            while (oku.Read())
            {
                rapor.Rows.Add();
                rapor.Rows[sayac].Cells[0].Value = oku[0].ToString();
                rapor.Rows[sayac].Cells[1].Value = oku[1].ToString().Substring(0, 10);
                rapor.Rows[sayac].Cells[2].Value = oku[2].ToString();
                rapor.Rows[sayac].Cells[3].Value = oku[3].ToString();
                rapor.Rows[sayac].Cells[4].Value = oku[4].ToString();
                sayac++;
            }
            baglanti.Close();
        }



        private void Excel_Aktar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rapor.Rows.Count != 0)
                {
                    Microsoft.Office.Interop.Excel.Application uyg = new Microsoft.Office.Interop.Excel.Application();
                    uyg.Visible = true;
                    Microsoft.Office.Interop.Excel.Workbook kitap = uyg.Workbooks.Add(System.Reflection.Missing.Value);
                    Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];
                    int StartCol = 1;
                    int StartRow = 1;
                    for (int j = 0; j < rapor.ColumnCount; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                        myRange.Value2 = rapor.Columns[j].HeaderText;
                        myRange.ColumnWidth = 25;
                    }
                    StartRow++;
                    for (int i = 0; i < rapor.Rows.Count; i++)
                    {
                        for (int j = 0; j < rapor.Columns.Count; j++)
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = rapor[j, i].Value == null ? "" : rapor[j, i].Value;
                        }
                    }
                }
                else
                    MessageBox.Show("Veri olmadan excel çıktısı alamazsınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //YAZDIRMAK İÇİN
        //https://social.msdn.microsoft.com/Forums/tr-TR/2d97993e-96a0-4524-ad2c-b0e82a0a9238/datagrid-deki-bilgileri-yazdrma?forum=csharptr

        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;
        private void Yazdir_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog onizleme = new PrintPreviewDialog();
            onizleme.Document = printDocument1;
            onizleme.ShowDialog();
        }
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

                            e.Graphics.DrawString("Rezervasyon Raporu", new Font(rapor.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Rezervasyon Raporu", new Font(rapor.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

                            e.Graphics.DrawString(strDate, new Font(rapor.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(rapor.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Rezervasyon Raporu", new Font(new Font(rapor.Font,
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

        private void radio_tc_Click(object sender, EventArgs e)
        {

        }
    }
}
