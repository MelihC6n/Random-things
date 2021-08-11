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
using System.Text.RegularExpressions;

namespace Login
{
    public partial class r_musterı_ekle : Form
    {
        public int OtelID = Login.id;
        public r_musterı_ekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Login.veritabani);
        SqlConnection baglanti2 = new SqlConnection(Login.veritabani);
        SqlConnection baglanti3 = new SqlConnection(Login.veritabani);
        SqlConnection baglanti4 = new SqlConnection(Login.veritabani);
        SqlConnection baglanti5 = new SqlConnection(Login.veritabani);
        SqlConnection baglanti6 = new SqlConnection(Login.veritabani);
        SqlConnection baglanti7 = new SqlConnection(Login.veritabani);
        SqlConnection baglanti8 = new SqlConnection(Login.veritabani);

        private void Kaydet_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (kim_bel_tur.Text == "" || cep_tel.Text == "" || tcno.Text == "" || ad.Text == "" || soyad.Text == "" || babaad.Text == "" || anaad.Text == "" || dogum_yer.Text == "" || dogum_tar.Text == "" || uyruk.Text == "" || cins.Text == "" || ikamet_adres.Text == "" || giris_tar.Text == "")
            {
                MessageBox.Show("Lütfen kırmızı alanları boş geçmeyin", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                UInt64 tc = UInt64.Parse(tcno.Text);
                baglanti2.Open();
                baglanti3.Open();
                baglanti4.Open();
                SqlCommand komut = new SqlCommand("SELECT Count(TcKimlikNo) From R_Musteriekle where TcKimlikNo='" + tc + "' and OtelID='" + OtelID + "'", baglanti4);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    if (int.Parse(oku[0].ToString()) > 0)
                    {
                        bool mail = mailkontrol(e_mail.Text);
                        if (mail == true || e_mail.Text == "")
                        {
                            dogum_tar.CustomFormat = "MM/dd/yyyy";
                            dogum_tar.Format = DateTimePickerFormat.Custom;
                            if (tcno.Text.Length > 10)
                            {
                                SqlCommand cmd = new SqlCommand("update R_Musteriekle set KimlikBelgeTuru='" + kim_bel_tur.SelectedIndex + "',KimlikSeriNo='" + kimlik_seri_no.Text + "',TcKimlikNo='" + tcno.Text + "',Ad='" + ad.Text + "',Soyad='" + soyad.Text + "',BabaAd='" + babaad.Text + "',AnaAd='" + anaad.Text + "',Dogumyeri='" + dogum_yer.Text + "',DogumTarihi='" + dogum_tar.Text + "',Uyruk='" + uyruk.SelectedIndex + "',Cinsiyeti='" + cins.SelectedIndex + "',MedeniHali='" + med_hal.SelectedIndex + "',KayıtlıOlduguil='" + il.Text + "',KayıtlıOlduguilce='" + ilce.Text + "',KayıtlıOlduguMahalle='" + mah.Text + "',CiltNo='" + cilt_no.Text + "',AileSıraNo='" + aile_sıra_no.Text + "',SıraNo='" + int.Parse(sıra_no.Text) + "',Yetiskin_Cocuk='" + yet_cocuk.SelectedIndex + "',Telefon='" + tel.Text + "',CepTelefon='" + cep_tel.Text + "',Email='" + e_mail.Text + "',AracPlakaNo='" + arac_plaka_no.Text + "',Musteri_is='" + isi.Text + "',ikametkah='" + ikamet_adres.Text + "',Notlar='" + not.Text + "' where TcKimlikNo='" + tc + "' and OtelID='" + OtelID + "'", baglanti3);
                                dogum_tar.Format = DateTimePickerFormat.Long;
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();

                                SqlCommand cmd2 = new SqlCommand("update Uyruk set uyruk='" + comboBox1.Text + "' where KimlikNo='" + tc + "' and OtelID='" + OtelID + "'", baglanti2);
                                cmd2.ExecuteNonQuery();
                                cmd2.Dispose();

                                giris_tar.CustomFormat = "MM/dd/yyyy";
                                giris_tar.Format = DateTimePickerFormat.Custom;

                                SqlCommand Rez_rapor = new SqlCommand("insert into RezRapor values('" + OtelID + "','" + tcno.Text + "','" + giris_tar.Text + "','" + ad.Text + "','" + soyad.Text + "','" + uyruk.SelectedIndex + "')", baglanti2);
                                Rez_rapor.ExecuteNonQuery();
                                baglanti2.Close();

                                giris_tar.Format = DateTimePickerFormat.Long;

                                MessageBox.Show("Bilgiler güncellenmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                yenile();
                                baglanti2.Close();
                                baglanti3.Close();
                            }
                            else
                                MessageBox.Show("Kimlik numarası hatalıdır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Mail adresi hatalıdır. Lütfen kontrol ediniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {

                        bool mail = mailkontrol(e_mail.Text);
                        if (mail == true || e_mail.Text == "")
                        {
                            baglanti2.Close();
                            baglanti.Open();
                            baglanti2.Open();
                            giris_tar.CustomFormat = "MM/dd/yyyy";
                            dogum_tar.CustomFormat = "MM/dd/yyyy";
                            giris_tar.Format = DateTimePickerFormat.Custom;
                            dogum_tar.Format = DateTimePickerFormat.Custom;
                            if (tcno.Text.Length > 10)
                            {
                                SqlCommand Rez_ekle = new SqlCommand("insert into R_Musteriekle(OtelID, KimlikBelgeTuru, KimlikSeriNo, TcKimlikNo, Ad, Soyad, BabaAd, AnaAd, DogumYeri, DogumTarihi, Uyruk, Cinsiyeti, MedeniHali, KayıtlıOlduguil, KayıtlıOlduguilce, KayıtlıOlduguMahalle, CiltNo, AileSıraNo, SıraNo,Yetiskin_Cocuk, Telefon, CepTelefon, Email, AracPlakaNo, Musteri_is, ikametkah, Notlar,Durum) values('" + OtelID + "','" + kim_bel_tur.SelectedIndex + "','" + kimlik_seri_no.Text + "','" + Convert.ToUInt64(tcno.Text) + "','" + ad.Text + "','" + soyad.Text + "','" + babaad.Text + "','" + anaad.Text + "','" + dogum_yer.Text + "','" + dogum_tar.Text + "','" + uyruk.SelectedIndex + "','" + cins.SelectedIndex + "','" + med_hal.SelectedIndex + "','" + il.Text + "','" + ilce.Text + "','" + mah.Text + "','" + cilt_no.Text + "','" + aile_sıra_no.Text + "','" + sıra_no.Text + "','" + yet_cocuk.SelectedIndex + "','" + tel.Text + "','" + cep_tel.Text+ "','" + e_mail.Text + "','" + arac_plaka_no.Text + "','" + isi.Text + "','" + ikamet_adres.Text + "','" + not.Text + "',1)", baglanti);
                                Rez_ekle.ExecuteNonQuery();
                                baglanti.Close();

                                SqlCommand Rez_rapor = new SqlCommand("insert into RezRapor values('" + OtelID + "','" + tcno.Text + "','" + giris_tar.Text + "','" + ad.Text + "','" + soyad.Text + "','" + uyruk.SelectedIndex + "')", baglanti2);
                                Rez_rapor.ExecuteNonQuery();
                                baglanti2.Close();

                                baglanti8.Open();
                                SqlCommand uyrukekle = new SqlCommand("insert into Uyruk values('" + OtelID + "','" + tcno.Text + "','" + comboBox1.Text + "')", baglanti8);
                                uyrukekle.ExecuteNonQuery();
                                baglanti8.Close();

                                dogum_tar.Format = DateTimePickerFormat.Long;
                                giris_tar.Format = DateTimePickerFormat.Long;
                                MessageBox.Show("Rezervasyon başarıyla oluşturulmuştur.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                yenile();
                            }
                            else
                                MessageBox.Show("Kimlik numarası hatalıdır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();
                        }
                        else
                        {
                            MessageBox.Show("Mail adresi hatalıdır. Lütfen kontrol ediniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                baglanti2.Close();
                baglanti3.Close();
                baglanti4.Close();
            }
      //  }
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
    }


        
        void yenile()
        {
            kim_bel_tur.SelectedItem = null;
            kimlik_seri_no.Text = "";
            tcno.Text = "";
            ad.Text = "";
            soyad.Text = "";
            babaad.Text = "";
            anaad.Text = "";
            dogum_tar.Text = "";
            dogum_yer.Text = "";
            uyruk.SelectedItem = null;
            cins.SelectedItem = null;
            med_hal.SelectedItem = null;
            il.SelectedItem = null;
            ilce.SelectedItem = null;
            mah.SelectedItem = null;
            ilce.Items.Clear();
            mah.Items.Clear();
            cilt_no.Text = "";
            aile_sıra_no.Text = "";
            sıra_no.Text = "";
            yet_cocuk.SelectedItem = null;
            tel.Text = "";
            cep_tel.Text = "";
            e_mail.Text = "";
            arac_plaka_no.Text = "";
            isi.Text = "";
            ikamet_adres.Text = "";
            not.Text = "";

            comboBox1.Enabled = false;
            comboBox1.SelectedItem = "Turkey";
        }
        public static bool mailkontrol(string Telefon)
        {
            string mailvalidation = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Match Eslesme = Regex.Match(Telefon, mailvalidation, RegexOptions.IgnoreCase);
            return Eslesme.Success; // bool değer döner
        }

        private void Temizle_Click(object sender, EventArgs e)
        {
            yenile();
        }

        private void R_musterı_ekle_Load(object sender, EventArgs e)
        {
            dogum_tar.MaxDate = DateTime.Now;
            giris_tar.MinDate = DateTime.Now;
            tcno.MaxLength = 11;
            kimlik_seri_no.MaxLength = 9;

            baglanti.Open();
            SqlCommand illiste = new SqlCommand("select CityName from City", baglanti);
            SqlDataReader iller = illiste.ExecuteReader();
            while(iller.Read())
            {
                il.Items.Add(iller[0].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand ulkeliste = new SqlCommand("select CountryName from Country", baglanti);
            SqlDataReader ulkeler = ulkeliste.ExecuteReader();
            while (ulkeler.Read())
            {
                comboBox1.Items.Add(ulkeler[0].ToString());
            }
            baglanti.Close();

            comboBox1.SelectedItem = "Turkey";
        }
        private void Iptal_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Tcno_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi(e);
        }

        private void Cilt_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi(e);
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

        private void Aile_sıra_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi(e);
        }

        private void Sıra_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi(e);
        }

        private void Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi(e);
        }

        private void Cep_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            sayi(e);
        }
        private void Ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void Soyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void Babaad_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void Anaad_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void İl_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void İlce_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void Mah_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void E_mail_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void İsi_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void İkamet_adres_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void Not_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void Dogum_yer_KeyPress(object sender, KeyPressEventArgs e)
        {
            harf(e);
        }

        private void Tcno_TextChanged(object sender, EventArgs e)
        {
            if (tcno.Text.Length ==11)
            {
                UInt64 tc = Convert.ToUInt64(tcno.Text);
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * From R_Musteriekle where TcKimlikNo='" + tc + "' and OtelID='" + OtelID + "'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    Boolean a = Boolean.Parse(oku["KimlikBelgeTuru"].ToString());
                    if (a == true)
                        kim_bel_tur.Text = "T.C Kimlik Belgesi";
                    else if (a == false)
                        kim_bel_tur.Text = "Yabancı Kimlik";

                    kimlik_seri_no.Text = oku["KimlikSeriNo"].ToString();
                    tcno.Text = oku["TcKimlikNo"].ToString();
                    ad.Text = oku["Ad"].ToString();
                    soyad.Text = oku["Soyad"].ToString();
                    babaad.Text = oku["BabaAd"].ToString();
                    anaad.Text = oku["AnaAd"].ToString();
                    dogum_yer.Text = oku["DogumYeri"].ToString();
                    dogum_tar.Value = Convert.ToDateTime(oku["DogumTarihi"].ToString());

                    Boolean b = Boolean.Parse(oku["Uyruk"].ToString());
                    if (b == true)
                        uyruk.Text = "Türk";
                    else if (b == false)
                        uyruk.Text = "Yabancı";

                    Boolean c = Boolean.Parse(oku["Cinsiyeti"].ToString());
                    if (c == true)
                        cins.Text = "Erkek";
                    else if (c == false)
                        cins.Text = "Kadın";

                    Boolean d = Boolean.Parse(oku["MedeniHali"].ToString());
                    if (d == true)
                        med_hal.Text = "Evli";
                    else if (d == false)
                        med_hal.Text = "Bekar";

                    il.Text = oku["KayıtlıOlduguil"].ToString();
                    ilce.Text = oku["KayıtlıOlduguilce"].ToString();
                    mah.Text = oku["KayıtlıOlduguMahalle"].ToString();
                    cilt_no.Text = oku["CiltNo"].ToString();
                    aile_sıra_no.Text = oku["AileSıraNo"].ToString();
                    sıra_no.Text = oku["SıraNo"].ToString();

                    Boolean h = Boolean.Parse(oku["Yetiskin_Cocuk"].ToString());
                    if (h == true)
                        cins.Text = "Yetişkin";
                    else if (h == false)
                        cins.Text = "Çocuk";

                    tel.Text = oku["Telefon"].ToString();
                    cep_tel.Text = oku["CepTelefon"].ToString();
                    e_mail.Text = oku["Email"].ToString();
                    arac_plaka_no.Text = oku["AracPlakaNo"].ToString();
                    isi.Text = oku["Musteri_is"].ToString();
                    ikamet_adres.Text = oku["ikametkah"].ToString();
                    not.Text = oku["Notlar"].ToString();
                }

                baglanti7.Open();
                SqlCommand komut2 = new SqlCommand("SELECT uyruk From Uyruk where KimlikNo='" + tc + "' and OtelID='" + OtelID + "'", baglanti7);
                SqlDataReader oku2 = komut2.ExecuteReader();
                while (oku2.Read())
                {
                    comboBox1.SelectedItem = oku2[0].ToString();
                }
                baglanti7.Close();

            }
            baglanti.Close();

               
        }

        private void il_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilce.Items.Clear();

            int ilid=0;
            baglanti5.Open();
            SqlCommand ilidal = new SqlCommand("select CityID from City where CityName='" + il.Text + "'", baglanti5);
            SqlDataReader ilidgetir = ilidal.ExecuteReader();
            while(ilidgetir.Read())
            {
                ilid = int.Parse(ilidgetir[0].ToString());
            }
            baglanti5.Close();
            baglanti5.Open();
            SqlCommand ilceliste = new SqlCommand("select TownName from Town where CityID='" + ilid.ToString() + "'", baglanti5);
            SqlDataReader ilcedoldur = ilceliste.ExecuteReader();
            while(ilcedoldur.Read())
            {
                ilce.Items.Add(ilcedoldur[0].ToString());
            }
            baglanti5.Close();
        }

        private void ilce_SelectedIndexChanged(object sender, EventArgs e)
        {
            mah.Items.Clear();
            int ilceid = 0;
            int ilid = 0;
            baglanti6.Open();
            SqlCommand ilidal = new SqlCommand("select CityID from City where CityName='" + il.Text + "'", baglanti6);
            SqlDataReader ilidgetir = ilidal.ExecuteReader();
            while (ilidgetir.Read())
            {
                ilid = int.Parse(ilidgetir[0].ToString());
            }
            baglanti6.Close();
            baglanti6.Open();
            SqlCommand ilceliste = new SqlCommand("select TownID from Town where CityID='" + ilid.ToString() + "' and TownName='"+ilce.Text+"'", baglanti6);
            SqlDataReader ilcedoldur = ilceliste.ExecuteReader();
            while (ilcedoldur.Read())
            {
                ilceid=int.Parse(ilcedoldur[0].ToString());
            }
            baglanti6.Close();
            baglanti6.Open();
            SqlCommand mahalleal = new SqlCommand("select DistrictName from District where TownID='"+ilceid.ToString()+"'", baglanti6);
            SqlDataReader mahallegetir = mahalleal.ExecuteReader();
            while (mahallegetir.Read())
            {
                mah.Items.Add(mahallegetir[0].ToString());
            }
            baglanti6.Close();
        }

        private void kim_bel_tur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(kim_bel_tur.SelectedIndex==0)
            {
                label3.Text = "Pasaport No:";
                label2.Text = "Pasaport Seri No:";
            }
            else
            {
                label3.Text = "Kimlik No:";
                label2.Text = "Kimlik Seri No:";
            }
        }

        private void uyruk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uyruk.SelectedIndex == 0)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.SelectedItem = "Turkey";
            }
        }
    }
}
