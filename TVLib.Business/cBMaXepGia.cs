using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBMaXepGia : cBBase
    {
        private cDMaXepGia oDMaXepGia;
        private MaXepGiaInfo oMaXepGiaInfo;
        
        public string SinhMaXepGia(int intIDKho)
        {
            string strMaKho = "";
            string strMaXepGia = "";
            string strMaxMaXepGia="";
            string strSeri = "";
            string strNamHienTai = Right(DateTime.Now.Year.ToString(), 2);
            KhoInfo oKhoInfo = new KhoInfo();
            cBKho obKho=new cBKho();
            oKhoInfo.KhoID = intIDKho;
            DataTable dtbKho = obKho.Get(oKhoInfo);
                if (dtbKho.Rows.Count > 0)
                {
                    strMaKho = dtbKho.Rows[0]["MaKho"].ToString();
                    strMaxMaXepGia = dtbKho.Rows[0]["MaxMaXepGia"].ToString();
                    if(strMaxMaXepGia=="")
                    {
                        strMaxMaXepGia = "0";
                    }
                }

                for (int i = 0; i < 5 - (double.Parse(strMaxMaXepGia) +1).ToString().Length; i++)
                {
                    strSeri = strSeri + 0;
                }
               
                strMaXepGia = strMaKho + strNamHienTai + strSeri + (double.Parse(strMaxMaXepGia)+1);
                return strMaXepGia;
        }
        public bool MaXepGiaExisted(string strMaXepGia,ref int ID)
        {
            bool boolExisted = false;
            DataTable dtbMaXepGia = oDMaXepGia.MaXepGiaExisted(strMaXepGia);
            if(dtbMaXepGia.Rows.Count>0)
            {
                boolExisted = true;
                ID = int.Parse(dtbMaXepGia.Rows[0]["ID"].ToString());
            }
            return boolExisted;
        }
        public void Add_MaXepGia(MaXepGiaInfo pMaXepGiaInfo,string strMaXepGia,int intSoLuong)
        {
            string strKyTuChu = "";
            string strKyTuSo = "";
            string strDKCB = "";
            int intdem=0;
            int intID = 0;
            int intMaxMaXepGia =0;
            double dbKyTuSo=0;
             KhoInfo oKhoInfo = new KhoInfo();
            cBKho obKho=new cBKho();
            oKhoInfo.KhoID = pMaXepGiaInfo.IDKho;
            DataTable dtbKho = obKho.Get(oKhoInfo);
            if(dtbKho.Rows.Count>0)
            {
                intMaxMaXepGia =int.Parse(dtbKho.Rows[0]["MaxMaXepGia"].ToString());
            }
            if (strMaXepGia != "")
            {
                strKyTuSo = GetNumber(ref strMaXepGia);
                if (strKyTuSo != "")
                {
                    int intKyTuSo = strKyTuSo.Length;
                    dbKyTuSo = double.Parse(strKyTuSo)-1;
                    while(intdem<intSoLuong)
                    {
                        intdem = intdem + 1;
                        dbKyTuSo = dbKyTuSo + 1;
                        if (intKyTuSo > dbKyTuSo.ToString().Length)
                        {
                            strDKCB = strMaXepGia + "0" + (dbKyTuSo).ToString();
                        }
                        else 
                        {
                            strDKCB = strMaXepGia + (dbKyTuSo).ToString();
                        }
                        while(!MaXepGiaExisted(strDKCB,ref intID))
                        {
                            pMaXepGiaInfo.MaXepGia = strDKCB;
                            oDMaXepGia.Add(pMaXepGiaInfo);
                        }
                    }
                    //Update MaxMaXepGia vao bang Kho
                    cBKho oBKho = new cBKho();
                    oBKho.UpdateMaxMaXepGia(pMaXepGiaInfo.IDKho,intSoLuong+intMaxMaXepGia);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        public string GetNumber(ref string strMaXepGia)
        {
            string strNumber = "";
            while(char.IsNumber(char.Parse(Right(strMaXepGia,1))) && strMaXepGia.Length>0 )
            {
                strNumber = Right(strMaXepGia, 1) + strNumber;
                strMaXepGia = Left(strMaXepGia,strMaXepGia.Length-1);
            }
            return strNumber;
        }
        public void KiemNhanMoKhoa(string strID)
        {
            oDMaXepGia.KiemNhanMoKhoa(strID);
        }
        public void ThanhLyDKCB(string strID,int IDLyDoThanhLy)
        {
            oDMaXepGia.ThanhLyDKCB(strID, IDLyDoThanhLy);
        }
        public void PhucHoiDKCB(string strID)
        {
            oDMaXepGia.PhucHoiDKCB(strID);
        }
        public cBMaXepGia()        
        {
            oDMaXepGia = new cDMaXepGia();
        }

        public DataTable Get(MaXepGiaInfo pMaXepGiaInfo)        
        {
            return oDMaXepGia.Get(pMaXepGiaInfo);
        }
        public DataTable Get_BaoCaoBoSung(int IDThuVien, int IDKho,DateTime TuNgay, DateTime DenNgay)
        {
            return oDMaXepGia.Get_BaoCaoBoSung(IDThuVien, IDKho, TuNgay, DenNgay);
        }
        public DataTable DanhMucSachMoi(DateTime TuNgay, DateTime DenNgay)
        {
            return oDMaXepGia.DanhMucSachMoi(TuNgay, DenNgay);
        }
        public DataTable Get_InMaVach(int IDThuVien, int IDKho, string MaXepGia, string MaTaiLieu,DateTime TuNgay, DateTime DenNgay)
        {
            return oDMaXepGia.Get_InMaVach(IDThuVien, IDKho, MaXepGia, MaTaiLieu, TuNgay, DenNgay);
        }
        public DataTable Get_InNhanGay(int IDThuVien, int IDKho, string MaXepGia, string MaTaiLieu)
        {
            return oDMaXepGia.Get_InNhanGay(IDThuVien, IDKho, MaXepGia, MaTaiLieu);
        }
        public DataTable GetByTaiLieu(int intTaiLieuID)
        {
            return oDMaXepGia.GetByTaiLieu(intTaiLieuID);
        }
        public DataTable GetByIDTaiLieus(string strTaiLieuID)
        {
            return oDMaXepGia.GetByIDTaiLieus(strTaiLieuID);
        }
        public DataTable GetQuanLyKho(string DKCB, int IDKho, int LoaiChucNang)
        {
            return oDMaXepGia.GetQuanLyKho(DKCB, IDKho, LoaiChucNang);
        }
        public DataTable Get_MaXepGiaInfo_ByIDTaiLieu(int intIDTaiLieu)
        {
            return oDMaXepGia.Get_MaXepGiaInfo_ByIDTaiLieu(intIDTaiLieu);
        }
        public int Add(MaXepGiaInfo pMaXepGiaInfo)
        {
			int ID = 0;
            ID = oDMaXepGia.Add(pMaXepGiaInfo);
            mErrorMessage = oDMaXepGia.ErrorMessages;
            mErrorNumber = oDMaXepGia.ErrorNumber;
            return ID;
        }

        public bool Update(MaXepGiaInfo pMaXepGiaInfo)
        {
            bool bolUpdate = false;
            int ID=0;
            if (!MaXepGiaExisted(pMaXepGiaInfo.MaXepGia,ref ID))
            {
               
                    oDMaXepGia.Update(pMaXepGiaInfo);
                    bolUpdate = true;
                
            }
            else if (ID == pMaXepGiaInfo.ID)
            {
                oDMaXepGia.Update(pMaXepGiaInfo);
                bolUpdate = true;

            }
            else
            {
                bolUpdate = false;
            }
            return bolUpdate;
            

            mErrorMessage = oDMaXepGia.ErrorMessages;
            mErrorNumber = oDMaXepGia.ErrorNumber;
        }
        
        public void Delete(MaXepGiaInfo pMaXepGiaInfo)
        {
            oDMaXepGia.Delete(pMaXepGiaInfo);
            mErrorMessage = oDMaXepGia.ErrorMessages;
            mErrorNumber = oDMaXepGia.ErrorNumber;
        }

        public List<MaXepGiaInfo> GetList(MaXepGiaInfo pMaXepGiaInfo)
        {
            List<MaXepGiaInfo> oMaXepGiaInfoList = new List<MaXepGiaInfo>();
            DataTable dtb = Get(pMaXepGiaInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oMaXepGiaInfo = new MaXepGiaInfo();
                    

                    oMaXepGiaInfo.MaXepGia = dtb.Rows[i]["MaXepGia"].ToString();
                    oMaXepGiaInfo.LuuThong = bool.Parse(dtb.Rows[i]["LuuThong"].ToString());
                    oMaXepGiaInfo.DangMuon = bool.Parse(dtb.Rows[i]["DangMuon"].ToString());
                    oMaXepGiaInfo.IDTaiLieu = int.Parse(dtb.Rows[i]["IDTaiLieu"].ToString());
                    
                    oMaXepGiaInfoList.Add(oMaXepGiaInfo);
                }
            }
            return oMaXepGiaInfoList.Count == 0 ? null : oMaXepGiaInfoList;
        }
        public DataTable GetTotal(int IDTaiLieu)
        {
            return oDMaXepGia.GetTotal(IDTaiLieu);
        }
    }
}
