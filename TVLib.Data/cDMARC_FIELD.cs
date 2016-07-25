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
        public DataTable Get_ByMARC(int IDMARC)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@IDMARC", SqlDbType.Int, IDMARC));

            return RunProcedureGet("sp_MARC_Field_Get_ByMARC", colParam);
        }
        public DataTable Get_ByParent(int IDParent)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@IDParent", SqlDbType.Int, IDParent));

            return RunProcedureGet("sp_MARC_Field_Get_ByParent", colParam);
        }
    }
}
