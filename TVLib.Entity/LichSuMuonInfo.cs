using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class LichSuMuonInfo
    {

        private string mMaXepGia;
        private DateTime mNgayMuon;
        private DateTime mNgayTra;
        private int mIDBanDoc;
        private int mSoNgayQuaHan;
        private float mSoTienPhat;

        public string strMaXepGia = "MaXepGia";
        public string strNgayMuon = "NgayMuon";
        public string strNgayTra = "NgayTra";
        public string strIDBanDoc = "IDBanDoc";
        public string strSoNgayQuaHan = "SoNgayQuaHan";
        public string strSoTienPhat = "SoTienPhat";

        public LichSuMuonInfo()
        { }

        public string MaXepGia{
        	set{ mMaXepGia = value;}
        	get{ return mMaXepGia;}
        }
        public DateTime NgayMuon{
        	set{ mNgayMuon = value;}
        	get{ return mNgayMuon;}
        }
        public DateTime NgayTra{
        	set{ mNgayTra = value;}
        	get{ return mNgayTra;}
        }
        public int IDBanDoc{
        	set{ mIDBanDoc = value;}
        	get{ return mIDBanDoc;}
        }
        public int SoNgayQuaHan{
        	set{ mSoNgayQuaHan = value;}
        	get{ return mSoNgayQuaHan;}
        }
        public float SoTienPhat{
        	set{ mSoTienPhat = value;}
        	get{ return mSoTienPhat;}
        }
    }
}
