using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBTaiKhoan_File : cBBase
    {
        private cDTaiKhoan_File oDTaiKhoan_File;
        private TaiKhoan_FileInfo oTaiKhoan_FileInfo;

        public cBTaiKhoan_File()        
        {
            oDTaiKhoan_File = new cDTaiKhoan_File();
        }

        public DataTable Get(TaiKhoan_FileInfo pTaiKhoan_FileInfo)        
        {
            return oDTaiKhoan_File.Get(pTaiKhoan_FileInfo);
        }

        public int Add(TaiKhoan_FileInfo pTaiKhoan_FileInfo)
        {
			int ID = 0;
            ID = oDTaiKhoan_File.Add(pTaiKhoan_FileInfo);
            mErrorMessage = oDTaiKhoan_File.ErrorMessages;
            mErrorNumber = oDTaiKhoan_File.ErrorNumber;
            return ID;
        }

        public void Update(TaiKhoan_FileInfo pTaiKhoan_FileInfo)
        {
            oDTaiKhoan_File.Update(pTaiKhoan_FileInfo);
            mErrorMessage = oDTaiKhoan_File.ErrorMessages;
            mErrorNumber = oDTaiKhoan_File.ErrorNumber;
        }
        
        public void Delete(TaiKhoan_FileInfo pTaiKhoan_FileInfo)
        {
            oDTaiKhoan_File.Delete(pTaiKhoan_FileInfo);
            mErrorMessage = oDTaiKhoan_File.ErrorMessages;
            mErrorNumber = oDTaiKhoan_File.ErrorNumber;
        }

        public List<TaiKhoan_FileInfo> GetList(TaiKhoan_FileInfo pTaiKhoan_FileInfo)
        {
            List<TaiKhoan_FileInfo> oTaiKhoan_FileInfoList = new List<TaiKhoan_FileInfo>();
            DataTable dtb = Get(pTaiKhoan_FileInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTaiKhoan_FileInfo = new TaiKhoan_FileInfo();
                    

                    oTaiKhoan_FileInfo.TaiKhoanFileID = int.Parse(dtb.Rows[i]["TaiKhoanFileID"].ToString());
                    oTaiKhoan_FileInfo.IDTaiKhoan = int.Parse(dtb.Rows[i]["IDTaiKhoan"].ToString());
                    oTaiKhoan_FileInfo.IDFile = int.Parse(dtb.Rows[i]["IDFile"].ToString());
                    oTaiKhoan_FileInfo.NgayDowloadFile = DateTime.Parse(dtb.Rows[i]["NgayDowloadFile"].ToString());
                    oTaiKhoan_FileInfo.ChiPhi = float.Parse(dtb.Rows[i]["ChiPhi"].ToString());
                    
                    oTaiKhoan_FileInfoList.Add(oTaiKhoan_FileInfo);
                }
            }
            return oTaiKhoan_FileInfoList.Count == 0 ? null : oTaiKhoan_FileInfoList;
        }
    }
}
