using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBTaiLieu : cBBase
    {
        private cDTaiLieu oDTaiLieu;
        private TaiLieuInfo oTaiLieuInfo;

        public cBTaiLieu()
        {
            oDTaiLieu = new cDTaiLieu();
        }
        public DataTable GetMaxMaTaiLieu()
        {
            return oDTaiLieu.GetMaxMaTaiLieu();
        }
        public DataTable Get(TaiLieuInfo pTaiLieuInfo)
        {
            return oDTaiLieu.Get(pTaiLieuInfo);
        }
        public DataTable ThongKeTaiLieuTrongKho()
        {
            return oDTaiLieu.ThongKeTaiLieuTrongKho();
        }
        public DataTable ThongKeTaiLieuTheoNamBoSung(int TuNam, int DenNam)
        {
            return oDTaiLieu.ThongKeTaiLieuTheoNamBoSung(TuNam,DenNam);
        }
        public DataTable GetSoLuongTaiLieu(string TuNgay, string DenNgay, int IDNguoiDung)
        {
            return oDTaiLieu.GetSoLuongTaiLieu(TuNgay,DenNgay,IDNguoiDung);
        }
        public DataTable GetSoLuong_ByKho(string TuNgay, string DenNgay, int IDKho, int intType)
        {
            return oDTaiLieu.GetSoLuong_ByKho(TuNgay, DenNgay, IDKho, intType);
        }
        public DataTable GetSoLuongMXG_ByKho(DateTime TuNgay, DateTime DenNgay)
        {
            return oDTaiLieu.GetSoLuongMXG_ByKho(TuNgay, DenNgay);
        }
        public DataTable GetSoLuong_NgayBienMuc(int Ngay, int Thang, int Nam)
        {
            return oDTaiLieu.GetSoLuong_NgayBienMuc(Ngay,Thang, Nam);
        }
        public DataTable GetSoLuong_ByIDLoaiTaiLieu(int Thang, int Nam, int IDLoaiTaiLieu)
        {
            return oDTaiLieu.GetSoLuong_ByIDLoaiTaiLieu(Thang, Nam, IDLoaiTaiLieu);
        }
        public DataTable GetSoLuong_ByLoaiTaiLieu(int Thang, int Nam)
        {
            return oDTaiLieu.GetSoLuong_ByLoaiTaiLieu(Thang, Nam);
        }
        public DataTable GetSoLuongTaiLieuByUser(DateTime TuNgay, DateTime DenNgay)
        {
            return oDTaiLieu.GetSoLuongTaiLieuByUser(TuNgay, DenNgay);
        
        }
        public DataTable GetSoLuong_ByNgayBienMuc(int Thang, int Nam)
        {
            return oDTaiLieu.GetSoLuong_ByNgayBienMuc(Thang, Nam);
        }
        public DataTable GetTop20_MuonNhieuNhat(DateTime dtFromDate, DateTime dtToDate)
        {
            return oDTaiLieu.GetTop20_MuonNhieuNhat(dtFromDate,dtToDate);
        }
        public DataTable GetTop20_BanDoc(DateTime dtFromDate, DateTime dtToDate)
        {
            return oDTaiLieu.GetTop20_BanDoc(dtFromDate, dtToDate);
        }
        public DataTable GetTop20_MuonTrongNgay(DateTime dtFromDate)
        {
            return oDTaiLieu.GetTop20_MuonTrongNgay(dtFromDate);
        }
        public DataTable Get_BaoCao_DangMuon(string Khoa, string Lop, string SoThe, DateTime TuNgay, DateTime DenNgay, string MaTaiLieu, string MaXepGia, int IDKho)
        {
            return oDTaiLieu.Get_BaoCao_DangMuon(Khoa, Lop, SoThe,TuNgay,DenNgay,MaTaiLieu,MaXepGia,IDKho);
        }
        public DataTable Get_BaoCao_LichSuMuon(string SoThe, DateTime MuonTuNgay, DateTime MuonDenNgay, DateTime TraTuNgay, DateTime TraDenNgay, string MaTaiLieu, string MaXepGia, int IDKho)
        {
            return oDTaiLieu.Get_BaoCao_LichSuMuon(SoThe, MuonTuNgay, MuonDenNgay, TraTuNgay, TraDenNgay, MaTaiLieu, MaXepGia, IDKho);
        }
        public DataTable GetByLoaiTaiLieu(int pIDLoaiTaiLieu)
        {
            return oDTaiLieu.GetByLoaiTaiLieu(pIDLoaiTaiLieu);
        }
        public string SinhMaTaiLieu()
        {
            string strMaTaiLieu;
            string seriMaTaiLieu;
            string strNamHienTai = Right(DateTime.Now.Year.ToString(), 2);
            DataTable dtbMaxMaTaiLieu = GetMaxMaTaiLieu();
            if (dtbMaxMaTaiLieu.Rows.Count > 0 && dtbMaxMaTaiLieu.Rows[0][0].ToString()!="")
            {

                seriMaTaiLieu = dtbMaxMaTaiLieu.Rows[0][0].ToString();
                strMaTaiLieu = "TV" + strNamHienTai + seriMaTaiLieu.Substring(2,seriMaTaiLieu.Length-2);
            }
            else
                strMaTaiLieu = "TV" + strNamHienTai + "000001";
            return strMaTaiLieu;

        }
        public int Add(TaiLieuInfo pTaiLieuInfo)
        {
            int ID = 0;
            ID = oDTaiLieu.Add(pTaiLieuInfo);
            mErrorMessage = oDTaiLieu.ErrorMessages;
            mErrorNumber = oDTaiLieu.ErrorNumber;
            return ID;
        }
        public void UpdateTempHTT(int IDTaiLieu, float STT)
        {
            oDTaiLieu.UpdateTempHTT(IDTaiLieu, STT);
        }
        public void Update(TaiLieuInfo pTaiLieuInfo)
        {
            oDTaiLieu.Update(pTaiLieuInfo);
            mErrorMessage = oDTaiLieu.ErrorMessages;
            mErrorNumber = oDTaiLieu.ErrorNumber;
        }

        public void Delete(TaiLieuInfo pTaiLieuInfo)
        {
            oDTaiLieu.Delete(pTaiLieuInfo);
            mErrorMessage = oDTaiLieu.ErrorMessages;
            mErrorNumber = oDTaiLieu.ErrorNumber;
        }

        public List<TaiLieuInfo> GetList(TaiLieuInfo pTaiLieuInfo)
        {
            List<TaiLieuInfo> oTaiLieuInfoList = new List<TaiLieuInfo>();
            DataTable dtb = Get(pTaiLieuInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oTaiLieuInfo = new TaiLieuInfo();


                    oTaiLieuInfo.TaiLieuID = int.Parse(dtb.Rows[i]["TaiLieuID"].ToString());
                    oTaiLieuInfo.LuuThong = bool.Parse(dtb.Rows[i]["LuuThong"].ToString());
                    oTaiLieuInfo.IDKieuTuLieuBanGhi = int.Parse(dtb.Rows[i]["IDKieuTuLieuBanGhi"].ToString());
                    oTaiLieuInfo.CapDoMat = int.Parse(dtb.Rows[i]["CapDoMat"].ToString());
                    oTaiLieuInfo.GiaTien = float.Parse(dtb.Rows[i]["GiaTien"].ToString());
                    oTaiLieuInfo.IDNguoiNhapTin = int.Parse(dtb.Rows[i]["IDNguoiNhapTin"].ToString());
                    oTaiLieuInfo.IDLoaiTaiLieu = int.Parse(dtb.Rows[i]["IDLoaiTaiLieu"].ToString());

                    oTaiLieuInfoList.Add(oTaiLieuInfo);
                }
            }
            return oTaiLieuInfoList.Count == 0 ? null : oTaiLieuInfoList;
        }
    }
}
