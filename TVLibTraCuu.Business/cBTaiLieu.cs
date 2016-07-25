using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBTaiLieu : cBBase
    {
        private cDTaiLieu oDTaiLieu;
        private TaiLieuInfo oTaiLieuInfo;

        public cBTaiLieu()        
        {
            oDTaiLieu = new cDTaiLieu();
        }

        public DataTable Get(TaiLieuInfo pTaiLieuInfo)
        {
            return oDTaiLieu.Get(pTaiLieuInfo);
        }
        public DataTable GetTaiLieuInfo(TaiLieuInfo pTaiLieuInfo)
        {
            return oDTaiLieu.GetTaiLieuInfo(pTaiLieuInfo);
        }
        public DataTable GetSoTapChiByTaiLieuID(TaiLieuInfo pTaiLieuInfo)
        {
            return oDTaiLieu.GetSoTapChiByTaiLieuID(pTaiLieuInfo);
        } 
        public DataTable GetTop20(TaiLieuInfo pTaiLieuInfo)
        {
            return oDTaiLieu.GetTop20(pTaiLieuInfo);
        }

        public DataTable Get20MuonNhieuNhat(TaiLieuInfo pTaiLieuInfo)
        {
            return oDTaiLieu.Get20MuonNhieuNhat(pTaiLieuInfo);
        }

        public int Add(TaiLieuInfo pTaiLieuInfo)
        {
			int ID = 0;
            ID = oDTaiLieu.Add(pTaiLieuInfo);
            mErrorMessage = oDTaiLieu.ErrorMessages;
            mErrorNumber = oDTaiLieu.ErrorNumber;
            return ID;
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
                for (int i=0;i<dtb.Rows.Count;i++)
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
