using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDNgheNghiep : cDBase
    {
        public DataTable GopNgheNghiep(NgheNghiepInfo pNgheNghiepInfo, int intNgheNghiepID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NgheNghiepID", SqlDbType.Int, pNgheNghiepInfo.NgheNghiepID));
            colParam.Add(CreateParam("@NgheNghiepIDGop", SqlDbType.Int, intNgheNghiepID));

            return RunProcedureGet("sp_NgheNghiep_Gop", colParam);
        }

    }
}
