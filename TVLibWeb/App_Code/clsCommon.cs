using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Common
/// </summary>
public class clsCommon
{
    public clsCommon()
    {
    }
    public string UpLoadFiles(HtmlInputFile objUpload, string strPathSave, string strDesFile)
    {
        string strRet = null;

        strRet = "Fail";
        try
        {
            if ((!string.IsNullOrEmpty(strPathSave)))
            {
                if ((objUpload.PostedFile !=null) && (objUpload.PostedFile.FileName.Length > 0))
                {
                    if (CheckSize(objUpload.PostedFile.ContentLength))
                    {
                        string strFN = null;
                        strFN = objUpload.PostedFile.FileName;
                        string strExt = null;
                        if (strFN.IndexOf(".") >= 0)
                        {
                            strExt = strFN.Substring(strFN.IndexOf("."), strFN.Length - (strFN.IndexOf(".")));
                        }
                        else
                        {
                            strExt = "";
                        }
                       
                            if (string.IsNullOrEmpty(strDesFile))
                            {
                                objUpload.PostedFile.SaveAs(strPathSave + "\\" + strFN);
                                strRet = strFN;
                            }
                            else
                            {
                                if (strDesFile.IndexOf(".") >= 0)
                                {
                                    objUpload.PostedFile.SaveAs(strPathSave + "\\" + strDesFile);
                                    strRet = strDesFile;
                                }
                                else
                                {
                                    objUpload.PostedFile.SaveAs(strPathSave + "\\" + strDesFile + strExt);
                                    strRet = strDesFile + strExt;
                                }
                            }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return strRet;
    }
    public Boolean CheckSize(long lngSizeF)
    {
        // default = 10 MB
        if (lngSizeF/1024 >= (10 * 1024))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static string Left(string param, int length)
    {
        //we start at 0 since we want to get the characters starting from the
        //left and with the specified lenght and assign it to a variable
        string result = "";
        if (param != "")
        {
            result = param.Substring(0, length);
        }
        //return the result of the operation
        return result;
    }
    public static string Right(string param, int length)
    {
        //start at the index based on the lenght of the sting minus
        //the specified lenght and assign it a variable
        string result = "";
        if (param != "")
        {
            result = param.Substring(param.Length - length, length);
        }
        //return the result of the operation
        return result;
    }
    public static string Mid(string param, int startIndex, int length)
    {
        //start at the specified index in the string ang get N number of
        //characters depending on the lenght and assign it to a variable
        string result = param.Substring(startIndex, length);
        //return the result of the operation
        return result;
    }
    public static bool ColumnEqual(object A, object B)
    {
        // Compares two values to see if they are equal. Also compares DBNULL.Value.
        // Note: If your DataTable contains object fields, then you must extend this
        // function to handle them in a meaningful way if you intend to group on them.
        if (A == DBNull.Value && B == DBNull.Value) // both are DBNull.Value
            return true;
        if (A == DBNull.Value || B == DBNull.Value) // only one is DBNull.Value
            return false;
        return (A.Equals(B)); // value type standard comparison
    }
    public static  DataTable SelectDistinct(string TableName, DataTable SourceTable, string FieldName)
    {
        DataTable dt = new DataTable(TableName);
        dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
        object LastValue = null;
        foreach (DataRow dr in SourceTable.Select("", FieldName))
        {
            if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])))
            {
                
                LastValue = dr[FieldName];
                dt.Rows.Add(new object[] { LastValue });
            }
        }
        
        return dt;
    }

}
