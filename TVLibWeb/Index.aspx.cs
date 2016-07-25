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


public partial class Index :  System.Web.UI.Page
{
    cBNguoiDung oBNguoiDung;
   NguoiDungInfo oNguoiDungInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblImage.Text = "<div class='headerSuuTapSo'><a href='../../Home.aspx'><img border=0 src='" + Request.ApplicationPath + "/Resources/Images/TVLib_Logo.png'/></a></div>";
        oNguoiDungInfo = new NguoiDungInfo ();
        oBNguoiDung = new cBNguoiDung ();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        oNguoiDungInfo.TenDangNHap = txtTenDangNhap.Text.Trim();
        oNguoiDungInfo.MatKhau = txtMatKhau.Text.Trim();
        DataTable dtTemp = oBNguoiDung.Login(oNguoiDungInfo);
        if (dtTemp != null)
        {

            if (dtTemp.Rows.Count > 0)
            {
                Session["TenDangNhap"] = txtTenDangNhap.Text.Trim();
                Session["TaiKhoanID"] = dtTemp.Rows[0]["NguoiDungID"].ToString();               
                Response.Redirect("BoSungBienMuc/BoSungBienMucIndex.aspx");

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "key", "<Script>alert('Tên đăng nhập hoặc mật khẩu không chính xác!');</Script>");
                txtMatKhau.Focus();
            }
        }
    }
    
}
