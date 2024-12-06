using Manage_tour.DbQueries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Manage_tour
{
    public partial class payment : Form
    {
        public payment(String maDatTour, String tenKhach, String diaChi, String cccd,
            String tenTour, int soLuong, double gia, double total, DateTime ngayDat)
        {
            InitializeComponent();
            panel_chuyenkhoan.Visible = false;
            panel_viettinbank.Visible = false;
            panel_bidv.Visible = false;

            label_matt.Text = ThanhToanModel.GenerateMaThanhToan();
            label_madt.Text = maDatTour;
            label_tentour.Text = tenTour;
            label_soluong.Text = soLuong.ToString();
            label_gia.Text = gia.ToString("C");
            label_tenkhach.Text = tenKhach;
            label_cccd.Text = cccd;
            label_diachi.Text = diaChi;
            label_ngaydat.Text = ngayDat.ToString("dd/MM/yyyy");
            label_tongtien.Text = total.ToString();
            //label_nvphutrach.Text  sửa sau
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void payment_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu checkbox "chuyển khoản" được chọn
            if (checkBox_chuyenkhoan.Checked)
            {
                checkBox_tienmat.Checked = false; // Bỏ chọn checkbox "tiền mặt"
                panel_chuyenkhoan.Visible = true; // Hiển thị panel chuyển khoản
            }
            else
            {
                panel_chuyenkhoan.Visible = false; // Ẩn panel chuyển khoản
                panel_bidv.Visible=false;
                panel_viettinbank.Visible=false;
            }
        }

        private void checkBox_tienmat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_tienmat.Checked)
            {
                checkBox_chuyenkhoan.Checked = false;
            }
        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panel_viettinbank_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox_viettinbank_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_viettinbank.Checked) 
            {
                checkBox_bidv.Checked = false; 
                panel_viettinbank.Visible = true; 
                panel_bidv.Visible = false; 
            }
            else 
            {
                panel_viettinbank.Visible = false; 
            }
        }

        private void checkBox_bidv_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_bidv.Checked)
            {
                checkBox_viettinbank.Checked = false;
                panel_bidv.Visible = true;
                panel_viettinbank.Visible = false;
            }
            else
            {
                panel_bidv.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Tạo mã thanh toán
            string maThanhToan = null;
            try
            {
                maThanhToan = ThanhToanModel.GenerateMaThanhToan(); // Tạo mã thanh toán
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi khi tạo mã thanh toán: " + ex.Message);
                return; // Dừng lại nếu có lỗi
            }

            // Xác định phương thức thanh toán
            string hinhThuc;
            if (checkBox_chuyenkhoan.Checked)
            {
                hinhThuc = "Chuyển khoản";
            }
            else if (checkBox_tienmat.Checked)
            {
                hinhThuc = "Tiền mặt";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán.");
                return; // Dừng lại nếu không có phương thức thanh toán nào được chọn
            }

            // Thông tin thanh toán
            DateTime ngayThanhToan = DateTime.Now.Date; 

            double tongTien;
            if (!double.TryParse(label_tongtien.Text.Trim(), out tongTien)) // Lấy tổng tiền từ label
            {
                MessageBox.Show("Tổng tiền không hợp lệ.");
                return; // Dừng lại nếu tổng tiền không hợp lệ
            }

            string madatTour = label_madt.Text.Trim(); // Mã đặt tour từ label

            // Tạo đối tượng thanh toán
            ThanhToanModel newPayment = new ThanhToanModel(maThanhToan, madatTour, ngayThanhToan, hinhThuc, (decimal)tongTien);

            // Lưu thông tin thanh toán vào cơ sở dữ liệu
            try
            {
                if (ThanhToanModel.insert(newPayment) > 0) // Gọi phương thức insert để lưu thông tin
                {
                    DatTourModel.UpdateTourStatus(madatTour,"Đã Thanh Toán");
                    MessageBox.Show("Thanh toán thành công!");
                    this.Dispose(); // Đóng form thanh toán
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thanh toán: " + ex.Message);
            }
        }
    }
}
