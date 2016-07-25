using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDNhatKyHeThong : cDBase
    {
        public DataTable Get(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NhatKy_ID",SqlDbType.Int,pNhatKyHeThongInfo.NhatKy_ID));

            return RunProcedureGet("sp_NhatKyHeThong_Get", colParam);            
        }

        public int Add(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IPMay",SqlDbType.VarChar,pNhatKyHeThongInfo.IPMay));
            colParam.Add(CreateParam("@TenDangNhap",SqlDbType.NVarChar,pNhatKyHeThongInfo.TenDangNhap));
            colParam.Add(CreateParam("@CongViec",SqlDbType.NVarChar,pNhatKyHeThongInfo.CongViec));
            colParam.Add(CreateParam("@ThoiGian",SqlDbType.DateTime,pNhatKyHeThongInfo.ThoiGian));
            colParam.Add(CreateParam("@ID_ChucNang",SqlDbType.Int,pNhatKyHeThongInfo.ID_ChucNang));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_NhatKyHeThong_Add", colParam);
        }
        
        public void Update(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IPMay",SqlDbType.VarChar,pNhatKyHeThongInfo.IPMay));
            colParam.Add(CreateParam("@TenDangNhap",SqlDbType.NVarChar,pNhatKyHeThongInfo.TenDangNhap));
            colParam.Add(CreateParam("@CongViec",SqlDbType.NVarChar,pNhatKyHeThongInfo.CongViec));
            colParam.Add(CreateParam("@ThoiGian",SqlDbType.DateTime,pNhatKyHeThongInfo.ThoiGian));
            colParam.Add(CreateParam("@ID_ChucNang",SqlDbType.Int,pNhatKyHeThongInfo.ID_ChucNang));
            colParam.Add(CreateParam("@NhatKy_ID",SqlDbType.Int,pNhatKyHeThongInfo.NhatKy_ID));

            RunProcedure("sp_NhatKyHeThong_Update", colParam);
        }
        
        public void Delete(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NhatKy_ID",SqlDbType.Int,pNhatKyHeThongInfo.NhatKy_ID));

            RunProcedure("sp_NhatKyHeThong_Delete", colParam);
        }
    }
}
