using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDFile_BoSuuTap : cDBase
    {
        public DataTable Get(File_BoSuuTapInfo pFile_BoSuuTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@File_BoSuuTapID",SqlDbType.Int,pFile_BoSuuTapInfo.File_BoSuuTapID));

            return RunProcedureGet("sp_File_BoSuuTap_Get", colParam);            
        }

        public int Add(File_BoSuuTapInfo pFile_BoSuuTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDFile",SqlDbType.Int,pFile_BoSuuTapInfo.IDFile));
            colParam.Add(CreateParam("@IDBoSuuTap",SqlDbType.Int,pFile_BoSuuTapInfo.IDBoSuuTap));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_File_BoSuuTap_Add", colParam);
        }
        
        public void Update(File_BoSuuTapInfo pFile_BoSuuTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDFile",SqlDbType.Int,pFile_BoSuuTapInfo.IDFile));
            colParam.Add(CreateParam("@IDBoSuuTap",SqlDbType.Int,pFile_BoSuuTapInfo.IDBoSuuTap));
            colParam.Add(CreateParam("@File_BoSuuTapID",SqlDbType.Int,pFile_BoSuuTapInfo.File_BoSuuTapID));

            RunProcedure("sp_File_BoSuuTap_Update", colParam);
        }
        
        public void Delete(File_BoSuuTapInfo pFile_BoSuuTapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@File_BoSuuTapID",SqlDbType.Int,pFile_BoSuuTapInfo.File_BoSuuTapID));

            RunProcedure("sp_File_BoSuuTap_Delete", colParam);
        }
    }
}
