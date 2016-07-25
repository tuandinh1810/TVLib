using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBBanDoc_KhoaThe : cBBase
    {
        private cDBanDoc_KhoaThe oDBanDoc_KhoaThe;
        private BanDoc_KhoaTheInfo oBanDoc_KhoaTheInfo;

        public cBBanDoc_KhoaThe()        
        {
            oDBanDoc_KhoaThe = new cDBanDoc_KhoaThe();
        }

        public DataTable Get(BanDoc_KhoaTheInfo pBanDoc_KhoaTheInfo)        
        {
            return oDBanDoc_KhoaThe.Get(pBanDoc_KhoaTheInfo);
        }

        public int Add(BanDoc_KhoaTheInfo pBanDoc_KhoaTheInfo, string SoThe)
        {
			int ID = 0;
            ID = oDBanDoc_KhoaThe.Add(pBanDoc_KhoaTheInfo, SoThe);
            mErrorMessage = oDBanDoc_KhoaThe.ErrorMessages;
            mErrorNumber = oDBanDoc_KhoaThe.ErrorNumber;
            return ID;
        }

        public void Update(BanDoc_KhoaTheInfo pBanDoc_KhoaTheInfo)
        {
            oDBanDoc_KhoaThe.Update(pBanDoc_KhoaTheInfo);
            mErrorMessage = oDBanDoc_KhoaThe.ErrorMessages;
            mErrorNumber = oDBanDoc_KhoaThe.ErrorNumber;
        }
        
        public void Delete(BanDoc_KhoaTheInfo pBanDoc_KhoaTheInfo)
        {
            oDBanDoc_KhoaThe.Delete(pBanDoc_KhoaTheInfo);
            mErrorMessage = oDBanDoc_KhoaThe.ErrorMessages;
            mErrorNumber = oDBanDoc_KhoaThe.ErrorNumber;
        }

        public List<BanDoc_KhoaTheInfo> GetList(BanDoc_KhoaTheInfo pBanDoc_KhoaTheInfo)
        {
            List<BanDoc_KhoaTheInfo> oBanDoc_KhoaTheInfoList = new List<BanDoc_KhoaTheInfo>();
            DataTable dtb = Get(pBanDoc_KhoaTheInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oBanDoc_KhoaTheInfo = new BanDoc_KhoaTheInfo();
                    

                    oBanDoc_KhoaTheInfo.BanDocID = int.Parse(dtb.Rows[i]["BanDocID"].ToString());
                    oBanDoc_KhoaTheInfo.NgayBatDau = DateTime.Parse(dtb.Rows[i]["NgayBatDau"].ToString());
                    oBanDoc_KhoaTheInfo.SoNgay = int.Parse(dtb.Rows[i]["SoNgay"].ToString());
                    oBanDoc_KhoaTheInfo.NgayKetThuc = DateTime.Parse(dtb.Rows[i]["NgayKetThuc"].ToString());
                    oBanDoc_KhoaTheInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    
                    oBanDoc_KhoaTheInfoList.Add(oBanDoc_KhoaTheInfo);
                }
            }
            return oBanDoc_KhoaTheInfoList.Count == 0 ? null : oBanDoc_KhoaTheInfoList;
        }
    }
}
