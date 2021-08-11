using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuButton;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml;

namespace Login
{



    public partial class OtelArayüz : Form
    {
        Form kapa = new Form();
        StringFormat strFormat;

        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;
        int OtelId = Login.id;

        public void Fomrdgsme(int a)
        {
            bunifuLabel1.Visible = false;
            Form child=new Form();

            try
            {
                kapa.Close();
            }
            catch (Exception)
            {

                throw;
            }

            if (a == 1)
            {  child = new Rezervasyon();
                kapa = child;
            }
            else if (a == 2)
            {  child = new Resepsiyon();
                kapa = child;
            }
            else if (a == 3)
            {  child = new Profiller();
                kapa = child;
            }
            else if (a == 4)
            {  child = new Konaklamalar();
                kapa = child; }
            else if (a == 5)
            {  child = new OdaSiparis();
                kapa = child;
            }
            else if (a == 6)
            {  child = new KatHizmetleri();
                kapa = child;
            }
            else if (a == 7)
            { child = new RezRapor();
                kapa = child;
            }
            else if(a==8)
            {  child = new YoneticiPanel();
                kapa = child;
            }
            else if (a == 9)
            {
                child = new YoneticiPanel();
                kapa = child;
            }
            else if (a == 10)
            {
                child = new Personel();
                kapa = child;
            }
            else if (a == 11)
            {
                child = new Odalar();
                kapa = child;
            }
            else if (a == 12)
            {
                child = new Istatistikler();
                kapa = child;
            }
            else if (a == 13)
            {
                child = new Log();
                kapa = child;
            }
            else
            {
                child = new Profiller();
                kapa = child;
            }

            child.TopLevel = false; //set it's TopLevel to false
            Controls.Add(child); //and add it to the parent Form
            child.Show(); //finally display it
            child.Location = new Point(200, 80);
            child.Dock = DockStyle.Fill;
            panel5.Controls.Add(child);
            child.BringToFront();


        }

        public OtelArayüz()
        {
            InitializeComponent();
        }

        

        private void OtelArayüz_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Rez_Ekle.IconVisible = true; Rez_Sil.IconVisible = true; bunifuFlatButton3.IconVisible = true; bunifuFlatButton4.IconVisible = true; bunifuFlatButton5.IconVisible = true; bunifuFlatButton6.IconVisible = true; Rez_Raporu.IconVisible = true; bunifuFlatButton8.IconVisible = true; bunifuFlatButton9.IconVisible = true; bunifuFlatButton10.IconVisible = true; bunifuFlatButton11.IconVisible = true; btnexcelprofil.IconVisible = true; btnyazdirprofil.IconVisible = true; Excel_Gonder.IconVisible = true; Yazdir.IconVisible = true; bunifuFlatButton16.IconVisible = true; bunifuFlatButton17.IconVisible = true; bunifuFlatButton18.IconVisible = true; bunifuFlatButton19.IconVisible = true; bunifuFlatButton20.IconVisible = true; bunifuFlatButton21.IconVisible = true; bunifuFlatButton22.IconVisible = true; bunifuFlatButton23.IconVisible = true; bunifuFlatButton24.IconVisible = true;
            bunifuFlatButton5.Text = " - "+DateTime.Now.ToLongTimeString();
            bunifuFlatButton6.Text = " - " + DateTime.Now.Day.ToString()+"."+DateTime.Now.Month.ToString()+"."+DateTime.Now.Year.ToString();
            bunifuPages1.SelectedTab = tabPage8;
            bunifuLabel1.Location = new Point(panel5.Size.Width/2-202,panel5.Size.Height/2);

            TCMBDovizKuruAl();
        }
       

        

       
        private void bunifuTileButton6_Click_1(object sender, EventArgs e)
        {
            Resepsiyon resepsiyon = new Resepsiyon();
            resepsiyon.Dispose();
            resepsiyon.Close();

            Application.Exit();
        }
        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedTab = tabPage4;
            Fomrdgsme(4);

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedTab = tabPage2;
            Fomrdgsme(2);
        }

        private void bunifuTileButton8_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedTab = tabPage1;
            Fomrdgsme(1);
        }

        private void bunifuTileButton7_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedTab = tabPage3;
            Fomrdgsme(3);
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedTab = tabPage5;
            Fomrdgsme(5);
        }

        private void bunifuTileButton9_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedTab = tabPage6;
            Fomrdgsme(6);
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedTab = tabPage7;
            Fomrdgsme(8);
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Fomrdgsme(7);
        }

        private void bunifuFlatButton20_Click(object sender, EventArgs e)
        {
            Fomrdgsme(9);
        }

        private void bunifuFlatButton19_Click(object sender, EventArgs e)
        {
            Fomrdgsme(10);
        }

        private void bunifuFlatButton22_Click(object sender, EventArgs e)
        {
            Fomrdgsme(11);
        }

        private void bunifuFlatButton21_Click(object sender, EventArgs e)
        {
            Fomrdgsme(12);
        }

        private void bunifuFlatButton24_Click(object sender, EventArgs e)
        {
            Fomrdgsme(13);
        }

        private void bunifuFlatButton23_Click(object sender, EventArgs e)
        {
            Fomrdgsme(14);
        }

        private void bunifuFlatButton18_Click(object sender, EventArgs e)
        {
            Oda_Durum pencere = new Oda_Durum();
            pencere.Show();
        }

        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            var pencere = (KatHizmetleri)Application.OpenForms["KatHizmetleri"];
            if (pencere != null)
            {
              pencere.TumOnay();
              pencere.OdaDurumDegisimi();
              pencere.OdaOnaylanacaklar();
            }
        }

        private void bunifuFlatButton16_Click(object sender, EventArgs e)
        {
            UrunEkle urunekle = new UrunEkle();
            urunekle.Show();
        }

        private void btnexcelprofil_Click(object sender, EventArgs e)//excele veri aktarma işlemleri aşağıda 
        {




            Profiller form = Application.OpenForms["Profiller"] as Profiller;
            try
            {

                if (form.bunifuCustomDataGrid1.Rows.Count != 0)
                {
                    Microsoft.Office.Interop.Excel.Application uyg = new Microsoft.Office.Interop.Excel.Application();
                    uyg.Visible = true;
                    Microsoft.Office.Interop.Excel.Workbook kitap = uyg.Workbooks.Add(System.Reflection.Missing.Value);
                    Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];

                    int StartCol = 1;

                    int StartRow = 1;

                    for (int j = 0; j < form.bunifuCustomDataGrid1.ColumnCount; j++)
                    {

                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];

                        myRange.Value2 = form.bunifuCustomDataGrid1.Columns[j].HeaderText;
                        myRange.ColumnWidth = 15;
                    }

                    StartRow++;

                    for (int i = 0; i < form.bunifuCustomDataGrid1.Rows.Count; i++)
                    {

                        for (int j = 0; j < form.bunifuCustomDataGrid1.Columns.Count; j++)
                        {



                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];

                            myRange.Value2 = form.bunifuCustomDataGrid1[j, i].Value == null ? "" : form.bunifuCustomDataGrid1[j, i].Value;

                        }


                    }

                }
                else
                {
                    MessageBox.Show("Veri olmadan excel çıktısı alamazsınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }



        }

        private void btnyazdirprofil_Click(object sender, EventArgs e) //Profil formu yazdırma işlemleri
        {
            try
            {
                Profiller form = Application.OpenForms["Profiller"] as Profiller;
                if (form.bunifuCustomDataGrid1.Rows.Count > 0)
                {
                    PrintPreviewDialog onizleme = new PrintPreviewDialog();
                    onizleme.Document = printDocument1;
                    onizleme.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Profil Bilgileri Olmadan Çıktı Alamazsınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // https://social.msdn.microsoft.com/Forums/tr-TR/2d97993e-96a0-4524-ad2c-b0e82a0a9238/datagrid-deki-bilgileri-yazdrma?forum=csharptr
                //yazdırma kısmını yapabilmek için yukarıdaki makaleden yardım aldım
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            r_musterı_ekle musterı_Ekle = new r_musterı_ekle();
            musterı_Ekle.Show();
        }


        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Profiller form = Application.OpenForms["Profiller"] as Profiller;
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
                foreach (DataGridViewColumn dgvGridCol in form.bunifuCustomDataGrid1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //// Profil Formu yazdırma İşlemleri

        void TCMBDovizKuruAl()
        {
            try
            {
                string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

                var xmlDoc = new XmlDocument();
                xmlDoc.Load(today);
                string USD_Satis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
                string EURO_Satis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;


                bunifuFlatButton11.Text = USD_Satis;
                bunifuFlatButton10.Text = EURO_Satis;
                bunifuFlatButton3.Text = USD_Satis;
                bunifuFlatButton4.Text = EURO_Satis;
            }
            catch (Exception)
            {
                MessageBox.Show("İnternet bağlantınız bulunmadığı için döviz kurları alınamadı!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            Rez_Sil rez_Sil = new Rez_Sil();
            rez_Sil.Show();
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Profiller form = Application.OpenForms["Profiller"] as Profiller;
            try
            {
                int iLeftMargin = e.MarginBounds.Left;
                int iTopMargin = e.MarginBounds.Top;
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                bFirstPage = true;

                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in form.bunifuCustomDataGrid1.Columns)
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

                while (iRow <= form.bunifuCustomDataGrid1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = form.bunifuCustomDataGrid1.Rows[iRow];

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

                            e.Graphics.DrawString("Profil Bilgileri", new Font(form.bunifuCustomDataGrid1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Profil Bilgileri", new Font(form.bunifuCustomDataGrid1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

                            e.Graphics.DrawString(strDate, new Font(form.bunifuCustomDataGrid1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(form.bunifuCustomDataGrid1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Profil Bilgileri", new Font(new Font(form.bunifuCustomDataGrid1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);


                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in form.bunifuCustomDataGrid1.Columns)
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

        private void Rez_Ekle_Click(object sender, EventArgs e)
        {
            r_musterı_ekle f = new r_musterı_ekle();
            f.Show();
        }

        private void Rez_Sil_Click(object sender, EventArgs e)
        {
            Rez_Sil f = new Rez_Sil();
            f.Show();
        }

        private void Excel_Gonder_Click(object sender, EventArgs e)
        {
            Konaklamalar form = Application.OpenForms["Konaklamalar"] as Konaklamalar;
            try
            {

                if (form.rapor.Rows.Count != 0)
                {
                    Microsoft.Office.Interop.Excel.Application uyg = new Microsoft.Office.Interop.Excel.Application();
                    uyg.Visible = true;
                    Microsoft.Office.Interop.Excel.Workbook kitap = uyg.Workbooks.Add(System.Reflection.Missing.Value);
                    Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];

                    int StartCol = 1;

                    int StartRow = 1;

                    for (int j = 0; j < form.rapor.ColumnCount; j++)
                    {

                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];

                        myRange.Value2 = form.rapor.Columns[j].HeaderText;
                        myRange.ColumnWidth = 20;
                    }

                    StartRow++;

                    for (int i = 0; i < form.rapor.Rows.Count; i++)
                    {

                        for (int j = 0; j < form.rapor.Columns.Count; j++)
                        {



                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];

                            myRange.Value2 = form.rapor[j, i].Value == null ? "" : form.rapor[j, i].Value;

                        }


                    }

                }
                else
                {
                    MessageBox.Show("Veri olmadan excel çıktısı alamazsınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        private void Yazdir_Click(object sender, EventArgs e)
        {
            Konaklamalar form = Application.OpenForms["Konaklamalar"] as Konaklamalar;

            PrintPreviewDialog onizleme = new PrintPreviewDialog();
            onizleme.Document = form.printDocument1;
            onizleme.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuFlatButton5.Text = " - " + DateTime.Now.ToLongTimeString();
            bunifuFlatButton6.Text = " - " + DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString();

            // o günün verisi 
        }

    }
}
