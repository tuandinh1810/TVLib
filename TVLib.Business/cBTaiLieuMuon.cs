using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBTaiLieuMuon : cBBase
    {
        private cDTaiLieuMuon oDTaiLieuMuon;
        private TaiLieuMuonInfo oTaiLieuMuonInfo;

        public cBTaiLieuMuon()        
        {
            oDTaiLieuMuon = new cDTaiLieuMuon();
        }
        public DataTable Search(int IDBanDoc, string SoThe, string TuNgayMuon, string DenNgayMuon, string MaXepGia, string TuNgayTra, string DenNgayTra)
        {
            return oDTaiLieuMuon.Search(IDBanDoc, SoThe, TuNgayMuon, DenNgayMuon, MaXepGia, TuNgayTra, DenNgayTra);
        }
        public DataTable Get(TaiLieuMuonInfo pTaiLieuMuonInfo)        
        {
            return oDTaiLieuMuon.Get(pTaiLieuMuonInfo);
        }
        public DataTable GetMuonSachBySoThe(string strSoThe)
        {
            return oDTaiLieuMuon.GetMuonSachBySoThe(strSoThe);
        }
        public DataTable GetMuonSachByBanDocID(int BanDocID)
        {
            return oDTaiLieuMuon.GetMuonSachByBanDocID(BanDocID);
        }
        public DataTable UpdateGiaHan(string TaiLieuMuonIDs, DateTime dtNgayGiaHan)
        {
            return oDTaiLieuMuon.UpdateGiaHan(TaiLieuMuonIDs, dtNgayGiaHan);
        }
        public DataTable GetByChuoiMaXepGia(string strMaXepGia)
        {
            return oDTaiLieuMuon.GetByChuoiMaXepGia(strMaXepGia);
        }
        public int Add(TaiLieuMuonInfo pTaiLieuMuonInfo)
        {
			int ID = 0;
            ID = oDTaiLieuMuon.Add(pTaiLieuMuonInfo);
            mErrorMessage = oDTaiLieuMuon.ErrorMessages;
            mErrorNumber = oDTaiLieuMuon.ErrorNumber;
            return ID;
        }

        public void Update(TaiLieuMuonInfo pTaiLieuMuonInfo)
        {
            oDTaiLieuMuon.Update(pTaiLieuMuonInfo);
            mErrorMessage = oDTaiLieuMuon.ErrorMessages;
            mErrorNumber = oDTaiLieuMuon.ErrorNumber;
        }

        public void Delete(TaiLieuMuonInfo pTaiLieuMuonInfo)
        {
            oDTaiLieuMuon.Delete(pTaiLieuMuonInfo);
            mErrorMessage = oDTaiLieuMuon.ErrorMessages;
            mErrorNumber = oDTaiLieuMuon.ErrorNumber;
        }

        public int  GhiTra(string strMaxepgia, float TienPhat, int Type)
        {
            int ID = 0;
            ID = oDTaiLieuMuon.GhiTra(strMaxepgia,TienPhat,Type);
            mErrorMessage = oDTaiLieuMuon.ErrorMessages;
            mErrorNumber = oDTaiLieuMuon.ErrorNumber;
            return ID;
        }

        public List<TaiLieuMuonInfo> GetList(TaiLieuMuonInfo pTaiLieuMuonInfo)
        {
            List<TaiLieuMuonInfo> oTaiLieuMuonInfoList = new List<TaiLieuMuonInfo>();
            DataTable dtb = Get(pTaiLieuMuonInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTaiLieuMuonInfo = new TaiLieuMuonInfo();
                    

                    oTaiLieuMuonInfo.MaXepGia = dtb.Rows[i]["MaXepGia"].ToString();
                    oTaiLieuMuonInfo.NgayMuon = DateTime.Parse(dtb.Rows[i]["NgayMuon"].ToString());
                    oTaiLieuMuonInfo.NgayPhaiTra = DateTime.Parse(dtb.Rows[i]["NgayPhaiTra"].ToString());
                    oTaiLieuMuonInfo.IDBanDoc = int.Parse(dtb.Rows[i]["IDBanDoc"].ToString());
                    
                    oTaiLieuMuonInfoList.Add(oTaiLieuMuonInfo);
                }
            }
            return oTaiLieuMuonInfoList.Count == 0 ? null : oTaiLieuMuonInfoList;
        }
    }
}
