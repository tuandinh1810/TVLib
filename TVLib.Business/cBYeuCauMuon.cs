using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBYeuCauMuon : cBBase
    {
        private cDYeuCauMuon oDYeuCauMuon;

        public cBYeuCauMuon()        
        {
            oDYeuCauMuon = new cDYeuCauMuon();
        }
        public DataTable GetByThoiDiem(DateTime TuNgay, DateTime DenNgay, string SoThe)
        {
            return oDYeuCauMuon.GetByThoiDiem(TuNgay, DenNgay, SoThe);
        }
        public DataTable Get(YeuCauMuonInfo pYeuCauMuonInfo)        
        {
            return oDYeuCauMuon.Get(pYeuCauMuonInfo);
        }

        public int Add(YeuCauMuonInfo pYeuCauMuonInfo)
        {
			int ID = 0;
            ID = oDYeuCauMuon.Add(pYeuCauMuonInfo);
            mErrorMessage = oDYeuCauMuon.ErrorMessages;
            mErrorNumber = oDYeuCauMuon.ErrorNumber;
            return ID;
        }

        public void Update(YeuCauMuonInfo pYeuCauMuonInfo)
        {
            oDYeuCauMuon.Update(pYeuCauMuonInfo);
            mErrorMessage = oDYeuCauMuon.ErrorMessages;
            mErrorNumber = oDYeuCauMuon.ErrorNumber;
        }
        
        public void Delete(YeuCauMuonInfo pYeuCauMuonInfo)
        {
            oDYeuCauMuon.Delete(pYeuCauMuonInfo);
            mErrorMessage = oDYeuCauMuon.ErrorMessages;
            mErrorNumber = oDYeuCauMuon.ErrorNumber;
        }

        public List<YeuCauMuonInfo> GetList(YeuCauMuonInfo pYeuCauMuonInfo)
        {
            List<YeuCauMuonInfo> oYeuCauMuonInfoList = new List<YeuCauMuonInfo>();
            DataTable dtb = Get(pYeuCauMuonInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pYeuCauMuonInfo = new YeuCauMuonInfo();

                    pYeuCauMuonInfo.YeuCauMuonID = int.Parse(dtb.Rows[i][pYeuCauMuonInfo.strYeuCauMuonID].ToString());
                    if("" + dtb.Rows[i][pYeuCauMuonInfo.strIDBanDoc] != "")
                    	pYeuCauMuonInfo.IDBanDoc = int.Parse(dtb.Rows[i][pYeuCauMuonInfo.strIDBanDoc].ToString());
                    if("" + dtb.Rows[i][pYeuCauMuonInfo.strNgayYeuCau] != "")
                    	pYeuCauMuonInfo.NgayYeuCau = DateTime.Parse(dtb.Rows[i][pYeuCauMuonInfo.strNgayYeuCau].ToString());
                    if("" + dtb.Rows[i][pYeuCauMuonInfo.strIDTaiLieu] != "")
                    	pYeuCauMuonInfo.IDTaiLieu = int.Parse(dtb.Rows[i][pYeuCauMuonInfo.strIDTaiLieu].ToString());
                    
                    oYeuCauMuonInfoList.Add(pYeuCauMuonInfo);
                }
            }
            return oYeuCauMuonInfoList;
        }
        
        public void ToDataRow(YeuCauMuonInfo pYeuCauMuonInfo, ref DataRow dr)
        {

			dr[pYeuCauMuonInfo.strYeuCauMuonID] = pYeuCauMuonInfo.YeuCauMuonID;
			dr[pYeuCauMuonInfo.strIDBanDoc] = pYeuCauMuonInfo.IDBanDoc;
			dr[pYeuCauMuonInfo.strNgayYeuCau] = pYeuCauMuonInfo.NgayYeuCau;
			dr[pYeuCauMuonInfo.strIDTaiLieu] = pYeuCauMuonInfo.IDTaiLieu;
        }
        
        public void ToInfo(ref YeuCauMuonInfo pYeuCauMuonInfo, DataRow dr)
        {

			pYeuCauMuonInfo.YeuCauMuonID = int.Parse(dr[pYeuCauMuonInfo.strYeuCauMuonID].ToString());
			if("" + dr[pYeuCauMuonInfo.strIDBanDoc] != "")
				pYeuCauMuonInfo.IDBanDoc = int.Parse(dr[pYeuCauMuonInfo.strIDBanDoc].ToString());
			if("" + dr[pYeuCauMuonInfo.strNgayYeuCau] != "")
				pYeuCauMuonInfo.NgayYeuCau = DateTime.Parse(dr[pYeuCauMuonInfo.strNgayYeuCau].ToString());
			if("" + dr[pYeuCauMuonInfo.strIDTaiLieu] != "")
				pYeuCauMuonInfo.IDTaiLieu = int.Parse(dr[pYeuCauMuonInfo.strIDTaiLieu].ToString());
        }
    }
}
