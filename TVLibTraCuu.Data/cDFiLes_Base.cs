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
        public DataTable Get(FiLesInfo pFiLesInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@FileID",SqlDbType.Int,pFiLesInfo.FileID));

            return RunProcedureGet("sp_FiLes_Get", colParam);            
        }

        public int Add(FiLesInfo pFiLesInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KichCoFile",SqlDbType.Int,pFiLesInfo.KichCoFile));
            colParam.Add(CreateParam("@NgayUpLoad",SqlDbType.DateTime,pFiLesInfo.NgayUpLoad));
            colParam.Add(CreateParam("@NguoiUpLoad",SqlDbType.NVarChar,pFiLesInfo.NguoiUpLoad));
            colParam.Add(CreateParam("@TenFile",SqlDbType.NVarChar,pFiLesInfo.TenFile));
            colParam.Add(CreateParam("@DangFile",SqlDbType.VarChar,pFiLesInfo.DangFile));
            colParam.Add(CreateParam("@MaTrangThai",SqlDbType.VarChar,pFiLesInfo.MaTrangThai));
            colParam.Add(CreateParam("@Existed",SqlDbType.Bit,pFiLesInfo.Existed));
            colParam.Add(CreateParam("@ThuPhi",SqlDbType.Bit,pFiLesInfo.ThuPhi));
            colParam.Add(CreateParam("@GiaTien",SqlDbType.Money,pFiLesInfo.GiaTien));
            colParam.Add(CreateParam("@SoTrang",SqlDbType.Int,pFiLesInfo.SoTrang));
            colParam.Add(CreateParam("@DuongDanVatLy",SqlDbType.NVarChar,pFiLesInfo.DuongDanVatLy));
            colParam.Add(CreateParam("@SoLanDownLoad",SqlDbType.Int,pFiLesInfo.SoLanDownLoad));
            colParam.Add(CreateParam("@CapDoMat",SqlDbType.Int,pFiLesInfo.CapDoMat));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_FiLes_Add", colParam);
        }
        
        public void Update(FiLesInfo pFiLesInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KichCoFile",SqlDbType.Int,pFiLesInfo.KichCoFile));
            colParam.Add(CreateParam("@NgayUpLoad",SqlDbType.DateTime,pFiLesInfo.NgayUpLoad));
            colParam.Add(CreateParam("@NguoiUpLoad",SqlDbType.NVarChar,pFiLesInfo.NguoiUpLoad));
            colParam.Add(CreateParam("@TenFile",SqlDbType.NVarChar,pFiLesInfo.TenFile));
            colParam.Add(CreateParam("@DangFile",SqlDbType.VarChar,pFiLesInfo.DangFile));
            colParam.Add(CreateParam("@MaTrangThai",SqlDbType.VarChar,pFiLesInfo.MaTrangThai));
            colParam.Add(CreateParam("@Existed",SqlDbType.Bit,pFiLesInfo.Existed));
            colParam.Add(CreateParam("@ThuPhi",SqlDbType.Bit,pFiLesInfo.ThuPhi));
            colParam.Add(CreateParam("@GiaTien",SqlDbType.Money,pFiLesInfo.GiaTien));
            colParam.Add(CreateParam("@SoTrang",SqlDbType.Int,pFiLesInfo.SoTrang));
            colParam.Add(CreateParam("@DuongDanVatLy",SqlDbType.NVarChar,pFiLesInfo.DuongDanVatLy));
            colParam.Add(CreateParam("@SoLanDownLoad",SqlDbType.Int,pFiLesInfo.SoLanDownLoad));
            colParam.Add(CreateParam("@CapDoMat",SqlDbType.Int,pFiLesInfo.CapDoMat));
            colParam.Add(CreateParam("@FileID",SqlDbType.Int,pFiLesInfo.FileID));

            RunProcedure("sp_FiLes_Update", colParam);
        }
        
        public void Delete(FiLesInfo pFiLesInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@FileID",SqlDbType.Int,pFiLesInfo.FileID));

            RunProcedure("sp_FiLes_Delete", colParam);
        }
    }
}
