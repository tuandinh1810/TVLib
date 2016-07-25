using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDFile_TruongDublin : cDBase
    {
        public DataTable RunSql(string strSql)
        {
            return RunSQLGet(strSql);
        }
    }
}
