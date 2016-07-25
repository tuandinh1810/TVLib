using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class BanDoc_KhoaTheInfo
    {

        private int mBanDocID;
        private DateTime mNgayBatDau;
        private int mSoNgay;
        private DateTime mNgayKetThuc;
        private string mGhiChu;

        public string strBanDocID = "BanDocID";
        public string strNgayBatDau = "NgayBatDau";
        public string strSoNgay = "SoNgay";
        public string strNgayKetThuc = "NgayKetThuc";
        public string strGhiChu = "GhiChu";

        public BanDoc_KhoaTheInfo()
        { }

        public int BanDocID{
        	set{ mBanDocID = value;}
        	get{ return mBanDocID;}
        }
        public DateTime NgayBatDau{
        	set{ mNgayBatDau = value;}
        	get{ return mNgayBatDau;}
        }
        public int SoNgay{
        	set{ mSoNgay = value;}
        	get{ return mSoNgay;}
        }
        public DateTime NgayKetThuc{
        	set{ mNgayKetThuc = value;}
        	get{ return mNgayKetThuc;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
    }
}
