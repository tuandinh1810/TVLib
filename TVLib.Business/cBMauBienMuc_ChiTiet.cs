using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBMauBienMuc_ChiTiet : cBBase
    {
        private cDMauBienMuc_ChiTiet oDMauBienMuc_ChiTiet;
        private MauBienMuc_ChiTietInfo oMauBienMuc_ChiTietInfo;

        public cBMauBienMuc_ChiTiet()        
        {
            oDMauBienMuc_ChiTiet = new cDMauBienMuc_ChiTiet();
        }

        public DataTable Get(MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo)        
        {
            return oDMauBienMuc_ChiTiet.Get(pMauBienMuc_ChiTietInfo);
        }
        public DataTable Get_ByMauBienMuc(int IDMauBienMuc)
        {
            return oDMauBienMuc_ChiTiet.Get_ByMauBienMuc(IDMauBienMuc);
        }

        public int Add(MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo)
        {
			int ID = 0;
            ID = oDMauBienMuc_ChiTiet.Add(pMauBienMuc_ChiTietInfo);
            mErrorMessage = oDMauBienMuc_ChiTiet.ErrorMessages;
            mErrorNumber = oDMauBienMuc_ChiTiet.ErrorNumber;
            return ID;
        }

        public void Update(MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo)
        {
            oDMauBienMuc_ChiTiet.Update(pMauBienMuc_ChiTietInfo);
            mErrorMessage = oDMauBienMuc_ChiTiet.ErrorMessages;
            mErrorNumber = oDMauBienMuc_ChiTiet.ErrorNumber;
        }
        
        public void Delete(MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo)
        {
            oDMauBienMuc_ChiTiet.Delete(pMauBienMuc_ChiTietInfo);
            mErrorMessage = oDMauBienMuc_ChiTiet.ErrorMessages;
            mErrorNumber = oDMauBienMuc_ChiTiet.ErrorNumber;
        }

        public List<MauBienMuc_ChiTietInfo> GetList(MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo)
        {
            List<MauBienMuc_ChiTietInfo> oMauBienMuc_ChiTietInfoList = new List<MauBienMuc_ChiTietInfo>();
            DataTable dtb = Get(pMauBienMuc_ChiTietInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oMauBienMuc_ChiTietInfo = new MauBienMuc_ChiTietInfo();

                    oMauBienMuc_ChiTietInfo.ID = int.Parse(dtb.Rows[i]["ID"].ToString());
                    oMauBienMuc_ChiTietInfo.IDMARC_FIELD = int.Parse(dtb.Rows[i]["IDMARC_FIELD"].ToString());
                    oMauBienMuc_ChiTietInfo.GiaTriMacDinh = dtb.Rows[i]["GiaTriMacDinh"].ToString();
                    oMauBienMuc_ChiTietInfo.IDMauBienMuc = int.Parse(dtb.Rows[i]["IDMauBienMuc"].ToString());
                    
                    oMauBienMuc_ChiTietInfoList.Add(oMauBienMuc_ChiTietInfo);
                }
            }
            return oMauBienMuc_ChiTietInfoList;
        }
        
        public void ToDataRow(MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo, ref DataRow dr)
        {

			dr[pMauBienMuc_ChiTietInfo.strID] = pMauBienMuc_ChiTietInfo.ID;
			dr[pMauBienMuc_ChiTietInfo.strIDMARC_FIELD] = pMauBienMuc_ChiTietInfo.IDMARC_FIELD;
			dr[pMauBienMuc_ChiTietInfo.strGiaTriMacDinh] = pMauBienMuc_ChiTietInfo.GiaTriMacDinh;
			dr[pMauBienMuc_ChiTietInfo.strIDMauBienMuc] = pMauBienMuc_ChiTietInfo.IDMauBienMuc;
        }
        
        public void ToInfo(ref MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo, DataRow dr)
        {

			pMauBienMuc_ChiTietInfo.ID = int.Parse(dr[pMauBienMuc_ChiTietInfo.strID].ToString());
			pMauBienMuc_ChiTietInfo.IDMARC_FIELD = int.Parse(dr[pMauBienMuc_ChiTietInfo.strIDMARC_FIELD].ToString());
			pMauBienMuc_ChiTietInfo.GiaTriMacDinh = dr[pMauBienMuc_ChiTietInfo.strGiaTriMacDinh].ToString();
			pMauBienMuc_ChiTietInfo.IDMauBienMuc = int.Parse(dr[pMauBienMuc_ChiTietInfo.strIDMauBienMuc].ToString());
        }
    }
}
