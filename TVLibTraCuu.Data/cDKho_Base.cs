using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDKho : cDBase
    {
        public DataTable Get(KhoInfo pKhoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KhoID",SqlDbType.Int,pKhoInfo.KhoID));

            return RunProcedureGet("sp_Kho_Get", colParam);            
        }

        public int Add(KhoInfo pKhoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaKho",SqlDbType.NVarChar,pKhoInfo.MaKho));
            colParam.Add(CreateParam("@TenKho",SqlDbType.NVarChar,pKhoInfo.TenKho));
            colParam.Add(CreateParam("@IDThuVien",SqlDbType.Int,pKhoInfo.IDThuVien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_Kho_Add", colParam);
        }
        
        public int Update(KhoInfo pKhoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaKho",SqlDbType.NVarChar,pKhoInfo.MaKho));
            colParam.Add(CreateParam("@TenKho",SqlDbType.NVarChar,pKhoInfo.TenKho));
            colParam.Add(CreateParam("@IDThuVien",SqlDbType.Int,pKhoInfo.IDThuVien));
            colParam.Add(CreateParam("@KhoID",SqlDbType.Int,pKhoInfo.KhoID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_Kho_Update", colParam);

      
        }
        
        public void Delete(KhoInfo pKhoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KhoID",SqlDbType.Int,pKhoInfo.KhoID));

            RunProcedure("sp_Kho_Delete", colParam);
        }
    }
}
