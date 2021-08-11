using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuButton;
using Microsoft.VisualBasic.PowerPacks;
using System.Data.SqlClient;
using System.Threading;

namespace Login
{
    public partial class Resepsiyon : Form
    {

        public Resepsiyon()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Login.veritabani);
        SqlConnection con2 = new SqlConnection(Login.veritabani);
        SqlConnection con3 = new SqlConnection(Login.veritabani);
        SqlConnection con4 = new SqlConnection(Login.veritabani);
        SqlConnection con5 = new SqlConnection(Login.veritabani);
        SqlConnection con6 = new SqlConnection(Login.veritabani);
        SqlConnection con7 = new SqlConnection(Login.veritabani);


        int OtelId = Login.id;

        odaicerik f = new odaicerik();
  
        
        private void tikla(object sender, EventArgs e)
        {
            f.Hide();

        }
        public static Point GetMousePositionWindowsForms()
        {
            System.Drawing.Point point = Control.MousePosition;
            return new Point(point.X, point.Y);
        }

        private void Btndn_MouseLeave(object sender, EventArgs e)
        {
            f.Hide();
        }
        private void Btndn_DoubleClick(object sender, EventArgs e)
        {
           

            BunifuButton btndn = sender as BunifuButton;
            string metin = btndn.ButtonText;
            string[] parca = metin.Split('-');
            int splitodano = int.Parse(parca[0]);
            try
            {
                SqlCommand cmd = new SqlCommand("Select Durum From Odalar where OdaNo='" + splitodano + "' and OtelID='" + OtelId + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr[0].ToString()) == 1 && btndn.BackColor == System.Drawing.Color.FromArgb(51, 122, 183))
                    {
                        goto git;

                    }
                    else if (Convert.ToInt32(dr[0].ToString()) == 2 && btndn.BackColor == Color.MediumSeaGreen)
                    {
                        goto git;

                    }
                    else
                    {
                        MessageBox.Show("Kirli veya arızalı odaya giriş yapamazsınız", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        goto git2;
                    }
                }


                git:

                r_konak r_Konak = new r_konak();
                r_Konak.Show();
                r_konak r_Konak2 = Application.OpenForms["r_konak"] as r_konak;
                r_Konak2.cmbodano.Text = splitodano.ToString();

                git2:;
                con.Close();
               
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void gorunum()
        {
            this.DataGridViewFolio.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            this.DataGridView3Gun.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            this.DataGridView1Hafta.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            this.DataGridViewHatirlatmalar.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            

        }//bunifudatagridviewlerin font tipini belirledim
        void folioyenileme()
        {
            SqlDataAdapter da = new SqlDataAdapter("select TOP 0 TcKimlikNo as TcKimlikNumarası,Ad,Soyad,GelisTarihi as GelişTarihi from folyo   ", con2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataGridViewFolio.DataSource = ds.Tables[0];
        }
        private void Resepsiyon_Load(object sender, EventArgs e)
        {

            // int OtelId = Convert.ToInt32(label8.Text.ToString());

            Control.CheckForIllegalCrossThreadCalls = false;
            try
            {



                DateTime myDateTime = DateTime.Now.Date;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");

                DateTime myDateTime2 = DateTime.Now.Date.AddDays(+3);
                string sqlFormattedDate2 = myDateTime2.ToString("yyyy-MM-dd");

                int a = 0;

                    SqlCommand gun = new SqlCommand("Select OdaNo,GidisTarihi,Ad from gun3 where (GidisTarihi Between '" + sqlFormattedDate + "' and '" + sqlFormattedDate2 + "')    and OtelID='"+OtelId+"'", con);
                    con.Open();
                    SqlDataReader gunreader = gun.ExecuteReader();
                    while (gunreader.Read())
                    {
                    DataGridView3Gun.Rows.Add();
                        DataGridView3Gun.Rows[a].Cells[0].Value = gunreader[0].ToString();
                        DataGridView3Gun.Rows[a].Cells[1].Value = Convert.ToDateTime(gunreader[1].ToString()).ToString("yyyy.MM.dd");
                        DataGridView3Gun.Rows[a].Cells[2].Value = gunreader[2].ToString();

                    a++;
                    }
                    con.Close();



                DateTime date = DateTime.Now.Date;
                string tarih = date.ToString("yyyy-MM-dd");
                DateTime date2 = DateTime.Now.Date.AddDays(+7);
                string tarih2= date2.ToString("yyyy-MM-dd");
                int b = 0;
                SqlCommand hafta = new SqlCommand("Select GelisTarih,ad,soyad from RezRapor where (GelisTarih Between '" + tarih + "' and '" + tarih2 + "')    and OtelID='" + OtelId + "'", con2);
                con2.Open();
                SqlDataReader haftareader = hafta.ExecuteReader();
                while (haftareader.Read())
                {
                    DataGridView1Hafta.Rows.Add();
                    DataGridView1Hafta.Rows[b].Cells[0].Value = Convert.ToDateTime(haftareader[0].ToString()).ToString("yyyy.MM.dd");
                    DataGridView1Hafta.Rows[b].Cells[1].Value = haftareader[1].ToString();
                    DataGridView1Hafta.Rows[b].Cells[2].Value = haftareader[2].ToString();

                    b++;
                }
                con2.Close();



                gorunum();

                SqlCommand hatirlatma = new SqlCommand("Select Tarih,HatirlatmaBaslik,HatirlatmaNo from Hatirlatmalar where OtelID='" + OtelId + "'", con);
                con.Open();
                SqlDataReader hatirladr = hatirlatma.ExecuteReader();
                int k = 0;
                while (hatirladr.Read())
                {

                    DataGridViewHatirlatmalar.Rows.Add();
                    DataGridViewHatirlatmalar.Rows[k].Cells[0].Value = Convert.ToDateTime(hatirladr[0].ToString());
                    DataGridViewHatirlatmalar.Rows[k].Cells[1].Value = hatirladr[1].ToString();
                    DataGridViewHatirlatmalar.Rows[k].Cells[2].Value = hatirladr[2].ToString();
                    k++;
                }
                con.Close();




                con.Open();
                SqlCommand cmd = new SqlCommand("select DISTINCT(Kat)  from Odalar where OtelId='" + OtelId + "'", con); // kat bilgisini buradan alıyoruz

          

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    TabPage tabPage1 = new TabPage();
                    tabPage1.Name = "tabPage" + sdr[0].ToString(); //tabpagelere kat ismini atıyarak 
                    tabPage1.Text = "KAT " + sdr[0].ToString();
                    tabPage1.Font = new Font("Verdana", 12);
                    tabControl1.TabPages.Add(tabPage1);

                    FlowLayoutPanel flp1 = new FlowLayoutPanel();
                    flp1.BackColor = Color.WhiteSmoke;
                    Controls.Add(flp1);
                    tabPage1.Controls.Add(flp1);
                    flp1.Dock = DockStyle.Fill;
                    flp1.AutoScroll = true;


                    SqlCommand cmd3 = new SqlCommand("select OdaNo,OdaTip,Durum from Odalar where OtelID='" + OtelId + "' and Kat='" + sdr[0].ToString() + "' ORDER BY OdaNo ASC", con2);
                    //kata göre odaları ekleyen sorgumuz
                    con2.Open();
                    SqlDataReader sdr3 = cmd3.ExecuteReader();
                    int i = 1;
                    while (sdr3.Read())
                    {
                        BunifuButton btndn = new BunifuButton();

                        btndn.Margin = new System.Windows.Forms.Padding(5);
                        btndn.IdleBorderThickness = 1;
                        if (i == 1)
                        { Thread.Sleep(50); i++; }
                        if (int.Parse(sdr3[1].ToString()) == 1)
                        {
                            btndn.ButtonText = sdr3[0].ToString() + " - " + "SGL";
                        }
                        else if (int.Parse(sdr3[1].ToString()) == 2)
                        {
                            btndn.ButtonText = sdr3[0].ToString() + " - " + "TSU";
                        }
                        else if (int.Parse(sdr3[1].ToString()) == 3)
                        {
                            btndn.ButtonText = sdr3[0].ToString() + " - " + "TWR";
                        }
                        else if (int.Parse(sdr3[1].ToString()) == 4)
                        {
                            btndn.ButtonText = sdr3[0].ToString() + " - " + "DBL";
                        }
                        else if (int.Parse(sdr3[1].ToString()) == 5)
                        {
                            btndn.ButtonText = sdr3[0].ToString() + " - " + "TR";
                        }
                        else if (int.Parse(sdr3[1].ToString()) == 6)
                        {
                            btndn.ButtonText = sdr3[0].ToString() + " - " + "QUAD";
                        }

                        btndn.Size = new Size(192, 125);
                        btndn.Font = new Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
                        btndn.ForeColor = System.Drawing.Color.White;
                        btndn.Click += new EventHandler(Btndn_MouseClick);
                        btndn.MouseEnter += new EventHandler(Btndn_MouseEnter);
                        btndn.MouseLeave += new EventHandler(Btndn_MouseLeave);
                        btndn.MouseDoubleClick += new MouseEventHandler(Btndn_DoubleClick);

                        if (sdr3[2].ToString() == "1") //dolu oda için
                        {
                            btndn.IdleBorderColor = System.Drawing.Color.FromArgb(51, 122, 183);
                            btndn.IdleFillColor = System.Drawing.Color.FromArgb(51, 122, 183);
                            btndn.BackColor = btndn.IdleFillColor;
                            btndn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(40, 96, 144);
                            btndn.onHoverState.FillColor = System.Drawing.Color.FromArgb(40, 96, 144);
                        }


                        else if (sdr3[2].ToString() == "2") //boş oda için
                        {
                            btndn.IdleBorderColor = Color.MediumSeaGreen;
                            btndn.IdleFillColor = Color.MediumSeaGreen;
                            btndn.BackColor = btndn.IdleFillColor;
                            btndn.onHoverState.BorderColor = Color.SeaGreen;
                            btndn.onHoverState.FillColor = Color.SeaGreen;
                        }


                        else if (sdr3[2].ToString() == "3") //kirli oda için
                        {
                            btndn.IdleBorderColor = System.Drawing.Color.FromArgb(215, 0, 0);
                            btndn.IdleFillColor = System.Drawing.Color.FromArgb(215, 0, 0);
                            btndn.BackColor = btndn.IdleFillColor;
                            btndn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(174, 0, 0);
                            btndn.onHoverState.FillColor = System.Drawing.Color.FromArgb(174, 0, 0);
                        }

                        else if (sdr3[2].ToString() == "4") // arızalı oda için
                        {
                            btndn.IdleBorderColor = Color.Gray;
                            btndn.IdleFillColor = Color.Gray;
                            btndn.BackColor = btndn.IdleFillColor;
                            btndn.onHoverState.BorderColor = Color.DimGray;
                            btndn.onHoverState.FillColor = Color.DimGray;
                        }

                        else
                        {       //herhangi bir sorun olursa diye default renk
                            btndn.IdleBorderColor = Color.Black;
                            btndn.IdleFillColor = Color.Black;
                            btndn.BackColor = btndn.IdleFillColor;
                            btndn.onHoverState.BorderColor = Color.Black;
                            btndn.onHoverState.FillColor = Color.Black;
                        }

                        flp1.Controls.Add(btndn);

                    }
                    con2.Close();

                }

            con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            th1 = new Thread(new ThreadStart(Yenile));
            th1.Start();


        }//buton oluşturma,oda verisi çekme
        public Thread th1;
        private void Btndn_MouseEnter(object sender, EventArgs e)
        {
            try
            {

                f.Show();
                f.Visible = false;
                f = Application.OpenForms["odaicerik"] as odaicerik;
                BunifuButton btndn = sender as BunifuButton;

                string metin = btndn.ButtonText;
                string[] parca = metin.Split('-');
                int splitodano = int.Parse(parca[0]);


                Point a = new Point();
                a = GetMousePositionWindowsForms();

                if (a.X < 1000)
                    f.Location = new Point(a.X - 10, a.Y);
                else
                    f.Location = new Point(a.X - 250, a.Y);

                f.Visible = true;
                SqlCommand cmd = new SqlCommand("Select OdaNo,Ad,Soyad,GelisTarihi,GidisTarihi,OdaTip from Odaicerik where OdaNo='" + splitodano + "' and OtelID='" + OtelId + "'", con);
                SqlCommand cmd2 = new SqlCommand("Select Count(Ad) as sayi from Odaicerik where OdaNo='" + splitodano + "' and OtelID='" + OtelId + "'", con2);
                SqlCommand cmd3 = new SqlCommand("Select OdaNo,OdaTip,Durum from Odalar where OdaNo='" + splitodano + "' and OtelID='" + OtelId + "'", con);
                  con2.Close();
                con2.Open();
                SqlDataReader sdr2 = cmd2.ExecuteReader();

                while (sdr2.Read())
                {

                    if (Convert.ToInt32(sdr2[0].ToString()) > 0)
                    {
                        con.Close();
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            f.lblodano.Text = sdr["OdaNo"].ToString();
                            f.lbladsoyad.Text = sdr["Ad"].ToString() + " " + sdr["Soyad"].ToString();
                            int b = Convert.ToInt32(sdr["OdaTip"].ToString());
                            if (b == 1)
                            {
                                f.lblodatip.Text = "Tek kişilik oda(SGL)";
                            }
                            else if (b == 2)
                            {
                                f.lblodatip.Text = "Standart iki yataklı oda(TFSU)";

                            }
                            else if (b == 3)
                            {
                                f.lblodatip.Text = "İki kişilik oda(TR) ";
                            }
                            else if (b == 4)
                            {
                                f.lblodatip.Text = "Standart çift kişilik oda(DBL)";
                            }
                            else if (b == 5)
                            {
                                f.lblodatip.Text = "Üç kişilik oda(TR)";
                            }
                            else if (b == 6)
                            {
                                f.lblodatip.Text = "Dört kişilik oda(Quad)";
                            }
                            f.lblgelistarihi.Text = sdr["GelisTarihi"].ToString();
                            f.lblgidistarihi.Text = sdr["GidisTarihi"].ToString();
                            f.lblodadurumu.Text = "Dolu";
                        }
                        con.Close();                      
                      
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        SqlDataReader sdr3 = cmd3.ExecuteReader();
                        while (sdr3.Read())
                        {
                            f.lblodano.Text = sdr3["OdaNo"].ToString();
                            int i = int.Parse(sdr3["Durum"].ToString());

                            if (i == 2)
                            {
                                f.lblodadurumu.Text = "Boş";
                            }
                            else if (i == 3)
                            {
                                f.lblodadurumu.Text = "Kirli";
                            }
                            else if (i == 4)
                            {
                                f.lblodadurumu.Text = "Arızalı";
                            }

                            int b = Convert.ToInt32(sdr3["OdaTip"].ToString());
                            if (b == 1)
                            {
                                f.lblodatip.Text = "Tek kişilik oda(SGL)";
                            }
                            else if (b == 2)
                            {
                                f.lblodatip.Text = "Standart iki yataklı oda(TFSU)";

                            }
                            else if (b == 3)
                            {
                                f.lblodatip.Text = "İki kişilik oda(TR) ";
                            }
                            else if (b == 4)
                            {
                                f.lblodatip.Text = "Standart çift kişilik oda(DBL)";
                            }
                            else if (b == 5)
                            {
                                f.lblodatip.Text = "Üç kişilik oda(TR)";
                            }
                            else if (b == 6)
                            {
                                f.lblodatip.Text = "Dört kişilik oda(Quad)";
                            }
                            f.lbladsoyad.Text = "------";
                            f.lblgelistarihi.Text = "------";
                            f.lblgidistarihi.Text = "------";
                        }
                        con.Close();
                    }

                }

            con2.Close();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

}
        private void Btndn_MouseClick(object sender, EventArgs e)
        {

            try
            {

                BunifuButton btndn = sender as BunifuButton;

                string metin = btndn.ButtonText;
                string[] parca = metin.Split('-');
                int odano = int.Parse(parca[0]);

                SqlCommand cmd = new SqlCommand("select DISTINCT(Durum) as sayi from Odalar", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    if (dr["sayi"].ToString() == "1" && btndn.BackColor == System.Drawing.Color.FromArgb(51, 122, 183)) //Dolu Oda için
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select TcKimlikNo as KimlikNo,Ad,Soyad,GelisTarihi as GelişTarihi from folyo  where OdaNo='" + odano + "' and OtelID='" + OtelId + "' ORDER BY GelisTarihi ASC ", con2);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        DataGridViewFolio.DataSource = ds.Tables[0];
                    }
                    else if (dr["sayi"].ToString() == "2" && btndn.BackColor == Color.MediumSeaGreen) // Boş oda için
                    {
                        folioyenileme();
                        //MessageBox.Show("Oda boş olduğu için Folio bilgileri getirilemiyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dr["sayi"].ToString() == "3" && btndn.BackColor == System.Drawing.Color.FromArgb(215, 0, 0)) //Kirli Oda için
                    {
                        folioyenileme();
                        //MessageBox.Show("Oda boş ve kirli olduğu için Folio bilgileri getirilemiyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dr["sayi"].ToString() == "4" && btndn.BackColor == Color.Gray) // Arızalı Oda için
                    {
                        folioyenileme();
                        // MessageBox.Show("Oda Arızalı olduğu için Folio bilgileri getirilemiyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }




                con.Close();


        }//folio bilgileri 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

}
        public void Yenile()
        {
            try
            {
                while (true)
                {
                    git:
                    con3.Open();

                    Thread.Sleep(500);
                    SqlCommand oda = new SqlCommand(" select OdaNo,Durum from Odalar where OtelID='" + OtelId + "'", con3);
                    SqlDataReader dr = oda.ExecuteReader();
                    while (dr.Read())
                    {
                        con4.Open();
                        SqlCommand karsilastir = new SqlCommand("select Durum from OdalarYenileme where OdaNo='" + dr[0].ToString() + "' and OtelID='" + OtelId + "'", con4);
                        SqlDataReader dr2 = karsilastir.ExecuteReader();
                        while (dr2.Read())
                        {
                            if (dr[1].ToString() == dr2[0].ToString())
                            {

                            }
                            else
                            {
                               

                                if (this.InvokeRequired)
                                {
                                    this.Invoke((MethodInvoker)delegate ()
                                    {

                                        tabControl1.TabPages.Clear();
                                    });
                                }
                          
                            con.Open();
                            SqlCommand cmd = new SqlCommand("select DISTINCT(Kat)  from Odalar where OtelId='" + OtelId + "'", con); // kat bilgisini buradan alıyoruz
                        
                                
                                SqlDataReader calislütfen = cmd.ExecuteReader();
                                while (calislütfen.Read())
                                {
                                    TabPage tabPage1 = new TabPage();
                                    tabPage1.Name = "tabPage" + calislütfen[0].ToString(); //tabpagelere kat ismini atıyarak 
                                    tabPage1.Text = "KAT " + calislütfen[0].ToString();
                                    tabPage1.Font = new Font("Verdana", 12);

                                    if (this.InvokeRequired)
                                    {
                                        this.Invoke((MethodInvoker)delegate ()
                                           {

                                               tabControl1.TabPages.Add(tabPage1);
                                           });
                                    }



                                    FlowLayoutPanel flp1 = new FlowLayoutPanel();
                                    if (this.InvokeRequired)
                                    {
                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            Controls.Add(flp1);
                                            tabPage1.Controls.Add(flp1);

                                        });
                                    }
                                    flp1.BackColor = Color.WhiteSmoke;

                                    flp1.Dock = DockStyle.Fill;
                                    flp1.AutoScroll = true;



                                    SqlCommand cmd3 = new SqlCommand("select OdaNo,OdaTip,Durum from Odalar where OtelID='" + OtelId + "' and Kat='" + calislütfen[0].ToString() + "' ORDER BY OdaNo ASC", con7);
                                //kata göre odaları ekleyen sorgumuz
                                    //con2.Close();
                                    con7.Open();
                                    SqlDataReader sdr3 = cmd3.ExecuteReader();
                                    int i = 1;
                                    while (sdr3.Read())
                                    {
                                        BunifuButton btndn = new BunifuButton();

                                        btndn.Margin = new System.Windows.Forms.Padding(5);
                                        btndn.IdleBorderThickness = 1;
                                        if (i == 1)
                                        { Thread.Sleep(100); i++; }
                                        if (int.Parse(sdr3[1].ToString()) == 1)
                                        {
                                            btndn.ButtonText = sdr3[0].ToString() + " - " + "SGL";
                                        }
                                        else if (int.Parse(sdr3[1].ToString()) == 2)
                                        {
                                            btndn.ButtonText = sdr3[0].ToString() + " - " + "TSU";
                                        }
                                        else if (int.Parse(sdr3[1].ToString()) == 3)
                                        {
                                            btndn.ButtonText = sdr3[0].ToString() + " - " + "TWR";
                                        }
                                        else if (int.Parse(sdr3[1].ToString()) == 4)
                                        {
                                            btndn.ButtonText = sdr3[0].ToString() + " - " + "DBL";
                                        }
                                        else if (int.Parse(sdr3[1].ToString()) == 5)
                                        {
                                            btndn.ButtonText = sdr3[0].ToString() + " - " + "TR";
                                        }
                                        else if (int.Parse(sdr3[1].ToString()) == 6)
                                        {
                                            btndn.ButtonText = sdr3[0].ToString() + " - " + "QUAD";
                                        }

                                        btndn.Size = new Size(192, 125);
                                        btndn.Font = new Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
                                        btndn.ForeColor = System.Drawing.Color.White;
                                        btndn.Click += new EventHandler(Btndn_MouseClick);
                                        btndn.MouseEnter += new EventHandler(Btndn_MouseEnter);
                                        btndn.MouseLeave += new EventHandler(Btndn_MouseLeave);
                                        btndn.MouseDoubleClick += new MouseEventHandler(Btndn_DoubleClick);

                                        if (sdr3[2].ToString() == "1") //dolu oda için
                                        {
                                            btndn.IdleBorderColor = System.Drawing.Color.FromArgb(51, 122, 183);
                                            btndn.IdleFillColor = System.Drawing.Color.FromArgb(51, 122, 183);
                                            btndn.BackColor = btndn.IdleFillColor;
                                            btndn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(40, 96, 144);
                                            btndn.onHoverState.FillColor = System.Drawing.Color.FromArgb(40, 96, 144);
                                        }


                                        else if (sdr3[2].ToString() == "2") //boş oda için
                                        {
                                            btndn.IdleBorderColor = Color.MediumSeaGreen;
                                            btndn.IdleFillColor = Color.MediumSeaGreen;
                                            btndn.BackColor = btndn.IdleFillColor;
                                            btndn.onHoverState.BorderColor = Color.SeaGreen;
                                            btndn.onHoverState.FillColor = Color.SeaGreen;
                                        }


                                        else if (sdr3[2].ToString() == "3") //kirli oda için
                                        {
                                            btndn.IdleBorderColor = System.Drawing.Color.FromArgb(215, 0, 0);
                                            btndn.IdleFillColor = System.Drawing.Color.FromArgb(215, 0, 0);
                                            btndn.BackColor = btndn.IdleFillColor;
                                            btndn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(174, 0, 0);
                                            btndn.onHoverState.FillColor = System.Drawing.Color.FromArgb(174, 0, 0);
                                        }

                                        else if (sdr3[2].ToString() == "4") // arızalı oda için
                                        {
                                            btndn.IdleBorderColor = Color.Gray;
                                            btndn.IdleFillColor = Color.Gray;
                                            btndn.BackColor = btndn.IdleFillColor;
                                            btndn.onHoverState.BorderColor = Color.DimGray;
                                            btndn.onHoverState.FillColor = Color.DimGray;
                                        }

                                        else
                                        {       //herhangi bir sorun olursa diye default renk
                                            btndn.IdleBorderColor = Color.Black;
                                            btndn.IdleFillColor = Color.Black;
                                            btndn.BackColor = btndn.IdleFillColor;
                                            btndn.onHoverState.BorderColor = Color.Black;
                                            btndn.onHoverState.FillColor = Color.Black;
                                        }


                                        if (this.InvokeRequired)
                                        {
                                            this.Invoke((MethodInvoker)delegate ()
                                            {
                                                flp1.Controls.Add(btndn);
                                            });
                                        }

                                    }
                                    con7.Close();



                                }

                                con.Close();

                              
                                con5.Open();
                                SqlCommand odalis = new SqlCommand(" select OdaNo,Durum from Odalar where OtelID='" + OtelId + "'", con5);
                                SqlDataReader dr3 = odalis.ExecuteReader();
                                while (dr3.Read())
                                {
                                    con6.Open();
                                    SqlCommand guncelle = new SqlCommand("update OdalarYenileme set Durum=@durum where OdaNo='" + dr3[0].ToString() + "' and OtelID='" + OtelId + "'", con6);
                                    guncelle.Parameters.AddWithValue("@durum", dr3[1].ToString());
                                    guncelle.ExecuteNonQuery();
                                    con6.Close();

                                }
                                con5.Close();
                                con3.Close();
                                con4.Close();

                                goto git;
                            }
                        }
                        con4.Close();
                    }
                    con3.Close();
                    





                }

        }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void Resepsiyon_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                th1.Abort();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    
      

        private void DataGridViewHatirlatmalar_DoubleClick(object sender, EventArgs e)
        {
            Hatirlatmaekle hatirlatmaekle = new Hatirlatmaekle();
            hatirlatmaekle.Show();
           
            
        }

        private void DataGridViewHatirlatmalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {


                Hatirlatmaekle hatirlatmaekle = new Hatirlatmaekle();
                hatirlatmaekle.Show();
                hatirlatmaekle.panel1.Visible = true;
                con.Open();

                SqlCommand cmd = new SqlCommand("Select Hatirlatmametin From Hatirlatmalar Where Hatirlatmano=@hatirlatmano And OtelID='" + OtelId + "'", con);
                cmd.Parameters.AddWithValue("@hatirlatmano", DataGridViewHatirlatmalar.CurrentRow.Cells[2].Value.ToString());

                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {


                    hatirlatmaekle.richTextBox2.Text = dr[0].ToString();

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
      
    }
}