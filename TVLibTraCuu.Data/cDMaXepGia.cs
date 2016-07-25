using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDMaXepGia : cDBase
    {
        public DataTable GetByIDTaiLieu(MaXepGiaInfo pMaXepGiaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu", SqlDbType.Int, pMaXepGiaInfo.IDTaiLieu));

            return RunProcedureGet("sp_MaXepGia_GetByTaiLieu", colParam);
        }
    }
}
