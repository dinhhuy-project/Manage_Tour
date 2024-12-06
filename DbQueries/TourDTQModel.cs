﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class TourDTQModel
    {
        public TourDTQModel(SqlDataReader reader)
        {
            ma_tour = reader["ma_tour"].ToString();  
            ma_diem_tham_quan = reader["ma_diem_tham_quan"].ToString();  
        }

        public TourDTQModel(object[] dataRow) {
            ma_tour = dataRow[0].ToString();
            ma_diem_tham_quan= dataRow[1].ToString();
        }

        public TourDTQModel(string Ma_tour, string Ma_diem_tham_quan)
        {
            ma_tour = Ma_tour;
            ma_diem_tham_quan = Ma_diem_tham_quan;
        }

        // Lấy tất cả Tour-DiemThamQuan
        public static ArrayList selectAll()
        {
            return DbQueries.Queries.Select(QUERY_SELECT_ALL);
        }

        // Lấy Tour-DiemThamQuan theo mã Tour hoặc mã Điểm Tham Quan
        public static TourDTQModel selectByKey(string maTour, string maDTQ)
        {
            TourDTQModel tourDTQ = null;
            foreach (object[] dataRow in DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, maTour, maDTQ))
            {
                tourDTQ = new TourDTQModel(dataRow);
            }
            return tourDTQ;
        }

        // Thêm mới (đối tượng)
        public static int insert(TourDTQModel tourDTQ)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, tourDTQ.ma_tour, tourDTQ.ma_diem_tham_quan);
            return result;
        }

        // Thêm mới (tham số)
        public static int insert(string ma_tour, string ma_diem_tham_quan)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, ma_tour, ma_diem_tham_quan);
            return result;
        }

        public static int update(TourDTQModel tourDTQ)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY,  tourDTQ.ma_diem_tham_quan , tourDTQ.ma_tour);
            return result;
        }

        public static int update(string ma_diem_tham_quan , string ma_tour)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY,  ma_diem_tham_quan , ma_tour);
            return result;
        }

        // Xóa Tour-DiemThamQuan
        public static int delete(TourDTQModel tourDTQ)
        {
            int result = DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, tourDTQ.ma_tour, tourDTQ.ma_diem_tham_quan);
            return result;
        }

        // Xóa bằng tham số
        public static int delete(string ma_tour, string ma_diem_tham_quan)
        {
            int result = DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, ma_tour , ma_diem_tham_quan);
            return result;
        }

        // Các trường và truy vấn SQL
        public static string TABLE = "Tour_DiemThamQuan";
        public static string FIELD_MA_TOUR = "ma_tour";
        public static string FIELD_MA_DIEM_THAM_QUAN = "ma_diem_tham_quan";

        public static string QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static string QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_TOUR}=@p1 AND {FIELD_MA_DIEM_THAM_QUAN}=@p2";
        public static string QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_MA_TOUR}, {FIELD_MA_DIEM_THAM_QUAN}) VALUES (@p1, @p2)";
        public static string QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_MA_DIEM_THAM_QUAN}=@p1 WHERE {FIELD_MA_TOUR} = @p2";
        public static string QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_MA_TOUR}=@p1 AND {FIELD_MA_DIEM_THAM_QUAN}=@p2";


        public string ma_tour { get; set; }  
        public string ma_diem_tham_quan { get; set; }  
    }
}