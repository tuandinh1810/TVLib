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

public partial class BoSungBienMuc_InAn_PrintNhan : WebBase
{
    cBNhanGay oBNhanGay;
    NhanGayInfo pNhanGayInfo;
    cBTaiLieu_MarcField oBTaiLieu_MarcField;
    int Page=1, SoNhanTrenTrang = 35;
    int SoDong = 5, SoCot = 7;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request["Page"] + "" != "")
            Page = int.Parse(Request["Page"] + "");
        pNhanGayInfo = new NhanGayInfo();
        oBNhanGay = new cBNhanGay();
        oBTaiLieu_MarcField = new cBTaiLieu_MarcField();
        string MauNhan = "";
        string[] MaXepGia;
        string strLabel = "";
        lbLabel.Text = "<table width='100%' border=1 cellpadding=5><tr>";
        DataTable dtTaiLieu, dtTemp;
        if (Session["ChuoiMaXG"] != null && Session["MauNhanGay"]!= null)
        {
            pNhanGayInfo.NhanGayID = int.Parse("0" + Session["MauNhanGay"].ToString());
            MauNhan = oBNhanGay.Get(pNhanGayInfo).Rows[0]["NoiDung"].ToString();
            MaXepGia= Session["ChuoiMaXG"].ToString().Split(',');
            string Temp;
            string Code;
            int Count = Page * SoNhanTrenTrang;
            if (Count > MaXepGia.Length)
                Count = MaXepGia.Length;
            for (int i = (Page - 1) * SoNhanTrenTrang; i < Count; i++)
            {
                dtTaiLieu = oBTaiLieu_MarcField.GetByIDTaiLieu(0,MaXepGia[i].ToString());
                Temp = MauNhan;
                Temp = Temp.Replace("<$MXG$>", MaXepGia[i]) ;
                strLabel += "<td align='center'>";
                while (Temp.IndexOf("<$") >= 0)
                {
                    Code = Temp.Substring(Temp.IndexOf("<$") + 2, Temp.IndexOf("$>") - Temp.IndexOf("<$") - 2);
                    dtTemp = dtTaiLieu.Copy();
                    dtTemp.DefaultView.RowFilter = "Code='" + Code + "'";

                    if (dtTemp.DefaultView.Count > 0)
                    {
                        Temp = Temp.Replace("<$" + Code + "$>", dtTemp.DefaultView[0]["DisplayEntry"].ToString());

                    }
                    else
                    {
                        Temp = Temp.Replace("<$" + Code + "$>", " ");

                    }

                }
                strLabel += Temp;
                strLabel += "</td>";
                if ((i + 1) % SoDong == 0)
                {
                    strLabel += "</tr><tr>";
                }
            }
            int j = MaXepGia.Length % SoCot;
            if (j != 0)
                strLabel = strLabel + "<td colspan='" + (j * 2).ToString() + "'></td> </tr>";

            lbLabel.Text += strLabel + "</table>";
            //for (int i = 0; i < MaXepGia.Length; i++)
            //{
            //    strLabel += "<td>" + MauNhan.Replace("<$MXG$>", MaXepGia[i]) + "</td><td></td>";
            //     if ((i + 1) % 4 == 0) 
            //     {
            //         strLabel += "</tr><tr><td colspan=8 height='20px'></td></tr><tr>";
            //     }
            //}
            //  int j = MaXepGia.Length % 4;
            //  if (j != 0)
            //      strLabel = strLabel + "<td colspan='" + (j*2).ToString() + "'> </td> </tr>";
                
            //lbLabel.Text += strLabel + "</table>";
            ClientScript.RegisterClientScriptBlock(GetType(), "PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>");
            //Session["MauNhanGay"] = null;
            //Session["ChuoiMaXG"] = null;
        }
    }
}
