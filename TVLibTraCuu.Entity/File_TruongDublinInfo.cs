using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class File_TruongDublinInfo
    {

        private int mFile_TruongDublin_ID;
        private int mIDFile;
        private int mIDTruongDublin;
        private string mDisplayEntry;
        private string mAccessEntry;

        public string strFile_TruongDublin_ID = "File_TruongDublin_ID";
        public string strIDFile = "IDFile";
        public string strIDTruongDublin = "IDTruongDublin";
        public string strDisplayEntry = "DisplayEntry";
        public string strAccessEntry = "AccessEntry";

        public File_TruongDublinInfo()
        { }

        public int File_TruongDublin_ID{
        	set{ mFile_TruongDublin_ID = value;}
        	get{ return mFile_TruongDublin_ID;}
        }
        public int IDFile{
        	set{ mIDFile = value;}
        	get{ return mIDFile;}
        }
        public int IDTruongDublin{
        	set{ mIDTruongDublin = value;}
        	get{ return mIDTruongDublin;}
        }
        public string DisplayEntry{
        	set{ mDisplayEntry = value;}
        	get{ return mDisplayEntry;}
        }
        public string AccessEntry{
        	set{ mAccessEntry = value;}
        	get{ return mAccessEntry;}
        }
    }
}
