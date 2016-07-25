using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBDongTap : cBBase
    {
        private cDDongTap oDDongTap;

        public cBDongTap()        
        {
            oDDongTap = new cDDongTap();
        }

        public DataTable Get(DongTapInfo pDongTapInfo)        
        {
            return oDDongTap.Get(pDongTapInfo);
        }

        public int Add(DongTapInfo pDongTapInfo)
        {
			int ID = 0;
            ID = oDDongTap.Add(pDongTapInfo);
            mErrorMessage = oDDongTap.ErrorMessages;
            mErrorNumber = oDDongTap.ErrorNumber;
            return ID;
        }

        public void Update(DongTapInfo pDongTapInfo)
        {
            oDDongTap.Update(pDongTapInfo);
            mErrorMessage = oDDongTap.ErrorMessages;
            mErrorNumber = oDDongTap.ErrorNumber;
        }
        
        public void Delete(DongTapInfo pDongTapInfo)
        {
            oDDongTap.Delete(pDongTapInfo);
            mErrorMessage = oDDongTap.ErrorMessages;
            mErrorNumber = oDDongTap.ErrorNumber;
        }

        public List<DongTapInfo> GetList(DongTapInfo pDongTapInfo)
        {
            List<DongTapInfo> oDongTapInfoList = new List<DongTapInfo>();
            DataTable dtb = Get(pDongTapInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pDongTapInfo = new DongTapInfo();

                    pDongTapInfo.DongTapID = int.Parse(dtb.Rows[i][pDongTapInfo.strDongTapID].ToString());
                    pDongTapInfo.IDTaiLieu = int.Parse(dtb.Rows[i][pDongTapInfo.strIDTaiLieu].ToString());
                    pDongTapInfo.MaXepGia = dtb.Rows[i][pDongTapInfo.strMaXepGia].ToString();
                    
                    oDongTapInfoList.Add(pDongTapInfo);
                }
            }
            return oDongTapInfoList;
        }
        
        public void ToDataRow(DongTapInfo pDongTapInfo, ref DataRow dr)
        {

			dr[pDongTapInfo.strDongTapID] = pDongTapInfo.DongTapID;
			dr[pDongTapInfo.strIDTaiLieu] = pDongTapInfo.IDTaiLieu;
			dr[pDongTapInfo.strMaXepGia] = pDongTapInfo.MaXepGia;
        }
        
        public void ToInfo(ref DongTapInfo pDongTapInfo, DataRow dr)
        {

			pDongTapInfo.DongTapID = int.Parse(dr[pDongTapInfo.strDongTapID].ToString());
			pDongTapInfo.IDTaiLieu = int.Parse(dr[pDongTapInfo.strIDTaiLieu].ToString());
			pDongTapInfo.MaXepGia = dr[pDongTapInfo.strMaXepGia].ToString();
        }
    }
}
