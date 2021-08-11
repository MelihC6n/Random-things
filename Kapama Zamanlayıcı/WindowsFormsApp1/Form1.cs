using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sure = "";
            try
            {
                int.Parse(textBox2.Text);
                if (comboBox1.SelectedIndex == 0 && textBox2.Text != "")
                {
                    sure = textBox2.Text;
                    Kapa(sure);
                }
                else if (comboBox1.SelectedIndex == 1 && textBox2.Text != "")
                {
                    sure = (int.Parse(textBox2.Text) * 60).ToString();
                    Kapa(sure);
                }
                else if (comboBox1.SelectedIndex == 2 && textBox2.Text != "")
                {
                    sure = (int.Parse(textBox2.Text) * 60 * 60).ToString();
                    Kapa(sure);
                }
                else if (comboBox1.SelectedIndex == 3 && textBox2.Text != "")
                {
                    sure = (int.Parse(textBox2.Text) * 60 * 60 * 24).ToString();
                    Kapa(sure);
                }
                else if (comboBox1.SelectedIndex == 4 && textBox2.Text != "")
                {
                    sure = (int.Parse(textBox2.Text) * 60 * 60 * 24 * 7).ToString();
                    Kapa(sure);
                }
                else
                {
                    MessageBox.Show("Bir süre tipi ve süre değeri seçiniz!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Süre değerini boş bırakmayınız ve sayısal bir değer giriniz!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
            }

        }

        private void Kapa(string sure)
        {
            try
            {
                var proc1 = new ProcessStartInfo();
                string anyCommand = "shutdown -s -t " + sure;
                proc1.UseShellExecute = false;

                proc1.WorkingDirectory = @"C:\Windows\System32";

                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.Verb = "runas";
                proc1.Arguments = "/c " + anyCommand;
                proc1.WindowStyle = ProcessWindowStyle.Normal;
                Process.Start(proc1);
            }
            catch (Exception)
            {
                MessageBox.Show("Komut sistemine izin verilmediği için kapatma ayarlaması başarısız!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var proc1 = new ProcessStartInfo();
                string anyCommand = "shutdown -a";
                proc1.UseShellExecute = false;

                proc1.WorkingDirectory = @"C:\Windows\System32";

                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.Verb = "runas";
                proc1.Arguments = "/c " + anyCommand;
                proc1.WindowStyle = ProcessWindowStyle.Normal;
                Process.Start(proc1);
            }
            catch (Exception)
            {
                MessageBox.Show("Komut sistemine izin verilmediği için iptal etme başarısız!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
