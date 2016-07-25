using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBNhanGay : cBBase
    {
        private cDNhanGay oDNhanGay;
        private NhanGayInfo oNhanGayInfo;

        public cBNhanGay()        
        {
            oDNhanGay = new cDNhanGay();
        }

        public DataTable Get(NhanGayInfo pNhanGayInfo)        
        {
            return oDNhanGay.Get(pNhanGayInfo);
        }

        public int Add(NhanGayInfo pNhanGayInfo)
        {
			int ID = 0;
            ID = oDNhanGay.Add(pNhanGayInfo);
            mErrorMessage = oDNhanGay.ErrorMessages;
            mErrorNumber = oDNhanGay.ErrorNumber;
            return ID;
        }

        public void Update(NhanGayInfo pNhanGayInfo)
        {
            oDNhanGay.Update(pNhanGayInfo);
            mErrorMessage = oDNhanGay.ErrorMessages;
            mErrorNumber = oDNhanGay.ErrorNumber;
        }
        
        public void Delete(NhanGayInfo pNhanGayInfo)
        {
            oDNhanGay.Delete(pNhanGayInfo);
            mErrorMessage = oDNhanGay.ErrorMessages;
            mErrorNumber = oDNhanGay.ErrorNumber;
        }

        public List<NhanGayInfo> GetList(NhanGayInfo pNhanGayInfo)
        {
            List<NhanGayInfo> oNhanGayInfoList = new List<NhanGayInfo>();
            DataTable dtb = Get(pNhanGayInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNhanGayInfo = new NhanGayInfo();

                    oNhanGayInfo.NhanGayID = int.Parse(dtb.Rows[i]["NhanGayID"].ToString());
                    oNhanGayInfo.TenNhanGay = dtb.Rows[i]["TenNhanGay"].ToString();
                    oNhanGayInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
                    
                    oNhanGayInfoList.Add(oNhanGayInfo);
                }
            }
            return oNhanGayInfoList;
        }
        
        public void ToDataRow(NhanGayInfo pNhanGayInfo, ref DataRow dr)
        {

			dr[pNhanGayInfo.strNhanGayID] = pNhanGayInfo.NhanGayID;
			dr[pNhanGayInfo.strTenNhanGay] = pNhanGayInfo.TenNhanGay;
			dr[pNhanGayInfo.strNoiDung] = pNhanGayInfo.NoiDung;
        }
        
        public void ToInfo(ref NhanGayInfo pNhanGayInfo, DataRow dr)
        {

			pNhanGayInfo.NhanGayID = int.Parse(dr[pNhanGayInfo.strNhanGayID].ToString());
			pNhanGayInfo.TenNhanGay = dr[pNhanGayInfo.strTenNhanGay].ToString();
			pNhanGayInfo.NoiDung = dr[pNhanGayInfo.strNoiDung].ToString();
        }
    }
}
