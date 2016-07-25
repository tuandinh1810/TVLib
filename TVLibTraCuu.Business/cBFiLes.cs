using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBFiLes : cBBase
    {
        private cDFiLes oDFiLes;
        private FiLesInfo oFiLesInfo;

        public cBFiLes()        
        {
            oDFiLes = new cDFiLes();
        }

        public DataTable Get(FiLesInfo pFiLesInfo)        
        {
            return oDFiLes.Get(pFiLesInfo);
        }
        public DataTable GetTop20(FiLesInfo pFiLesInfo)
        {
            return oDFiLes.GetTop20(pFiLesInfo);
        }
        public DataTable GetTop10Download(FiLesInfo pFiLesInfo)
        {
            return oDFiLes.GetTop10Download(pFiLesInfo);
        }
        public DataTable GetFileDetail(FiLesInfo pFiLesInfo)
        {
            return oDFiLes.GetFileDetail(pFiLesInfo);
        }      
        public DataTable GetFileLienKet(FiLesInfo pFileInfo)
        {
            return oDFiLes.GetLienKetFile(pFileInfo);
        }
        public DataTable GetFileExisted(int intFileID)
        {
            return oDFiLes.GetFileExisted(intFileID);
        }
        
        public int Add(FiLesInfo pFiLesInfo)
        {
			int ID = 0;
            ID = oDFiLes.Add(pFiLesInfo);
            mErrorMessage = oDFiLes.ErrorMessages;
            mErrorNumber = oDFiLes.ErrorNumber;
            return ID;
        }

        public void Update(FiLesInfo pFiLesInfo)
        {
            oDFiLes.Update(pFiLesInfo);
            mErrorMessage = oDFiLes.ErrorMessages;
            mErrorNumber = oDFiLes.ErrorNumber;
        }
        
        public void Delete(FiLesInfo pFiLesInfo)
        {
            oDFiLes.Delete(pFiLesInfo);
            mErrorMessage = oDFiLes.ErrorMessages;
            mErrorNumber = oDFiLes.ErrorNumber;
        }

        public List<FiLesInfo> GetList(FiLesInfo pFiLesInfo)
        {
            List<FiLesInfo> oFiLesInfoList = new List<FiLesInfo>();
            DataTable dtb = Get(pFiLesInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oFiLesInfo = new FiLesInfo();
                    

                    oFiLesInfo.FileID = int.Parse(dtb.Rows[i]["FileID"].ToString());
                    oFiLesInfo.KichCoFile = int.Parse(dtb.Rows[i]["KichCoFile"].ToString());
                    oFiLesInfo.NgayUpLoad = DateTime.Parse(dtb.Rows[i]["NgayUpLoad"].ToString());
                    oFiLesInfo.NguoiUpLoad = dtb.Rows[i]["NguoiUpLoad"].ToString();
                    oFiLesInfo.TenFile = dtb.Rows[i]["TenFile"].ToString();
                    oFiLesInfo.DangFile = dtb.Rows[i]["DangFile"].ToString();
                    oFiLesInfo.MaTrangThai = dtb.Rows[i]["MaTrangThai"].ToString();
                    oFiLesInfo.Existed = bool.Parse(dtb.Rows[i]["Existed"].ToString());
                    oFiLesInfo.ThuPhi = bool.Parse(dtb.Rows[i]["ThuPhi"].ToString());
                    oFiLesInfo.GiaTien = float.Parse(dtb.Rows[i]["GiaTien"].ToString());
                    oFiLesInfo.SoTrang = int.Parse(dtb.Rows[i]["SoTrang"].ToString());
                    oFiLesInfo.DuongDanVatLy = dtb.Rows[i]["DuongDanVatLy"].ToString();
                    oFiLesInfo.SoLanDownLoad = int.Parse(dtb.Rows[i]["SoLanDownLoad"].ToString());
                    oFiLesInfo.CapDoMat = int.Parse(dtb.Rows[i]["CapDoMat"].ToString());
                    
                    oFiLesInfoList.Add(oFiLesInfo);
                }
            }
            return oFiLesInfoList.Count == 0 ? null : oFiLesInfoList;
        }

        public int CheckUser_DownloadFile(int intTaiKhoanID, int intFileID)
        {
            return oDFiLes.CheckUser_DownloadFile(intTaiKhoanID, intFileID);
        }
    }
}
