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
    public partial class WDangKy :  WebBase 
    {
        TaiKhoanInfo oTaiKhoanInfo;
        cBTaiKhoan oBTaiKhoan;
        protected void Page_Load(object sender, EventArgs e)
        {
            oTaiKhoanInfo = new TaiKhoanInfo();
            oBTaiKhoan = new cBTaiKhoan();
            BindJS();
        }
        public void BindJS()
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='Resources/Js/TVLib.js'></script>");
            ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript' src='Resources/Js/MatKhau.js'></script>");
            btnUpdate.Attributes.Add("OnClick", "return CheckTaiKhoanInfor();");
            btnCancel.Attributes.Add("OnClick", "document.forms[0].reset(); document.forms[0].txtTenDangNhap.focus(); return false;"); 
        }              
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            oTaiKhoanInfo.DiaChi = txtDiaChi.Text.Trim();
            oTaiKhoanInfo.DienThoai = txtDienThoai.Text.Trim();
            oTaiKhoanInfo.DonVi = txtDonVi.Text.Trim();
            oTaiKhoanInfo.Email = txtEmail.Text.Trim();
            if (drdlGioiTinh.SelectedValue != "0")
            {
                oTaiKhoanInfo.GioiTinh = false;
            }
            else
                oTaiKhoanInfo.GioiTinh = true;
            oTaiKhoanInfo.MatKhau = txtMatKhau.Text.Trim();
            oTaiKhoanInfo.MucDoMat = 0;
            oTaiKhoanInfo.TenDangNhap = txtTenDangNhap.Text.Trim();
            oTaiKhoanInfo.TenTaiKhoan = txtTenDayDu.Text.Trim();
            oTaiKhoanInfo.PhongBan = txtPhongBan.Text.Trim();
            oTaiKhoanInfo.TienNap = 0;
            // them moi tai khoan

            int KetQua = oBTaiKhoan.Add(oTaiKhoanInfo);
            if (KetQua == 0)
            {
                ThongBao("Đăng ký tài khoản thành công!");
                // reset controls
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
                txtDonVi.Text = "";
                txtEmail.Text = "";
                txtGoLaiMatKhau.Text = "";
                txtMatKhau.Text = "";
                txtPhongBan.Text = "";
                txtTenDangNhap.Text = "";
                txtTenDayDu.Text = "";
                drdlGioiTinh.SelectedIndex = 0;
                txtGhiChu.Text = "";
            }
            else
            {
                ThongBao("Tên đăng nhập đã dược đăng ký!");
                txtTenDangNhap.Focus();
            }
            

              
        }
    }
}
