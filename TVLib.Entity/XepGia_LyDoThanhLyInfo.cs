using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class XepGia_LyDoThanhLyInfo
    {

        private int mLyDoID;
        private string mNoiDungLyDo;

        public string strLyDoID = "LyDoID";
        public string strNoiDungLyDo = "NoiDungLyDo";

        public XepGia_LyDoThanhLyInfo()
        { }

        public int LyDoID{
        	set{ mLyDoID = value;}
        	get{ return mLyDoID;}
        }
        public string NoiDungLyDo{
        	set{ mNoiDungLyDo = value;}
        	get{ return mNoiDungLyDo;}
        }
    }
}
