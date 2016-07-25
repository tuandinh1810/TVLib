using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDTinh : cDBase
    {
        public void GopTinh(TinhInfo pTinhInfo, int TinhIDGop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TinhID", SqlDbType.Int, pTinhInfo.TinhID));
            colParam.Add(CreateParam("@TinhIDGop", SqlDbType.Int, TinhIDGop));

            RunProcedure("sp_Tinh_GopTinh", colParam);
        }
    }
}
