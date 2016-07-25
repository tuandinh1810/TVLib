using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBTaiKhoan : cBBase
    {
        private cDTaiKhoan oDTaiKhoan;
        private TaiKhoanInfo oTaiKhoanInfo;

        public cBTaiKhoan()
        {
            oDTaiKhoan = new cDTaiKhoan();
        }

        public DataTable Get(TaiKhoanInfo pTaiKhoanInfo)
        {
            return oDTaiKhoan.Get(pTaiKhoanInfo);
        }

        public DataTable GetTaiChinhInfor(  string strThoiGian, string strThang, string strNam )
        {
            return oDTaiKhoan.GetTaiChinhInfor(strThoiGian, strThang,strNam);
        }
        public DataTable GetChiPhiMuaTaiLieu(string MaTaiKhoan, string strThoiGian, string strThang, string strNam)
        {
            return oDTaiKhoan.GetChiPhiMuaTaiLieu(MaTaiKhoan,strThoiGian, strThang, strNam);
        }
        public DataTable GetTienNopTaiKhoan(string MaTaiKhoan,  string strThoiGian, string strThang, string strNam)
        {
            return oDTaiKhoan.GetTienNopTaiKhoan(MaTaiKhoan,strThoiGian, strThang, strNam);
        }


        public int Add(TaiKhoanInfo pTaiKhoanInfo)
        {
            int ID = 0;
            ID = oDTaiKhoan.Add(pTaiKhoanInfo);
            mErrorMessage = oDTaiKhoan.ErrorMessages;
            mErrorNumber = oDTaiKhoan.ErrorNumber;
            return ID;
        }

        public int Update(TaiKhoanInfo pTaiKhoanInfo)
        {
            return oDTaiKhoan.Update(pTaiKhoanInfo);
            mErrorMessage = oDTaiKhoan.ErrorMessages;
            mErrorNumber = oDTaiKhoan.ErrorNumber;
        }

        public void Delete(TaiKhoanInfo pTaiKhoanInfo)
        {
            oDTaiKhoan.Delete(pTaiKhoanInfo);
            mErrorMessage = oDTaiKhoan.ErrorMessages;
            mErrorNumber = oDTaiKhoan.ErrorNumber;
        }

        public DataTable GetTaiKhoanByTenDangNhap(string strTenDangNhap)
        {
            return oDTaiKhoan.GetTaiKhoanByTenDangNhap(strTenDangNhap);
            mErrorMessage = oDTaiKhoan.ErrorMessages;
            mErrorNumber = oDTaiKhoan.ErrorNumber;
        }

        public void KichHoat(string chkIDs)
        {
            oDTaiKhoan.KichHoat(chkIDs);
            mErrorMessage = oDTaiKhoan.ErrorMessages;
            mErrorNumber = oDTaiKhoan.ErrorNumber;
        }
        public List<TaiKhoanInfo> GetList(TaiKhoanInfo pTaiKhoanInfo)
        {
            List<TaiKhoanInfo> oTaiKhoanInfoList = new List<TaiKhoanInfo>();
            DataTable dtb = Get(pTaiKhoanInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oTaiKhoanInfo = new TaiKhoanInfo();


                    oTaiKhoanInfo.TaiKhoanID = int.Parse(dtb.Rows[i]["TaiKhoanID"].ToString());
                    oTaiKhoanInfo.TenTaiKhoan = dtb.Rows[i]["TenTaiKhoan"].ToString();
                    oTaiKhoanInfo.GioiTinh = bool.Parse(dtb.Rows[i]["GioiTinh"].ToString());
                    oTaiKhoanInfo.DonVi = dtb.Rows[i]["DonVi"].ToString();
                    oTaiKhoanInfo.PhongBan = dtb.Rows[i]["PhongBan"].ToString();
                    oTaiKhoanInfo.TenDangNhap = dtb.Rows[i]["TenDangNhap"].ToString();
                    oTaiKhoanInfo.MatKhau = dtb.Rows[i]["MatKhau"].ToString();
                    oTaiKhoanInfo.Email = dtb.Rows[i]["Email"].ToString();
                    oTaiKhoanInfo.DienThoai = dtb.Rows[i]["DienThoai"].ToString();
                    oTaiKhoanInfo.MucDoMat = int.Parse(dtb.Rows[i]["MucDoMat"].ToString());
                    oTaiKhoanInfo.TienNap = float.Parse(dtb.Rows[i]["TienNap"].ToString());
                    oTaiKhoanInfo.KichHoat = bool.Parse(dtb.Rows[i]["KichHoat"].ToString());
                    oTaiKhoanInfo.NgayTaoTaiKhoan = DateTime.Parse(dtb.Rows[i]["NgayTaoTaiKhoan"].ToString());
                   // oTaiKhoanInfo.DiaChi  = dtb.Rows[i]["DiaChi"].ToString();

                    oTaiKhoanInfoList.Add(oTaiKhoanInfo);
                }
            }
            return oTaiKhoanInfoList.Count == 0 ? null : oTaiKhoanInfoList;
        }
    }
}
