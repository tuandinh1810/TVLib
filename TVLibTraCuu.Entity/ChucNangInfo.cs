using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class ChucNangInfo
    {

        private int mChucNangID;
        private string mMaChucNang;
        private string mTenChucNang;
        private int mIDPhanHe;

        public string strChucNangID = "ChucNangID";
        public string strMaChucNang = "MaChucNang";
        public string strTenChucNang = "TenChucNang";
        public string strIDPhanHe = "IDPhanHe";

        public ChucNangInfo()
        { }

        public int ChucNangID{
        	set{ mChucNangID = value;}
        	get{ return mChucNangID;}
        }
        public string MaChucNang{
        	set{ mMaChucNang = value;}
        	get{ return mMaChucNang;}
        }
        public string TenChucNang{
        	set{ mTenChucNang = value;}
        	get{ return mTenChucNang;}
        }
        public int IDPhanHe{
        	set{ mIDPhanHe = value;}
        	get{ return mIDPhanHe;}
        }
    }
}
