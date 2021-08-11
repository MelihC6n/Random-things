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

namespace Login
{
    public partial class Istatistikler : Form
    {
        int otelid = Login.id;
        SqlConnection baglan = new SqlConnection(Login.veritabani);

        int sorgutipi = 0;
        SqlCommand grafik;
        Boolean datepickerchange = true;


        public Istatistikler()
        {
            InitializeComponent();
        }

        private void RadioGun_Click(object sender, EventArgs e)
        {
            DateMevcut.CustomFormat = "yyyy-MM-dd";
            DateKarsi.CustomFormat = "yyyy-MM-dd";
            Grafik();
            IstatistikYazi();
        }

        private void RadioAy_Click(object sender, EventArgs e)
        {
            DateMevcut.CustomFormat = "yyyy-MM";
            DateKarsi.CustomFormat = "yyyy-MM";
            Grafik();
            IstatistikYazi();
        }

        private void RadioYil_Click(object sender, EventArgs e)
        {
            DateMevcut.CustomFormat = "yyyy";
            DateKarsi.CustomFormat = "yyyy";
            Grafik();
            IstatistikYazi();
        }

        private void Grafik()
        {
            try
            {
                datepickerchange = false;
                DateTime mevcutasil = DateMevcut.Value;
                DateTime karsiasil = DateKarsi.Value;
                chart1.Series["Grafik"].IsValueShownAsLabel = true;
                chart1.Series["Grafik"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series["Grafik"].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;


                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }

                chart1.Titles.Clear();
                if (bunifuToggleSwitch1.Value == true)
                {
                    chart1.ChartAreas[0].AxisX.IsReversed = false;
                }
                else
                {
                    chart1.ChartAreas[0].AxisX.IsReversed = true;  //chartı ters çevirmek için buradan yardım aldım : https://stackoverflow.com/questions/29932431/reverse-the-direction-of-line-chart
                }

                if (sorgutipi == 1)
                {
                    chart1.Titles.Add("Tarih Biçimine Göre Ortalama Dolu Oda Sayısı");
                    if (RadioAy.Checked == true)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            int gunsayi = 0;
                            grafik = new SqlCommand("SELECT Distinct GelisTarihi,GidisTarihi,OdaNo ,DATEDIFF(day,GelisTarihi,GidisTarihi) from GirisGecmis where OtelID='" + otelid + "' and GelisTarihi like '" + DateMevcut.Text + "%' and GidisTarihi like '" + DateMevcut.Text + "%'", baglan);
                            baglan.Open();
                            SqlDataReader oku = grafik.ExecuteReader();
                            while (oku.Read())
                            {
                                gunsayi += int.Parse(oku[3].ToString());
                            }
                            int aydakigun = DateTime.DaysInMonth(DateMevcut.Value.Year, DateMevcut.Value.Month);
                            double a = gunsayi / aydakigun;
                            baglan.Close();
                            chart1.Series["Grafik"].Points.Add(a);
                            chart1.Series["Grafik"].Points[i].AxisLabel = DateMevcut.Text;
                            if (bunifuToggleSwitch1.Value == true)
                            {
                                int gunsayi2 = 0;
                                grafik = new SqlCommand("SELECT Distinct GelisTarihi,GidisTarihi,OdaNo ,DATEDIFF(day,GelisTarihi,GidisTarihi) from GirisGecmis where OtelID='" + otelid + "' and GelisTarihi like '" + DateKarsi.Text + "%' and GidisTarihi like '" + DateKarsi.Text + "%'", baglan);
                                baglan.Open();
                                SqlDataReader oku2 = grafik.ExecuteReader();
                                while (oku2.Read())
                                {
                                    gunsayi2 += int.Parse(oku2[3].ToString());
                                }
                                int aydakigun2 = DateTime.DaysInMonth(DateKarsi.Value.Year, DateKarsi.Value.Month);
                                double a2 = gunsayi2 / aydakigun2;
                                baglan.Close();

                                chart1.Series["Grafik"].Points.Add(a2);
                                chart1.Series["Grafik"].Points[i + 1].AxisLabel = DateKarsi.Text;
                                break;
                            }
                            else
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddMonths(-1);   //tarih işlemleri için buradan yardım aldım : http://web.bilecik.edu.tr/ugur-talas/2014/10/14/cta-datetimea-zaman-ekleme-yada-cikarma-islemleri/
                                DateMevcut.Value = oncekigun;
                            }
                        }
                    }
                    else if (RadioYil.Checked == true)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            int gunsayi = 0;
                            grafik = new SqlCommand("SELECT Distinct GelisTarihi,GidisTarihi,OdaNo ,DATEDIFF(day,GelisTarihi,GidisTarihi) from GirisGecmis where OtelID='" + otelid + "' and GelisTarihi like '" + DateMevcut.Text + "%' and GidisTarihi like '" + DateMevcut.Text + "%'", baglan);
                            baglan.Open();
                            SqlDataReader oku = grafik.ExecuteReader();
                            while (oku.Read())
                            {
                                gunsayi += int.Parse(oku[3].ToString());
                            }
                            int a = gunsayi / 365;
                            baglan.Close();

                            chart1.Series["Grafik"].Points.Add(a);
                            chart1.Series["Grafik"].Points[i].AxisLabel = DateMevcut.Text;
                            if (bunifuToggleSwitch1.Value == true)
                            {
                                int gunsayi2 = 0;
                                grafik = new SqlCommand("SELECT Distinct GelisTarihi,GidisTarihi,OdaNo ,DATEDIFF(day,GelisTarihi,GidisTarihi) from GirisGecmis where OtelID='" + otelid + "' and GelisTarihi like '" + DateKarsi.Text + "%' and GidisTarihi like '" + DateKarsi.Text + "%'", baglan);
                                baglan.Open();
                                SqlDataReader oku2 = grafik.ExecuteReader();
                                while (oku2.Read())
                                {
                                    gunsayi2 += int.Parse(oku[3].ToString());
                                }
                                int a2 = gunsayi2 / 365;
                                baglan.Close();
                                chart1.Series["Grafik"].Points.Add(a2);
                                chart1.Series["Grafik"].Points[i + 1].AxisLabel = DateKarsi.Text;
                                break;
                            }
                            else
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddYears(-1);
                                DateMevcut.Value = oncekigun;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            int gunsayi = 0;
                            grafik = new SqlCommand("SELECT Distinct GelisTarihi,GidisTarihi,OdaNo ,DATEDIFF(day,GelisTarihi,GidisTarihi) from GirisGecmis where OtelID='" + otelid + "' and GelisTarihi <= '" + DateMevcut.Text + "' and GidisTarihi >= '" + DateMevcut.Text + "'", baglan);
                            baglan.Open();
                            SqlDataReader oku = grafik.ExecuteReader();
                            while (oku.Read())
                            {
                                gunsayi += 1;
                            }
                            baglan.Close();

                            chart1.Series["Grafik"].Points.Add(gunsayi);
                            chart1.Series["Grafik"].Points[i].AxisLabel = DateMevcut.Text;
                            if (bunifuToggleSwitch1.Value == true)
                            {
                                int gunsayi2 = 0;
                                grafik = new SqlCommand("SELECT Distinct GelisTarihi,GidisTarihi,OdaNo ,DATEDIFF(day,GelisTarihi,GidisTarihi) from GirisGecmis where OtelID='" + otelid + "' and GelisTarihi <= '" + DateKarsi.Text + "' and GidisTarihi >= '" + DateKarsi.Text + "'", baglan);
                                baglan.Open();
                                SqlDataReader oku2 = grafik.ExecuteReader();
                                while (oku2.Read())
                                {
                                    gunsayi2 += 1;
                                }
                                baglan.Close();
                                chart1.Series["Grafik"].Points.Add(gunsayi2);
                                chart1.Series["Grafik"].Points[i + 1].AxisLabel = DateKarsi.Text;
                                break;
                            }
                            else
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddDays(-1);
                                DateMevcut.Value = oncekigun;
                            }
                        }
                    }
                }


                else if (sorgutipi == 2)
                {
                    chart1.Titles.Add("Tarih Biçimine Göre Yapılan RezervasyonSayısı");
                    if (RadioAy.Checked == true)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            grafik = new SqlCommand("select COUNT(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateMevcut.Text + "%'", baglan);
                            baglan.Open();
                            SqlDataReader oku = grafik.ExecuteReader();
                            while (oku.Read())
                            {
                                chart1.Series["Grafik"].Points.Add(int.Parse(oku[0].ToString()));
                                chart1.Series["Grafik"].Points[i].AxisLabel = DateMevcut.Text;
                            }
                            baglan.Close();

                            if (bunifuToggleSwitch1.Value == true)
                            {
                                grafik = new SqlCommand("select COUNT(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateKarsi.Text + "%'", baglan);
                                baglan.Open();
                                SqlDataReader oku2 = grafik.ExecuteReader();
                                while (oku2.Read())
                                {

                                    chart1.Series["Grafik"].Points.Add(int.Parse(oku2[0].ToString()));
                                    chart1.Series["Grafik"].Points[i + 1].AxisLabel = DateKarsi.Text;
                                    chart1.Series["Grafik"].Points[i + 1].AxisLabel = DateKarsi.Text;
                                }
                                baglan.Close();

                                break;
                            }
                            else
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddMonths(-1);   //tarih işlemleri için buradan yardım aldım : http://web.bilecik.edu.tr/ugur-talas/2014/10/14/cta-datetimea-zaman-ekleme-yada-cikarma-islemleri/
                                DateMevcut.Value = oncekigun;
                            }
                        }
                    }
                    else if (RadioYil.Checked == true)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            grafik = new SqlCommand("select COUNT(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateMevcut.Text + "%'", baglan);
                            baglan.Open();
                            SqlDataReader oku = grafik.ExecuteReader();
                            while (oku.Read())
                            {
                                chart1.Series["Grafik"].Points.Add(int.Parse(oku[0].ToString()));
                                chart1.Series["Grafik"].Points[i].AxisLabel = DateMevcut.Text;
                            }
                            baglan.Close();

                            if (bunifuToggleSwitch1.Value == true)
                            {
                                grafik = new SqlCommand("select COUNT(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateKarsi.Text + "%'", baglan);
                                baglan.Open();
                                SqlDataReader oku2 = grafik.ExecuteReader();
                                while (oku2.Read())
                                {

                                    chart1.Series["Grafik"].Points.Add(int.Parse(oku2[0].ToString()));
                                    chart1.Series["Grafik"].Points[i + 1].AxisLabel = DateKarsi.Text;
                                }
                                baglan.Close();

                                break;
                            }
                            else
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddYears(-1);
                                DateMevcut.Value = oncekigun;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            grafik = new SqlCommand("select COUNT(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateMevcut.Text + "%'", baglan);
                            baglan.Open();
                            SqlDataReader oku = grafik.ExecuteReader();
                            while (oku.Read())
                            {
                                chart1.Series["Grafik"].Points.Add(int.Parse(oku[0].ToString()));
                                chart1.Series["Grafik"].Points[i].AxisLabel = DateMevcut.Text;
                            }
                            baglan.Close();

                            if (bunifuToggleSwitch1.Value == true)
                            {
                                grafik = new SqlCommand("select COUNT(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateKarsi.Text + "%'", baglan);
                                baglan.Open();
                                SqlDataReader oku2 = grafik.ExecuteReader();
                                while (oku2.Read())
                                {

                                    chart1.Series["Grafik"].Points.Add(int.Parse(oku2[0].ToString()));
                                    chart1.Series["Grafik"].Points[i + 1].AxisLabel = DateKarsi.Text;
                                }
                                baglan.Close();

                                break;
                            }
                            else
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddDays(-1);
                                DateMevcut.Value = oncekigun;
                            }
                        }
                    }
                }
                if (sorgutipi == 3)
                {
                    chart1.Titles.Add("Tarihlere Göre Toplam Ciro (₺)");
                    int gecmissure = 0;
                    if (RadioGun.Checked == true)
                        gecmissure = 7;
                    else if (RadioAy.Checked == true)
                        gecmissure = 3;
                    else
                        gecmissure = 3;
                    for (int i = 0; i < gecmissure; i++)
                    {
                        double asilciro = 0;
                        double karsiciro = 0;
                        grafik = new SqlCommand("select Odeme from OdemelerGecmis where OtelID='" + otelid + "' and OdemeTarih like '" + DateMevcut.Text + "%'", baglan);
                        baglan.Open();
                        SqlDataReader oku = grafik.ExecuteReader();
                        while (oku.Read())
                        {
                            asilciro += double.Parse(oku[0].ToString());
                        }
                        baglan.Close();
                        chart1.Series["Grafik"].Points.Add(asilciro);
                        chart1.Series["Grafik"].Points[i].AxisLabel = DateMevcut.Text;
                        if (bunifuToggleSwitch1.Value == true)
                        {
                            grafik = new SqlCommand("select Odeme from OdemelerGecmis where OtelID='" + otelid + "' and OdemeTarih like '" + DateKarsi.Text + "%'", baglan);
                            baglan.Open();
                            SqlDataReader oku2 = grafik.ExecuteReader();
                            while (oku2.Read())
                            {
                                karsiciro += double.Parse(oku2[0].ToString());
                            }
                            baglan.Close();

                            chart1.Series["Grafik"].Points.Add(karsiciro);
                            chart1.Series["Grafik"].Points[i + 1].AxisLabel = DateKarsi.Text;
                            break;
                        }
                        else
                        {
                            if (RadioGun.Checked == true)
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddDays(-1);
                                DateMevcut.Value = oncekigun;
                            }
                            else if (RadioAy.Checked == true)
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddMonths(-1);
                                DateMevcut.Value = oncekigun;
                            }
                            else
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddYears(-1);
                                DateMevcut.Value = oncekigun;
                            }
                        }
                    }

                }
                if (sorgutipi == 4)
                {
                    chart1.Titles.Add("Tarihlere Göre Misafirlerin Uyruk Oranı");
                    chart1.Series["Grafik"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chart1.Series["Grafik"].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.None;

                    grafik = new SqlCommand("select Count(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateMevcut.Text + "%' and uyruk=1", baglan);
                    baglan.Open();
                    SqlDataReader oku = grafik.ExecuteReader();
                    while (oku.Read())
                    {
                        chart1.Series["Grafik"].Points.AddXY("Türk", int.Parse(oku[0].ToString()));
                    }
                    baglan.Close();
                    grafik = new SqlCommand("select Count(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateMevcut.Text + "%' and uyruk=0", baglan);
                    baglan.Open();
                    SqlDataReader oku2 = grafik.ExecuteReader();
                    while (oku2.Read())
                    {
                        chart1.Series["Grafik"].Points.AddXY("Yabancı", int.Parse(oku2[0].ToString()));

                    }
                    baglan.Close();

                    if (bunifuToggleSwitch1.Value == true)
                    {
                        grafik = new SqlCommand("select Count(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateKarsi.Text + "%' and uyruk=1", baglan);
                        baglan.Open();
                        SqlDataReader oku3 = grafik.ExecuteReader();
                        while (oku3.Read())
                        {
                            chart1.Series["Grafik"].Points.AddXY("Karşılaştırılan Türk", int.Parse(oku3[0].ToString()));
                        }
                        baglan.Close();
                        grafik = new SqlCommand("select Count(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateKarsi.Text + "%' and uyruk=0", baglan);
                        baglan.Open();
                        SqlDataReader oku4 = grafik.ExecuteReader();
                        while (oku4.Read())
                        {
                            chart1.Series["Grafik"].Points.AddXY("Karşılaştırılan Yabancı", int.Parse(oku4[0].ToString()));

                        }
                        baglan.Close();

                    }
                }
                if (sorgutipi == 5)
                {
                    chart1.Titles.Add("Tarihlere Göre Toplam Konaklama Geliri (₺)");
                    int gecmissure = 0;
                    if (RadioGun.Checked == true)
                        gecmissure = 7;
                    else if (RadioAy.Checked == true)
                        gecmissure = 3;
                    else
                        gecmissure = 3;
                    for (int i = 0; i < gecmissure; i++)
                    {
                        double asilkonak = 0;
                        double karsikonak = 0;
                        grafik = new SqlCommand("select ToplamOdaFiyati from CikisGecmis where OtelID='" + otelid + "' and Tarih like '" + DateMevcut.Text + "%'", baglan);
                        baglan.Open();
                        SqlDataReader oku = grafik.ExecuteReader();
                        while (oku.Read())
                        {
                            asilkonak += double.Parse(oku[0].ToString());
                        }
                        baglan.Close();
                        chart1.Series["Grafik"].Points.Add(asilkonak);
                        chart1.Series["Grafik"].Points[i].AxisLabel = DateMevcut.Text;
                        if (bunifuToggleSwitch1.Value == true)
                        {
                            grafik = new SqlCommand("select ToplamOdaFiyati from CikisGecmis where OtelID='" + otelid + "' and Tarih like '" + DateKarsi.Text + "%'", baglan);
                            baglan.Open();
                            SqlDataReader oku2 = grafik.ExecuteReader();
                            while (oku2.Read())
                            {
                                karsikonak += double.Parse(oku2[0].ToString());
                            }
                            baglan.Close();

                            chart1.Series["Grafik"].Points.Add(karsikonak);
                            chart1.Series["Grafik"].Points[i + 1].AxisLabel = DateKarsi.Text;
                            break;
                        }
                        else
                        {
                            if (RadioGun.Checked == true)
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddDays(-1);
                                DateMevcut.Value = oncekigun;
                            }
                            else if (RadioAy.Checked == true)
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddMonths(-1);
                                DateMevcut.Value = oncekigun;
                            }
                            else
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddYears(-1);
                                DateMevcut.Value = oncekigun;
                            }
                        }
                    }

                }
                if (sorgutipi == 6)
                {
                    chart1.Titles.Add("Tarihlere Göre Toplam Ürün Geliri (₺)");
                    int gecmissure = 0;
                    if (RadioGun.Checked == true)
                        gecmissure = 7;
                    else if (RadioAy.Checked == true)
                        gecmissure = 3;
                    else
                        gecmissure = 3;
                    for (int i = 0; i < gecmissure; i++)
                    {
                        double asilurun = 0;
                        double karsiurun = 0;
                        grafik = new SqlCommand("select EkstraHarcamalar from CikisGecmis where OtelID='" + otelid + "' and Tarih like '" + DateMevcut.Text + "%'", baglan);
                        baglan.Open();
                        SqlDataReader oku = grafik.ExecuteReader();
                        while (oku.Read())
                        {
                            asilurun += double.Parse(oku[0].ToString());
                        }
                        baglan.Close();
                        chart1.Series["Grafik"].Points.Add(asilurun);
                        chart1.Series["Grafik"].Points[i].AxisLabel = DateMevcut.Text;
                        if (bunifuToggleSwitch1.Value == true)
                        {
                            grafik = new SqlCommand("select EkstraHarcamalar from CikisGecmis where OtelID='" + otelid + "' and Tarih like '" + DateKarsi.Text + "%'", baglan);
                            baglan.Open();
                            SqlDataReader oku2 = grafik.ExecuteReader();
                            while (oku2.Read())
                            {
                                karsiurun += double.Parse(oku2[0].ToString());
                            }
                            baglan.Close();

                            chart1.Series["Grafik"].Points.Add(karsiurun);
                            chart1.Series["Grafik"].Points[i + 1].AxisLabel = DateKarsi.Text;
                            break;
                        }
                        else
                        {
                            if (RadioGun.Checked == true)
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddDays(-1);
                                DateMevcut.Value = oncekigun;
                            }
                            else if (RadioAy.Checked == true)
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddMonths(-1);
                                DateMevcut.Value = oncekigun;
                            }
                            else
                            {
                                DateTime oncekigun = DateMevcut.Value;
                                oncekigun = oncekigun.AddYears(-1);
                                DateMevcut.Value = oncekigun;
                            }
                        }
                    }
                }

                DateMevcut.Value = mevcutasil;
                DateKarsi.Value = karsiasil;
                datepickerchange = true;

                if (bunifuToggleSwitch1.Value == true)
                {
                    chart1.Series["Grafik"].Points[1].Color = Color.Orange;
                    chart1.Series["Grafik"].Points[1].BorderColor = Color.Orange;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void IstatistikYazi()
        {

            try
            {
                if (RadioGun.Checked == true)
                {
                    grafik = new SqlCommand("SELECT Distinct GelisTarihi,GidisTarihi,OdaNo ,DATEDIFF(day,GelisTarihi,GidisTarihi) from GirisGecmis where OtelID='" + otelid + "' and GelisTarihi <= '" + DateMevcut.Text + "' and GidisTarihi >= '" + DateMevcut.Text + "'", baglan);
                    int gunsayi = 0;
                    baglan.Open();
                    SqlDataReader oku = grafik.ExecuteReader();
                    while (oku.Read())
                    {
                        gunsayi += 1;
                    }
                    baglan.Close();
                    DoluOda.Text = gunsayi.ToString();
                }
                else if (RadioAy.Checked == true)
                {
                    grafik = new SqlCommand("SELECT Distinct GelisTarihi,GidisTarihi,OdaNo ,DATEDIFF(day,GelisTarihi,GidisTarihi) from GirisGecmis where OtelID='" + otelid + "' and GelisTarihi like '" + DateMevcut.Text + "%' and GidisTarihi like '" + DateMevcut.Text + "%'", baglan);
                    int gunsayi = 0;
                    baglan.Open();
                    SqlDataReader oku = grafik.ExecuteReader();
                    while (oku.Read())
                    {
                        gunsayi += int.Parse(oku[3].ToString());
                    }
                    baglan.Close();
                    int aydakigun = DateTime.DaysInMonth(DateMevcut.Value.Year, DateMevcut.Value.Month);
                    int a = gunsayi / aydakigun;
                    DoluOda.Text = a.ToString();
                }
                else
                {
                    grafik = new SqlCommand("SELECT Distinct GelisTarihi,GidisTarihi,OdaNo ,DATEDIFF(day,GelisTarihi,GidisTarihi) from GirisGecmis where OtelID='" + otelid + "' and GelisTarihi like '" + DateMevcut.Text + "%' and GidisTarihi like '" + DateMevcut.Text + "%'", baglan);
                    int gunsayi = 0;
                    baglan.Open();
                    SqlDataReader oku = grafik.ExecuteReader();
                    while (oku.Read())
                    {
                        gunsayi += int.Parse(oku[3].ToString());
                    }
                    baglan.Close();
                    int a = gunsayi / 365;
                    DoluOda.Text = a.ToString();
                }





                grafik = new SqlCommand("select COUNT(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateMevcut.Text + "%'", baglan);
                baglan.Open();
                SqlDataReader oku2 = grafik.ExecuteReader();
                while (oku2.Read())
                {
                    RezSayi.Text = oku2[0].ToString();
                }
                baglan.Close();



                double asilciro = 0;
                grafik = new SqlCommand("select Odeme from OdemelerGecmis where OtelID='" + otelid + "' and OdemeTarih like '" + DateMevcut.Text + "%'", baglan);
                baglan.Open();
                SqlDataReader oku3 = grafik.ExecuteReader();
                while (oku3.Read())
                {
                    asilciro += double.Parse(oku3[0].ToString());
                }
                baglan.Close();
                Ciro.Text = asilciro.ToString() + "₺";


                string misafir = "";
                grafik = new SqlCommand("select Count(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateMevcut.Text + "%' and uyruk=1", baglan);
                baglan.Open();
                SqlDataReader oku4 = grafik.ExecuteReader();
                while (oku4.Read())
                {
                    misafir = oku4[0].ToString();
                }
                baglan.Close();
                misafir += "/";
                grafik = new SqlCommand("select Count(*) from RezRapor where OtelID='" + otelid + "' and GelisTarih like '" + DateMevcut.Text + "%' and uyruk=0", baglan);
                baglan.Open();
                SqlDataReader oku5 = grafik.ExecuteReader();
                while (oku5.Read())
                {
                    misafir += oku5[0].ToString();

                }
                baglan.Close();
                Misafirler.Text = misafir;



                double asilkonak = 0;
                grafik = new SqlCommand("select ToplamOdaFiyati from CikisGecmis where OtelID='" + otelid + "' and Tarih like '" + DateMevcut.Text + "%'", baglan);
                baglan.Open();
                SqlDataReader oku6 = grafik.ExecuteReader();
                while (oku6.Read())
                {
                    asilkonak += double.Parse(oku6[0].ToString());
                }
                baglan.Close();
                KonaklamaGelir.Text = asilkonak.ToString() + "₺";




                double asilurun = 0;
                grafik = new SqlCommand("select EkstraHarcamalar from CikisGecmis where OtelID='" + otelid + "' and Tarih like '" + DateMevcut.Text + "%'", baglan);
                baglan.Open();
                SqlDataReader oku7 = grafik.ExecuteReader();
                while (oku7.Read())
                {
                    asilurun += double.Parse(oku7[0].ToString());
                }
                baglan.Close();
                UrunGelir.Text = asilurun.ToString() + "₺";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void PanelOdaSayi_Click(object sender, EventArgs e)
        {
            sorgutipi = 1;
            Grafik();
        }

        private void PanelRezervasyon_Click(object sender, EventArgs e)
        {
            sorgutipi = 2;
            Grafik();
        }

        private void PanelCiro_Click(object sender, EventArgs e)
        {
            sorgutipi = 3;
            Grafik();
        }

        private void PanelMisafir_Click(object sender, EventArgs e)
        {
            sorgutipi = 4;
            Grafik();
        }

        private void PanelKonaklama_Click(object sender, EventArgs e)
        {
            sorgutipi = 5;
            Grafik();
        }

        private void PanelUrun_Click(object sender, EventArgs e)
        {
            sorgutipi = 6;
            Grafik();
        }

        private void DateMevcut_ValueChanged(object sender, EventArgs e)
        {
            if(datepickerchange==true)
            Grafik();
            IstatistikYazi();
        }

        private void DateKarsi_ValueChanged(object sender, EventArgs e)
        {
            if(datepickerchange==true)
            Grafik();
        }

        private void bunifuToggleSwitch1_OnValuechange(object sender, EventArgs e)
        {
            Grafik();
            if (bunifuToggleSwitch1.Value == true)
            {
                DateKarsi.ForeColor=Color.Magenta;
                DateKarsi.Color = Color.Magenta;
                DateKarsi.IconColor = Color.Magenta;
            }
            else
            {
                DateKarsi.Color = Color.Gray;
                DateKarsi.ForeColor= Color.Gray;
                DateKarsi.IconColor = Color.Gray;
            }
        }

        private void Istatistikler_Load(object sender, EventArgs e)
        {
            bunifuToggleSwitch1.Value = false;
            IstatistikYazi();
            sorgutipi = 1;
            Grafik();
        }

    }
}
