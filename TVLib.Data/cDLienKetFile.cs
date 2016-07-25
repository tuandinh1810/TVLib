using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDLienKetFile : cDBase
    {
        public DataTable GetByIDFile1(int intIDFile1)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDFile1", SqlDbType.Int, intIDFile1));

            return RunProcedureGet("sp_LienKetFile_GetByIDFile2", colParam);
        }
        public DataTable GetChuoiIDFile(int intLienKetFileID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LienKetFileID", SqlDbType.Int, intLienKetFileID));

            return RunProcedureGet("sp_LienKetFile_GetChuoiIDFile", colParam);
        }
    }
}
