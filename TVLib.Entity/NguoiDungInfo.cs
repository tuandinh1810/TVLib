using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class NguoiDungInfo
    {

        private int mNguoiDungID;
        private string mTenNguoiDung;
        private string mTenDangNHap;
        private string mMatKhau;
        private string mEmail;
        private string mDienThoai;
        private string mGhiChu;

        public string strNguoiDungID = "NguoiDungID";
        public string strTenNguoiDung = "TenNguoiDung";
        public string strTenDangNHap = "TenDangNHap";
        public string strMatKhau = "MatKhau";
        public string strEmail = "Email";
        public string strDienThoai = "DienThoai";
        public string strGhiChu = "GhiChu";

        public NguoiDungInfo()
        { }

        public int NguoiDungID{
        	set{ mNguoiDungID = value;}
        	get{ return mNguoiDungID;}
        }
        public string TenNguoiDung{
        	set{ mTenNguoiDung = value;}
        	get{ return mTenNguoiDung;}
        }
        public string TenDangNHap{
        	set{ mTenDangNHap = value;}
        	get{ return mTenDangNHap;}
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
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
