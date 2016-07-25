using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDMauBienMuc : cDBase
    {
        public DataTable Get(MauBienMucInfo pMauBienMucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MauBienMucID",SqlDbType.Int,pMauBienMucInfo.MauBienMucID));

            return RunProcedureGet("sp_MauBienMuc_Get", colParam);            
        }

        public int Add(MauBienMucInfo pMauBienMucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Ten",SqlDbType.NVarChar,pMauBienMucInfo.Ten));
            colParam.Add(CreateParam("@IDNguoiDung",SqlDbType.Int,pMauBienMucInfo.IDNguoiDung));
            colParam.Add(CreateParam("@NgayTao",SqlDbType.DateTime,pMauBienMucInfo.NgayTao));
            colParam.Add(CreateParam("@NgaySuaCuoi",SqlDbType.DateTime,pMauBienMucInfo.NgaySuaCuoi));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_MauBienMuc_Add", colParam);
        }
        
        public void Update(MauBienMucInfo pMauBienMucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Ten",SqlDbType.NVarChar,pMauBienMucInfo.Ten));
            colParam.Add(CreateParam("@IDNguoiDung",SqlDbType.Int,pMauBienMucInfo.IDNguoiDung));
            colParam.Add(CreateParam("@NgayTao",SqlDbType.DateTime,pMauBienMucInfo.NgayTao));
            colParam.Add(CreateParam("@NgaySuaCuoi",SqlDbType.DateTime,pMauBienMucInfo.NgaySuaCuoi));
            colParam.Add(CreateParam("@MauBienMucID",SqlDbType.Int,pMauBienMucInfo.MauBienMucID));

            RunProcedure("sp_MauBienMuc_Update", colParam);
        }
        
        public void Delete(MauBienMucInfo pMauBienMucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MauBienMucID",SqlDbType.Int,pMauBienMucInfo.MauBienMucID));

            RunProcedure("sp_MauBienMuc_Delete", colParam);
        }
    }
}
