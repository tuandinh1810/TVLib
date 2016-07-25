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
        public DataTable Get(LienKetFileInfo pLienKetFileInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LienKetFileID",SqlDbType.Int,pLienKetFileInfo.LienKetFileID));

            return RunProcedureGet("sp_LienKetFile_Get", colParam);            
        }

        public int Add(LienKetFileInfo pLienKetFileInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDFile1",SqlDbType.Int,pLienKetFileInfo.IDFile1));
            colParam.Add(CreateParam("@IDFile2",SqlDbType.Int,pLienKetFileInfo.IDFile2));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_LienKetFile_Add", colParam);
        }
        
        public void Update(LienKetFileInfo pLienKetFileInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDFile1",SqlDbType.Int,pLienKetFileInfo.IDFile1));
            colParam.Add(CreateParam("@IDFile2",SqlDbType.Int,pLienKetFileInfo.IDFile2));
            colParam.Add(CreateParam("@LienKetFileID",SqlDbType.Int,pLienKetFileInfo.LienKetFileID));

            RunProcedure("sp_LienKetFile_Update", colParam);
        }
        
        public void Delete(LienKetFileInfo pLienKetFileInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LienKetFileID",SqlDbType.Int,pLienKetFileInfo.LienKetFileID));

            RunProcedure("sp_LienKetFile_Delete", colParam);
        }
    }
}
