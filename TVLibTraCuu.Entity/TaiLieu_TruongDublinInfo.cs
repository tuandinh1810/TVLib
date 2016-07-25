using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class TaiLieu_TruongDublinInfo
    {

        private int mTaiLieu_TruongDublin_ID;
        private int mIDTaiLieu;
        private int mIDTruongDublin;
        private string mDisplayEntry;
        private string mAccessEntry;

        public string strTaiLieu_TruongDublin_ID = "TaiLieu_TruongDublin_ID";
        public string strIDTaiLieu = "IDTaiLieu";
        public string strIDTruongDublin = "IDTruongDublin";
        public string strDisplayEntry = "DisplayEntry";
        public string strAccessEntry = "AccessEntry";

        public TaiLieu_TruongDublinInfo()
        { }

        public int TaiLieu_TruongDublin_ID{
        	set{ mTaiLieu_TruongDublin_ID = value;}
        	get{ return mTaiLieu_TruongDublin_ID;}
        }
        public int IDTaiLieu{
        	set{ mIDTaiLieu = value;}
        	get{ return mIDTaiLieu;}
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
