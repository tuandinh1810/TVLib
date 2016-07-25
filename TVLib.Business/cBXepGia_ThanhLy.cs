using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBXepGia_ThanhLy : cBBase
    {
        private cDXepGia_ThanhLy oDXepGia_ThanhLy;
        private XepGia_ThanhLyInfo oXepGia_ThanhLyInfo;

        public cBXepGia_ThanhLy()        
        {
            oDXepGia_ThanhLy = new cDXepGia_ThanhLy();
        }

        public DataTable Get(XepGia_ThanhLyInfo pXepGia_ThanhLyInfo)        
        {
            return oDXepGia_ThanhLy.Get(pXepGia_ThanhLyInfo);
        }

        public int Add(XepGia_ThanhLyInfo pXepGia_ThanhLyInfo)
        {
			int ID = 0;
            ID = oDXepGia_ThanhLy.Add(pXepGia_ThanhLyInfo);
            mErrorMessage = oDXepGia_ThanhLy.ErrorMessages;
            mErrorNumber = oDXepGia_ThanhLy.ErrorNumber;
            return ID;
        }

        public void Update(XepGia_ThanhLyInfo pXepGia_ThanhLyInfo)
        {
            oDXepGia_ThanhLy.Update(pXepGia_ThanhLyInfo);
            mErrorMessage = oDXepGia_ThanhLy.ErrorMessages;
            mErrorNumber = oDXepGia_ThanhLy.ErrorNumber;
        }
        
        public void Delete(XepGia_ThanhLyInfo pXepGia_ThanhLyInfo)
        {
            oDXepGia_ThanhLy.Delete(pXepGia_ThanhLyInfo);
            mErrorMessage = oDXepGia_ThanhLy.ErrorMessages;
            mErrorNumber = oDXepGia_ThanhLy.ErrorNumber;
        }

        public List<XepGia_ThanhLyInfo> GetList(XepGia_ThanhLyInfo pXepGia_ThanhLyInfo)
        {
            List<XepGia_ThanhLyInfo> oXepGia_ThanhLyInfoList = new List<XepGia_ThanhLyInfo>();
            DataTable dtb = Get(pXepGia_ThanhLyInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXepGia_ThanhLyInfo = new XepGia_ThanhLyInfo();

                    oXepGia_ThanhLyInfo.ID = int.Parse(dtb.Rows[i]["ID"].ToString());
                    oXepGia_ThanhLyInfo.MaXepGia = dtb.Rows[i]["MaXepGia"].ToString();
                    oXepGia_ThanhLyInfo.LuuThong = bool.Parse(dtb.Rows[i]["LuuThong"].ToString());
                    oXepGia_ThanhLyInfo.DangMuon = bool.Parse(dtb.Rows[i]["DangMuon"].ToString());
                    oXepGia_ThanhLyInfo.Shelf = dtb.Rows[i]["Shelf"].ToString();
                    oXepGia_ThanhLyInfo.KiemNhan = bool.Parse(dtb.Rows[i]["KiemNhan"].ToString());
                    oXepGia_ThanhLyInfo.NgayThanhLy = DateTime.Parse(dtb.Rows[i]["NgayThanhLy"].ToString());
                    oXepGia_ThanhLyInfo.NgayXepGia = DateTime.Parse(dtb.Rows[i]["NgayXepGia"].ToString());
                    oXepGia_ThanhLyInfo.IDTaiLieu = int.Parse(dtb.Rows[i]["IDTaiLieu"].ToString());
                    oXepGia_ThanhLyInfo.IDKho = int.Parse(dtb.Rows[i]["IDKho"].ToString());
                    oXepGia_ThanhLyInfo.IDLyDoThanhLy = int.Parse(dtb.Rows[i]["IDLyDoThanhLy"].ToString());
                    
                    oXepGia_ThanhLyInfoList.Add(oXepGia_ThanhLyInfo);
                }
            }
            return oXepGia_ThanhLyInfoList;
        }
        
        public void ToDataRow(XepGia_ThanhLyInfo pXepGia_ThanhLyInfo, ref DataRow dr)
        {

			dr[pXepGia_ThanhLyInfo.strID] = pXepGia_ThanhLyInfo.ID;
			dr[pXepGia_ThanhLyInfo.strMaXepGia] = pXepGia_ThanhLyInfo.MaXepGia;
			dr[pXepGia_ThanhLyInfo.strLuuThong] = pXepGia_ThanhLyInfo.LuuThong;
			dr[pXepGia_ThanhLyInfo.strDangMuon] = pXepGia_ThanhLyInfo.DangMuon;
			dr[pXepGia_ThanhLyInfo.strShelf] = pXepGia_ThanhLyInfo.Shelf;
			dr[pXepGia_ThanhLyInfo.strKiemNhan] = pXepGia_ThanhLyInfo.KiemNhan;
			dr[pXepGia_ThanhLyInfo.strNgayThanhLy] = pXepGia_ThanhLyInfo.NgayThanhLy;
			dr[pXepGia_ThanhLyInfo.strNgayXepGia] = pXepGia_ThanhLyInfo.NgayXepGia;
			dr[pXepGia_ThanhLyInfo.strIDTaiLieu] = pXepGia_ThanhLyInfo.IDTaiLieu;
			dr[pXepGia_ThanhLyInfo.strIDKho] = pXepGia_ThanhLyInfo.IDKho;
			dr[pXepGia_ThanhLyInfo.strIDLyDoThanhLy] = pXepGia_ThanhLyInfo.IDLyDoThanhLy;
        }
        
        public void ToInfo(ref XepGia_ThanhLyInfo pXepGia_ThanhLyInfo, DataRow dr)
        {

			pXepGia_ThanhLyInfo.ID = int.Parse(dr[pXepGia_ThanhLyInfo.strID].ToString());
			pXepGia_ThanhLyInfo.MaXepGia = dr[pXepGia_ThanhLyInfo.strMaXepGia].ToString();
			pXepGia_ThanhLyInfo.LuuThong = bool.Parse(dr[pXepGia_ThanhLyInfo.strLuuThong].ToString());
			pXepGia_ThanhLyInfo.DangMuon = bool.Parse(dr[pXepGia_ThanhLyInfo.strDangMuon].ToString());
			pXepGia_ThanhLyInfo.Shelf = dr[pXepGia_ThanhLyInfo.strShelf].ToString();
			pXepGia_ThanhLyInfo.KiemNhan = bool.Parse(dr[pXepGia_ThanhLyInfo.strKiemNhan].ToString());
			pXepGia_ThanhLyInfo.NgayThanhLy = DateTime.Parse(dr[pXepGia_ThanhLyInfo.strNgayThanhLy].ToString());
			pXepGia_ThanhLyInfo.NgayXepGia = DateTime.Parse(dr[pXepGia_ThanhLyInfo.strNgayXepGia].ToString());
			pXepGia_ThanhLyInfo.IDTaiLieu = int.Parse(dr[pXepGia_ThanhLyInfo.strIDTaiLieu].ToString());
			pXepGia_ThanhLyInfo.IDKho = int.Parse(dr[pXepGia_ThanhLyInfo.strIDKho].ToString());
			pXepGia_ThanhLyInfo.IDLyDoThanhLy = int.Parse(dr[pXepGia_ThanhLyInfo.strIDLyDoThanhLy].ToString());
        }
    }
}
