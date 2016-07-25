using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class LienKetFileInfo
    {

        private int mLienKetFileID;
        private int mIDFile1;
        private int mIDFile2;

        public string strLienKetFileID = "LienKetFileID";
        public string strIDFile1 = "IDFile1";
        public string strIDFile2 = "IDFile2";

        public LienKetFileInfo()
        { }

        public int LienKetFileID{
        	set{ mLienKetFileID = value;}
        	get{ return mLienKetFileID;}
        }
        public int IDFile1{
        	set{ mIDFile1 = value;}
        	get{ return mIDFile1;}
        }
        public int IDFile2{
        	set{ mIDFile2 = value;}
        	get{ return mIDFile2;}
        }
    }
}
