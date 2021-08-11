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
    public partial class Rezervasyon : Form
    {
        public int OtelID = Login.id;
        public Rezervasyon()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Login.veritabani);

        private void Ara_Click(object sender, EventArgs e)
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
                baglanti.Open();
                SqlCommand da = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where ad='" + tc_noveyaad.Text + "' and OtelID='" + OtelID + "' ", baglanti);
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
                baglanti.Close();
            }

        }

        private void Tc_noveyaad_OnValueChanged(object sender, EventArgs e)
        {

            if (tc_noveyaad.Text.Length > 0)
            {
                gel_aralik.Value = false;
                radiotc.Enabled = false;
                radiotc.Checked = false;
                radioyabanci.Enabled = false;
                radioyabanci.Checked = false;
                gel_tar.Enabled = false;
                gel_tar.IconColor = Color.Gray;
                gel_tar2.Enabled = false;
                gel_tar2.IconColor = Color.Gray;
                gel_tar2.Enabled = false;
            }
            else
            {
                radiotc.Enabled = true;
                radioyabanci.Enabled = true;
                gel_tar.Enabled = true;
                gel_tar.IconColor = Color.Green;
                rapor.Rows.Clear();
            }
        }

        private void Rapor_Goster_Click(object sender, EventArgs e)
        {
            try
            {
                gel_tar.CustomFormat = "MM/dd/yyyy";
                gel_tar2.CustomFormat = "MM/dd/yyyy";
                gel_tar.Format = DateTimePickerFormat.Custom;
                gel_tar2.Format = DateTimePickerFormat.Custom;

                if (radiotc.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where (GelisTarih BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and uyruk='Turkey' and OtelID='" + OtelID + "'", baglanti);
                    verigetir(komut);
                }
                else if (radioyabanci.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where (GelisTarih BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and uyruk<>'Turkey' and OtelID='" + OtelID + "'", baglanti);
                    verigetir(komut);
                }
                else if (radio_hepsi.Checked == true)
                {
                    SqlCommand komut = new SqlCommand("select TcNo,GelisTarih,ad,soyad,uyruk from RezRaporV where (GelisTarih BETWEEN '" + gel_tar.Text + "' and '" + gel_tar2.Text + "') and (uyruk='Turkey' or uyruk<>'Turkey') and OtelID='" + OtelID + "'", baglanti);
                    verigetir(komut);
                }
                gel_tar.Format = DateTimePickerFormat.Long;
                gel_tar2.Format = DateTimePickerFormat.Long;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        void verigetir(SqlCommand a)
        {
            rapor.Rows.Clear();
            baglanti.Open();

            if (gel_aralik.Value == true)
            {
                SqlDataReader oku = a.ExecuteReader();
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

            }
            else
            {
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

            }
            baglanti.Close();
        }

        private void Rezervasyon_Load(object sender, EventArgs e)
        {
            gel_aralik.Value = false;
            radiotc.Checked = false;
            radioyabanci.Checked = false;
            radio_hepsi.Checked = true;
            gel_tar.MinDate = DateTime.Now;
            gel_tar2.MinDate = DateTime.Now;
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
                rapor.Rows[sayac].Cells[4].Value =oku[4].ToString(); 
                sayac++;
            }
            baglanti.Close();

        }

        private void Gel_aralik_OnValuechange(object sender, EventArgs e)
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

        private void Gel_tar_ValueChanged(object sender, EventArgs e)
        {
            gel_tar2.MinDate = gel_tar.MinDate;
        }
    }
}
