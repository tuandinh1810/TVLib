using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDChucNang : cDBase
    {
        public DataTable Get(ChucNangInfo pChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ChucNangID",SqlDbType.Int,pChucNangInfo.ChucNangID));

            return RunProcedureGet("sp_ChucNang_Get", colParam);            
        }

        public int Add(ChucNangInfo pChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaChucNang",SqlDbType.NVarChar,pChucNangInfo.MaChucNang));
            colParam.Add(CreateParam("@TenChucNang",SqlDbType.NVarChar,pChucNangInfo.TenChucNang));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_ChucNang_Add", colParam);
        }
        
        public void Update(ChucNangInfo pChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaChucNang",SqlDbType.NVarChar,pChucNangInfo.MaChucNang));
            colParam.Add(CreateParam("@TenChucNang",SqlDbType.NVarChar,pChucNangInfo.TenChucNang));
            colParam.Add(CreateParam("@ChucNangID",SqlDbType.Int,pChucNangInfo.ChucNangID));

            RunProcedure("sp_ChucNang_Update", colParam);
        }
        
        public void Delete(ChucNangInfo pChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ChucNangID",SqlDbType.Int,pChucNangInfo.ChucNangID));

            RunProcedure("sp_ChucNang_Delete", colParam);
        }
    }
}
