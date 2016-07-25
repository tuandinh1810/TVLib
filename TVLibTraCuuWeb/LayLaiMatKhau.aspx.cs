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
    public partial class WLayLaiMatKhau : WebBase 
    {
        TaiKhoanInfo oTaiKhoan;
        cBTaiKhoan oBTaiKhoan;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindJS();
            oTaiKhoan = new TaiKhoanInfo();
            oBTaiKhoan = new cBTaiKhoan();

        }
        public void BindJS()
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "JS", "<script language='javascript' src='Resources/JS/TVLib.js' > </script>");
            ClientScript.RegisterClientScriptBlock(GetType(), "KiemTraThongTin", "<script language='javascript' src='Resources/JS/MatKhau.js' > </script>");
            btnKetQua.Attributes.Add("Onclick","return CheckCapLaiMatKhau();");
        }
        protected void btnKetQua_Click(object sender, EventArgs e)
        {
            oTaiKhoan.TenDangNhap = txtTenDangNhap.Text.Trim();
            oTaiKhoan.Email = txtEmail.Text.Trim();
            int intKetQua = oBTaiKhoan.LayLaiMatKhau(oTaiKhoan);
            if (intKetQua != 0)
            {
                lbInfor.Visible = true;
                lbKetQua.Visible = true;

            }
            else
            {
                ThongBao("Tên đăng nhập hoặc Email không chính xác");
                txtEmail.Focus();
            }

        }
 
    }
}
