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
        public string ma_tour { get; set; }  
        public string ma_hdv { get; set; }  
    }
}
