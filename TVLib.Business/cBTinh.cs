using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBTinh : cBBase
    {
        private cDTinh oDTinh;
        private TinhInfo oTinhInfo;

        public cBTinh()        
        {
            oDTinh = new cDTinh();
        }

        public DataTable Get(TinhInfo pTinhInfo)        
        {
            return oDTinh.Get(pTinhInfo);
        }

        public int Add(TinhInfo pTinhInfo)
        {
			int ID = 0;
            ID = oDTinh.Add(pTinhInfo);
            mErrorMessage = oDTinh.ErrorMessages;
            mErrorNumber = oDTinh.ErrorNumber;
            return ID;
        }

        public int Update(TinhInfo pTinhInfo)
        {
            int ID = 0;
            ID = oDTinh.Update(pTinhInfo);
            mErrorMessage = oDTinh.ErrorMessages;
            mErrorNumber = oDTinh.ErrorNumber;
            return ID;
        }
        public void GopTinh(TinhInfo pTinhInfo, int TinhIDGop)
        {
           oDTinh.GopTinh(pTinhInfo,TinhIDGop);            
        }
        
        public void Delete(TinhInfo pTinhInfo)
        {
            oDTinh.Delete(pTinhInfo);
            mErrorMessage = oDTinh.ErrorMessages;
            mErrorNumber = oDTinh.ErrorNumber;
        }

        public List<TinhInfo> GetList(TinhInfo pTinhInfo)
        {
            List<TinhInfo> oTinhInfoList = new List<TinhInfo>();
            DataTable dtb = Get(pTinhInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTinhInfo = new TinhInfo();
                    

                    oTinhInfo.TinhID = int.Parse(dtb.Rows[i]["TinhID"].ToString());
                    oTinhInfo.TenTinh = dtb.Rows[i]["TenTinh"].ToString();
                    
                    oTinhInfoList.Add(oTinhInfo);
                }
            }
            return oTinhInfoList.Count == 0 ? null : oTinhInfoList;
        }
    }
}
