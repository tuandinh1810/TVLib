using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBTruongDublin : cBBase
    {
        private cDTruongDublin oDTruongDublin;
        private TruongDublinInfo oTruongDublinInfo;

        public cBTruongDublin()        
        {
            oDTruongDublin = new cDTruongDublin();
        }

        public DataTable Get(TruongDublinInfo pTruongDublinInfo)        
        {
            return oDTruongDublin.Get(pTruongDublinInfo);
        }

        public int Add(TruongDublinInfo pTruongDublinInfo)
        {
			int ID = 0;
            ID = oDTruongDublin.Add(pTruongDublinInfo);
            mErrorMessage = oDTruongDublin.ErrorMessages;
            mErrorNumber = oDTruongDublin.ErrorNumber;
            return ID;
        }

        public void Update(TruongDublinInfo pTruongDublinInfo)
        {
            oDTruongDublin.Update(pTruongDublinInfo);
            mErrorMessage = oDTruongDublin.ErrorMessages;
            mErrorNumber = oDTruongDublin.ErrorNumber;
        }
        
        public void Delete(TruongDublinInfo pTruongDublinInfo)
        {
            oDTruongDublin.Delete(pTruongDublinInfo);
            mErrorMessage = oDTruongDublin.ErrorMessages;
            mErrorNumber = oDTruongDublin.ErrorNumber;
        }

        public List<TruongDublinInfo> GetList(TruongDublinInfo pTruongDublinInfo)
        {
            List<TruongDublinInfo> oTruongDublinInfoList = new List<TruongDublinInfo>();
            DataTable dtb = Get(pTruongDublinInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTruongDublinInfo = new TruongDublinInfo();
                    

                    oTruongDublinInfo.TruongDublinID = int.Parse(dtb.Rows[i]["TruongDublinID"].ToString());
                    oTruongDublinInfo.TenTruongDublin = dtb.Rows[i]["TenTruongDublin"].ToString();
                    
                    oTruongDublinInfoList.Add(oTruongDublinInfo);
                }
            }
            return oTruongDublinInfoList.Count == 0 ? null : oTruongDublinInfoList;
        }
    }
}
