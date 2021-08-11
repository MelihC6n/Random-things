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
    public partial class KatHizmetleri : Form
    {//"Server=DESKTOP-7JCKATF\\MELIH;Integrated Security=SSPI;Initial Catalog=OtelProje"
        SqlConnection baglan = new SqlConnection(Login.veritabani);
        int otelid = Login.id;

        public KatHizmetleri()
        {
            InitializeComponent();
        }

        private void OdaServisi_Load(object sender, EventArgs e)
        {
            OdaDurumDegisimi();
            OdaOnaylanacaklar();
        }

        public void OdaOnaylanacaklar()
        {
            try
            {
                Yenile2();
                baglan.Open();
                SqlCommand odalist = new SqlCommand("select OdaNo,Durum from Odalar where OtelId='" + otelid + "' and Durum=6", baglan);
                
                SqlDataReader getir = odalist.ExecuteReader();
                while (getir.Read())
                {
                    BunifuButton btndn = new BunifuButton();
                    btndn.Size = new Size(135, 102);
                    btndn.Margin = new System.Windows.Forms.Padding(5);
                    btndn.IdleBorderThickness = 1;
                    btndn.ButtonText = getir[0].ToString();
                    btndn.Font = new Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);

                    btndn.ForeColor = System.Drawing.Color.White;

                    btndn.IdleBorderColor = Color.Gold;
                    btndn.IdleFillColor = Color.Gold;

                    flowLayoutPanel1.Controls.Add(btndn);
                    btndn.onHoverState.BorderColor = btndn.IdleBorderColor;
                    btndn.onHoverState.FillColor = btndn.IdleFillColor;
                    btndn.MouseEnter += belirtec;
                    btndn.MouseLeave += ayril;
                    btndn.Click += Onay;
                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Onay(object sender, EventArgs e)
        {
            try
            {
                BunifuButton btn = sender as BunifuButton;
                DialogResult cevap = MessageBox.Show("Odanın temizlendiğini / onarıldığını onaylıyor musunuz ?", "ONAY EKRANI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    baglan.Open();
                    SqlCommand guncelle = new SqlCommand("update  Odalar set Durum=2 where OdaNo='" + btn.ButtonText + "' and OtelId='" + otelid + "'", baglan);
                    
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                }
                OdaOnaylanacaklar();
                OdaDurumDegisimi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void TumOnay()
        {
            try
            {
                if(flowLayoutPanel1.Controls.Count>0)
                { 
                DialogResult cevap = MessageBox.Show("Tüm odaların temizlendiğini / onarıldığını onaylıyor musunuz?", "ONAY EKRANI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                        baglan.Open();
                        SqlCommand guncelle = new SqlCommand("update  Odalar set Durum=2 where Durum=6 and OtelId='" + otelid + "'", baglan);
                    
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                }
                OdaOnaylanacaklar();
                OdaDurumDegisimi();
                }
                else
                    MessageBox.Show("Onaylanacak oda mevcut değil.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {

            }
           
        }

        private void ayril(object sender, EventArgs e)
        {
            BunifuButton btn = sender as BunifuButton;
            if(btn.IdleBorderThickness==3)
            btn.IdleBorderThickness = 1;
        }

        private void belirtec(object sender, EventArgs e)
        {
            BunifuButton btn = sender as BunifuButton;
            btn.IdleBorderThickness = 4;
        }

        private void bunifuCheckbox5_OnChange(object sender, EventArgs e)
        {
            OdaDurumDegisimi();
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            OdaDurumDegisimi();
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            OdaDurumDegisimi();
        }

        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            OdaDurumDegisimi();
        }

        private void bunifuCheckbox4_OnChange(object sender, EventArgs e)
        {
            OdaDurumDegisimi();
        }

        public void OdaDurumDegisimi()
        {
            try
            {
                Yenile();

                String sqlsorgu = "";
                if (bunifuCheckbox5.Checked == true)
                    sqlsorgu = sqlsorgu + "Durum=2 or ";
                if (bunifuCheckbox1.Checked == true)
                    sqlsorgu = sqlsorgu + "Durum=1 or ";
                if (bunifuCheckbox2.Checked == true)
                    sqlsorgu = sqlsorgu + "Durum=3 or ";
                if (bunifuCheckbox3.Checked == true)
                    sqlsorgu = sqlsorgu + "Durum=4 or ";
                if (bunifuCheckbox4.Checked == true)
                    sqlsorgu = sqlsorgu + "Durum=5 or ";
                sqlsorgu = sqlsorgu.Remove(sqlsorgu.Length - 4, 3);
                baglan.Open();
                SqlCommand odalist = new SqlCommand("select OdaNo,Durum from Odalar where OtelId='" + otelid + "' and (" + sqlsorgu + ")", baglan);

                SqlDataReader getir = odalist.ExecuteReader();
                while (getir.Read())
                {
                    BunifuButton btndn = new BunifuButton();
                    btndn.Size = new Size(135, 102);
                    btndn.Margin = new System.Windows.Forms.Padding(5);
                    btndn.IdleBorderThickness = 1;
                    btndn.ButtonText = getir[0].ToString();
                    btndn.Font = new Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);

                    btndn.ForeColor = System.Drawing.Color.White;
                    if (getir[1].ToString() == "1")
                    {
                        btndn.IdleBorderColor = System.Drawing.Color.FromArgb(51, 122, 183);
                        btndn.IdleFillColor = System.Drawing.Color.FromArgb(51, 122, 183);
                    }

                    else if (getir[1].ToString() == "2")
                    {
                        btndn.IdleBorderColor = System.Drawing.Color.FromArgb(61, 214, 22);
                        btndn.IdleFillColor = System.Drawing.Color.FromArgb(61, 214, 22);
                    }

                    else if (getir[1].ToString() == "3")
                    {
                        btndn.IdleBorderColor = Color.Red;
                        btndn.IdleFillColor = Color.Red;
                    }

                    else if (getir[1].ToString() == "4")
                    {
                        btndn.IdleBorderColor = Color.Gray;
                        btndn.IdleFillColor = Color.Gray;
                    }

                    else
                    {
                        btndn.IdleBorderColor = Color.Black;
                        btndn.IdleFillColor = Color.Black;
                    }
                    flowLayoutPanel2.Controls.Add(btndn);
                    btndn.onHoverState.BorderColor = btndn.IdleBorderColor;
                    btndn.onHoverState.FillColor = btndn.IdleFillColor;
                    btndn.MouseEnter += belirtec;
                    btndn.MouseLeave += ayril;
                    btndn.Click += DurumPencere;
                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void DurumPencere(object sender, EventArgs e)
        {
            
            BunifuButton btn = sender as BunifuButton;
            if (btn.IdleFillColor == System.Drawing.Color.FromArgb(51, 122, 183))
            {
                MessageBox.Show("Dolu oda durumu değiştirilemez", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Oda_Durum pencere = new Oda_Durum();
                pencere.Show();
                pencere.Controls[11].Text = btn.ButtonText;
            }

        }

        private void Yenile()
        {
            int temizle = flowLayoutPanel2.Controls.Count;
            for (int a = 0; a < temizle; a++)
            {
                flowLayoutPanel2.Controls.Remove(flowLayoutPanel2.Controls[0]);
            }


        }
        private void Yenile2()
        {
            int temizle = flowLayoutPanel1.Controls.Count;
            for (int a = 0; a < temizle; a++)
            {
                flowLayoutPanel1.Controls.Remove(flowLayoutPanel1.Controls[0]);
            }
        }
    }
}
