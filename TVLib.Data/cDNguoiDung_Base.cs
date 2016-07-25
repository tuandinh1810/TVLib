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
        public DataTable Get(NguoiDungInfo pNguoiDungInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NguoiDungID",SqlDbType.Int,pNguoiDungInfo.NguoiDungID));

            return RunProcedureGet("sp_NguoiDung_Get", colParam);            
        }

        public int Add(NguoiDungInfo pNguoiDungInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNguoiDung",SqlDbType.NVarChar,pNguoiDungInfo.TenNguoiDung));
            colParam.Add(CreateParam("@TenDangNHap",SqlDbType.NVarChar,pNguoiDungInfo.TenDangNHap));
            colParam.Add(CreateParam("@MatKhau",SqlDbType.NChar,pNguoiDungInfo.MatKhau));
            colParam.Add(CreateParam("@Email",SqlDbType.NChar,pNguoiDungInfo.Email));
            colParam.Add(CreateParam("@DienThoai",SqlDbType.NVarChar,pNguoiDungInfo.DienThoai));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pNguoiDungInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_NguoiDung_Add", colParam);
        }
        
        public int  Update(NguoiDungInfo pNguoiDungInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNguoiDung",SqlDbType.NVarChar,pNguoiDungInfo.TenNguoiDung));
            colParam.Add(CreateParam("@TenDangNHap",SqlDbType.NVarChar,pNguoiDungInfo.TenDangNHap));
            colParam.Add(CreateParam("@MatKhau",SqlDbType.NChar,pNguoiDungInfo.MatKhau));
            colParam.Add(CreateParam("@Email",SqlDbType.NChar,pNguoiDungInfo.Email));
            colParam.Add(CreateParam("@DienThoai",SqlDbType.NVarChar,pNguoiDungInfo.DienThoai));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pNguoiDungInfo.GhiChu));
            colParam.Add(CreateParam("@NguoiDungID",SqlDbType.Int,pNguoiDungInfo.NguoiDungID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));


            return RunProcedureOut("sp_NguoiDung_Update", colParam);
        }
        
        public void Delete(NguoiDungInfo pNguoiDungInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NguoiDungID",SqlDbType.Int,pNguoiDungInfo.NguoiDungID));

            RunProcedure("sp_NguoiDung_Delete", colParam);
        }
    }
}
