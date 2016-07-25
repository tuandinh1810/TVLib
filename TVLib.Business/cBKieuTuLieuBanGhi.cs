using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBKieuTuLieuBanGhi : cBBase
    {
        private cDKieuTuLieuBanGhi oDKieuTuLieuBanGhi;
        private KieuTuLieuBanGhiInfo oKieuTuLieuBanGhiInfo;

        public cBKieuTuLieuBanGhi()        
        {
            oDKieuTuLieuBanGhi = new cDKieuTuLieuBanGhi();
        }

        public DataTable Get(KieuTuLieuBanGhiInfo pKieuTuLieuBanGhiInfo)        
        {
            return oDKieuTuLieuBanGhi.Get(pKieuTuLieuBanGhiInfo);
        }

        public int Add(KieuTuLieuBanGhiInfo pKieuTuLieuBanGhiInfo)
        {
			int ID = 0;
            ID = oDKieuTuLieuBanGhi.Add(pKieuTuLieuBanGhiInfo);
            mErrorMessage = oDKieuTuLieuBanGhi.ErrorMessages;
            mErrorNumber = oDKieuTuLieuBanGhi.ErrorNumber;
            return ID;
        }

        public void Update(KieuTuLieuBanGhiInfo pKieuTuLieuBanGhiInfo)
        {
            oDKieuTuLieuBanGhi.Update(pKieuTuLieuBanGhiInfo);
            mErrorMessage = oDKieuTuLieuBanGhi.ErrorMessages;
            mErrorNumber = oDKieuTuLieuBanGhi.ErrorNumber;
        }
        
        public void Delete(KieuTuLieuBanGhiInfo pKieuTuLieuBanGhiInfo)
        {
            oDKieuTuLieuBanGhi.Delete(pKieuTuLieuBanGhiInfo);
            mErrorMessage = oDKieuTuLieuBanGhi.ErrorMessages;
            mErrorNumber = oDKieuTuLieuBanGhi.ErrorNumber;
        }

        public List<KieuTuLieuBanGhiInfo> GetList(KieuTuLieuBanGhiInfo pKieuTuLieuBanGhiInfo)
        {
            List<KieuTuLieuBanGhiInfo> oKieuTuLieuBanGhiInfoList = new List<KieuTuLieuBanGhiInfo>();
            DataTable dtb = Get(pKieuTuLieuBanGhiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKieuTuLieuBanGhiInfo = new KieuTuLieuBanGhiInfo();
                    

                    oKieuTuLieuBanGhiInfo.KieuTuLieuBanGhiID = int.Parse(dtb.Rows[i]["KieuTuLieuBanGhiID"].ToString());
                    oKieuTuLieuBanGhiInfo.TenKieuTuLieuBanGhi = dtb.Rows[i]["TenKieuTuLieuBanGhi"].ToString();
                    
                    oKieuTuLieuBanGhiInfoList.Add(oKieuTuLieuBanGhiInfo);
                }
            }
            return oKieuTuLieuBanGhiInfoList.Count == 0 ? null : oKieuTuLieuBanGhiInfoList;
        }
    }
}
