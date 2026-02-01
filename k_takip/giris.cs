using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_takip
{
    public partial class giris : Form
    {
        SqlConnection cn;
        SqlDataReader dr;
        public giris()
        {
            InitializeComponent();
        }

        private void giris_Load(object sender, EventArgs e)
        {

             cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Desktop\ç_rapor\k_takip\Database1.mdf;Integrated Security=True");
            cn.Open();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty || textBox1.Text != string.Empty)
            {

             SqlCommand   cmd = new SqlCommand("select * from k_Table where username='" +textBox1.Text + "' and password='" + textBox2.Text + "'", cn);
                 dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    MessageBox.Show("Hoşgeldin"+" "+ textBox1.Text);
                    rapor ana = new rapor();
                    ana.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("bu isim ve şifreyle kayıtlı bir HESAP YOK ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("devam etmek için BÜTÜN boşlukları doldurun", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            kaydolma kayit = new kaydolma();
            kayit.ShowDialog();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Your logic to handle closing here
            this.Close();
        }
    }
}
