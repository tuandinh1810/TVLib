using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDDongTap : cDBase
    {
        public DataTable Get(DongTapInfo pDongTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DongTapID",SqlDbType.Int,pDongTapInfo.DongTapID));

            return RunProcedureGet("sp_DongTap_Get", colParam);            
        }

        public int Add(DongTapInfo pDongTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pDongTapInfo.IDTaiLieu));
            colParam.Add(CreateParam("@MaXepGia",SqlDbType.NVarChar,pDongTapInfo.MaXepGia));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DongTap_Add", colParam);
        }
        
        public void Update(DongTapInfo pDongTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pDongTapInfo.IDTaiLieu));
            colParam.Add(CreateParam("@MaXepGia",SqlDbType.NVarChar,pDongTapInfo.MaXepGia));
            colParam.Add(CreateParam("@DongTapID",SqlDbType.Int,pDongTapInfo.DongTapID));

            RunProcedure("sp_DongTap_Update", colParam);
        }
        
        public void Delete(DongTapInfo pDongTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DongTapID",SqlDbType.Int,pDongTapInfo.DongTapID));

            RunProcedure("sp_DongTap_Delete", colParam);
        }
    }
}
