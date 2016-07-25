using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDMARC_FIELD : cDBase
    {
        public DataTable Get(MARC_FIELDInfo pMARC_FIELDInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MARC_FIELD_ID",SqlDbType.Int,pMARC_FIELDInfo.MARC_FIELD_ID));

            return RunProcedureGet("sp_MARC_FIELD_Get", colParam);            
        }

        public int Add(MARC_FIELDInfo pMARC_FIELDInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MARC_FIELD_ID",SqlDbType.Int,pMARC_FIELDInfo.MARC_FIELD_ID));
            colParam.Add(CreateParam("@Name",SqlDbType.NVarChar,pMARC_FIELDInfo.Name));
            colParam.Add(CreateParam("@Code",SqlDbType.NVarChar,pMARC_FIELDInfo.Code));
            colParam.Add(CreateParam("@ID_MARC",SqlDbType.Int,pMARC_FIELDInfo.ID_MARC));
            colParam.Add(CreateParam("@Repeat",SqlDbType.Bit,pMARC_FIELDInfo.Repeat));
            colParam.Add(CreateParam("@ID_FieldType",SqlDbType.Int,pMARC_FIELDInfo.ID_FieldType));
            colParam.Add(CreateParam("@ParentID",SqlDbType.Int,pMARC_FIELDInfo.ParentID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_MARC_FIELD_Add", colParam);
        }
        
        public void Update(MARC_FIELDInfo pMARC_FIELDInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Name",SqlDbType.NVarChar,pMARC_FIELDInfo.Name));
            colParam.Add(CreateParam("@Code",SqlDbType.NVarChar,pMARC_FIELDInfo.Code));
            colParam.Add(CreateParam("@ID_MARC",SqlDbType.Int,pMARC_FIELDInfo.ID_MARC));
            colParam.Add(CreateParam("@Repeat",SqlDbType.Bit,pMARC_FIELDInfo.Repeat));
            colParam.Add(CreateParam("@ID_FieldType",SqlDbType.Int,pMARC_FIELDInfo.ID_FieldType));
            colParam.Add(CreateParam("@ParentID",SqlDbType.Int,pMARC_FIELDInfo.ParentID));
            colParam.Add(CreateParam("@MARC_FIELD_ID",SqlDbType.Int,pMARC_FIELDInfo.MARC_FIELD_ID));

            RunProcedure("sp_MARC_FIELD_Update", colParam);
        }
        
        public void Delete(MARC_FIELDInfo pMARC_FIELDInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MARC_FIELD_ID",SqlDbType.Int,pMARC_FIELDInfo.MARC_FIELD_ID));

            RunProcedure("sp_MARC_FIELD_Delete", colParam);
        }
    }
}
