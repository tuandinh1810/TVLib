using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class KyKiemKeInfo
    {

        private int mKyKiemKeID;
        private string mTenKyKiemKe;
        private bool mTrangThai;
        private DateTime mNgayKiemKe;

        public string strKyKiemKeID = "KyKiemKeID";
        public string strTenKyKiemKe = "TenKyKiemKe";
        public string strTrangThai = "TrangThai";
        public string strNgayKiemKe = "NgayKiemKe";

        public KyKiemKeInfo()
        { }

        public int KyKiemKeID{
        	set{ mKyKiemKeID = value;}
        	get{ return mKyKiemKeID;}
        }
        public string TenKyKiemKe{
        	set{ mTenKyKiemKe = value;}
        	get{ return mTenKyKiemKe;}
        }
        public bool TrangThai{
        	set{ mTrangThai = value;}
        	get{ return mTrangThai;}
        }
        public DateTime NgayKiemKe{
        	set{ mNgayKiemKe = value;}
        	get{ return mNgayKiemKe;}
        }
    }
}
