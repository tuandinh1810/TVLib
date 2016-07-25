using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDThuVien : cDBase
    {
        public DataTable Get(ThuVienInfo pThuVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ThuVienID",SqlDbType.Int,pThuVienInfo.ThuVienID));

            return RunProcedureGet("sp_ThuVien_Get", colParam);            
        }

        public int Add(ThuVienInfo pThuVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenThuVien",SqlDbType.NVarChar,pThuVienInfo.TenThuVien));
            colParam.Add(CreateParam("@MaThuVien",SqlDbType.NVarChar,pThuVienInfo.MaThuVien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_ThuVien_Add", colParam);
        }
        
        public int  Update(ThuVienInfo pThuVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenThuVien",SqlDbType.NVarChar,pThuVienInfo.TenThuVien));
            colParam.Add(CreateParam("@MaThuVien",SqlDbType.NVarChar,pThuVienInfo.MaThuVien));
            colParam.Add(CreateParam("@ThuVienID",SqlDbType.Int,pThuVienInfo.ThuVienID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_ThuVien_Update", colParam);
        }
        
        public void Delete(ThuVienInfo pThuVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ThuVienID",SqlDbType.Int,pThuVienInfo.ThuVienID));

            RunProcedure("sp_ThuVien_Delete", colParam);
        }
    }
}
