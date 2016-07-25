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

public partial class LuuThong_InTaiLieuDangKyMuon : WebBase
{
    cBMauPhieu oBMauPhieu;
    MauPhieuInfo oMauPhieu;

    protected void Page_Load(object sender, EventArgs e)
    {
        oMauPhieu = new MauPhieuInfo();
        oBMauPhieu = new cBMauPhieu();
        string strLabel = "";
        // lay ra loai phieu
        oMauPhieu.MauPhieuID = 0;
        DataTable dtbMauPhieu = oBMauPhieu.Get(oMauPhieu);
        if (dtbMauPhieu.Rows.Count > 0)
        {
            dtbMauPhieu.DefaultView.RowFilter = "LoaiPhieu =" + Request["LoaiPhieu"];
            if (dtbMauPhieu.DefaultView.Count > 0)
            {
                strLabel = dtbMauPhieu.DefaultView[0]["NoiDung"].ToString();
            }
            else
            {
                lbLabel.Text = "Chưa có mẫu phiếu";
            }
        }
        DataTable dtbData = (DataTable)(Session["Data"]);
        DataTable dtbBanDoc = (DataTable)(Session["BanDoc"]);
        string Code="";
        if (dtbData != null && strLabel != "" && dtbBanDoc != null)
        {
            while (strLabel.IndexOf("<$") >= 0)
             {
                 Code = strLabel.Substring(strLabel.IndexOf("<$") + 2, strLabel.IndexOf("$>") - strLabel.IndexOf("<$") - 2);
                 // danh sach tai lieu ghi muon
                 if (Code == "data")
                     strLabel = strLabel.Replace("<$" + Code + "$>", LoadData(dtbData));
                 else
                     strLabel = strLabel.Replace("<$" + Code + "$>", dtbBanDoc.Rows[0][Code].ToString());
                
             }
        }
        lbLabel.Text = strLabel;
        ClientScript.RegisterClientScriptBlock(GetType(), "PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>");
        Session["Data"] = null;
    }
    private string LoadData( DataTable dtTemp)
    {
        string strLabel = "<table width='100%' border=1 ><tr><td width='5%'>STT</td><td>Nhan Đề</td><td>Ngày mượn</td></tr>";
        for (int i = 0; i < dtTemp.Rows.Count; i++)
        {
            strLabel += "<tr><td>" + (i + 1).ToString() + "</td><td>" + dtTemp.Rows[i]["NhanDe"].ToString() + "</td><td>" + DateTime.Parse(dtTemp.Rows[i]["NgayMuon"].ToString()).ToShortDateString() + "</td></tr>";
        }
        strLabel += "</table>";
        return strLabel;
    }
}
