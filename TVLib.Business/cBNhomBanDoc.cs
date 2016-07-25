using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBNhomBanDoc : cBBase
    {
        private cDNhomBanDoc oDNhomBanDoc;
        private NhomBanDocInfo oNhomBanDocInfo;

        public cBNhomBanDoc()        
        {
            oDNhomBanDoc = new cDNhomBanDoc();
        }

        public DataTable Get(NhomBanDocInfo pNhomBanDocInfo)        
        {
            return oDNhomBanDoc.Get(pNhomBanDocInfo);
        }

        public int Add(NhomBanDocInfo pNhomBanDocInfo)
        {
			int ID = 0;
            ID = oDNhomBanDoc.Add(pNhomBanDocInfo);
            mErrorMessage = oDNhomBanDoc.ErrorMessages;
            mErrorNumber = oDNhomBanDoc.ErrorNumber;
            return ID;
        }

        public int Update(NhomBanDocInfo pNhomBanDocInfo)
        {
            int ID = 0;
            ID = oDNhomBanDoc.Update(pNhomBanDocInfo);
            mErrorMessage = oDNhomBanDoc.ErrorMessages;
            mErrorNumber = oDNhomBanDoc.ErrorNumber;
            return ID;
        }
        
        public int  Delete(NhomBanDocInfo pNhomBanDocInfo)
        {
            int ID = 0;
            ID = oDNhomBanDoc.Delete(pNhomBanDocInfo);
            mErrorMessage = oDNhomBanDoc.ErrorMessages;
            mErrorNumber = oDNhomBanDoc.ErrorNumber;
            return ID;
        }

        public List<NhomBanDocInfo> GetList(NhomBanDocInfo pNhomBanDocInfo)
        {
            List<NhomBanDocInfo> oNhomBanDocInfoList = new List<NhomBanDocInfo>();
            DataTable dtb = Get(pNhomBanDocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNhomBanDocInfo = new NhomBanDocInfo();
                    

                    oNhomBanDocInfo.NhomBanDocID = int.Parse(dtb.Rows[i]["NhomBanDocID"].ToString());
                    oNhomBanDocInfo.TenNhomBanDoc = dtb.Rows[i]["TenNhomBanDoc"].ToString();
                    oNhomBanDocInfo.SoSachMuon = int.Parse(dtb.Rows[i]["SoSachMuon"].ToString());
                    oNhomBanDocInfo.SoSachDatCho = int.Parse(dtb.Rows[i]["SoSachDatCho"].ToString());
                    oNhomBanDocInfo.CacKhoDuocMuon = dtb.Rows[i]["CacKhoDuocMuon"].ToString();
                    
                    oNhomBanDocInfoList.Add(oNhomBanDocInfo);
                }
            }
            return oNhomBanDocInfoList.Count == 0 ? null : oNhomBanDocInfoList;
        }
    }
}
