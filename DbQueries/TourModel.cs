using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Manage_tour.DbQueries
{
    public class TourModel
    {
        public TourModel(object[] dataRow)
        {
                ma_tour = dataRow[0].ToString();  
                ten_tour = dataRow[1].ToString();  
                gia = dataRow[2] != DBNull.Value ? Convert.ToDecimal(dataRow[2]) : 0;
                ngay_bd = dataRow[3] != DBNull.Value ? Convert.ToDateTime(dataRow[3]) : DateTime.MinValue;
                ngay_kt = dataRow[4] != DBNull.Value ? Convert.ToDateTime(dataRow[4]) : DateTime.MinValue;
        }

        public TourModel(string Ma_tour, string Ten_tour, string Gia, string Ngay_bd, string Ngay_kt)
        {
            ma_tour = Ma_tour;
            ten_tour = Ten_tour;

            // Chuyển đổi string Gia thành decimal
            gia = !string.IsNullOrEmpty(Gia) ? Convert.ToDecimal(Gia) : 0;

            // Chuyển đổi string Ngay_bd và Ngay_kt thành DateTime
            ngay_bd = !string.IsNullOrEmpty(Ngay_bd) ? Convert.ToDateTime(Ngay_bd) : DateTime.MinValue;
            ngay_kt = !string.IsNullOrEmpty(Ngay_kt) ? Convert.ToDateTime(Ngay_kt) : DateTime.MinValue;
        }

        public static ArrayList selectAll()
        {
            return DbQueries.Queries.Select(QUERY_SELECT_ALL);
        }
        public static TourModel selectByKey(string id)
        {
            TourModel tourModel = null;
            foreach (object[] dataRow in DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, id))
            {
                tourModel = new TourModel(dataRow);
            }
            return tourModel;
        }
        public static ArrayList selectLikeKey(string id)
        {
            return DbQueries.Queries.Select(QUERY_SELECT_LIKE_KEY, '%'+id+'%');
        }
        public static int insert(TourModel tourModel)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, tourModel.ma_tour, tourModel.ten_tour, tourModel.gia, tourModel.ngay_bd, tourModel.ngay_kt);
            return result;
        }
        public static int insert(string ma_tour, string ten_tour, float gia, DateTime ngay_bd, DateTime ngay_kt)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, ma_tour, ten_tour, gia, ngay_bd, ngay_kt);
            return result;
        }
        public static int update(TourModel tourModel)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, tourModel.ten_tour, tourModel.gia, tourModel.ngay_bd, tourModel.ngay_kt, tourModel.ma_tour);
            return result;
        }
        public static int update(string ten_tour, float gia, DateTime ngay_bd, DateTime ngay_kt, string ma_tour)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, ten_tour, gia, ngay_bd, ngay_kt, ma_tour);
            return result;
        }
        public static int delete(TourModel tourModel)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, tourModel.ma_tour);
        }
        public static int delete(string id)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, id);
        }

        public static String TABLE               = "Tour";
        public static String FIELD_MA_TOUR       = "ma_tour";
        public static String FIELD_TEN_TOUR      = "ten_tour";
        public static String FIELD_GIA           = "gia";
        public static String FIELD_NGAYBD        = "ngay_bd";
        public static String FIELD_NGAYKT        = "ngay_kt";

        //đặt value bắt đầu từ @p1 tiếp tục là @p2 @p3...
        public static String QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static String QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_TOUR} = @p1";
        public static String QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_MA_TOUR}, {FIELD_TEN_TOUR}, {FIELD_GIA}, {FIELD_NGAYBD}, {FIELD_NGAYKT}) VALUES (@p1, @p2, @p3, @p4, @p5)";
        public static String QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_TEN_TOUR}=@p1, {FIELD_GIA}=@p2, {FIELD_NGAYBD}=@p3, {FIELD_NGAYKT}=@p4 WHERE {FIELD_MA_TOUR} = @p5";
        public static String QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_MA_TOUR} = @p1";
        public static String QUERY_SELECT_LIKE_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_TOUR} LIKE @p1 OR {FIELD_TEN_TOUR} LIKE @p1";

        public string ma_tour { get; set; }
        public string ten_tour { get; set; }
        public decimal gia { get; set; }
        public DateTime ngay_bd { get; set; }
        public DateTime ngay_kt { get; set; }
    }
}
