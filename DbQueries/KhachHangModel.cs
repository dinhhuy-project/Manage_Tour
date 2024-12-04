using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_tour.DbQueries
{
    public class KhachHangModel
    {
        public KhachHangModel(object[] dataRow)
        {
            ma_kh = dataRow[0].ToString();
            ten_kh = dataRow[1].ToString();
            sdt = dataRow[2].ToString();
            cccd = dataRow[3].ToString();
            dia_chi = dataRow[4].ToString();
        }

        public KhachHangModel(string Ma_kh, string Ten_kh, string Sdt, string Cccd, string Dia_chi)
        {
            ma_kh = Ma_kh;
            ten_kh = Ten_kh;
            sdt = Sdt;
            cccd = Cccd;
            dia_chi = Dia_chi;
        }

        public static ArrayList selectAll()
        {
            return DbQueries.Queries.Select(QUERY_SELECT_ALL);
        }

        public static KhachHangModel selectByKey(string id)
        {
            KhachHangModel khachHangModel = null;
            foreach (object[] dataRow in DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, id))
            {
                khachHangModel = new KhachHangModel(dataRow);
            }
            return khachHangModel;
        }

        public static int insert(KhachHangModel khachHangModel)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, khachHangModel.ma_kh, khachHangModel.ten_kh, khachHangModel.sdt, khachHangModel.cccd, khachHangModel.dia_chi);
            return result;
        }

        public static int insert(string ma_kh, string ten_kh, string sdt, string cccd, string dia_chi)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, ma_kh, ten_kh, sdt, cccd, dia_chi);
            return result;
        }

        public static int update(KhachHangModel khachHangModel)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, khachHangModel.ten_kh, khachHangModel.sdt, khachHangModel.cccd, khachHangModel.dia_chi, khachHangModel.ma_kh);
            return result;
        }

        public static int update(string ten_kh, string sdt, string cccd, string dia_chi, string ma_kh)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, ten_kh, sdt, cccd, dia_chi, ma_kh);
            return result;
        }

        public static int delete(KhachHangModel khachHangModel)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, khachHangModel.ma_kh);
        }

        public static int delete(string id)
        {
            return DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, id);
        }

        public static String TABLE = "KhachHang";
        public static String FIELD_MA_KH = "ma_kh";
        public static String FIELD_TEN_KH = "ten_kh";
        public static String FIELD_SDT = "sdt";
        public static String FIELD_CCCD = "cccd";
        public static String FIELD_DIA_CHI = "dia_chi";

        public static String QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static String QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_KH} = @p1";
        public static String QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_MA_KH}, {FIELD_TEN_KH}, {FIELD_SDT}, {FIELD_CCCD}, {FIELD_DIA_CHI}) VALUES (@p1, @p2, @p3, @p4, @p5)";
        public static String QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_TEN_KH}=@p1, {FIELD_SDT}=@p2, {FIELD_CCCD}=@p3, {FIELD_DIA_CHI}=@p4 WHERE {FIELD_MA_KH} = @p5";
        public static String QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_MA_KH} = @p1";

        public string ma_kh { get; set; }  
        public string ten_kh { get; set; }  
        public string sdt { get; set; }  
        public string cccd { get; set; } 
        public string dia_chi { get; set; } 
    }
}
