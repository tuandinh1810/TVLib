using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBBanDoc : cBBase
    {
        private cDBanDoc oDBanDoc;
        private BanDocInfo oBanDocInfo;

        public cBBanDoc()        
        {
            oDBanDoc = new cDBanDoc();
        }

        public DataTable Get(BanDocInfo pBanDocInfo)        
        {
            return oDBanDoc.Get(pBanDocInfo);
        }

        public DataTable GetBanDoc_GhiMuon(BanDocInfo pBanDocInfo)
        {
            return oDBanDoc.GetBanDoc_GhiMuon(pBanDocInfo);
        }
        public DataTable GetBySoThe(string SoThe)
        {
            return oDBanDoc.GetBySoThe(SoThe);
        }
        public int Add(BanDocInfo pBanDocInfo)
        {
			int ID = 0;
            ID = oDBanDoc.Add(pBanDocInfo);
            mErrorMessage = oDBanDoc.ErrorMessages;
            mErrorNumber = oDBanDoc.ErrorNumber;
            return ID;
        }

        public void Update(BanDocInfo pBanDocInfo)
        {
            oDBanDoc.Update(pBanDocInfo);
            mErrorMessage = oDBanDoc.ErrorMessages;
            mErrorNumber = oDBanDoc.ErrorNumber;
        }

        //public DataTable  Search(string strHoVaTen, string strSoThe, string strIDNgheNghiep, string strIDDanToc, string strGioiTinh, string strNgayCapThe, string strNgayHetHan, string strKhoa, string strLop, string strNgaySinh, string strIDNhomBanDoc)
        //{
        //    return  oDBanDoc.Search( strHoVaTen,  strSoThe, strIDNgheNghiep,strIDDanToc,  strGioiTinh,  strNgayCapThe, strNgayHetHan, strKhoa,strLop, strNgaySinh, strIDNhomBanDoc);
        //    mErrorMessage = oDBanDoc.ErrorMessages;
        //    mErrorNumber = oDBanDoc.ErrorNumber;
        //}
        
        public void Delete(BanDocInfo pBanDocInfo)
        {
            oDBanDoc.Delete(pBanDocInfo);
            mErrorMessage = oDBanDoc.ErrorMessages;
            mErrorNumber = oDBanDoc.ErrorNumber;
        }

        //public List<BanDocInfo> GetList(BanDocInfo pBanDocInfo)
        //{
        //    List<BanDocInfo> oBanDocInfoList = new List<BanDocInfo>();
        //    DataTable dtb = Get(pBanDocInfo);
        //    if (dtb != null)
        //    {                
        //        for (int i=0;i<dtb.Rows.Count;i++)
        //        {
        //            oBanDocInfo = new BanDocInfo();
                    

        //            oBanDocInfo.BanDocID = int.Parse(dtb.Rows[i]["BanDocID"].ToString());
        //            oBanDocInfo.SoThe = dtb.Rows[i]["SoThe"].ToString();
        //            oBanDocInfo.TenDayDu = dtb.Rows[i]["TenDayDu"].ToString();
        //            oBanDocInfo.NgaySinh = DateTime.Parse(dtb.Rows[i]["NgaySinh"].ToString());
        //            oBanDocInfo.NgayCap = DateTime.Parse(dtb.Rows[i]["NgayCap"].ToString());
        //            oBanDocInfo.NgayHieuLuc = DateTime.Parse(dtb.Rows[i]["NgayHieuLuc"].ToString());
        //            oBanDocInfo.NgayHetHan = DateTime.Parse(dtb.Rows[i]["NgayHetHan"].ToString());
        //            oBanDocInfo.IDDanToc = int.Parse(dtb.Rows[i]["IDDanToc"].ToString());
        //            oBanDocInfo.IDNhomBanDoc = int.Parse(dtb.Rows[i]["IDNhomBanDoc"].ToString());
        //            oBanDocInfo.IDTrinhDo = int.Parse(dtb.Rows[i]["IDTrinhDo"].ToString());
        //            oBanDocInfo.IDNgheNghiep = int.Parse(dtb.Rows[i]["IDNgheNghiep"].ToString());
        //            oBanDocInfo.Khoa = dtb.Rows[i]["Khoa"].ToString();
        //            oBanDocInfo.Lop = dtb.Rows[i]["Lop"].ToString();
        //            oBanDocInfo.NoiLamViec = dtb.Rows[i]["NoiLamViec"].ToString();
        //            oBanDocInfo.GioiTinh = bool.Parse(dtb.Rows[i]["GioiTinh"].ToString());
        //            oBanDocInfo.DiaChi = dtb.Rows[i]["DiaChi"].ToString();
        //            oBanDocInfo.ThanhPho = dtb.Rows[i]["ThanhPho"].ToString();
        //            oBanDocInfo.IDTinh = int.Parse(dtb.Rows[i]["IDTinh"].ToString());
        //            oBanDocInfo.SoCMT = dtb.Rows[i]["SoCMT"].ToString();
        //            oBanDocInfo.SoDienThoai = dtb.Rows[i]["SoDienThoai"].ToString();
        //            oBanDocInfo.Email = dtb.Rows[i]["Email"].ToString();
        //            oBanDocInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
        //            oBanDocInfo.MaVung = dtb.Rows[i]["MaVung"].ToString();
        //            oBanDocInfo.KhoaThe = bool.Parse(dtb.Rows[i]["KhoaThe"].ToString());
        //            oBanDocInfo.AnhURL = dtb.Rows[i]["AnhURL"].ToString();
                    
        //            oBanDocInfoList.Add(oBanDocInfo);
        //        }
        //    }
        //    return oBanDocInfoList.Count == 0 ? null : oBanDocInfoList;
        //}
    }
}
