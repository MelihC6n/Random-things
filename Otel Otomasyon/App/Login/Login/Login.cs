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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string veritabani = "Data Source=DESKTOP-7JCKATF\\MELIH;Integrated Security=SSPI;Initial Catalog=OtelProje";
        SqlConnection con = new SqlConnection(veritabani);
        SqlConnection con2 = new SqlConnection(veritabani);
       
        public static int id;
        private void bunifuTileButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Kullanicilar where KullaniciAdi='" + bunifuMetroTextbox1.Text + "' and Sifre='" + bunifuMetroTextbox2.Text + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                 
                    OtelArayüz oa = new OtelArayüz();
                    Resepsiyon resepsiyon = new Resepsiyon();
                    oa.Show();
                    this.Hide();
                    id=int.Parse(dr["OtelID"].ToString());

                    if (Boolean.Parse(dr["Rezervasyon"].ToString()) == true)
                    {
                        oa.btnrezervasyon.Enabled = true;
                    }
                    else
                    {
                        oa.btnrezervasyon.Enabled = false;
                    }
                    if (Boolean.Parse(dr["Resepsiyon"].ToString()) == true)
                    {
                        oa.btnresepsiyon.Enabled = true;
                    }
                    else
                    {
                        oa.btnresepsiyon.Enabled = false;
                    }
                    if (Boolean.Parse(dr["Profiller"].ToString()) == true)
                    {
                        oa.btnprofiller.Enabled = true;
                    }
                    else
                    {
                        oa.btnprofiller.Enabled = false;
                    }
                    if (Boolean.Parse(dr["Raporlar"].ToString()) == true)
                    {
                        oa.btnraporlar.Enabled = true;
                    }
                    else
                    {
                        oa.btnraporlar.Enabled = false;
                    }
                    if (Boolean.Parse(dr["OdaServisi"].ToString()) == true)
                    {
                        oa.btnodaservisi.Enabled = true;
                    }
                    else
                    {
                        oa.btnodaservisi.Enabled = false;
                    }
                    if (Boolean.Parse(dr["KatHizmetleri"].ToString()) == true)
                    {
                        oa.btnkathizmetleri.Enabled = true;
                    }
                    else
                    {
                        oa.btnkathizmetleri.Enabled = false;
                    }
                    if (Boolean.Parse(dr["OtelYonetimi"].ToString()) == true)
                    {
                        oa.btnotelyonetimi.Enabled = true;
                    }
                    else
                    {
                        oa.btnotelyonetimi.Enabled = false;
                    }
                    

                }
                else
                {
                    MessageBox.Show("KullanıcıAdı Veya Şifre Yanlış");
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Admin where Kullanici='" + bunifuMetroTextbox1.Text + "' and Sifre='" + bunifuMetroTextbox2.Text + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Admin admin = new Admin();
                    admin.Show();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
