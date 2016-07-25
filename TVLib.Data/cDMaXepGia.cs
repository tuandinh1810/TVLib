using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDMaXepGia : cDBase
    {
        public DataTable GetByTaiLieu(int intIDTaiLieu)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu", SqlDbType.Int, intIDTaiLieu));

            return RunProcedureGet("[sp_MaXepGia_GetByTaiLieu]", colParam);
        }
        public DataTable GetByIDTaiLieus(string strIDTaiLieu)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu", SqlDbType.VarChar, strIDTaiLieu));

            return RunProcedureGet("[sp_MaXepGia_GetByIDTaiLieus]", colParam);
        }
        public DataTable Get_BaoCaoBoSung(int IDThuVien, int IDKho,DateTime TuNgay, DateTime DenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDThuVien", SqlDbType.Int, IDThuVien));
            colParam.Add(CreateParam("@IDKho", SqlDbType.Int, IDKho));
            colParam.Add(CreateParam("@TuNgay", SqlDbType.DateTime, TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));

            return RunProcedureGet("[sp_MaXepGia_Get_BaoCaoBoSung]", colParam);
        }
        public DataTable DanhMucSachMoi(DateTime TuNgay, DateTime DenNgay)
        {
            ArrayList colParam = new ArrayList();

            
            colParam.Add(CreateParam("@TuNgay", SqlDbType.DateTime, TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));

            return RunProcedureGet("[sp_TaiLieu_SachMoi]", colParam);
        }
        public DataTable Get_InMaVach(int IDThuVien, int IDKho, string MaXepGia, string MaTaiLieu, DateTime TuNgay, DateTime DenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDThuVien", SqlDbType.Int, IDThuVien));
            colParam.Add(CreateParam("@IDKho", SqlDbType.Int, IDKho));
            colParam.Add(CreateParam("@MaXepGia", SqlDbType.NVarChar, 4000, MaXepGia));
            colParam.Add(CreateParam("@MaTaiLieu", SqlDbType.NVarChar, 50, MaTaiLieu));
            colParam.Add(CreateParam("@TuNgay", SqlDbType.DateTime, TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));

            return RunProcedureGet("[sp_MaXepGia_Get_InMaVach]", colParam);
        }
        public DataTable Get_InNhanGay(int IDThuVien, int IDKho, string MaXepGia, string MaTaiLieu)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDThuVien", SqlDbType.Int, IDThuVien));
            colParam.Add(CreateParam("@IDKho", SqlDbType.Int, IDKho));
            colParam.Add(CreateParam("@MaXepGia", SqlDbType.NVarChar, 2500, MaXepGia));
            colParam.Add(CreateParam("@MaTaiLieu", SqlDbType.NVarChar, 50, MaTaiLieu));

            return RunProcedureGet("[sp_MaXepGia_Get_InNhanGay]", colParam);
        }
        public DataTable GetQuanLyKho(string DKCB, int IDKho, int LoaiChucNang)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DKCB", SqlDbType.NVarChar , DKCB));
            colParam.Add(CreateParam("@IDKho", SqlDbType.Int, IDKho));
            colParam.Add(CreateParam("@ChucNang", SqlDbType.Int, LoaiChucNang));

            return RunProcedureGet("[sp_MaXepGia_GetQuanLyKho]", colParam);
        }
        public DataTable MaXepGiaExisted(string strMaXepGia)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia", SqlDbType.VarChar, strMaXepGia));

            return RunProcedureGet("sp_XepGia_Existed", colParam);
        }
        public DataTable Get_MaXepGiaInfo_ByIDTaiLieu(int intIDTaiLieu)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu", SqlDbType.Int,intIDTaiLieu));

            return RunProcedureGet("sp_MaXepGia_GetInfo", colParam);
        }
        public void KiemNhanMoKhoa(string strID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@strID", SqlDbType.VarChar,2000,strID));

            RunProcedureGet("s_MaXepGia_KiemNhanMoKhoa", colParam);
        }
        public void ThanhLyDKCB(string strID, int IDLyDoThanhLy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@strID", SqlDbType.VarChar,3000, strID));
            colParam.Add(CreateParam("@IDLyDoThanhLy", SqlDbType.Int, IDLyDoThanhLy));

            RunProcedureGet("sp_MaXepGia_ThanhLy", colParam);
        }
        public void PhucHoiDKCB(string strID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@strID", SqlDbType.VarChar, 3000, strID));

            RunProcedureGet("[sp_MaXepGia_PhucHoi]", colParam);
        }

        public DataTable GetTotal(int IDTaiLieu)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu", SqlDbType.Int, IDTaiLieu));

            return RunProcedureGet("sp_XepGia_TotalByIDTaiLieu", colParam);
        }
    }
}
