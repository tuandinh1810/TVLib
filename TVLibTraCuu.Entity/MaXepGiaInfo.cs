using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class MaXepGiaInfo
    {

        private string mMaXepGia;
        private bool mLuuThong;
        private bool mDangMuon;
        private int mIDTaiLieu;

        public string strMaXepGia = "MaXepGia";
        public string strLuuThong = "LuuThong";
        public string strDangMuon = "DangMuon";
        public string strIDTaiLieu = "IDTaiLieu";

        public MaXepGiaInfo()
        { }

        public string MaXepGia{
        	set{ mMaXepGia = value;}
        	get{ return mMaXepGia;}
        }
        public bool LuuThong{
        	set{ mLuuThong = value;}
        	get{ return mLuuThong;}
        }
        public bool DangMuon{
        	set{ mDangMuon = value;}
        	get{ return mDangMuon;}
        }
        public int IDTaiLieu{
        	set{ mIDTaiLieu = value;}
        	get{ return mIDTaiLieu;}
        }
    }
}
