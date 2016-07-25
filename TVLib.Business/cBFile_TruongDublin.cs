using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBFile_TruongDublin : cBBase
    {
        private cDFile_TruongDublin oDFile_TruongDublin;
        private File_TruongDublinInfo oFile_TruongDublinInfo;
        
        //Insert data to File_TruongDublin
        public void AddFile_TruongDublin(string strTruongDublin,string strDublinValue,int intIDFile)
        {
            string[] arrTruongDublin;
            string[] arrDublinValue;
            arrTruongDublin=strTruongDublin.Split('$');
            arrDublinValue=strDublinValue.Split('$');
            cBFile_TruongDublin objFileTruongDublin = new cBFile_TruongDublin();
            File_TruongDublinInfo objFileTruongDublinInfo = new File_TruongDublinInfo();
            for (int intIndex = 0; intIndex <= arrTruongDublin.Length - 1;intIndex++ )
            {
                if(arrDublinValue[intIndex]!="" && arrTruongDublin[intIndex]!="")
                {
                objFileTruongDublinInfo.IDTruongDublin = Convert.ToInt16( arrTruongDublin[intIndex]);
                objFileTruongDublinInfo.DisplayEntry = arrDublinValue[intIndex].ToString();
                objFileTruongDublinInfo.IDFile = intIDFile;
                objFileTruongDublinInfo.AccessEntry = arrDublinValue[intIndex].ToUpper();
                objFileTruongDublin.Add(objFileTruongDublinInfo);
                }
            }
        }
        public void UpdateFile_TruongDublin(string strTruongDublin, string strDublinValue, int intIDFile,int intFile_TruongDublinID)
        {
            string[] arrTruongDublin;
            string[] arrDublinValue;
            arrTruongDublin = strTruongDublin.Split('$');
            arrDublinValue = strDublinValue.Split('$');
            cBFile_TruongDublin objFileTruongDublin = new cBFile_TruongDublin();
            File_TruongDublinInfo objFileTruongDublinInfo = new File_TruongDublinInfo();
            for (int intIndex = 0; intIndex <= arrTruongDublin.Length - 1; intIndex++)
            {
                if (arrDublinValue[intIndex] != "" && arrTruongDublin[intIndex] != "")
                {
                    objFileTruongDublinInfo.IDTruongDublin = Convert.ToInt16(arrTruongDublin[intIndex]);
                    objFileTruongDublinInfo.DisplayEntry = arrDublinValue[intIndex].ToString();
                    objFileTruongDublinInfo.IDFile = intIDFile;
                    objFileTruongDublinInfo.AccessEntry = arrDublinValue[intIndex].ToUpper();
                    objFileTruongDublinInfo.File_TruongDublin_ID = 0;
                    objFileTruongDublin.Update(objFileTruongDublinInfo);
                }
            }
        }
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
        public DataTable Dublin_GetByIDFile(int intIDFile)
        {
            return oDFile_TruongDublin.Dublin_GetByID(intIDFile);
        }
        public int UpDate_File_TruongDublin(int intIDFile, string strTruongDublinID, string strDisplayEntry, string strAccessEntry)
        {
            return oDFile_TruongDublin.UpDate_File_TruongDublin(intIDFile, strTruongDublinID, strDisplayEntry, strAccessEntry);
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
