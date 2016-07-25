using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class QuaTrinhNapTienInfo
    {

        private int mQuaTrinhNapTienID;
        private int mIDTaiKhoan;
        private DateTime mNgayNapTien;
        private float mSoTienNap;
        private string mGhiChu;

        public string strQuaTrinhNapTienID = "QuaTrinhNapTienID";
        public string strIDTaiKhoan = "IDTaiKhoan";
        public string strNgayNapTien = "NgayNapTien";
        public string strSoTienNap = "SoTienNap";
        public string strGhiChu = "GhiChu";

        public QuaTrinhNapTienInfo()
        { }

        public int QuaTrinhNapTienID{
        	set{ mQuaTrinhNapTienID = value;}
        	get{ return mQuaTrinhNapTienID;}
        }
        public int IDTaiKhoan{
        	set{ mIDTaiKhoan = value;}
        	get{ return mIDTaiKhoan;}
        }
        public DateTime NgayNapTien{
        	set{ mNgayNapTien = value;}
        	get{ return mNgayNapTien;}
        }
        public float SoTienNap{
        	set{ mSoTienNap = value;}
        	get{ return mSoTienNap;}
        }
        public string GhiChu
        {
            set { mGhiChu = value; }
            get { return mGhiChu; }
        }
    }
}
