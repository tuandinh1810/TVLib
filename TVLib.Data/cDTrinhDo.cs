using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDTrinhDo : cDBase
    {
        public void GopTrinhDo(TrinhDoInfo pTrinhDoInfo, int intTrinhDoID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TrinhDoID", SqlDbType.Int, pTrinhDoInfo.TrinhDoID));
            colParam.Add(CreateParam("@TrinhDoIDGop", SqlDbType.Int, intTrinhDoID));
            

             RunProcedure("sp_TrinhDo_Gop", colParam);
        }
    }
}
