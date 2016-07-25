using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDFiLes : cDBase
    {
        public DataTable GetTop20(FiLesInfo pFiLesInfo)
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_FiLes_Get_Top20", colParam);
        }
        public DataTable GetTop10Download(FiLesInfo pFiLesInfo)
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_FiLes_Get_Top10_Download", colParam);
        }

        public DataTable GetFileDetail(FiLesInfo pFiLesInfo)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@FileID", SqlDbType.Int, pFiLesInfo.FileID));
            return RunProcedureGet("sp_FiLes_Get_Detail", colParam);
        }
        public DataTable GetLienKetFile(FiLesInfo pFilesInfo)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@FileID", SqlDbType.Int, pFilesInfo.FileID));
            return RunProcedureGet("sp_LienKetFile_GetByIDFile", colParam);
        }
        public DataTable GetFileExisted(int intFileID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@FileID", SqlDbType.Int, intFileID));

            return RunProcedureGet("sp_FiLes_GetFieleExisted", colParam);
        }
        public int CheckUser_DownloadFile(int intTaiKhoanID,int intFileID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@FileID", SqlDbType.Int, intFileID));
            colParam.Add(CreateParam("@TaiKhoanID", SqlDbType.Int, intTaiKhoanID));
            colParam.Add(CreateParamOut("@ID",SqlDbType.Int));

            return RunProcedureOut("sp_CheckUser_DownloadFile", colParam);
        }
    }
}
