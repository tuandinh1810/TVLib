using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLibTraCuu.Entity;
using TruongViet.TVLibTraCuu.Data;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBNhatKyHeThong : cBBase
    {
        private cDNhatKyHeThong oDNhatKyHeThong;
        private NhatKyHeThongInfo oNhatKyHeThongInfo;

        public cBNhatKyHeThong()        
        {
            oDNhatKyHeThong = new cDNhatKyHeThong();
        }

        public DataTable Get(NhatKyHeThongInfo pNhatKyHeThongInfo)        
        {
            return oDNhatKyHeThong.Get(pNhatKyHeThongInfo);
        }

        public int Add(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
			int ID = 0;
            ID = oDNhatKyHeThong.Add(pNhatKyHeThongInfo);
            mErrorMessage = oDNhatKyHeThong.ErrorMessages;
            mErrorNumber = oDNhatKyHeThong.ErrorNumber;
            return ID;
        }

        public void Update(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
            oDNhatKyHeThong.Update(pNhatKyHeThongInfo);
            mErrorMessage = oDNhatKyHeThong.ErrorMessages;
            mErrorNumber = oDNhatKyHeThong.ErrorNumber;
        }
        
        public void Delete(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
            oDNhatKyHeThong.Delete(pNhatKyHeThongInfo);
            mErrorMessage = oDNhatKyHeThong.ErrorMessages;
            mErrorNumber = oDNhatKyHeThong.ErrorNumber;
        }

        public List<NhatKyHeThongInfo> GetList(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
            List<NhatKyHeThongInfo> oNhatKyHeThongInfoList = new List<NhatKyHeThongInfo>();
            DataTable dtb = Get(pNhatKyHeThongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNhatKyHeThongInfo = new NhatKyHeThongInfo();
                    

                    oNhatKyHeThongInfo.NhatKy_ID = int.Parse(dtb.Rows[i]["NhatKy_ID"].ToString());
                    oNhatKyHeThongInfo.IPMay = dtb.Rows[i]["IPMay"].ToString();
                    oNhatKyHeThongInfo.TenDangNhap = dtb.Rows[i]["TenDangNhap"].ToString();
                    oNhatKyHeThongInfo.CongViec = dtb.Rows[i]["CongViec"].ToString();
                    oNhatKyHeThongInfo.ThoiGian = DateTime.Parse(dtb.Rows[i]["ThoiGian"].ToString());
                    oNhatKyHeThongInfo.ID_ChucNang = int.Parse(dtb.Rows[i]["ID_ChucNang"].ToString());
                    
                    oNhatKyHeThongInfoList.Add(oNhatKyHeThongInfo);
                }
            }
            return oNhatKyHeThongInfoList.Count == 0 ? null : oNhatKyHeThongInfoList;
        }
    }
}
