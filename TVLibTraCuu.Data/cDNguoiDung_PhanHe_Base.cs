using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDNguoiDung_PhanHe : cDBase
    {
        public DataTable Get(NguoiDung_PhanHeInfo pNguoiDung_PhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNguoiDung",SqlDbType.Int,pNguoiDung_PhanHeInfo.IDNguoiDung));
            colParam.Add(CreateParam("@IDPhanHe",SqlDbType.Int,pNguoiDung_PhanHeInfo.IDPhanHe));

            return RunProcedureGet("sp_NguoiDung_PhanHe_Get", colParam);            
        }

        public int Add(NguoiDung_PhanHeInfo pNguoiDung_PhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNguoiDung",SqlDbType.Int,pNguoiDung_PhanHeInfo.IDNguoiDung));
            colParam.Add(CreateParam("@IDPhanHe",SqlDbType.Int,pNguoiDung_PhanHeInfo.IDPhanHe));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_NguoiDung_PhanHe_Add", colParam);
        }
        
        public void Update(NguoiDung_PhanHeInfo pNguoiDung_PhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNguoiDung",SqlDbType.Int,pNguoiDung_PhanHeInfo.IDNguoiDung));
            colParam.Add(CreateParam("@IDPhanHe",SqlDbType.Int,pNguoiDung_PhanHeInfo.IDPhanHe));

            RunProcedure("sp_NguoiDung_PhanHe_Update", colParam);
        }
        
        public void Delete(NguoiDung_PhanHeInfo pNguoiDung_PhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNguoiDung",SqlDbType.Int,pNguoiDung_PhanHeInfo.IDNguoiDung));
            colParam.Add(CreateParam("@IDPhanHe",SqlDbType.Int,pNguoiDung_PhanHeInfo.IDPhanHe));

            RunProcedure("sp_NguoiDung_PhanHe_Delete", colParam);
        }
    }
}
