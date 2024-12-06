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
using Manage_tour.DbQueries;

namespace Manage_tour
{
    public partial class HDV : Panel
    {
        private bool isEditMode = false;

        public HDV()
        {
            InitializeComponent();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();
            //LoadData();
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

            //Search(keyword);
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

                MessageBox.Show($"{DeleteHDV(GuideID)} Guide(s) deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }

        }

        private void EditHDV(String GuideID)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
            isEditMode = true;
            HuongDanVienModel HDV = HuongDanVienModel.selectByKey(GuideID);

            txtGuideID.Text = HDV.ma_hdv;
            txtFullName.Text = HDV.full_name;
            txtCCCD.Text = HDV.cccd;
            //txtPhoneNumber.Text = HDV.sdt;
            //txtAddress.Text = HDV.diachi;

            txtGuideID.Enabled = false;
        }


        private void AdjustDataGridView()
        {
            // Tính toán chiều cao khả dụng cho DataGridView
            int availableHeight = 400; // 20 là khoảng cách trống phía dưới

            if (tableLayoutPanel1.Visible)
            {
                ADD.Visible = false;
                dataGridViewHDV.Height = availableHeight - tableLayoutPanel1.Height + 100; // Giảm thêm để có khoảng trống nút Add
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

        private void ClearInputFields()
        {
            txtGuideID.Text = String.Empty;
            txtFullName.Text = String.Empty;
            txtCCCD.Text = String.Empty;
            //txtPhoneNumber.Text = String.Empty;
            //txtAddress.Text = String.Empty;
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
            //String PhoneNumber = txtPhoneNumber.Text;
            //String Address = txtAddress.Text;

            if (string.IsNullOrEmpty(GuideID) || string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(CCCD))
            {
                MessageBox.Show("Please enter all required information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }



            // Kiểm tra trạng thái để thực hiện Add hoặc Update
            if (isEditMode)
            {
                //UpdateHDV(); // Cập nhật tour
                AdjustDataGridView();
            }
            else
            {
               // AddHDV(GuideID, FullName, CCCD, PhoneNumber, Address); // Thêm mới tour
            }

            isEditMode = false;
            txtGuideID.Enabled = true;
            ClearInputFields();
            tableLayoutPanel1.Visible = false;
            AdjustDataGridView();

        }

        //private void UpdateHDV()
        //{
        //    HuongDanVienModel.update(txtFullName.Text, txtCCCD.Text, txtPhoneNumber, txtAddress, txtGuideID.Text);
        //}
        //private void AddHDV(String GuideID, String FullName, String CCCD, String PhoneNumber, String Address)
        //{
        //    HuongDanVienModel.insert(GuideID, FullName, CCCD, PhoneNumber, Address);
        //}


        private int DeleteHDV(string id)
        {
            int rowAffected = HuongDanVienModel.delete(id);
            loadData();
            return rowAffected;
        }

        private void loadData()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridViewHDV.Rows.Clear();
            foreach (object[] row in HuongDanVienModel.selectAll())
            {
                dataGridViewHDV.Rows.Add(row);
            }
        }
        private void ADD_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            AdjustDataGridView();
        }
    }
}
