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
    public partial class UrunEkle : Form
    {
        SqlConnection baglan = new SqlConnection(Login.veritabani);
        SqlConnection baglan2 = new SqlConnection(Login.veritabani);

        int otelid = Login.id;

        public UrunEkle()
        {
            InitializeComponent();
        }

        private void TxtYiyecekFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtIcecekFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtYiyecekAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsPunctuation(e.KeyChar);

        }

        private void TxtIcecekAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsPunctuation(e.KeyChar);

        }
        private void DataGridYenile1()
        {
            try
            {
                int a = 0;
                bunifuCustomDataGrid1.Rows.Clear();
                SqlCommand yenile = new SqlCommand("select YiyecekAd,YiyecekFiyat from Yiyecekler where OtelID='" + otelid + "'", baglan);
                baglan.Open();
                SqlDataReader getir = yenile.ExecuteReader();
                while (getir.Read())
                {
                    bunifuCustomDataGrid1.Rows.Add();
                    bunifuCustomDataGrid1.Rows[a].Cells[0].Value = getir[0];
                    bunifuCustomDataGrid1.Rows[a].Cells[1].Value = double.Parse(getir[1].ToString()) + "₺";
                    a++;
                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void DataGridYenile2()
        {
            try
            {
                int a = 0;
                bunifuCustomDataGrid2.Rows.Clear();
                SqlCommand yenile = new SqlCommand("select IcecekAd,IcecekFiyat from Icecekler where OtelID='" + otelid + "'", baglan);
                baglan.Open();
                SqlDataReader getir = yenile.ExecuteReader();
                while (getir.Read())
                {
                    bunifuCustomDataGrid2.Rows.Add();
                    bunifuCustomDataGrid2.Rows[a].Cells[0].Value = getir[0];
                    bunifuCustomDataGrid2.Rows[a].Cells[1].Value = double.Parse(getir[1].ToString()) + "₺";
                    a++;
                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {
            DataGridYenile1();
            DataGridYenile2();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtYiyecekAd.Text != "" && TxtYiyecekFiyat.Text != "")
                {
                    SqlCommand sayi = new SqlCommand("select count(YiyecekAd) from Yiyecekler where YiyecekAd='" + TxtYiyecekAd.Text + "' and OtelId='" + otelid + "'", baglan);
                    baglan.Open();
                    SqlDataReader oku = sayi.ExecuteReader();
                    while (oku.Read())
                    {
                        if (int.Parse(oku[0].ToString()) == 0)
                        {
                            string tutargir = TxtYiyecekFiyat.Text.ToString().Replace(",", ".");
                            SqlCommand yiyecekekle = new SqlCommand("insert into Yiyecekler values('" + otelid + "','" + TxtYiyecekAd.Text + "','" + tutargir + "')", baglan2);
                            baglan2.Open();
                            yiyecekekle.ExecuteNonQuery();
                            baglan2.Close();
                            MessageBox.Show("Yiyecek eklendi.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Aynı isimde yiyecek mevcut.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    baglan.Close();
                    DataGridYenile1();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtIcecekAd.Text != "" && TxtIcecekFiyat.Text != "")
                {
                    SqlCommand sayi = new SqlCommand("select count(IcecekAd) from Icecekler where IcecekAd='" + TxtIcecekAd.Text + "' and OtelId='" + otelid + "'", baglan);
                    baglan.Open();
                    SqlDataReader oku = sayi.ExecuteReader();
                    while (oku.Read())
                    {
                        if (int.Parse(oku[0].ToString()) == 0)
                        {
                            string tutargir = TxtIcecekFiyat.Text.ToString().Replace(",", ".");
                            SqlCommand icecekekle = new SqlCommand("insert into Icecekler values('" + otelid + "','" + TxtIcecekAd.Text + "','" + tutargir + "')", baglan2);
                            baglan2.Open();
                            icecekekle.ExecuteNonQuery();
                            baglan2.Close();
                            MessageBox.Show("İçecek eklendi.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                            MessageBox.Show("Aynı isimde yiyecek mevcut.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    baglan.Close();
                    DataGridYenile2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void UrunEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            var yenilet = (OdaSiparis)Application.OpenForms["OdaSiparis"];
            if (yenilet != null)
                yenilet.ListleriYenile();
        }

    }
}
