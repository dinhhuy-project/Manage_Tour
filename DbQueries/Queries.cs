using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Data.Common;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Data.Odbc;

namespace Manage_tour.DbQueries
{
    internal class Queries
    {
        private static SqlConnection _connection = DbConnection.getInstance().GetSqlConnection();
        public static NhanVienModel logIn(String email, String password)
        {
            NhanVienModel nhanVien = null;
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
                            nhanVien = new NhanVienModel(reader);
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

        public static ArrayList Select(string stmt, params object[] args)
        {
            ArrayList resultSet = new ArrayList();

            try
            {
                _connection.Open();
                if (_connection == null) return resultSet;

                using (SqlCommand cmd = new SqlCommand(stmt, _connection))
                {
                    // Add parameters to the prepared statement
                    for (int i = 0; i < args.Length; ++i)
                    {
                        cmd.Parameters.AddWithValue($"@p{i + 1}", args[i]);
                    }

                    // Execute query and read data
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Tạo một ArrayList con chứa dữ liệu của từng hàng
                            ArrayList row = new ArrayList();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row.Add(reader.GetValue(i)); // Thêm giá trị của từng cột vào hàng
                            }
                            resultSet.Add(row.ToArray()); // Thêm hàng vào danh sách kết quả
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"SQL Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                // Đảm bảo kết nối luôn được đóng
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return resultSet;
        }

        public static int Update(string stmt, params object[] args)
        {
            int totalAffectedRows = 0;

            try
            {
                _connection.Open();
                if (_connection == null) return 0;

                // Tạo SqlCommand
                using (SqlCommand cmd = new SqlCommand(stmt, _connection))
                {
                    // Thêm tham số vào câu lệnh SQL
                    for (int i = 0; i < args.Length; ++i)
                    {
                        cmd.Parameters.AddWithValue($"@p{i + 1}", args[i]);
                    }

                    // Thực thi câu lệnh SQL
                    totalAffectedRows = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"SQL Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                // Đảm bảo kết nối luôn được đóng
                if (_connection != null && _connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return totalAffectedRows;
        }
    }
}
