using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_tour
{
    public partial class DTQ : Form
    {
        public string connectionString = "Data Source=DESKTOP-C2UG3F0\\SQLEXPRESS01;Initial Catalog=Tour;Persist Security Info=True;User ID=sa;Password=123";
        private bool isEditMode = false;

        public DTQ()
        {
            InitializeComponent();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
            LoadData();
            dataGridViewDTQ.ClearSelection();
        }

        private void Search_Click(object sender, EventArgs e)
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
                string query = "SELECT * FROM DiemThamQuan WHERE ma_diem_tham_quan LIKE @Keyword OR ten_dia_diem LIKE @Keyword OR dia_chi LIKE @Keyword" ;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Xóa các dòng hiện tại trong DataGridView
                    dataGridViewDTQ.Rows.Clear();

                    // Duyệt qua DataTable và thêm từng dòng vào DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        // Tạo một mảng các giá trị từ dòng
                        object[] rowData = row.ItemArray;

                        // Thêm dòng vào DataGridView
                        dataGridViewDTQ.Rows.Add(rowData);
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột là "Sửa"
            if (dataGridViewDTQ.Columns["Edit"] != null && e.ColumnIndex == dataGridViewDTQ.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string DTQID = dataGridViewDTQ.Rows[e.RowIndex].Cells["DTQID"].Value.ToString();

                // Gọi hàm để xử lý sửa

                EditDTQ(DTQID);
            }

            // Kiểm tra nếu cột là "Xoá"
            if (dataGridViewDTQ.Columns["Del"] != null && e.ColumnIndex == dataGridViewDTQ.Columns["Del"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin dòng hiện tại
                string DTQID = dataGridViewDTQ.Rows[e.RowIndex].Cells["DTQID"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this attraction?",
                         "Delete Confirmation",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Warning);


                if (result == DialogResult.Yes)
                {
                    DeleteDTQ(DTQID);
                }
                
                
            }

            if (e.RowIndex < 0) return;

        }

        private void DeleteDTQ(String DTQID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM DiemThamQuan WHERE ma_diem_tham_quan = @DTQID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DTQID", DTQID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("DTQ deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void EditDTQ(String DTQID)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
            isEditMode = true;

            try
            {
                DataGridViewRow selectedRow = dataGridViewDTQ.Rows.Cast<DataGridViewRow>().FirstOrDefault(row => row.Cells["DTQID"].Value.ToString() == DTQID);
                if (selectedRow != null)
                {
                    txtDTQID.Text = selectedRow.Cells["DTQID"].Value.ToString();
                    txtDTQName.Text = selectedRow.Cells["DTQName"].Value.ToString();
                    txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                    

                    txtDTQID.Enabled = false;
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
                dataGridViewDTQ.Height = availableHeight - tableLayoutPanel1.Height +30; // Giảm thêm để có khoảng trống nút Add
            }
            else
            {
                // Nếu bảng ẩn, tăng chiều cao DataGridView
                ADD.Visible = true;
                dataGridViewDTQ.Height = availableHeight;
            }

            // Cập nhật vị trí nút Add dựa trên DataGridView
            ADD.Top = dataGridViewDTQ.Bottom + 5; // Cách DataGridView 10px

            ClearInputFields();
        }

        private void LoadData()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridViewDTQ.Rows.Clear();

            // Kết nối tới cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Câu lệnh SQL để lấy dữ liệu
                    string query = "SELECT * FROM DiemThamQuan"; // Thay đổi câu lệnh SQL nếu cần

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
                        dataGridViewDTQ.Rows.Add(rowData);
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
            txtDTQID.Text = String.Empty;
            txtDTQName.Text = String.Empty;
            txtAddress.Text = String.Empty;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            String DTQID = txtDTQID.Text;
            String DTQName = txtDTQName.Text;
            String Address = txtAddress.Text;

            
            if (string.IsNullOrEmpty(DTQID) || string.IsNullOrEmpty(DTQName) || string.IsNullOrEmpty(Address))
            {
                MessageBox.Show("Please enter all required information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }



            // Kiểm tra trạng thái để thực hiện Add hoặc Update
            if (isEditMode)
            {
                UpdateDTQ(); // Cập nhật tour
                AdjustDataGridView();
            }
            else
            {
                AddDTQ(DTQID, DTQName, Address); // Thêm mới tour
            }

            isEditMode = false;
            txtDTQID.Enabled = true;
            ClearInputFields();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
        }

        private void UpdateDTQ()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Truy vấn cập nhật thông tin tour
                    string query = "UPDATE DiemThamQuan SET ten_dia_diem = @DTQName, dia_chi = @DiaChi WHERE ma_diem_tham_quan = @DTQID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DTQName", txtDTQName.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@DTQID", txtDTQID.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tour updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Tải lại dữ liệu sau khi cập nhật
                            tableLayoutPanel1.Visible = false; // Ẩn bảng chỉnh sửa
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not update DTQ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDTQ(String DTQID, String DTQName, String Address)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    String Query = "INSERT INTO DiemThamQuan VALUES (@DTQID, @DTQName ,@Address)";
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DTQID", DTQID);
                        cmd.Parameters.AddWithValue("@DTQName", DTQName);
                        cmd.Parameters.AddWithValue("@Address", Address);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("DTQ added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridViewDTQ.Rows.Add(DTQID, DTQName, Address);
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Error: Could not add DTQ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
