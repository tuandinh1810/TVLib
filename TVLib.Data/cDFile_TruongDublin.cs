using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDFile_TruongDublin : cDBase
    {
        public DataTable Dublin_GetByID(int intFileID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@File_ID", SqlDbType.Int,intFileID));

            return RunProcedureGet("sp_File_TruongDublin_GetByIDFile", colParam);
        }
        public int UpDate_File_TruongDublin(int intIDFile, string strTruongDublinID, string strDisplayEntry, string strAccessEntry)
        {
            ArrayList colParam = new ArrayList();
 
            colParam.Add(CreateParam("@IDFile", SqlDbType.Int, intIDFile));
            colParam.Add(CreateParam("@strFieldIDs", SqlDbType.VarChar, strTruongDublinID));
            colParam.Add(CreateParam("@strDisplayEntry", SqlDbType.NVarChar, strDisplayEntry));
            colParam.Add(CreateParam("@strAccessEntry", SqlDbType.NVarChar, strAccessEntry));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));
            return RunProcedureOut("sp_File_TruongDublin_Add", colParam);
        }
        public DataTable RunSql(string strSql)
        {
            return RunStrSql(strSql);
        }
    }
}
