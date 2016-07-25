using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDNhatKyHeThong : cDBase
    {
        public void SetLogMode(int IDPhanHe, string ChucNangIDs)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDPhanHe", SqlDbType.Int, IDPhanHe ));
            colParam.Add(CreateParam("@ChucNangIDs", SqlDbType.VarChar, 1000, ChucNangIDs));

            RunProcedure("sp_Log_SetLogMode", colParam); 
        }
    }
}
