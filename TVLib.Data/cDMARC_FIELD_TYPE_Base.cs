using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDMARC_FIELD_TYPE : cDBase
    {
        public DataTable Get(MARC_FIELD_TYPEInfo pMARC_FIELD_TYPEInfo)
        {
            ArrayList colParam = new ArrayList();


            return RunProcedureGet("sp_MARC_FIELD_TYPE_Get", colParam);            
        }

        public int Add(MARC_FIELD_TYPEInfo pMARC_FIELD_TYPEInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ID",SqlDbType.Int,pMARC_FIELD_TYPEInfo.ID));
            colParam.Add(CreateParam("@FieldType",SqlDbType.NVarChar,pMARC_FIELD_TYPEInfo.FieldType));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_MARC_FIELD_TYPE_Add", colParam);
        }
        
        public void Update(MARC_FIELD_TYPEInfo pMARC_FIELD_TYPEInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ID",SqlDbType.Int,pMARC_FIELD_TYPEInfo.ID));
            colParam.Add(CreateParam("@FieldType",SqlDbType.NVarChar,pMARC_FIELD_TYPEInfo.FieldType));

            RunProcedure("sp_MARC_FIELD_TYPE_Update", colParam);
        }
        
        public void Delete(MARC_FIELD_TYPEInfo pMARC_FIELD_TYPEInfo)
        {
            ArrayList colParam = new ArrayList();


            RunProcedure("sp_MARC_FIELD_TYPE_Delete", colParam);
        }
    }
}
