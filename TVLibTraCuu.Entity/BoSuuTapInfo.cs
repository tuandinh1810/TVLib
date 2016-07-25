using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class BoSuuTapInfo
    {

        private int mBoSuuTapID;
        private string mTenBoSuuTap;
        private string mMoTa;

        public string strBoSuuTapID = "BoSuuTapID";
        public string strTenBoSuuTap = "TenBoSuuTap";
        public string strMoTa = "MoTa";

        public BoSuuTapInfo()
        { }

        public int BoSuuTapID{
        	set{ mBoSuuTapID = value;}
        	get{ return mBoSuuTapID;}
        }
        public string TenBoSuuTap{
        	set{ mTenBoSuuTap = value;}
        	get{ return mTenBoSuuTap;}
        }
        public string MoTa{
        	set{ mMoTa = value;}
        	get{ return mMoTa;}
        }
    }
}
