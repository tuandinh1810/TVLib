using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDFiLes : cDBase
    {
        public DataTable GetFileByDuongDanThuMuc(string DuongDanThuMuc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DuongDanThuMuc", SqlDbType.VarChar, DuongDanThuMuc));

            return RunProcedureGet("[sp_File_GetByDuongDanThuMuc]", colParam);
        }
        public DataTable GetFileByDuongDanVatLy(string DuongDanVatLy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DuongDanVatLy", SqlDbType.VarChar, DuongDanVatLy));

            return RunProcedureGet("[sp_File_GetByDuongDanVatLy]", colParam);
        }
        public DataTable GetFileByIDBoSuuTap(int intIDBoSuuTap)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDBoSuuTap", SqlDbType.Int, intIDBoSuuTap));

            return RunProcedureGet("[sp_Files_GetByIDBoSuuTap]", colParam);
        }
        public void UpdateExisted(FiLesInfo pFilesInfo)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@KichCoFile", SqlDbType.Float, pFilesInfo.KichCoFile));
            colParam.Add(CreateParam("@Existed", SqlDbType.Bit, pFilesInfo.Existed));
            colParam.Add(CreateParam("@FileID", SqlDbType.Int,pFilesInfo.FileID));
            RunProcedure("[sp_FiLes_UpdateExisted]", colParam);
        }
        public void Update_Existed(FiLesInfo pFilesInfo)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@KichCoFile", SqlDbType.Float, pFilesInfo.KichCoFile));
            colParam.Add(CreateParam("@NguoiUpLoad", SqlDbType.NVarChar, pFilesInfo.NguoiUpLoad));
            colParam.Add(CreateParam("@NgayUpLoad", SqlDbType.DateTime, pFilesInfo.NgayUpLoad));
            colParam.Add(CreateParam("@Existed", SqlDbType.Bit, pFilesInfo.Existed));
            colParam.Add(CreateParam("@FileID", SqlDbType.Int, pFilesInfo.FileID));
            RunProcedure("[sp_FiLes_Update_Existed]", colParam);
        }
        public void Update_TrangThai(string strMaTrangThai,int intFileID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaTrangThai", SqlDbType.NVarChar, strMaTrangThai));
            colParam.Add(CreateParam("@FileID", SqlDbType.Int, intFileID));
            RunProcedure("[sp_FiLes_UpdateTrangThai]", colParam);
        }
        public void UpdateThuPhi(float fltGiaTien,int intSoTrang,int intFileID)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@GiaTien", SqlDbType.Float, fltGiaTien));
            colParam.Add(CreateParam("@SoTrang", SqlDbType.Int,intSoTrang));
            colParam.Add(CreateParam("@FileID", SqlDbType.Int,intFileID));
            RunProcedure("[sp_FiLes_Update_ThuPhi]", colParam);
        }
        public void Update_CapDoMat(int intCapDoMat,int intFileID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@CapDoMat", SqlDbType.Int, intCapDoMat));
            colParam.Add(CreateParam("@FileID", SqlDbType.Int, intFileID));
            RunProcedure("[sp_FiLes_UpdateCapDoMat]", colParam);
        }
        public void Update_ThuPhi(Boolean bnlThuPhi, int intFileID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ThuPhi", SqlDbType.Bit, bnlThuPhi));
            colParam.Add(CreateParam("@FileID", SqlDbType.Int, intFileID));
            RunProcedure("[sp_FiLes_UpdateThuPhi]", colParam);
        }
        public void Update_DuongDan(string strDuongDanCu,string strDuongDanMoi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@strOldLoc", SqlDbType.VarChar, strDuongDanCu));
            colParam.Add(CreateParam("@strNewLoc", SqlDbType.VarChar, strDuongDanMoi));
            colParam.Add(CreateParamOut("@intOutVal", SqlDbType.Int));
            RunProcedure("[sp_File_UpDaTe_DuongDan]", colParam);
        }
        public DataTable GetFileExisted(int intFileID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@FileID", SqlDbType.Int, intFileID));

            return RunProcedureGet("[sp_FiLes_GetFieleExisted]", colParam);
        }
    }
}
