using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBMaXepGia : cBBase
    {
        private cDMaXepGia oDMaXepGia;
        private MaXepGiaInfo oMaXepGiaInfo;

        public cBMaXepGia()        
        {
            oDMaXepGia = new cDMaXepGia();
        }

        public DataTable Get(MaXepGiaInfo pMaXepGiaInfo)        
        {
            return oDMaXepGia.Get(pMaXepGiaInfo);
        }
        public DataTable GetByIDTaiLieu(MaXepGiaInfo pMaXepGiaInfo)
        {
            return oDMaXepGia.GetByIDTaiLieu(pMaXepGiaInfo);
        }

        public int Add(MaXepGiaInfo pMaXepGiaInfo)
        {
			int ID = 0;
            ID = oDMaXepGia.Add(pMaXepGiaInfo);
            mErrorMessage = oDMaXepGia.ErrorMessages;
            mErrorNumber = oDMaXepGia.ErrorNumber;
            return ID;
        }

        public void Update(MaXepGiaInfo pMaXepGiaInfo)
        {
            oDMaXepGia.Update(pMaXepGiaInfo);
            mErrorMessage = oDMaXepGia.ErrorMessages;
            mErrorNumber = oDMaXepGia.ErrorNumber;
        }
        
        public void Delete(MaXepGiaInfo pMaXepGiaInfo)
        {
            oDMaXepGia.Delete(pMaXepGiaInfo);
            mErrorMessage = oDMaXepGia.ErrorMessages;
            mErrorNumber = oDMaXepGia.ErrorNumber;
        }

        public List<MaXepGiaInfo> GetList(MaXepGiaInfo pMaXepGiaInfo)
        {
            List<MaXepGiaInfo> oMaXepGiaInfoList = new List<MaXepGiaInfo>();
            DataTable dtb = Get(pMaXepGiaInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oMaXepGiaInfo = new MaXepGiaInfo();
                    

                    oMaXepGiaInfo.MaXepGia = dtb.Rows[i]["MaXepGia"].ToString();
                    oMaXepGiaInfo.LuuThong = bool.Parse(dtb.Rows[i]["LuuThong"].ToString());
                    oMaXepGiaInfo.DangMuon = bool.Parse(dtb.Rows[i]["DangMuon"].ToString());
                    oMaXepGiaInfo.IDTaiLieu = int.Parse(dtb.Rows[i]["IDTaiLieu"].ToString());
                    
                    oMaXepGiaInfoList.Add(oMaXepGiaInfo);
                }
            }
            return oMaXepGiaInfoList.Count == 0 ? null : oMaXepGiaInfoList;
        }
    }
}
