using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public KhachHangModel(object[] dataRow) {
            ma_kh = dataRow[0].ToString();
            ten_kh= dataRow[1].ToString();
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

<<<<<<< HEAD
        // Lấy tất cả khách hàng
=======
>>>>>>> 1ee6b95ec52f249d2710167586f7f753c5beed07
        public static ArrayList selectAll()
        {
            return DbQueries.Queries.Select(QUERY_SELECT_ALL);
        }

<<<<<<< HEAD
        // Lấy khách hàng theo mã hoặc thông tin khác
        public static KhachHangModel selectByKey(string idKH)
        {
            KhachHangModel kh = null;
            foreach (object[] dataRow in DbQueries.Queries.Select(QUERY_SELECT_BY_KEY, idKH))
            {
                kh = new KhachHangModel(dataRow);
            }
            return kh;
        }

        // Thêm khách hàng mới (đối tượng)
        public static int insert(KhachHangModel kh)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, kh.ma_kh, kh.ten_kh, kh.sdt, kh.cccd, kh.dia_chi);
            return result;
        }

        // Thêm khách hàng mới (tham số)
=======
        public static ArrayList selectLikeKey(string id)
        {
            return DbQueries.Queries.Select(QUERY_SELECT_LIKE_KEY, '%' + id + '%');
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

>>>>>>> 1ee6b95ec52f249d2710167586f7f753c5beed07
        public static int insert(string ma_kh, string ten_kh, string sdt, string cccd, string dia_chi)
        {
            int result = DbQueries.Queries.Update(QUERY_INSERT, ma_kh, ten_kh, sdt, cccd, dia_chi);
            return result;
        }

<<<<<<< HEAD
        // Cập nhật thông tin khách hàng
        public static int update(KhachHangModel kh)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, kh.ten_kh, kh.sdt, kh.cccd, kh.dia_chi, kh.ma_kh);
            return result;
        }

        public static int update( string ten_kh, string sdt, string cccd, string dia_chi ,string ma_kh)
=======
        public static int update(KhachHangModel khachHangModel)
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, khachHangModel.ten_kh, khachHangModel.sdt, khachHangModel.cccd, khachHangModel.dia_chi, khachHangModel.ma_kh);
            return result;
        }

        public static int update(string ten_kh, string sdt, string cccd, string dia_chi, string ma_kh)
>>>>>>> 1ee6b95ec52f249d2710167586f7f753c5beed07
        {
            int result = DbQueries.Queries.Update(QUERY_UPDATE_BY_KEY, ten_kh, sdt, cccd, dia_chi, ma_kh);
            return result;
        }

<<<<<<< HEAD

        // Xóa khách hàng theo mã
        public static int delete(KhachHangModel kh)
        {
            int result = DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, kh.ma_kh);
            return result;
        }

        // Xóa khách hàng theo mã (tham số)
        public static int delete(string ma_kh)
        {
            int result = DbQueries.Queries.Update(QUERY_DELETE_BY_KEY, ma_kh);
            return result;
        }

        // Các trường và truy vấn SQL
        public static string TABLE = "KhachHang";
        public static string FIELD_MA_KH = "ma_kh";
        public static string FIELD_TEN_KH = "ten_kh";
        public static string FIELD_SDT = "sdt";
        public static string FIELD_CCCD = "cccd";
        public static string FIELD_DIA_CHI = "dia_chi";

        public static string QUERY_SELECT_ALL = $"SELECT * FROM {TABLE}";
        public static string QUERY_SELECT_BY_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_KH}=@p1 ";
        public static string QUERY_INSERT = $"INSERT INTO {TABLE} ({FIELD_MA_KH}, {FIELD_TEN_KH}, {FIELD_SDT}, {FIELD_CCCD}, {FIELD_DIA_CHI}) VALUES (@p1, @p2, @p3, @p4, @p5)";
        public static string QUERY_UPDATE_BY_KEY = $"UPDATE {TABLE} SET {FIELD_TEN_KH}=@p1, {FIELD_SDT}=@p2, {FIELD_CCCD}=@p3, {FIELD_DIA_CHI}=@p4 WHERE {FIELD_MA_KH}=@p5";
        public static string QUERY_DELETE_BY_KEY = $"DELETE FROM {TABLE} WHERE {FIELD_MA_KH}=@p1";


=======
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
        public static String QUERY_SELECT_LIKE_KEY = $"SELECT * FROM {TABLE} WHERE {FIELD_MA_KH} LIKE @p1 OR {FIELD_CCCD} LIKE @p1";
>>>>>>> 1ee6b95ec52f249d2710167586f7f753c5beed07
        public string ma_kh { get; set; }  
        public string ten_kh { get; set; }  
        public string sdt { get; set; }  
        public string cccd { get; set; } 
        public string dia_chi { get; set; } 
    }
}
