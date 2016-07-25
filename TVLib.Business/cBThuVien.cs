using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;
using TruongViet.TVLib.Business;


namespace TruongViet.TVLib.Business
{
    public class cBThuVien : cBBase
    {
        private cDThuVien oDThuVien;
        private ThuVienInfo oThuVienInfo;

        public cBThuVien()        
        {
            oDThuVien = new cDThuVien();
        }

        public DataTable Get(ThuVienInfo pThuVienInfo)        
        {
            return oDThuVien.Get(pThuVienInfo);
        }

        public int Add(ThuVienInfo pThuVienInfo)
        {
			int ID = 0;
            ID = oDThuVien.Add(pThuVienInfo);
            mErrorMessage = oDThuVien.ErrorMessages;
            mErrorNumber = oDThuVien.ErrorNumber;
            return ID;
        }

        public int  Update(ThuVienInfo pThuVienInfo)
        {
            int ID = 0;
            ID = oDThuVien.Update(pThuVienInfo);
            mErrorMessage = oDThuVien.ErrorMessages;
            mErrorNumber = oDThuVien.ErrorNumber;
            return ID;
        }

        public void GopThuVien(ThuVienInfo pThuVienInfo, int intThuVienIDGop)
        {
            oDThuVien.GopThuVien(pThuVienInfo, intThuVienIDGop);
            mErrorMessage = oDThuVien.ErrorMessages;
            mErrorNumber = oDThuVien.ErrorNumber;
        }

        public void Delete(ThuVienInfo pThuVienInfo)
        {
            oDThuVien.Delete(pThuVienInfo);
            mErrorMessage = oDThuVien.ErrorMessages;
            mErrorNumber = oDThuVien.ErrorNumber;
        }

        public List<ThuVienInfo> GetList(ThuVienInfo pThuVienInfo)
        {
            List<ThuVienInfo> oThuVienInfoList = new List<ThuVienInfo>();
            DataTable dtb = Get(pThuVienInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oThuVienInfo = new ThuVienInfo();
                    

                    oThuVienInfo.ThuVienID = int.Parse(dtb.Rows[i]["ThuVienID"].ToString());
                    oThuVienInfo.TenThuVien = dtb.Rows[i]["TenThuVien"].ToString();
                    oThuVienInfo.MaThuVien = dtb.Rows[i]["MaThuVien"].ToString();
                    
                    oThuVienInfoList.Add(oThuVienInfo);
                }
            }
            return oThuVienInfoList.Count == 0 ? null : oThuVienInfoList;
        }
    }
}
