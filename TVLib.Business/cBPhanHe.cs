using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Business;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBPhanHe : cBBase
    {
        private cDPhanHe oDPhanHe;
        private PhanHeInfo oPhanHeInfo;

        public cBPhanHe()        
        {
            oDPhanHe = new cDPhanHe();
        }

        public DataTable Get(PhanHeInfo pPhanHeInfo)        
        {
            return oDPhanHe.Get(pPhanHeInfo);
        }

        public int Add(PhanHeInfo pPhanHeInfo)
        {
			int ID = 0;
            ID = oDPhanHe.Add(pPhanHeInfo);
            mErrorMessage = oDPhanHe.ErrorMessages;
            mErrorNumber = oDPhanHe.ErrorNumber;
            return ID;
        }

        public void Update(PhanHeInfo pPhanHeInfo)
        {
            oDPhanHe.Update(pPhanHeInfo);
            mErrorMessage = oDPhanHe.ErrorMessages;
            mErrorNumber = oDPhanHe.ErrorNumber;
        }
        
        public void Delete(PhanHeInfo pPhanHeInfo)
        {
            oDPhanHe.Delete(pPhanHeInfo);
            mErrorMessage = oDPhanHe.ErrorMessages;
            mErrorNumber = oDPhanHe.ErrorNumber;
        }

        public List<PhanHeInfo> GetList(PhanHeInfo pPhanHeInfo)
        {
            List<PhanHeInfo> oPhanHeInfoList = new List<PhanHeInfo>();
            DataTable dtb = Get(pPhanHeInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oPhanHeInfo = new PhanHeInfo();
                    

                    oPhanHeInfo.PhanHeID = int.Parse(dtb.Rows[i]["PhanHeID"].ToString());
                    //oPhanHeInfo.MaPhanHe = dtb.Rows[i]["MaPhanHe"].ToString();
                    oPhanHeInfo.TenPhanHe = dtb.Rows[i]["TenPhanHe"].ToString();
                    
                    oPhanHeInfoList.Add(oPhanHeInfo);
                }
            }
            return oPhanHeInfoList.Count == 0 ? null : oPhanHeInfoList;
        }
    }
}
