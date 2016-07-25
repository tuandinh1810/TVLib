using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDBanDoc : cDBase
    {
    public DataTable GetBanDoc_GhiMuon(BanDocInfo pBanDocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoThe",SqlDbType.NVarChar,50,pBanDocInfo.SoThe));

            return RunProcedureGet("sp_BanDoc_GhiMuon", colParam);            
        }
    public DataTable GetBySoThe(string SoThe)
    {
        ArrayList colParam = new ArrayList();

        colParam.Add(CreateParam("@SoThe", SqlDbType.VarChar, SoThe));

        return RunProcedureGet("[sp_BanDoc_GetBySoThe]", colParam);
    }

    }
}
