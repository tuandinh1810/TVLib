using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDThuVien : cDBase
    {
        public void GopThuVien(ThuVienInfo pThuVienInfo, int intThuVienIDGop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ThuVienID", SqlDbType.Int, pThuVienInfo.ThuVienID));
            colParam.Add(CreateParam("@ThuVienIDGop", SqlDbType.Int, intThuVienIDGop));


            RunProcedure("sp_ThuVien_Gop", colParam);
        }
       
    }
}
