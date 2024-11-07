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

namespace Manage_tour
{
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
        }

        public string dbcon = "Data Source = IKIENKINZERO\\SQLEXPRESS;Initial Catalog = manage_tour_1; Persist Security Info=True;User ID = sa; Password=***********;Trust Server Certificate=True";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
            panel2.Visible = !panel2.Visible;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = !panel2.Visible;
            panel1.Visible = !panel1.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox6.Text;
            string password = textBox5.Text;
            if (CheckLogin(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckLogin(string username, string password)
        {
            // Chuỗi kết nối tới SQL Server
            string connectionString = "Data Source=IKIENKINZERO\\SQLEXPRESS;Initial Catalog=manage_tour_1;Persist Security Info=True;User ID=sa;Password=123456";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn kiểm tra đăng nhập
                    string query = "SELECT COUNT(*) FROM HuongDanVien WHERE email = @Username AND pass_word = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int result = (int)cmd.ExecuteScalar();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
