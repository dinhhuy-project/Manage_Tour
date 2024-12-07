using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class DiemThamQuanModel
    {
        public DiemThamQuanModel(object[] dataRow)
        {
            ma_diem_tham_quan = dataRow[0].ToString();
            ten_dia_diem = dataRow[1].ToString();
            dia_chi = dataRow[2].ToString();
        }

        public DiemThamQuanModel(string Ma_diem_tham_quan, string Ten_dia_diem, string Dia_chi)
        {
            ma_diem_tham_quan = Ma_diem_tham_quan;
            ten_dia_diem = Ten_dia_diem;
            dia_chi = Dia_chi;
        }

        public static ArrayList selectAll()
        {
            return DbQueries.Queries.Select(QUERY_SELECT_ALL);
        }

        public static ArrayList selectLikeKey(string id)
        {
            return DbQueries.Queries.Select(QUERY_SELECT_LIKE_KEY, '%' + id + '%');
        }
        public static DiemThamQuanModel selectByKey(string id)
        {
            DiemThamQuanModel diemThamQuanModel = null;
            foreach (object[] dataRow in DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, id))
            {
                diemThamQuanModel = new DiemThamQuanModel(dataRow);
            }
            return diemThamQuanModel;
        }

        public static int insert(DiemThamQuanModel diemThamQuanModel)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT,
                diemThamQuanModel.ma_diem_tham_quan,
                diemThamQuanModel.ten_dia_diem,
                diemThamQuanModel.dia_chi);
            return result;
        }

        public static int insert(string ma_diem_tham_quan, string ten_dia_diem, string dia_chi)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT,
                ma_diem_tham_quan,
                ten_dia_diem,
                dia_chi);
            return result;
        }

        public static int update(DiemThamQuanModel diemThamQuanModel)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY,
                diemThamQuanModel.ten_dia_diem,
                diemThamQuanModel.dia_chi,
                diemThamQuanModel.ma_diem_tham_quan);
            return result;
        }

        public static int update(string ten_dia_diem, string dia_chi, string ma_diem_tham_quan)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY,
                ten_dia_diem,
                dia_chi,
                ma_diem_tham_quan);
            return result;
        }

        public static int delete(DiemThamQuanModel diemThamQuanModel)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, diemThamQuanModel.ma_diem_tham_quan);
        }

        public static int delete(string id)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, id);
        }

        public static String TABLE = "DiemThamQuan";
        public static String FIELD_MA_DIEM_THAM_QUAN = "ma_diem_tham_quan";
        public static String FIELD_TEN_DIA_DIEM = "ten_dia_diem";
        public static String FIELD_DIA_CHI = "dia_chi";

        public static String QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static String QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_DIEM_THAM_QUAN} = @p1";
        public static String QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_MA_DIEM_THAM_QUAN}, {FIELD_TEN_DIA_DIEM}, {FIELD_DIA_CHI}) VALUES (@p1, @p2, @p3)";
        public static String QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_TEN_DIA_DIEM}=@p1, {FIELD_DIA_CHI}=@p2 WHERE {FIELD_MA_DIEM_THAM_QUAN} = @p3";
        public static String QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_MA_DIEM_THAM_QUAN} = @p1";
        public static String QUERY_SELECT_LIKE_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_DIEM_THAM_QUAN} LIKE @p1 OR {FIELD_TEN_DIA_DIEM} LIKE @p1";
        public string ma_diem_tham_quan { get; set; }  
        public string ten_dia_diem { get; set; }  
        public string dia_chi { get; set; }  
    }
}
