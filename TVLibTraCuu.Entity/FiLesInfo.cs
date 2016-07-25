using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Entity
{
    public class FiLesInfo
    {

        private int mFileID;
        private int mKichCoFile;
        private DateTime mNgayUpLoad;
        private string mNguoiUpLoad;
        private string mTenFile;
        private string mDangFile;
        private string mMaTrangThai;
        private bool mExisted;
        private bool mThuPhi;
        private float mGiaTien;
        private int mSoTrang;
        private string mDuongDanVatLy;
        private int mSoLanDownLoad;
        private int mCapDoMat;

        public string strFileID = "FileID";
        public string strKichCoFile = "KichCoFile";
        public string strNgayUpLoad = "NgayUpLoad";
        public string strNguoiUpLoad = "NguoiUpLoad";
        public string strTenFile = "TenFile";
        public string strDangFile = "DangFile";
        public string strMaTrangThai = "MaTrangThai";
        public string strExisted = "Existed";
        public string strThuPhi = "ThuPhi";
        public string strGiaTien = "GiaTien";
        public string strSoTrang = "SoTrang";
        public string strDuongDanVatLy = "DuongDanVatLy";
        public string strSoLanDownLoad = "SoLanDownLoad";
        public string strCapDoMat = "CapDoMat";

        public FiLesInfo()
        { }

        public int FileID{
        	set{ mFileID = value;}
        	get{ return mFileID;}
        }
        public int KichCoFile{
        	set{ mKichCoFile = value;}
        	get{ return mKichCoFile;}
        }
        public DateTime NgayUpLoad{
        	set{ mNgayUpLoad = value;}
        	get{ return mNgayUpLoad;}
        }
        public string NguoiUpLoad{
        	set{ mNguoiUpLoad = value;}
        	get{ return mNguoiUpLoad;}
        }
        public string TenFile{
        	set{ mTenFile = value;}
        	get{ return mTenFile;}
        }
        public string DangFile{
        	set{ mDangFile = value;}
        	get{ return mDangFile;}
        }
        public string MaTrangThai{
        	set{ mMaTrangThai = value;}
        	get{ return mMaTrangThai;}
        }
        public bool Existed{
        	set{ mExisted = value;}
        	get{ return mExisted;}
        }
        public bool ThuPhi{
        	set{ mThuPhi = value;}
        	get{ return mThuPhi;}
        }
        public float GiaTien{
        	set{ mGiaTien = value;}
        	get{ return mGiaTien;}
        }
        public int SoTrang{
        	set{ mSoTrang = value;}
        	get{ return mSoTrang;}
        }
        public string DuongDanVatLy{
        	set{ mDuongDanVatLy = value;}
        	get{ return mDuongDanVatLy;}
        }
        public int SoLanDownLoad{
        	set{ mSoLanDownLoad = value;}
        	get{ return mSoLanDownLoad;}
        }
        public int CapDoMat{
        	set{ mCapDoMat = value;}
        	get{ return mCapDoMat;}
        }
    }
}
