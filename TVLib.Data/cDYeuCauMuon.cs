using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDYeuCauMuon : cDBase
    {
        public DataTable GetByThoiDiem(DateTime TuNgay, DateTime DenNgay, string SoThe)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TuNgay", SqlDbType.DateTime, TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));
            colParam.Add(CreateParam("@SoThe", SqlDbType.VarChar, SoThe));
            return RunProcedureGet("[sp_YeuCauMuon_GetByThoiGian]", colParam);
        }
    }
}
