using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDLichSuMuon : cDBase
    {
        public DataTable Get(LichSuMuonInfo pLichSuMuonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia", SqlDbType.VarChar, pLichSuMuonInfo.MaXepGia));
            return RunProcedureGet("sp_LichSuMuon_Get", colParam);            
        }

        public int Add(LichSuMuonInfo pLichSuMuonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pLichSuMuonInfo.MaXepGia));
            colParam.Add(CreateParam("@NgayMuon",SqlDbType.DateTime,pLichSuMuonInfo.NgayMuon));
            colParam.Add(CreateParam("@NgayTra",SqlDbType.DateTime,pLichSuMuonInfo.NgayTra));
            colParam.Add(CreateParam("@IDBanDoc",SqlDbType.Int,pLichSuMuonInfo.IDBanDoc));
            colParam.Add(CreateParam("@SoNgayQuaHan",SqlDbType.Int,pLichSuMuonInfo.SoNgayQuaHan));
            colParam.Add(CreateParam("@SoTienPhat",SqlDbType.Float,pLichSuMuonInfo.SoTienPhat));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_LichSuMuon_Add", colParam);
        }
        
        public void Update(LichSuMuonInfo pLichSuMuonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pLichSuMuonInfo.MaXepGia));
            colParam.Add(CreateParam("@NgayMuon",SqlDbType.DateTime,pLichSuMuonInfo.NgayMuon));
            colParam.Add(CreateParam("@NgayTra",SqlDbType.DateTime,pLichSuMuonInfo.NgayTra));
            colParam.Add(CreateParam("@IDBanDoc",SqlDbType.Int,pLichSuMuonInfo.IDBanDoc));
            colParam.Add(CreateParam("@SoNgayQuaHan",SqlDbType.Int,pLichSuMuonInfo.SoNgayQuaHan));
            colParam.Add(CreateParam("@SoTienPhat",SqlDbType.Float,pLichSuMuonInfo.SoTienPhat));

            RunProcedure("sp_LichSuMuon_Update", colParam);
        }
        
        public void Delete(LichSuMuonInfo pLichSuMuonInfo)
        {
            ArrayList colParam = new ArrayList();


            RunProcedure("sp_LichSuMuon_Delete", colParam);
        }
    }
}
