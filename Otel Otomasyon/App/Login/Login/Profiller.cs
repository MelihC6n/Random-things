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
    public partial class Profiller : Form
    {
        public Profiller()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Login.veritabani);
        SqlConnection con2= new SqlConnection(Login.veritabani);
        int otelid = Login.id;
        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("Select Ad,Soyad From R_Musteriekle where TcKimlikNo like '"+bunifuMaterialTextbox1.Text+"%' and OtelID='"+otelid+"'", con);
           

            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                listBox1.Items.Clear();
                while (dr.Read())
                {
                   
                        
                        listBox1.Items.Add(dr["Ad"].ToString() + " " + dr["Soyad"].ToString());
                     

                }
                if (bunifuMaterialTextbox1.Text=="")
                {
                    bunifuCustomDataGrid1.DataSource = null;
                    listBox1.Items.Clear();
                    temizle();
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("HATA" + ex.Message);

            }
            finally
            {
                con.Close();

            }




        }
        void listbox()
        {

            SqlCommand cmd = new SqlCommand("Select Ad,Soyad From R_Musteriekle where TcKimlikNo like '" + bunifuMaterialTextbox1.Text + "%' and OtelID='" + otelid + "'", con);


            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                listBox1.Items.Clear();
                while (dr.Read())
                {


                    listBox1.Items.Add(dr["Ad"].ToString() + " " + dr["Soyad"].ToString());
                 


                }
                if (bunifuMaterialTextbox1.Text == "")
                {
                    bunifuCustomDataGrid1.DataSource = null;
                    listBox1.Items.Clear();
                    temizle();
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show("HATA" + ex.Message);

            }
            finally
            {
                con.Close();

            }
        }//listboxtaki veriyi güncellemek için yaptım


            void temizle()
        {
            Tctxt.Clear();
            Adtxt.Clear();
            Soyadtxt.Clear();
            Anatxt.Clear();
            Babatxt.Clear();
            Dogumyertxt.Clear();
            dateTimePicker1.ResetText();
            cmbuyruk.ResetText();
            ceptxt.Clear();
            Emailtxt.Clear();
            istxt.Clear();
            ikamettxt.Clear();
            txtNotlar.ResetText();
           
            
        }//textbox ve diğer nesneleri clearaladım
        
        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            temizle();
            if(listBox1.SelectedItem.ToString()!=null)
            {
            string metin = listBox1.SelectedItem.ToString();

           
             
            SqlCommand cmd = new SqlCommand("Select TcKimlikNo,Ad,Soyad,BabaAd,AnaAd,DogumYeri,DogumTarihi,Uyruk,CepTelefon,Email,Musteri_is,ikametkah,Notlar from R_Musteriekle where TcKimlikNo like ''+@tc+'%' and Ad+' '+Soyad='"+metin+"'  and OtelID='"+otelid+"'", con);
            cmd.Parameters.AddWithValue("@tc", bunifuMaterialTextbox1.Text);
         
            try
            {

                if (con.State != ConnectionState.Open) //bağlantıyı kontrol edip açık değilse açtım
                    con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) // datareaderden gerekli verileri aldım
                {
                  

                    Tctxt.Text = dr["TcKimlikNo"].ToString();
                    tclabel.Text = Tctxt.Text;
                    Adtxt.Text = dr["Ad"].ToString();
                    Soyadtxt.Text = dr["Soyad"].ToString();
                    Babatxt.Text = dr["BabaAd"].ToString();
                    Anatxt.Text = dr["AnaAd"].ToString();
                    Dogumyertxt.Text = dr["Dogumyeri"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dr["DogumTarihi"].ToString());
                    
                    Boolean a =Convert.ToBoolean(dr["Uyruk"].ToString());
                   if(a==true)
                    {
                        cmbuyruk.Items.Clear();
                        cmbuyruk.Items.Add("Türk");
                        cmbuyruk.SelectedIndex = 0;
                    }
                   else if(a==false)
                    {
                        cmbuyruk.Items.Clear();
                        cmbuyruk.Items.Add("Yabancı");
                        cmbuyruk.SelectedIndex = 0;
                    }

                    ceptxt.Text = dr["CepTelefon"].ToString();
                    Emailtxt.Text = dr["Email"].ToString();
                    istxt.Text = dr["Musteri_is"].ToString();
                    ikamettxt.Text = dr["ikametkah"].ToString();
                    txtNotlar.Text = dr["Notlar"].ToString();


                }
                yenile();

                }

           

            catch (Exception ex)
            {

                MessageBox.Show("HATA" + ex.Message);

            }
            finally
            {
                con.Close();

            }
            }
        }


        private void bunifuMaterialTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//string veri girişini engelliyor
            
        }

        private void Profiller_Load(object sender, EventArgs e)
        {
            this.bunifuCustomDataGrid1.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            
          

        }
        void yenile()
        {   try
            {

                SqlDataAdapter da = new SqlDataAdapter("select  * from profiller where TcKimlikNo='" + Tctxt.Text + "' and OtelID='" + otelid + "'", con2);
                //profiller diye sqlde view oluşturdum onu excel için kullanacağız
                DataSet ds = new DataSet();
                da.Fill(ds);

                bunifuCustomDataGrid1.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnkisiguncelle_Click(object sender, EventArgs e)
        {
            try
            {

                if (Tctxt.Text != "" && Tctxt.TextLength == 11)
            {


                DialogResult cevap = MessageBox.Show("Kişinin Verileri Güncellenecek Emin misiniz?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("Update R_Musteriekle set TcKimlikNo=@tc,Ad=@ad,Soyad=@soyad,BabaAd=@babaad,AnaAd=@anaad,Dogumyeri=@dy,DogumTarihi=@dt,Uyruk=@uyruk,CepTelefon=@cep,Email=@email,Musteri_is=@is,Notlar=@nott,ikametkah=@ikametkah where TcKimlikNo=@aratc and OtelID='" + otelid + "'", con);

                    cmd.Parameters.AddWithValue("@tc", Tctxt.Text);
                    cmd.Parameters.AddWithValue("@ad", Adtxt.Text);
                    cmd.Parameters.AddWithValue("@soyad", Soyadtxt.Text);
                    cmd.Parameters.AddWithValue("@babaad", Babatxt.Text);
                    cmd.Parameters.AddWithValue("@anaad", Anatxt.Text);
                    //  cmd.Parameters.AddWithValue("@dy", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@dy", Dogumyertxt.Text);
                    cmd.Parameters.Add("@dt", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToString("yyyy-MM-dd");


                    //cmd.Parameters["@dy"].Value = dateTimePicker1.Value;

                    if (cmbuyruk.Text == "Türk")
                    {
                        cmd.Parameters.AddWithValue("@uyruk", true);
                    }
                    else if (cmbuyruk.Text == "Yabancı")
                    {
                        cmd.Parameters.AddWithValue("@uyruk", false);
                    }
                    cmd.Parameters.AddWithValue("@cep", ceptxt.Text.ToString());
                    cmd.Parameters.AddWithValue("@email", Emailtxt.Text);
                    cmd.Parameters.AddWithValue("@is", istxt.Text);
                    cmd.Parameters.AddWithValue("@nott", txtNotlar.Text);
                    cmd.Parameters.AddWithValue("@aratc", tclabel.Text);
                    cmd.Parameters.AddWithValue("@ikametkah", ikamettxt.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    listbox();
                    yenile();
                    con.Close();

                    MessageBox.Show("Kişi başarı ile güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Güncelleme işlemi iptal edildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }





            }
            else
            {
                MessageBox.Show("Kişi Bilgileri boş olduğu için güncelleme yapamazsınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        

        }

        private void cmbuyruk_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmbuyruk.Items.Count  < 2)
            {
                if (cmbuyruk.Text == "Türk")
                {
                    cmbuyruk.Items.Add("Yabancı");
                }

                else if (cmbuyruk.Text == "Yabancı")
                {
                    cmbuyruk.Items.Add("Türk");
                }

            }
        }

        private void Tctxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ceptxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Adtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void Soyadtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void Babatxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void Anatxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void istxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void Dogumyertxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

