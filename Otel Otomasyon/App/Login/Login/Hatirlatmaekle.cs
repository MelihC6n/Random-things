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
    public partial class Hatirlatmaekle : Form
    {
        public Hatirlatmaekle()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Login.veritabani);
        int OtelID = Login.id;
        private void btn_kay_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand hatirlatmaekle = new SqlCommand("insert into Hatirlatmalar(OtelID,HatirlatmaBaslik,HatirlatmaMetin) values(@otelid,@baslik,@metin)", con);
                hatirlatmaekle.Parameters.AddWithValue("@otelid", OtelID);
                hatirlatmaekle.Parameters.AddWithValue("@baslik", textBox1.Text);
                hatirlatmaekle.Parameters.AddWithValue("@metin", richTextBox1.Text);
                con.Open();
                hatirlatmaekle.ExecuteNonQuery();
                MessageBox.Show("Hatırlatma başarı ile eklenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                yenile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void yenile()
        {
            try
            {
                Resepsiyon resepsiyon = Application.OpenForms["Resepsiyon"] as Resepsiyon;
                resepsiyon.DataGridViewHatirlatmalar.Rows.Clear();
                SqlCommand cmd = new SqlCommand("Select Tarih,HatirlatmaBaslik,Hatirlatmano From Hatirlatmalar where OtelID='" + OtelID + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    resepsiyon.DataGridViewHatirlatmalar.Rows.Add();
                    resepsiyon.DataGridViewHatirlatmalar.Rows[i].Cells[0].Value = Convert.ToDateTime(dr[0].ToString());
                    resepsiyon.DataGridViewHatirlatmalar.Rows[i].Cells[1].Value = dr[1].ToString();
                    resepsiyon.DataGridViewHatirlatmalar.Rows[i].Cells[2].Value = dr[2].ToString();

                    i++;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
