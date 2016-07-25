using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class TaiLieu_MarcFieldInfo
    {

        private int mTaiLieu_MarcFieldID;
        private int mIDTaiLieu;
        private int mIDMarcField;
        private string mDisplayEntry;
        private string mAccessEntry;

        public string strTaiLieu_MarcFieldID = "TaiLieu_MarcFieldID";
        public string strIDTaiLieu = "IDTaiLieu";
        public string strIDTruongDublin = "IDMarcField";
        public string strDisplayEntry = "DisplayEntry";
        public string strAccessEntry = "AccessEntry";

        public TaiLieu_MarcFieldInfo()
        { }

        public int TaiLieu_MarcFieldID{
        	set{ mTaiLieu_MarcFieldID = value;}
        	get{ return mTaiLieu_MarcFieldID;}
        }
        public int IDTaiLieu{
        	set{ mIDTaiLieu = value;}
        	get{ return mIDTaiLieu;}
        }
        public int IDMarcField
        {
            set { mIDMarcField = value; }
            get { return mIDMarcField; }
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
