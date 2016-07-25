using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBFile_BoSuuTap : cBBase
    {
        private cDFile_BoSuuTap oDFile_BoSuuTap;
        private File_BoSuuTapInfo oFile_BoSuuTapInfo;

        public DataTable Get_File_BoSuuTap_ByID(int IDBoSuuTap, int IDFile)
        {
            return oDFile_BoSuuTap.Get_File_BoSuuTap_ByID(IDBoSuuTap,IDFile);
        }
        public void Delete_FieBoSuuTap_ByIDBoSuuTaps(string strIDBoSuuTap)
        {
            oDFile_BoSuuTap.Delete_FieBoSuuTap_ByIDBoSuuTaps(strIDBoSuuTap);
            mErrorMessage = oDFile_BoSuuTap.ErrorMessages;
            mErrorNumber = oDFile_BoSuuTap.ErrorNumber;
        }
        public int GopBoSuuTap(DataTable dtbFileBoSuuTap, int IDBoSuuTap)
        {
            string strIDFiles = "";
            string[] arrIDFile;
            int intSucess = 0;
            DataTable dtbTemp;
            File_BoSuuTapInfo objFileBoSuuTapInfo=new File_BoSuuTapInfo();
            cBFile_BoSuuTap objFileBoSuuTap=new cBFile_BoSuuTap();
            if (dtbFileBoSuuTap.Rows.Count > 0)
            {
                for (int i = 0; i < dtbFileBoSuuTap.Rows.Count; i++)
                {
                    strIDFiles = dtbFileBoSuuTap.Rows[i]["IDFile"].ToString() + ",";
                }
            }
              
            arrIDFile = strIDFiles.Split(',');
            
            if (arrIDFile.Length > 0 && arrIDFile[0] != "")
            {
                for (int intgop = 0; intgop < arrIDFile.Length - 1; intgop++)
                {
                    if (arrIDFile[intgop] != "")
                    {
                        dtbTemp = Get_File_BoSuuTap_ByID(IDBoSuuTap, int.Parse (arrIDFile[intgop]));
                        if(dtbTemp.Rows.Count==0)
                        {
                            objFileBoSuuTapInfo.IDBoSuuTap = IDBoSuuTap;
                            objFileBoSuuTapInfo.IDFile =int.Parse( arrIDFile[intgop]);
                            intSucess = objFileBoSuuTap.Add(objFileBoSuuTapInfo);
                        }
                    }
                }
            }
            return intSucess;
        }

        public DataTable Get_File_BoSuuTap_ByIDBoSuuTap(string strIDBoSuuTaps)
        {
            return oDFile_BoSuuTap.Get_File_BoSuuTap_ByIDBoSuuTap(strIDBoSuuTaps);
        }
        public DataTable GetCountByGroup(int intPara)
        {
            return oDFile_BoSuuTap.GetCountByGroup(intPara);
        }

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
