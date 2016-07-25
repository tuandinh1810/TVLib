using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDDanToc : cDBase
    {
        public DataTable Get(DanTocInfo pDanTocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DanTocID",SqlDbType.Int,pDanTocInfo.DanTocID));

            return RunProcedureGet("sp_DanToc_Get", colParam);            
        }

        public int Add(DanTocInfo pDanTocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DanToc",SqlDbType.NVarChar,pDanTocInfo.DanToc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_DanToc_Add", colParam);
        }
        
        public int  Update(DanTocInfo pDanTocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DanToc",SqlDbType.NVarChar,pDanTocInfo.DanToc));
            colParam.Add(CreateParam("@DanTocID",SqlDbType.Int,pDanTocInfo.DanTocID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_DanToc_Update", colParam);
        }
        
        public void Delete(DanTocInfo pDanTocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DanTocID",SqlDbType.Int,pDanTocInfo.DanTocID));

            RunProcedure("sp_DanToc_Delete", colParam);
        }
    }
}
