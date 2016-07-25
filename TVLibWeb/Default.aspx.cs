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


public partial class Default : System.Web.UI.Page
{

   cBNguoiDung oBNguoiDung;
   NguoiDungInfo oNguoiDungInfo;
   NguoiDung_ChucNangInfo oND_CNInfo;
   cBNguoiDung_ChucNang oBND_CN;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblImage.Text = "<div class='headerSuuTapSo'><a href='../../Home.aspx'><img border=0 src='" + Request.ApplicationPath + "Resources/Images/TVLib_Logo.png'/></a></div>";
        oNguoiDungInfo = new NguoiDungInfo ();
        oBNguoiDung = new cBNguoiDung ();
    }
    public string MaHoaMatKhau(string strMatKhau)
    {
        AspCrypt.CryptClass cryp = new AspCrypt.CryptClass();
        string strMaBoSung = "pl";
        string strOut = cryp.Crypt(strMaBoSung, strMatKhau);
        return strOut;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        oNguoiDungInfo.TenDangNHap = txtTenDangNhap.Text.Trim();
        //oNguoiDungInfo.MatKhau = MaHoaMatKhau(txtMatKhau.Text.Trim());
        oNguoiDungInfo.MatKhau = txtMatKhau.Text.Trim();
        DataTable dtTemp = oBNguoiDung.Login(oNguoiDungInfo);
        DateTime dtimeExpire = DateTime.ParseExact("16/01/2015", "dd/MM/yyyy", null);
        //if (DateTime.Now <= dtimeExpire)
        //{
            if (dtTemp != null)
            {


                if (dtTemp.Rows.Count > 0)
                {
                    Session["TenDangNhap"] = txtTenDangNhap.Text.Trim();
                    Session["TaiKhoanID"] = dtTemp.Rows[0]["NguoiDungID"].ToString();
                    Session["QuyenIDs"] = LayThongTinNguoiDung_ChucNang(int.Parse(dtTemp.Rows[0]["NguoiDungID"].ToString()));
                    Response.Redirect("BoSungBienMuc/Default.aspx");

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(GetType(), "key", "<Script>alert('Tên đăng nhập hoặc mật khẩu không chính xác!');</Script>");
                    txtMatKhau.Focus();
                }
            }
        //}
        //else
        //    ClientScript.RegisterClientScriptBlock(GetType(), "key", "<Script>alert('Phần mềm hết hạn sử dụng cần liên hệ với nhà cung cấp sản phẩm!');</Script>");
    }
    private string LayThongTinNguoiDung_ChucNang(int NguoiDungID)
    {
        oBND_CN = new cBNguoiDung_ChucNang();
        oND_CNInfo = new NguoiDung_ChucNangInfo();
        oND_CNInfo.IDNguoiDung = NguoiDungID;
        DataTable dtTemp = oBND_CN.Get(oND_CNInfo);
        string strChuoi = "";
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                strChuoi = ",";
                for (int inti = 0; inti < dtTemp.Rows.Count; inti++)
                {
                    strChuoi = strChuoi + dtTemp.Rows[inti]["IDChucNang"].ToString() + ",";
                }

            }
            else
            {
                strChuoi = "";
            }
        }
        return strChuoi;
    }
    
}
