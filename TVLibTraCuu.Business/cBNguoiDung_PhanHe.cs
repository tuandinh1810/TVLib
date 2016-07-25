using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBNguoiDung_PhanHe : cBBase
    {
        private cDNguoiDung_PhanHe oDNguoiDung_PhanHe;
        private NguoiDung_PhanHeInfo oNguoiDung_PhanHeInfo;

        public cBNguoiDung_PhanHe()        
        {
            oDNguoiDung_PhanHe = new cDNguoiDung_PhanHe();
        }

        public DataTable Get(NguoiDung_PhanHeInfo pNguoiDung_PhanHeInfo)        
        {
            return oDNguoiDung_PhanHe.Get(pNguoiDung_PhanHeInfo);
        }

        public int Add(NguoiDung_PhanHeInfo pNguoiDung_PhanHeInfo)
        {
			int ID = 0;
            ID = oDNguoiDung_PhanHe.Add(pNguoiDung_PhanHeInfo);
            mErrorMessage = oDNguoiDung_PhanHe.ErrorMessages;
            mErrorNumber = oDNguoiDung_PhanHe.ErrorNumber;
            return ID;
        }

        public void Update(NguoiDung_PhanHeInfo pNguoiDung_PhanHeInfo)
        {
            oDNguoiDung_PhanHe.Update(pNguoiDung_PhanHeInfo);
            mErrorMessage = oDNguoiDung_PhanHe.ErrorMessages;
            mErrorNumber = oDNguoiDung_PhanHe.ErrorNumber;
        }
        
        public void Delete(NguoiDung_PhanHeInfo pNguoiDung_PhanHeInfo)
        {
            oDNguoiDung_PhanHe.Delete(pNguoiDung_PhanHeInfo);
            mErrorMessage = oDNguoiDung_PhanHe.ErrorMessages;
            mErrorNumber = oDNguoiDung_PhanHe.ErrorNumber;
        }

        public List<NguoiDung_PhanHeInfo> GetList(NguoiDung_PhanHeInfo pNguoiDung_PhanHeInfo)
        {
            List<NguoiDung_PhanHeInfo> oNguoiDung_PhanHeInfoList = new List<NguoiDung_PhanHeInfo>();
            DataTable dtb = Get(pNguoiDung_PhanHeInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNguoiDung_PhanHeInfo = new NguoiDung_PhanHeInfo();
                    

                    oNguoiDung_PhanHeInfo.IDNguoiDung = int.Parse(dtb.Rows[i]["IDNguoiDung"].ToString());
                    oNguoiDung_PhanHeInfo.IDPhanHe = int.Parse(dtb.Rows[i]["IDPhanHe"].ToString());
                    
                    oNguoiDung_PhanHeInfoList.Add(oNguoiDung_PhanHeInfo);
                }
            }
            return oNguoiDung_PhanHeInfoList.Count == 0 ? null : oNguoiDung_PhanHeInfoList;
        }
    }
}
