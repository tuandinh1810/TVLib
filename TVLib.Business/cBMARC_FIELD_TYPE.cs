using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBMARC_FIELD_TYPE : cBBase
    {
        private cDMARC_FIELD_TYPE oDMARC_FIELD_TYPE;
        private MARC_FIELD_TYPEInfo oMARC_FIELD_TYPEInfo;

        public cBMARC_FIELD_TYPE()        
        {
            oDMARC_FIELD_TYPE = new cDMARC_FIELD_TYPE();
        }

        public DataTable Get(MARC_FIELD_TYPEInfo pMARC_FIELD_TYPEInfo)        
        {
            return oDMARC_FIELD_TYPE.Get(pMARC_FIELD_TYPEInfo);
        }

        public int Add(MARC_FIELD_TYPEInfo pMARC_FIELD_TYPEInfo)
        {
			int ID = 0;
            ID = oDMARC_FIELD_TYPE.Add(pMARC_FIELD_TYPEInfo);
            mErrorMessage = oDMARC_FIELD_TYPE.ErrorMessages;
            mErrorNumber = oDMARC_FIELD_TYPE.ErrorNumber;
            return ID;
        }

        public void Update(MARC_FIELD_TYPEInfo pMARC_FIELD_TYPEInfo)
        {
            oDMARC_FIELD_TYPE.Update(pMARC_FIELD_TYPEInfo);
            mErrorMessage = oDMARC_FIELD_TYPE.ErrorMessages;
            mErrorNumber = oDMARC_FIELD_TYPE.ErrorNumber;
        }
        
        public void Delete(MARC_FIELD_TYPEInfo pMARC_FIELD_TYPEInfo)
        {
            oDMARC_FIELD_TYPE.Delete(pMARC_FIELD_TYPEInfo);
            mErrorMessage = oDMARC_FIELD_TYPE.ErrorMessages;
            mErrorNumber = oDMARC_FIELD_TYPE.ErrorNumber;
        }

        public List<MARC_FIELD_TYPEInfo> GetList(MARC_FIELD_TYPEInfo pMARC_FIELD_TYPEInfo)
        {
            List<MARC_FIELD_TYPEInfo> oMARC_FIELD_TYPEInfoList = new List<MARC_FIELD_TYPEInfo>();
            DataTable dtb = Get(pMARC_FIELD_TYPEInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oMARC_FIELD_TYPEInfo = new MARC_FIELD_TYPEInfo();

                    oMARC_FIELD_TYPEInfo.ID = int.Parse(dtb.Rows[i]["ID"].ToString());
                    oMARC_FIELD_TYPEInfo.FieldType = dtb.Rows[i]["FieldType"].ToString();
                    
                    oMARC_FIELD_TYPEInfoList.Add(oMARC_FIELD_TYPEInfo);
                }
            }
            return oMARC_FIELD_TYPEInfoList;
        }
        
        public void ToDataRow(MARC_FIELD_TYPEInfo pMARC_FIELD_TYPEInfo, ref DataRow dr)
        {

			dr[pMARC_FIELD_TYPEInfo.strID] = pMARC_FIELD_TYPEInfo.ID;
			dr[pMARC_FIELD_TYPEInfo.strFieldType] = pMARC_FIELD_TYPEInfo.FieldType;
        }
        
        public void ToInfo(ref MARC_FIELD_TYPEInfo pMARC_FIELD_TYPEInfo, DataRow dr)
        {

			pMARC_FIELD_TYPEInfo.ID = int.Parse(dr[pMARC_FIELD_TYPEInfo.strID].ToString());
			pMARC_FIELD_TYPEInfo.FieldType = dr[pMARC_FIELD_TYPEInfo.strFieldType].ToString();
        }
    }
}
