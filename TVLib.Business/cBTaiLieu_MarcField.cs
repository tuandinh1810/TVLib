using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBTaiLieu_MarcField : cBBase
    {
        private cDTaiLieu_MarcField oDTaiLieu_MarcField;
        private TaiLieu_MarcFieldInfo oTaiLieu_MarcFieldInfo;

        public cBTaiLieu_MarcField()        
        {
            oDTaiLieu_MarcField = new cDTaiLieu_MarcField();
        }
        
        public DataTable Get(TaiLieu_MarcFieldInfo pTaiLieu_MarcFieldInfo)        
        {
            return oDTaiLieu_MarcField.Get(pTaiLieu_MarcFieldInfo);
        }
        public DataTable GetThongTinTaiLieu(string strTaiLieuID)
        {
            return oDTaiLieu_MarcField.GetThongTinTaiLieu(strTaiLieuID);
        }
        public int Add(TaiLieu_MarcFieldInfo pTaiLieu_MarcFieldInfo)
        {
			int ID = 0;
            ID = oDTaiLieu_MarcField.Add(pTaiLieu_MarcFieldInfo);
            mErrorMessage = oDTaiLieu_MarcField.ErrorMessages;
            mErrorNumber = oDTaiLieu_MarcField.ErrorNumber;
            return ID;
        }

        public void Updates(int IDTaiLieu,string  strTruongDublinID,string strDublinValue,string strAccessEntry)
        {
            oDTaiLieu_MarcField.Updates(IDTaiLieu, strTruongDublinID, strDublinValue, strAccessEntry);
            mErrorMessage = oDTaiLieu_MarcField.ErrorMessages;
            mErrorNumber = oDTaiLieu_MarcField.ErrorNumber;
        }

        public void Update(TaiLieu_MarcFieldInfo pTaiLieu_MarcFieldInfo)
        {
            oDTaiLieu_MarcField.Update(pTaiLieu_MarcFieldInfo);
            mErrorMessage = oDTaiLieu_MarcField.ErrorMessages;
            mErrorNumber = oDTaiLieu_MarcField.ErrorNumber;
        }
        
        public void Delete(TaiLieu_MarcFieldInfo pTaiLieu_MarcFieldInfo)
        {
            oDTaiLieu_MarcField.Delete(pTaiLieu_MarcFieldInfo);
            mErrorMessage = oDTaiLieu_MarcField.ErrorMessages;
            mErrorNumber = oDTaiLieu_MarcField.ErrorNumber;
        }
        public DataTable GetByIDTaiLieu(int intIDTaiLieu, string MaXepGia)
        {
            return oDTaiLieu_MarcField.GetByIDTaiLieu(intIDTaiLieu, MaXepGia);
        }
        public DataTable RunSql(string strSql)
        {
            return oDTaiLieu_MarcField.RunSql(strSql);
        }
        public List<TaiLieu_MarcFieldInfo> GetList(TaiLieu_MarcFieldInfo pTaiLieu_MarcFieldInfo)
        {
            List<TaiLieu_MarcFieldInfo> oTaiLieu_MarcFieldInfoList = new List<TaiLieu_MarcFieldInfo>();
            DataTable dtb = Get(pTaiLieu_MarcFieldInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTaiLieu_MarcFieldInfo = new TaiLieu_MarcFieldInfo();
                    

                   // oTaiLieu_MarcFieldInfo.TaiLieu_MarcField_ID = int.Parse(dtb.Rows[i]["TaiLieu_MarcField_ID"].ToString());
                    oTaiLieu_MarcFieldInfo.IDTaiLieu = int.Parse(dtb.Rows[i]["IDTaiLieu"].ToString());
                    oTaiLieu_MarcFieldInfo.IDMarcField = int.Parse(dtb.Rows[i]["IDTruongDublin"].ToString());
                    oTaiLieu_MarcFieldInfo.DisplayEntry = dtb.Rows[i]["DisplayEntry"].ToString();
                    oTaiLieu_MarcFieldInfo.AccessEntry = dtb.Rows[i]["AccessEntry"].ToString();
                    
                    oTaiLieu_MarcFieldInfoList.Add(oTaiLieu_MarcFieldInfo);
                }
            }
            return oTaiLieu_MarcFieldInfoList.Count == 0 ? null : oTaiLieu_MarcFieldInfoList;
        }
    }
}
