using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBQuaTrinhNapTien : cBBase
    {
        private cDQuaTrinhNapTien oDQuaTrinhNapTien;
        private QuaTrinhNapTienInfo oQuaTrinhNapTienInfo;

        public cBQuaTrinhNapTien()        
        {
            oDQuaTrinhNapTien = new cDQuaTrinhNapTien();
        }

        public DataTable Get(QuaTrinhNapTienInfo pQuaTrinhNapTienInfo, int intCheck)        
        {
            return oDQuaTrinhNapTien.Get(pQuaTrinhNapTienInfo, intCheck);
        }
        public DataTable Search(string strMaTaiKhoan, string strThang, string strNam)
        {
            return oDQuaTrinhNapTien.Search(strMaTaiKhoan,strThang,strNam);
        }
       
        public int Add(QuaTrinhNapTienInfo pQuaTrinhNapTienInfo)
        {
			int ID = 0;
            ID = oDQuaTrinhNapTien.Add(pQuaTrinhNapTienInfo);
            mErrorMessage = oDQuaTrinhNapTien.ErrorMessages;
            mErrorNumber = oDQuaTrinhNapTien.ErrorNumber;
            return ID;
        }

        public void Update(QuaTrinhNapTienInfo pQuaTrinhNapTienInfo)
        {
            oDQuaTrinhNapTien.Update(pQuaTrinhNapTienInfo);
            mErrorMessage = oDQuaTrinhNapTien.ErrorMessages;
            mErrorNumber = oDQuaTrinhNapTien.ErrorNumber;
        }
        
        public void Delete(QuaTrinhNapTienInfo pQuaTrinhNapTienInfo)
        {
            oDQuaTrinhNapTien.Delete(pQuaTrinhNapTienInfo);
            mErrorMessage = oDQuaTrinhNapTien.ErrorMessages;
            mErrorNumber = oDQuaTrinhNapTien.ErrorNumber;
        }

        public List<QuaTrinhNapTienInfo> GetList(QuaTrinhNapTienInfo pQuaTrinhNapTienInfo)
        {
            List<QuaTrinhNapTienInfo> oQuaTrinhNapTienInfoList = new List<QuaTrinhNapTienInfo>();
            DataTable dtb = Get(pQuaTrinhNapTienInfo,0);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oQuaTrinhNapTienInfo = new QuaTrinhNapTienInfo();
                    

                    oQuaTrinhNapTienInfo.QuaTrinhNapTienID = int.Parse(dtb.Rows[i]["QuaTrinhNapTienID"].ToString());
                    oQuaTrinhNapTienInfo.IDTaiKhoan = int.Parse(dtb.Rows[i]["IDTaiKhoan"].ToString());
                    oQuaTrinhNapTienInfo.NgayNapTien = DateTime.Parse(dtb.Rows[i]["NgayNapTien"].ToString());
                    oQuaTrinhNapTienInfo.SoTienNap = float.Parse(dtb.Rows[i]["SoTienNap"].ToString());
                    
                    oQuaTrinhNapTienInfoList.Add(oQuaTrinhNapTienInfo);
                }
            }
            return oQuaTrinhNapTienInfoList.Count == 0 ? null : oQuaTrinhNapTienInfoList;
        }
    }
}
