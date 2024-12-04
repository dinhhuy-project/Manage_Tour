using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class DatTourModel
    {
        public DatTourModel(object[] dataRow)
        {
            ma_dat_tour = dataRow[0].ToString();
            ma_tour = dataRow[1].ToString();
            ma_kh = dataRow[2].ToString();
            ngay_dat = ((DateTime)dataRow[3]).Date;
            so_luong_nguoi = dataRow[4] != DBNull.Value ? Convert.ToInt32(dataRow[4]) : 0;
            tong_tien = dataRow[5] != DBNull.Value ? Convert.ToDecimal(dataRow[5]) : 0;
            trang_thai = dataRow[6].ToString();
        }

        public DatTourModel(string Ma_dat_tour, string Ma_tour, string Ma_kh, DateTime Ngay_dat, int So_luong_nguoi, decimal Tong_tien, string Trang_thai)
        {
            ma_dat_tour = Ma_dat_tour;
            ma_tour = Ma_tour;
            ma_kh = Ma_kh;
            ngay_dat = Ngay_dat;
            so_luong_nguoi = So_luong_nguoi;
            tong_tien = Tong_tien;
            trang_thai = Trang_thai;
        }

        public static ArrayList selectAll()
        {
            return DbQueries.Queries.Select(QUERY_SELECT_ALL);
        }

        public static ArrayList selectLikeKey(string id)
        {
            return DbQueries.Queries.Select(QUERY_SELECT_LIKE_KEY, '%' + id + '%');
        }
        public static DatTourModel selectByKey(string id_mdt, string id_mt, string makh)
        {
            DatTourModel datTourModel = null;
            foreach (object[] dataRow in DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, id_mdt, id_mt, makh))
            {
                datTourModel = new DatTourModel(dataRow);
            }
            return datTourModel;
        }

        public static int insert(DatTourModel datTourModel)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT,
                datTourModel.ma_dat_tour,
                datTourModel.ma_tour,
                datTourModel.ma_kh,
                datTourModel.ngay_dat,
                datTourModel.so_luong_nguoi,
                datTourModel.tong_tien,
                datTourModel.trang_thai);
            return result;
        }

        public static int insert(string ma_dat_tour, string ma_tour, string ma_kh, DateTime ngay_dat, int so_luong_nguoi, decimal tong_tien, string trang_thai)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT,
                ma_dat_tour,
                ma_tour,
                ma_kh,
                ngay_dat,
                so_luong_nguoi,
                tong_tien,
                trang_thai);
            return result;
        }

        public static int update(DatTourModel datTourModel)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY,
                datTourModel.ma_tour,
                datTourModel.ma_kh,
                datTourModel.ngay_dat,
                datTourModel.so_luong_nguoi,
                datTourModel.tong_tien,
                datTourModel.trang_thai,
                datTourModel.ma_dat_tour);
            return result;
        }

        public static int update(string ma_tour, string ma_kh, DateTime ngay_dat, int so_luong_nguoi, decimal tong_tien, string trang_thai, string ma_dat_tour)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY,
                ma_tour,
                ma_kh,
                ngay_dat,
                so_luong_nguoi,
                tong_tien,
                trang_thai,
                ma_dat_tour);
            return result;
        }

        public static int delete(DatTourModel datTourModel)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, datTourModel.ma_dat_tour);
        }

        public static int delete(string id)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, id);
        }

        public static bool IsMaDatTourExist(string ma_dat_tour)
        {
            bool exists = false;

            
            foreach (object[] dataRow in DbQueries.Queries.Select($"SELECT COUNT(*) FROM {TABLE} WHERE {FIELD_MA_DAT_TOUR} = @p1", ma_dat_tour))
            {
                int count = Convert.ToInt32(dataRow[0]); // Đọc giá trị đếm từ kết quả truy vấn
                exists = count > 0; // Nếu số lượng lớn hơn 0, mã đặt tour tồn tại
            }

            return exists;
        }
        public static string GenerateMaDatTour()
        {
            string maDatTour;
            int counter = 1; 

            do
            {
                maDatTour = "DTour" + counter.ToString("D2"); 
                counter++;
            } while (IsMaDatTourExist(maDatTour)); // Kiểm tra xem mã đặt tour đã tồn tại chưa

            return maDatTour; // Trả về mã đặt tour mới
        }
        public static bool UpdateTourStatus(string ma_dat_tour, string trang_thai)
        {           
            string sql = $"UPDATE {TABLE} SET {FIELD_TRANG_THAI} = @p1 WHERE {FIELD_MA_DAT_TOUR} = @p2";

            try
            {
                int rowsAffected = DbQueries.Queries.Update(sql, trang_thai, ma_dat_tour);
                return rowsAffected > 0; // Trả về true nếu cập nhật thành công
            }
            catch (Exception ex)
            {
                return false; // Trả về false nếu có lỗi
            }
        }
        

        public static String TABLE = "DatTour";
        public static String FIELD_MA_DAT_TOUR = "ma_dat_tour";
        public static String FIELD_MA_TOUR = "ma_tour";
        public static String FIELD_MA_KH = "ma_kh";
        public static String FIELD_NGAY_DAT = "ngay_dat";
        public static String FIELD_SO_LUONG_NGUOI = "so_luong_nguoi";
        public static String FIELD_TONG_TIEN = "tong_tien";
        public static String FIELD_TRANG_THAI = "trang_thai";

        public static String QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static String QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_DAT_TOUR} = @p1 AND {FIELD_MA_TOUR} = @p2 AND {FIELD_MA_KH} = @p3";
        public static String QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_MA_DAT_TOUR}, {FIELD_MA_TOUR}, {FIELD_MA_KH}, {FIELD_NGAY_DAT}, {FIELD_SO_LUONG_NGUOI}, {FIELD_TONG_TIEN}, {FIELD_TRANG_THAI}) VALUES (@p1, @p2, @p3, CAST(@p4 AS DATE), @p5, @p6, @p7)";
        public static String QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_MA_TOUR}=@p1, {FIELD_MA_KH}=@p2, {FIELD_NGAY_DAT}=CAST(@p3 AS DATE), {FIELD_SO_LUONG_NGUOI}=@p4, {FIELD_TONG_TIEN}=@p5, {FIELD_TRANG_THAI}=@p6 WHERE {FIELD_MA_DAT_TOUR} = @p7";
        public static String QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_MA_DAT_TOUR} = @p1";
        public static String QUERY_SELECT_LIKE_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_DAT_TOUR} LIKE @p1 OR {FIELD_MA_TOUR} LIKE @p1 OR {FIELD_MA_KH} LIKE @p1";
        public string ma_dat_tour { get; set; }  
        public string ma_tour { get; set; }  
        public string ma_kh { get; set; }  
        public DateTime ngay_dat { get; set; }  
        public int so_luong_nguoi { get; set; } 
        public decimal tong_tien { get; set; }  
        public string trang_thai { get; set; }
        public string NgayDatFormatted => ngay_dat.ToString("dd/MM/yyyy");
    }
}
