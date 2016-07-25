using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDFile_TruongDublin : cDBase
    {
        public DataTable Get(File_TruongDublinInfo pFile_TruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@File_TruongDublin_ID",SqlDbType.Int,pFile_TruongDublinInfo.File_TruongDublin_ID));

            return RunProcedureGet("sp_File_TruongDublin_Get", colParam);            
        }

        public int Add(File_TruongDublinInfo pFile_TruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDFile",SqlDbType.Int,pFile_TruongDublinInfo.IDFile));
            colParam.Add(CreateParam("@IDTruongDublin",SqlDbType.Int,pFile_TruongDublinInfo.IDTruongDublin));
            colParam.Add(CreateParam("@DisplayEntry",SqlDbType.NVarChar,pFile_TruongDublinInfo.DisplayEntry));
            colParam.Add(CreateParam("@AccessEntry",SqlDbType.NVarChar,pFile_TruongDublinInfo.AccessEntry));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_File_TruongDublin_Add", colParam);
        }
        
        public void Update(File_TruongDublinInfo pFile_TruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDFile",SqlDbType.Int,pFile_TruongDublinInfo.IDFile));
            colParam.Add(CreateParam("@IDTruongDublin",SqlDbType.Int,pFile_TruongDublinInfo.IDTruongDublin));
            colParam.Add(CreateParam("@DisplayEntry",SqlDbType.NVarChar,pFile_TruongDublinInfo.DisplayEntry));
            colParam.Add(CreateParam("@AccessEntry",SqlDbType.NVarChar,pFile_TruongDublinInfo.AccessEntry));
            colParam.Add(CreateParam("@File_TruongDublin_ID",SqlDbType.Int,pFile_TruongDublinInfo.File_TruongDublin_ID));

            RunProcedure("sp_File_TruongDublin_Update", colParam);
        }
        
        public void Delete(File_TruongDublinInfo pFile_TruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@File_TruongDublin_ID",SqlDbType.Int,pFile_TruongDublinInfo.File_TruongDublin_ID));

            RunProcedure("sp_File_TruongDublin_Delete", colParam);
        }
    }
}
