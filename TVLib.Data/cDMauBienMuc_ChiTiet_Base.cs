using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDMauBienMuc_ChiTiet : cDBase
    {
        public DataTable Get(MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ID",SqlDbType.Int,pMauBienMuc_ChiTietInfo.ID));

            return RunProcedureGet("sp_MauBienMuc_ChiTiet_Get", colParam);            
        }

        public int Add(MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDMARC_FIELD",SqlDbType.Int,pMauBienMuc_ChiTietInfo.IDMARC_FIELD));
            colParam.Add(CreateParam("@GiaTriMacDinh",SqlDbType.NVarChar,pMauBienMuc_ChiTietInfo.GiaTriMacDinh));
            colParam.Add(CreateParam("@IDMauBienMuc",SqlDbType.Int,pMauBienMuc_ChiTietInfo.IDMauBienMuc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_MauBienMuc_ChiTiet_Add", colParam);
        }
        
        public void Update(MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDMARC_FIELD",SqlDbType.Int,pMauBienMuc_ChiTietInfo.IDMARC_FIELD));
            colParam.Add(CreateParam("@GiaTriMacDinh",SqlDbType.NVarChar,pMauBienMuc_ChiTietInfo.GiaTriMacDinh));
            colParam.Add(CreateParam("@IDMauBienMuc",SqlDbType.Int,pMauBienMuc_ChiTietInfo.IDMauBienMuc));
            colParam.Add(CreateParam("@ID",SqlDbType.Int,pMauBienMuc_ChiTietInfo.ID));

            RunProcedure("sp_MauBienMuc_ChiTiet_Update", colParam);
        }
        
        public void Delete(MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ID",SqlDbType.Int,pMauBienMuc_ChiTietInfo.ID));

            RunProcedure("sp_MauBienMuc_ChiTiet_Delete", colParam);
        }
    }
}
