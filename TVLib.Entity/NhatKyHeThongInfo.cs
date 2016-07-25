using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public struct NhatKyHeThongInfo
    {

        private int mNhatKy_ID;
        private string mIPMay;
        private string mTenDangNhap;
        private string mCongViec;
        private DateTime mThoiGian;
        private string mEventGroupIDs;
        private string  mLogTimeTo;
        private string mLogTimeFrom;
        private int mIDChucNang;

        public int IDChucNang
        {
            set { mIDChucNang = value; }
            get { return mIDChucNang; }
        }
       public string EventGroupIDs
        {
            set { mEventGroupIDs = value; }
            get { return mEventGroupIDs; }
        }
       public string LogTimeTo
       {
           set { mLogTimeTo = value; }
           get { return mLogTimeTo; }
       }
       public string LogTimeFrom
       {
           set { mLogTimeFrom = value; }
           get { return mLogTimeFrom; }
       }

        public int NhatKy_ID{
        	set{ mNhatKy_ID = value;}
        	get{ return mNhatKy_ID;}
        }
        public string IPMay{
        	set{ mIPMay = value;}
        	get{ return mIPMay;}
        }
        public string TenDangNhap{
        	set{ mTenDangNhap = value;}
        	get{ return mTenDangNhap;}
        }
        public string CongViec{
        	set{ mCongViec = value;}
        	get{ return mCongViec;}
        }
        public DateTime ThoiGian{
        	set{ mThoiGian = value;}
        	get{ return mThoiGian;}
        }
    }
}
