using System;
using System.Data.SqlClient;


using System.Windows.Forms;

namespace k_takip
{
    public partial class RegisterForm : Form
    {
        
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void kaydolma_Load(object sender, EventArgs e)
        {

        }

private void button2_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // 1️⃣ boş kontrol
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Tüm alanları doldur");
                return;
            }

            // 2️⃣ şifre eşleşme kontrolü
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor");
                return;
            }

            using (SqlConnection cn = DatabaseHelper.GetConnection())
            {
                cn.Open();

                
                SqlCommand check = new SqlCommand(
                    "SELECT COUNT(*) FROM k_Table WHERE username=@u", cn);
                check.Parameters.AddWithValue("@u", textBox1.Text);

                int exists = (int)check.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Kullanıcı adı alınmış");
                    return;
                }

                string hashedPassword =
                    PasswordHelper.HashPassword(textBox2.Text);

              
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO k_Table(username,password) VALUES(@u,@p)", cn);

                cmd.Parameters.AddWithValue("@u", textBox1.Text);
                cmd.Parameters.AddWithValue("@p", hashedPassword);

                cmd.ExecuteNonQuery();//burada bir hata verdi bak

                MessageBox.Show("Kayıt başarılı");

                
                LoginForm login = new LoginForm();
                login.Show();
                this.Hide();
            }


        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
