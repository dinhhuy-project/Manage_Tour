using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class ThanhToanModel
    {
        public ThanhToanModel(object[] dataRow)
        {
            ma_thanh_toan = dataRow[0].ToString();
            ma_dat_tour = dataRow[1].ToString();
            ngay_thanh_toan = dataRow[2] != DBNull.Value ? Convert.ToDateTime(dataRow[2]) : DateTime.MinValue;
            hinh_thuc = dataRow[3].ToString();
            tong_tien = dataRow[4] != DBNull.Value ? Convert.ToDecimal(dataRow[4]) : 0;
        }


        public ThanhToanModel(string Ma_thanh_toan, string Ma_dat_tour, DateTime Ngay_thanh_toan, string Hinh_thuc, decimal Tong_tien)
        {
            ma_thanh_toan = Ma_thanh_toan;
            ma_dat_tour = Ma_dat_tour;
            ngay_thanh_toan = Ngay_thanh_toan;
            hinh_thuc = Hinh_thuc;
            tong_tien = Tong_tien;
        }

        public static ArrayList selectAll()
        {
            return DbQueries.Queries.Select(QUERY_SELECT_ALL);
        }

        public static ThanhToanModel selectByKey(string id)
        {
            ThanhToanModel thanhToan = null;
            var dataRows = DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, id);

            foreach (object[] dataRow in dataRows)
            {
                thanhToan = new ThanhToanModel(dataRow);
            }

            return thanhToan;
        }

        public static int insert(ThanhToanModel thanhToan)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, thanhToan.ma_thanh_toan, thanhToan.ma_dat_tour, thanhToan.ngay_thanh_toan, thanhToan.hinh_thuc, thanhToan.tong_tien);
            return result;
        }

        public static int insert(string ma_thanh_toan, string ma_dat_tour, DateTime ngay_thanh_toan, string hinh_thuc, decimal tong_tien)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, ma_thanh_toan, ma_dat_tour, ngay_thanh_toan, hinh_thuc, tong_tien);
            return result;
        }

        public static int update(ThanhToanModel thanhToan)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, thanhToan.ma_dat_tour, thanhToan.ngay_thanh_toan, thanhToan.hinh_thuc, thanhToan.tong_tien, thanhToan.ma_thanh_toan);
            return result;
        }

        public static int update(string ma_dat_tour, DateTime ngay_thanh_toan, string hinh_thuc, decimal tong_tien, string ma_thanh_toan)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, ma_dat_tour, ngay_thanh_toan, hinh_thuc, tong_tien, ma_thanh_toan);
            return result;
        }

        public static int delete(ThanhToanModel thanhToan)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, thanhToan.ma_thanh_toan);
        }

        public static int delete(string id)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, id);
        }
        public static bool IsMaThanhToanExist(string ma_thanh_toan)
        {
            bool exists = false;

           
            foreach (object[] dataRow in DbQueries.Queries.Select($"SELECT COUNT(*) FROM {TABLE} WHERE {FIELD_MA_THANH_TOAN} = @p1", ma_thanh_toan))
            {
                int count = Convert.ToInt32(dataRow[0]); // Đọc giá trị đếm từ kết quả truy vấn
                exists = count > 0; // Nếu số lượng lớn hơn 0, mã đặt tour tồn tại
            }

            return exists;
        }
        public static string GenerateMaThanhToan()
        {
            string ma_thanh_toan;
            int counter = 1; 

            do
            {
                ma_thanh_toan = "TT" + counter.ToString("D2"); 
                counter++; 
            } while (IsMaThanhToanExist(ma_thanh_toan)); // Kiểm tra xem mã thanhtoan đã tồn tại chưa

            return ma_thanh_toan; // Trả về mã thanhtoan mới
        }

        public static ArrayList SelectBySearchTerm(string searchTerm)
        {
            // Tạo truy vấn tìm kiếm
            string sql = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_THANH_TOAN} LIKE @p1 OR {FIELD_MA_DAT_TOUR} LIKE @p1";

            // Thực hiện truy vấn và trả về kết quả
            return DbQueries.Queries.Select(sql, "%" + searchTerm + "%");
        }
        public static string TABLE = "ThanhToan";
        public static string FIELD_MA_THANH_TOAN = "ma_thanh_toan";
        public static string FIELD_MA_DAT_TOUR = "ma_dat_tour";
        public static string FIELD_NGAY_THANH_TOAN = "ngay_thanh_toan";
        public static string FIELD_HINH_THUC = "hinh_thuc";
        public static string FIELD_TONG_TIEN = "tong_tien";

        public static string QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static string QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_THANH_TOAN} = @p1";
        public static string QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_MA_THANH_TOAN}, {FIELD_MA_DAT_TOUR}, {FIELD_NGAY_THANH_TOAN}, {FIELD_HINH_THUC}, {FIELD_TONG_TIEN}) VALUES (@p1, @p2, @p3, @p4, @p5)";
        public static string QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_MA_DAT_TOUR}=@p1, {FIELD_NGAY_THANH_TOAN}=@p2, {FIELD_HINH_THUC}=@p3, {FIELD_TONG_TIEN}=@p4 WHERE {FIELD_MA_THANH_TOAN} = @p5";
        public static string QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_MA_THANH_TOAN} = @p1";
    public string ma_thanh_toan { get; set; } 
        public string ma_dat_tour { get; set; } 
        public DateTime ngay_thanh_toan { get; set; }  
        public string hinh_thuc { get; set; }  
        public decimal tong_tien { get; set; }  
    }
}
