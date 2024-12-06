using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class TourHDVModel
    {
        public TourHDVModel(object[] dataRow)
        {
            ma_tour = dataRow[0].ToString();
            ma_hdv = dataRow[1].ToString();
        }

<<<<<<< HEAD
        public TourHDVModel(object[] dataRow)
        {
            ma_tour = dataRow[0].ToString();
            ma_hdv = dataRow[1].ToString();
        }
=======
>>>>>>> 1ee6b95ec52f249d2710167586f7f753c5beed07

        public TourHDVModel(string Ma_tour, string Ma_hdv)
        {
            ma_tour = Ma_tour;
            ma_hdv = Ma_hdv;
        }

<<<<<<< HEAD
        // Phương thức selectAll để lấy toàn bộ dữ liệu
=======
>>>>>>> 1ee6b95ec52f249d2710167586f7f753c5beed07
        public static ArrayList selectAll()
        {
            return DbQueries.Queries.Select(QUERY_SELECT_ALL);
        }

<<<<<<< HEAD
        // Phương thức selectByKey để lấy dữ liệu theo khóa
        public static TourHDVModel selectByKey(string maTour, string maHDV)
        {
            TourHDVModel tourHDV = null;
            foreach (object[] dataRow in DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, maTour, maHDV))
            {
                tourHDV = new TourHDVModel(dataRow);
            }
            return tourHDV;
        }

        // Phương thức insert để thêm mới bản ghi
        public static int insert(TourHDVModel tourHDV)
        {
            return DbQueries.Queries.Update(QUERY_INSERT, tourHDV.ma_tour, tourHDV.ma_hdv);
        }

        public static int insert(string maTour, string maHDV)
        {
            return DbQueries.Queries.Update(QUERY_INSERT, maTour, maHDV);
        }

        public static int update(TourHDVModel tourHDV)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, tourHDV.ma_hdv, tourHDV.ma_tour);
            return result;
        }

        public static int update(string ma_hdv, string ma_tour)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, ma_hdv, ma_tour);
            return result;
        }

        // Phương thức delete để xóa bản ghi theo đối tượng
        public static int delete(TourHDVModel tourHDV)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, tourHDV.ma_tour, tourHDV.ma_hdv);
        }

        // Phương thức delete để xóa bản ghi theo khóa
        public static int delete(string maTour, string maHDV)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, maTour, maHDV);
        }

        // Các hằng số đại diện cho tên bảng và cột
        public static string TABLE = "Tour_HDV";
        public static string FIELD_MA_TOUR = "ma_tour";
        public static string FIELD_MA_HDV = "ma_hdv";

        // Các câu lệnh truy vấn SQL
        public static string QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static string QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_TOUR} = @p1 AND {FIELD_MA_HDV} = @p2";
        public static string QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_MA_TOUR}, {FIELD_MA_HDV}) VALUES (@p1, @p2)";
        public static string QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_MA_HDV}=@p1 WHERE {FIELD_MA_TOUR} = @p2";
        public static string QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_MA_TOUR} = @p1 AND {FIELD_MA_HDV} = @p2";


=======
        public static ArrayList selectLikeKey(string id)
        {
            return DbQueries.Queries.Select(QUERY_SELECT_LIKE_KEY, '%' + id + '%');
        }
        public static TourHDVModel selectByKey(string id)
        {
            TourHDVModel tourHdv = null;
            var dataRows = DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, id);

            foreach (object[] dataRow in dataRows)
            {
                tourHdv = new TourHDVModel(dataRow);
            }

            return tourHdv;
        }

        public static int insert(TourHDVModel tourHdv)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, tourHdv.ma_tour, tourHdv.ma_hdv);
            return result;
        }

        public static int update(TourHDVModel tourHdv)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, tourHdv.ma_hdv, tourHdv.ma_tour);
            return result;
        }

        public static int delete(TourHDVModel tourHdv)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, tourHdv.ma_tour);
        }

        public static int delete(string id)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, id);
        }

        public static string TABLE = "TourHdv";
        public static string FIELD_MA_TOUR = "ma_tour";
        public static string FIELD_MA_HDV = "ma_hdv";

        public static string QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static string QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_TOUR} = @p1";
        public static string QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_MA_TOUR}, {FIELD_MA_HDV}) VALUES (@p1, @p2)";
        public static string QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_MA_HDV}=@p1 WHERE {FIELD_MA_TOUR} = @p2";
        public static string QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_MA_TOUR} = @p1";
        public static String QUERY_SELECT_LIKE_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_TOUR} LIKE @p1 OR {FIELD_MA_HDV} LIKE @p1";
>>>>>>> 1ee6b95ec52f249d2710167586f7f753c5beed07
        public string ma_tour { get; set; }  
        public string ma_hdv { get; set; }  
    }
}
