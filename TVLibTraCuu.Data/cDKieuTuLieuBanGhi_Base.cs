using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDKieuTuLieuBanGhi : cDBase
    {
        public DataTable Get(KieuTuLieuBanGhiInfo pKieuTuLieuBanGhiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KieuTuLieuBanGhiID",SqlDbType.Int,pKieuTuLieuBanGhiInfo.KieuTuLieuBanGhiID));

            return RunProcedureGet("sp_KieuTuLieuBanGhi_Get", colParam);            
        }

        public int Add(KieuTuLieuBanGhiInfo pKieuTuLieuBanGhiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenKieuTuLieuBanGhi",SqlDbType.NVarChar,pKieuTuLieuBanGhiInfo.TenKieuTuLieuBanGhi));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_KieuTuLieuBanGhi_Add", colParam);
        }
        
        public void Update(KieuTuLieuBanGhiInfo pKieuTuLieuBanGhiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenKieuTuLieuBanGhi",SqlDbType.NVarChar,pKieuTuLieuBanGhiInfo.TenKieuTuLieuBanGhi));
            colParam.Add(CreateParam("@KieuTuLieuBanGhiID",SqlDbType.Int,pKieuTuLieuBanGhiInfo.KieuTuLieuBanGhiID));

            RunProcedure("sp_KieuTuLieuBanGhi_Update", colParam);
        }
        
        public void Delete(KieuTuLieuBanGhiInfo pKieuTuLieuBanGhiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KieuTuLieuBanGhiID",SqlDbType.Int,pKieuTuLieuBanGhiInfo.KieuTuLieuBanGhiID));

            RunProcedure("sp_KieuTuLieuBanGhi_Delete", colParam);
        }
    }
}
