using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class TaiKhoan_FileInfo
    {

        private int mTaiKhoanFileID;
        private int mIDTaiKhoan;
        private int mIDFile;
        private DateTime mNgayDowloadFile;
        private float mChiPhi;

        public string strTaiKhoanFileID = "TaiKhoanFileID";
        public string strIDTaiKhoan = "IDTaiKhoan";
        public string strIDFile = "IDFile";
        public string strNgayDowloadFile = "NgayDowloadFile";
        public string strChiPhi = "ChiPhi";

        public TaiKhoan_FileInfo()
        { }

        public int TaiKhoanFileID{
        	set{ mTaiKhoanFileID = value;}
        	get{ return mTaiKhoanFileID;}
        }
        public int IDTaiKhoan{
        	set{ mIDTaiKhoan = value;}
        	get{ return mIDTaiKhoan;}
        }
        public int IDFile{
        	set{ mIDFile = value;}
        	get{ return mIDFile;}
        }
        public DateTime NgayDowloadFile{
        	set{ mNgayDowloadFile = value;}
        	get{ return mNgayDowloadFile;}
        }
        public float ChiPhi{
        	set{ mChiPhi = value;}
        	get{ return mChiPhi;}
        }
    }
}
