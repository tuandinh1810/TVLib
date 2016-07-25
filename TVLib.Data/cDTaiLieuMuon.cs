using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDTaiLieuMuon : cDBase
    {

        public DataTable Search(int IDBanDoc, string SoThe, string TuNgayMuon, string DenNgayMuon, string MaXepGia, string TuNgayTra, string DenNgayTra)
        {
            ArrayList colParam = new ArrayList();

            //  colParam.Add(CreateParam("@MaXepGia", SqlDbType.VarChar, MaXepGia));
            // colParam.Add(CreateParam("@NgayMuon", SqlDbType.DateTime, pLichSuMuonInfo.NgayMuon));
            // colParam.Add(CreateParam("@NgayTra", SqlDbType.DateTime, pLichSuMuonInfo.NgayTra));
            colParam.Add(CreateParam("@IDBanDoc", SqlDbType.Int, IDBanDoc));
            //  colParam.Add(CreateParam("@SoNgayQuaHan", SqlDbType.Int, pLichSuMuonInfo.SoNgayQuaHan));
            //  colParam.Add(CreateParam("@SoTienPhat", SqlDbType.Float, pLichSuMuonInfo.SoTienPhat));
            //  colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureGet("sp_TaiLieuMuon_Search", colParam);
        }

        public DataTable GetByChuoiMaXepGia(string strMaXepGia)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGias", SqlDbType.NVarChar,500, strMaXepGia));

            return RunProcedureGet("sp_TaiLieuMuon_GetByMaXepGia", colParam);
        }

        public DataTable UpdateGiaHan(string TaiLieuMuonIDs, DateTime dtNgayGiaHan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiLieuMuonIDs", SqlDbType.VarChar, 2000, TaiLieuMuonIDs));
            colParam.Add(CreateParam("@NgayGiaHan", SqlDbType.DateTime, dtNgayGiaHan));

            return RunProcedureGet("sp_TaiLieuMuon_GiaHan", colParam);
        }


        public DataTable GetMuonSachBySoThe(string strSoThe)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoThe", SqlDbType.NVarChar, 50, strSoThe));

            return RunProcedureGet("sp_TaiLieuMuon_GetByBanDoc", colParam);
        }
        public DataTable GetMuonSachByBanDocID(int BanDocID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@BanDocID", SqlDbType.Int, BanDocID));

            return RunProcedureGet("sp_TaiLieuMuon_GetByBanDocID", colParam);
        }
        // GhiTra method
        public int GhiTra(string strMaxepgia, float TienPhat, int Type)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia", SqlDbType.NVarChar, 50, strMaxepgia));
            colParam.Add(CreateParam("@PhiPhat", SqlDbType.Float, TienPhat));
            colParam.Add(CreateParam("@Type", SqlDbType.Int, Type));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TaiLieuMuon_GhiTra", colParam);
        }
    }
}
