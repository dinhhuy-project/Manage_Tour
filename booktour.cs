using Manage_tour.DbQueries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_tour
{
    public partial class booktour : Panel
    {
        public booktour()
        {
            InitializeComponent();
            loadData();
            SetCurrentDateForLabel();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void booktour_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            payment payment = new payment();
            payment.ShowDialog();
        }

        private void loadData()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView1.Rows.Clear();
            foreach (object[] row in TourModel.selectAll())
            {
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.AllowUserToAddRows = false;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0]; // Đặt ô hiện tại
                totalPrice(); // Tính toán tổng tiền cho dòng đầu tiên
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (dataGridView1.CurrentRow != null)
                {
                    try
                    {
                        totalPrice();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xử lý dòng được chọn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        public void totalPrice()
        {
            double totalPrice = 0;
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                try
                {
                    // Lấy giá từ cột giá (đảm bảo chỉ số cột là chính xác)
                    double price = Convert.ToDouble(selectedRow.Cells[2].Value);
                    int quantity = (int)numericUpDown1.Value;

                    // Tính tổng tiền
                    totalPrice = price * quantity;

                    // Gán tổng tiền vào label13, định dạng thành tiền tệ
                    label13.Text = totalPrice.ToString(); // Hiển thị dưới dạng tiền tệ
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi tính toán tổng tiền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                label13.Text = "0"; // Nếu không có dòng nào được chọn
            }
        }
        private void ClearInputFields()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            label13.Text = string.Empty;
            numericUpDown1.Value = 0;
        }
        private void SetCurrentDateForLabel()
        {
            // Lấy ngày hiện tại
            DateTime today = DateTime.Now;

            // Định dạng ngày theo kiểu "dd-MM-yyyy"
            string formattedDate = today.ToString("dd-MM-yyyy");

            // Thiết lập giá trị cho label10
            label10.Text = formattedDate;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            totalPrice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
            ClearInputFields();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                string makh = textBox1.Text.Trim(); 
                if (!string.IsNullOrEmpty(makh)) 
                {
                    loadCustomer(makh); 
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.SuppressKeyPress = true; 
            }
        }

        
        private void loadCustomer(string makh)
        {
            
            KhachHangModel kh = KhachHangModel.selectByKey(makh);

            if (kh != null)
            {
                
                textBox1.Text = kh.ma_kh;  
                textBox2.Text = kh.ten_kh; 
                textBox3.Text = kh.sdt;    
                textBox4.Text = kh.cccd;   
                textBox5.Text = kh.dia_chi; 
            }
            else
            {
                
                MessageBox.Show("Không tìm thấy mã khách hàng " + makh, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
