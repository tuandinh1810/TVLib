using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Business;
using TruongViet.TVLib.Data;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Business
{
   
    public class cBDanToc : cBBase
    {
        
        private cDDanToc oDDanToc;
        private DanTocInfo oDanTocInfo;

        public cBDanToc()        
        {
            oDDanToc = new cDDanToc();
        }

        public DataTable Get(DanTocInfo pDanTocInfo)        
        {
            return oDDanToc.Get(pDanTocInfo);
        }

        public int Add(DanTocInfo pDanTocInfo)
        {
			int ID = 0;
            ID = oDDanToc.Add(pDanTocInfo);
            mErrorMessage = oDDanToc.ErrorMessages;
            mErrorNumber = oDDanToc.ErrorNumber;
            return ID;
        }
        public void GopDanToc(DanTocInfo pDanTocInfo, int DanTocIDGop)
        {
            oDDanToc.GopDanToc(pDanTocInfo, DanTocIDGop);
        }
        public int  Update(DanTocInfo pDanTocInfo)
        {
            int ID = 0;
            ID = oDDanToc.Update(pDanTocInfo);
            mErrorMessage = oDDanToc.ErrorMessages;
            mErrorNumber = oDDanToc.ErrorNumber;
            return ID; 
        }
        
        public void Delete(DanTocInfo pDanTocInfo)
        {
            oDDanToc.Delete(pDanTocInfo);
            mErrorMessage = oDDanToc.ErrorMessages;
            mErrorNumber = oDDanToc.ErrorNumber;
        }

        public List<DanTocInfo> GetList(DanTocInfo pDanTocInfo)
        {
            List<DanTocInfo> oDanTocInfoList = new List<DanTocInfo>();
            DataTable dtb = Get(pDanTocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDanTocInfo = new DanTocInfo();
                    

                    oDanTocInfo.DanTocID = int.Parse(dtb.Rows[i]["DanTocID"].ToString());
                    oDanTocInfo.DanToc = dtb.Rows[i]["DanToc"].ToString();
                    
                    oDanTocInfoList.Add(oDanTocInfo);
                }
            }
            return oDanTocInfoList.Count == 0 ? null : oDanTocInfoList;
        }
    }
}
