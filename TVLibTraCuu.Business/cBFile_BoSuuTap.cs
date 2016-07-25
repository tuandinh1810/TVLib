using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBFile_BoSuuTap : cBBase
    {
        private cDFile_BoSuuTap oDFile_BoSuuTap;
        private File_BoSuuTapInfo oFile_BoSuuTapInfo;

        public cBFile_BoSuuTap()        
        {
            oDFile_BoSuuTap = new cDFile_BoSuuTap();
        }

        public DataTable Get(File_BoSuuTapInfo pFile_BoSuuTapInfo)        
        {
            return oDFile_BoSuuTap.Get(pFile_BoSuuTapInfo);
        }

        public int Add(File_BoSuuTapInfo pFile_BoSuuTapInfo)
        {
			int ID = 0;
            ID = oDFile_BoSuuTap.Add(pFile_BoSuuTapInfo);
            mErrorMessage = oDFile_BoSuuTap.ErrorMessages;
            mErrorNumber = oDFile_BoSuuTap.ErrorNumber;
            return ID;
        }

        public void Update(File_BoSuuTapInfo pFile_BoSuuTapInfo)
        {
            oDFile_BoSuuTap.Update(pFile_BoSuuTapInfo);
            mErrorMessage = oDFile_BoSuuTap.ErrorMessages;
            mErrorNumber = oDFile_BoSuuTap.ErrorNumber;
        }
        
        public void Delete(File_BoSuuTapInfo pFile_BoSuuTapInfo)
        {
            oDFile_BoSuuTap.Delete(pFile_BoSuuTapInfo);
            mErrorMessage = oDFile_BoSuuTap.ErrorMessages;
            mErrorNumber = oDFile_BoSuuTap.ErrorNumber;
        }

        public List<File_BoSuuTapInfo> GetList(File_BoSuuTapInfo pFile_BoSuuTapInfo)
        {
            List<File_BoSuuTapInfo> oFile_BoSuuTapInfoList = new List<File_BoSuuTapInfo>();
            DataTable dtb = Get(pFile_BoSuuTapInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oFile_BoSuuTapInfo = new File_BoSuuTapInfo();
                    

                    oFile_BoSuuTapInfo.File_BoSuuTapID = int.Parse(dtb.Rows[i]["File_BoSuuTapID"].ToString());
                    oFile_BoSuuTapInfo.IDFile = int.Parse(dtb.Rows[i]["IDFile"].ToString());
                    oFile_BoSuuTapInfo.IDBoSuuTap = int.Parse(dtb.Rows[i]["IDBoSuuTap"].ToString());
                    
                    oFile_BoSuuTapInfoList.Add(oFile_BoSuuTapInfo);
                }
            }
            return oFile_BoSuuTapInfoList.Count == 0 ? null : oFile_BoSuuTapInfoList;
        }
    }
}
