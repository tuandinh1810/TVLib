using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class DanTocInfo
    {

        private int mDanTocID;
        private string mDanToc;

        public string strDanTocID = "DanTocID";
        public string strDanToc = "DanToc";

        public DanTocInfo()
        { }

        public int DanTocID{
        	set{ mDanTocID = value;}
        	get{ return mDanTocID;}
        }
        public string DanToc{
        	set{ mDanToc = value;}
        	get{ return mDanToc;}
        }
    }
}
