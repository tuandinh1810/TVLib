using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDNgheNghiep : cDBase
    {
        public DataTable Get(NgheNghiepInfo pNgheNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NgheNghiepID",SqlDbType.Int,pNgheNghiepInfo.NgheNghiepID));

            return RunProcedureGet("sp_NgheNghiep_Get", colParam);            
        }

        public int Add(NgheNghiepInfo pNgheNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNgheNghiep",SqlDbType.NVarChar,pNgheNghiepInfo.TenNgheNghiep));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_NgheNghiep_Add", colParam);
        }
        
        public int  Update(NgheNghiepInfo pNgheNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNgheNghiep",SqlDbType.NVarChar,pNgheNghiepInfo.TenNgheNghiep));
            colParam.Add(CreateParam("@NgheNghiepID",SqlDbType.Int,pNgheNghiepInfo.NgheNghiepID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_NgheNghiep_Update", colParam);
 
        }
        
        public void Delete(NgheNghiepInfo pNgheNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NgheNghiepID",SqlDbType.Int,pNgheNghiepInfo.NgheNghiepID));

            RunProcedure("sp_NgheNghiep_Delete", colParam);
        }
    }
}
