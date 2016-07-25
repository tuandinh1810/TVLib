using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDNguoiDung : cDBase
    {
        public DataTable Login(NguoiDungInfo pNguoiDungInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenDangNhap", SqlDbType.NVarChar, 50, pNguoiDungInfo.TenDangNHap));
            colParam.Add(CreateParam("@MatKhau", SqlDbType.VarChar, 50, pNguoiDungInfo.MatKhau));

            return RunProcedureGet("sp_NguoiDung_Login", colParam);
        }
    }
}
