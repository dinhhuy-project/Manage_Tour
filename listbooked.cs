using Manage_tour.DbQueries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_tour
{
    public partial class listbooked : Panel
    {
        public listbooked()
        {
            InitializeComponent();
            loadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Lấy dòng hiện tại được chọn (dòng đang được chọn)
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;

                // Kiểm tra nếu dòng được chọn hợp lệ
                if (selectedRow != null)
                {
                    // Lấy giá trị cột trạng thái thanh toán từ dòng hiện tại
                    string trangThai = selectedRow.Cells[6].Value.ToString(); 

                    // Kiểm tra nếu trạng thái là "Chưa Thanh Toán"
                    if (trangThai == "Chưa Thanh Toán")
                    {
                        // Hiển thị form thanh toán
                        ShowPayment(selectedRow);
                    }
                    else
                    {
                        // Nếu đã thanh toán thì không làm gì
                        MessageBox.Show("Đã thanh toán, không cần thanh toán lại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng hợp lệ.");
            }
        }
        private void ShowPayment(DataGridViewRow selectedRow)
        {
            try
            {
                // Lấy thông tin cần thiết từ dòng được chọn
                string maTour = selectedRow.Cells[1].Value?.ToString();
                string maDatTour = selectedRow.Cells[0].Value?.ToString();
                double total = Convert.ToDouble(selectedRow.Cells[5].Value);
                string maKh = selectedRow.Cells[2].Value?.ToString();
                DateTime ngayDat = Convert.ToDateTime(selectedRow.Cells[3].Value).Date;
                int soLuong = Convert.ToInt32(selectedRow.Cells[4].Value);

                if (string.IsNullOrEmpty(maTour))
                {
                    MessageBox.Show("Mã tour không hợp lệ.");
                    return;
                }

                TourModel tourgia = TourModel.selectByKey(maTour);
                if (tourgia == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin tour.");
                    return;
                }

                double gia = Convert.ToDouble(tourgia.gia);
                string tenTour = tourgia.ten_tour;

                KhachHangModel thongtinkh = KhachHangModel.selectByKey(maKh);
                if (thongtinkh == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng.");
                    return;
                }

                string tenkhach = thongtinkh.ten_kh;
                string cccd = thongtinkh.cccd;
                string diachi = thongtinkh.dia_chi;

                // Tạo và hiển thị form thanh toán mới
                payment paymentForm = new payment(maDatTour, tenkhach, diachi, cccd, tenTour, soLuong, gia, total, ngayDat);
                paymentForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        private void loadData()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView1.Rows.Clear();
            foreach (object[] row in DatTourModel.selectAll())
            {
                dataGridView1.Rows.Add(row);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Tìm kiếm theo mã đặt tour, mã tour hoặc mã khách hàng
                LoadData_search(searchTerm);
            }
            else
            {
                // Nếu không có từ khóa tìm kiếm, tải lại tất cả dữ liệu
                loadData();
            }
        }
        private void LoadData_search(string searchTerm)
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView1.Rows.Clear();

            // Lấy dữ liệu từ cơ sở dữ liệu theo từ khóa tìm kiếm
            foreach (object[] row in DatTourModel.SelectBySearchTerm(searchTerm))
            {
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
