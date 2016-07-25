using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDNhanGay : cDBase
    {
        public DataTable Get(NhanGayInfo pNhanGayInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NhanGayID",SqlDbType.Int,pNhanGayInfo.NhanGayID));

            return RunProcedureGet("sp_NhanGay_Get", colParam);            
        }

        public int Add(NhanGayInfo pNhanGayInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNhanGay",SqlDbType.NVarChar,pNhanGayInfo.TenNhanGay));
            colParam.Add(CreateParam("@NoiDung", SqlDbType.NText, pNhanGayInfo.NoiDung));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_NhanGay_Add", colParam);
        }
        
        public void Update(NhanGayInfo pNhanGayInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNhanGay",SqlDbType.NVarChar,pNhanGayInfo.TenNhanGay));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NText,pNhanGayInfo.NoiDung));
            colParam.Add(CreateParam("@NhanGayID",SqlDbType.Int,pNhanGayInfo.NhanGayID));

            RunProcedure("sp_NhanGay_Update", colParam);
        }
        
        public void Delete(NhanGayInfo pNhanGayInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NhanGayID",SqlDbType.Int,pNhanGayInfo.NhanGayID));

            RunProcedure("sp_NhanGay_Delete", colParam);
        }
    }
}
