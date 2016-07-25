using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBSoTapChi : cBBase
    {
        private cDSoTapChi oDSoTapChi;

        public cBSoTapChi()        
        {
            oDSoTapChi = new cDSoTapChi();
        }

        public DataTable Get(SoTapChiInfo pSoTapChiInfo)        
        {
            return oDSoTapChi.Get(pSoTapChiInfo);
        }

        public DataTable GetByTaiLieuID_NamPhatHanh(int pTaiLieuID)
        {
            return oDSoTapChi.GetByTaiLieuID_NamPhatHanh(pTaiLieuID);
        }

        public int Add(SoTapChiInfo pSoTapChiInfo)
        {
			int ID = 0;
            ID = oDSoTapChi.Add(pSoTapChiInfo);
            mErrorMessage = oDSoTapChi.ErrorMessages;
            mErrorNumber = oDSoTapChi.ErrorNumber;
            return ID;
        }

        public void Update(SoTapChiInfo pSoTapChiInfo)
        {
            oDSoTapChi.Update(pSoTapChiInfo);
            mErrorMessage = oDSoTapChi.ErrorMessages;
            mErrorNumber = oDSoTapChi.ErrorNumber;
        }
        
        public void Delete(SoTapChiInfo pSoTapChiInfo)
        {
            oDSoTapChi.Delete(pSoTapChiInfo);
            mErrorMessage = oDSoTapChi.ErrorMessages;
            mErrorNumber = oDSoTapChi.ErrorNumber;
        }

        public List<SoTapChiInfo> GetList(SoTapChiInfo pSoTapChiInfo)
        {
            List<SoTapChiInfo> oSoTapChiInfoList = new List<SoTapChiInfo>();
            DataTable dtb = Get(pSoTapChiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pSoTapChiInfo = new SoTapChiInfo();

                    pSoTapChiInfo.SoTapChiID = int.Parse(dtb.Rows[i][pSoTapChiInfo.strSoTapChiID].ToString());
                    pSoTapChiInfo.IDTaiLieu = int.Parse(dtb.Rows[i][pSoTapChiInfo.strIDTaiLieu].ToString());
                    pSoTapChiInfo.NamPhatHanh = dtb.Rows[i][pSoTapChiInfo.strNamPhatHanh].ToString();
                    pSoTapChiInfo.SoTheoNam = dtb.Rows[i][pSoTapChiInfo.strSoTheoNam].ToString();
                    if("" + dtb.Rows[i][pSoTapChiInfo.strSoToanCuc] != "")
                    	pSoTapChiInfo.SoToanCuc = dtb.Rows[i][pSoTapChiInfo.strSoToanCuc].ToString();
                    pSoTapChiInfo.NgayPhatHanh = DateTime.Parse(dtb.Rows[i][pSoTapChiInfo.strNgayPhatHanh].ToString());
                    if("" + dtb.Rows[i][pSoTapChiInfo.strDonGia] != "")
                    	pSoTapChiInfo.DonGia = double.Parse(dtb.Rows[i][pSoTapChiInfo.strDonGia].ToString());
                    if("" + dtb.Rows[i][pSoTapChiInfo.strTomTat] != "")
                    	pSoTapChiInfo.TomTat = dtb.Rows[i][pSoTapChiInfo.strTomTat].ToString();
                    if("" + dtb.Rows[i][pSoTapChiInfo.strGhiChu] != "")
                    	pSoTapChiInfo.GhiChu = dtb.Rows[i][pSoTapChiInfo.strGhiChu].ToString();
                    if("" + dtb.Rows[i][pSoTapChiInfo.strIDDongTap] != "")
                    	pSoTapChiInfo.IDDongTap = int.Parse(dtb.Rows[i][pSoTapChiInfo.strIDDongTap].ToString());
                    
                    oSoTapChiInfoList.Add(pSoTapChiInfo);
                }
            }
            return oSoTapChiInfoList;
        }
        
        public void ToDataRow(SoTapChiInfo pSoTapChiInfo, ref DataRow dr)
        {

			dr[pSoTapChiInfo.strSoTapChiID] = pSoTapChiInfo.SoTapChiID;
			dr[pSoTapChiInfo.strIDTaiLieu] = pSoTapChiInfo.IDTaiLieu;
			dr[pSoTapChiInfo.strNamPhatHanh] = pSoTapChiInfo.NamPhatHanh;
			dr[pSoTapChiInfo.strSoTheoNam] = pSoTapChiInfo.SoTheoNam;
			dr[pSoTapChiInfo.strSoToanCuc] = pSoTapChiInfo.SoToanCuc;
			dr[pSoTapChiInfo.strNgayPhatHanh] = pSoTapChiInfo.NgayPhatHanh;
			dr[pSoTapChiInfo.strDonGia] = pSoTapChiInfo.DonGia;
			dr[pSoTapChiInfo.strTomTat] = pSoTapChiInfo.TomTat;
			dr[pSoTapChiInfo.strGhiChu] = pSoTapChiInfo.GhiChu;
			dr[pSoTapChiInfo.strIDDongTap] = pSoTapChiInfo.IDDongTap;
        }
        
        public void ToInfo(ref SoTapChiInfo pSoTapChiInfo, DataRow dr)
        {

			pSoTapChiInfo.SoTapChiID = int.Parse(dr[pSoTapChiInfo.strSoTapChiID].ToString());
			pSoTapChiInfo.IDTaiLieu = int.Parse(dr[pSoTapChiInfo.strIDTaiLieu].ToString());
           // pSoTapChiInfo.NamPhatHanh = dr[pSoTapChiInfo.strNamPhatHanh].ToString();
			pSoTapChiInfo.SoTheoNam = dr[pSoTapChiInfo.strSoTheoNam].ToString();
			if("" + dr[pSoTapChiInfo.strSoToanCuc] != "")
				pSoTapChiInfo.SoToanCuc = dr[pSoTapChiInfo.strSoToanCuc].ToString();
			pSoTapChiInfo.NgayPhatHanh = DateTime.Parse(dr[pSoTapChiInfo.strNgayPhatHanh].ToString());
			if("" + dr[pSoTapChiInfo.strDonGia] != "")
				pSoTapChiInfo.DonGia = double.Parse(dr[pSoTapChiInfo.strDonGia].ToString());
			if("" + dr[pSoTapChiInfo.strTomTat] != "")
				pSoTapChiInfo.TomTat = dr[pSoTapChiInfo.strTomTat].ToString();
			if("" + dr[pSoTapChiInfo.strGhiChu] != "")
				pSoTapChiInfo.GhiChu = dr[pSoTapChiInfo.strGhiChu].ToString();
			if("" + dr[pSoTapChiInfo.strIDDongTap] != "")
				pSoTapChiInfo.IDDongTap = int.Parse(dr[pSoTapChiInfo.strIDDongTap].ToString());
        }
    }
}
