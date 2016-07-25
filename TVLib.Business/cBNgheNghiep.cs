using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Business;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBNgheNghiep : cBBase
    {
        private cDNgheNghiep oDNgheNghiep;
        private NgheNghiepInfo oNgheNghiepInfo;

        public cBNgheNghiep()        
        {
            oDNgheNghiep = new cDNgheNghiep();
        }

        public DataTable Get(NgheNghiepInfo pNgheNghiepInfo)        
        {
            return oDNgheNghiep.Get(pNgheNghiepInfo);
        }

        public int Add(NgheNghiepInfo pNgheNghiepInfo)
        {
			int ID = 0;
            ID = oDNgheNghiep.Add(pNgheNghiepInfo);
            mErrorMessage = oDNgheNghiep.ErrorMessages;
            mErrorNumber = oDNgheNghiep.ErrorNumber;
            return ID;
        }

        public int Update(NgheNghiepInfo pNgheNghiepInfo)
        {
            int ID = 0;
            ID = oDNgheNghiep.Update(pNgheNghiepInfo);
            mErrorMessage = oDNgheNghiep.ErrorMessages;
            mErrorNumber = oDNgheNghiep.ErrorNumber;
            return ID;
        }
        
        public void Delete(NgheNghiepInfo pNgheNghiepInfo)
        {
            oDNgheNghiep.Delete(pNgheNghiepInfo);
            mErrorMessage = oDNgheNghiep.ErrorMessages;
            mErrorNumber = oDNgheNghiep.ErrorNumber;
        }
        public DataTable  GopNgheNghiep(NgheNghiepInfo pNgheNghiepInfo, int intNgheNghiepID)
        {
            return oDNgheNghiep.GopNgheNghiep(pNgheNghiepInfo, intNgheNghiepID);
          
        }

        public List<NgheNghiepInfo> GetList(NgheNghiepInfo pNgheNghiepInfo)
        {
            List<NgheNghiepInfo> oNgheNghiepInfoList = new List<NgheNghiepInfo>();
            DataTable dtb = Get(pNgheNghiepInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNgheNghiepInfo = new NgheNghiepInfo();
                    

                    oNgheNghiepInfo.NgheNghiepID = int.Parse(dtb.Rows[i]["NgheNghiepID"].ToString());
                    oNgheNghiepInfo.TenNgheNghiep = dtb.Rows[i]["TenNgheNghiep"].ToString();
                    
                    oNgheNghiepInfoList.Add(oNgheNghiepInfo);
                }
            }
            return oNgheNghiepInfoList.Count == 0 ? null : oNgheNghiepInfoList;
        }
    }
}
