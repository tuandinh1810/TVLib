using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class KhoInfo
    {

        private int mKhoID;
        private string mMaKho;
        private string mTenKho;
        private int mIDThuVien;
        private int mMXG;
        public string strKhoID = "KhoID";
        public string strMaKho = "MaKho";
        public string strTenKho = "TenKho";
        public string strIDThuVien = "IDThuVien";
        public int intSTTMXG = 0;
        public KhoInfo()
        { }

        public int KhoID{
        	set{ mKhoID = value;}
        	get{ return mKhoID;}
        }
        public string MaKho{
        	set{ mMaKho = value;}
        	get{ return mMaKho;}
        }
        public string TenKho{
        	set{ mTenKho = value;}
        	get{ return mTenKho;}
        }
        public int IDThuVien{
        	set{ mIDThuVien = value;}
        	get{ return mIDThuVien;}
        }
        public int STTMGX
        {
            set { mMXG = value; }
            get { return mMXG; }
        }
    }
}
