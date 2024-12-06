using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manage_tour.DbQueries;

namespace Manage_tour
{
    public partial class customer : Panel
    {
        private bool isEditMode = false;
        public customer()
        {
            InitializeComponent();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
            loadDataKh();
            dataGridView1.ClearSelection();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ADD_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            txtCustomerID.Enabled = true;
            AdjustDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột là "Sửa"
            if (dataGridView1.Columns["Edit"] != null && e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string KhID = dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();

                // Gọi hàm để xử lý sửa
                EditCustomer(KhID);
            }

            // Kiểm tra nếu cột là "Xoá"
            if (dataGridView1.Columns["Del"] != null && e.ColumnIndex == dataGridView1.Columns["Del"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string ID = dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();

                // Gọi hàm để xử lý xoá
                //DeleteCustomer(ID);
                MessageBox.Show($"{DeleteCustomer(ID)} customer(s) deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
        }

        private int DeleteCustomer(string id)
        {
            int rowAffected = KhachHangModel.delete(id);
            loadDataKh();
            return rowAffected;
        }

        private void EditCustomer(string KhId)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
            isEditMode = true;
            KhachHangModel kh = KhachHangModel.selectByKey(KhId);
            // Điền thông tin vào các trường nhập liệu
            txtCustomerID.Text = kh.ma_kh;
            txtCustomerName.Text = kh.ten_kh;
            txtPhoneNumber.Text = kh.sdt;
            txtCCCD.Text = kh.cccd;
            txtAddress.Text = kh.dia_chi;

            // Vô hiệu hóa trường TourID để không cho phép thay đổi
            txtCustomerID.Enabled = false;
        }

        private void loadDataKh()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView1.Rows.Clear();
            foreach (object[] row in KhachHangModel.selectAll())
            {
                dataGridView1.Rows.Add(row);
            }
        }

        private void ClearInputFields()
        {
            txtCustomerID.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtCCCD.Text = string.Empty;
        }

        private void AdjustDataGridView()
        {
            // Tính toán chiều cao khả dụng cho DataGridView
            int availableHeight = 400; 

            if (tableLayoutPanel1.Visible)
            {
                // Nếu bảng hiển thị, giảm chiều cao DataGridView
                ADD.Visible = false;
                dataGridView1.Height = availableHeight - tableLayoutPanel1.Height + 100; // Giảm thêm để có khoảng trống nút Add
            }
            else
            {
                // Nếu bảng ẩn, tăng chiều cao DataGridView
                ADD.Visible = true;
                dataGridView1.Height = availableHeight;
            }

            // Cập nhật vị trí nút Add dựa trên DataGridView
            ADD.Top = dataGridView1.Bottom + 5; 

            ClearInputFields();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            String ID=txtCustomerID.Text ;
            String CustomerName=txtCustomerName.Text;
            String Address=txtAddress.Text ;
            String PhoneNumber=txtPhoneNumber.Text ;
            String CCCD=txtCCCD.Text;

            if(String.IsNullOrEmpty(ID) || String.IsNullOrEmpty(CustomerName) || String.IsNullOrEmpty(Address) || String.IsNullOrEmpty(PhoneNumber) || String.IsNullOrEmpty(CCCD))
            {
                MessageBox.Show("Please enter all required information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return;
            }

            if (isEditMode)
            {
                UpdateCustomer();
                AdjustDataGridView();
            }
            else
            {
                AddCustomer(ID, CustomerName, PhoneNumber, CCCD, Address);
            }

            isEditMode = false;
            txtCustomerID.Enabled = true;
            ClearInputFields();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
            loadDataKh();
        }
        private void UpdateCustomer()
        {
            KhachHangModel.update(txtCustomerName.Text, txtPhoneNumber.Text, txtCCCD.Text, txtAddress.Text, txtCustomerID.Text);
        }
        private void AddCustomer(String ID, String CustomerName,String PhoneNumber, String CCCD,String Address)
        {
            KhachHangModel.insert(ID, CustomerName, PhoneNumber, CCCD, Address);
        }


        private void Search_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a search keyword!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //SearchCustomer(keyword);
        }


        private void ADD_Click_1(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            txtCustomerID.Enabled = true;
            AdjustDataGridView();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
