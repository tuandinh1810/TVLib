using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDTaiLieu_MarcField : cDBase
    {
        public DataTable Get(TaiLieu_MarcFieldInfo pTaiLieu_MarcFieldInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiLieu_MarcFieldID",SqlDbType.Int,pTaiLieu_MarcFieldInfo.TaiLieu_MarcFieldID));

            return RunProcedureGet("sp_TaiLieu_MarcField_Get", colParam);            
        }

        public int Add(TaiLieu_MarcFieldInfo pTaiLieu_MarcFieldInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pTaiLieu_MarcFieldInfo.IDTaiLieu));
            colParam.Add(CreateParam("@IDMarcField", SqlDbType.Int, pTaiLieu_MarcFieldInfo.IDMarcField));
            colParam.Add(CreateParam("@DisplayEntry",SqlDbType.NVarChar,pTaiLieu_MarcFieldInfo.DisplayEntry));
            colParam.Add(CreateParam("@AccessEntry",SqlDbType.NVarChar,pTaiLieu_MarcFieldInfo.AccessEntry));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TaiLieu_MarcField_Add", colParam);
        }
        
        public void Update(TaiLieu_MarcFieldInfo pTaiLieu_MarcFieldInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pTaiLieu_MarcFieldInfo.IDTaiLieu));
            colParam.Add(CreateParam("@IDMarcField", SqlDbType.Int, pTaiLieu_MarcFieldInfo.IDMarcField));
            colParam.Add(CreateParam("@DisplayEntry",SqlDbType.NVarChar,pTaiLieu_MarcFieldInfo.DisplayEntry));
            colParam.Add(CreateParam("@AccessEntry",SqlDbType.NVarChar,pTaiLieu_MarcFieldInfo.AccessEntry));
            colParam.Add(CreateParam("@TaiLieu_MarcFieldID",SqlDbType.Int,pTaiLieu_MarcFieldInfo.TaiLieu_MarcFieldID));

            RunProcedure("sp_TaiLieu_MarcField_Update", colParam);
        }
        
        public void Delete(TaiLieu_MarcFieldInfo pTaiLieu_MarcFieldInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiLieu_MarcFieldID",SqlDbType.Int,pTaiLieu_MarcFieldInfo.TaiLieu_MarcFieldID));

            RunProcedure("sp_TaiLieu_MarcField_Delete", colParam);
        }
    }
}
