using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDBoSuuTap : cDBase
    {
        public DataTable GetFile_ByBoSuuTapID(int intBoSuuTapID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDBoSuuTap", SqlDbType.Int, intBoSuuTapID));
            return RunProcedureGet("sp_FileInfor_GetByIDBoSuuTap", colParam);
        }
    }
}
