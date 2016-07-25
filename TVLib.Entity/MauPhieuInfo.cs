using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class MauPhieuInfo
    {

        private int mMauPhieuID;
        private string mTenMauPhieu;
        private string mNoiDung;
        private DateTime mNgayTao;
        private int mLoaiPhieu;

        public string strMauPhieuID = "MauPhieuID";
        public string strTenMauPhieu = "TenMauPhieu";
        public string strNoiDung = "NoiDung";
        public string strNgayTao = "NgayTao";
        public string strLoaiPhieu = "LoaiPhieu";

        public MauPhieuInfo()
        { }

        public int MauPhieuID{
        	set{ mMauPhieuID = value;}
        	get{ return mMauPhieuID;}
        }
        public string TenMauPhieu{
        	set{ mTenMauPhieu = value;}
        	get{ return mTenMauPhieu;}
        }
        public string NoiDung{
        	set{ mNoiDung = value;}
        	get{ return mNoiDung;}
        }
        public DateTime NgayTao{
        	set{ mNgayTao = value;}
        	get{ return mNgayTao;}
        }
        public int LoaiPhieu{
        	set{ mLoaiPhieu = value;}
        	get{ return mLoaiPhieu;}
        }
    }
}
