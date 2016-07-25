using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDNhomBanDoc : cDBase
    {
        public DataTable Get(NhomBanDocInfo pNhomBanDocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NhomBanDocID",SqlDbType.Int,pNhomBanDocInfo.NhomBanDocID));

            return RunProcedureGet("sp_NhomBanDoc_Get", colParam);            
        }

        public int Add(NhomBanDocInfo pNhomBanDocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNhomBanDoc",SqlDbType.NVarChar,pNhomBanDocInfo.TenNhomBanDoc));
            colParam.Add(CreateParam("@SoSachMuon",SqlDbType.Int,pNhomBanDocInfo.SoSachMuon));
            colParam.Add(CreateParam("@SoSachDatCho",SqlDbType.Int,pNhomBanDocInfo.SoSachDatCho));
            colParam.Add(CreateParam("@CacKhoDuocMuon",SqlDbType.NVarChar,pNhomBanDocInfo.CacKhoDuocMuon));
            colParam.Add(CreateParam("@CapDoMat", SqlDbType.Int, pNhomBanDocInfo.CapDoMat));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_NhomBanDoc_Add", colParam);
        }
        
        public int Update(NhomBanDocInfo pNhomBanDocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNhomBanDoc",SqlDbType.NVarChar,pNhomBanDocInfo.TenNhomBanDoc));
            colParam.Add(CreateParam("@SoSachMuon",SqlDbType.Int,pNhomBanDocInfo.SoSachMuon));
            colParam.Add(CreateParam("@SoSachDatCho",SqlDbType.Int,pNhomBanDocInfo.SoSachDatCho));
            colParam.Add(CreateParam("@CacKhoDuocMuon",SqlDbType.NVarChar,pNhomBanDocInfo.CacKhoDuocMuon));
            colParam.Add(CreateParam("@NhomBanDocID",SqlDbType.Int,pNhomBanDocInfo.NhomBanDocID));
            colParam.Add(CreateParam("@CapDoMat", SqlDbType.Int, pNhomBanDocInfo.CapDoMat));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

           return  RunProcedureOut("sp_NhomBanDoc_Update", colParam);
        }
        
        public int  Delete(NhomBanDocInfo pNhomBanDocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NhomBanDocID",SqlDbType.Int,pNhomBanDocInfo.NhomBanDocID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return   RunProcedureOut("sp_NhomBanDoc_Delete", colParam);
        }
    }
}
