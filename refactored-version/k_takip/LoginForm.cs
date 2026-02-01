using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace k_takip
{
    public partial class LoginForm : Form
    {
      
        public LoginForm()
        {
            InitializeComponent();
        }

        private void giris_Load(object sender, EventArgs e)
        {
  

            using (SqlConnection cn = DatabaseHelper.GetConnection())
            {
                cn.Open();
                
            }

        }
        

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş alan bırakma");
                return;
            }

            string hashedPassword = PasswordHelper.HashPassword(textBox2.Text);

            using (SqlConnection cn = DatabaseHelper.GetConnection())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM k_Table WHERE username=@u AND password=@p",
                    cn);

                cmd.Parameters.AddWithValue("@u", textBox1.Text);
                cmd.Parameters.AddWithValue("@p", hashedPassword);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Hoşgeldin " + textBox1.Text);
                    ReportForm frm = new ReportForm();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış");
                }
            }
        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm kayit = new RegisterForm();
            kayit.Show();
            this.Hide();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Your logic to handle closing here
            this.Close();
        }
    }
}
