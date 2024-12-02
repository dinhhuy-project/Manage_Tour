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
    public partial class HDV : Form
    {
        public string connectionString = "Data Source=DESKTOP-C2UG3F0\\SQLEXPRESS01;Initial Catalog=Tour;Persist Security Info=True;User ID=sa;Password=123";
        private bool isEditMode = false;

        public HDV()
        {
            InitializeComponent();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
            LoadData();
            dataGridViewHDV.ClearSelection();
            dataGridViewHDV.CellContentClick += dataGridViewHDV_CellContentClick;
        }

        

        private void SearchHDV_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a search keyword!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Search(keyword);
        }

        private void Search(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ma_hdv, full_name, cccd FROM HuongDanVien WHERE ma_hdv LIKE @Keyword OR full_name LIKE @Keyword OR cccd LIKE @Keyword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Xóa các dòng hiện tại trong DataGridView
                    dataGridViewHDV.Rows.Clear();

                    // Duyệt qua DataTable và thêm từng dòng vào DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        // Tạo một mảng các giá trị từ dòng
                        object[] rowData = row.ItemArray;

                        // Thêm dòng vào DataGridView
                        dataGridViewHDV.Rows.Add(rowData);
                    }
                }
            }
        }

        private void dataGridViewHDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột là "Sửa"
            if (dataGridViewHDV.Columns["Edit"] != null && e.ColumnIndex == dataGridViewHDV.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string GuideID = dataGridViewHDV.Rows[e.RowIndex].Cells["GuideID"].Value.ToString();

                // Gọi hàm để xử lý sửa

                EditHDV(GuideID);
            }

            // Kiểm tra nếu cột là "Xoá"
            if (dataGridViewHDV.Columns["Del"] != null && e.ColumnIndex == dataGridViewHDV.Columns["Del"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string GuideID = dataGridViewHDV.Rows[e.RowIndex].Cells["GuideID"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this attraction?",
                         "Delete Confirmation",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Warning);


                if (result == DialogResult.Yes)
                {
                    DeleteHDV(GuideID);
                }


            }

        }

        private void DeleteHDV(String GuideID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM HuongDanVien WHERE ma_hdv = @GuideID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GuideID", GuideID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Tải lại dữ liệu
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not delete tour.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditHDV(String GuideID)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
            isEditMode = true;

            try
            {
                DataGridViewRow selectedRow = dataGridViewHDV.Rows.Cast<DataGridViewRow>().FirstOrDefault(row => row.Cells["GuideID"].Value.ToString() == GuideID);
                if (selectedRow != null)
                {
                    txtGuideID.Text = selectedRow.Cells["GuideID"].Value.ToString();
                    txtFullName.Text = selectedRow.Cells["FullName"].Value.ToString();
                    txtCCCD.Text = selectedRow.Cells["CCCD"].Value.ToString();


                    txtGuideID.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AdjustDataGridView()
        {
            // Tính toán chiều cao khả dụng cho DataGridView
            int availableHeight = this.ClientSize.Height - 100; // 20 là khoảng cách trống phía dưới

            if (tableLayoutPanel1.Visible)
            {
                // Nếu bảng hiển thị, giảm chiều cao DataGridView
                ADD.Visible = false;
                dataGridViewHDV.Height = availableHeight - tableLayoutPanel1.Height + 30; // Giảm thêm để có khoảng trống nút Add
            }
            else
            {
                // Nếu bảng ẩn, tăng chiều cao DataGridView
                ADD.Visible = true;
                dataGridViewHDV.Height = availableHeight;
            }

            // Cập nhật vị trí nút Add dựa trên DataGridView
            ADD.Top = dataGridViewHDV.Bottom + 5; // Cách DataGridView 10px

            ClearInputFields();
        }

        private void LoadData()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridViewHDV.Rows.Clear();

            // Kết nối tới cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Câu lệnh SQL để lấy dữ liệu
                    string query = "SELECT ma_hdv, full_name, cccd FROM HuongDanVien"; // Thay đổi câu lệnh SQL nếu cần

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
                        dataGridViewHDV.Rows.Add(rowData);
                    }

                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (nếu có)
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }


            }

        }

        private void ClearInputFields()
        {
            txtGuideID.Text = String.Empty;
            txtFullName.Text = String.Empty;
            txtCCCD.Text = String.Empty;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            String GuideID = txtGuideID.Text;
            String FullName = txtFullName.Text;
            String CCCD = txtCCCD.Text;


            if (string.IsNullOrEmpty(GuideID) || string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(CCCD))
            {
                MessageBox.Show("Please enter all required information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }



            // Kiểm tra trạng thái để thực hiện Add hoặc Update
            if (isEditMode)
            {
                UpdateHDV(); // Cập nhật tour
                AdjustDataGridView();
            }
            else
            {
                AddHDV(GuideID, FullName, CCCD); // Thêm mới tour
            }

            isEditMode = false;
            txtGuideID.Enabled = true;
            ClearInputFields();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void UpdateHDV()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn cập nhật thông tin tour
                    string query = "UPDATE HuongDanVien SET full_name = @FullName, cccd = @CCCD WHERE ma_hdv = @GuideID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                        cmd.Parameters.AddWithValue("@GuideID", txtGuideID.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tour updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Tải lại dữ liệu sau khi cập nhật
                            tableLayoutPanel1.Visible = false; // Ẩn bảng chỉnh sửa
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddHDV(String GuideID, String FullName, String CCCD)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    String Query = "INSERT INTO HuongDanVien(ma_hdv, full_name, cccd) VALUES (@GuideID, @FullName ,@CCCD)";
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GuideID", GuideID);
                        cmd.Parameters.AddWithValue("@FullName", FullName);
                        cmd.Parameters.AddWithValue("@CCCD", CCCD);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridViewHDV.Rows.Add(GuideID, FullName, CCCD);
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not add HDV.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
        }
    }
}
