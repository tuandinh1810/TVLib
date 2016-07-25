using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
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
        public DataTable GetFileByDuongDanThuMuc(string DuongDanThuMuc)
        {
            return oDFiLes.GetFileByDuongDanThuMuc(DuongDanThuMuc);
        }

        public DataTable GetFileByIDBoSuuTap(int intIDBoSuuTap)
        {
            return oDFiLes.GetFileByIDBoSuuTap(intIDBoSuuTap);
        }
        public DataTable GetFileByDuongDanVatLy(string DuongDanVatLy)
        {
            return oDFiLes.GetFileByDuongDanVatLy(DuongDanVatLy);
        }
        public void UpdateThuPhi(float fltGiaTien,int intSoTrang,int intFileID)
        {
             oDFiLes.UpdateThuPhi(fltGiaTien, intSoTrang, intFileID);
        }
            
        public int Add(FiLesInfo pFiLesInfo)
        {
            int ID = 0;
            ID = oDFiLes.Add(pFiLesInfo);
            mErrorMessage = oDFiLes.ErrorMessages;
            mErrorNumber = oDFiLes.ErrorNumber;
            return ID;
        }
        public void UpdateExisted(FiLesInfo pFilesInfo)
        {
            oDFiLes.UpdateExisted(pFilesInfo);
        }
        public void Update_Existed(FiLesInfo pFilesInfo)
        {
            oDFiLes.Update_Existed(pFilesInfo);
        }
        public void Update_TrangThai(string strMaTrangThai, int intFileID)
        {
            oDFiLes.Update_TrangThai(strMaTrangThai, intFileID);
        }
        public void Update_CapDoMat(int CapDoMat, int intFileID)
        {
            oDFiLes.Update_CapDoMat(CapDoMat, intFileID);
        }
        public void Update_ThuPhi(Boolean bnlThuPhi, int intFileID)
        {
            oDFiLes.Update_ThuPhi(bnlThuPhi, intFileID);
        }
        public void Update_DuongDan(string strDuongDanCu, string strDuongDanMoi)
        {
            oDFiLes.Update_DuongDan(strDuongDanCu, strDuongDanMoi);
        }
        public void Update(FiLesInfo pFiLesInfo)
        {
            oDFiLes.Update(pFiLesInfo);
            mErrorMessage = oDFiLes.ErrorMessages;
            mErrorNumber = oDFiLes.ErrorNumber;
        }
        public DataTable GetFileExisted(int intFileID)
        {
            return oDFiLes.GetFileExisted(intFileID);
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
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oFiLesInfo = new FiLesInfo();


                    oFiLesInfo.FileID = int.Parse(dtb.Rows[i]["FileID"].ToString());
                    oFiLesInfo.KichCoFile = float.Parse(dtb.Rows[i]["KichCoFile"].ToString());
                    oFiLesInfo.NgayUpLoad = DateTime.Parse(dtb.Rows[i]["NgayUpLoad"].ToString());
                    oFiLesInfo.NguoiUpLoad = dtb.Rows[i]["NguoiUpLoad"].ToString();
                    oFiLesInfo.TenFile = dtb.Rows[i]["TenFile"].ToString();
                    oFiLesInfo.DangFile = dtb.Rows[i]["DangFile"].ToString();
                    oFiLesInfo.MaTrangThai = dtb.Rows[i]["MaTrangThai"].ToString();
                    oFiLesInfo.Existed = bool.Parse(dtb.Rows[i]["Existed"].ToString());
                    oFiLesInfo.DuongDanThuMuc = dtb.Rows[i]["DuongDanThuMuc"].ToString();
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
    }
}
