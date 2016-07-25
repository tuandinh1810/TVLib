using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDBanDoc_KhoaThe : cDBase
    {
        public DataTable Get(BanDoc_KhoaTheInfo pBanDoc_KhoaTheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@BanDocID",SqlDbType.Int,pBanDoc_KhoaTheInfo.BanDocID));

            return RunProcedureGet("sp_BanDoc_KhoaThe_Get", colParam);            
        }

        public int Add(BanDoc_KhoaTheInfo pBanDoc_KhoaTheInfo, string SoThe)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoThe",SqlDbType.VarChar,50,SoThe));
            colParam.Add(CreateParam("@NgayBatDau",SqlDbType.DateTime,pBanDoc_KhoaTheInfo.NgayBatDau));
            colParam.Add(CreateParam("@SoNgay",SqlDbType.Int,pBanDoc_KhoaTheInfo.SoNgay));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pBanDoc_KhoaTheInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_BanDoc_KhoaThe_Add", colParam);
        }
        
        public void Update(BanDoc_KhoaTheInfo pBanDoc_KhoaTheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NgayBatDau",SqlDbType.DateTime,pBanDoc_KhoaTheInfo.NgayBatDau));
            colParam.Add(CreateParam("@SoNgay",SqlDbType.Int,pBanDoc_KhoaTheInfo.SoNgay));            
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pBanDoc_KhoaTheInfo.GhiChu));
            colParam.Add(CreateParam("@BanDocID",SqlDbType.Int,pBanDoc_KhoaTheInfo.BanDocID));

            RunProcedure("sp_BanDoc_KhoaThe_Update", colParam);
        }
        
        public void Delete(BanDoc_KhoaTheInfo pBanDoc_KhoaTheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@BanDocID",SqlDbType.Int,pBanDoc_KhoaTheInfo.BanDocID));

            RunProcedure("sp_BanDoc_KhoaThe_Delete", colParam);
        }
    }
}
