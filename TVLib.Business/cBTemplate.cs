using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBTemplate : cBBase
    {
        private cDTemplate oDTemplate;
        private TemplateInfo oTemplateInfo;

        public cBTemplate()        
        {
            oDTemplate = new cDTemplate();
        }
        public DataTable GetTemplateByTenTemp(string strTenTemp)
        {
            return oDTemplate.GetTemplateByTenTemp(strTenTemp);
        }
        public DataTable Get(TemplateInfo pTemplateInfo)        
        {
            return oDTemplate.Get(pTemplateInfo);
        }

        public int Add(TemplateInfo pTemplateInfo)
        {
			int ID = 0;
            ID = oDTemplate.Add(pTemplateInfo);
            mErrorMessage = oDTemplate.ErrorMessages;
            mErrorNumber = oDTemplate.ErrorNumber;
            return ID;
        }

        public void Update(TemplateInfo pTemplateInfo)
        {
            oDTemplate.Update(pTemplateInfo);
            mErrorMessage = oDTemplate.ErrorMessages;
            mErrorNumber = oDTemplate.ErrorNumber;
        }
        
        public void Delete(TemplateInfo pTemplateInfo)
        {
            oDTemplate.Delete(pTemplateInfo);
            mErrorMessage = oDTemplate.ErrorMessages;
            mErrorNumber = oDTemplate.ErrorNumber;
        }

        public List<TemplateInfo> GetList(TemplateInfo pTemplateInfo)
        {
            List<TemplateInfo> oTemplateInfoList = new List<TemplateInfo>();
            DataTable dtb = Get(pTemplateInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTemplateInfo = new TemplateInfo();

                    oTemplateInfo.TemplateID = int.Parse(dtb.Rows[i]["TemplateID"].ToString());
                    oTemplateInfo.TenTemplate = dtb.Rows[i]["TenTemplate"].ToString();
                    oTemplateInfo.GiaTri = dtb.Rows[i]["GiaTri"].ToString();
                    
                    oTemplateInfoList.Add(oTemplateInfo);
                }
            }
            return oTemplateInfoList;
        }
        
        public void ToDataRow(TemplateInfo pTemplateInfo, ref DataRow dr)
        {

			dr[pTemplateInfo.strTemplateID] = pTemplateInfo.TemplateID;
			dr[pTemplateInfo.strTenTemplate] = pTemplateInfo.TenTemplate;
			dr[pTemplateInfo.strGiaTri] = pTemplateInfo.GiaTri;
        }
        
        public void ToInfo(ref TemplateInfo pTemplateInfo, DataRow dr)
        {

			pTemplateInfo.TemplateID = int.Parse(dr[pTemplateInfo.strTemplateID].ToString());
			pTemplateInfo.TenTemplate = dr[pTemplateInfo.strTenTemplate].ToString();
			pTemplateInfo.GiaTri = dr[pTemplateInfo.strGiaTri].ToString();
        }
    }
}
