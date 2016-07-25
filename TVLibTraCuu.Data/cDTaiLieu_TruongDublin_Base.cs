using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDTaiLieu_TruongDublin : cDBase
    {
        public DataTable Get(TaiLieu_TruongDublinInfo pTaiLieu_TruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiLieu_TruongDublin_ID",SqlDbType.Int,pTaiLieu_TruongDublinInfo.TaiLieu_TruongDublin_ID));

            return RunProcedureGet("sp_TaiLieu_TruongDublin_Get", colParam);            
        }

        public int Add(TaiLieu_TruongDublinInfo pTaiLieu_TruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pTaiLieu_TruongDublinInfo.IDTaiLieu));
            colParam.Add(CreateParam("@IDTruongDublin",SqlDbType.Int,pTaiLieu_TruongDublinInfo.IDTruongDublin));
            colParam.Add(CreateParam("@DisplayEntry",SqlDbType.NVarChar,pTaiLieu_TruongDublinInfo.DisplayEntry));
            colParam.Add(CreateParam("@AccessEntry",SqlDbType.NVarChar,pTaiLieu_TruongDublinInfo.AccessEntry));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TaiLieu_TruongDublin_Add", colParam);
        }
        
        public void Update(TaiLieu_TruongDublinInfo pTaiLieu_TruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pTaiLieu_TruongDublinInfo.IDTaiLieu));
            colParam.Add(CreateParam("@IDTruongDublin",SqlDbType.Int,pTaiLieu_TruongDublinInfo.IDTruongDublin));
            colParam.Add(CreateParam("@DisplayEntry",SqlDbType.NVarChar,pTaiLieu_TruongDublinInfo.DisplayEntry));
            colParam.Add(CreateParam("@AccessEntry",SqlDbType.NVarChar,pTaiLieu_TruongDublinInfo.AccessEntry));
            colParam.Add(CreateParam("@TaiLieu_TruongDublin_ID",SqlDbType.Int,pTaiLieu_TruongDublinInfo.TaiLieu_TruongDublin_ID));

            RunProcedure("sp_TaiLieu_TruongDublin_Update", colParam);
        }
        
        public void Delete(TaiLieu_TruongDublinInfo pTaiLieu_TruongDublinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiLieu_TruongDublin_ID",SqlDbType.Int,pTaiLieu_TruongDublinInfo.TaiLieu_TruongDublin_ID));

            RunProcedure("sp_TaiLieu_TruongDublin_Delete", colParam);
        }
    }
}
