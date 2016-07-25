using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class TemplateInfo
    {

        private int mTemplateID;
        private string mTenTemplate;
        private string mGiaTri;

        public string strTemplateID = "TemplateID";
        public string strTenTemplate = "TenTemplate";
        public string strGiaTri = "GiaTri";

        public TemplateInfo()
        { }

        public int TemplateID{
        	set{ mTemplateID = value;}
        	get{ return mTemplateID;}
        }
        public string TenTemplate{
        	set{ mTenTemplate = value;}
        	get{ return mTenTemplate;}
        }
        public string GiaTri{
        	set{ mGiaTri = value;}
        	get{ return mGiaTri;}
        }
    }
}
