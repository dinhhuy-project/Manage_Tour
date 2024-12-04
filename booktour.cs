using Manage_tour.DbQueries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
            //this.Hide();
            //payment payment = new payment();
            //payment.ShowDialog();
            // Lấy thông tin từ các trường nhập
            string maKh = textBox1.Text.Trim();
            string tenKh = textBox2.Text.Trim();
            string diaChi = textBox4.Text.Trim();
            string cccd = textBox5.Text.Trim();
            string sdt = textBox3.Text.Trim();
            int soLuong = (int)numericUpDown1.Value;


            // Kiểm tra thông tin đầu vào
            if (string.IsNullOrEmpty(maKh) || string.IsNullOrEmpty(tenKh) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(cccd) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.");
                return;
            }

            // Kiểm tra nếu số lượng người chưa được nhập
            if (soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng người.");
                return;
            }

            DateTime ngayDat;
            if (!DateTime.TryParseExact(label10.Text.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayDat))
            {
                MessageBox.Show("Ngày đặt không hợp lệ. Vui lòng nhập lại.");
                return;
            }

            // Lấy hàng đã chọn trong DataGridView
            int selectedRow = dataGridView1.SelectedCells.Count > 0 ? dataGridView1.SelectedCells[0].RowIndex : -1;
            if (selectedRow == -1)
            {
                MessageBox.Show("Vui lòng chọn tour từ bảng.");
                return;
            }

            // Lấy giá và tên tour từ DataGridView
            double gia;
            if (!double.TryParse(dataGridView1.Rows[selectedRow].Cells[2].Value.ToString(), out gia))
            {
                MessageBox.Show("Giá tour không hợp lệ.");
                return;
            }

            string tenTour = dataGridView1.Rows[selectedRow].Cells[1].Value.ToString();
            double total = gia * soLuong;

            // Tạo mã đặt tour mới
            string maDatTour = null;
            try
            {
                maDatTour = DatTourModel.GenerateMaDatTour();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo mã đặt tour: " + ex.Message);
                return;
            }

            // Tạo đối tượng DatTourModel mới và thiết lập các giá trị
            DatTourModel newBooking = new DatTourModel(maDatTour,
                                                        dataGridView1.Rows[selectedRow].Cells[0].Value.ToString(), // MaTour
                                                        maKh,
                                                        ngayDat,
                                                        soLuong,
                                                            Convert.ToDecimal(total), // TongTien
                                                        "Chưa Thanh Toán"); // TrangThai

            // Gọi phương thức lưu vào cơ sở dữ liệu
            try
            {
                int result = DatTourModel.insert(newBooking);
                if (result > 0)
                {
                    MessageBox.Show("Đặt tour thành công!");
                    payment paymentForm = new payment(maDatTour, tenKh, diaChi, cccd, tenTour, soLuong, gia, total, ngayDat);
                    paymentForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đặt tour thất bại. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi kết nối với cơ sở dữ liệu: " + ex.Message);
            }

            this.Hide(); // Đóng cửa sổ hiện tại
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
                    // Lấy giá từ cột giá 
                    double price = Convert.ToDouble(selectedRow.Cells[2].Value);
                    int quantity = (int)numericUpDown1.Value;

                    // Tính tổng tiền
                    totalPrice = price * quantity;

                    // Gán tổng tiền vào label13
                    label13.Text = totalPrice.ToString("C"); 
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
                string makh = textBox1.Text.Trim(); // Lấy mã khách hàng từ textBox1
                if (!string.IsNullOrEmpty(makh)) // Kiểm tra mã khách hàng không rỗng
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
            // Gọi phương thức tìm khách hàng theo mã
            KhachHangModel kh = KhachHangModel.selectByKey(makh);

            if (kh != null)
            {
                // Điền dữ liệu vào các textbox tương ứng
                textBox1.Text = kh.ma_kh;
                textBox2.Text = kh.ten_kh;
                textBox3.Text = kh.sdt;
                textBox5.Text = kh.cccd;
                textBox4.Text = kh.dia_chi;
            }
            else
            {
                // Hiển thị thông báo lỗi nếu không tìm thấy
                MessageBox.Show("Không tìm thấy mã khách hàng: " + makh, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void clearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
