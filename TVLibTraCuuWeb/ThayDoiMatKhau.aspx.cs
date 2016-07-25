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
    public partial class WThayDoiMatKhau : WebBase 
    {
        cBTaiKhoan oBTaiKhoan;
        TaiKhoanInfo oTaiKhoanInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            oTaiKhoanInfo = new TaiKhoanInfo();
            oBTaiKhoan = new cBTaiKhoan();
            BindJS();
        }
        public void BindJS()
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "JS", "<script language='javascript' src='Resources/JS/TVLib.js' > </script>");
            ClientScript.RegisterClientScriptBlock(GetType(), "KiemTraThongTin", "<script language='javascript' src='Resources/JS/MatKhau.js' > </script>");
            btnCapNhat.Attributes.Add("Onclick", "return CheckDoiMatKhau();");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtGoLaiMatKhauMoi.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtMatKhauMoi.Text = "";
        }
        
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            oTaiKhoanInfo.TenDangNhap = txtTenDangNhap.Text.Trim();
            oTaiKhoanInfo.MatKhau = txtMatKhau.Text.Trim();
            int intKetQua = oBTaiKhoan.DoiMatKhau(oTaiKhoanInfo, txtMatKhauMoi.Text.Trim());
            if (intKetQua != 0)
            {
                ThongBao("Đổi mật khẩu thành công!");
                txtGoLaiMatKhauMoi.Text = "";
                txtTenDangNhap.Text = "";
                txtMatKhau.Text = "";
                txtMatKhauMoi.Text = "";
            }
            else
            {
                ThongBao("Tên đăng nhập hoặc  mật khẩu cũ không chính xác!");
                txtMatKhau.Text = "";
                txtMatKhau.Focus();
            }
        }
    }
}
