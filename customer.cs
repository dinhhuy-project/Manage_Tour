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
    public partial class customer : Form
    {
        public string connectionString = "Data Source=DESKTOP-C2UG3F0\\SQLEXPRESS01;Initial Catalog=Tour;Persist Security Info=True;User ID=sa;Password=123";
        private bool isEditMode = false;
        public customer()
        {
            InitializeComponent();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
            LoadData();
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
                EditCustomer(ID);
            }

            // Kiểm tra nếu cột là "Xoá"
            if (dataGridView1.Columns["Del"] != null && e.ColumnIndex == dataGridView1.Columns["Del"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string ID = dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();

                // Gọi hàm để xử lý xoá
                DeleteCustomer(ID);
            }

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
        }

        private void EditCustomer(String ID)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
            isEditMode = true;

            try
            {
                DataGridViewRow selectedRow = dataGridView1.Rows.Cast<DataGridViewRow>().FirstOrDefault(row => row.Cells["CustomerID"].Value.ToString() == ID);
                if (selectedRow != null)
                {
                    txtCustomerID.Text = selectedRow.Cells["CustomerID"].Value.ToString();
                    txtCustomerName.Text = selectedRow.Cells["CustomerName"].Value.ToString();
                    txtPhoneNumber.Text = selectedRow.Cells["PhoneNumber"].Value.ToString();
                    txtCCCD.Text = selectedRow.Cells["CCCD"].Value.ToString();
                    txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();

                    txtCustomerID.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteCustomer(String ID)
        {
            try
            {
                using (SqlConnection conn=new SqlConnection(connectionString))
                {
                    conn.Open();
                    String query = "DELETE FROM KhachHang WHERE ma_kh=@MaKh";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKh", ID);
                        int rowAffected = cmd.ExecuteNonQuery();
                        if(rowAffected > 0)
                        {
                            MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not delete customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCustomer()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn cập nhật thông tin tour
                    string query = "UPDATE Tour SET ten_kh = @NameCustomer, sdt = @PhoneNumber, cccd = @CCCD, dia_chi=@Address WHERE ma_kh = @ID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NameCustomer", txtCustomerName.Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                        cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress);
                        cmd.Parameters.AddWithValue("@ID", txtCustomerID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Tải lại dữ liệu sau khi cập nhật
                            tableLayoutPanel1.Visible = false; // Ẩn bảng chỉnh sửa
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not update customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            int availableHeight = this.ClientSize.Height - 100; 

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
        }

        private void AddCustomer(String ID, String CustomerName, String PhoneNumber, String CCCD,String Address)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    String Query = "INSERT INTO KhachHang VALUES (@ID, @CustomerName ,@PhoneNumber, @CCCD, @Address)";
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        cmd.Parameters.AddWithValue("@CCCD", CCCD);
                        cmd.Parameters.AddWithValue("@Address", Address);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.Rows.Add(ID, CustomerName, PhoneNumber, CCCD, Address);
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not add customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView1.Rows.Clear();

            // Kết nối tới cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Câu lệnh SQL để lấy dữ liệu
                    string query = "SELECT * FROM KhachHang"; // Thay đổi câu lệnh SQL nếu cần

                    // Tạo SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);

                    // Duyệt qua DataTable và thêm từng dòng vào DataGridView
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Tạo một mảng các giá trị từ dòng
                        object[] rowData = row.ItemArray;

                        // Thêm dòng vào DataGridView
                        dataGridView1.Rows.Add(rowData);
                    }

                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (nếu có)
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }


            }

        }

        private void SearchCustomer(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM KhachHang WHERE ma_kh LIKE @Keyword OR ten_kh LIKE @Keyword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Xóa các dòng hiện tại trong DataGridView
                    dataGridView1.Rows.Clear();

                    // Duyệt qua DataTable và thêm từng dòng vào DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        // Tạo một mảng các giá trị từ dòng
                        object[] rowData = row.ItemArray;

                        // Thêm dòng vào DataGridView
                        dataGridView1.Rows.Add(rowData);
                    }
                }
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a search keyword!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchCustomer(keyword);
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
