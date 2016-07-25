using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class KhoInfo
    {

        private int mKhoID;
        private string mMaKho;
        private string mTenKho;
        private int mIDThuVien;

        public string strKhoID = "KhoID";
        public string strMaKho = "MaKho";
        public string strTenKho = "TenKho";
        public string strIDThuVien = "IDThuVien";

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
    }
}
