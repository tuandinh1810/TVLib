using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class NgheNghiepInfo
    {

        private int mNgheNghiepID;
        private string mTenNgheNghiep;

        public string strNgheNghiepID = "NgheNghiepID";
        public string strTenNgheNghiep = "TenNgheNghiep";

        public NgheNghiepInfo()
        { }

        public int NgheNghiepID{
        	set{ mNgheNghiepID = value;}
        	get{ return mNgheNghiepID;}
        }
        public string TenNgheNghiep{
        	set{ mTenNgheNghiep = value;}
        	get{ return mTenNgheNghiep;}
        }
    }
}
