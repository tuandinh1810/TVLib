using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class TinhInfo
    {

        private int mTinhID;
        private string mTenTinh;

        public string strTinhID = "TinhID";
        public string strTenTinh = "TenTinh";

        public TinhInfo()
        { }

        public int TinhID{
        	set{ mTinhID = value;}
        	get{ return mTinhID;}
        }
        public string TenTinh{
        	set{ mTenTinh = value;}
        	get{ return mTenTinh;}
        }
    }
}
