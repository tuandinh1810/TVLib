using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBTaiLieu_TruongDublin : cBBase
    {
        private cDTaiLieu_TruongDublin oDTaiLieu_TruongDublin;
        private TaiLieu_TruongDublinInfo oTaiLieu_TruongDublinInfo;

        public cBTaiLieu_TruongDublin()        
        {
            oDTaiLieu_TruongDublin = new cDTaiLieu_TruongDublin();
        }
        public DataTable RunSql(string strSql)
        {
            return oDTaiLieu_TruongDublin.RunSql(strSql);
        }
        public DataTable Get(TaiLieu_TruongDublinInfo pTaiLieu_TruongDublinInfo)        
        {
            return oDTaiLieu_TruongDublin.Get(pTaiLieu_TruongDublinInfo);
        }

        public int Add(TaiLieu_TruongDublinInfo pTaiLieu_TruongDublinInfo)
        {
			int ID = 0;
            ID = oDTaiLieu_TruongDublin.Add(pTaiLieu_TruongDublinInfo);
            mErrorMessage = oDTaiLieu_TruongDublin.ErrorMessages;
            mErrorNumber = oDTaiLieu_TruongDublin.ErrorNumber;
            return ID;
        }

        public void Update(TaiLieu_TruongDublinInfo pTaiLieu_TruongDublinInfo)
        {
            oDTaiLieu_TruongDublin.Update(pTaiLieu_TruongDublinInfo);
            mErrorMessage = oDTaiLieu_TruongDublin.ErrorMessages;
            mErrorNumber = oDTaiLieu_TruongDublin.ErrorNumber;
        }
        
        public void Delete(TaiLieu_TruongDublinInfo pTaiLieu_TruongDublinInfo)
        {
            oDTaiLieu_TruongDublin.Delete(pTaiLieu_TruongDublinInfo);
            mErrorMessage = oDTaiLieu_TruongDublin.ErrorMessages;
            mErrorNumber = oDTaiLieu_TruongDublin.ErrorNumber;
        }

        public List<TaiLieu_TruongDublinInfo> GetList(TaiLieu_TruongDublinInfo pTaiLieu_TruongDublinInfo)
        {
            List<TaiLieu_TruongDublinInfo> oTaiLieu_TruongDublinInfoList = new List<TaiLieu_TruongDublinInfo>();
            DataTable dtb = Get(pTaiLieu_TruongDublinInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTaiLieu_TruongDublinInfo = new TaiLieu_TruongDublinInfo();
                    

                    oTaiLieu_TruongDublinInfo.TaiLieu_TruongDublin_ID = int.Parse(dtb.Rows[i]["TaiLieu_TruongDublin_ID"].ToString());
                    oTaiLieu_TruongDublinInfo.IDTaiLieu = int.Parse(dtb.Rows[i]["IDTaiLieu"].ToString());
                    oTaiLieu_TruongDublinInfo.IDTruongDublin = int.Parse(dtb.Rows[i]["IDTruongDublin"].ToString());
                    oTaiLieu_TruongDublinInfo.DisplayEntry = dtb.Rows[i]["DisplayEntry"].ToString();
                    oTaiLieu_TruongDublinInfo.AccessEntry = dtb.Rows[i]["AccessEntry"].ToString();
                    
                    oTaiLieu_TruongDublinInfoList.Add(oTaiLieu_TruongDublinInfo);
                }
            }
            return oTaiLieu_TruongDublinInfoList.Count == 0 ? null : oTaiLieu_TruongDublinInfoList;
        }
    }
}
