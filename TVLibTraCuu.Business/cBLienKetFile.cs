using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBLienKetFile : cBBase
    {
        private cDLienKetFile oDLienKetFile;
        private LienKetFileInfo oLienKetFileInfo;

        public cBLienKetFile()        
        {
            oDLienKetFile = new cDLienKetFile();
        }

        public DataTable Get(LienKetFileInfo pLienKetFileInfo)        
        {
            return oDLienKetFile.Get(pLienKetFileInfo);
        }

        public int Add(LienKetFileInfo pLienKetFileInfo)
        {
			int ID = 0;
            ID = oDLienKetFile.Add(pLienKetFileInfo);
            mErrorMessage = oDLienKetFile.ErrorMessages;
            mErrorNumber = oDLienKetFile.ErrorNumber;
            return ID;
        }

        public void Update(LienKetFileInfo pLienKetFileInfo)
        {
            oDLienKetFile.Update(pLienKetFileInfo);
            mErrorMessage = oDLienKetFile.ErrorMessages;
            mErrorNumber = oDLienKetFile.ErrorNumber;
        }
        
        public void Delete(LienKetFileInfo pLienKetFileInfo)
        {
            oDLienKetFile.Delete(pLienKetFileInfo);
            mErrorMessage = oDLienKetFile.ErrorMessages;
            mErrorNumber = oDLienKetFile.ErrorNumber;
        }

        public List<LienKetFileInfo> GetList(LienKetFileInfo pLienKetFileInfo)
        {
            List<LienKetFileInfo> oLienKetFileInfoList = new List<LienKetFileInfo>();
            DataTable dtb = Get(pLienKetFileInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oLienKetFileInfo = new LienKetFileInfo();
                    

                    oLienKetFileInfo.LienKetFileID = int.Parse(dtb.Rows[i]["LienKetFileID"].ToString());
                    oLienKetFileInfo.IDFile1 = int.Parse(dtb.Rows[i]["IDFile1"].ToString());
                    oLienKetFileInfo.IDFile2 = int.Parse(dtb.Rows[i]["IDFile2"].ToString());
                    
                    oLienKetFileInfoList.Add(oLienKetFileInfo);
                }
            }
            return oLienKetFileInfoList.Count == 0 ? null : oLienKetFileInfoList;
        }
    }
}
