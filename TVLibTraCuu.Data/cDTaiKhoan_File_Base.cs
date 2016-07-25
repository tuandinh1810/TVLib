using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDTaiKhoan_File : cDBase
    {
        public DataTable Get(TaiKhoan_FileInfo pTaiKhoan_FileInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiKhoanFileID",SqlDbType.Int,pTaiKhoan_FileInfo.TaiKhoanFileID));

            return RunProcedureGet("sp_TaiKhoan_File_Get", colParam);            
        }

        public int Add(TaiKhoan_FileInfo pTaiKhoan_FileInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiKhoan",SqlDbType.Int,pTaiKhoan_FileInfo.IDTaiKhoan));
            colParam.Add(CreateParam("@IDFile",SqlDbType.Int,pTaiKhoan_FileInfo.IDFile));
            colParam.Add(CreateParam("@NgayDowloadFile",SqlDbType.DateTime,pTaiKhoan_FileInfo.NgayDowloadFile));
            colParam.Add(CreateParam("@ChiPhi",SqlDbType.Money,pTaiKhoan_FileInfo.ChiPhi));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TaiKhoan_File_Add", colParam);
        }
        
        public void Update(TaiKhoan_FileInfo pTaiKhoan_FileInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiKhoan",SqlDbType.Int,pTaiKhoan_FileInfo.IDTaiKhoan));
            colParam.Add(CreateParam("@IDFile",SqlDbType.Int,pTaiKhoan_FileInfo.IDFile));
            colParam.Add(CreateParam("@NgayDowloadFile",SqlDbType.DateTime,pTaiKhoan_FileInfo.NgayDowloadFile));
            colParam.Add(CreateParam("@ChiPhi",SqlDbType.Money,pTaiKhoan_FileInfo.ChiPhi));
            colParam.Add(CreateParam("@TaiKhoanFileID",SqlDbType.Int,pTaiKhoan_FileInfo.TaiKhoanFileID));

            RunProcedure("sp_TaiKhoan_File_Update", colParam);
        }
        
        public void Delete(TaiKhoan_FileInfo pTaiKhoan_FileInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiKhoanFileID",SqlDbType.Int,pTaiKhoan_FileInfo.TaiKhoanFileID));

            RunProcedure("sp_TaiKhoan_File_Delete", colParam);
        }
    }
}
