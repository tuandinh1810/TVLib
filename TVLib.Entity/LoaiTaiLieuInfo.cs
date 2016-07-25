using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class LoaiTaiLieuInfo
    {

        private int mLoaiTaiLieuID;
        private string mTenLoaiTaiLieu;
        private string mMoTa;

        public string strLoaiTaiLieuID = "LoaiTaiLieuID";
        public string strTenLoaiTaiLieu = "TenLoaiTaiLieu";
        public string strMoTa = "MoTa";

        public LoaiTaiLieuInfo()
        { }

        public int LoaiTaiLieuID{
        	set{ mLoaiTaiLieuID = value;}
        	get{ return mLoaiTaiLieuID;}
        }
        public string TenLoaiTaiLieu{
        	set{ mTenLoaiTaiLieu = value;}
        	get{ return mTenLoaiTaiLieu;}
        }
        public string MoTa{
        	set{ mMoTa = value;}
        	get{ return mMoTa;}
        }
    }
}
