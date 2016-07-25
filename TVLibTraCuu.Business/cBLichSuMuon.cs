using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBLichSuMuon : cBBase
    {
        private cDLichSuMuon oDLichSuMuon;
        private LichSuMuonInfo oLichSuMuonInfo;

        public cBLichSuMuon()        
        {
            oDLichSuMuon = new cDLichSuMuon();
        }

        public DataTable Get(LichSuMuonInfo pLichSuMuonInfo)        
        {
            return oDLichSuMuon.Get(pLichSuMuonInfo);
        }

        public int Add(LichSuMuonInfo pLichSuMuonInfo)
        {
			int ID = 0;
            ID = oDLichSuMuon.Add(pLichSuMuonInfo);
            mErrorMessage = oDLichSuMuon.ErrorMessages;
            mErrorNumber = oDLichSuMuon.ErrorNumber;
            return ID;
        }

        public void Update(LichSuMuonInfo pLichSuMuonInfo)
        {
            oDLichSuMuon.Update(pLichSuMuonInfo);
            mErrorMessage = oDLichSuMuon.ErrorMessages;
            mErrorNumber = oDLichSuMuon.ErrorNumber;
        }
        
        public void Delete(LichSuMuonInfo pLichSuMuonInfo)
        {
            oDLichSuMuon.Delete(pLichSuMuonInfo);
            mErrorMessage = oDLichSuMuon.ErrorMessages;
            mErrorNumber = oDLichSuMuon.ErrorNumber;
        }

        public List<LichSuMuonInfo> GetList(LichSuMuonInfo pLichSuMuonInfo)
        {
            List<LichSuMuonInfo> oLichSuMuonInfoList = new List<LichSuMuonInfo>();
            DataTable dtb = Get(pLichSuMuonInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oLichSuMuonInfo = new LichSuMuonInfo();
                    

                    oLichSuMuonInfo.MaXepGia = dtb.Rows[i]["MaXepGia"].ToString();
                    oLichSuMuonInfo.NgayMuon = DateTime.Parse(dtb.Rows[i]["NgayMuon"].ToString());
                    oLichSuMuonInfo.NgayTra = DateTime.Parse(dtb.Rows[i]["NgayTra"].ToString());
                    oLichSuMuonInfo.IDBanDoc = int.Parse(dtb.Rows[i]["IDBanDoc"].ToString());
                    oLichSuMuonInfo.SoNgayQuaHan = int.Parse(dtb.Rows[i]["SoNgayQuaHan"].ToString());
                    oLichSuMuonInfo.SoTienPhat = float.Parse(dtb.Rows[i]["SoTienPhat"].ToString());
                    
                    oLichSuMuonInfoList.Add(oLichSuMuonInfo);
                }
            }
            return oLichSuMuonInfoList.Count == 0 ? null : oLichSuMuonInfoList;
        }
    }
}
