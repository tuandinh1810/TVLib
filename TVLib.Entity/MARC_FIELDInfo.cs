using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class MARC_FIELDInfo
    {

        private int mMARC_FIELD_ID;
        private string mName;
        private string mCode;
        private int mID_MARC;
        private bool mRepeat;
        private int mID_FieldType;
        private int mParentID;

        public string strMARC_FIELD_ID = "MARC_FIELD_ID";
        public string strName = "Name";
        public string strCode = "Code";
        public string strID_MARC = "ID_MARC";
        public string strRepeat = "Repeat";
        public string strID_FieldType = "ID_FieldType";
        public string strParentID = "ParentID";

        public MARC_FIELDInfo()
        { }

        public int MARC_FIELD_ID{
        	set{ mMARC_FIELD_ID = value;}
        	get{ return mMARC_FIELD_ID;}
        }
        public string Name{
        	set{ mName = value;}
        	get{ return mName;}
        }
        public string Code{
        	set{ mCode = value;}
        	get{ return mCode;}
        }
        public int ID_MARC{
        	set{ mID_MARC = value;}
        	get{ return mID_MARC;}
        }
        public bool Repeat{
        	set{ mRepeat = value;}
        	get{ return mRepeat;}
        }
        public int ID_FieldType{
        	set{ mID_FieldType = value;}
        	get{ return mID_FieldType;}
        }
        public int ParentID{
        	set{ mParentID = value;}
        	get{ return mParentID;}
        }
    }
}
