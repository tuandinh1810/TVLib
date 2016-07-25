using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class XepGia_ThanhLyInfo
    {

        private int mID;
        private string mMaXepGia;
        private bool mLuuThong;
        private bool mDangMuon;
        private string mShelf;
        private bool mKiemNhan;
        private DateTime mNgayThanhLy;
        private DateTime mNgayXepGia;
        private int mIDTaiLieu;
        private int mIDKho;
        private int mIDLyDoThanhLy;

        public string strID = "ID";
        public string strMaXepGia = "MaXepGia";
        public string strLuuThong = "LuuThong";
        public string strDangMuon = "DangMuon";
        public string strShelf = "Shelf";
        public string strKiemNhan = "KiemNhan";
        public string strNgayThanhLy = "NgayThanhLy";
        public string strNgayXepGia = "NgayXepGia";
        public string strIDTaiLieu = "IDTaiLieu";
        public string strIDKho = "IDKho";
        public string strIDLyDoThanhLy = "IDLyDoThanhLy";

        public XepGia_ThanhLyInfo()
        { }

        public int ID{
        	set{ mID = value;}
        	get{ return mID;}
        }
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
        public string Shelf{
        	set{ mShelf = value;}
        	get{ return mShelf;}
        }
        public bool KiemNhan{
        	set{ mKiemNhan = value;}
        	get{ return mKiemNhan;}
        }
        public DateTime NgayThanhLy{
        	set{ mNgayThanhLy = value;}
        	get{ return mNgayThanhLy;}
        }
        public DateTime NgayXepGia{
        	set{ mNgayXepGia = value;}
        	get{ return mNgayXepGia;}
        }
        public int IDTaiLieu{
        	set{ mIDTaiLieu = value;}
        	get{ return mIDTaiLieu;}
        }
        public int IDKho{
        	set{ mIDKho = value;}
        	get{ return mIDKho;}
        }
        public int IDLyDoThanhLy{
        	set{ mIDLyDoThanhLy = value;}
        	get{ return mIDLyDoThanhLy;}
        }
    }
}
