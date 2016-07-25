using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class NhatKyHeThongInfo
    {

        private int mNhatKy_ID;
        private string mIPMay;
        private string mTenDangNhap;
        private string mCongViec;
        private DateTime mThoiGian;
        private int mID_ChucNang;

        public string strNhatKy_ID = "NhatKy_ID";
        public string strIPMay = "IPMay";
        public string strTenDangNhap = "TenDangNhap";
        public string strCongViec = "CongViec";
        public string strThoiGian = "ThoiGian";
        public string strID_ChucNang = "ID_ChucNang";

        public NhatKyHeThongInfo()
        { }

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
        public int ID_ChucNang{
        	set{ mID_ChucNang = value;}
        	get{ return mID_ChucNang;}
        }
    }
}
