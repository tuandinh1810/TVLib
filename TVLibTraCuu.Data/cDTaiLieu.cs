using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDTaiLieu : cDBase
    {
        public DataTable GetTaiLieuInfo(TaiLieuInfo pTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@TaiLieuID", SqlDbType.Int, pTaiLieuInfo.TaiLieuID));
            return RunProcedureGet("sp_TaiLieu_Get_Detail", colParam);
        }
        public DataTable GetSoTapChiByTaiLieuID(TaiLieuInfo pTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@IDTaiLieu", SqlDbType.Int, pTaiLieuInfo.TaiLieuID));
            return RunProcedureGet("sp_TaiLieu_GetSoTapChiByTaiLieuID", colParam);
        }
        public DataTable GetTop20(TaiLieuInfo pTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();


            return RunProcedureGet("sp_TaiLieu_Get_Top20", colParam);
        }
        public DataTable Get20MuonNhieuNhat(TaiLieuInfo pTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();


            return RunProcedureGet("sp_TaiLieu_Top20MuonNhieuNhat", colParam);
        }
    }
}
