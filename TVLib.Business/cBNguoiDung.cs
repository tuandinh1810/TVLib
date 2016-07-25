using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBNguoiDung : cBBase
    {
        private cDNguoiDung oDNguoiDung;
        private NguoiDungInfo oNguoiDungInfo;

        public cBNguoiDung()        
        {
            oDNguoiDung = new cDNguoiDung();
        }
        public DataTable Login(NguoiDungInfo pNguoiDungInfo)
        {
            return oDNguoiDung.Login(pNguoiDungInfo);
        }

        public DataTable Get(NguoiDungInfo pNguoiDungInfo)        
        {
            return oDNguoiDung.Get(pNguoiDungInfo);
        }

        public int Add(NguoiDungInfo pNguoiDungInfo)
        {
			int ID = 0;
            ID = oDNguoiDung.Add(pNguoiDungInfo);
            mErrorMessage = oDNguoiDung.ErrorMessages;
            mErrorNumber = oDNguoiDung.ErrorNumber;
            return ID;
        }

        public int Update(NguoiDungInfo pNguoiDungInfo)
        {
          return   oDNguoiDung.Update(pNguoiDungInfo);
            mErrorMessage = oDNguoiDung.ErrorMessages;
            mErrorNumber = oDNguoiDung.ErrorNumber;
        }
        
        public void Delete(NguoiDungInfo pNguoiDungInfo)
        {
            oDNguoiDung.Delete(pNguoiDungInfo);
            mErrorMessage = oDNguoiDung.ErrorMessages;
            mErrorNumber = oDNguoiDung.ErrorNumber;
        }

        public List<NguoiDungInfo> GetList(NguoiDungInfo pNguoiDungInfo)
        {
            List<NguoiDungInfo> oNguoiDungInfoList = new List<NguoiDungInfo>();
            DataTable dtb = Get(pNguoiDungInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNguoiDungInfo = new NguoiDungInfo();
                    

                    oNguoiDungInfo.NguoiDungID = int.Parse(dtb.Rows[i]["NguoiDungID"].ToString());
                    oNguoiDungInfo.TenNguoiDung = dtb.Rows[i]["TenNguoiDung"].ToString();
                    oNguoiDungInfo.TenDangNHap = dtb.Rows[i]["TenDangNHap"].ToString();
                    oNguoiDungInfo.MatKhau = dtb.Rows[i]["MatKhau"].ToString();
                    oNguoiDungInfo.Email = dtb.Rows[i]["Email"].ToString();
                    oNguoiDungInfo.DienThoai = dtb.Rows[i]["DienThoai"].ToString();
                    oNguoiDungInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    
                    oNguoiDungInfoList.Add(oNguoiDungInfo);
                }
            }
            return oNguoiDungInfoList.Count == 0 ? null : oNguoiDungInfoList;
        }
    }
}
