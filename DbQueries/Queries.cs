﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;

namespace Manage_tour.DbQueries
{
    internal class Queries
    {
        private static SqlConnection _connection = DbConnection.getInstance().GetSqlConnection();
        public static NhanVien logIn(String email, String password)
        {
            NhanVien nhanVien = null;
            try
            {
                _connection.Open();
                // Truy vấn kiểm tra đăng nhập
                string query = "SELECT * FROM NhanVien WHERE email = @Email AND pass_word = @Password";
                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    // Sử dụng ExecuteReader để lấy dữ liệu
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nhanVien = new NhanVien(reader);
                            break;
                        }
                    }
                    return nhanVien;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                // Đảm bảo kết nối luôn được đóng
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public static bool signUp(String fullname, String cccd, String email, String password)
        {
            try
            {
                _connection.Open();
                // Truy vấn kiểm tra đăng nhập
                string query = "INSERT INTO NhanVien (full_name, cccd, email, pass_word, chuc_vu) VALUES (@Fullname, @Cccd, @Email, @Password, @Chucvu)";
                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@Fullname", fullname);
                    cmd.Parameters.AddWithValue("@Cccd", cccd);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Chucvu", "Nhân Viên");

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // Đảm bảo kết nối luôn được đóng
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
    }
}
