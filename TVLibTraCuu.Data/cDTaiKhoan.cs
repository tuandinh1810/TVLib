using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDTaiKhoan : cDBase
    {
        
        public DataTable Login(TaiKhoanInfo pTaiKhoanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenDangNhap", SqlDbType.NVarChar ,50, pTaiKhoanInfo.TenDangNhap));
            colParam.Add(CreateParam("@MatKhau", SqlDbType.VarChar, 50, pTaiKhoanInfo.MatKhau));

            return RunProcedureGet("sp_TaiKhoan_Login", colParam);
        }

        public DataTable GetFile_ByIDTaiKhoan(TaiKhoanInfo pTaiKhoanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiKhoan", SqlDbType.Int, pTaiKhoanInfo.TaiKhoanID));

            return RunProcedureGet("sp_TaiKhoan_File_GetByIDTaiKhoan", colParam);
        }

        public int LayLaiMatKhau(TaiKhoanInfo pTaiKhoanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenDangNhap", SqlDbType.NVarChar, 50, pTaiKhoanInfo.TenDangNhap));
            colParam.Add(CreateParam("@Email", SqlDbType.VarChar, 50, pTaiKhoanInfo.Email));
            colParam.Add(CreateParamOut("@ID",SqlDbType.Int));

            return RunProcedureOut("sp_TaiKhoan_QuenMatKhau", colParam);
        }

        public int  ThayDoiMatKhau(TaiKhoanInfo pTaiKhoanInfo, string strMatKhauMoi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenDangNhap", SqlDbType.NVarChar, 50, pTaiKhoanInfo.TenDangNhap));
            colParam.Add(CreateParam("@MatKhau", SqlDbType.VarChar, 50, pTaiKhoanInfo.MatKhau));
            colParam.Add(CreateParam("@MatKhauMoi", SqlDbType.VarChar, 50, strMatKhauMoi ));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TaiKhoan_DoiMatKhau", colParam);
        }

    }
}
