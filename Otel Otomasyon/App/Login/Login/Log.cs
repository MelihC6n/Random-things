using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[0].Cells[0].Value = "04.05.2019";
            bunifuCustomDataGrid1.Rows[0].Cells[1].Value = "Oda Durumu Değişikliği";
            bunifuCustomDataGrid1.Rows[0].Cells[2].Value = "Mustafa";
            bunifuCustomDataGrid1.Rows[0].Cells[3].Value = "DOĞAN";
            bunifuCustomDataGrid1.Rows[0].Cells[4].Value = "jollydogn";
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[1].Cells[0].Value = "06.04.2018";
            bunifuCustomDataGrid1.Rows[1].Cells[1].Value = "Rezervasyon Kaydı";
            bunifuCustomDataGrid1.Rows[1].Cells[2].Value = "Emrah";
            bunifuCustomDataGrid1.Rows[1].Cells[3].Value = "TUNÇ";
            bunifuCustomDataGrid1.Rows[1].Cells[4].Value = "emrah.png";
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[2].Cells[0].Value = "02.01.2016";
            bunifuCustomDataGrid1.Rows[2].Cells[1].Value = "Rezervasyon Silme";
            bunifuCustomDataGrid1.Rows[2].Cells[2].Value = "Melih Can";
            bunifuCustomDataGrid1.Rows[2].Cells[3].Value = "AKGÜNEŞ";
            bunifuCustomDataGrid1.Rows[2].Cells[4].Value = "melihcanakgunes";
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
