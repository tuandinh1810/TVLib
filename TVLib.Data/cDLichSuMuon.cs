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
        public DataTable Search(int IDBanDoc, string SoThe, string TuNgayMuon, string DenNgayMuon, string MaXepGia, string TuNgayTra, string DenNgayTra)
        {
            ArrayList colParam = new ArrayList();

          //  colParam.Add(CreateParam("@MaXepGia", SqlDbType.VarChar, MaXepGia));
           // colParam.Add(CreateParam("@NgayMuon", SqlDbType.DateTime, pLichSuMuonInfo.NgayMuon));
           // colParam.Add(CreateParam("@NgayTra", SqlDbType.DateTime, pLichSuMuonInfo.NgayTra));
            colParam.Add(CreateParam("@IDBanDoc", SqlDbType.Int, IDBanDoc));
          //  colParam.Add(CreateParam("@SoNgayQuaHan", SqlDbType.Int, pLichSuMuonInfo.SoNgayQuaHan));
          //  colParam.Add(CreateParam("@SoTienPhat", SqlDbType.Float, pLichSuMuonInfo.SoTienPhat));
          //  colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureGet("sp_LichSuMuon_Search", colParam);
        }
    }
}
