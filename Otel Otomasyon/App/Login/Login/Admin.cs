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
    public partial class Admin : Form
    {
        SqlConnection baglanti = new SqlConnection(Login.veritabani);

        public Admin()
        {
            InitializeComponent();
        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(otelad.Text!="" && oteladres.Text!="" && ad.Text!="" && soyad.Text!="" && kad.Text!="" && ksifre.Text!="")
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("insert into Oteller(OtelAd,OtelAdres,KatSayisi) values('" + otelad.Text + "','" + oteladres.Text + "',0)", baglanti);
                    baglanti.Open();
                    ekle.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    int otelid = 0;
                    SqlCommand oku = new SqlCommand("select OtelID from Oteller where OtelAd='" + otelad.Text + "' and OtelAdres='" + oteladres.Text + "' and KatSayisi=0", baglanti);
                    SqlDataReader getir = oku.ExecuteReader();
                    while (getir.Read())
                    {
                        otelid = int.Parse(getir[0].ToString());
                    }
                    baglanti.Close();
                    SqlCommand ekle2 = new SqlCommand("insert into Kullanicilar values('" + otelid + "','" + ad.Text + "','" + soyad.Text + "','" + kad.Text + "','" + ksifre.Text + "','" + true + "','" + true + "','" + true + "','" + true + "','" + true + "','" + true + "','" + true + "')", baglanti);
                    baglanti.Open();
                    ekle2.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Otel başarıyla eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
