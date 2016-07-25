using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDPhanHe : cDBase
    {
        public DataTable Get(PhanHeInfo pPhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@PhanHeID",SqlDbType.Int,pPhanHeInfo.PhanHeID));

            return RunProcedureGet("sp_PhanHe_Get", colParam);            
        }

        public int Add(PhanHeInfo pPhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenPhanHe",SqlDbType.NVarChar,pPhanHeInfo.TenPhanHe));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_PhanHe_Add", colParam);
        }
        
        public void Update(PhanHeInfo pPhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenPhanHe",SqlDbType.NVarChar,pPhanHeInfo.TenPhanHe));
            colParam.Add(CreateParam("@PhanHeID",SqlDbType.Int,pPhanHeInfo.PhanHeID));

            RunProcedure("sp_PhanHe_Update", colParam);
        }
        
        public void Delete(PhanHeInfo pPhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@PhanHeID",SqlDbType.Int,pPhanHeInfo.PhanHeID));

            RunProcedure("sp_PhanHe_Delete", colParam);
        }
    }
}
