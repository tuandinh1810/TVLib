using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBMARC_FIELD : cBBase
    {
        private cDMARC_FIELD oDMARC_FIELD;
        private MARC_FIELDInfo oMARC_FIELDInfo;

        public cBMARC_FIELD()        
        {
            oDMARC_FIELD = new cDMARC_FIELD();
        }

        public DataTable Get(MARC_FIELDInfo pMARC_FIELDInfo)        
        {
            return oDMARC_FIELD.Get(pMARC_FIELDInfo);
        }
        public DataTable Get_ByMARC(int IDMarc)
        {
            return oDMARC_FIELD.Get_ByMARC(IDMarc);
        }
        public DataTable Get_ByParent(int IDParent)
        {
            return oDMARC_FIELD.Get_ByParent(IDParent);
        }
        public int Add(MARC_FIELDInfo pMARC_FIELDInfo)
        {
			int ID = 0;
            ID = oDMARC_FIELD.Add(pMARC_FIELDInfo);
            mErrorMessage = oDMARC_FIELD.ErrorMessages;
            mErrorNumber = oDMARC_FIELD.ErrorNumber;
            return ID;
        }

        public void Update(MARC_FIELDInfo pMARC_FIELDInfo)
        {
            oDMARC_FIELD.Update(pMARC_FIELDInfo);
            mErrorMessage = oDMARC_FIELD.ErrorMessages;
            mErrorNumber = oDMARC_FIELD.ErrorNumber;
        }
        
        public void Delete(MARC_FIELDInfo pMARC_FIELDInfo)
        {
            oDMARC_FIELD.Delete(pMARC_FIELDInfo);
            mErrorMessage = oDMARC_FIELD.ErrorMessages;
            mErrorNumber = oDMARC_FIELD.ErrorNumber;
        }

        public List<MARC_FIELDInfo> GetList(MARC_FIELDInfo pMARC_FIELDInfo)
        {
            List<MARC_FIELDInfo> oMARC_FIELDInfoList = new List<MARC_FIELDInfo>();
            DataTable dtb = Get(pMARC_FIELDInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oMARC_FIELDInfo = new MARC_FIELDInfo();

                    oMARC_FIELDInfo.MARC_FIELD_ID = int.Parse(dtb.Rows[i]["MARC_FIELD_ID"].ToString());
                    oMARC_FIELDInfo.Name = dtb.Rows[i]["Name"].ToString();
                    oMARC_FIELDInfo.Code = dtb.Rows[i]["Code"].ToString();
                    oMARC_FIELDInfo.ID_MARC = int.Parse(dtb.Rows[i]["ID_MARC"].ToString());
                    oMARC_FIELDInfo.Repeat = bool.Parse(dtb.Rows[i]["Repeat"].ToString());
                    oMARC_FIELDInfo.ID_FieldType = int.Parse(dtb.Rows[i]["ID_FieldType"].ToString());
                    oMARC_FIELDInfo.ParentID = int.Parse(dtb.Rows[i]["ParentID"].ToString());
                    
                    oMARC_FIELDInfoList.Add(oMARC_FIELDInfo);
                }
            }
            return oMARC_FIELDInfoList;
        }
        
        public void ToDataRow(MARC_FIELDInfo pMARC_FIELDInfo, ref DataRow dr)
        {

			dr[pMARC_FIELDInfo.strMARC_FIELD_ID] = pMARC_FIELDInfo.MARC_FIELD_ID;
			dr[pMARC_FIELDInfo.strName] = pMARC_FIELDInfo.Name;
			dr[pMARC_FIELDInfo.strCode] = pMARC_FIELDInfo.Code;
			dr[pMARC_FIELDInfo.strID_MARC] = pMARC_FIELDInfo.ID_MARC;
			dr[pMARC_FIELDInfo.strRepeat] = pMARC_FIELDInfo.Repeat;
			dr[pMARC_FIELDInfo.strID_FieldType] = pMARC_FIELDInfo.ID_FieldType;
			dr[pMARC_FIELDInfo.strParentID] = pMARC_FIELDInfo.ParentID;
        }
        
        public void ToInfo(ref MARC_FIELDInfo pMARC_FIELDInfo, DataRow dr)
        {

			pMARC_FIELDInfo.MARC_FIELD_ID = int.Parse(dr[pMARC_FIELDInfo.strMARC_FIELD_ID].ToString());
			pMARC_FIELDInfo.Name = dr[pMARC_FIELDInfo.strName].ToString();
			pMARC_FIELDInfo.Code = dr[pMARC_FIELDInfo.strCode].ToString();
			pMARC_FIELDInfo.ID_MARC = int.Parse(dr[pMARC_FIELDInfo.strID_MARC].ToString());
			pMARC_FIELDInfo.Repeat = bool.Parse(dr[pMARC_FIELDInfo.strRepeat].ToString());
			pMARC_FIELDInfo.ID_FieldType = int.Parse(dr[pMARC_FIELDInfo.strID_FieldType].ToString());
			pMARC_FIELDInfo.ParentID = int.Parse(dr[pMARC_FIELDInfo.strParentID].ToString());
        }
    }
}
