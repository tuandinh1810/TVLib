using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDTaiLieu : cDBase
    {
        public DataTable GetByLoaiTaiLieu(int pIDLoaiTaiLieu)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDLoaiTaiLieu", SqlDbType.Int, pIDLoaiTaiLieu));

            return RunProcedureGet("sp_TaiLieu_GetByLoaiTaiLieu", colParam);
        }
        public DataTable GetMaxMaTaiLieu()
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Para", SqlDbType.Int,0));

            return RunProcedureGet("sp_TaiLieu_GetMaxMaTaiLieu", colParam);
        }

        public DataTable GetTop20_MuonNhieuNhat(DateTime dtFromDate, DateTime dtToDate)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@FromDate", SqlDbType.DateTime, dtFromDate));
            colParam.Add(CreateParam("@ToDate", SqlDbType.DateTime, dtToDate));

            return RunProcedureGet("sp_TaiLieu_Top20MuonNhieuNhat", colParam);
        }
        public DataTable GetTop20_BanDoc(DateTime dtFromDate, DateTime dtToDate)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@FromDate", SqlDbType.DateTime, dtFromDate));
            colParam.Add(CreateParam("@ToDate", SqlDbType.DateTime, dtToDate));

            return RunProcedureGet("sp_TaiLieu_Top20_BanDoc", colParam);
        }
        public DataTable GetTop20_MuonTrongNgay(DateTime dtFromDate)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@FromDate", SqlDbType.DateTime, dtFromDate));

            return RunProcedureGet("sp_TaiLieu_Top20_MuonTrongNgay", colParam);
        }
        public DataTable Get_BaoCao_DangMuon(string Khoa, string Lop, string SoThe, DateTime TuNgay, DateTime DenNgay, string MaTaiLieu, string MaXepGia, int IDKho)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Khoa", SqlDbType.NVarChar, 50, Khoa));
            colParam.Add(CreateParam("@Lop", SqlDbType.NVarChar, 50, Lop));
            colParam.Add(CreateParam("@SoThe", SqlDbType.NVarChar, 50, SoThe));
            colParam.Add(CreateParam("@TuNgay", SqlDbType.DateTime, TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));
            colParam.Add(CreateParam("@MaTaiLieu", SqlDbType.NVarChar, 100, MaTaiLieu));
            colParam.Add(CreateParam("@MaXepGia", SqlDbType.NVarChar, 50, MaXepGia));
            colParam.Add(CreateParam("@IDKho", SqlDbType.Int , IDKho));

            return RunProcedureGet("sp_TaiLieu_BaoCao_DangMuon", colParam);
        }
        public DataTable Get_BaoCao_LichSuMuon(string SoThe, DateTime MuonTuNgay, DateTime MuonDenNgay, DateTime TraTuNgay, DateTime TraDenNgay, string MaTaiLieu, string MaXepGia, int IDKho)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoThe", SqlDbType.NVarChar, 50, SoThe));
            colParam.Add(CreateParam("@MuonTuNgay", SqlDbType.DateTime, MuonTuNgay));
            colParam.Add(CreateParam("@MuonDenNgay", SqlDbType.DateTime, MuonDenNgay));
            colParam.Add(CreateParam("@TraTuNgay", SqlDbType.DateTime, TraTuNgay));
            colParam.Add(CreateParam("@TraDenNgay", SqlDbType.DateTime, TraDenNgay));
            colParam.Add(CreateParam("@MaTaiLieu", SqlDbType.NVarChar, 100, MaTaiLieu));
            colParam.Add(CreateParam("@MaXepGia", SqlDbType.NVarChar, 50, MaXepGia));
            colParam.Add(CreateParam("@IDKho", SqlDbType.Int, IDKho));

            return RunProcedureGet("sp_TaiLieu_BaoCao_LichSuMuon", colParam);
        }
        //--sp_TaiLieu_ThongKeTaiLieuTrongKho
        public DataTable ThongKeTaiLieuTrongKho()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_TaiLieu_ThongKeTaiLieuTrongKho", colParam);
        }
        public DataTable ThongKeTaiLieuTheoNamBoSung(int TuNam,int DenNam)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@TuNam", SqlDbType.Int, TuNam));
            colParam.Add(CreateParam("@DenNam", SqlDbType.Int, DenNam));
            return RunProcedureGet("sp_ThongKe_TaiLieuTheoNamBoSung", colParam);
        }
        public DataTable GetSoLuongTaiLieu(string TuNgay, string DenNgay, int IDNguoiDung)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TuNgay", SqlDbType.VarChar, TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.VarChar, DenNgay));
            colParam.Add(CreateParam("@IDNguoiDung", SqlDbType.Int, IDNguoiDung));

            return RunProcedureGet("sp_TaiLieu_GetSoLuong_ByNguoiDung", colParam);
        }
        public DataTable GetSoLuongTaiLieuByUser(DateTime TuNgay, DateTime DenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TuNgay", SqlDbType.VarChar, TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.VarChar, DenNgay));


            return RunProcedureGet("[sp_TaiLieu_GetSoLuong_ByUser]", colParam);
        }
        public DataTable GetSoLuong_ByKho(string TuNgay, string DenNgay, int IDKho, int intType)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TuNgay", SqlDbType.VarChar, TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.VarChar, DenNgay));
            colParam.Add(CreateParam("@IDKho", SqlDbType.Int, IDKho));
            colParam.Add(CreateParam("@intType", SqlDbType.Int, intType));

            return RunProcedureGet("sp_TaiLieu_GetSoLuong_ByKho", colParam);
        }
        public DataTable GetSoLuongMXG_ByKho(DateTime TuNgay,DateTime DenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TuNgay", SqlDbType.DateTime, TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));

            return RunProcedureGet("sp_TaiLieu_GetSoLuongMXG_ByKho", colParam);
        }
        public DataTable GetSoLuong_NgayBienMuc(int Ngay, int Thang, int Nam)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Ngay", SqlDbType.Int, Ngay));
            colParam.Add(CreateParam("@Thang", SqlDbType.Int, Thang));
            colParam.Add(CreateParam("@Nam", SqlDbType.Int, Nam));

            return RunProcedureGet("sp_TaiLieu_GetSoLuong_NgayBienMuc", colParam);
        }
        public DataTable GetSoLuong_ByNgayBienMuc( int Thang, int Nam)
        {
            ArrayList colParam = new ArrayList();

           
            colParam.Add(CreateParam("@Thang", SqlDbType.Int, Thang));
            colParam.Add(CreateParam("@Nam", SqlDbType.Int, Nam));

            return RunProcedureGet("sp_TaiLieu_GetSoLuong_ByNgayBienMuc", colParam);
        }
        public DataTable GetSoLuong_ByIDLoaiTaiLieu(int Thang, int Nam, int IDLoaiTaiLieu)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Thang", SqlDbType.Int, Thang));
            colParam.Add(CreateParam("@Nam", SqlDbType.Int, Nam));
            colParam.Add(CreateParam("@IDLoaiTaiLieu", SqlDbType.Int, IDLoaiTaiLieu));

            return RunProcedureGet("sp_TaiLieu_GetSoLuong_ByIDLoaiTaiLieu", colParam);
        }
        public DataTable GetSoLuong_ByLoaiTaiLieu(int Thang, int Nam)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Thang", SqlDbType.Int, Thang));
            colParam.Add(CreateParam("@Nam", SqlDbType.Int, Nam));


            return RunProcedureGet("[sp_TaiLieu_GetSoLuong_ByLoaiTaiLieu]", colParam);
        }
    }
}
