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

using TruongViet.TVLib.Business;
using TruongViet.TVLib.Entity;

public partial class QuanTriHeThong_ThayDoiThongTinNguoiDung : WebBase
{
    public cBNguoiDung oBNguoiDung=new cBNguoiDung();
    public NguoiDungInfo oNguoiDung=new NguoiDungInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            BindJS();
        }

    }
    public void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript' src='../../Resources/Js/QTHT.js'></script>");
        btnThemmoi.Attributes.Add("OnClick", "return CheckUserInfor();");
    }
    private void LoadData()
    {
        
        if (Session["TaiKhoanID"] + "" != "")
            oNguoiDung.NguoiDungID = int.Parse(Session["TaiKhoanID"].ToString());
        DataTable dtbNguoiDung = oBNguoiDung.Get(oNguoiDung);
        if (dtbNguoiDung.Rows.Count > 0)
        {
            txtDienthoai.Text = dtbNguoiDung.Rows[0]["DienThoai"].ToString();
            txtEmail.Text = dtbNguoiDung.Rows[0]["Email"].ToString();
            txtGhiChu.Text = dtbNguoiDung.Rows[0]["GhiChu"].ToString();
            txtTenDangNhap.Text = dtbNguoiDung.Rows[0]["TenDangNHap"].ToString();
            if (txtTenDangNhap.Text.ToUpper() == "ADMIN")
            {
                txtTenDangNhap.Enabled = true;
            }
            else
            txtTenDangNhap.Enabled = false;
            hdPassword.Value = dtbNguoiDung.Rows[0]["MatKhau"].ToString();
            txthoten.Text = dtbNguoiDung.Rows[0]["TenNguoiDung"].ToString();
            //txtMatKhau.Text = dtbNguoiDung.Rows[0]["MatKhau"].ToString();

        }
    }
    public string MaHoaMatKhau(string strMatKhau)
    {
        AspCrypt.CryptClass cryp = new AspCrypt.CryptClass();
        string strMaBoSung = "pl";
        string strOut = cryp.Crypt(strMaBoSung, strMatKhau);
        return strOut;
    }
    protected void btnThemmoi_Click(object sender, EventArgs e)
    {
        oNguoiDung.TenNguoiDung = txthoten.Text.Trim();
        if (txtMatKhau.Text.Trim() != "")
            oNguoiDung.MatKhau = txtMatKhau.Text;//MaHoaMatKhau(txtMatKhau.Text.Trim());
        else
            oNguoiDung.MatKhau = "";
        oNguoiDung.DienThoai = txtDienthoai.Text.Trim();
        oNguoiDung.Email = txtEmail.Text.Trim();
        oNguoiDung.TenDangNHap = txtTenDangNhap.Text.Trim();
        oNguoiDung.GhiChu = txtGhiChu.Text.Trim();
        if (Session["TaiKhoanID"] + "" != "")
        {
            //if (txtMatKhau.Text.Trim() == "")
            //{
            //    oNguoiDung.MatKhau = hdPassword.Value;
            //}
            //else
            //{
            //    oNguoiDung.MatKhau = txtMatKhau.Text.Trim();
            //}
            oNguoiDung.NguoiDungID = int.Parse(Session["TaiKhoanID"].ToString());
            int intKetQua = oBNguoiDung.Update(oNguoiDung);
            if (intKetQua == 0)
            {
                ThongBao("Cập nhật người dùng thành công!");
                WriteLog(1, "Sửa thông tin người dùng", Request.UserHostAddress,Session["TenDangNhap"].ToString());
            }
        }
     
       
    }
}
