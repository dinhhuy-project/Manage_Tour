﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manage_tour.DbQueries;

namespace Manage_tour
{
    public partial class Tour_HDV : Panel
    {
        private bool isEditMode = false;

        public Tour_HDV()
        {
            InitializeComponent();
            loadDataTourHDV();
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
                string hdvId = row.Cells["GuideID1"].Value?.ToString();

                if (!string.IsNullOrEmpty(tourId))
                {
                    isEditMode=true;
                    EditTourHDV(tourId,hdvId);
                }
            }
        }

        private void EditTourHDV(String tourId, String hdvId)
        {
            TourHDVModel.update(tourId,hdvId);
            txtTourID.Enabled = false;
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
            loadDataTourHDV();
        }

        private void UpdateTourHDV()
        {
            TourHDVModel.update(txtGuideID.Text, txtTourID.Text);
        }
        private void AddTourHDV(String TourID, String GuideID)
        {
            TourHDVModel.insert(TourID, GuideID);
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

            //SearchID(keyword);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            txtTourID.Enabled = true;
            isEditMode = false;
            loadDataTourHDV();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex].Name == "DEL1")
            {
                // Lấy thông tin từ hàng được chọn
                string tourId = dataGridView2.Rows[e.RowIndex].Cells["TourID1"].Value.ToString();
                string GuideId = dataGridView2.Rows[e.RowIndex].Cells["GuideID1"].Value.ToString();
                // Xác nhận xoá
                var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    MessageBox.Show($"{DeleteTourHDV(tourId, GuideId)} tourDTQ(s) deleted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private int DeleteTourHDV(string tourId, string GuideId)
        {
            int rowAffected = TourHDVModel.delete(tourId);
            loadDataTourHDV();
            return rowAffected;
        }

        private void loadDataTourHDV()
        {
            // Xóa tất cả các dòng hiện tại trong DataGridView (nếu có)
            dataGridView2.Rows.Clear();
            foreach (object[] row in TourHDVModel.selectAll())
            {
                dataGridView2.Rows.Add(row);
            }
        }
    }
}
