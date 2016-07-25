using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class TaiLieuMuonInfo
    {

        private string mMaXepGia;
        private DateTime mNgayMuon;
        private DateTime mNgayPhaiTra;
        private int mIDBanDoc;
        private int mSoLanGiaHan;
        private float mPhiMuon;

        public string strMaXepGia = "MaXepGia";
        public string strNgayMuon = "NgayMuon";
        public string strNgayPhaiTra = "NgayPhaiTra";
        public string strIDBanDoc = "IDBanDoc";
        public string strSoLanGiaHan = "SoLanGiaHan";
        public string strPhiMuon = "PhiMuon";

        public TaiLieuMuonInfo()
        { }

        public string MaXepGia{
        	set{ mMaXepGia = value;}
        	get{ return mMaXepGia;}
        }
        public DateTime NgayMuon{
        	set{ mNgayMuon = value;}
        	get{ return mNgayMuon;}
        }
        public DateTime NgayPhaiTra{
        	set{ mNgayPhaiTra = value;}
        	get{ return mNgayPhaiTra;}
        }
        public int IDBanDoc{
        	set{ mIDBanDoc = value;}
        	get{ return mIDBanDoc;}
        }
        public int SoLanGiaHan
        {
            set { mSoLanGiaHan  = value; }
            get { return mSoLanGiaHan; }
        }
        public float PhiMuon
        {
            set { mPhiMuon = value; }
            get { return mPhiMuon; }
        }
    }
}
