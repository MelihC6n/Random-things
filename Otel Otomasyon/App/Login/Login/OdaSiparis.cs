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
using Microsoft.VisualBasic;

namespace Login
{
    public partial class OdaSiparis : Form
    {
        SqlConnection baglan = new SqlConnection(Login.veritabani);
        SqlConnection baglan2 = new SqlConnection(Login.veritabani);

        int otelid = Login.id;

        public OdaSiparis()
        {
            InitializeComponent();
        }

        private void OdaSiparis_Load(object sender, EventArgs e)
        {
            ListleriYenile();
        }

        public void ListleriYenile()
        {
            try
            {
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox2.Items.Add("Açık Yiyecek");
                listBox3.Items.Add("Açık İçecek");
                TxtIcecekFiyat.Enabled = false;
                TxtYiyecekFiyat.Enabled = false;
                CmbOda.Items.Clear();
                SqlCommand odalist = new SqlCommand("select OdaNo from Odalar where OtelId='" + otelid + "' and Durum=1", baglan);
                baglan.Open();
                SqlDataReader getir = odalist.ExecuteReader();
                while (getir.Read())
                {
                    CmbOda.Items.Add(getir[0]);
                }
                baglan.Close();

                SqlCommand yiyecek = new SqlCommand("select YiyecekAd from Yiyecekler where OtelID='" + otelid + "'", baglan);
                baglan.Open();
                SqlDataReader getiry = yiyecek.ExecuteReader();
                while (getiry.Read())
                {
                    listBox2.Items.Add(getiry[0]);
                }
                baglan.Close();

                SqlCommand icecek = new SqlCommand("select IcecekAd from Icecekler where OtelID='" + otelid + "'", baglan);
                baglan.Open();
                SqlDataReader getiri = icecek.ExecuteReader();
                while (getiri.Read())
                {
                    listBox3.Items.Add(getiri[0]);
                }
                baglan.Close();
                DataGridYenile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TxtYiyecekAd.Text = listBox2.SelectedItem.ToString();
            }
            catch (Exception)
            { 
            }
            
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TxtIcecekAd.Text = listBox3.SelectedItem.ToString();
            }
            catch (Exception)
            { 
            }
            
        }

        private void TxtYiyecekAd_TextChanged(object sender, EventArgs e)
        {
            if (TxtYiyecekAd.Text == "Açık Yiyecek")
            {
                numericUpDown1.Text = "1";
                TxtYiyecekFiyat.Text = "0";
                TxtYiyecekFiyat.Enabled = true;
                listBox2.Items.Clear();
            }
            else
            {
                TxtYiyecekFiyat.Enabled = false;
                listBox2.Items.Clear();
                try
                {
                    SqlCommand yiyecek = new SqlCommand("select YiyecekAd from Yiyecekler where OtelID='" + otelid + "' and YiyecekAd like '%" + TxtYiyecekAd.Text + "%'", baglan);
                    baglan.Open();
                    SqlDataReader getiry = yiyecek.ExecuteReader();
                    while (getiry.Read())
                    {
                        listBox2.Items.Add(getiry[0]);
                    }
                    baglan.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                try
                {
                    if (TxtYiyecekAd.Text == listBox2.Items[0].ToString())
                    {
                        numericUpDown1.Text = "2";
                        numericUpDown1.Text = "1";
                    }
                    else if (TxtYiyecekAd.Text == "")
                    {
                        listBox2.Items.Insert(0, "Açık Yiyecek");
                        numericUpDown1.Text = "1";
                        TxtYiyecekFiyat.Text = "0";
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void TxtIcecekAd_TextChanged(object sender, EventArgs e)
        {
            if (TxtIcecekAd.Text == "Açık İçecek")
            {
                numericUpDown2.Text = "1";
                TxtIcecekFiyat.Text = "0";
                TxtIcecekFiyat.Enabled = true;
                listBox3.Items.Clear();
            }
            else
            {
                TxtIcecekFiyat.Enabled = false;
                listBox3.Items.Clear();
                try
                {
                    SqlCommand icecek = new SqlCommand("select IcecekAd from Icecekler where OtelID='" + otelid + "' and IcecekAd like '%" + TxtIcecekAd.Text + "%'", baglan);
                    baglan.Open();
                    SqlDataReader getiri = icecek.ExecuteReader();
                    while (getiri.Read())
                    {
                        listBox3.Items.Add(getiri[0]);
                    }
                    baglan.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                try
                {
                    if (TxtIcecekAd.Text == listBox3.Items[0].ToString())
                    {
                        numericUpDown2.Text = "2";
                        numericUpDown2.Text = "1";
                    }
                    else if (TxtIcecekAd.Text == "")
                    {
                        listBox3.Items.Insert(0, "Açık İçecek");
                        numericUpDown2.Text = "1";
                        TxtIcecekFiyat.Text = "0";
                    }

                }
                catch (Exception)
                {

                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand yiyecek = new SqlCommand("select YiyecekFiyat from Yiyecekler where OtelID='" + otelid + "' and YiyecekAd='" + TxtYiyecekAd.Text + "'", baglan);
                baglan.Open();
                SqlDataReader getiry = yiyecek.ExecuteReader();
                while (getiry.Read())
                {
                    TxtYiyecekFiyat.Text = (double.Parse(getiry[0].ToString()) * double.Parse(numericUpDown1.Value.ToString())).ToString();
                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (TxtYiyecekAd.Text == "Açık Yiyecek" && TxtAcikYiyecekAd.Text != "")
            {
                if (TxtYiyecekFiyat.Text != "")
                {
                    if (numericUpDown1.Value > 0 && double.Parse(TxtYiyecekFiyat.Text) > 0)
                    {
                    listBox1.Items.Add(numericUpDown1.Text + "-" + TxtAcikYiyecekAd.Text + " = " + TxtYiyecekFiyat.Text);
                    TxtYiyecekAd.Text = "";
                    TxtAcikYiyecekAd.Text = "";
                    }
                    else
                    MessageBox.Show("Lütfen açık yiyeceğe adet,ve tutar giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                    MessageBox.Show("Tutar alanı boş geçilemez.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {
                SqlCommand yiyecek = new SqlCommand("select YiyecekAd from Yiyecekler where OtelID='" + otelid + "' and YiyecekAd='" + TxtYiyecekAd.Text + "'", baglan);
                baglan.Open();
                SqlDataReader onay = yiyecek.ExecuteReader();
                onay.Read();
            try {
                    if (onay[0].ToString() != "")
                    {
                        if (numericUpDown1.Value > 0 && double.Parse(TxtYiyecekFiyat.Text) > 0 && TxtYiyecekFiyat.Text != "")
                        {
                            listBox1.Items.Add(numericUpDown1.Text + "-" + TxtYiyecekAd.Text + " = " + TxtYiyecekFiyat.Text);
                        }
                        else
                            MessageBox.Show("Lütfen açık yiyeceğe adet,ve tutar giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                     }
            }
            catch (Exception)
            {
                MessageBox.Show("Böyle bir ürün bulunmamakta.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
            baglan.Close();
            TxtYiyecekAd.Text = "";
            TxtAcikYiyecekAd.Text = "";
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            if (TxtIcecekAd.Text == "Açık İçecek" && TxtAcikIcecekAd.Text != "")
            {
                if(TxtIcecekFiyat.Text != "")
                {
                   if (numericUpDown2.Value > 0 && double.Parse(TxtIcecekFiyat.Text) > 0)
                   {
                       listBox1.Items.Add(numericUpDown2.Text + "-" + TxtAcikIcecekAd.Text + " = " + TxtIcecekFiyat.Text);
                       TxtIcecekAd.Text = "";
                       TxtAcikIcecekAd.Text = "";
                   }
                   else
                       MessageBox.Show("Lütfen açık içeceğe adet,ve tutar giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                    MessageBox.Show("Tutar alanı boş geçilemez.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            { 
            SqlCommand icecek = new SqlCommand("select IcecekAd from Icecekler where OtelID='" + otelid + "' and IcecekAd='" + TxtIcecekAd.Text + "'", baglan);
            baglan.Open();
            SqlDataReader onay = icecek.ExecuteReader();
            onay.Read();
            try
            {
                if (onay[0].ToString() != "")
                {
                     if (numericUpDown2.Value > 0 && double.Parse(TxtIcecekFiyat.Text) > 0 && TxtIcecekFiyat.Text != "")
                     {
                         listBox1.Items.Add(numericUpDown2.Text + "-" + TxtIcecekAd.Text + " = " + TxtIcecekFiyat.Text);
                     }
                     else
                         MessageBox.Show("Lütfen açık içeceğe adet,ve tutar giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Böyle bir ürün bulunmamakta.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            baglan.Close();
            TxtIcecekAd.Text = "";
            TxtAcikIcecekAd.Text = "";
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            CmbOda.Text = "";
            TxtYiyecekAd.Text = "";
            TxtIcecekAd.Text = "";
            numericUpDown1.Text = "";
            numericUpDown2.Text = "";
            TxtIcecekFiyat.Text = "";
            TxtYiyecekFiyat.Text = "";
            TxtAcikIcecekAd.Text = "";
            TxtAcikYiyecekAd.Text = "";
            listBox1.Items.Clear();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            SqlCommand odakontrol = new SqlCommand("select OdaNo from Odalar where OtelID='"+otelid+"' and OdaNo='"+CmbOda.Text+"'",baglan);
            baglan.Open();
            SqlDataReader kontroloku = odakontrol.ExecuteReader();
            kontroloku.Read();
            try
            {
                if (kontroloku[0].ToString() != "" && listBox1.Items.Count > 0)
                {
                    string siparis = "";
                    float tutar=0;
                    for (int a = 0; a < listBox1.Items.Count; a++)
                    {
                        string ayir = listBox1.Items[a].ToString();
                        string[] tutarayir = ayir.Split('=');
                        tutar = tutar + float.Parse(tutarayir[1]);
                        siparis += listBox1.Items[a];
                        if (a != listBox1.Items.Count - 1)
                        { siparis += " / "; }
                    }
                    baglan2.Open();
                    string tutargir = tutar.ToString().Replace(",", ".");
                    SqlCommand ekle = new SqlCommand("insert into Siparisler(OtelID,OdaNo,Siparis,Tutar,SiparisDurum) values(" + otelid + "," + CmbOda.Text + ",'" + siparis + "',"+tutargir+",1)", baglan2);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Siparişler başarıyla eklendi.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglan2.Close();
                    listBox1.Items.Clear();
                    CmbOda.Text = null;
                }
                else if (kontroloku[0].ToString() != "" && listBox1.Items.Count == 0)
                {
                    MessageBox.Show("Lütfen sipariş için ürünler seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen sipariş için oda ve ürünler seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
             baglan.Close();
            DataGridYenile();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand icecek = new SqlCommand("select IcecekFiyat from Icecekler where OtelID='" + otelid + "' and IcecekAd='" + TxtIcecekAd.Text + "'", baglan);
                baglan.Open();
                SqlDataReader getiri = icecek.ExecuteReader();
                while (getiri.Read())
                {
                    TxtIcecekFiyat.Text = (double.Parse(getiri[0].ToString()) * double.Parse(numericUpDown2.Value.ToString())).ToString();
                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            
        }

        private void numericUpDown2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            
        }

        private void TxtYiyecekFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';

        }

        private void TxtIcecekFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {if(listBox1.SelectedItem.ToString()!="")
                { 
                DialogResult cevap = MessageBox.Show("Bu sipariş listeden silinecek, emin misiniz", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
            catch (Exception)
            {

            }
        }

        private void TxtAcikYiyecekAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsPunctuation(e.KeyChar);
        }

        private void TxtAcikIcecekAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsPunctuation(e.KeyChar);
        }

        private void DataGridYenile()
        {
            try
            {
                int a = 0;
                bunifuCustomDataGrid1.Rows.Clear();
                SqlCommand yenile = new SqlCommand("select SiparisID,OdaNo,Siparis,Tutar from Siparisler where OtelID='" + otelid + "' and SiparisDurum=1", baglan);
                baglan.Open();
                SqlDataReader getir = yenile.ExecuteReader();
                while (getir.Read())
                {
                    bunifuCustomDataGrid1.Rows.Add();
                    bunifuCustomDataGrid1.Rows[a].Cells[0].Value = getir[0];
                    bunifuCustomDataGrid1.Rows[a].Cells[1].Value = getir[1];
                    bunifuCustomDataGrid1.Rows[a].Cells[2].Value = getir[2];
                    bunifuCustomDataGrid1.Rows[a].Cells[3].Value = float.Parse(getir[3].ToString()) + "₺";
                    a++;

                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void bunifuCustomDataGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int satır = bunifuCustomDataGrid1.CurrentRow.Index;
                DialogResult cevap = MessageBox.Show("Siparişi tamamlandığını onaylıyor musunuz?" + "\n" + "Onaylamak için EVET," + "\n" + "Siparişten çıkmak için HAYIR" + "\n" + "Siparişi iptal etmek içn İPTAL'e basınız.", "ODA " + bunifuCustomDataGrid1.Rows[satır].Cells[0].Value.ToString() + " SİPARİŞİ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                baglan.Open();
                if (cevap == DialogResult.Yes)
                {
                    SqlCommand onay = new SqlCommand("update Siparisler set SiparisDurum=0 where SiparisID=" + bunifuCustomDataGrid1.Rows[satır].Cells[0].Value + "", baglan);
                    onay.ExecuteNonQuery();
                    MessageBox.Show("Sipariş tamamlandı.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                double tutar=0;
                SqlCommand tutartopla = new SqlCommand("select Tutar from Siparisler where SiparisDurum=0 and OdaNo='" + bunifuCustomDataGrid1.Rows[satır].Cells[1].Value + "' and OtelID='" + otelid + "'", baglan2);
                baglan2.Open();
                SqlDataReader getir = tutartopla.ExecuteReader();
                while(getir.Read())
                {
                    tutar+=double.Parse(getir[0].ToString());
                }
                baglan2.Close();
                    double odafiyat = 0;
                    double odenecek = 0;
                    SqlCommand odafiyattopla = new SqlCommand("select ToplamOdaFiyati,OdenecekTutar from K_Cikis where OdaNo='" + bunifuCustomDataGrid1.Rows[satır].Cells[1].Value + "' and OtelID='" + otelid + "'", baglan2);
                    baglan2.Open();
                    SqlDataReader topla = odafiyattopla.ExecuteReader();
                    while (topla.Read())
                    {
                        odafiyat = double.Parse(topla[0].ToString());
                        odenecek = double.Parse(topla[1].ToString());
                    }
                    baglan2.Close();
                    SqlCommand update = new SqlCommand("update K_Cikis set EkstraHarcamalar=@extra,GenelToplam=@genel,OdenecekTutar=@odenecek where OdaNo='" + bunifuCustomDataGrid1.Rows[satır].Cells[1].Value + "' and OtelID='" + otelid + "'", baglan);
                    update.Parameters.AddWithValue("@extra", tutar);
                    update.Parameters.AddWithValue("@genel", odafiyat+tutar);
                    string isaretcikar = bunifuCustomDataGrid1.Rows[satır].Cells[3].Value.ToString();
                    isaretcikar = isaretcikar.Replace("₺", "");
                    update.Parameters.AddWithValue("@odenecek", odenecek+double.Parse(isaretcikar));
                    update.ExecuteNonQuery();
                }
                else if (cevap == DialogResult.Cancel)
                {
                    SqlCommand sil = new SqlCommand("delete from Siparisler where SiparisID=" + bunifuCustomDataGrid1.Rows[satır].Cells[0].Value + "", baglan);
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Sipariş iptal edildi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                baglan.Close();
                DataGridYenile();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

}
    }
}
