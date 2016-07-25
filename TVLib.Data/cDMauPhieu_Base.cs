using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDMauPhieu : cDBase
    {
        public DataTable Get(MauPhieuInfo pMauPhieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MauPhieuID",SqlDbType.Int,pMauPhieuInfo.MauPhieuID));

            return RunProcedureGet("sp_MauPhieu_Get", colParam);            
        }

        public int Add(MauPhieuInfo pMauPhieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenMauPhieu",SqlDbType.NVarChar,pMauPhieuInfo.TenMauPhieu));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NText,pMauPhieuInfo.NoiDung));
            colParam.Add(CreateParam("@NgayTao",SqlDbType.DateTime,pMauPhieuInfo.NgayTao));
            colParam.Add(CreateParam("@LoaiPhieu",SqlDbType.Int,pMauPhieuInfo.LoaiPhieu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_MauPhieu_Add", colParam);
        }
        
        public void Update(MauPhieuInfo pMauPhieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenMauPhieu",SqlDbType.NVarChar,pMauPhieuInfo.TenMauPhieu));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NText,pMauPhieuInfo.NoiDung));
            colParam.Add(CreateParam("@NgayTao",SqlDbType.DateTime,pMauPhieuInfo.NgayTao));
            colParam.Add(CreateParam("@LoaiPhieu",SqlDbType.Int,pMauPhieuInfo.LoaiPhieu));
            colParam.Add(CreateParam("@MauPhieuID",SqlDbType.Int,pMauPhieuInfo.MauPhieuID));

            RunProcedure("sp_MauPhieu_Update", colParam);
        }
        
        public void Delete(MauPhieuInfo pMauPhieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MauPhieuID",SqlDbType.Int,pMauPhieuInfo.MauPhieuID));

            RunProcedure("sp_MauPhieu_Delete", colParam);
        }
    }
}
