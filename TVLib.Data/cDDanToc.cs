using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDDanToc : cDBase
    {
        public void  GopDanToc(DanTocInfo pDanTocInfo, int DanTocIDGop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DanTocID", SqlDbType.Int,pDanTocInfo.DanTocID));
            colParam.Add(CreateParam("@DanTocIDGop", SqlDbType.Int,DanTocIDGop) );

            RunProcedure("sp_DanToc_GopDanToc", colParam);
        }
    }
}
