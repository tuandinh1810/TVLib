using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class LoaiTienInfo
    {

        private int mLoaiTienID;
        private string mLoaiTien;
        private float mTyGia;

        public string strLoaiTienID = "LoaiTienID";
        public string strLoaiTien = "LoaiTien";
        public string strTyGia = "TyGia";

        public LoaiTienInfo()
        { }

        public int LoaiTienID{
        	set{ mLoaiTienID = value;}
        	get{ return mLoaiTienID;}
        }
        public string LoaiTien{
        	set{ mLoaiTien = value;}
        	get{ return mLoaiTien;}
        }
        public float TyGia{
        	set{ mTyGia = value;}
        	get{ return mTyGia;}
        }
    }
}
