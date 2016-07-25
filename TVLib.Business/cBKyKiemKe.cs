using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBKyKiemKe : cBBase
    {
        private cDKyKiemKe oDKyKiemKe;
        private KyKiemKeInfo oKyKiemKeInfo;

        public cBKyKiemKe()        
        {
            oDKyKiemKe = new cDKyKiemKe();
        }

        public DataTable Get(KyKiemKeInfo pKyKiemKeInfo)        
        {
            return oDKyKiemKe.Get(pKyKiemKeInfo);
        }

        public int Add(KyKiemKeInfo pKyKiemKeInfo)
        {
			int ID = 0;
            ID = oDKyKiemKe.Add(pKyKiemKeInfo);
            mErrorMessage = oDKyKiemKe.ErrorMessages;
            mErrorNumber = oDKyKiemKe.ErrorNumber;
            return ID;
        }

        public void Update(KyKiemKeInfo pKyKiemKeInfo)
        {
            oDKyKiemKe.Update(pKyKiemKeInfo);
            mErrorMessage = oDKyKiemKe.ErrorMessages;
            mErrorNumber = oDKyKiemKe.ErrorNumber;
        }
        
        public void Delete(KyKiemKeInfo pKyKiemKeInfo)
        {
            oDKyKiemKe.Delete(pKyKiemKeInfo);
            mErrorMessage = oDKyKiemKe.ErrorMessages;
            mErrorNumber = oDKyKiemKe.ErrorNumber;
        }

        public List<KyKiemKeInfo> GetList(KyKiemKeInfo pKyKiemKeInfo)
        {
            List<KyKiemKeInfo> oKyKiemKeInfoList = new List<KyKiemKeInfo>();
            DataTable dtb = Get(pKyKiemKeInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKyKiemKeInfo = new KyKiemKeInfo();

                    oKyKiemKeInfo.KyKiemKeID = int.Parse(dtb.Rows[i]["KyKiemKeID"].ToString());
                    oKyKiemKeInfo.TenKyKiemKe = dtb.Rows[i]["TenKyKiemKe"].ToString();
                    oKyKiemKeInfo.TrangThai = bool.Parse(dtb.Rows[i]["TrangThai"].ToString());
                    oKyKiemKeInfo.NgayKiemKe = DateTime.Parse(dtb.Rows[i]["NgayKiemKe"].ToString());
                    
                    oKyKiemKeInfoList.Add(oKyKiemKeInfo);
                }
            }
            return oKyKiemKeInfoList;
        }
        
        public void ToDataRow(KyKiemKeInfo pKyKiemKeInfo, ref DataRow dr)
        {

			dr[pKyKiemKeInfo.strKyKiemKeID] = pKyKiemKeInfo.KyKiemKeID;
			dr[pKyKiemKeInfo.strTenKyKiemKe] = pKyKiemKeInfo.TenKyKiemKe;
			dr[pKyKiemKeInfo.strTrangThai] = pKyKiemKeInfo.TrangThai;
			dr[pKyKiemKeInfo.strNgayKiemKe] = pKyKiemKeInfo.NgayKiemKe;
        }
        
        public void ToInfo(ref KyKiemKeInfo pKyKiemKeInfo, DataRow dr)
        {

			pKyKiemKeInfo.KyKiemKeID = int.Parse(dr[pKyKiemKeInfo.strKyKiemKeID].ToString());
			pKyKiemKeInfo.TenKyKiemKe = dr[pKyKiemKeInfo.strTenKyKiemKe].ToString();
			pKyKiemKeInfo.TrangThai = bool.Parse(dr[pKyKiemKeInfo.strTrangThai].ToString());
			pKyKiemKeInfo.NgayKiemKe = DateTime.Parse(dr[pKyKiemKeInfo.strNgayKiemKe].ToString());
        }
    }
}
