using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDTruongDublin : cDBase
    {
        public DataTable Get(TruongDublinInfo pTruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TruongDublinID",SqlDbType.Int,pTruongDublinInfo.TruongDublinID));

            return RunProcedureGet("sp_TruongDublin_Get", colParam);            
        }

        public int Add(TruongDublinInfo pTruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTruongDublin",SqlDbType.NVarChar,pTruongDublinInfo.TenTruongDublin));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TruongDublin_Add", colParam);
        }
        
        public void Update(TruongDublinInfo pTruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTruongDublin",SqlDbType.NVarChar,pTruongDublinInfo.TenTruongDublin));
            colParam.Add(CreateParam("@TruongDublinID",SqlDbType.Int,pTruongDublinInfo.TruongDublinID));

            RunProcedure("sp_TruongDublin_Update", colParam);
        }
        
        public void Delete(TruongDublinInfo pTruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TruongDublinID",SqlDbType.Int,pTruongDublinInfo.TruongDublinID));

            RunProcedure("sp_TruongDublin_Delete", colParam);
        }
    }
}
