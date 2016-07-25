using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDTaiLieuMuon : cDBase
    {
        public DataTable Get(TaiLieuMuonInfo pTaiLieuMuonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pTaiLieuMuonInfo.MaXepGia));

            return RunProcedureGet("sp_TaiLieuMuon_Get", colParam);            
        }

        public int Add(TaiLieuMuonInfo pTaiLieuMuonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pTaiLieuMuonInfo.MaXepGia));
            colParam.Add(CreateParam("@NgayMuon",SqlDbType.DateTime,pTaiLieuMuonInfo.NgayMuon));
            colParam.Add(CreateParam("@NgayPhaiTra",SqlDbType.DateTime,pTaiLieuMuonInfo.NgayPhaiTra));
            colParam.Add(CreateParam("@IDBanDoc",SqlDbType.Int,pTaiLieuMuonInfo.IDBanDoc));
            colParam.Add(CreateParam("@PhiMuon", SqlDbType.Float, pTaiLieuMuonInfo.PhiMuon));
            colParam.Add(CreateParam("@SoLanGiaHan", SqlDbType.Int, pTaiLieuMuonInfo.SoLanGiaHan));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TaiLieuMuon_Add", colParam);
        }
        
        public void Update(TaiLieuMuonInfo pTaiLieuMuonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NgayMuon",SqlDbType.DateTime,pTaiLieuMuonInfo.NgayMuon));
            colParam.Add(CreateParam("@NgayPhaiTra",SqlDbType.DateTime,pTaiLieuMuonInfo.NgayPhaiTra));
            colParam.Add(CreateParam("@IDBanDoc",SqlDbType.Int,pTaiLieuMuonInfo.IDBanDoc));
            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pTaiLieuMuonInfo.MaXepGia));
            colParam.Add(CreateParam("@PhiMuon", SqlDbType.Float, pTaiLieuMuonInfo.IDBanDoc));
            colParam.Add(CreateParam("@SoLanGiaHan", SqlDbType.Int, pTaiLieuMuonInfo.IDBanDoc));

            RunProcedure("sp_TaiLieuMuon_Update", colParam);
        }
        
        public void Delete(TaiLieuMuonInfo pTaiLieuMuonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pTaiLieuMuonInfo.MaXepGia));

            RunProcedure("sp_TaiLieuMuon_Delete", colParam);
        }
    }
}
