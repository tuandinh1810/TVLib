using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Entity
{
    public class NguoiDung_PhanHeInfo
    {

        private int mIDNguoiDung;
        private int mIDPhanHe;

        public string strIDNguoiDung = "IDNguoiDung";
        public string strIDPhanHe = "IDPhanHe";

        public NguoiDung_PhanHeInfo()
        { }

        public int IDNguoiDung{
        	set{ mIDNguoiDung = value;}
        	get{ return mIDNguoiDung;}
        }
        public int IDPhanHe{
        	set{ mIDPhanHe = value;}
        	get{ return mIDPhanHe;}
        }
    }
}
