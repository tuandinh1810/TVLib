using System;
using System.Collections;
using System.Collections.Generic;
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
using TruongViet.Lib.Web;

public partial class BanDoc_XoaBanDoc : WebBase 
{
    BanDocInfo oBanDocInfo;
    cBBanDoc oBBanDoc;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",24,") >= 0)
        {
            oBanDocInfo = new BanDocInfo();
            oBBanDoc = new cBBanDoc();
            BindJS();
            oChucNang.MaChucNang = "XoaBanDocTheoLo";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
        }
        else
            Response.Redirect("../Error.aspx");
    }

    private void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "JSAdminCommon", "<script language='javascript' src='../Resources/JS/BanDoc.js'></script>");       
        btnXoa.Attributes.Add("Onclick", "return CheckThongTinXoaBanDoc();");
    }

    protected void btnXoa_Click(object sender, EventArgs e)
    {
        string TuNgay = "";
        string DenNgay = "";
        if (txtTuNgay.Text.Trim() != "")
        {
            TuNgay = TVDateTime.ChuyenVietSangAnh(txtTuNgay.Text.Trim()).ToString();
        }
        if (txtDenNgay.Text.Trim() != "")
        {
            DenNgay = TVDateTime.ChuyenVietSangAnh(txtDenNgay.Text.Trim()).ToString();
        }
        DataTable dtTemp = oBBanDoc.XoaBanDocTheoLo(txtKhoa.Text.Trim(), txtLop.Text.Trim(), TuNgay, DenNgay);
        if (dtTemp != null)
        {
            ThongBao("Xoá bạn đọc thành công");
            WriteLog(lstChucNang[0].ChucNangID, "Xóa bạn đọc theo lô thành công " , Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
    }
}
