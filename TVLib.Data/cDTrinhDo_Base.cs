using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDTrinhDo : cDBase
    {
        public DataTable Get(TrinhDoInfo pTrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TrinhDoID",SqlDbType.Int,pTrinhDoInfo.TrinhDoID));

            return RunProcedureGet("sp_TrinhDo_Get", colParam);            
        }

        public int Add(TrinhDoInfo pTrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TrinhDo",SqlDbType.NVarChar,pTrinhDoInfo.TrinhDo));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TrinhDo_Add", colParam);
        }
        
        public int Update(TrinhDoInfo pTrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TrinhDo",SqlDbType.NVarChar,pTrinhDoInfo.TrinhDo));
            colParam.Add(CreateParam("@TrinhDoID",SqlDbType.Int,pTrinhDoInfo.TrinhDoID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TrinhDo_Update", colParam);
        }
        
        public void Delete(TrinhDoInfo pTrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TrinhDoID",SqlDbType.Int,pTrinhDoInfo.TrinhDoID));

            RunProcedure("sp_TrinhDo_Delete", colParam);
        }
    }
}
