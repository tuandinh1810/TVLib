using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDYeuCauMuon : cDBase
    {
        public DataTable Get(YeuCauMuonInfo pYeuCauMuonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@YeuCauMuonID",SqlDbType.Int,pYeuCauMuonInfo.YeuCauMuonID));

            return RunProcedureGet("sp_YeuCauMuon_Get", colParam);            
        }

        public int Add(YeuCauMuonInfo pYeuCauMuonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDBanDoc",SqlDbType.Int,pYeuCauMuonInfo.IDBanDoc));
            colParam.Add(CreateParam("@NgayYeuCau",SqlDbType.DateTime,pYeuCauMuonInfo.NgayYeuCau));
            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pYeuCauMuonInfo.IDTaiLieu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_YeuCauMuon_Add", colParam);
        }
        
        public void Update(YeuCauMuonInfo pYeuCauMuonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDBanDoc",SqlDbType.Int,pYeuCauMuonInfo.IDBanDoc));
            colParam.Add(CreateParam("@NgayYeuCau",SqlDbType.DateTime,pYeuCauMuonInfo.NgayYeuCau));
            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pYeuCauMuonInfo.IDTaiLieu));
            colParam.Add(CreateParam("@YeuCauMuonID",SqlDbType.Int,pYeuCauMuonInfo.YeuCauMuonID));

            RunProcedure("sp_YeuCauMuon_Update", colParam);
        }
        
        public void Delete(YeuCauMuonInfo pYeuCauMuonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@YeuCauMuonID",SqlDbType.Int,pYeuCauMuonInfo.YeuCauMuonID));

            RunProcedure("sp_YeuCauMuon_Delete", colParam);
        }
    }
}
