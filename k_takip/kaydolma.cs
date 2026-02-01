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
    public partial class kaydolma : Form
    {
        SqlDataReader dr;
        SqlConnection cn;
        public kaydolma()
        {
            InitializeComponent();
        }

        private void kaydolma_Load(object sender, EventArgs e)
        {

            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\N100454\Desktop\ç_rapor\k_takip\Database1.mdf;Integrated Security=True");
            cn.Open();
            

            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            giris login = new giris();
            login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (textBox3.Text != string.Empty || textBox2.Text != string.Empty ||textBox1.Text != string.Empty)
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                      SqlCommand  cmd = new SqlCommand("select * from k_Table where username='" + textBox1.Text + "'",  cn );
                     dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            dr.Close();
                            MessageBox.Show("Kullanıcı adı müsayit deyil başka bir ad deneyin ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dr.Close();
                             cmd = new SqlCommand("insert into k_Table values(@username,@password)", cn);
                            cmd.Parameters.AddWithValue("username", textBox1.Text);
                            cmd.Parameters.AddWithValue("password", textBox2.Text);
                       
                        cmd.ExecuteNonQuery();
                            MessageBox.Show("hesabınız oluşturuldu .giriş yapabilirsiniz.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifre ve ŞİFRE TEKRARI aynı olmalıdır ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("devametmek için BÜTÜN boşlukları doldurun", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Your logic to handle closing here
            this.Close();
        }
    }
}
