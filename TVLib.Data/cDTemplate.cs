using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDTemplate : cDBase
    {
        public DataTable GetTemplateByTenTemp(string strTenTemp)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTemplate", SqlDbType.NVarChar, strTenTemp));
            return RunProcedureGet("[sp_Template_GetByTenTemp]", colParam);
        }

    }
}
