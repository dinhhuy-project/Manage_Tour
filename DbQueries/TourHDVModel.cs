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


        public TourHDVModel(string Ma_tour, string Ma_hdv)
        {
            ma_tour = Ma_tour;
            ma_hdv = Ma_hdv;
        }

        public static ArrayList selectAll()
        {
            return DbQueries.Queries.Select(QUERY_SELECT_ALL);
        }

        public static ArrayList selectLikeKey(string id)
        {
            return DbQueries.Queries.Select(QUERY_SELECT_LIKE_KEY, '%' + id + '%');
        }
        public static TourHDVModel selectByKey(string id, string idhdv)
        {
            TourHDVModel tourHdv = null;
            var dataRows = DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, id ,idhdv);

            foreach (object[] dataRow in dataRows)
            {
                tourHdv = new TourHDVModel(dataRow);
            }

            return tourHdv;
        }

        public static ArrayList select(string tourId, string HDVId)
        {
            return DbQueries.Queries.Select(QUERY, tourId, HDVId);
        }

        public static int insert(TourHDVModel tourHdv)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, tourHdv.ma_tour, tourHdv.ma_hdv);
            return result;
        }
        public static int insert(string ma_tour, string ma_hdv)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, ma_tour, ma_hdv);
            return result;
        }

        public static int update(TourHDVModel tourHdv)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, tourHdv.ma_hdv, tourHdv.ma_tour);
            return result;
        }

        public static int update(string ma_hdv_new, string ma_tour, string ma_hdv)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, ma_hdv_new, ma_tour, ma_hdv);
            return result;
        }

        public static int delete(TourHDVModel tourHdv)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, tourHdv.ma_tour, tourHdv.ma_hdv);
        }

        public static int delete(string id ,string idhdv)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, id, idhdv);
        }

        public static string TABLE = "Tour_HDV";
        public static string FIELD_MA_TOUR = "ma_tour";
        public static string FIELD_MA_HDV = "ma_hdv";

        public static string QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static string QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_TOUR} = @p1 AND {FIELD_MA_HDV}=@p2";
        public static string QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_MA_TOUR}, {FIELD_MA_HDV}) VALUES (@p1, @p2)";
        public static string QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_MA_HDV}=@p1 WHERE {FIELD_MA_TOUR} = @p2 AND {FIELD_MA_HDV}=@p3";
        public static string QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_MA_TOUR} = @p1 AND {FIELD_MA_HDV}=@p2";
        public static string QUERY_SELECT_LIKE_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_TOUR} LIKE @p1 OR {FIELD_MA_HDV} LIKE @p1";
        public static string QUERY = $"select tour.*,HuongDanVien.* FROM Tour,Tour_HDV,HuongDanVien WHERE Tour.ma_tour=Tour_HDV.ma_tour AND Tour_HDV.ma_hdv=HuongDanVien.ma_hdv AND Tour.ma_tour = @p1 AND HuongDanVien.ma_hdv=@p2";

        public string ma_tour { get; set; }  
        public string ma_hdv { get; set; }  
    }
}
