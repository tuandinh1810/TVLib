using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class NhomBanDocInfo
    {

        private int mNhomBanDocID;
        private string mTenNhomBanDoc;
        private int mSoSachMuon;
        private int mSoSachDatCho;
        private string mCacKhoDuocMuon;
        private int mCapDoMat;

        public string strNhomBanDocID = "NhomBanDocID";
        public string strTenNhomBanDoc = "TenNhomBanDoc";
        public string strSoSachMuon = "SoSachMuon";
        public string strSoSachDatCho = "SoSachDatCho";
        public string strCacKhoDuocMuon = "CacKhoDuocMuon";
        public string strCapDoMat = "CapDoMat";

        public NhomBanDocInfo()
        { }

        public int NhomBanDocID{
        	set{ mNhomBanDocID = value;}
        	get{ return mNhomBanDocID;}
        }
      
        public string TenNhomBanDoc{
        	set{ mTenNhomBanDoc = value;}
        	get{ return mTenNhomBanDoc;}
        }
        public int SoSachMuon{
        	set{ mSoSachMuon = value;}
        	get{ return mSoSachMuon;}
        }
        public int SoSachDatCho{
        	set{ mSoSachDatCho = value;}
        	get{ return mSoSachDatCho;}
        }
        public string CacKhoDuocMuon{
        	set{ mCacKhoDuocMuon = value;}
        	get{ return mCacKhoDuocMuon;}
        }
        public int CapDoMat
        {
            set { mCapDoMat = value; }
            get { return mCapDoMat; }
        }
    }
}
