using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBNguoiDung_ChucNang : cBBase
    {
        private cDNguoiDung_ChucNang oDNguoiDung_ChucNang;
        private NguoiDung_ChucNangInfo oNguoiDung_ChucNangInfo;

        public cBNguoiDung_ChucNang()        
        {
            oDNguoiDung_ChucNang = new cDNguoiDung_ChucNang();
        }

        public DataTable Get(NguoiDung_ChucNangInfo pNguoiDung_ChucNangInfo)        
        {
            return oDNguoiDung_ChucNang.Get(pNguoiDung_ChucNangInfo);
        }

        public int Add(NguoiDung_ChucNangInfo pNguoiDung_ChucNangInfo)
        {
			int ID = 0;
            ID = oDNguoiDung_ChucNang.Add(pNguoiDung_ChucNangInfo);
            mErrorMessage = oDNguoiDung_ChucNang.ErrorMessages;
            mErrorNumber = oDNguoiDung_ChucNang.ErrorNumber;
            return ID;
        }

        public void Update(NguoiDung_ChucNangInfo pNguoiDung_ChucNangInfo)
        {
            oDNguoiDung_ChucNang.Update(pNguoiDung_ChucNangInfo);
            mErrorMessage = oDNguoiDung_ChucNang.ErrorMessages;
            mErrorNumber = oDNguoiDung_ChucNang.ErrorNumber;
        }
        
        public void Delete(NguoiDung_ChucNangInfo pNguoiDung_ChucNangInfo)
        {
            oDNguoiDung_ChucNang.Delete(pNguoiDung_ChucNangInfo);
            mErrorMessage = oDNguoiDung_ChucNang.ErrorMessages;
            mErrorNumber = oDNguoiDung_ChucNang.ErrorNumber;
        }

        public List<NguoiDung_ChucNangInfo> GetList(NguoiDung_ChucNangInfo pNguoiDung_ChucNangInfo)
        {
            List<NguoiDung_ChucNangInfo> oNguoiDung_ChucNangInfoList = new List<NguoiDung_ChucNangInfo>();
            DataTable dtb = Get(pNguoiDung_ChucNangInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNguoiDung_ChucNangInfo = new NguoiDung_ChucNangInfo();
                    

                    oNguoiDung_ChucNangInfo.NguoiDung_ChucNang_ID = int.Parse(dtb.Rows[i]["NguoiDung_ChucNang_ID"].ToString());
                    oNguoiDung_ChucNangInfo.IDNguoiDung = int.Parse(dtb.Rows[i]["IDNguoiDung"].ToString());
                    oNguoiDung_ChucNangInfo.IDChucNang = int.Parse(dtb.Rows[i]["IDChucNang"].ToString());
                    
                    oNguoiDung_ChucNangInfoList.Add(oNguoiDung_ChucNangInfo);
                }
            }
            return oNguoiDung_ChucNangInfoList.Count == 0 ? null : oNguoiDung_ChucNangInfoList;
        }
    }
}
