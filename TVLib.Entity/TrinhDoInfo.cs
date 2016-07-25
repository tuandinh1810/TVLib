using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class TrinhDoInfo
    {

        private int mTrinhDoID;
        private string mTrinhDo;

        public string strTrinhDoID = "TrinhDoID";
        public string strTrinhDo = "TrinhDo";

        public TrinhDoInfo()
        { }

        public int TrinhDoID{
        	set{ mTrinhDoID = value;}
        	get{ return mTrinhDoID;}
        }
        public string TrinhDo{
        	set{ mTrinhDo = value;}
        	get{ return mTrinhDo;}
        }
    }
}
