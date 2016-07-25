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
using TruongViet.TVLibTraCuu.Business;
using TruongViet.TVLibTraCuu.Entity;

namespace TVLibTraCuuWeb
{
    public partial class DangNhap : WebBase
    {
        cBNguoiDung  oBNguoiDung;
        NguoiDungInfo  oNguoiDungInfo;

        protected void Page_Load(object sender, EventArgs e)
        {

            oBNguoiDung = new cBNguoiDung();
            oNguoiDungInfo = new NguoiDungInfo();
           if (Session["TenNguoiDUng"]+"" !="")
               ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script> top.location.href='QTTinTuc.aspx' </script>");
        }        

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
          oNguoiDungInfo.TenDangNHap  = txtTenDangNhap.Text.Trim();
            oNguoiDungInfo.MatKhau = txtMatKhau.Text.Trim();
            DataTable dtTemp = oBNguoiDung.Login(oNguoiDungInfo);
            if (dtTemp != null)
            {
                
                if (dtTemp.Rows.Count > 0)
                {
                    //ThongBao("Đăng nhập thành công!");
                    //Session["TenDangNhap"] = txtTenDangNhap.Text.Trim();
                    Session["NguoiDungID"] = dtTemp.Rows[0]["NguoiDungID"].ToString();
                    Session["TenNguoiDUng"] = dtTemp.Rows[0]["TenNguoiDUng"].ToString();
                    //Session["TenDangNhap"] = dtTemp.Rows[0][oTaiKhoanInfo.strTenTaiKhoan].ToString();
                  //  Response.Redirect("Index.aspx");
                    ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script> top.location.href='QTTinTuc.aspx' </script>");
                }
                else
                {
                    ThongBao("Tên đăng nhập hoặc mật khẩu không đúng hoặc tài khoản của bạn chưa được kích hoạt!");
                    txtMatKhau.Focus();
                }
            }
        }

    }
}
