using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDMaXepGia : cDBase
    {
        public DataTable Get(MaXepGiaInfo pMaXepGiaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pMaXepGiaInfo.MaXepGia));

            return RunProcedureGet("sp_MaXepGia_Get", colParam);            
        }

        public int Add(MaXepGiaInfo pMaXepGiaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pMaXepGiaInfo.MaXepGia));
            colParam.Add(CreateParam("@LuuThong",SqlDbType.Bit,pMaXepGiaInfo.LuuThong));
            colParam.Add(CreateParam("@DangMuon",SqlDbType.Bit,pMaXepGiaInfo.DangMuon));
            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pMaXepGiaInfo.IDTaiLieu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_MaXepGia_Add", colParam);
        }
        
        public void Update(MaXepGiaInfo pMaXepGiaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LuuThong",SqlDbType.Bit,pMaXepGiaInfo.LuuThong));
            colParam.Add(CreateParam("@DangMuon",SqlDbType.Bit,pMaXepGiaInfo.DangMuon));
            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pMaXepGiaInfo.IDTaiLieu));
            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pMaXepGiaInfo.MaXepGia));

            RunProcedure("sp_MaXepGia_Update", colParam);
        }
        
        public void Delete(MaXepGiaInfo pMaXepGiaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pMaXepGiaInfo.MaXepGia));

            RunProcedure("sp_MaXepGia_Delete", colParam);
        }
    }
}
