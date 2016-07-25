using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class TaiLieuInfo
    {

        private int mTaiLieuID;
        private bool mLuuThong;
        private int mIDKieuTuLieuBanGhi;
        private int mCapDoMat;
        private float mGiaTien;
        private int mIDNguoiNhapTin;
        private int mIDLoaiTaiLieu;
        private int mIDMauBienMuc;
        private string mMaTaiLieu;

        public string strTaiLieuID = "TaiLieuID";
        public string strLuuThong = "LuuThong";
        public string strIDKieuTuLieuBanGhi = "IDKieuTuLieuBanGhi";
        public string strCapDoMat = "CapDoMat";
        public string strGiaTien = "GiaTien";
        public string strIDNguoiNhapTin = "IDNguoiNhapTin";
        public string strIDLoaiTaiLieu = "IDLoaiTaiLieu";
        public string strIDMauBienMuc = "IDMauBienMuc";
        public string strMaTaiLieu = "MaTaiLieu";

        public TaiLieuInfo()
        { }
        public string MaTaiLieu
        {
            set { mMaTaiLieu = value; }
            get { return mMaTaiLieu; }
        }

        public int TaiLieuID{
        	set{ mTaiLieuID = value;}
        	get{ return mTaiLieuID;}
        }
        public bool LuuThong{
        	set{ mLuuThong = value;}
        	get{ return mLuuThong;}
        }
        public int IDKieuTuLieuBanGhi{
        	set{ mIDKieuTuLieuBanGhi = value;}
        	get{ return mIDKieuTuLieuBanGhi;}
        }
        public int CapDoMat{
        	set{ mCapDoMat = value;}
        	get{ return mCapDoMat;}
        }
        public float GiaTien{
        	set{ mGiaTien = value;}
        	get{ return mGiaTien;}
        }
        public int IDNguoiNhapTin{
        	set{ mIDNguoiNhapTin = value;}
        	get{ return mIDNguoiNhapTin;}
        }
        public int IDMauBienMuc
        {
            set { mIDMauBienMuc = value; }
            get { return mIDMauBienMuc; }
        }
        public int IDLoaiTaiLieu{
        	set{ mIDLoaiTaiLieu = value;}
        	get{ return mIDLoaiTaiLieu;}
        }
    }
}
