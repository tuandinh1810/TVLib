using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBChucNang : cBBase
    {
        private cDChucNang oDChucNang;
        private ChucNangInfo oChucNangInfo;

        public cBChucNang()        
        {
            oDChucNang = new cDChucNang();
        }

        public DataTable Get(ChucNangInfo pChucNangInfo)        
        {
            return oDChucNang.Get(pChucNangInfo);
        }

        public int Add(ChucNangInfo pChucNangInfo)
        {
			int ID = 0;
            ID = oDChucNang.Add(pChucNangInfo);
            mErrorMessage = oDChucNang.ErrorMessages;
            mErrorNumber = oDChucNang.ErrorNumber;
            return ID;
        }

        public void Update(ChucNangInfo pChucNangInfo)
        {
            oDChucNang.Update(pChucNangInfo);
            mErrorMessage = oDChucNang.ErrorMessages;
            mErrorNumber = oDChucNang.ErrorNumber;
        }
        
        public void Delete(ChucNangInfo pChucNangInfo)
        {
            oDChucNang.Delete(pChucNangInfo);
            mErrorMessage = oDChucNang.ErrorMessages;
            mErrorNumber = oDChucNang.ErrorNumber;
        }

        public List<ChucNangInfo> GetList(ChucNangInfo pChucNangInfo)
        {
            List<ChucNangInfo> oChucNangInfoList = new List<ChucNangInfo>();
            DataTable dtb = Get(pChucNangInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oChucNangInfo = new ChucNangInfo();
                    

                    oChucNangInfo.ChucNangID = int.Parse(dtb.Rows[i]["ChucNangID"].ToString());
                    oChucNangInfo.MaChucNang = dtb.Rows[i]["MaChucNang"].ToString();
                    oChucNangInfo.TenChucNang = dtb.Rows[i]["TenChucNang"].ToString();
                    oChucNangInfo.IDPhanHe = int.Parse(dtb.Rows[i]["IDPhanHe"].ToString());
                    
                    oChucNangInfoList.Add(oChucNangInfo);
                }
            }
            return oChucNangInfoList.Count == 0 ? null : oChucNangInfoList;
        }
    }
}
