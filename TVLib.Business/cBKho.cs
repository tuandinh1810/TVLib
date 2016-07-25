using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBKho : cBBase
    {
        private cDKho oDKho;
        private KhoInfo oKhoInfo;

        public cBKho()        
        {
            oDKho = new cDKho();
        }

        public DataTable Get(KhoInfo pKhoInfo)        
        {
            return oDKho.Get(pKhoInfo);
        }

        public DataTable GetByThuVienID(int intThuVienID)
        {
            return oDKho.GetByThuVienID(intThuVienID);
        }
        public DataTable GetByThuVien(KhoInfo pKhoInfo)
        {
            return oDKho.GetByThuVien(pKhoInfo);
        }

        public int Add(KhoInfo pKhoInfo)
        {
			int ID = 0;
            ID = oDKho.Add(pKhoInfo);
            mErrorMessage = oDKho.ErrorMessages;
            mErrorNumber = oDKho.ErrorNumber;
            return ID;
        }
        public void UpdateMaxMaXepGia(int intKhoID,int intMaxMaXepGia)
        {
            oDKho.Update_MaxMaXepGia(intKhoID, intMaxMaXepGia);
            mErrorMessage = oDKho.ErrorMessages;
            mErrorNumber = oDKho.ErrorNumber;
        }
        public void Update_TrangThai(string KhoiIDs, int TrangThai)
        {
            oDKho.Update_TrangThai(KhoiIDs, TrangThai);
            mErrorMessage = oDKho.ErrorMessages;
            mErrorNumber = oDKho.ErrorNumber;
        }
        public int  Update(KhoInfo pKhoInfo)
        {
            int ID = 0;
            ID = oDKho.Update(pKhoInfo);
            mErrorMessage = oDKho.ErrorMessages;
            mErrorNumber = oDKho.ErrorNumber;
            return ID;
        }

        public void GopKho(KhoInfo pKhoInfo, int intKhoIDGop)
        {
            oDKho.GopKho(pKhoInfo, intKhoIDGop);
            mErrorMessage = oDKho.ErrorMessages;
            mErrorNumber = oDKho.ErrorNumber;
        }

        public void Delete(KhoInfo pKhoInfo)
        {
            oDKho.Delete(pKhoInfo);
            mErrorMessage = oDKho.ErrorMessages;
            mErrorNumber = oDKho.ErrorNumber;
        }

        public List<KhoInfo> GetList(KhoInfo pKhoInfo)
        {
            List<KhoInfo> oKhoInfoList = new List<KhoInfo>();
            DataTable dtb = Get(pKhoInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKhoInfo = new KhoInfo();
                    

                    oKhoInfo.KhoID = int.Parse(dtb.Rows[i]["KhoID"].ToString());
                    oKhoInfo.MaKho = dtb.Rows[i]["MaKho"].ToString();
                    oKhoInfo.TenKho = dtb.Rows[i]["TenKho"].ToString();
                    oKhoInfo.IDThuVien = int.Parse(dtb.Rows[i]["IDThuVien"].ToString());
                    
                    oKhoInfoList.Add(oKhoInfo);
                }
            }
            return oKhoInfoList.Count == 0 ? null : oKhoInfoList;
        }
    }
}
