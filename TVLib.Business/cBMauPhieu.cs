using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBMauPhieu : cBBase
    {
        private cDMauPhieu oDMauPhieu;
        private MauPhieuInfo oMauPhieuInfo;

        public cBMauPhieu()        
        {
            oDMauPhieu = new cDMauPhieu();
        }

        public DataTable Get(MauPhieuInfo pMauPhieuInfo)        
        {
            return oDMauPhieu.Get(pMauPhieuInfo);
        }

        public int Add(MauPhieuInfo pMauPhieuInfo)
        {
			int ID = 0;
            ID = oDMauPhieu.Add(pMauPhieuInfo);
            mErrorMessage = oDMauPhieu.ErrorMessages;
            mErrorNumber = oDMauPhieu.ErrorNumber;
            return ID;
        }

        public void Update(MauPhieuInfo pMauPhieuInfo)
        {
            oDMauPhieu.Update(pMauPhieuInfo);
            mErrorMessage = oDMauPhieu.ErrorMessages;
            mErrorNumber = oDMauPhieu.ErrorNumber;
        }
        
        public void Delete(MauPhieuInfo pMauPhieuInfo)
        {
            oDMauPhieu.Delete(pMauPhieuInfo);
            mErrorMessage = oDMauPhieu.ErrorMessages;
            mErrorNumber = oDMauPhieu.ErrorNumber;
        }

        public List<MauPhieuInfo> GetList(MauPhieuInfo pMauPhieuInfo)
        {
            List<MauPhieuInfo> oMauPhieuInfoList = new List<MauPhieuInfo>();
            DataTable dtb = Get(pMauPhieuInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oMauPhieuInfo = new MauPhieuInfo();

                    oMauPhieuInfo.MauPhieuID = int.Parse(dtb.Rows[i]["MauPhieuID"].ToString());
                    oMauPhieuInfo.TenMauPhieu = dtb.Rows[i]["TenMauPhieu"].ToString();
                    oMauPhieuInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
                    oMauPhieuInfo.NgayTao = DateTime.Parse(dtb.Rows[i]["NgayTao"].ToString());
                    oMauPhieuInfo.LoaiPhieu = int.Parse(dtb.Rows[i]["LoaiPhieu"].ToString());
                    
                    oMauPhieuInfoList.Add(oMauPhieuInfo);
                }
            }
            return oMauPhieuInfoList;
        }
        
        public void ToDataRow(MauPhieuInfo pMauPhieuInfo, ref DataRow dr)
        {

			dr[pMauPhieuInfo.strMauPhieuID] = pMauPhieuInfo.MauPhieuID;
			dr[pMauPhieuInfo.strTenMauPhieu] = pMauPhieuInfo.TenMauPhieu;
			dr[pMauPhieuInfo.strNoiDung] = pMauPhieuInfo.NoiDung;
			dr[pMauPhieuInfo.strNgayTao] = pMauPhieuInfo.NgayTao;
			dr[pMauPhieuInfo.strLoaiPhieu] = pMauPhieuInfo.LoaiPhieu;
        }
        
        public void ToInfo(ref MauPhieuInfo pMauPhieuInfo, DataRow dr)
        {

			pMauPhieuInfo.MauPhieuID = int.Parse(dr[pMauPhieuInfo.strMauPhieuID].ToString());
			pMauPhieuInfo.TenMauPhieu = dr[pMauPhieuInfo.strTenMauPhieu].ToString();
			pMauPhieuInfo.NoiDung = dr[pMauPhieuInfo.strNoiDung].ToString();
			pMauPhieuInfo.NgayTao = DateTime.Parse(dr[pMauPhieuInfo.strNgayTao].ToString());
			pMauPhieuInfo.LoaiPhieu = int.Parse(dr[pMauPhieuInfo.strLoaiPhieu].ToString());
        }
    }
}
