using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBXepGia_LyDoThanhLy : cBBase
    {
        private cDXepGia_LyDoThanhLy oDXepGia_LyDoThanhLy;
        private XepGia_LyDoThanhLyInfo oXepGia_LyDoThanhLyInfo;

        public cBXepGia_LyDoThanhLy()        
        {
            oDXepGia_LyDoThanhLy = new cDXepGia_LyDoThanhLy();
        }

        public DataTable Get(XepGia_LyDoThanhLyInfo pXepGia_LyDoThanhLyInfo)        
        {
            return oDXepGia_LyDoThanhLy.Get(pXepGia_LyDoThanhLyInfo);
        }

        public int Add(XepGia_LyDoThanhLyInfo pXepGia_LyDoThanhLyInfo)
        {
			int ID = 0;
            ID = oDXepGia_LyDoThanhLy.Add(pXepGia_LyDoThanhLyInfo);
            mErrorMessage = oDXepGia_LyDoThanhLy.ErrorMessages;
            mErrorNumber = oDXepGia_LyDoThanhLy.ErrorNumber;
            return ID;
        }

        public void Update(XepGia_LyDoThanhLyInfo pXepGia_LyDoThanhLyInfo)
        {
            oDXepGia_LyDoThanhLy.Update(pXepGia_LyDoThanhLyInfo);
            mErrorMessage = oDXepGia_LyDoThanhLy.ErrorMessages;
            mErrorNumber = oDXepGia_LyDoThanhLy.ErrorNumber;
        }
        
        public void Delete(XepGia_LyDoThanhLyInfo pXepGia_LyDoThanhLyInfo)
        {
            oDXepGia_LyDoThanhLy.Delete(pXepGia_LyDoThanhLyInfo);
            mErrorMessage = oDXepGia_LyDoThanhLy.ErrorMessages;
            mErrorNumber = oDXepGia_LyDoThanhLy.ErrorNumber;
        }

        public List<XepGia_LyDoThanhLyInfo> GetList(XepGia_LyDoThanhLyInfo pXepGia_LyDoThanhLyInfo)
        {
            List<XepGia_LyDoThanhLyInfo> oXepGia_LyDoThanhLyInfoList = new List<XepGia_LyDoThanhLyInfo>();
            DataTable dtb = Get(pXepGia_LyDoThanhLyInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXepGia_LyDoThanhLyInfo = new XepGia_LyDoThanhLyInfo();

                    oXepGia_LyDoThanhLyInfo.LyDoID = int.Parse(dtb.Rows[i]["LyDoID"].ToString());
                    oXepGia_LyDoThanhLyInfo.NoiDungLyDo = dtb.Rows[i]["NoiDungLyDo"].ToString();
                    
                    oXepGia_LyDoThanhLyInfoList.Add(oXepGia_LyDoThanhLyInfo);
                }
            }
            return oXepGia_LyDoThanhLyInfoList;
        }
        
        public void ToDataRow(XepGia_LyDoThanhLyInfo pXepGia_LyDoThanhLyInfo, ref DataRow dr)
        {

			dr[pXepGia_LyDoThanhLyInfo.strLyDoID] = pXepGia_LyDoThanhLyInfo.LyDoID;
			dr[pXepGia_LyDoThanhLyInfo.strNoiDungLyDo] = pXepGia_LyDoThanhLyInfo.NoiDungLyDo;
        }
        
        public void ToInfo(ref XepGia_LyDoThanhLyInfo pXepGia_LyDoThanhLyInfo, DataRow dr)
        {

			pXepGia_LyDoThanhLyInfo.LyDoID = int.Parse(dr[pXepGia_LyDoThanhLyInfo.strLyDoID].ToString());
			pXepGia_LyDoThanhLyInfo.NoiDungLyDo = dr[pXepGia_LyDoThanhLyInfo.strNoiDungLyDo].ToString();
        }
    }
}
