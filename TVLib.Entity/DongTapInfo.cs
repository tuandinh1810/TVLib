using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class DongTapInfo
    {

        private int mDongTapID;
        private int mIDTaiLieu;
        private string mMaXepGia;

        public string strDongTapID = "DongTapID";
        public string strIDTaiLieu = "IDTaiLieu";
        public string strMaXepGia = "MaXepGia";

        public DongTapInfo()
        { }

        public int DongTapID{
        	set{ mDongTapID = value;}
        	get{ return mDongTapID;}
        }
        public int IDTaiLieu{
        	set{ mIDTaiLieu = value;}
        	get{ return mIDTaiLieu;}
        }
        public string MaXepGia{
        	set{ mMaXepGia = value;}
        	get{ return mMaXepGia;}
        }
    }
}
