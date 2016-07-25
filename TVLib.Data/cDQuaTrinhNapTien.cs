using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDQuaTrinhNapTien : cDBase
    {
        public DataTable Search(string strMaTaiKhoan, string strThang, string strNam )
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaTaiKhoan", SqlDbType.NVarChar ,50, strMaTaiKhoan));
            colParam.Add(CreateParam("@Thang", SqlDbType.VarChar, 50, strThang));
            colParam.Add(CreateParam("@Nam", SqlDbType.VarChar, 50, strNam));

            return RunProcedureGet("sp_QuaTrinhNapTien_Search", colParam);
        }
    }
}
