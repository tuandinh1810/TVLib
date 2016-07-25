using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class YeuCauMuonInfo
    {

        private int mYeuCauMuonID;
        private int? mIDBanDoc;
        private DateTime? mNgayYeuCau;
        private int? mIDTaiLieu;

        public string strYeuCauMuonID = "YeuCauMuonID";
        public string strIDBanDoc = "IDBanDoc";
        public string strNgayYeuCau = "NgayYeuCau";
        public string strIDTaiLieu = "IDTaiLieu";

        public YeuCauMuonInfo()
        { }

        public int YeuCauMuonID{
        	set{ mYeuCauMuonID = value;}
        	get{ return mYeuCauMuonID;}
        }
        public int? IDBanDoc{
        	set{ mIDBanDoc = value;}
        	get{ return mIDBanDoc;}
        }
        public DateTime? NgayYeuCau{
        	set{ mNgayYeuCau = value;}
        	get{ return mNgayYeuCau;}
        }
        public int? IDTaiLieu{
        	set{ mIDTaiLieu = value;}
        	get{ return mIDTaiLieu;}
        }
    }
}
