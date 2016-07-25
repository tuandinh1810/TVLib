using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBBanDoc : cBBase
    {
        private cDBanDoc oDBanDoc;
        private BanDocInfo oBanDocInfo;

        public cBBanDoc()        
        {
            oDBanDoc = new cDBanDoc();
        }

        public DataTable RunSql(string strSql)
        {
            return oDBanDoc.RunSql(strSql);
        }
        public DataTable GetBanDocBySoThe(string SoThe)
        {
            return oDBanDoc.GetBySoThe(SoThe);
        }
        public DataTable Get(BanDocInfo pBanDocInfo)        
        {
            return oDBanDoc.Get(pBanDocInfo);
        }
        public DataTable PhongDoc_GetBySoThe_Thang(string SoThe)
        {
            return oDBanDoc.PhongDoc_GetBySoThe_Thang(SoThe);

        }
        public DataTable XoaBanDocTheoLo(string Khoa, string Lop, string TuNgay, string DenNgay)
        {
            return oDBanDoc.XoaBanDocTheoLo( Khoa,  Lop,  TuNgay,  DenNgay);
        }

        public void MoKhoa()
        {
            oDBanDoc.MoKhoa();
        }
        public DataTable GetSoLuongBanDoc_ByNhomBanDoc(int IDNhomBanDoc)
        {
            return oDBanDoc.GetSoLuongBanDoc_ByNhomBanDoc(IDNhomBanDoc);
                    
        }
        public DataTable Get_SoLuotMuon_PhongDocMo(string Khoa, string Lop, string SoThe, DateTime TuNgay, DateTime DenNgay)
        {
            return oDBanDoc.Get_SoLuotMuon_PhongDocMo(Khoa, Lop, SoThe, TuNgay, DenNgay);
        }
        
        public DataTable GetBanDoc_GhiMuon(BanDocInfo pBanDocInfo)
        {
            return oDBanDoc.GetBanDoc_GhiMuon(pBanDocInfo);
        }
        public DataTable GetBanDoc_GhiMuonByMaXepGia(string pMaXepGia)
        {
            return oDBanDoc.GetBanDoc_GhiMuonByMaXepGia(pMaXepGia);
        }
        public int PhongDoc_LuongBanDoc_Add(string SoThe, DateTime NgayGioVao)
        {
            return oDBanDoc.PhongDoc_LuongBanDoc_Add(SoThe, NgayGioVao);
        }
        public DataTable PhongDoc_Vaildate(string SoThe, DateTime NgayGio)
        {
            return oDBanDoc.PhongDoc_Vaildate(SoThe, NgayGio);
        }
        public int PhongDoc_LuongBanDoc_Update(string SoThe, DateTime NgayGioRa)
        {
            return oDBanDoc.PhongDoc_LuongBanDoc_Update(SoThe, NgayGioRa);
        }
        public DataTable ThongKeLuotBanDoc_PhongDoc(int Thang, int Nam, string Khoa, string Lop, string MaThe)
        {
            return oDBanDoc.ThongKeLuotBanDoc_PhongDoc(Thang,Nam,Khoa,Lop,MaThe);
        }
        public DataTable GetKhoas(BanDocInfo pBanDocInfo)
        {
            return oDBanDoc.GetKhoas(pBanDocInfo);
        }
        public DataTable GetLop(BanDocInfo pBanDocInfo)
        {
            return oDBanDoc.GetLop(pBanDocInfo);
        }
        public DataTable GetBanDoc(BanDocInfo pBanDocInfo)
        {
            return oDBanDoc.GetBanDoc(pBanDocInfo);
        }
        public DataTable GetBanDoc_GhiMuon_ByBanDocID(BanDocInfo pBanDocInfo)
        {
            return oDBanDoc.GetBanDoc_GhiMuon_ByBanDocID(pBanDocInfo);
        }
        public int Add(BanDocInfo pBanDocInfo)
        {
			int ID = 0;
            ID = oDBanDoc.Add(pBanDocInfo);
            mErrorMessage = oDBanDoc.ErrorMessages;
            mErrorNumber = oDBanDoc.ErrorNumber;
            return ID;
        }

        public int  Update(BanDocInfo pBanDocInfo)
        {
            int ID = 0;
            ID = oDBanDoc.Update(pBanDocInfo);
            mErrorMessage = oDBanDoc.ErrorMessages;
            mErrorNumber = oDBanDoc.ErrorNumber;
            return ID;
        }

        //public DataTable  Search(string strHoVaTen, string strSoThe, string strIDNgheNghiep, string strIDDanToc, string strGioiTinh, string strNgayCapThe, string strNgayHetHan, string strKhoa, string strLop, string strNgaySinh, string strIDNhomBanDoc)
        //{
        //    return  oDBanDoc.Search( strHoVaTen,  strSoThe, strIDNgheNghiep,strIDDanToc,  strGioiTinh,  strNgayCapThe, strNgayHetHan, strKhoa,strLop, strNgaySinh, strIDNhomBanDoc);
        //    mErrorMessage = oDBanDoc.ErrorMessages;
        //    mErrorNumber = oDBanDoc.ErrorNumber;
        //}
        
        public int  Delete(BanDocInfo pBanDocInfo)
        {
            int ID = 0;
            ID = oDBanDoc.Delete(pBanDocInfo);
            mErrorMessage = oDBanDoc.ErrorMessages;
            mErrorNumber = oDBanDoc.ErrorNumber;
            return ID;
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
