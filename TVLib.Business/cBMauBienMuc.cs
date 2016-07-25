using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBMauBienMuc : cBBase
    {
        private cDMauBienMuc oDMauBienMuc;
        private MauBienMucInfo oMauBienMucInfo;

        public cBMauBienMuc()        
        {
            oDMauBienMuc = new cDMauBienMuc();
        }

        public DataTable Get(MauBienMucInfo pMauBienMucInfo)        
        {
            return oDMauBienMuc.Get(pMauBienMucInfo);
        }

        public int Add(MauBienMucInfo pMauBienMucInfo)
        {
			int ID = 0;
            ID = oDMauBienMuc.Add(pMauBienMucInfo);
            mErrorMessage = oDMauBienMuc.ErrorMessages;
            mErrorNumber = oDMauBienMuc.ErrorNumber;
            return ID;
        }

        public void Update(MauBienMucInfo pMauBienMucInfo)
        {
            oDMauBienMuc.Update(pMauBienMucInfo);
            mErrorMessage = oDMauBienMuc.ErrorMessages;
            mErrorNumber = oDMauBienMuc.ErrorNumber;
        }
        
        public void Delete(MauBienMucInfo pMauBienMucInfo)
        {
            oDMauBienMuc.Delete(pMauBienMucInfo);
            mErrorMessage = oDMauBienMuc.ErrorMessages;
            mErrorNumber = oDMauBienMuc.ErrorNumber;
        }

        public List<MauBienMucInfo> GetList(MauBienMucInfo pMauBienMucInfo)
        {
            List<MauBienMucInfo> oMauBienMucInfoList = new List<MauBienMucInfo>();
            DataTable dtb = Get(pMauBienMucInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oMauBienMucInfo = new MauBienMucInfo();

                    oMauBienMucInfo.MauBienMucID = int.Parse(dtb.Rows[i]["MauBienMucID"].ToString());
                    oMauBienMucInfo.Ten = dtb.Rows[i]["Ten"].ToString();
                    oMauBienMucInfo.IDNguoiDung = int.Parse(dtb.Rows[i]["IDNguoiDung"].ToString());
                    oMauBienMucInfo.NgayTao = DateTime.Parse(dtb.Rows[i]["NgayTao"].ToString());
                    oMauBienMucInfo.NgaySuaCuoi = DateTime.Parse(dtb.Rows[i]["NgaySuaCuoi"].ToString());
                    
                    oMauBienMucInfoList.Add(oMauBienMucInfo);
                }
            }
            return oMauBienMucInfoList;
        }
        
        public void ToDataRow(MauBienMucInfo pMauBienMucInfo, ref DataRow dr)
        {

			dr[pMauBienMucInfo.strMauBienMucID] = pMauBienMucInfo.MauBienMucID;
			dr[pMauBienMucInfo.strTen] = pMauBienMucInfo.Ten;
			dr[pMauBienMucInfo.strIDNguoiDung] = pMauBienMucInfo.IDNguoiDung;
			dr[pMauBienMucInfo.strNgayTao] = pMauBienMucInfo.NgayTao;
			dr[pMauBienMucInfo.strNgaySuaCuoi] = pMauBienMucInfo.NgaySuaCuoi;
        }
        
        public void ToInfo(ref MauBienMucInfo pMauBienMucInfo, DataRow dr)
        {

			pMauBienMucInfo.MauBienMucID = int.Parse(dr[pMauBienMucInfo.strMauBienMucID].ToString());
			pMauBienMucInfo.Ten = dr[pMauBienMucInfo.strTen].ToString();
			pMauBienMucInfo.IDNguoiDung = int.Parse(dr[pMauBienMucInfo.strIDNguoiDung].ToString());
			pMauBienMucInfo.NgayTao = DateTime.Parse(dr[pMauBienMucInfo.strNgayTao].ToString());
			pMauBienMucInfo.NgaySuaCuoi = DateTime.Parse(dr[pMauBienMucInfo.strNgaySuaCuoi].ToString());
        }
    }
}
