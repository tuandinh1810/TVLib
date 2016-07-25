using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBMARC : cBBase
    {
        private cDMARC oDMARC;
        private MARCInfo oMARCInfo;

        public cBMARC()        
        {
            oDMARC = new cDMARC();
        }

        public DataTable Get(MARCInfo pMARCInfo)        
        {
            return oDMARC.Get(pMARCInfo);
        }

        public int Add(MARCInfo pMARCInfo)
        {
			int ID = 0;
            ID = oDMARC.Add(pMARCInfo);
            mErrorMessage = oDMARC.ErrorMessages;
            mErrorNumber = oDMARC.ErrorNumber;
            return ID;
        }

        public void Update(MARCInfo pMARCInfo)
        {
            oDMARC.Update(pMARCInfo);
            mErrorMessage = oDMARC.ErrorMessages;
            mErrorNumber = oDMARC.ErrorNumber;
        }
        
        public void Delete(MARCInfo pMARCInfo)
        {
            oDMARC.Delete(pMARCInfo);
            mErrorMessage = oDMARC.ErrorMessages;
            mErrorNumber = oDMARC.ErrorNumber;
        }

        public List<MARCInfo> GetList(MARCInfo pMARCInfo)
        {
            List<MARCInfo> oMARCInfoList = new List<MARCInfo>();
            DataTable dtb = Get(pMARCInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oMARCInfo = new MARCInfo();

                    oMARCInfo.MARCID = int.Parse(dtb.Rows[i]["MARCID"].ToString());
                    oMARCInfo.Name = dtb.Rows[i]["Name"].ToString();
                    oMARCInfo.Code = dtb.Rows[i]["Code"].ToString();
                    
                    oMARCInfoList.Add(oMARCInfo);
                }
            }
            return oMARCInfoList;
        }
        
        public void ToDataRow(MARCInfo pMARCInfo, ref DataRow dr)
        {

			dr[pMARCInfo.strMARCID] = pMARCInfo.MARCID;
			dr[pMARCInfo.strName] = pMARCInfo.Name;
			dr[pMARCInfo.strCode] = pMARCInfo.Code;
        }
        
        public void ToInfo(ref MARCInfo pMARCInfo, DataRow dr)
        {

			pMARCInfo.MARCID = int.Parse(dr[pMARCInfo.strMARCID].ToString());
			pMARCInfo.Name = dr[pMARCInfo.strName].ToString();
			pMARCInfo.Code = dr[pMARCInfo.strCode].ToString();
        }
    }
}
