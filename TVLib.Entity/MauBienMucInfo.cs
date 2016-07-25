using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class MauBienMucInfo
    {

        private int mMauBienMucID;
        private string mTen;
        private int mIDNguoiDung;
        private DateTime mNgayTao;
        private DateTime mNgaySuaCuoi;

        public string strMauBienMucID = "MauBienMucID";
        public string strTen = "Ten";
        public string strIDNguoiDung = "IDNguoiDung";
        public string strNgayTao = "NgayTao";
        public string strNgaySuaCuoi = "NgaySuaCuoi";

        public MauBienMucInfo()
        { }

        public int MauBienMucID{
        	set{ mMauBienMucID = value;}
        	get{ return mMauBienMucID;}
        }
        public string Ten{
        	set{ mTen = value;}
        	get{ return mTen;}
        }
        public int IDNguoiDung{
        	set{ mIDNguoiDung = value;}
        	get{ return mIDNguoiDung;}
        }
        public DateTime NgayTao{
        	set{ mNgayTao = value;}
        	get{ return mNgayTao;}
        }
        public DateTime NgaySuaCuoi{
        	set{ mNgaySuaCuoi = value;}
        	get{ return mNgaySuaCuoi;}
        }
    }
}
