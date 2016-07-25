using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class BanDoc_WUpLoad : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnClose.Attributes.Add("OnClick", "");
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile == false)
        {
            hidValue.Value = "";
            ThongBao("Bạn chưa tải ảnh!");
        }
        else
        {
            hidValue.Value = UplLoadFile();
            ClientScript.RegisterClientScriptBlock(GetType(), "Self", "<script language='javascript' >window.opener.document.forms[0].ctl00_ContentPlaceHolder1_hidImage.value ='" + hidValue.Value + "'; window.opener.document.forms[0].submit();self.close();</script>");
            
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "CloseSelf1", "<script language='javascript' >self.close();</script>");
    }
    private string UplLoadFile()
    {
        string tempUplLoadFile = null;
        string strPath = MapPath("~/Resources/images/AnhThe");
        string strFileUpLoad = "";
        if (FileUpload1.HasFile)
        {
           strFileUpLoad =  ProcessFileName(FileUpload1.FileName, strFileUpLoad);
            strPath = strPath + "\\" + strFileUpLoad;
            FileUpload1.PostedFile.SaveAs(strPath);
            tempUplLoadFile = strFileUpLoad;
        }
        return tempUplLoadFile;
    }
    // ProcessFileName method
    // Purpose: Rename the file
    public string ProcessFileName(string strFileAttach,  string strFileName)
    {
        string strExtension = "";
        while ((strFileAttach.IndexOf(" ", 0) + 1) > 0)
        {
            strFileAttach = strFileAttach.Replace(" ", "");
        }
        strFileAttach = strFileAttach.Replace("'", "");
        strExtension = strFileAttach.Substring(strFileAttach.Length - (strFileAttach.Length - (strFileAttach.LastIndexOf(".") + 1)));
       // Microsoft.VisualBasic.VBMath.Randomize();
        return strFileName = "file" + System.DateTime.Now.Year + new String('0', 2 - System.Convert.ToString(System.DateTime.Now.Month).Length) + new String('0', 2 - System.Convert.ToString(System.DateTime.Now.Day).Length) + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Second.ToString() + "." + strExtension;
    }
}
