using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDNguoiDung_ChucNang : cDBase
    {
        public DataTable Get(NguoiDung_ChucNangInfo pNguoiDung_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NguoiDung_ChucNang_ID",SqlDbType.Int,pNguoiDung_ChucNangInfo.NguoiDung_ChucNang_ID));

            return RunProcedureGet("sp_NguoiDung_ChucNang_Get", colParam);            
        }

        public int Add(NguoiDung_ChucNangInfo pNguoiDung_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNguoiDung",SqlDbType.Int,pNguoiDung_ChucNangInfo.IDNguoiDung));
            colParam.Add(CreateParam("@IDChucNang",SqlDbType.Int,pNguoiDung_ChucNangInfo.IDChucNang));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_NguoiDung_ChucNang_Add", colParam);
        }
        
        public void Update(NguoiDung_ChucNangInfo pNguoiDung_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNguoiDung",SqlDbType.Int,pNguoiDung_ChucNangInfo.IDNguoiDung));
            colParam.Add(CreateParam("@IDChucNang",SqlDbType.Int,pNguoiDung_ChucNangInfo.IDChucNang));
            colParam.Add(CreateParam("@NguoiDung_ChucNang_ID",SqlDbType.Int,pNguoiDung_ChucNangInfo.NguoiDung_ChucNang_ID));

            RunProcedure("sp_NguoiDung_ChucNang_Update", colParam);
        }
        
        public void Delete(NguoiDung_ChucNangInfo pNguoiDung_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NguoiDung_ChucNang_ID",SqlDbType.Int,pNguoiDung_ChucNangInfo.NguoiDung_ChucNang_ID));

            RunProcedure("sp_NguoiDung_ChucNang_Delete", colParam);
        }
    }
}
