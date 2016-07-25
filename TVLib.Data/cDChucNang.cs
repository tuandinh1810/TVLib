using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDChucNang : cDBase
    {
        public DataTable GetByPhanHe(ChucNangInfo pChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@PhanHeID", SqlDbType.Int, pChucNangInfo.IDPhanHe ));

            return RunProcedureGet("sp_ChucNang_Get_By_PhanHe", colParam);
        }
        public DataTable GetByMaChucNang(ChucNangInfo pChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaChucNang", SqlDbType.VarChar, pChucNangInfo.MaChucNang));

            return RunProcedureGet("[sp_ChucNang_Get_ByMaChucNang]", colParam);
        }
        public DataTable GetQuyenKhongDuocCap(int IDNguoiDung, int IDPhanHe)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNguoiDung", SqlDbType.Int, IDNguoiDung));
            colParam.Add(CreateParam("@IDPhanHe", SqlDbType.Int, IDPhanHe));

            return RunProcedureGet("sp_ChucNang_GetQuyenKhongDuocCap", colParam);
        }
        public DataTable GetQuyenDuocCap(int IDNguoiDung, int IDPhanHe)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNguoiDung", SqlDbType.Int, IDNguoiDung));
            colParam.Add(CreateParam("@IDPhanHe", SqlDbType.Int, IDPhanHe));

            return RunProcedureGet("sp_ChucNang_GetQuyenDuocCap", colParam);
        }
    }
}
