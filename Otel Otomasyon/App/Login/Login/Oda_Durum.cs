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
    public partial class Oda_Durum : Form
    {
        SqlConnection baglan = new SqlConnection(Login.veritabani);
        int otelid = Login.id;

        public Oda_Durum()
        {
            InitializeComponent();
        }

        private void Oda_Durum_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand odalist = new SqlCommand("select OdaNo from Odalar where OtelId='" + otelid + "'", baglan);
                baglan.Open();
                SqlDataReader getir = odalist.ExecuteReader();
                while (getir.Read())
                {
                    comboBox1.Items.Add(getir[0]);
                }
                baglan.Close();
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                comboBox2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                comboBox2.Enabled = true;
                SqlCommand odalist = new SqlCommand("select Durum,Televizyon,Klima,Buzdolabi,MiniBar,Telefon from Odalar where OtelId='" + otelid + "' and OdaNo='" + comboBox1.Text + "'", baglan);
                baglan.Open();
                SqlDataReader getir = odalist.ExecuteReader();
                getir.Read();
                if (getir[0].ToString() == "2")
                {
                    comboBox2.Text = "Temiz";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    PanelSifirla();
                }
                else if (getir[0].ToString() == "3")
                {
                    comboBox2.SelectedItem = comboBox2.Items[0];
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    PanelSifirla();
                }
                else if (getir[0].ToString() == "4")
                {
                    comboBox2.SelectedItem = comboBox2.Items[1];
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                    panel1.Enabled = true;
                    checkBox1.Checked = Convert.ToBoolean(getir[1]);
                    checkBox2.Checked = Convert.ToBoolean(getir[2]);
                    checkBox3.Checked = Convert.ToBoolean(getir[3]);
                    checkBox4.Checked = Convert.ToBoolean(getir[4]);
                    checkBox5.Checked = Convert.ToBoolean(getir[5]);
                }
                else if (getir[0].ToString() == "5")
                {
                    comboBox2.SelectedItem = comboBox2.Items[1];
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    PanelSifirla();
                }
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                PanelSifirla();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel1.Enabled = true;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex==1)
            { radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else
            { radioButton1.Enabled = false;radioButton1.Checked = false;
                radioButton2.Enabled = false;radioButton2.Checked = false;
                PanelSifirla();
            }
            if (comboBox2.SelectedIndex == 0 || comboBox2.SelectedIndex == 1)
            {
                bunifuFlatButton1.Visible = true;
            }
            else
                bunifuFlatButton1.Visible = false;
        }
        private void PanelSifirla()
        {
            panel1.Enabled = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="")
            MessageBox.Show("Lütfen bir oda seçiniz","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Information);

            else {
                if (comboBox2.SelectedIndex == 0)
                    Durum(3);
                else if (comboBox2.SelectedIndex == 1 && radioButton1.Checked == true)
                    Durum(4);
                else if (comboBox2.SelectedIndex == 1 && radioButton2.Checked == true)
                    Durum(5);
                else if (comboBox2.SelectedIndex == 1 && (radioButton1.Checked == false || radioButton2.Checked == false))
                    MessageBox.Show("Lütfen arıza tipini seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Hide();
            try
            {
                var pencere = (KatHizmetleri)Application.OpenForms["KatHizmetleri"];
                if (pencere != null)
                {
                    pencere.OdaDurumDegisimi();
                    pencere.OdaOnaylanacaklar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Durum(int a)
        {
            try
            {
                SqlCommand guncelle = new SqlCommand("update  Odalar set Durum='" + a + "',Televizyon='" + checkBox1.Checked + "',Klima='" + checkBox2.Checked + "',Buzdolabi='" + checkBox3.Checked + "',MiniBar='" + checkBox4.Checked + "',Telefon='" + checkBox5.Checked + "'  where OdaNo='" + comboBox1.Text + "' and OtelId='" + otelid + "'", baglan);
                baglan.Open();
                guncelle.ExecuteNonQuery();
                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand guncelle = new SqlCommand("update  Odalar set Durum=6,Televizyon='" + checkBox1.Checked + "',Klima='" + checkBox2.Checked + "',Buzdolabi='" + checkBox3.Checked + "',MiniBar='" + checkBox4.Checked + "',Telefon='" + checkBox5.Checked + "'  where OdaNo='" + comboBox1.Text + "' and OtelId='" + otelid + "'", baglan);
                baglan.Open();
                guncelle.ExecuteNonQuery();
                baglan.Close();
                this.Hide();
                var pencere = (KatHizmetleri)Application.OpenForms["KatHizmetleri"];
                if (pencere != null)
                {
                    pencere.OdaDurumDegisimi();
                    pencere.OdaOnaylanacaklar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
