using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDTinTuc : cDBase
    {
        public DataTable GetTopTinTuc()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_TinTuc_GetTopTinTuc", colParam);
        }


        public DataTable Get_TomTatTinTuc(int TinTucID)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@TinTucID", SqlDbType.Int, TinTucID));

            return RunProcedureGet("sp_TinTuc_GetTomTat", colParam);
        }
    }
}
