using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBBoSuuTap : cBBase
    {
        private cDBoSuuTap oDBoSuuTap;
        private BoSuuTapInfo oBoSuuTapInfo;

        public cBBoSuuTap()        
        {
            oDBoSuuTap = new cDBoSuuTap();
        }

        public DataTable Get(BoSuuTapInfo pBoSuuTapInfo)        
        {
            return oDBoSuuTap.Get(pBoSuuTapInfo);
        }

        public int Add(BoSuuTapInfo pBoSuuTapInfo)
        {
			int ID = 0;
            ID = oDBoSuuTap.Add(pBoSuuTapInfo);
            mErrorMessage = oDBoSuuTap.ErrorMessages;
            mErrorNumber = oDBoSuuTap.ErrorNumber;
            return ID;
        }

        public void Update(BoSuuTapInfo pBoSuuTapInfo)
        {
            oDBoSuuTap.Update(pBoSuuTapInfo);
            mErrorMessage = oDBoSuuTap.ErrorMessages;
            mErrorNumber = oDBoSuuTap.ErrorNumber;
        }
        
        public void Delete(BoSuuTapInfo pBoSuuTapInfo)
        {
            oDBoSuuTap.Delete(pBoSuuTapInfo);
            mErrorMessage = oDBoSuuTap.ErrorMessages;
            mErrorNumber = oDBoSuuTap.ErrorNumber;
        }

        public List<BoSuuTapInfo> GetList(BoSuuTapInfo pBoSuuTapInfo)
        {
            List<BoSuuTapInfo> oBoSuuTapInfoList = new List<BoSuuTapInfo>();
            DataTable dtb = Get(pBoSuuTapInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oBoSuuTapInfo = new BoSuuTapInfo();
                    

                    oBoSuuTapInfo.BoSuuTapID = int.Parse(dtb.Rows[i]["BoSuuTapID"].ToString());
                    oBoSuuTapInfo.TenBoSuuTap = dtb.Rows[i]["TenBoSuuTap"].ToString();
                    oBoSuuTapInfo.MoTa = dtb.Rows[i]["MoTa"].ToString();
                    
                    oBoSuuTapInfoList.Add(oBoSuuTapInfo);
                }
            }
            return oBoSuuTapInfoList.Count == 0 ? null : oBoSuuTapInfoList;
        }
    }
}
