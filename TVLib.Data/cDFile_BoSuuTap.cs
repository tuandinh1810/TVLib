using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDFile_BoSuuTap : cDBase
    {
        public DataTable Get_File_BoSuuTap_ByIDBoSuuTap(string strIDBoSuuTaps)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@strIDBoSuuTap", SqlDbType.VarChar, strIDBoSuuTaps));

            return RunProcedureGet("sp_File_BoSuuTap_GetByIDBoSuuTap", colParam);
        }
        public DataTable Get_File_BoSuuTap_ByID(int IDBoSuuTap,int IDFile)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDBoSuuTap", SqlDbType.Int, IDBoSuuTap));
            colParam.Add(CreateParam("@IDFile", SqlDbType.Int, IDFile));
            return RunProcedureGet("sp_File_BoSuuTap_GetByID", colParam);
        }
        public DataTable GetCountByGroup(int intPara)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@intPara", SqlDbType.Int, intPara));
            return RunProcedureGet("sp_File_BoSuuTap_GetCountByGroup",colParam);
        }
        public void Delete_FieBoSuuTap_ByIDBoSuuTaps(string strIDBoSuuTap)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDBoSuuTap", SqlDbType.VarChar,strIDBoSuuTap));
            RunProcedure("sp_File_BoSuuTap_DeleteByIDBoSuuTap", colParam);
        }
    }
}
