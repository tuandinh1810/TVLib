using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDMARC : cDBase
    {
        public DataTable Get(MARCInfo pMARCInfo)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@MARCID", SqlDbType.Int, pMARCInfo.MARCID));

            return RunProcedureGet("sp_MARC_Get", colParam);            
        }

        public int Add(MARCInfo pMARCInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MARCID",SqlDbType.Int,pMARCInfo.MARCID));
            colParam.Add(CreateParam("@Name",SqlDbType.NVarChar,pMARCInfo.Name));
            colParam.Add(CreateParam("@Code",SqlDbType.NVarChar,pMARCInfo.Code));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_MARC_Add", colParam);
        }
        
        public void Update(MARCInfo pMARCInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MARCID",SqlDbType.Int,pMARCInfo.MARCID));
            colParam.Add(CreateParam("@Name",SqlDbType.NVarChar,pMARCInfo.Name));
            colParam.Add(CreateParam("@Code",SqlDbType.NVarChar,pMARCInfo.Code));

            RunProcedure("sp_MARC_Update", colParam);
        }
        
        public void Delete(MARCInfo pMARCInfo)
        {
            ArrayList colParam = new ArrayList();


            RunProcedure("sp_MARC_Delete", colParam);
        }
    }
}
