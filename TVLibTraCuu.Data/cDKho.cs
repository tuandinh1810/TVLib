using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDKho : cDBase
    {
        public void GopKho(KhoInfo pKhoInfo, int intKhoIDGop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KhoID", SqlDbType.Int, pKhoInfo.KhoID));
            colParam.Add(CreateParam("@KhoIDGop", SqlDbType.Int, intKhoIDGop));

            RunProcedure("sp_Kho_Gop", colParam);
        }
        public DataTable  GetByThuVien(KhoInfo pKhoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDThuVien", SqlDbType.Int, pKhoInfo.IDThuVien ));
         
            return RunProcedureGet("sp_Kho_GetByThuVien", colParam);
        }
    }
}
