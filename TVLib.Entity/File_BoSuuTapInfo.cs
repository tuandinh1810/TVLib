using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class File_BoSuuTapInfo
    {

        private int mFile_BoSuuTapID;
        private int mIDFile;
        private int mIDBoSuuTap;

        public string strFile_BoSuuTapID = "File_BoSuuTapID";
        public string strIDFile = "IDFile";
        public string strIDBoSuuTap = "IDBoSuuTap";

        public File_BoSuuTapInfo()
        { }

        public int File_BoSuuTapID{
        	set{ mFile_BoSuuTapID = value;}
        	get{ return mFile_BoSuuTapID;}
        }
        public int IDFile{
        	set{ mIDFile = value;}
        	get{ return mIDFile;}
        }
        public int IDBoSuuTap{
        	set{ mIDBoSuuTap = value;}
        	get{ return mIDBoSuuTap;}
        }
    }
}
