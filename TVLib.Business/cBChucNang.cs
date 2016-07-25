using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBChucNang : cBBase
    {
        private cDChucNang oDChucNang;
        private ChucNangInfo oChucNangInfo;

        public cBChucNang()        
        {
            oDChucNang = new cDChucNang();
        }
        public DataTable GetQuyenKhongDuocCap(int IDNguoiDung, int IDPhanHe)
        {
            return oDChucNang.GetQuyenKhongDuocCap(IDNguoiDung, IDPhanHe);
        }
        public DataTable GetQuyenDuocCap(int IDNguoiDung, int IDPhanHe)
        {
            return oDChucNang.GetQuyenDuocCap(IDNguoiDung, IDPhanHe);
        }
        public DataTable Get(ChucNangInfo pChucNangInfo)        
        {
            return oDChucNang.Get(pChucNangInfo);
        }
        public DataTable GetByPhanHe(ChucNangInfo pChucNangInfo)
        {
            return oDChucNang.GetByPhanHe(pChucNangInfo);
        }
        public DataTable GetByMaChucNang(ChucNangInfo pChucNangInfo)
        {
            return oDChucNang.GetByMaChucNang(pChucNangInfo);
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
                    
                    oChucNangInfoList.Add(oChucNangInfo);
                }
            }
            return oChucNangInfoList.Count == 0 ? null : oChucNangInfoList;
        }
        public List<ChucNangInfo> Get_ByMaChucNang_List(ChucNangInfo pChucNangInfo)
        {
            List<ChucNangInfo> oChucNangInfoList = new List<ChucNangInfo>();
            DataTable dtb = GetByMaChucNang(pChucNangInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
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
