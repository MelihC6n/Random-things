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
    public partial class YoneticiPanel : Form
    {
        int otelid = Login.id;
        SqlConnection baglan = new SqlConnection(Login.veritabani);
        SqlCommand grafik;


        public YoneticiPanel()
        {
            InitializeComponent();
        }

        private void YoneticiPanel_Load(object sender, EventArgs e)
        {
            Veriler();
        }

        private void Veriler()
        {

            chart1.ChartAreas[0].AxisX.IsReversed = true;
            Tarih.Format = DateTimePickerFormat.Custom;
            DateTime mevcutasil = Tarih.Value;

            for (int i = 0; i < 7; i++)
            {
                int gunsayi = 0;
                int misafirsayi = 0;
                grafik = new SqlCommand("SELECT DATEDIFF(day,GelisTarihi,GidisTarihi) from GirisGecmis where OtelID='" + otelid + "' and GelisTarihi <= '" + Tarih.Text + "' and GidisTarihi >= '" + Tarih.Text + "'", baglan);
                baglan.Open();
                SqlDataReader oku = grafik.ExecuteReader();
                while (oku.Read())
                {
                    gunsayi += 1;

                }
                if (i == 0)
                {
                    Misafir.Text = gunsayi.ToString();
                }
                chart1.Series["Grafik"].Points.Add(int.Parse(gunsayi.ToString()));
                chart1.Series["Grafik"].Points[i].AxisLabel = Tarih.Text;
                baglan.Close();


                DateTime oncekigun = Tarih.Value;
                oncekigun = oncekigun.AddDays(-1);
                Tarih.Value = oncekigun;
            }

            DateTime oncekigun2 = Tarih.Value;
            oncekigun2 = oncekigun2.AddDays(7);
            Tarih.Value = oncekigun2;

            grafik = new SqlCommand("select COUNT(*) from Kullanicilar where OtelID='" + otelid + "'", baglan);
            baglan.Open();
            SqlDataReader oku2 = grafik.ExecuteReader();
            while (oku2.Read())
            {
                Personel.Text = oku2[0].ToString();
            }
            baglan.Close();

            double gelir = 0;
            grafik = new SqlCommand("select Odeme from OdemelerGecmis where OtelID='" + otelid + "' and OdemeTarih like '" + Tarih.Text + "%'", baglan);
            baglan.Open();
            SqlDataReader oku3 = grafik.ExecuteReader();
            while (oku3.Read())
            {
                gelir += double.Parse(oku3[0].ToString());
            }
            baglan.Close();
            Gelir.Text = gelir.ToString() + "₺";


            int odasayisi = 0;
            grafik = new SqlCommand("select Count(*) from Odalar where OtelID='" + otelid + "'", baglan);
            baglan.Open();
            SqlDataReader oku4 = grafik.ExecuteReader();
            while (oku4.Read())
            {
                odasayisi = int.Parse(oku4[0].ToString());
            }
            baglan.Close();

            int doluoda = 0;
            grafik = new SqlCommand("select Count(*) from Odalar where OtelID='" + otelid + "' and Durum=1", baglan);
            baglan.Open();
            SqlDataReader oku5 = grafik.ExecuteReader();
            while (oku5.Read())
            {
                doluoda = int.Parse(oku5[0].ToString());
            }
            baglan.Close();

            try
            {
            int yuzde = doluoda * 100 / odasayisi;
            bunifuCircleProgress2.Value = yuzde;
            }
            catch (Exception)
            {
                bunifuCircleProgress2.Value = 0;
            }

            
            



            Tarih.Value = mevcutasil;
            Tarih.Format = DateTimePickerFormat.Long;

        }

    }
}
