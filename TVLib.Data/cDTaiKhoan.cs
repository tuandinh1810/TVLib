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
        public DataTable GetTaiKhoanByTenDangNhap(string strTenDangNhap)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenDangNhap", SqlDbType.VarChar , strTenDangNhap));

            return RunProcedureGet("sp_TaiKhoan_Get_By_TenDangNhap", colParam);   
        }

        public DataTable GetTaiChinhInfor(string strThoiGian, string strThang, string strNam)
        {
            ArrayList colParam = new ArrayList();
            if (strThoiGian != "")
            {
                colParam.Add(CreateParam("@ThoiGian", SqlDbType.VarChar, 50, ConvertDateBack(strThoiGian, false)));
            }
            else
                colParam.Add(CreateParam("@ThoiGian", SqlDbType.VarChar , 50, strThoiGian ));
            colParam.Add(CreateParam("@Thang", SqlDbType.VarChar, 50, strThang));
            colParam.Add(CreateParam("@Nam", SqlDbType.VarChar, 50, strNam));

            return RunProcedureGet("sp_TaiKhoan_TaiChinh", colParam);
        }
        public DataTable GetTienNopTaiKhoan(string strMaTaiKhoan,string strThoiGian, string strThang, string strNam)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@MaTaiKhoan", SqlDbType.VarChar, 50, strMaTaiKhoan ));
            if (strThoiGian != "")
            {
                colParam.Add(CreateParam("@ThoiGian", SqlDbType.VarChar, 50, ConvertDateBack(strThoiGian, false)));
            }
            else
                colParam.Add(CreateParam("@ThoiGian", SqlDbType.VarChar, 50, strThoiGian));
            colParam.Add(CreateParam("@Thang", SqlDbType.VarChar, 50, strThang));
            colParam.Add(CreateParam("@Nam", SqlDbType.VarChar, 50, strNam));

            return RunProcedureGet("sp_TaiKhoan_TienNopTaiKhoan", colParam);
        }
        public DataTable GetChiPhiMuaTaiLieu(string strMaTaiKhoan,string strThoiGian, string strThang, string strNam)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@MaTaiKhoan", SqlDbType.VarChar, 50, strMaTaiKhoan));
            if (strThoiGian != "")
            {
                colParam.Add(CreateParam("@ThoiGian", SqlDbType.VarChar, 50, ConvertDateBack(strThoiGian, false)));
            }
            else
                colParam.Add(CreateParam("@ThoiGian", SqlDbType.VarChar, 50, strThoiGian));
            colParam.Add(CreateParam("@Thang", SqlDbType.VarChar, 50, strThang));
            colParam.Add(CreateParam("@Nam", SqlDbType.VarChar, 50, strNam));

            return RunProcedureGet("sp_TaiKhoan_ChiPhiMuaTaiLieu", colParam);
        }
    }
}
