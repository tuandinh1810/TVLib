using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBFile_TruongDublin : cBBase
    {
        private cDFile_TruongDublin oDFile_TruongDublin;
        private File_TruongDublinInfo oFile_TruongDublinInfo;

        public cBFile_TruongDublin()        
        {
            oDFile_TruongDublin = new cDFile_TruongDublin();
        }
        public DataTable RunSql(string strSql)
        {
            return oDFile_TruongDublin.RunSql(strSql);
        }
        public DataTable Get(File_TruongDublinInfo pFile_TruongDublinInfo)        
        {
            return oDFile_TruongDublin.Get(pFile_TruongDublinInfo);
        }

        public int Add(File_TruongDublinInfo pFile_TruongDublinInfo)
        {
			int ID = 0;
            ID = oDFile_TruongDublin.Add(pFile_TruongDublinInfo);
            mErrorMessage = oDFile_TruongDublin.ErrorMessages;
            mErrorNumber = oDFile_TruongDublin.ErrorNumber;
            return ID;
        }

        public void Update(File_TruongDublinInfo pFile_TruongDublinInfo)
        {
            oDFile_TruongDublin.Update(pFile_TruongDublinInfo);
            mErrorMessage = oDFile_TruongDublin.ErrorMessages;
            mErrorNumber = oDFile_TruongDublin.ErrorNumber;
        }
        
        public void Delete(File_TruongDublinInfo pFile_TruongDublinInfo)
        {
            oDFile_TruongDublin.Delete(pFile_TruongDublinInfo);
            mErrorMessage = oDFile_TruongDublin.ErrorMessages;
            mErrorNumber = oDFile_TruongDublin.ErrorNumber;
        }

        public List<File_TruongDublinInfo> GetList(File_TruongDublinInfo pFile_TruongDublinInfo)
        {
            List<File_TruongDublinInfo> oFile_TruongDublinInfoList = new List<File_TruongDublinInfo>();
            DataTable dtb = Get(pFile_TruongDublinInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oFile_TruongDublinInfo = new File_TruongDublinInfo();
                    

                    oFile_TruongDublinInfo.File_TruongDublin_ID = int.Parse(dtb.Rows[i]["File_TruongDublin_ID"].ToString());
                    oFile_TruongDublinInfo.IDFile = int.Parse(dtb.Rows[i]["IDFile"].ToString());
                    oFile_TruongDublinInfo.IDTruongDublin = int.Parse(dtb.Rows[i]["IDTruongDublin"].ToString());
                    oFile_TruongDublinInfo.DisplayEntry = dtb.Rows[i]["DisplayEntry"].ToString();
                    oFile_TruongDublinInfo.AccessEntry = dtb.Rows[i]["AccessEntry"].ToString();
                    
                    oFile_TruongDublinInfoList.Add(oFile_TruongDublinInfo);
                }
            }
            return oFile_TruongDublinInfoList.Count == 0 ? null : oFile_TruongDublinInfoList;
        }
    }
}
