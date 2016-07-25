using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBLienKetFile : cBBase
    {
        private cDLienKetFile oDLienKetFile;
        private LienKetFileInfo oLienKetFileInfo;
        //Xu ly lien ket file
        
        public void Add_LienKetFile(int intIDFile1, int intIDFile2)
        {
            LienKetFileInfo pLienKetFile = new LienKetFileInfo();
            cBLienKetFile objLienKetFie = new cBLienKetFile();
            DataTable dtblkf;
            string strChuoiIDFile1 = "";
            string strChuoiIDFile2="";
            Boolean bnlfount = false;
            dtblkf = oDLienKetFile.GetChuoiIDFile(0);
            if (dtblkf.Rows.Count > 0)
            {
                for (int i = 0; i < dtblkf.Rows.Count; i++)
                {
                    strChuoiIDFile1 = intIDFile1.ToString() + "," + intIDFile2.ToString();
                    if (strChuoiIDFile1.Equals(dtblkf.Rows[i]["ChuoiIDFile"].ToString()))
                    {
                        bnlfount = true;
                        break;
                    }
                        strChuoiIDFile2 = dtblkf.Rows[i]["ChuoiIDFile"].ToString();
                        if (CheckDulicateLK(strChuoiIDFile1, strChuoiIDFile2))
                        {
                            bnlfount = true;
                            break;
                        }
                 }
                if (bnlfount ==false )
                { 
                    pLienKetFile.IDFile1 = intIDFile1;
                    pLienKetFile.IDFile2 = intIDFile2;
                    objLienKetFie.Add(pLienKetFile);
                }
              }
            else
            {
                pLienKetFile.IDFile1 = intIDFile1;
                pLienKetFile.IDFile2 = intIDFile2;
                objLienKetFie.Add(pLienKetFile);
            }
        }
        protected Boolean CheckDulicateLK(string str1, string str2)
        {
            string[] arr1;
            string[] arr2;
            arr1 = str1.Split(',');
            arr2 = str2.Split(',');
            Boolean blndulicate = false;
            if(arr1.Length>0 && arr2.Length>0)
            {
                if (arr1[0] == arr2[1] && arr1[1]==arr2[0])
                {
                    blndulicate = true;
                }
            }
            return blndulicate;
        }
        public DataTable GetByIDFile1(int intIDFile1)
        {
            return oDLienKetFile.GetByIDFile1(intIDFile1);
        }
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
