using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class MauPhichInfo
    {

        private int mMauPhichID;
        private string mTenMauPhich;
        private string mGiaTri;

        public string strMauPhichID = "MauPhichID";
        public string strTenMauPhich = "TenMauPhich";
        public string strGiaTri = "GiaTri";

        public MauPhichInfo()
        { }

        public int MauPhichID{
        	set{ mMauPhichID = value;}
        	get{ return mMauPhichID;}
        }
        public string TenMauPhich{
        	set{ mTenMauPhich = value;}
        	get{ return mTenMauPhich;}
        }
        public string GiaTri{
        	set{ mGiaTri = value;}
        	get{ return mGiaTri;}
        }
    }
}
