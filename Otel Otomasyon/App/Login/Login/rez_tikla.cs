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
    public partial class rez_tikla : Form
    {
        public rez_tikla()
        {
            InitializeComponent();
        }
        int OtelID = Login.id;
        SqlConnection con = new SqlConnection(Login.veritabani);
        SqlConnection con2 = new SqlConnection(Login.veritabani);
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        public void gridyenile()//rezrapor tablosundan verileri çekiyor
        {
            try
            {
                DateTime mydatetime = DateTime.Now.Date;
                string sqlformat = mydatetime.ToString("yyyy-MM-dd");

                SqlCommand cmd = new SqlCommand("Select TcNo,ad,soyad,GelisTarih from RezRapor where TcNo like '" + bunifuMaterialTextbox1.Text + "%' and OtelID='" + OtelID + "' and GelisTarih='"+sqlformat+"'", con);

                bunifuCustomDataGrid1.Rows.Clear();
                int a = 0;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    bunifuCustomDataGrid1.Rows.Add();
                    bunifuCustomDataGrid1.Rows[a].Cells[0].Value = sdr["TcNo"].ToString();
                    bunifuCustomDataGrid1.Rows[a].Cells[1].Value = sdr["ad"].ToString();
                    bunifuCustomDataGrid1.Rows[a].Cells[2].Value = sdr["soyad"].ToString();
                    bunifuCustomDataGrid1.Rows[a].Cells[3].Value = sdr["GelisTarih"].ToString();
                    a++;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            gridyenile();
        }

        private void btnrezekle_Click(object sender, EventArgs e)
        {
            r_musterı_ekle ekle = new r_musterı_ekle();
            ekle.Show();
        }

        private void rez_tikla_Load(object sender, EventArgs e)
        {
            gridyenile();
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//hücreye 2 kere tıkladığımızda verileri r_konak datagridine ekliyor
        {
            //// burada kaldık tc kimliğe göre datagrid sınırla hem oda gridi hem k_giris selecti yap
            try
            {

                int hata = 0;  //kişi bu odada hatası 
                int hata2 = 0;  //kişi bu otelde hatası 
                r_konak konak = Application.OpenForms["r_konak"] as r_konak;
                UInt64 tc = UInt64.Parse(bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.CurrentRow.Index].Cells[0].Value.ToString());
                con.Open();
                con2.Open();


                SqlCommand datagonder = new SqlCommand("select TcKimlikNo,Ad,Soyad,Cinsiyeti,Uyruk from R_Musteriekle where TcKimlikNo=" + tc + " and OtelID='" + OtelID + "'", con2);
                SqlDataReader getir = datagonder.ExecuteReader();

                if (konak.r_konakdatagrid.RowCount - 1 > 0)
                {
                    for (int satır = 0; satır < konak.r_konakdatagrid.RowCount - 1; satır++)
                    {
                        if (konak.r_konakdatagrid.Rows[satır].Cells[0].Value.ToString() == tc.ToString())
                            hata++;
                    }
                }
                SqlCommand sorgu = new SqlCommand("select COUNT(TcKimlik) from K_Giris where TcKimlik='" + tc + "' and OtelID='"+OtelID+"'", con);
                SqlDataReader varmi = sorgu.ExecuteReader();
                while (varmi.Read())
                {
                    if (int.Parse(varmi[0].ToString()) >= 1)
                        hata2++;
                }

                if (hata == 0 && hata2 == 0)
                {
                    while (getir.Read())
                    {
                        konak.r_konakdatagrid.Rows.Add();
                        konak.r_konakdatagrid.Rows[konak.r_konakdatagrid.RowCount - 2].Cells[0].Value = getir[0];
                        konak.r_konakdatagrid.Rows[konak.r_konakdatagrid.RowCount - 2].Cells[1].Value = getir[1];
                        konak.r_konakdatagrid.Rows[konak.r_konakdatagrid.RowCount - 2].Cells[2].Value = getir[2];
                        if(Boolean.Parse(getir[3].ToString())==true)
                        {
                            konak.r_konakdatagrid.Rows[konak.r_konakdatagrid.RowCount - 2].Cells[3].Value = "Erkek";
                        }
                      else if (Boolean.Parse(getir[3].ToString()) == false)
                        {
                            konak.r_konakdatagrid.Rows[konak.r_konakdatagrid.RowCount - 2].Cells[3].Value = "Kadın";
                        }

                        if(Boolean.Parse(getir[4].ToString())== true)
                        {
                            konak.r_konakdatagrid.Rows[konak.r_konakdatagrid.RowCount - 2].Cells[4].Value = "Türk";
                        }
                        if (Boolean.Parse(getir[4].ToString()) == false)
                        {
                            konak.r_konakdatagrid.Rows[konak.r_konakdatagrid.RowCount - 2].Cells[4].Value = "Yabancı";
                        }

                        konak.r_konakdatagrid.Rows[konak.r_konakdatagrid.RowCount - 2].Cells[5].Value = konak.datetpGelis.Value.ToString("yyyy-MM-dd");
                        konak.r_konakdatagrid.Rows[konak.r_konakdatagrid.RowCount - 2].Cells[6].Value = konak.DatetpGidis.Value.ToString("yyyy-MM-dd");
                        MessageBox.Show("Kişi odaya eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (hata > 0)
                    MessageBox.Show("Bu odada böyle bir kişi zaten mevcut.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (hata2 > 0)
                    MessageBox.Show("Bu otelde böyle bir kişi zaten mevcut.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con2.Close();
                con.Close();

                this.Hide();
                konak.Focus();

        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


}

        private void rez_tikla_FormClosed(object sender, FormClosedEventArgs e)
        {
            r_konak konak = new r_konak();
            konak.BringToFront();
        }
    }
        }
   

