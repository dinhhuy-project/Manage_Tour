using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class NhanVienModel
    {
        public NhanVienModel(SqlDataReader reader)
        {
            id = reader["id"].ToString();
            full_name = reader["full_name"].ToString();
            cccd = reader["cccd"].ToString();
            email = reader["email"].ToString();
            pass_word = reader["pass_word"].ToString();
            chuc_vu = reader["chuc_vu"].ToString();
        }

        public NhanVienModel(object[] dataRow)
        {
            id = dataRow[0].ToString();
            full_name = dataRow[1].ToString();
            cccd = dataRow[2].ToString();
            email = dataRow[3].ToString();
            pass_word = dataRow[4].ToString();
            chuc_vu = dataRow[5].ToString();
        }

        public NhanVienModel(string Id, string Fullname, string Cccd, string Email, string Password, string Chucvu)
        {
            id = Id;
            full_name = Fullname;
            cccd = Cccd;
            email = Email;
            pass_word = Password;
            chuc_vu = Chucvu;
        }

        public static ArrayList selectAll()
        {
            return DbQueries.Queries.Select(QUERY_SELECT_ALL);
        }

        public static ArrayList selectLikeKey(string id)
        {
            return DbQueries.Queries.Select(QUERY_SELECT_LIKE_KEY, '%' + id + '%');
        }

        // Phương thức tìm kiếm nhân viên theo ID
        public static NhanVienModel selectByKey(string id)
        {
            NhanVienModel nhanVien = null;
            foreach (object[] dataRow in DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, id))
            {
                nhanVien = new NhanVienModel(dataRow);
            }
            return nhanVien;
        }

        // Phương thức thêm nhân viên
        public static int insert(NhanVienModel nhanVien)
        {
            return DbQueries.Queries.Update(
                QUERY_INSERT,
                nhanVien.id,
                nhanVien.full_name,
                nhanVien.cccd,
                nhanVien.email,
                nhanVien.pass_word,
                nhanVien.chuc_vu
            );
        }

        public static int insert(string id, string full_name, string cccd, string email, string pass_word, string chuc_vu)
        {
            return DbQueries.Queries.Update(
                QUERY_INSERT,
                id, full_name, cccd, email, pass_word, chuc_vu
            );
        }

        // Phương thức cập nhật thông tin nhân viên
        public static int update(NhanVienModel nhanVien)
        {
            return DbQueries.Queries.Update(
                QUERY_UPDATE_BY_KEY,
                nhanVien.full_name,
                nhanVien.cccd,
                nhanVien.email,
                nhanVien.chuc_vu,
                nhanVien.id
            );
        }

        public static int update(string full_name, string cccd, string email, string chuc_vu, string id)
        {
            return DbQueries.Queries.Update(
                QUERY_UPDATE_BY_KEY,
                full_name, cccd, email, chuc_vu, id
            );
        }

        // Phương thức xóa nhân viên
        public static int delete(NhanVienModel nhanVien)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, nhanVien.id);
        }

        public static int delete(string id)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, id);
        }

        // Các biến liên quan đến bảng và truy vấn SQL
        public static String TABLE = "NhanVien";
        public static String FIELD_ID = "id";
        public static String FIELD_FULL_NAME = "full_name";
        public static String FIELD_CCCD = "cccd";
        public static String FIELD_EMAIL = "email";
        public static String FIELD_PASSWORD = "pass_word";
        public static String FIELD_CHUC_VU = "chuc_vu";

        public static String QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static String QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_ID} = @p1";
        public static String QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_ID}, {FIELD_FULL_NAME}, {FIELD_CCCD}, {FIELD_EMAIL}, {FIELD_PASSWORD}, {FIELD_CHUC_VU}) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
        public static String QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_FULL_NAME}=@p1, {FIELD_CCCD}=@p2, {FIELD_EMAIL}=@p3, {FIELD_CHUC_VU}=@p4 WHERE {FIELD_ID}=@p5";
        public static String QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_ID}=@p1";
        public static String QUERY_SELECT_LIKE_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_ID} LIKE @p1 OR {FIELD_FULL_NAME} LIKE @p1 OR {FIELD_CCCD} LIKE @p1";


        public string id { get; set; }
        public string full_name { get; set; }
        public string cccd { get; set; }
        public string email { get; set; }
        public string pass_word { get; set; }
        public string chuc_vu { get; set; }
    }
}
