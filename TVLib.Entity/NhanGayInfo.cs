using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class NhanGayInfo
    {

        private int mNhanGayID;
        private string mTenNhanGay;
        private string mNoiDung;

        public string strNhanGayID = "NhanGayID";
        public string strTenNhanGay = "TenNhanGay";
        public string strNoiDung = "NoiDung";

        public NhanGayInfo()
        { }

        public int NhanGayID{
        	set{ mNhanGayID = value;}
        	get{ return mNhanGayID;}
        }
        public string TenNhanGay{
        	set{ mTenNhanGay = value;}
        	get{ return mTenNhanGay;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
    }
}
