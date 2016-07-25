using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBLoaiTien : cBBase
    {
        private cDLoaiTien oDLoaiTien;
        private LoaiTienInfo oLoaiTienInfo;

        public cBLoaiTien()        
        {
            oDLoaiTien = new cDLoaiTien();
        }

        public DataTable Get(LoaiTienInfo pLoaiTienInfo)        
        {
            return oDLoaiTien.Get(pLoaiTienInfo);
            mErrorMessage = oDLoaiTien.ErrorMessages;
            mErrorNumber = oDLoaiTien.ErrorNumber;
        }

        public int Add(LoaiTienInfo pLoaiTienInfo)
        {
			int ID = 0;
            ID = oDLoaiTien.Add(pLoaiTienInfo);
            mErrorMessage = oDLoaiTien.ErrorMessages;
            mErrorNumber = oDLoaiTien.ErrorNumber;
            return ID;
        }

        public int  Update(LoaiTienInfo pLoaiTienInfo)
        {
           return  oDLoaiTien.Update(pLoaiTienInfo);
            mErrorMessage = oDLoaiTien.ErrorMessages;
            mErrorNumber = oDLoaiTien.ErrorNumber;
        }
        
        public void Delete(LoaiTienInfo pLoaiTienInfo)
        {
            oDLoaiTien.Delete(pLoaiTienInfo);
            mErrorMessage = oDLoaiTien.ErrorMessages;
            mErrorNumber = oDLoaiTien.ErrorNumber;
        }

        public List<LoaiTienInfo> GetList(LoaiTienInfo pLoaiTienInfo)
        {
            List<LoaiTienInfo> oLoaiTienInfoList = new List<LoaiTienInfo>();
            DataTable dtb = Get(pLoaiTienInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oLoaiTienInfo = new LoaiTienInfo();
                    

                    oLoaiTienInfo.LoaiTienID = int.Parse(dtb.Rows[i]["LoaiTienID"].ToString());
                    oLoaiTienInfo.LoaiTien = dtb.Rows[i]["LoaiTien"].ToString();
                    oLoaiTienInfo.TyGia = float.Parse(dtb.Rows[i]["TyGia"].ToString());
                    
                    oLoaiTienInfoList.Add(oLoaiTienInfo);
                }
            }
            return oLoaiTienInfoList.Count == 0 ? null : oLoaiTienInfoList;
        }
    }
}
