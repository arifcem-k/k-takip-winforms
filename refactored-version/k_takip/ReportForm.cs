using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace k_takip
{
    public partial class ReportForm : Form
    {
        
        public ReportForm()
        {
            InitializeComponent();
        }

        SqlConnection cn = DatabaseHelper.GetConnection();

        void VeriListele()
        {
            cn.Open();
            SqlDataAdapter veri = new SqlDataAdapter("select *from b_Table", cn);
            DataTable table = new DataTable();
            veri.Fill(table);
            dataGridView1.DataSource = table;
            cn.Close();
        }

        private void takip_Load(object sender, EventArgs e)
        {
            VeriListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                 
            String aad = textBox1.Text; String mem= textBox2.Text; String kad = textBox3.Text;
            String ac = richTextBox1.Text; String trh = dateTimePicker1.Value.ToString("yyyy-MM-dd");
           
            DataTable dt = (DataTable)dataGridView1.DataSource;
            DataRow newRow = dt.NewRow();
            newRow.ItemArray = new object[] {kad, aad, mem,trh,ac };

            dt.Rows.Add(newRow);
            dataGridView1.DataSource = dt;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource; 
            if (dt.Rows.Count > 0)
            {
                dt.Rows.RemoveAt(dt.Rows.Count - 1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            writer.Write(cell.Value + "\t");
                        }
                        writer.WriteLine();
                    }
                }
            }
        }
    }
    }
    

        
 
