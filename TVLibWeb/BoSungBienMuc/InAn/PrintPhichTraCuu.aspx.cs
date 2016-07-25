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
using TruongViet.TVLib.Business;
using TruongViet.TVLib.Entity;

public partial class BoSungBienMuc_InAn_PrintPhichTraCuu : WebBase
{
    cBMauPhich oBMauPhich;
    MauPhichInfo pMauPhichInfo;
    cBTaiLieu_MarcField oBTaiLieu_MarcField;
    int Page = 1, SoPhichTrenTrang = 6;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Page"] + "" != "")
            Page = int.Parse(Request["Page"] + "");
        pMauPhichInfo = new MauPhichInfo();
        oBMauPhich = new cBMauPhich();
        oBTaiLieu_MarcField = new cBTaiLieu_MarcField();
        string MauNhan = "";
        string[] TaiLieu;
        string strLabel = "";
        lbLabel.Text = "<table width='100%'><tr>";
        if (Session["ChuoiTaiLieu"] != null && Session["MauPhich"] != null)
        {
            pMauPhichInfo.MauPhichID = int.Parse("0" + Session["MauPhich"].ToString());
            MauNhan = oBMauPhich.Get(pMauPhichInfo).Rows[0]["GiaTri"].ToString();
            TaiLieu = Session["ChuoiTaiLieu"].ToString().Split(',');
            DataTable dtTaiLieu,dtTemp;
            string Temp;
            string Code;
            int Count = Page * SoPhichTrenTrang;
            if (Count > TaiLieu.Length)
                Count = TaiLieu.Length;
            for (int i = (Page - 1) * SoPhichTrenTrang; i < Count; i++)
            {
                dtTaiLieu = oBTaiLieu_MarcField.GetByIDTaiLieu(int.Parse(TaiLieu[i].ToString()),"");
                Temp = MauNhan;
                strLabel += "<td>";
                while (Temp.IndexOf("<$") >= 0)
                {
                    Code = Temp.Substring(Temp.IndexOf("<$")+2, Temp.IndexOf("$>") - Temp.IndexOf("<$") - 2);
                    dtTemp = dtTaiLieu.Copy();
                    dtTemp.DefaultView.RowFilter = " IDTaiLieu=" + TaiLieu[i].ToString() + " and Code='" + Code + "'";

                    if (dtTemp.DefaultView.Count > 0)
                    {
                        Temp = Temp.Replace("<$" + Code + "$>", dtTemp.DefaultView[0]["DisplayEntry"].ToString());
                        
                    }
                    else
                    {
                        Temp =  Temp.Replace("<$" + Code + "$>", " ");
                        
                    }

                }
                strLabel += Temp;
                strLabel += "</td><td></td>";
                if ((i + 1) % 2 == 0)
                {
                    strLabel += "</tr><tr><td colspan=4 height='20px'></td></tr><tr>";
                }
            }
            int j = TaiLieu.Length % 2;
            if (j != 0)
                strLabel = strLabel + "<td colspan='" + (j * 2).ToString() + "'> </td> </tr>";

            lbLabel.Text += strLabel + "</table>";
            ClientScript.RegisterClientScriptBlock(GetType(), "PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>");
            //Session["MauMauPhich"] = null;
            //Session["ChuoiTaiLieu"] = null;
        }
    }
}
