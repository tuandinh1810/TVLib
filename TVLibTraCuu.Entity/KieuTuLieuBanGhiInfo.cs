using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class KieuTuLieuBanGhiInfo
    {

        private int mKieuTuLieuBanGhiID;
        private string mTenKieuTuLieuBanGhi;

        public string strKieuTuLieuBanGhiID = "KieuTuLieuBanGhiID";
        public string strTenKieuTuLieuBanGhi = "TenKieuTuLieuBanGhi";

        public KieuTuLieuBanGhiInfo()
        { }

        public int KieuTuLieuBanGhiID{
        	set{ mKieuTuLieuBanGhiID = value;}
        	get{ return mKieuTuLieuBanGhiID;}
        }
        public string TenKieuTuLieuBanGhi{
        	set{ mTenKieuTuLieuBanGhi = value;}
        	get{ return mTenKieuTuLieuBanGhi;}
        }
    }
}
