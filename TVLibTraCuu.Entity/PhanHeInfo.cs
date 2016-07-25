using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class PhanHeInfo
    {

        private int mPhanHeID;
        private string mTenPhanHe;

        public string strPhanHeID = "PhanHeID";
        public string strTenPhanHe = "TenPhanHe";

        public PhanHeInfo()
        { }

        public int PhanHeID{
        	set{ mPhanHeID = value;}
        	get{ return mPhanHeID;}
        }
        public string TenPhanHe{
        	set{ mTenPhanHe = value;}
        	get{ return mTenPhanHe;}
        }
    }
}
