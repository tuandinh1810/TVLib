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


public partial class QuanTriHeThong_XoaLog : WebBase
{
    private NhatKyHeThongInfo oNhatKyHeThongInfo = new NhatKyHeThongInfo();
    private cBNhatKyHeThong oBNhatKyHeThong;
    protected void Page_Load(object sender, EventArgs e)
    {
        oBNhatKyHeThong = new cBNhatKyHeThong();
        BindJS();

    }
    public void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript' src='../Resources/Js/QTHT.js'></script>");
        btnXoa.Attributes.Add("OnClick", "return CheckDeleteLogs();");

    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {

        oBNhatKyHeThong.DeleteLogs(txtFromTime.Text.Trim(), txtToTime.Text.Trim());
        ThongBao("Xóa nhật ký hệ thống thành công!");

    }
    protected void btnLamLai_Click(object sender, EventArgs e)
    {
        txtToTime.Text = "";
        txtFromTime.Text = "";
    }
}

