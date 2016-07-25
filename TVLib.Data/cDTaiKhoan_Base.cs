using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDTaiKhoan : cDBase
    {
        public DataTable Get(TaiKhoanInfo pTaiKhoanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiKhoanID",SqlDbType.Int,pTaiKhoanInfo.TaiKhoanID));

            return RunProcedureGet("sp_TaiKhoan_Get", colParam);            
        }

        public int Add(TaiKhoanInfo pTaiKhoanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTaiKhoan",SqlDbType.NVarChar,pTaiKhoanInfo.TenTaiKhoan));
            colParam.Add(CreateParam("@GioiTinh",SqlDbType.Bit,pTaiKhoanInfo.GioiTinh));
            colParam.Add(CreateParam("@DonVi",SqlDbType.NVarChar,pTaiKhoanInfo.DonVi));
            colParam.Add(CreateParam("@PhongBan",SqlDbType.NVarChar,pTaiKhoanInfo.PhongBan));
            colParam.Add(CreateParam("@TenDangNhap",SqlDbType.NVarChar,pTaiKhoanInfo.TenDangNhap));
            colParam.Add(CreateParam("@MatKhau",SqlDbType.VarChar,pTaiKhoanInfo.MatKhau));
            colParam.Add(CreateParam("@Email",SqlDbType.VarChar,pTaiKhoanInfo.Email));
            colParam.Add(CreateParam("@DienThoai",SqlDbType.NVarChar,pTaiKhoanInfo.DienThoai));
            colParam.Add(CreateParam("@MucDoMat",SqlDbType.Int,pTaiKhoanInfo.MucDoMat));
            colParam.Add(CreateParam("@TienNap",SqlDbType.Money,pTaiKhoanInfo.TienNap));
            colParam.Add(CreateParam("@KichHoat",SqlDbType.Bit,pTaiKhoanInfo.KichHoat));         
            //colParam.Add(CreateParam("@DiaChi",SqlDbType.NVarChar,pTaiKhoanInfo.DiaChi));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TaiKhoan_Add", colParam);
        }
        
        public int  Update(TaiKhoanInfo pTaiKhoanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTaiKhoan",SqlDbType.NVarChar,pTaiKhoanInfo.TenTaiKhoan));
            colParam.Add(CreateParam("@GioiTinh",SqlDbType.Bit,pTaiKhoanInfo.GioiTinh));
            colParam.Add(CreateParam("@DonVi",SqlDbType.NVarChar,pTaiKhoanInfo.DonVi));
            colParam.Add(CreateParam("@PhongBan",SqlDbType.NVarChar,pTaiKhoanInfo.PhongBan));
            colParam.Add(CreateParam("@TenDangNhap",SqlDbType.NVarChar,pTaiKhoanInfo.TenDangNhap));
            colParam.Add(CreateParam("@MatKhau",SqlDbType.VarChar,pTaiKhoanInfo.MatKhau));
            colParam.Add(CreateParam("@Email",SqlDbType.VarChar,pTaiKhoanInfo.Email));
            colParam.Add(CreateParam("@DienThoai",SqlDbType.NVarChar,pTaiKhoanInfo.DienThoai));
            colParam.Add(CreateParam("@MucDoMat",SqlDbType.Int,pTaiKhoanInfo.MucDoMat));
            colParam.Add(CreateParam("@TienNap",SqlDbType.Money,pTaiKhoanInfo.TienNap));
            colParam.Add(CreateParam("@KichHoat",SqlDbType.Bit,pTaiKhoanInfo.KichHoat));
          //  colParam.Add(CreateParam("@DiaChi",SqlDbType.NVarChar,pTaiKhoanInfo.DiaChi));
            colParam.Add(CreateParam("@TaiKhoanID",SqlDbType.Int,pTaiKhoanInfo.TaiKhoanID));
            colParam.Add (CreateParamOut ("@ID",SqlDbType.Int ));

         return    RunProcedureOut("sp_TaiKhoan_Update", colParam);
        }
        
        public void Delete(TaiKhoanInfo pTaiKhoanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiKhoanID",SqlDbType.Int,pTaiKhoanInfo.TaiKhoanID));

            RunProcedure("sp_TaiKhoan_Delete", colParam);
        }
        public void KichHoat(string TaiKhoanIDs )
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiKhoanIDs", SqlDbType.VarChar ,200,TaiKhoanIDs  ));

            RunProcedure("sp_TaiKhoan_KichHoat", colParam);
        }
    }
}
