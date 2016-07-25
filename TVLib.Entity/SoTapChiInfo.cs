using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class SoTapChiInfo
    {

        private int mSoTapChiID;
        private int mIDTaiLieu;
        private string mNamPhatHanh;
        private string mSoTheoNam;
        private string mSoToanCuc;
        private DateTime mNgayPhatHanh;
        private double? mDonGia;
        private string mTomTat;
        private string mGhiChu;
        private int? mIDDongTap;

        public string strSoTapChiID = "SoTapChiID";
        public string strIDTaiLieu = "IDTaiLieu";
        public string strNamPhatHanh = "NamPhatHanh";
        public string strSoTheoNam = "SoTheoNam";
        public string strSoToanCuc = "SoToanCuc";
        public string strNgayPhatHanh = "NgayPhatHanh";
        public string strDonGia = "DonGia";
        public string strTomTat = "TomTat";
        public string strGhiChu = "GhiChu";
        public string strIDDongTap = "IDDongTap";

        public SoTapChiInfo()
        { }

        public int SoTapChiID{
        	set{ mSoTapChiID = value;}
        	get{ return mSoTapChiID;}
        }
        public int IDTaiLieu{
        	set{ mIDTaiLieu = value;}
        	get{ return mIDTaiLieu;}
        }
        public string NamPhatHanh{
        	set{ mNamPhatHanh = value;}
        	get{ return mNamPhatHanh;}
        }
        public string SoTheoNam{
        	set{ mSoTheoNam = value;}
        	get{ return mSoTheoNam;}
        }
        public string SoToanCuc{
        	set{ mSoToanCuc = value;}
        	get{ return mSoToanCuc;}
        }
        public DateTime NgayPhatHanh{
        	set{ mNgayPhatHanh = value;}
        	get{ return mNgayPhatHanh;}
        }
        public double? DonGia{
        	set{ mDonGia = value;}
        	get{ return mDonGia;}
        }
        public string TomTat{
        	set{ mTomTat = value;}
        	get{ return mTomTat;}
        }
        public string GhiChu{
        	set{ mGhiChu = value;}
        	get{ return mGhiChu;}
        }
        public int? IDDongTap{
        	set{ mIDDongTap = value;}
        	get{ return mIDDongTap;}
        }
    }
}
