using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class BanDocInfo
    {

        private int mBanDocID;
        private string mSoThe;
        private string mTenDayDu;
        private DateTime mNgaySinh;
        private DateTime mNgayCap;
        private DateTime mNgayHieuLuc;
        private DateTime mNgayHetHan;
        private int mIDDanToc;
        private int mIDNhomBanDoc;
        private int mIDTrinhDo;
        private int mIDNgheNghiep;
        private string mKhoa;
        private string mLop;
        private string mNoiLamViec;
        private bool mGioiTinh;
        private string mDiaChi;
        private string mThanhPho;
        private int mIDTinh;
        private string mSoCMT;
        private string mSoDienThoai;
        private string mEmail;
        private string mGhiChu;
        private string mMaVung;
        private bool mKhoaThe;
        private string mAnhURL;

        public string strBanDocID = "BanDocID";
        public string strSoThe = "SoThe";
        public string strTenDayDu = "TenDayDu";
        public string strNgaySinh = "NgaySinh";
        public string strNgayCap = "NgayCap";
        public string strNgayHieuLuc = "NgayHieuLuc";
        public string strNgayHetHan = "NgayHetHan";
        public string strIDDanToc = "IDDanToc";
        public string strIDNhomBanDoc = "IDNhomBanDoc";
        public string strIDTrinhDo = "IDTrinhDo";
        public string strIDNgheNghiep = "IDNgheNghiep";
        public string strKhoa = "Khoa";
        public string strLop = "Lop";
        public string strNoiLamViec = "NoiLamViec";
        public string strGioiTinh = "GioiTinh";
        public string strDiaChi = "DiaChi";
        public string strThanhPho = "ThanhPho";
        public string strIDTinh = "IDTinh";
        public string strSoCMT = "SoCMT";
        public string strSoDienThoai = "SoDienThoai";
        public string strEmail = "Email";
        public string strGhiChu = "GhiChu";
        public string strMaVung = "MaVung";
        public string strKhoaThe = "KhoaThe";
        public string strAnhURL = "AnhURL";

        public BanDocInfo()
        { }

        public int BanDocID{
        	set{ mBanDocID = value;}
        	get{ return mBanDocID;}
        }
        public string SoThe{
        	set{ mSoThe = value;}
        	get{ return mSoThe;}
        }
        public string TenDayDu{
        	set{ mTenDayDu = value;}
        	get{ return mTenDayDu;}
        }
        public DateTime NgaySinh{
        	set{ mNgaySinh = value;}
        	get{ return mNgaySinh;}
        }
        public DateTime NgayCap{
        	set{ mNgayCap = value;}
        	get{ return mNgayCap;}
        }
        public DateTime NgayHieuLuc{
        	set{ mNgayHieuLuc = value;}
        	get{ return mNgayHieuLuc;}
        }
        public DateTime NgayHetHan{
        	set{ mNgayHetHan = value;}
        	get{ return mNgayHetHan;}
        }
        public int IDDanToc{
        	set{ mIDDanToc = value;}
        	get{ return mIDDanToc;}
        }
        public int IDNhomBanDoc{
        	set{ mIDNhomBanDoc = value;}
        	get{ return mIDNhomBanDoc;}
        }
        public int IDTrinhDo{
        	set{ mIDTrinhDo = value;}
        	get{ return mIDTrinhDo;}
        }
        public int  IDNgheNghiep{
        	set{ mIDNgheNghiep = value;}
        	get{ return mIDNgheNghiep;}
        }
        public string Khoa{
        	set{ mKhoa = value;}
        	get{ return mKhoa;}
        }
        public string Lop{
        	set{ mLop = value;}
        	get{ return mLop;}
        }
        public string NoiLamViec{
        	set{ mNoiLamViec = value;}
        	get{ return mNoiLamViec;}
        }
        public bool GioiTinh{
        	set{ mGioiTinh = value;}
        	get{ return mGioiTinh;}
        }
        public string DiaChi{
        	set{ mDiaChi = value;}
        	get{ return mDiaChi;}
        }
        public string ThanhPho{
        	set{ mThanhPho = value;}
        	get{ return mThanhPho;}
        }
        public int IDTinh{
        	set{ mIDTinh = value;}
        	get{ return mIDTinh;}
        }
        public string SoCMT{
        	set{ mSoCMT = value;}
        	get{ return mSoCMT;}
        }
        public string SoDienThoai{
        	set{ mSoDienThoai = value;}
        	get{ return mSoDienThoai;}
        }
        public string Email{
        	set{ mEmail = value;}
        	get{ return mEmail;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
        public string MaVung{
        	set{ mMaVung = value;}
        	get{ return mMaVung;}
        }
        public bool KhoaThe{
        	set{ mKhoaThe = value;}
        	get{ return mKhoaThe;}
        }
        public string AnhURL{
        	set{ mAnhURL = value;}
        	get{ return mAnhURL;}
        }
    }
}
