using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBNhatKyHeThong : cBBase
    {
        private cDNhatKyHeThong  oDNhatKyHeThong;
        private NhatKyHeThongInfo oNhatKyHeThongInfo;

        public cBNhatKyHeThong()        
        {
            oDNhatKyHeThong = new cDNhatKyHeThong();
        }
         //Search method
        //Purpose: Get logs informations
        //Input: some logs information
        //Output: datatable result
        public DataTable Search(string strPhanHeIDs, string strChucNangIDs, string strChuoi, string strFromTime, string strToTime, string strTenDangNhap) 
        {
                      
               return  oDNhatKyHeThong.Search(strPhanHeIDs,strChucNangIDs,strChuoi, strFromTime,strToTime,strTenDangNhap );
                mErrorMessage = oDNhatKyHeThong.ErrorMessages;
                mErrorNumber = oDNhatKyHeThong.ErrorNumber;
          
        }
        public void SetLogMode(int IDPhanHe, string ChucNangIDs)
        {
            oDNhatKyHeThong.SetLogMode(IDPhanHe, ChucNangIDs);
            mErrorMessage = oDNhatKyHeThong.ErrorMessages;
            mErrorNumber = oDNhatKyHeThong.ErrorNumber;

        }
        public DataTable Get(NhatKyHeThongInfo pNhatKyHeThongInfo)        
        {
            return oDNhatKyHeThong.Get(pNhatKyHeThongInfo);
            mErrorMessage = oDNhatKyHeThong.ErrorMessages;
            mErrorNumber = oDNhatKyHeThong.ErrorNumber;
        }

        public void Add(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
			 oDNhatKyHeThong.Add(pNhatKyHeThongInfo);
            mErrorMessage = oDNhatKyHeThong.ErrorMessages;
            mErrorNumber = oDNhatKyHeThong.ErrorNumber;
           
        }
        public void DeleteLogs(string FromTime, string ToTime)
        {
            oDNhatKyHeThong.DeleteLogs(FromTime, ToTime);
            mErrorMessage = oDNhatKyHeThong.ErrorMessages;
            mErrorNumber = oDNhatKyHeThong.ErrorNumber;
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
                    
                    oNhatKyHeThongInfoList.Add(oNhatKyHeThongInfo);
                }
            }
            return oNhatKyHeThongInfoList.Count == 0 ? null : oNhatKyHeThongInfoList;
        }
    }
}
