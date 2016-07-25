using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDMauPhich : cDBase
    {
        public DataTable Get(MauPhichInfo pMauPhichInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MauPhichID",SqlDbType.Int,pMauPhichInfo.MauPhichID));

            return RunProcedureGet("sp_MauPhich_Get", colParam);            
        }

        public int Add(MauPhichInfo pMauPhichInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenMauPhich",SqlDbType.NVarChar,pMauPhichInfo.TenMauPhich));
            colParam.Add(CreateParam("@GiaTri",SqlDbType.NText,pMauPhichInfo.GiaTri));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_MauPhich_Add", colParam);
        }
        
        public void Update(MauPhichInfo pMauPhichInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenMauPhich",SqlDbType.NVarChar,pMauPhichInfo.TenMauPhich));
            colParam.Add(CreateParam("@GiaTri",SqlDbType.NText,pMauPhichInfo.GiaTri));
            colParam.Add(CreateParam("@MauPhichID",SqlDbType.Int,pMauPhichInfo.MauPhichID));

            RunProcedure("sp_MauPhich_Update", colParam);
        }
        
        public void Delete(MauPhichInfo pMauPhichInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MauPhichID",SqlDbType.Int,pMauPhichInfo.MauPhichID));

            RunProcedure("sp_MauPhich_Delete", colParam);
        }
    }
}
