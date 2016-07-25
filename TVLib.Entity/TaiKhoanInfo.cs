using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class TaiKhoanInfo
    {

        private int mTaiKhoanID;
        private string mTenTaiKhoan;
        private bool mGioiTinh;
        private string mDonVi;
        private string mPhongBan;
        private string mTenDangNhap;
        private string mMatKhau;
        private string mEmail;
        private string mDienThoai;
        private int mMucDoMat;
        private float mTienNap;
        private bool mKichHoat;
        private DateTime mNgayTaoTaiKhoan;
        private string mDiaChi;

        public string strTaiKhoanID = "TaiKhoanID";
        public string strTenTaiKhoan = "TenTaiKhoan";
        public string strGioiTinh = "GioiTinh";
        public string strDonVi = "DonVi";
        public string strPhongBan = "PhongBan";
        public string strTenDangNhap = "TenDangNhap";
        public string strMatKhau = "MatKhau";
        public string strEmail = "Email";
        public string strDienThoai = "DienThoai";
        public string strMucDoMat = "MucDoMat";
        public string strTienNap = "TienNap";
        public string strKichHoat = "KichHoat";
        public string strNgayTaoTaiKhoan = "NgayTaoTaiKhoan";
        public string strDiaChi = "DiaChi";

        public TaiKhoanInfo()
        { }

        public int TaiKhoanID{
        	set{ mTaiKhoanID = value;}
        	get{ return mTaiKhoanID;}
        }
        public string TenTaiKhoan{
        	set{ mTenTaiKhoan = value;}
        	get{ return mTenTaiKhoan;}
        }
        public bool GioiTinh{
        	set{ mGioiTinh = value;}
        	get{ return mGioiTinh;}
        }
        public string DonVi{
        	set{ mDonVi = value;}
        	get{ return mDonVi;}
        }
        public string PhongBan{
        	set{ mPhongBan = value;}
        	get{ return mPhongBan;}
        }
        public string TenDangNhap{
        	set{ mTenDangNhap = value;}
        	get{ return mTenDangNhap;}
        }
        public string MatKhau{
        	set{ mMatKhau = value;}
        	get{ return mMatKhau;}
        }
        public string Email{
        	set{ mEmail = value;}
        	get{ return mEmail;}
        }
        public string DienThoai{
        	set{ mDienThoai = value;}
        	get{ return mDienThoai;}
        }
        public int MucDoMat{
        	set{ mMucDoMat = value;}
        	get{ return mMucDoMat;}
        }
        public float TienNap{
        	set{ mTienNap = value;}
        	get{ return mTienNap;}
        }
        public bool KichHoat{
        	set{ mKichHoat = value;}
        	get{ return mKichHoat;}
        }
        public DateTime NgayTaoTaiKhoan{
        	set{ mNgayTaoTaiKhoan = value;}
        	get{ return mNgayTaoTaiKhoan;}
        }
        public string DiaChi{
        	set{ mDiaChi = value;}
        	get{ return mDiaChi;}
        }
    }
}
