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
    public partial class Odalar : Form
    {
        public Odalar()
        {
            InitializeComponent();
        }
        int OtelID = Login.id;

        SqlConnection baglanti = new SqlConnection(Login.veritabani);
        SqlConnection baglanti2 = new SqlConnection(Login.veritabani);
        public int taslakonay = 1;
        public int Katsayisi;
        private void Katekle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eğer otel kurulumu(kat ve kattaki odaların içerikleri doldurulmadan) tamamlanmadan bu sayfadan çıkılırsa mevcut veriler silinecektir ve tekrardan kurulumu yapmanız gerekecektir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            try
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from OdalarTaslak where OtelID='" + OtelID + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception)
            {

                
            }
                

            if(kat.Text.Length>0)
            {
                ykat.Items.Clear();
                ykat.Text = "";
                for (int i = 1; i <= int.Parse(kat.Text); i++)
                {
                    ykat.Items.Add(i+".Kat");
                }
                Katsayisi = int.Parse(kat.Text);
            }
            else
                MessageBox.Show("Lütfen kat sayısı girin.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        
        private void OdaEkle_Click(object sender, EventArgs e)
        {
            

            if (kat.Text.Length > 0)
            {
                if (katoda.Text.Length > 0)
                {
                    odasecim.Items.Clear();
                    int oda = int.Parse(katoda.Text);
                    for (int i = 1; i <= oda; i++)
                    {
                        if(ykat.SelectedItem!=null)
                        { 
                            ykat.Enabled = false;
                        katoda.Enabled = false;
                        odasecim.Items.Add(((int.Parse(ykat.SelectedItem.ToString().Substring(0, 1)) * 100) + i).ToString(), false);
                        }
                    }
                }
                else
                    MessageBox.Show("Lütfen oda sayısı girin.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Lütfen kat sayısı girin.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        int odatip;
        void sayi(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Kat_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi(e);
        }

        private void Katoda_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi(e);
        }

        private void Fiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi(e);
        }

        private void Odalar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select Count(*) From Odalar where OtelID='"+OtelID+"'",baglanti);
            SqlDataReader dr1 = komut5.ExecuteReader();
            while (dr1.Read())
            {
                if (int.Parse(dr1[0].ToString()) == 0)
                {

                }
                else
                {
                    guncellekat.Enabled = true;
                    guncelleoda.Enabled = true;
                    guncelletr.Enabled = true;
                    guncelletsu.Enabled = true;
                    guncelletwr.Enabled = true;
                    guncellesgl.Enabled = true;
                    guncellequad.Enabled = true;
                    guncelledbl.Enabled = true;
                    guncellefiyat.Enabled = true;
                    guncelleodasecim.Enabled = true;
                    Güncelle.Enabled = true;

                    kat.Enabled = false;
                    Katekle.Enabled = false;
                    ykat.Enabled = false;
                    katoda.Enabled = false;
                    OdaEkle.Enabled = false;
                    tr.Enabled = false;
                    tsu.Enabled = false;
                    twr.Enabled = false;
                    sgl.Enabled = false;
                    quad.Enabled = false;
                    dbl.Enabled = false;
                    fiyat.Enabled = false;
                    odasecim.Enabled = false;
                    Ekle.Enabled = false;
                    Kaydet.Enabled = false;
                    kat.Enabled = false;
                    Katekle.Enabled = false;
                }
            }
            baglanti.Close();
            guncelletr.Checked = false;
            guncelletsu.Checked = false;
            guncelletwr.Checked = false;
            guncellesgl.Checked = false;
            guncellequad.Checked = false;
            guncelledbl.Checked = false;
            tr.Checked = false;
            tsu.Checked = false;
            twr.Checked = false;
            sgl.Checked = false;
            quad.Checked = false;
            dbl.Checked = false;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select KatSayisi from Oteller where OtelID='"+OtelID+"'",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 1; i <= int.Parse(dr[0].ToString()); i++)
                {
                    guncellekat.Items.Add(i+".Kat");
                }
            }
            baglanti.Close();

        }

        private void Guncellekat_SelectedIndexChanged(object sender, EventArgs e)
        {
            guncelleodasecim.Items.Clear();
            guncelleoda.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Count(OdaNo) from Odalar where Kat='"+guncellekat.SelectedItem.ToString().Substring(0,1)+ "' and OtelID='" + OtelID + "'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                guncelleoda.Text = dr[0].ToString(); 
            }
            baglanti.Close();

            baglanti2.Open();
            SqlCommand komut2 = new SqlCommand("select OdaNo from Odalar where Kat='" + guncellekat.SelectedItem.ToString().Substring(0, 1) + "' and OtelID='"+OtelID+"'", baglanti2);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                int b = int.Parse(guncelleoda.Text);
                b= int.Parse(dr2[0].ToString());
                guncelleodasecim.Items.Add(dr2[0].ToString(),false);
            }
            baglanti2.Close();
        }

        int odatip2;
        private void Guncelleodasecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guncellesgl.Checked == true)
                odatip2 = 1;
            else if (guncelletsu.Checked == true)
                odatip2 = 2;
            else if (guncelletwr.Checked == true)
                odatip2 = 3;
            else if (guncelledbl.Checked == true)
                odatip2 = 4;
            else if (guncelletr.Checked == true)
                odatip2 = 5;
            else if (guncellequad.Checked == true)
                odatip2 = 6;

            if (guncelleodasecim.CheckedItems.Count ==0)
            {
                guncellesgl.Checked = false;
                guncelletr.Checked = false;
                guncelletsu.Checked = false;
                guncelletwr.Checked = false;
                guncellequad.Checked = false;
                guncelledbl.Checked = false;
                guncellefiyat.Text = "";
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select OdaTip,Fiyat from Odalar where OdaNo='" + guncelleodasecim.SelectedItem + "' and OtelID='" + OtelID + "'", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToUInt32(dr[0].ToString()) == 1)
                    {
                        guncellesgl.Checked = true;
                        guncelletr.Checked = false;
                        guncelletsu.Checked = false;
                        guncelletwr.Checked = false;
                        guncellequad.Checked = false;
                        guncelledbl.Checked = false;
                    }
                    else if (Convert.ToUInt32(dr[0].ToString()) == 2)
                    {
                        guncelletsu.Checked = true;
                        guncelletr.Checked = false;
                        guncelletwr.Checked = false;
                        guncellesgl.Checked = false;
                        guncellequad.Checked = false;
                        guncelledbl.Checked = false;
                    }
                    else if (Convert.ToUInt32(dr[0].ToString()) == 3)
                    {
                        guncelletwr.Checked = true;
                        guncelletr.Checked = false;
                        guncelletsu.Checked = false;
                        guncellesgl.Checked = false;
                        guncellequad.Checked = false;
                        guncelledbl.Checked = false;
                    }
                    else if (Convert.ToUInt32(dr[0].ToString()) == 4)
                    {
                        guncelledbl.Checked = true;
                        guncelletr.Checked = false;
                        guncelletsu.Checked = false;
                        guncelletwr.Checked = false;
                        guncellesgl.Checked = false;
                        guncellequad.Checked = false;
                    }
                    else if (Convert.ToUInt32(dr[0].ToString()) == 5)
                    {
                        guncelletr.Checked = true;
                        guncelletsu.Checked = false;
                        guncelletwr.Checked = false;
                        guncellesgl.Checked = false;
                        guncellequad.Checked = false;
                        guncelledbl.Checked = false;
                    }
                    else if (Convert.ToUInt32(dr[0].ToString()) == 6)
                    {
                        guncellequad.Checked = true;
                        guncelletr.Checked = false;
                        guncelletsu.Checked = false;
                        guncelletwr.Checked = false;
                        guncellesgl.Checked = false;
                        guncelledbl.Checked = false;
                    }

                    guncellefiyat.Text = dr[1].ToString();

                }
                baglanti.Close();
            }
            else
            {
                guncellequad.Checked = false;
                guncelletr.Checked = false;
                guncelletsu.Checked = false;
                guncelletwr.Checked = false;
                guncellesgl.Checked = false;
                guncelledbl.Checked = false;
                guncellefiyat.Text = "";
            }

        }
        int odatip3;
        private void Güncelle_Click(object sender, EventArgs e)
        {
            if (guncellesgl.Checked == false && guncelletsu.Checked == false && guncelletwr.Checked == false && guncelledbl.Checked == false && guncelletr.Checked == false && guncellequad.Checked == false)
                MessageBox.Show("Lütfen oda tipini seçiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (guncellefiyat.Text == "")
                MessageBox.Show("Lütfen oda fiyatını giriniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);            else
            {
                if (guncellesgl.Checked == true)
                    odatip3 = 1;
                else if (guncelletsu.Checked == true)
                    odatip3 = 2;
                else if (guncelletwr.Checked == true)
                    odatip3 = 3;
                else if (guncelledbl.Checked == true)
                    odatip3 = 4;
                else if (guncelletr.Checked == true)
                    odatip3 = 5;
                else if (guncellequad.Checked == true)
                    odatip3 = 6;

                for (int a = 0; a < guncelleodasecim.CheckedItems.Count; a++)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("update Odalar set OdaTip='" + odatip3 + "' ,  Fiyat='" + Convert.ToDouble(guncellefiyat.Text) + "' where OdaNo='" + guncelleodasecim.CheckedItems[a] + "' and OtelID='" + OtelID + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
                if(guncelleodasecim.SelectedItems.Count==1)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("update Odalar set OdaTip='" + odatip3 + "' ,  Fiyat='" + Convert.ToDouble(guncellefiyat.Text) + "' where OdaNo='" + guncelleodasecim.SelectedItem + "' and OtelID='" + OtelID + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
                string degisenodalar = "";
                if (guncelleodasecim.CheckedItems.Count > 0)
                {
                    for (int i = 0; i <= guncelleodasecim.CheckedItems.Count; i++)
                    {
                        degisenodalar = degisenodalar + " " + guncelleodasecim.CheckedItems[0].ToString();
                        guncelleodasecim.SelectedItem = guncelleodasecim.CheckedItems[0];
                        guncelleodasecim.SetItemChecked(guncelleodasecim.SelectedIndex,false);
                    }
                    degisenodalar = degisenodalar + " " + guncelleodasecim.CheckedItems[0].ToString();
                    guncelleodasecim.SelectedItem = guncelleodasecim.CheckedItems[0];
                    guncelleodasecim.SetItemChecked(guncelleodasecim.SelectedIndex, false);

                    degisenodalar = degisenodalar + " Nolu odalar başarıyla güncellendi.";
                }
                else
                    degisenodalar = guncelleodasecim.SelectedItem.ToString()+ " Nolu oda başarıyla güncellendi.";
                MessageBox.Show(degisenodalar, "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (guncelleodasecim.Items.Count == 0)
                {
                    guncelleoda.Text = "";
                }
                guncelletsu.Checked = false;
                guncelletr.Checked = false;
                guncelletwr.Checked = false;
                guncellesgl.Checked = false;
                guncellequad.Checked = false;
                guncelledbl.Checked = false;
                guncellefiyat.Text = "";
            }
           
        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
            if (odasecim.CheckedItems.Count == 0)
                MessageBox.Show("Lütfen oda seçiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (sgl.Checked == false && tsu.Checked == false && twr.Checked == false && dbl.Checked == false && tr.Checked == false && quad.Checked == false)
                MessageBox.Show("Lütfen oda tipini seçiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (fiyat.Text == "")
                MessageBox.Show("Lütfen oda fiyatını giriniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (sgl.Checked == true)
                    odatip = 1;
                else if (tsu.Checked == true)
                    odatip = 2;
                else if (twr.Checked == true)
                    odatip = 3;
                else if (dbl.Checked == true)
                    odatip = 4;
                else if (tr.Checked == true)
                    odatip = 5;
                else if (quad.Checked == true)
                    odatip = 6;
                for (int i = 0; i < odasecim.CheckedItems.Count; i++)
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into OdalarTaslak values('" + OtelID + "','" + int.Parse(ykat.SelectedItem.ToString().Substring(0, 1)) + "','" + int.Parse(Convert.ToString(OtelID + odasecim.CheckedItems[i].ToString())) + "','" + int.Parse(odasecim.CheckedItems[i].ToString()) + "','" + odatip + "','" + 2 + "','" + 1 + "','" + double.Parse(fiyat.Text) + "','" + true + "','" + true + "','" + true + "','" + true + "','" + true + "')", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
                MessageBox.Show("Odalar eklendi");
                taslakonay++;
                tr.Checked = false;
                tsu.Checked = false;
                twr.Checked = false;
                sgl.Checked = false;
                quad.Checked = false;
                dbl.Checked = false;
                fiyat.Text = "";
                for (int i = 0; i < odasecim.CheckedItems.Count * 100; i++)
                {
                    odasecim.Items.Remove(odasecim.CheckedItems[0]);
                }
                if (odasecim.Items.Count == 0)
                {
                    ykat.Items.RemoveAt(ykat.SelectedIndex);
                    katoda.Text = "";
                    ykat.Enabled = true;
                    katoda.Enabled = true;
                }
                if (ykat.Items.Count == 0)
                    kat.Text = "";
                if (odasecim.Items.Count == 0 && ykat.Items.Count == 0 && taslakonay!=1)
                {
                    MessageBox.Show("Otel kurulum taslağı tamamlandı.İşlenen mevcut odaları eklemek için 'Ekle' butonuna basın.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ykat.Enabled = false;
                    katoda.Enabled = false;
                    OdaEkle.Enabled = false;
                    tr.Enabled = false;
                    tsu.Enabled = false;
                    twr.Enabled = false;
                    sgl.Enabled = false;
                    quad.Enabled = false;
                    dbl.Enabled = false;
                    fiyat.Enabled = false;
                    odasecim.Enabled = false;
                    Ekle.Enabled = true;
                    Kaydet.Enabled = false;
                    Katekle.Enabled = false;
                    kat.Enabled = false;
                }

                   

            }
        }

        private void Ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from OdalarTaslak where OtelID='"+OtelID+"'",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                baglanti2.Open();
                SqlCommand komut2 = new SqlCommand("insert into Odalar values('"+dr[0]+ "','" + dr[1] + "','" + dr[2] + "','" + dr[3] + "','" + dr[4] + "','" + dr[5] + "','" + dr[6] + "','" +double.Parse(dr[7].ToString()) + "','" + dr[8] + "','" + dr[9] + "','" + dr[10] + "','" + dr[11] + "','" + dr[12] + "')", baglanti2);
                komut2.ExecuteNonQuery();
                baglanti2.Close();

                baglanti2.Open();
                SqlCommand komut5 = new SqlCommand("insert into OdalarYenileme values('" + OtelID + "','" + dr[3] + "','" + dr[5] + "')", baglanti2);
                komut5.ExecuteNonQuery();
                baglanti2.Close();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from OdalarTaslak where OtelID='" + OtelID + "'", baglanti);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update Oteller set KatSayisi='"+Katsayisi+"' where OtelID='"+OtelID+"'",baglanti);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Otel kurulumu tamamlandı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Ekle.Enabled = false;
        }
    }
}
