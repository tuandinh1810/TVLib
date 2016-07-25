using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBLoaiTaiLieu : cBBase
    {
        private cDLoaiTaiLieu oDLoaiTaiLieu;
        private LoaiTaiLieuInfo oLoaiTaiLieuInfo;

        public cBLoaiTaiLieu()        
        {
            oDLoaiTaiLieu = new cDLoaiTaiLieu();
        }

        public DataTable Get(LoaiTaiLieuInfo pLoaiTaiLieuInfo)        
        {
            return oDLoaiTaiLieu.Get(pLoaiTaiLieuInfo);
        }

        public int Add(LoaiTaiLieuInfo pLoaiTaiLieuInfo)
        {
			int ID = 0;
            ID = oDLoaiTaiLieu.Add(pLoaiTaiLieuInfo);
            mErrorMessage = oDLoaiTaiLieu.ErrorMessages;
            mErrorNumber = oDLoaiTaiLieu.ErrorNumber;
            return ID;
        }

        public int Update(LoaiTaiLieuInfo pLoaiTaiLieuInfo)
        {
            int ID = 0;
            ID = oDLoaiTaiLieu.Update(pLoaiTaiLieuInfo);
            mErrorMessage = oDLoaiTaiLieu.ErrorMessages;
            mErrorNumber = oDLoaiTaiLieu.ErrorNumber;
            return ID;
        }
        
        public void Delete(LoaiTaiLieuInfo pLoaiTaiLieuInfo)
        {
            oDLoaiTaiLieu.Delete(pLoaiTaiLieuInfo);
            mErrorMessage = oDLoaiTaiLieu.ErrorMessages;
            mErrorNumber = oDLoaiTaiLieu.ErrorNumber;
        }
        public void GopLoaiTaiLieu(LoaiTaiLieuInfo pLoaiTaiLieuInfo, int intLoaiTaiLieuIDGop)
        {
            oDLoaiTaiLieu.GopLoaiTaiLieu(pLoaiTaiLieuInfo, intLoaiTaiLieuIDGop);
            mErrorMessage = oDLoaiTaiLieu.ErrorMessages;
            mErrorNumber = oDLoaiTaiLieu.ErrorNumber;
        }
        public List<LoaiTaiLieuInfo> GetList(LoaiTaiLieuInfo pLoaiTaiLieuInfo)
        {
            List<LoaiTaiLieuInfo> oLoaiTaiLieuInfoList = new List<LoaiTaiLieuInfo>();
            DataTable dtb = Get(pLoaiTaiLieuInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oLoaiTaiLieuInfo = new LoaiTaiLieuInfo();
                    

                    oLoaiTaiLieuInfo.LoaiTaiLieuID = int.Parse(dtb.Rows[i]["LoaiTaiLieuID"].ToString());
                    oLoaiTaiLieuInfo.TenLoaiTaiLieu = dtb.Rows[i]["TenLoaiTaiLieu"].ToString();
                    oLoaiTaiLieuInfo.MoTa = dtb.Rows[i]["MoTa"].ToString();
                    
                    oLoaiTaiLieuInfoList.Add(oLoaiTaiLieuInfo);
                }
            }
            return oLoaiTaiLieuInfoList.Count == 0 ? null : oLoaiTaiLieuInfoList;
        }
    }
}
