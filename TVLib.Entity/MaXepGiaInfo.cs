using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class MaXepGiaInfo
    {

        private string mMaXepGia;
        private bool mLuuThong;
        private bool mDangMuon;
        private int mIDTaiLieu;
        private int mIDKho;
        private string mShelf;
        private bool mKiemNhan;
        private int mID;

        public string strID = "ID";
        public string strMaXepGia = "MaXepGia";
        public string strLuuThong = "LuuThong";
        public string strDangMuon = "DangMuon";
        public string strIDTaiLieu = "IDTaiLieu";
        public string strShelf = "Shelf";
        public string boolKiemNhan = "KiemNhan";

        public MaXepGiaInfo()
        { }
        public int ID
        {
            set { mID = value; }
            get {return  mID; }
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
        public int IDTaiLieu{
        	set{ mIDTaiLieu = value;}
        	get{ return mIDTaiLieu;}
        }
        public int IDKho
        {
            set { mIDKho = value; }
            get { return mIDKho; }
        }
        public string Shelf
        {
            set 
            {
                mShelf = value;
            }
            get
            {
                return mShelf;
            }
        }
        public bool KiemNhan
        {
            set { mKiemNhan = value; }
            get { return mKiemNhan; }
        }
    }
}
