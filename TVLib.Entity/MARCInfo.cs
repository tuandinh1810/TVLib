using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class MARCInfo
    {

        private int mMARCID;
        private string mName;
        private string mCode;

        public string strMARCID = "MARCID";
        public string strName = "Name";
        public string strCode = "Code";

        public MARCInfo()
        { }

        public int MARCID{
        	set{ mMARCID = value;}
        	get{ return mMARCID;}
        }
        public string Name{
        	set{ mName = value;}
        	get{ return mName;}
        }
        public string Code{
        	set{ mCode = value;}
        	get{ return mCode;}
        }
    }
}
