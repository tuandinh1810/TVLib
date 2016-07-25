using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class MARC_FIELD_TYPEInfo
    {

        private int mID;
        private string mFieldType;

        public string strID = "ID";
        public string strFieldType = "FieldType";

        public MARC_FIELD_TYPEInfo()
        { }

        public int ID{
        	set{ mID = value;}
        	get{ return mID;}
        }
        public string FieldType{
        	set{ mFieldType = value;}
        	get{ return mFieldType;}
        }
    }
}
