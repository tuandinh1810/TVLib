using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDNguoiDung_PhanHe : cDBase
    {
        public DataTable GetNguoiDung_PhanHe(int IDNguoiDung)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNguoiDung", SqlDbType.Int, IDNguoiDung ));
            

            return RunProcedureGet("sp_NguoiDung_PhanHe_Get_ByNguoiDung", colParam);
        }

    }
}
