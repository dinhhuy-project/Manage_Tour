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
    public partial class Tour : Form
    {
        public Tour()
        {
            InitializeComponent();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
            LoadData();
            dataGridView1.ClearSelection();
        }

        public string connectionString = "Data Source=DESKTOP-C2UG3F0\\SQLEXPRESS01;Initial Catalog=Tour;Persist Security Info=True;User ID=sa;Password=123";
        private bool isEditMode = false;


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            // Kiểm tra nếu cột là "Sửa"
            if (dataGridView1.Columns["Edit"] != null && e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string tourId = dataGridView1.Rows[e.RowIndex].Cells["TourID"].Value.ToString();

                // Gọi hàm để xử lý sửa
                EditTour(tourId);
            }

            // Kiểm tra nếu cột là "Xoá"
            if (dataGridView1.Columns["Del"] != null && e.ColumnIndex == dataGridView1.Columns["Del"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string tourId = dataGridView1.Rows[e.RowIndex].Cells["TourID"].Value.ToString();

                // Gọi hàm để xử lý xoá
                DeleteTour(tourId);
            }

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;

        }

        private void DeleteTour(string tourId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Tour WHERE ma_tour = @TourID";
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

        private void EditTour(string tourId)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
            isEditMode = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn thông tin của tour theo `tourId`
                    string query = "SELECT * FROM Tour WHERE ma_tour = @TourID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TourID", tourId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Điền thông tin vào các trường nhập liệu
                                txtTourID.Text = reader["ma_tour"].ToString();
                                txtTourName.Text = reader["ten_tour"].ToString();
                                txtPrice.Text = reader["gia"].ToString();
                                startDate.Value = Convert.ToDateTime(reader["ngay_bd"]);
                                endDate.Value = Convert.ToDateTime(reader["ngay_kt"]);

                                // Vô hiệu hóa trường TourID để không cho phép thay đổi
                                txtTourID.Enabled = false;
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

        private void UpdateTour()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn cập nhật thông tin tour
                    string query = "UPDATE Tour SET ten_tour = @TourName, gia = @Price, ngay_bd = @StartDate, ngay_kt = @EndDate WHERE ma_tour = @TourID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TourID", txtTourID.Text);
                        cmd.Parameters.AddWithValue("@TourName", txtTourName.Text);
                        cmd.Parameters.AddWithValue("@Price", float.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", endDate.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tour updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Tải lại dữ liệu sau khi cập nhật
                            tableLayoutPanel1.Visible = false; // Ẩn bảng chỉnh sửa
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not update tour.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchTours(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Tour WHERE ma_tour LIKE @Keyword OR ten_tour LIKE @Keyword";
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

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void AdjustDataGridView()
        {
            // Tính toán chiều cao khả dụng cho DataGridView
            int availableHeight = this.ClientSize.Height - 100; // 20 là khoảng cách trống phía dưới

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
            ADD.Top = dataGridView1.Bottom + 10; // Cách DataGridView 10px

            ClearInputFields();
        }   

        private void ClearInputFields()
        {
            txtTourID.Text = string.Empty;
            txtTourName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            startDate.Value = DateTime.Now;
            endDate.Value = DateTime.Now;
        }
        private void Save_Click(object sender, EventArgs e)
        {
            String TourID = txtTourID.Text;
            String TourName = txtTourName.Text;
            DateTime startDateT = startDate.Value;
            DateTime endDateT = endDate.Value;
            float PriceT;

            // Kiểm tra nếu các trường tourID và tourName bị rỗng
            if (string.IsNullOrEmpty(TourID) || string.IsNullOrEmpty(TourName))
            {
                    MessageBox.Show("Please enter all required information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }


            // Kiểm tra nếu ngày bắt đầu lớn hơn ngày kết thúc
            if (startDateT > endDateT)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.");
                return;
            }

            // Kiểm tra giá trị Price hợp lệ
            try
            {
                PriceT = float.Parse(txtPrice.Text);

                if (PriceT <= 0)
                {
                    MessageBox.Show("The tour price must be a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid tour price!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            // Kiểm tra trạng thái để thực hiện Add hoặc Update
            if (isEditMode)
            {
                UpdateTour(); // Cập nhật tour
                AdjustDataGridView();
            }
            else
            {
                AddTour(TourID, TourName, startDateT, endDateT, PriceT); // Thêm mới tour
            }

            isEditMode = false;
            txtTourID.Enabled = true;
            ClearInputFields();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void AddTour(String TourID, String TourName, DateTime startDateT, DateTime endDateT, float PriceT)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    String Query = "INSERT INTO Tour VALUES (@TourID, @TourName ,@Price, @StartDate, @EndDate)";
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TourID", TourID);
                        cmd.Parameters.AddWithValue("@TourName", TourName);
                        cmd.Parameters.AddWithValue("@StartDate", startDateT);
                        cmd.Parameters.AddWithValue("@EndDate", endDateT);
                        cmd.Parameters.AddWithValue("@Price", PriceT);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tour added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView1.Rows.Add(TourID, TourName, PriceT, startDateT.ToShortDateString(), endDateT.ToShortDateString());
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not add tour.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = "SELECT * FROM Tour"; // Thay đổi câu lệnh SQL nếu cần

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

        private void Search_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a search keyword!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchTours(keyword);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
