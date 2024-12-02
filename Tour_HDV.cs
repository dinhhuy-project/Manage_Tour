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
    public partial class Tour_HDV : Form
    {
        public string connectionString = "Data Source=DESKTOP-C2UG3F0\\SQLEXPRESS01;Initial Catalog=Tour;Persist Security Info=True;User ID=sa;Password=123";
        private bool isEditMode = false;

        public Tour_HDV()
        {
            InitializeComponent();
            LoadData();
            dataGridView2.ClearSelection();
            // Đăng ký sự kiện CellClick
            dataGridView2.CellClick += dataGridView2_CellClick;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy hàng hiện tại
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                // Lấy mã tour từ cột ma_tour
                string tourId = row.Cells["TourID1"].Value?.ToString();

                if (!string.IsNullOrEmpty(tourId))
                {
                    // Gọi phương thức EditTour để tải dữ liệu chi tiết
                    EditTourHDV(tourId);
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String TourID = txtTourID.Text;
            String GuideID = txtGuideID.Text;



            if (string.IsNullOrEmpty(TourID) || string.IsNullOrEmpty(GuideID))
            {
                MessageBox.Show("Please enter all required information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }


            // Kiểm tra trạng thái để thực hiện Add hoặc Update
            if (isEditMode)
            {
                UpdateTourHDV(); // Cập nhật tour
            }
            else
            {
                AddTourHDV(TourID, GuideID); // Thêm mới tour
            }

            isEditMode = false;
            txtTourID.Enabled = true;
            ClearInputFields();

        }

        private void UpdateTourHDV()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Câu lệnh SQL để cập nhật dữ liệu
                    string query = "UPDATE Tour_HDV " +
                                   "SET ma_hdv = @GuideID " +
                                   "WHERE ma_tour = @TourID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số cho câu lệnh SQL
                        cmd.Parameters.AddWithValue("@TourID", txtTourID.Text.Trim());
                        cmd.Parameters.AddWithValue("@GuideID", txtGuideID.Text.Trim());

                        // Thực thi lệnh cập nhật
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Information updated successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("No found with the provided ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddTourHDV(String TourID, String GuideID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    String Query = "INSERT INTO Tour_HDV (ma_tour, ma_hdv) VALUES (@TourID, @GuideID)";
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TourID", TourID);
                        cmd.Parameters.AddWithValue("@GuideID", GuideID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Tải lại dữ liệu
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not add data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtTourID.Text = String.Empty;
            txtGuideID.Text = String.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a search keyword!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchID(keyword);
        }

        private void SearchID(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Tour_HDV WHERE ma_tour LIKE @Keyword OR ma_hdv LIKE @Keyword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Xóa các dòng hiện tại trong DataGridView
                    dataGridView2.Rows.Clear();

                    // Duyệt qua DataTable và thêm từng dòng vào DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        // Tạo một mảng các giá trị từ dòng
                        object[] rowData = row.ItemArray;

                        // Thêm dòng vào DataGridView
                        dataGridView2.Rows.Add(rowData);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            txtTourID.Enabled = true;
            LoadData();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "DEL1")
            {
                // Lấy thông tin từ hàng được chọn
                string tourId = dataGridView2.Rows[e.RowIndex].Cells["TourID1"].Value.ToString();

                // Xác nhận xoá
                var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Gọi hàm xoá
                    DeleteTourHDV(tourId);
                }
            }
        }

        private void EditTourHDV(string tourId)
        {
            isEditMode = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn thông tin của tour theo `tourId`
                    string query = "SELECT * FROM Tour_HDV WHERE ma_tour = @TourID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TourID", tourId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Điền thông tin vào các trường nhập liệu
                                txtTourID.Text = reader["ma_tour"].ToString();
                                txtGuideID.Text = reader["ma_hdv"].ToString();

                                // Vô hiệu hóa trường TourID để không cho phép thay đổi
                                txtTourID.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("No data found for the selected Tour ID.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DeleteTourHDV(string tourId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Tour_HDV WHERE ma_tour = @TourID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TourID", tourId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tour deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void LoadData()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView2.Rows.Clear();

            // Kết nối tới cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Câu lệnh SQL để lấy dữ liệu
                    string query = "SELECT * FROM Tour_HDV"; 

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
                        dataGridView2.Rows.Add(rowData);
                    }

                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (nếu có)
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }


            }

        }
    }
}
