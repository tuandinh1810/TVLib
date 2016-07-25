using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDLoaiTaiLieu : cDBase
    {
        public void GopLoaiTaiLieu(LoaiTaiLieuInfo pLoaiTaiLieuInfo, int intLoaiTaiLieuIDGop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LoaiTaiLieuID", SqlDbType.Int, pLoaiTaiLieuInfo.LoaiTaiLieuID));
            colParam.Add(CreateParam("@LoaiTaiLieuIDGop", SqlDbType.Int, intLoaiTaiLieuIDGop));


            RunProcedure("sp_LoaiTaiLieu_Gop", colParam);
        }
       
    }
}
