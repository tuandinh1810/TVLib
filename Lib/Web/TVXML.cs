using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using Microsoft.Win32;

namespace TruongViet.Lib.Web
{
    public class TVXML : LibBase
    {
        public static DataSet GetXML(string XMLFile)
        {
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(Application.StartupPath + "\\" + XMLFile);
            }
            catch
            {
                return null;
            }
            return ds;
        }

        public static DataTable GetXML(string XMLFile, string TableName)
        {
            DataSet ds = new DataSet();
            DataTable dtbTmp = null;
            try
            {
                ds.ReadXml(Application.StartupPath + "\\" + XMLFile);
                if (ds == null)
                    return null;
                dtbTmp = ds.Tables[TableName];
            }
            catch
            {
                return null;
            }
            return dtbTmp;
        }

        public static bool SaveXMLFile(DataSet dsTmp, string XMLFile)
        {
            try
            {
                dsTmp.WriteXml(Application.StartupPath + "\\" + XMLFile);
            }
            catch
            {
                return false;
            }
            finally
            {
            }
            return true;
        }

        public static bool SaveXMLField(DataTable dtbTmp, string FieldName, string FieldValue)
        {
            for (int i = 0; i < dtbTmp.Rows.Count; i++)
            {
                if (dtbTmp.Rows[i]["FieldName"].ToString() == FieldName)
                {
                    dtbTmp.Rows[i]["FieldValue"] = FieldValue;
                    return true;
                }
            }
            return false;
        }

        public static string GetXMLField(DataTable dtbTmp, string FieldName)
        {
            dtbTmp.DefaultView.RowFilter = "FieldName='" + FieldName + "'";
            if (dtbTmp.DefaultView.Count == 0)
                return null;
            return dtbTmp.DefaultView[0]["FieldValue"].ToString();
        }
    }
}
