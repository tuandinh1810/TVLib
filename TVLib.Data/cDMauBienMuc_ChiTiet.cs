using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDMauBienMuc_ChiTiet : cDBase
    {
        public DataTable Get_ByMauBienMuc(int IDMauBienMuc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDMauBienMuc", SqlDbType.Int, IDMauBienMuc));

            return RunProcedureGet("sp_MauBienMuc_ChiTiet_Get_ByMauBienMuc", colParam);
        }
    }
}
