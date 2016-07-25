using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBMauPhich : cBBase
    {
        private cDMauPhich oDMauPhich;
        private MauPhichInfo oMauPhichInfo;

        public cBMauPhich()        
        {
            oDMauPhich = new cDMauPhich();
        }

        public DataTable Get(MauPhichInfo pMauPhichInfo)        
        {
            return oDMauPhich.Get(pMauPhichInfo);
        }

        public int Add(MauPhichInfo pMauPhichInfo)
        {
			int ID = 0;
            ID = oDMauPhich.Add(pMauPhichInfo);
            mErrorMessage = oDMauPhich.ErrorMessages;
            mErrorNumber = oDMauPhich.ErrorNumber;
            return ID;
        }

        public void Update(MauPhichInfo pMauPhichInfo)
        {
            oDMauPhich.Update(pMauPhichInfo);
            mErrorMessage = oDMauPhich.ErrorMessages;
            mErrorNumber = oDMauPhich.ErrorNumber;
        }
        
        public void Delete(MauPhichInfo pMauPhichInfo)
        {
            oDMauPhich.Delete(pMauPhichInfo);
            mErrorMessage = oDMauPhich.ErrorMessages;
            mErrorNumber = oDMauPhich.ErrorNumber;
        }

        public List<MauPhichInfo> GetList(MauPhichInfo pMauPhichInfo)
        {
            List<MauPhichInfo> oMauPhichInfoList = new List<MauPhichInfo>();
            DataTable dtb = Get(pMauPhichInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oMauPhichInfo = new MauPhichInfo();

                    oMauPhichInfo.MauPhichID = int.Parse(dtb.Rows[i]["MauPhichID"].ToString());
                    oMauPhichInfo.TenMauPhich = dtb.Rows[i]["TenMauPhich"].ToString();
                    oMauPhichInfo.GiaTri = dtb.Rows[i]["GiaTri"].ToString();
                    
                    oMauPhichInfoList.Add(oMauPhichInfo);
                }
            }
            return oMauPhichInfoList;
        }
        
        public void ToDataRow(MauPhichInfo pMauPhichInfo, ref DataRow dr)
        {

			dr[pMauPhichInfo.strMauPhichID] = pMauPhichInfo.MauPhichID;
			dr[pMauPhichInfo.strTenMauPhich] = pMauPhichInfo.TenMauPhich;
			dr[pMauPhichInfo.strGiaTri] = pMauPhichInfo.GiaTri;
        }
        
        public void ToInfo(ref MauPhichInfo pMauPhichInfo, DataRow dr)
        {

			pMauPhichInfo.MauPhichID = int.Parse(dr[pMauPhichInfo.strMauPhichID].ToString());
			pMauPhichInfo.TenMauPhich = dr[pMauPhichInfo.strTenMauPhich].ToString();
			pMauPhichInfo.GiaTri = dr[pMauPhichInfo.strGiaTri].ToString();
        }
    }
}
