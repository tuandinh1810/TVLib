using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDTinh : cDBase
    {
        public DataTable Get(TinhInfo pTinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TinhID",SqlDbType.Int,pTinhInfo.TinhID));

            return RunProcedureGet("sp_Tinh_Get", colParam);            
        }

        public int Add(TinhInfo pTinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTinh",SqlDbType.NVarChar,pTinhInfo.TenTinh));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_Tinh_Add", colParam);
        }
        
        public int Update(TinhInfo pTinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTinh",SqlDbType.NVarChar,pTinhInfo.TenTinh));
            colParam.Add(CreateParam("@TinhID",SqlDbType.Int,pTinhInfo.TinhID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_Tinh_Update", colParam);

            
        }
        
        public void Delete(TinhInfo pTinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TinhID",SqlDbType.Int,pTinhInfo.TinhID));

            RunProcedure("sp_Tinh_Delete", colParam);
        }
    }
}
