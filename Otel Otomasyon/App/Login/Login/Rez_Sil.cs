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
    public partial class Rez_Sil : Form
    {
        public int OtelID = Login.id;
        public Rez_Sil()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Login.veritabani);
        private void Rez_Sil_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void Veri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                baglanti.Open();
                int a = veri.CurrentRow.Index;
                string b = veri.Rows[a].Cells[0].Value.ToString();
                DialogResult cevap = MessageBox.Show("Rezervasyonu Silmek İstediğinizden Emin Misiniz ? ", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    SqlCommand komut = new SqlCommand("delete from RezRapor where TcNo='" + b + "' and OtelID='" + OtelID + "'", baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Rezervasyon Silinmiştir.");
                    baglanti.Close();
                    yenile();
                }
                else if (cevap == DialogResult.No)
                {
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
            
        }
        void yenile()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select TcNo,GelisTarih,ad,soyad from RezRapor where OtelID='" + OtelID + "'", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            veri.DataSource = dt; 
            veri.Columns[0].HeaderText="Kimlik Numarası";
            veri.Columns[0].Width = 150;
            veri.Columns[1].HeaderText = "Geliş Tarihi";
            veri.Columns[1].Width = 200;
            veri.Columns[2].HeaderText = "Adı";
            veri.Columns[2].Width = 150;
            veri.Columns[3].HeaderText = "Soyadı";
            veri.Columns[3].Width = 150;
            baglanti.Close();
        }
    }
}
