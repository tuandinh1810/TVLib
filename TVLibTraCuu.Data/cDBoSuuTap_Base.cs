using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDBoSuuTap : cDBase
    {
        public DataTable Get(BoSuuTapInfo pBoSuuTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@BoSuuTapID",SqlDbType.Int,pBoSuuTapInfo.BoSuuTapID));

            return RunProcedureGet("sp_BoSuuTap_Get", colParam);            
        }

        public int Add(BoSuuTapInfo pBoSuuTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenBoSuuTap",SqlDbType.NVarChar,pBoSuuTapInfo.TenBoSuuTap));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pBoSuuTapInfo.MoTa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_BoSuuTap_Add", colParam);
        }
        
        public void Update(BoSuuTapInfo pBoSuuTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenBoSuuTap",SqlDbType.NVarChar,pBoSuuTapInfo.TenBoSuuTap));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pBoSuuTapInfo.MoTa));
            colParam.Add(CreateParam("@BoSuuTapID",SqlDbType.Int,pBoSuuTapInfo.BoSuuTapID));

            RunProcedure("sp_BoSuuTap_Update", colParam);
        }
        
        public void Delete(BoSuuTapInfo pBoSuuTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@BoSuuTapID",SqlDbType.Int,pBoSuuTapInfo.BoSuuTapID));

            RunProcedure("sp_BoSuuTap_Delete", colParam);
        }
    }
}
