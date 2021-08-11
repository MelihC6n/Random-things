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
using Bunifu.UI.WinForms.BunifuButton;
namespace Login
{
    public partial class r_konak : Form
    {
        public r_konak()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(Login.veritabani);
        SqlConnection con2 = new SqlConnection(Login.veritabani);
        SqlConnection con3 = new SqlConnection(Login.veritabani);
        SqlConnection con4 = new SqlConnection(Login.veritabani);
        int OtelID = Login.id;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                datetpGelis.MinDate = DateTime.Now.Date;
                datetpGelis.MaxDate = DateTime.Now.Date;
                btn_cik.IconVisible = true; btn_ekle.IconVisible = true; btn_ekleEx.IconVisible = true; btn_fatura.IconVisible = true; btn_iptal.IconVisible = true; btn_kay.IconVisible = true; btn_kayder.IconVisible = true; btn_yazdir.IconVisible = true;
                SqlCommand cmd = new SqlCommand("Select OdaNo from Odalar where OtelID='" + OtelID + "'", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    cmbodano.Items.Add(sdr[0]).ToString();


                }
                con.Close();

                cmbfiyatkod.Items.Add("Toplam Fiyat");
                cmbfiyatkod.Items.Add("Kişi Başı Fiyat");
                cmbfiyatkod.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
         
            DatetpGidis.MinDate = datetpGelis.Value.AddDays(+1);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cmbodano_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                toplamodafiyat.Text = "";
                geneltxt.Text = "";
                odenecektxt.Text = "";
                r_konakdatagrid.Rows.Clear();
                SqlCommand cmd = new SqlCommand("Select GelisTarihi,GidisTarihi,KaldigiGeceSayisi,OdaTip,Televizyon,Klima,Buzdolabi,MiniBar,Telefon,Notlar from R_Konaklama where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con);
                SqlCommand cmd2 = new SqlCommand("Select Durum from Odalar Where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con2);
                SqlCommand cmd3 = new SqlCommand("Select OdaTip,Televizyon,Klima,Buzdolabi,Minibar,Telefon from Odalar Where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con);
                SqlCommand cmd4 = new SqlCommand("Select TcKimlikNo,Ad,Soyad,Cinsiyeti,Uyruk,GelisTarihi,GidisTarihi from r_konakgriddoldurma where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con); ;

                con.Open();
                SqlDataReader readgrid = cmd4.ExecuteReader();
                int i = 0;
                while (readgrid.Read())
                {
                    r_konakdatagrid.Rows.Add();
                    r_konakdatagrid.Rows[i].Cells[0].Value = readgrid["TcKimlikNo"].ToString();
                    r_konakdatagrid.Rows[i].Cells[1].Value = readgrid["Ad"].ToString();
                    r_konakdatagrid.Rows[i].Cells[2].Value = readgrid["Soyad"].ToString();

                    if (Boolean.Parse(readgrid["Cinsiyeti"].ToString()) == true)
                    { r_konakdatagrid.Rows[i].Cells[3].Value = "Erkek"; }
                    else if (Boolean.Parse(readgrid["Cinsiyeti"].ToString()) == false)
                    { r_konakdatagrid.Rows[i].Cells[3].Value = "Kadın"; }

                    if (Boolean.Parse(readgrid["Uyruk"].ToString()) == true)
                    { r_konakdatagrid.Rows[i].Cells[4].Value = "Türk"; }
                    else if (Boolean.Parse(readgrid["Uyruk"].ToString()) == false)
                    { r_konakdatagrid.Rows[i].Cells[4].Value = "Yabancı"; }


                    r_konakdatagrid.Rows[i].Cells[5].Value = readgrid["GelisTarihi"].ToString();
                    r_konakdatagrid.Rows[i].Cells[5].Value = Convert.ToDateTime(r_konakdatagrid.Rows[i].Cells[5].Value).ToString("yyyy-MM-dd");
                    r_konakdatagrid.Rows[i].Cells[6].Value = readgrid["GidisTarihi"].ToString();
                    r_konakdatagrid.Rows[i].Cells[6].Value = Convert.ToDateTime(r_konakdatagrid.Rows[i].Cells[6].Value).ToString("yyyy-MM-dd");
                    i += 1;
                }
                con.Close();

                try
                {
                    con2.Open();
                    SqlDataReader sdr2 = cmd2.ExecuteReader();
                    sdr2.Read();
                    if (sdr2[0].ToString() == "1")
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            //datetpGelis.Value = Convert.ToDateTime(sdr["GelisTarihi"].ToString());
                            //DatetpGidis.Value = Convert.ToDateTime(sdr["GidisTarihi"].ToString());
                            datetpGelis.MinDate = DateTime.Now.Date;
                            datetpGelis.MaxDate = DateTime.Now.Date;
                            txtGecesayisi.Text = sdr["KaldigiGeceSayisi"].ToString();
                            int b = Convert.ToInt32(sdr["OdaTip"].ToString());
                            if (b == 1)
                            {
                                txtodatip.Text = ("Tek kişilik oda(SGL)");
                            }
                            else if (b == 2)
                            {
                                txtodatip.Text = ("Standart iki yataklı oda(TFSU)");

                            }
                            else if (b == 3)
                            {
                                txtodatip.Text = ("İki kişilik oda(TR) ");
                            }
                            else if (b == 4)
                            {
                                txtodatip.Text = ("Standart çift kişilik oda(DBL)");
                            }
                            else if (b == 5)
                            {
                                txtodatip.Text = ("Üç kişilik oda(TR)");
                            }
                            else if (b == 6)
                            {
                                txtodatip.Text = ("Dört kişilik oda(Quad)");
                            }
                            if (Convert.ToBoolean(sdr["Televizyon"].ToString()) == true)
                            {
                                chcktelevizyon.Checked = true;
                            }
                            else if (Convert.ToBoolean(sdr["Televizyon"].ToString()) == false)
                            {
                                chcktelevizyon.Checked = false;
                            }
                            if (Convert.ToBoolean(sdr["Klima"].ToString()) == true)
                            {
                                chckklima.Checked = true;
                            }
                            else
                            {
                                chckklima.Checked = false;
                            }
                            if (Convert.ToBoolean(sdr["Buzdolabi"].ToString()) == true)
                            {
                                chckBuzdolabi.Checked = true;
                            }
                            else
                            {
                                chckBuzdolabi.Checked = false;
                            }
                            if (Convert.ToBoolean(sdr["MiniBar"].ToString()) == true)
                            {
                                chckMiniBar.Checked = true;
                            }
                            else
                            {
                                chckMiniBar.Checked = false;
                            }
                            if (Convert.ToBoolean(sdr["Telefon"].ToString()) == true)
                            {
                                ChckTelefon.Checked = true;
                            }
                            else
                            {
                                ChckTelefon.Checked = false;
                            }

                            richTextBox2.Text = sdr["Notlar"].ToString();


                        }
                        con.Close();
                    }

                    else
                    {
                        con.Open();
                        SqlDataReader sdr3 = cmd3.ExecuteReader();
                        while (sdr3.Read())
                        {
                            int b = Convert.ToInt32(sdr3["OdaTip"].ToString());
                            if (b == 1)
                            {
                                txtodatip.Text = ("Tek kişilik oda(SGL)");
                            }
                            else if (b == 2)
                            {
                                txtodatip.Text = ("Standart iki yataklı oda(TFSU)");

                            }
                            else if (b == 3)
                            {
                                txtodatip.Text = ("İki kişilik oda(TR) ");
                            }
                            else if (b == 4)
                            {
                                txtodatip.Text = ("Standart çift kişilik oda(DBL)");
                            }
                            else if (b == 5)
                            {
                                txtodatip.Text = ("Üç kişilik oda(TR)");
                            }
                            else if (b == 6)
                            {
                                txtodatip.Text = ("Dört kişilik oda(Quad)");
                            }
                            if (Convert.ToBoolean(sdr3["Televizyon"].ToString()) == true)
                            {
                                chcktelevizyon.Checked = true;
                            }
                            else if (Convert.ToBoolean(sdr3["Televizyon"].ToString()) == false)
                            {
                                chcktelevizyon.Checked = false;
                            }
                            if (Convert.ToBoolean(sdr3["Klima"].ToString()) == true)
                            {
                                chckklima.Checked = true;
                            }
                            else
                            {
                                chckklima.Checked = false;
                            }
                            if (Convert.ToBoolean(sdr3["Buzdolabi"].ToString()) == true)
                            {
                                chckBuzdolabi.Checked = true;
                            }
                            else
                            {
                                chckBuzdolabi.Checked = false;
                            }
                            if (Convert.ToBoolean(sdr3["MiniBar"].ToString()) == true)
                            {
                                chckMiniBar.Checked = true;
                            }
                            else
                            {
                                chckMiniBar.Checked = false;
                            }
                            if (Convert.ToBoolean(sdr3["Telefon"].ToString()) == true)
                            {
                                ChckTelefon.Checked = true;
                            }
                            else
                            {
                                ChckTelefon.Checked = false;
                            }

                            richTextBox2.Text = "";
                        }
                        con.Close();
                    }
                    con2.Close();




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                SqlCommand cmd3 = new SqlCommand("Select OdaTip from Odalar Where OdaNo='" + cmbodano.Text + "' and OtelID='"+ OtelID+"'", con);
                con.Open();
                SqlDataReader sdr3 = cmd3.ExecuteReader();
                while (sdr3.Read())
                {
                    int b = Convert.ToInt32(sdr3["OdaTip"].ToString());
                    if (b == 1 && (r_konakdatagrid.RowCount) <= 1 && a==0)
                    {
                        a++;
                        rez_tikla rez_Tikla = new rez_tikla();
                        rez_Tikla.Show();
                    }
                    else if (b == 2 && (r_konakdatagrid.RowCount) <= 2 && a == 0)
                    {
                        a++;
                        rez_tikla rez_Tikla = new rez_tikla();
                        rez_Tikla.Show();
                    }
                    else if (b == 3 && (r_konakdatagrid.RowCount) <= 2 && a == 0)
                    {
                        a++;
                        rez_tikla rez_Tikla = new rez_tikla();
                        rez_Tikla.Show();
                    }
                    else if (b == 4 && (r_konakdatagrid.RowCount) <= 2 && a == 0)
                    {
                        a++;
                        rez_tikla rez_Tikla = new rez_tikla();
                        rez_Tikla.Show();
                    }
                    else if (b == 5 && (r_konakdatagrid.RowCount) <= 3 && a == 0)
                    {
                        a++;
                        rez_tikla rez_Tikla = new rez_tikla();
                        rez_Tikla.Show();
                    }
                    else if (b == 6 && (r_konakdatagrid.RowCount) <= 4 && a == 0)
                    {
                        a++;
                        rez_tikla rez_Tikla = new rez_tikla();
                        rez_Tikla.Show();
                    }
                    else
                        MessageBox.Show("Mevcut oda tipinde maksimum kişi sayısına ulaşıldı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_cik_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Select OdenecekTutar From K_Cikis Where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con);
                SqlCommand cmd2 = new SqlCommand("Select TcKimlik from K_Giris Where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con3);
                con.Open();
                con3.Open();
                SqlDataReader sdr = cmd.ExecuteReader();


                while (sdr.Read())
                {
                    if (Convert.ToDouble(sdr[0].ToString()) == 0)
                    {
                        con2.Open();
                        SqlCommand update = new SqlCommand("update Odalar set Durum=3 where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con2);
                        update.ExecuteNonQuery();
                        SqlCommand deletesiparis = new SqlCommand("delete from Siparisler where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con2);
                        deletesiparis.ExecuteNonQuery();
                        SqlCommand deleteodemeler = new SqlCommand("delete from Odemeler Where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con2);
                        deleteodemeler.ExecuteNonQuery();

                        SqlDataReader sdr2 = cmd2.ExecuteReader();
                        while (sdr2.Read())
                        {


                            SqlCommand updatetc = new SqlCommand("Update r_Musteriekle set Durum=0 where TcKimlikNo='" + sdr2[0].ToString() + "' and OtelID='" + OtelID + "'", con2);
                            updatetc.ExecuteNonQuery();
                            SqlCommand kgrissil = new SqlCommand("delete from K_Giris Where TcKimlik='" + sdr2[0].ToString() + "' and OtelID='" + OtelID + "'", con2);
                            kgrissil.ExecuteNonQuery();
                            SqlCommand kcikissil = new SqlCommand("delete from K_Cikis where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con2);
                            kcikissil.ExecuteNonQuery();


                        }

                        con2.Close();
                        MessageBox.Show("İstediğiniz başarı ile çıkışı yapılmıştır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        r_konakdatagrid.Rows.Clear();
                        datagridodemeler.Rows.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Oda ödemesi tamamlanmadan çıkış yapılamaz");
                    }

                }
                con.Close();
                con2.Close();
                con3.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void btn_kay_Click(object sender, EventArgs e)
            {
            try
            {
                int kaldigigece = 0;
            if (r_konakdatagrid.RowCount > 0)
            {
                for (int j = 0; j < r_konakdatagrid.RowCount - 1; j++)
                {
                    con.Open();
                    con3.Open();
                    SqlCommand sorgula = new SqlCommand("Select Count(TcKimlik) from K_Giris where TcKimlik=@tc and OtelID='" + OtelID + "'", con3);
                    sorgula.Parameters.AddWithValue("@tc", r_konakdatagrid.Rows[j].Cells[0].Value.ToString());

                    SqlDataReader dr = sorgula.ExecuteReader();
                    while (dr.Read())
                    {
                        if (Convert.ToInt32(dr[0].ToString()) == 0)
                        {

                            SqlCommand cmd = new SqlCommand("insert into K_Giris(OtelID,TcKimlik,GelisTarihi,GidisTarihi,KaldigiGeceSayisi,OdaNo) Values(@otelid ,@tc,@gelis,@gidis,@gece,@odano)", con);
                            cmd.Parameters.AddWithValue("@otelid", OtelID);
                            string a = r_konakdatagrid.Rows[j].Cells[0].Value.ToString();
                            cmd.Parameters.AddWithValue("@tc", a);
                            cmd.Parameters.AddWithValue("@gelis", r_konakdatagrid.Rows[j].Cells[5].Value.ToString());
                            cmd.Parameters.AddWithValue("@gidis", r_konakdatagrid.Rows[j].Cells[6].Value.ToString());
                            cmd.Parameters.AddWithValue("@gece", txtGecesayisi.Text);
                            cmd.Parameters.AddWithValue("@odano", cmbodano.Text);
                            cmd.ExecuteNonQuery();
                            SqlCommand update = new SqlCommand("update Odalar set Durum=1 where OdaNo=@odano", con4);
                            update.Parameters.AddWithValue("@odano", cmbodano.Text);
                            con4.Open();
                            update.ExecuteNonQuery();
                            con4.Close();

                        }
                        else
                        {
                        }
                    }
                    con.Close();
                    con3.Close();
                }
                for (int j = 0; j < r_konakdatagrid.RowCount - 1; j++)
                {

                    DateTime gelis = Convert.ToDateTime(Convert.ToDateTime(r_konakdatagrid.Rows[j].Cells[5].Value).ToString("yyyy-MM-dd"));
                    DateTime gidis = Convert.ToDateTime(Convert.ToDateTime(r_konakdatagrid.Rows[j].Cells[6].Value).ToString("yyyy-MM-dd"));
                    TimeSpan sonuc = gidis - gelis;
                    kaldigigece += int.Parse(sonuc.TotalDays.ToString());

                }

                SqlCommand bak = new SqlCommand("Select COUNT(OdaNo) from K_Cikis where OdaNo=@odano and OtelID=@otelid", con3);
                SqlCommand odalar = new SqlCommand("Select Fiyat from Odalar where OdaNo=@odano and OtelID=@otelid", con);
                odalar.Parameters.AddWithValue("@odano", cmbodano.Text);
                odalar.Parameters.AddWithValue("@otelid", OtelID);
                con.Open();
                SqlDataReader odalaroku = odalar.ExecuteReader();
                double odafiyat = 0;
                if (odalaroku.Read())
                {
                    odafiyat += Convert.ToDouble(odalaroku[0].ToString());
                }
                con.Close();
                bak.Parameters.AddWithValue("@odano", cmbodano.Text);
                bak.Parameters.AddWithValue("@otelid", OtelID);
                con3.Open();

                SqlDataReader dene = bak.ExecuteReader();
                while (dene.Read())
                {
                    if (Convert.ToInt32(dene[0].ToString()) == 0)
                    {
                        con2.Open();
                        SqlCommand insert = new SqlCommand("insert into K_Cikis(OtelID,OdaNo,KalinanGeceSayisi,ToplamOdaFiyati,EkstraHarcamalar,ToplamOdemeler,GenelToplam,Indirim,OdenecekTutar) Values(@otelid,@odano,@gece,@toplamodafiyat,@extra,@toplamodeme,@geneltoplam,@indirim,@odenecektutar)", con2);
                        insert.Parameters.AddWithValue("@otelid", OtelID);
                        insert.Parameters.AddWithValue("@odano", cmbodano.Text);
                        insert.Parameters.AddWithValue("@gece", kaldigigece);
                            double toplamoda = odafiyat * kaldigigece;
                        insert.Parameters.AddWithValue("@toplamodafiyat", toplamoda);
                        insert.Parameters.AddWithValue("@extra", double.Parse(extraharcamalartxt.Text));
                        insert.Parameters.AddWithValue("@toplamodeme", 0);
                        insert.Parameters.AddWithValue("@geneltoplam", ((Convert.ToDouble(odafiyat) * Convert.ToDouble(kaldigigece))) + Convert.ToDouble(extraharcamalartxt.Text));
                        insert.Parameters.AddWithValue("@indirim", 0);
                        insert.Parameters.AddWithValue("@odenecektutar", (((Convert.ToDouble(odafiyat) * Convert.ToDouble(kaldigigece))) + Convert.ToDouble(extraharcamalartxt.Text)));
                        insert.ExecuteNonQuery();
                        con2.Close();

                        con.Close();
                        yenile();
                        con.Open();

                        MessageBox.Show("Girdiğiniz Veriler Başarı İle Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        con.Close();
                        yenile();
                        con.Open();
                        con2.Open();
                        SqlCommand update = new SqlCommand("update K_Cikis set KalinanGeceSayisi=@gece,ToplamOdaFiyati=@toplamodafiyat,EkstraHarcamalar=@extra,ToplamOdemeler=@toplamodeme,GenelToplam=@geneltoplam,OdenecekTutar=@odenecektutar where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con2);
                        update.Parameters.AddWithValue("@gece", kaldigigece);
                        update.Parameters.AddWithValue("@toplamodafiyat", odafiyat * kaldigigece);
                        update.Parameters.AddWithValue("@extra", double.Parse(extraharcamalartxt.Text));
                        update.Parameters.AddWithValue("@toplamodeme", double.Parse(toplamodemeler.Text));
                        update.Parameters.AddWithValue("@geneltoplam", (Convert.ToDouble(odafiyat) * Convert.ToDouble(kaldigigece)) + Convert.ToDouble(extraharcamalartxt.Text));
                       
                        update.Parameters.AddWithValue("@odenecektutar", ((Convert.ToDouble(odafiyat) * Convert.ToDouble(kaldigigece)) + Convert.ToDouble(extraharcamalartxt.Text) - double.Parse(toplamodemeler.Text)));

                        update.ExecuteNonQuery();
                        MessageBox.Show("Girdiğiniz Veriler Başarı İle Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con2.Close();
                    }
                }
                con.Close();
                con3.Close();



            }
            else
            {
                MessageBox.Show("Kaydetmeden Önce Bazı Kişiler Eklemelisiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void datetpGelis_ValueChanged(object sender, EventArgs e)       //kalınan gece sayısı hesaplandı
        {
            DatetpGidis.MinDate = datetpGelis.Value;
            DateTime gelis = Convert.ToDateTime(datetpGelis.Value.ToString("yyyy-MM-dd"));
            DateTime gidis = Convert.ToDateTime(DatetpGidis.Value.ToString("yyyy-MM-dd"));
            TimeSpan sonuc = gidis - gelis;
            txtGecesayisi.Text = sonuc.TotalDays.ToString(); ;
        }

        private void btn_ip_Click(object sender, EventArgs e)
        {
            this.Hide();
            r_konak konak = new r_konak();
            konak.Dispose();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)//harcamaları aldığımız datagridleri dolduruyoruz
        {
            yenile();
            con.Open();
            DataGridViewHarcama.Rows.Clear();
            int i = 0;
            SqlCommand cmd = new SqlCommand("select TcKimlik,KaldigiGeceSayisi from K_Giris where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con); //odadaki tüm kişilerin tc noları ve kadiklerı gece sayısını alıyoruz
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())   // aldığımız herkesi sırayla döndürüyoruz
            {
                DataGridViewHarcama.Rows.Add();
                DataGridViewHarcama.Rows[i].Cells[0].Value = sdr[1].ToString();
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("select Ad,Soyad from R_Musteriekle where TcKimlikNo='" + sdr[0] + "' and OtelID='" + OtelID + "'", con2);  //sırasıyla gelen kişinin tcsiyle sorgulayıp ad ve soyadını birleştirip yazıyoruz
                SqlDataReader sdr2 = cmd2.ExecuteReader();
                while (sdr2.Read())
                {
                    DataGridViewHarcama.Rows[i].Cells[1].Value = sdr2[0].ToString() + " " + sdr2[1].ToString();
                }
                con2.Close();
                con3.Open();
                SqlCommand cmd3 = new SqlCommand("select Fiyat from Odalar where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con3);  //bulunan odanın fiyatını alıyoruz
                SqlDataReader sdr3 = cmd3.ExecuteReader();
                while (sdr3.Read())
                {
                    DataGridViewHarcama.Rows[i].Cells[2].Value = (double.Parse(sdr3[0].ToString()) * double.Parse(sdr[1].ToString())).ToString();  //kişinin kaldığı gün sayısı ile oda fiyatının çarpıp tutar elde ediyoruz
                }
                con3.Close();
                i++;
            }
            con.Close();
            bunifuCustomDataGrid1.Rows.Clear();
            SqlCommand siparis = new SqlCommand("Select Siparis from Siparisler Where OdaNo=@odano and OtelID=@otelid and SiparisDurum=@siparis", con4);
            siparis.Parameters.AddWithValue("@odano", cmbodano.Text);
            siparis.Parameters.AddWithValue("@otelid", OtelID);
            siparis.Parameters.AddWithValue("@siparis", false);
            con4.Open();
            int b = 0;
            SqlDataReader dr = siparis.ExecuteReader();
            while (dr.Read())
            {
                string metin = dr["Siparis"].ToString();
                string[] parca = metin.Split('/');
                for (int a = 0; a < parca.Length; a++)
                {

                    string[] metinadet = parca[a].Split('-');
                    string adet = metinadet[0];
                    string[] urun = metinadet[1].Split('=');
                    string urunad = urun[0];
                    string tutar = urun[1];

                    bunifuCustomDataGrid1.Rows.Add();
                    bunifuCustomDataGrid1.Rows[b].Cells[0].Value = adet;
                    bunifuCustomDataGrid1.Rows[b].Cells[1].Value = urunad;
                    bunifuCustomDataGrid1.Rows[b].Cells[2].Value = tutar;
                    b++;
                }
            }
            con4.Close();
        

        }

        private void DatetpGidis_ValueChanged(object sender, EventArgs e)

        {

            DateTime gelis = Convert.ToDateTime(datetpGelis.Value.ToString("yyyy-MM-dd"));
            DateTime gidis = Convert.ToDateTime(DatetpGidis.Value.ToString("yyyy-MM-dd"));
            TimeSpan sonuc = gidis - gelis;
            txtGecesayisi.Text = int.Parse(sonuc.TotalDays.ToString()).ToString();

        }


        private void tahsiltxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (Convert.ToInt32(tahsiltxt.Text) <= Convert.ToInt32(odenecektxt.Text))
                {
                    toplamodemeler.Text = (Convert.ToDouble(toplamodemeler.Text) + Convert.ToDouble(tahsiltxt.Text)).ToString();
                    int i = datagridodemeler.RowCount;
                    datagridodemeler.Rows.Add();
                    datagridodemeler.Rows[i].Cells[0].Value = cmbodano.Text;
                    datagridodemeler.Rows[i].Cells[1].Value = DateTime.Now;
                    datagridodemeler.Rows[i].Cells[2].Value = tahsiltxt.Text;
                    datagridodemeler.Rows[i].Cells[3].Value = "ekle";
                    tahsiltxt.Text = null;
                    odenecektxt.Text = (Convert.ToDouble(geneltxt.Text) - Convert.ToDouble(toplamodemeler.Text)).ToString();


                }
                else
                {
                    MessageBox.Show("Tahsil Edilen Tutar Ödenecek Tutardan Fazla Olamaz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void extraharcamalartxt_TextChanged(object sender, EventArgs e)
        {
            geneltxt.Text = (Convert.ToDouble(toplamodafiyat.Text) + Convert.ToDouble(extraharcamalartxt.Text)).ToString();
        }

        private void toplamodemeler_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {

           
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.KeyChar == (char)Keys.Enter)
            {
                
                if (Convert.ToDouble(indirimtxt.Text) <= Convert.ToDouble(odenecektxt.Text))
                {
                    odenecektxt.Text = Convert.ToDouble((Convert.ToDouble(odenecektxt.Text) - Convert.ToDouble(indirimtxt.Text))).ToString();
                }
                else
                {
                    MessageBox.Show("İndirim Ödenecek Tutardan Fazla Olamaz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }         
        }
    

        private void yenile()
        {
            SqlCommand odenecektutar = new SqlCommand("select ToplamOdaFiyati,EkstraHarcamalar,ToplamOdemeler,GenelToplam,Indirim,OdenecekTutar from K_Cikis where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con);
            SqlCommand odemeler = new SqlCommand("Select OdaNo,Odeme,OdemeTarih,IslemNo from Odemeler where OdaNo=@odano and OtelID=@otelid", con2);
            odemeler.Parameters.AddWithValue("@odano", cmbodano.Text);
            odemeler.Parameters.AddWithValue("@otelid", OtelID);

            con.Open();
            SqlDataReader oku = odenecektutar.ExecuteReader();
            while (oku.Read())
            {
                toplamodafiyat.Text = (Convert.ToDouble(oku[0].ToString())).ToString();
                extraharcamalartxt.Text = (Convert.ToDouble(oku[1].ToString())).ToString();
                toplamodemeler.Text = (Convert.ToDouble(oku[2].ToString())).ToString();
                geneltxt.Text = (Convert.ToDouble(oku[3].ToString())).ToString();
                indirimtxt.Text = (Convert.ToDouble(oku[4].ToString())).ToString();
                odenecektxt.Text = (Convert.ToDouble(oku[5].ToString())).ToString();

            }
            con.Close();
            con2.Open();
            SqlDataReader dr = odemeler.ExecuteReader();
            int i = 0;
            datagridodemeler.Rows.Clear();
            while (dr.Read())
            {
                datagridodemeler.Rows.Add();
                datagridodemeler.Rows[i].Cells[0].Value = dr["OdaNo"].ToString();
                datagridodemeler.Rows[i].Cells[1].Value = dr["OdemeTarih"].ToString();
                datagridodemeler.Rows[i].Cells[2].Value = Convert.ToDouble(dr["Odeme"].ToString()) + "₺";
                datagridodemeler.Rows[i].Cells[3].Value = dr["IslemNo"].ToString();
                i++;

            }
            con2.Close();
            con.Close();


        }



        private void btn_kayder_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                for (int i = 0; i < datagridodemeler.RowCount; i++)
                {
                    if (datagridodemeler.Rows[i].Cells[3].Value.ToString() == "ekle")
                    {
                        SqlCommand tahsilekle = new SqlCommand("insert into Odemeler(OtelID,OdaNo,Odeme,OdemeTarih) values(@otelid,@odano,@odeme,@odemetarih)", con);
                        tahsilekle.Parameters.AddWithValue("@otelid", OtelID);
                        tahsilekle.Parameters.AddWithValue("@odano", cmbodano.Text);
                        tahsilekle.Parameters.AddWithValue("@odeme", datagridodemeler.Rows[i].Cells[2].Value);
                        tahsilekle.Parameters.AddWithValue("@odemetarih", datagridodemeler.Rows[i].Cells[1].Value);

                        tahsilekle.ExecuteNonQuery();
                        MessageBox.Show("Değişiklikler Başarı İle Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        datagridodemeler.Rows[i].Cells[3].Value = "0";
                    }

                }
                con.Close();
                SqlCommand toplamodeme = new SqlCommand("Select Odeme from Odemeler where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con);
                con.Open();
                double toplamodemeupdate = 0;
                SqlDataReader topla = toplamodeme.ExecuteReader();
                while (topla.Read())
                {
                    toplamodemeupdate += double.Parse(topla[0].ToString());
                }
                con.Close();
                SqlCommand komut = new SqlCommand("Select GenelToplam from K_Cikis where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con);
                con.Open();
                SqlDataReader geneltoplamoku = komut.ExecuteReader();
                double geneltoplam = 0;
                while (geneltoplamoku.Read())
                {
                    geneltoplam = double.Parse(geneltoplamoku[0].ToString());
                }
                con.Close();
                con.Open();
                SqlCommand cikisupdate = new SqlCommand("update K_Cikis set ToplamOdemeler=@toplamodeme,OdenecekTutar=@odenecektutar where OdaNo=@odano and OtelID=@otelid", con);
                cikisupdate.Parameters.AddWithValue("@otelid", OtelID);
                cikisupdate.Parameters.AddWithValue("@odano", cmbodano.Text);
                cikisupdate.Parameters.AddWithValue("@toplamodeme", toplamodemeupdate);
                cikisupdate.Parameters.AddWithValue("@odenecektutar", geneltoplam - toplamodemeupdate);
                cikisupdate.ExecuteNonQuery();
                MessageBox.Show("Değişiklikler Başarı İle Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                yenile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tahsiltxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_ekleEx_Click(object sender, EventArgs e)
        {


            toplamodemeler.Text = geneltxt.Text;
            int i = datagridodemeler.RowCount;
            datagridodemeler.Rows.Add();
            datagridodemeler.Rows[i].Cells[0].Value = cmbodano.Text;
            datagridodemeler.Rows[i].Cells[1].Value = DateTime.Now;
            datagridodemeler.Rows[i].Cells[2].Value = Convert.ToDouble(odenecektxt.Text);
            datagridodemeler.Rows[i].Cells[3].Value = "ekle";
            tahsiltxt.Text = null;
            odenecektxt.Text = 0.ToString();

        }

        private void cmbfiyatkod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select ToplamOdaFiyati From K_Cikis where OdaNo='" + cmbodano.Text + "' and OtelID='" + OtelID + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (cmbfiyatkod.SelectedIndex == 0)
                    {
                        cmbfiyatkod.SelectedIndex = 0;
                        textBox1.Text = Convert.ToDouble(dr[0]).ToString();
                    }
                    else if (cmbfiyatkod.SelectedIndex == 1)
                    {


                        {
                            textBox1.Text = (Convert.ToDouble(dr[0].ToString()) / (r_konakdatagrid.RowCount - 1)).ToString();
                        }

                    }
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
    }


