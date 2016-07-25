using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class MauBienMuc_ChiTietInfo
    {

        private int mID;
        private int mIDMARC_FIELD;
        private string mGiaTriMacDinh;
        private int mIDMauBienMuc;

        public string strID = "ID";
        public string strIDMARC_FIELD = "IDMARC_FIELD";
        public string strGiaTriMacDinh = "GiaTriMacDinh";
        public string strIDMauBienMuc = "IDMauBienMuc";

        public MauBienMuc_ChiTietInfo()
        { }

        public int ID{
        	set{ mID = value;}
        	get{ return mID;}
        }
        public int IDMARC_FIELD{
        	set{ mIDMARC_FIELD = value;}
        	get{ return mIDMARC_FIELD;}
        }
        public string GiaTriMacDinh{
        	set{ mGiaTriMacDinh = value;}
        	get{ return mGiaTriMacDinh;}
        }
        public int IDMauBienMuc{
        	set{ mIDMauBienMuc = value;}
        	get{ return mIDMauBienMuc;}
        }
    }
}
