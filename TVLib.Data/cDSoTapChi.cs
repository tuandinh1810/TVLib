using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDSoTapChi : cDBase
    {
        public DataTable GetByTaiLieuID_NamPhatHanh(int pTaiLieuID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiLieuID", SqlDbType.Int, pTaiLieuID));
            

            return RunProcedureGet("sp_SoTapChi_GetByTaiLieuID_NamPhatHanh", colParam);
        }
    }
}
