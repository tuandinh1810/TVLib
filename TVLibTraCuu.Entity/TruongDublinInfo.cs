using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class TruongDublinInfo
    {

        private int mTruongDublinID;
        private string mTenTruongDublin;

        public string strTruongDublinID = "TruongDublinID";
        public string strTenTruongDublin = "TenTruongDublin";

        public TruongDublinInfo()
        { }

        public int TruongDublinID{
        	set{ mTruongDublinID = value;}
        	get{ return mTruongDublinID;}
        }
        public string TenTruongDublin{
        	set{ mTenTruongDublin = value;}
        	get{ return mTenTruongDublin;}
        }
    }
}
