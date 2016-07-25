using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDTaiLieuMuon : cDBase
    {
        public DataTable GetByChuoiMaXepGia(string strMaXepGia)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGias", SqlDbType.NVarChar,500, strMaXepGia));

            return RunProcedureGet("sp_TaiLieuMuon_GetByMaXepGia", colParam);
        }

        public DataTable GetMuonSachBySoThe(string strSoThe)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoThe", SqlDbType.NVarChar, 50, strSoThe));

            return RunProcedureGet("sp_TaiLieuMuon_GetByBanDoc", colParam);
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
