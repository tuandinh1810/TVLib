using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBTrinhDo : cBBase
    {
        private cDTrinhDo oDTrinhDo;
        private TrinhDoInfo oTrinhDoInfo;

        public cBTrinhDo()        
        {
            oDTrinhDo = new cDTrinhDo();
        }

        public DataTable Get(TrinhDoInfo pTrinhDoInfo)        
        {
            return oDTrinhDo.Get(pTrinhDoInfo);
        }

        public int Add(TrinhDoInfo pTrinhDoInfo)
        {
			int ID = 0;
            ID = oDTrinhDo.Add(pTrinhDoInfo);
            mErrorMessage = oDTrinhDo.ErrorMessages;
            mErrorNumber = oDTrinhDo.ErrorNumber;
            return ID;
        }
        public void GopTrinhDo(TrinhDoInfo pTrinhDoInfo, int intTrinhDoID)
        {
            oDTrinhDo.GopTrinhDo(pTrinhDoInfo, intTrinhDoID);
        }
        public int  Update(TrinhDoInfo pTrinhDoInfo)
        {
            int ID = 0;
            ID =  oDTrinhDo.Update(pTrinhDoInfo);
            mErrorMessage = oDTrinhDo.ErrorMessages;
            mErrorNumber = oDTrinhDo.ErrorNumber;
            return ID;
        }
        
        public void Delete(TrinhDoInfo pTrinhDoInfo)
        {
            oDTrinhDo.Delete(pTrinhDoInfo);
            mErrorMessage = oDTrinhDo.ErrorMessages;
            mErrorNumber = oDTrinhDo.ErrorNumber;
        }

        public List<TrinhDoInfo> GetList(TrinhDoInfo pTrinhDoInfo)
        {
            List<TrinhDoInfo> oTrinhDoInfoList = new List<TrinhDoInfo>();
            DataTable dtb = Get(pTrinhDoInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTrinhDoInfo = new TrinhDoInfo();
                    

                    oTrinhDoInfo.TrinhDoID = int.Parse(dtb.Rows[i]["TrinhDoID"].ToString());
                    oTrinhDoInfo.TrinhDo = dtb.Rows[i]["TrinhDo"].ToString();
                    
                    oTrinhDoInfoList.Add(oTrinhDoInfo);
                }
            }
            return oTrinhDoInfoList.Count == 0 ? null : oTrinhDoInfoList;
        }
    }
}
