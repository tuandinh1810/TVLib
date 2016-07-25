using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class NguoiDung_ChucNangInfo
    {

        private int mNguoiDung_ChucNang_ID;
        private int mIDNguoiDung;
        private int mIDChucNang;

        public string strNguoiDung_ChucNang_ID = "NguoiDung_ChucNang_ID";
        public string strIDNguoiDung = "IDNguoiDung";
        public string strIDChucNang = "IDChucNang";

        public NguoiDung_ChucNangInfo()
        { }

        public int NguoiDung_ChucNang_ID{
        	set{ mNguoiDung_ChucNang_ID = value;}
        	get{ return mNguoiDung_ChucNang_ID;}
        }
        public int IDNguoiDung{
        	set{ mIDNguoiDung = value;}
        	get{ return mIDNguoiDung;}
        }
        public int IDChucNang{
        	set{ mIDChucNang = value;}
        	get{ return mIDChucNang;}
        }
    }
}
