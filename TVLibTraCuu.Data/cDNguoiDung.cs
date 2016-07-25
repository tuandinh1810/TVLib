using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDNguoiDung : cDBase
    {
        public DataTable Login(NguoiDungInfo pNguoiDungInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenDangNHap", SqlDbType.NVarChar, pNguoiDungInfo.TenDangNHap));
            colParam.Add(CreateParam("@MatKhau", SqlDbType.NVarChar, pNguoiDungInfo.MatKhau));

            return RunProcedureGet("sp_NguoiDung_Login", colParam);
        }

    }
}
