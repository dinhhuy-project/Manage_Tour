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
            //LoadData();
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
                string ID = dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();

                // Gọi hàm để xử lý sửa
                //EditCustomer(ID);
            }

            // Kiểm tra nếu cột là "Xoá"
            if (dataGridView1.Columns["Del"] != null && e.ColumnIndex == dataGridView1.Columns["Del"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string ID = dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();

                // Gọi hàm để xử lý xoá
                //DeleteCustomer(ID);
            }

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
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
            ADD.Top = dataGridView1.Bottom + 5; // Cách DataGridView 10px

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
                //UpdateCustomer();
                AdjustDataGridView();
            }
            else
            {
                //AddCustomer(ID, CustomerName, PhoneNumber, CCCD, Address);
            }

            isEditMode = false;
            txtCustomerID.Enabled = true;
            ClearInputFields();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
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
