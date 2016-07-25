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
        public DataTable Get(TemplateInfo pTemplateInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TemplateID",SqlDbType.Int,pTemplateInfo.TemplateID));

            return RunProcedureGet("sp_Template_Get", colParam);            
        }

        public int Add(TemplateInfo pTemplateInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTemplate",SqlDbType.NVarChar,pTemplateInfo.TenTemplate));
            colParam.Add(CreateParam("@GiaTri",SqlDbType.NText,pTemplateInfo.GiaTri));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_Template_Add", colParam);
        }
        
        public void Update(TemplateInfo pTemplateInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTemplate",SqlDbType.NVarChar,pTemplateInfo.TenTemplate));
            colParam.Add(CreateParam("@GiaTri",SqlDbType.NText,pTemplateInfo.GiaTri));
            colParam.Add(CreateParam("@TemplateID",SqlDbType.Int,pTemplateInfo.TemplateID));

            RunProcedure("sp_Template_Update", colParam);
        }
        
        public void Delete(TemplateInfo pTemplateInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TemplateID",SqlDbType.Int,pTemplateInfo.TemplateID));

            RunProcedure("sp_Template_Delete", colParam);
        }
    }
}
