using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class TinTucInfo
    {

        private int mTinTucID;
        private string mTieuDe;
        private string mLoai;
        private string mURL;
        private string mTomTat;
        private string mNoiDung;
        private DateTime mNgayCapNhat;
        private bool mDuyet;
        private int mNgonNgu;
        private int mUuTien;
        private int mIDParent;

        public string strTinTucID = "TinTucID";
        public string strTieuDe = "TieuDe";
        public string strLoai = "Loai";
        public string strURL = "URL";
        public string strTomTat = "TomTat";
        public string strNoiDung = "NoiDung";
        public string strNgayCapNhat = "NgayCapNhat";
        public string strDuyet = "Duyet";
        public string strNgonNgu = "NgonNgu";
        public string strUuTien = "UuTien";
        public string strIDParent = "IDParent";

        public TinTucInfo()
        { }

        public int TinTucID{
        	set{ mTinTucID = value;}
        	get{ return mTinTucID;}
        }
        public string TieuDe{
        	set{ mTieuDe = value;}
        	get{ return mTieuDe;}
        }
        public string Loai{
        	set{ mLoai = value;}
        	get{ return mLoai;}
        }
        public string URL{
        	set{ mURL = value;}
        	get{ return mURL;}
        }
        public string TomTat{
        	set{ mTomTat = value;}
        	get{ return mTomTat;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
        public DateTime NgayCapNhat{
        	set{ mNgayCapNhat = value;}
        	get{ return mNgayCapNhat;}
        }
        public bool Duyet{
        	set{ mDuyet = value;}
        	get{ return mDuyet;}
        }
        public int NgonNgu{
        	set{ mNgonNgu = value;}
        	get{ return mNgonNgu;}
        }
        public int UuTien{
        	set{ mUuTien = value;}
        	get{ return mUuTien;}
        }
        public int IDParent{
        	set{ mIDParent = value;}
        	get{ return mIDParent;}
        }
    }
}
