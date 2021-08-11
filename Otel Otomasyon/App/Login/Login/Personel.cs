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
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }
        int OtelID = Login.id;
        SqlConnection baglanti = new SqlConnection(Login.veritabani);
        SqlConnection baglanti2 = new SqlConnection(Login.veritabani);
        private void Personel_Load(object sender, EventArgs e)
        {
            try
            {
                yenile();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        void yenile()
        {
            baglanti.Open();
            SqlDataAdapter komut = new SqlDataAdapter("select Ad as PersonelAd,Soyad as PersonelSoyad,KullaniciAdi as KullanıcıAdı from Kullanicilar where OtelID='" + OtelID + "'", baglanti);
            DataTable dt = new DataTable();
            komut.Fill(dt);
            personneller.DataSource = dt;
            personneller.Columns[0].FillWeight = 100;
            personneller.Columns[1].FillWeight = 100;
            personneller.Columns[2].FillWeight = 100;
            baglanti.Close();

        }
        private void PersonelEkle_Click(object sender, EventArgs e)
        {
            if (pad.Text == "" || psoyad.Text == "" || ksifre.Text == "" || kad.Text == "")
                MessageBox.Show("Lütfen bütün bilgileri doldurun.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into Kullanicilar values('" + OtelID + "','" + pad.Text + "','" + psoyad.Text + "','" + kad.Text + "','" + ksifre.Text + "','" + false + "','" + false + "','" + false + "','" + false + "','" + false + "','" + false + "','" + false + "')", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    pad.Text = "";
                    psoyad.Text = "";
                    kad.Text = "";
                    ksifre.Text = "";
                    MessageBox.Show("Personel başarıyla eklenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    yenile();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Personneller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int a = personneller.CurrentRow.Index;
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from Kullanicilar where KullaniciAdi='" + personneller.Rows[a].Cells[2].Value.ToString() + "' and OtelID='" + OtelID + "'", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    rezsecim.Value = Convert.ToBoolean(dr[5].ToString());
                    ressecim.Value = Convert.ToBoolean(dr[6].ToString());
                    prosecim.Value = Convert.ToBoolean(dr[7].ToString());
                    raporsecim.Value = Convert.ToBoolean(dr[8].ToString());
                    odasecim.Value = Convert.ToBoolean(dr[9].ToString());
                    katsecim.Value = Convert.ToBoolean(dr[10].ToString());
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Rezsecim_OnValuechange(object sender, EventArgs e)
        {
            try
            {
                int a = personneller.CurrentRow.Index;
                baglanti2.Open();
                SqlCommand komut = new SqlCommand("update Kullanicilar set Rezervasyon='" + Convert.ToBoolean((rezsecim.Value)) + "' where Kullaniciadi='" + personneller.Rows[a].Cells[2].Value.ToString() + "' and OtelID='" + OtelID + "'", baglanti2);
                komut.ExecuteNonQuery();
                baglanti2.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Ressecim_OnValuechange(object sender, EventArgs e)
        {
            try
            {
                int a = personneller.CurrentRow.Index;
                baglanti2.Open();
                SqlCommand komut = new SqlCommand("update Kullanicilar set Resepsiyon='" + Convert.ToBoolean((ressecim.Value)) + "' where Kullaniciadi='" + personneller.Rows[a].Cells[2].Value.ToString() + "' and OtelID='" + OtelID + "'", baglanti2);
                komut.ExecuteNonQuery();
                baglanti2.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Prosecim_OnValuechange(object sender, EventArgs e)
        {
            try
            {
                int a = personneller.CurrentRow.Index;
                baglanti2.Open();
                SqlCommand komut = new SqlCommand("update Kullanicilar set Profiller='" + Convert.ToBoolean((prosecim.Value)) + "' where Kullaniciadi='" + personneller.Rows[a].Cells[2].Value.ToString() + "' and OtelID='" + OtelID + "'", baglanti2);
                komut.ExecuteNonQuery();
                baglanti2.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Raporsecim_OnValuechange(object sender, EventArgs e)
        {
            try
            {
                int a = personneller.CurrentRow.Index;
                baglanti2.Open();
                SqlCommand komut = new SqlCommand("update Kullanicilar set Raporlar='" + Convert.ToBoolean((raporsecim.Value)) + "' where Kullaniciadi='" + personneller.Rows[a].Cells[2].Value.ToString() + "' and OtelID='" + OtelID + "'", baglanti2);
                komut.ExecuteNonQuery();
                baglanti2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Odasecim_OnValuechange(object sender, EventArgs e)
        {
            try
            {
                int a = personneller.CurrentRow.Index;
                baglanti2.Open();
                SqlCommand komut = new SqlCommand("update Kullanicilar set OdaServisi='" + Convert.ToBoolean((odasecim.Value)) + "' where Kullaniciadi='" + personneller.Rows[a].Cells[2].Value.ToString() + "' and OtelID='" + OtelID + "'", baglanti2);
                komut.ExecuteNonQuery();
                baglanti2.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Katsecim_OnValuechange(object sender, EventArgs e)
        {
            try
            {
                int a = personneller.CurrentRow.Index;
                baglanti2.Open();
                SqlCommand komut = new SqlCommand("update Kullanicilar set KatHizmetleri='" + Convert.ToBoolean((katsecim.Value)) + "' where Kullaniciadi='" + personneller.Rows[a].Cells[2].Value.ToString() + "' and OtelID='" + OtelID + "'", baglanti2);                komut.ExecuteNonQuery();
                baglanti2.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void PersonelSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Personeli silmek üzeresiniz ,onaylıyor musunuz?", "Bilgilendirme", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int a = personneller.CurrentRow.Index;
                    baglanti2.Open();
                    SqlCommand komut = new SqlCommand("delete from Kullanicilar where Kullaniciadi='" + personneller.Rows[a].Cells[2].Value.ToString() + "' and OtelID='" + OtelID + "'", baglanti2);
                    komut.ExecuteNonQuery();
                    baglanti2.Close();
                    MessageBox.Show("Personel başarıyla silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    yenile();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Pad_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }
        void sayi(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        void harf(KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void Psoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void Ksifre_OnValueChanged(object sender, EventArgs e)
        {
            if (ksifre.Text.Length == 8)
            {
                hata.Text = "Şifre 8 karakterden uzun olamaz";
            }
            else
                hata.Text = "";
        }
    }
}
