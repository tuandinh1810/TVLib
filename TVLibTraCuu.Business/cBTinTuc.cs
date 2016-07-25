using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBTinTuc : cBBase
    {
        private cDTinTuc oDTinTuc;
        private TinTucInfo oTinTucInfo;

        public cBTinTuc()        
        {
            oDTinTuc = new cDTinTuc();
        }

        public DataTable Get(TinTucInfo pTinTucInfo)        
        {
            return oDTinTuc.Get(pTinTucInfo);
        }


        public DataTable GetTopTinTuc()
        {
            return oDTinTuc.GetTopTinTuc();
        }

        public DataTable Get_TomTatTinTuc(int TinTucID)
        {
            return oDTinTuc.Get_TomTatTinTuc(TinTucID);
        }

        public int Add(TinTucInfo pTinTucInfo)
        {
			int ID = 0;
            ID = oDTinTuc.Add(pTinTucInfo);
            mErrorMessage = oDTinTuc.ErrorMessages;
            mErrorNumber = oDTinTuc.ErrorNumber;
            return ID;
        }

        public void Update(TinTucInfo pTinTucInfo)
        {
            oDTinTuc.Update(pTinTucInfo);
            mErrorMessage = oDTinTuc.ErrorMessages;
            mErrorNumber = oDTinTuc.ErrorNumber;
        }
        
        public void Delete(TinTucInfo pTinTucInfo)
        {
            oDTinTuc.Delete(pTinTucInfo);
            mErrorMessage = oDTinTuc.ErrorMessages;
            mErrorNumber = oDTinTuc.ErrorNumber;
        }

        public List<TinTucInfo> GetList(TinTucInfo pTinTucInfo)
        {
            List<TinTucInfo> oTinTucInfoList = new List<TinTucInfo>();
            DataTable dtb = Get(pTinTucInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTinTucInfo = new TinTucInfo();

                    oTinTucInfo.TinTucID = int.Parse(dtb.Rows[i]["TinTucID"].ToString());
                    oTinTucInfo.TieuDe = dtb.Rows[i]["TieuDe"].ToString();
                    oTinTucInfo.Loai = dtb.Rows[i]["Loai"].ToString();
                    oTinTucInfo.URL = dtb.Rows[i]["URL"].ToString();
                    oTinTucInfo.TomTat = dtb.Rows[i]["TomTat"].ToString();
                    oTinTucInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
                    oTinTucInfo.NgayCapNhat = DateTime.Parse(dtb.Rows[i]["NgayCapNhat"].ToString());
                    oTinTucInfo.Duyet = bool.Parse(dtb.Rows[i]["Duyet"].ToString());
                    oTinTucInfo.NgonNgu = int.Parse(dtb.Rows[i]["NgonNgu"].ToString());
                    oTinTucInfo.UuTien = int.Parse(dtb.Rows[i]["UuTien"].ToString());
                    oTinTucInfo.IDParent = int.Parse(dtb.Rows[i]["IDParent"].ToString());
                    
                    oTinTucInfoList.Add(oTinTucInfo);
                }
            }
            return oTinTucInfoList;
        }
        
        public void ToDataRow(TinTucInfo pTinTucInfo, ref DataRow dr)
        {

			dr[pTinTucInfo.strTinTucID] = pTinTucInfo.TinTucID;
			dr[pTinTucInfo.strTieuDe] = pTinTucInfo.TieuDe;
			dr[pTinTucInfo.strLoai] = pTinTucInfo.Loai;
			dr[pTinTucInfo.strURL] = pTinTucInfo.URL;
			dr[pTinTucInfo.strTomTat] = pTinTucInfo.TomTat;
			dr[pTinTucInfo.strNoiDung] = pTinTucInfo.NoiDung;
			dr[pTinTucInfo.strNgayCapNhat] = pTinTucInfo.NgayCapNhat;
			dr[pTinTucInfo.strDuyet] = pTinTucInfo.Duyet;
			dr[pTinTucInfo.strNgonNgu] = pTinTucInfo.NgonNgu;
			dr[pTinTucInfo.strUuTien] = pTinTucInfo.UuTien;
			dr[pTinTucInfo.strIDParent] = pTinTucInfo.IDParent;
        }
        
        public void ToInfo(ref TinTucInfo pTinTucInfo, DataRow dr)
        {

			pTinTucInfo.TinTucID = int.Parse(dr[pTinTucInfo.strTinTucID].ToString());
			pTinTucInfo.TieuDe = dr[pTinTucInfo.strTieuDe].ToString();
			pTinTucInfo.Loai = dr[pTinTucInfo.strLoai].ToString();
			pTinTucInfo.URL = dr[pTinTucInfo.strURL].ToString();
			pTinTucInfo.TomTat = dr[pTinTucInfo.strTomTat].ToString();
			pTinTucInfo.NoiDung = dr[pTinTucInfo.strNoiDung].ToString();
			pTinTucInfo.NgayCapNhat = DateTime.Parse(dr[pTinTucInfo.strNgayCapNhat].ToString());
			pTinTucInfo.Duyet = bool.Parse(dr[pTinTucInfo.strDuyet].ToString());
			pTinTucInfo.NgonNgu = int.Parse(dr[pTinTucInfo.strNgonNgu].ToString());
			pTinTucInfo.UuTien = int.Parse(dr[pTinTucInfo.strUuTien].ToString());
			pTinTucInfo.IDParent = int.Parse(dr[pTinTucInfo.strIDParent].ToString());
        }
    }
}
