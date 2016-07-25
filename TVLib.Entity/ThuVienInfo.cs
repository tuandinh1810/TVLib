using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class ThuVienInfo
    {

        private int mThuVienID;
        private string mTenThuVien;
        private string mMaThuVien;

        public string strThuVienID = "ThuVienID";
        public string strTenThuVien = "TenThuVien";
        public string strMaThuVien = "MaThuVien";

        public ThuVienInfo()
        { }

        public int ThuVienID{
        	set{ mThuVienID = value;}
        	get{ return mThuVienID;}
        }
        public string TenThuVien{
        	set{ mTenThuVien = value;}
        	get{ return mTenThuVien;}
        }
        public string MaThuVien{
        	set{ mMaThuVien = value;}
        	get{ return mMaThuVien;}
        }
    }
}
