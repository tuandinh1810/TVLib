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
    public partial class TrangCaNhan : WebBase
    {
        TaiKhoanInfo oTaiKhoanInfo;
        cBTaiKhoan oBTaiKhoan;
        cBTaiLieuMuon oBTaiLieuMuon;
        protected void Page_Load(object sender, EventArgs e)
        {
            oTaiKhoanInfo = new TaiKhoanInfo();
            oBTaiKhoan = new cBTaiKhoan();
            //if (Session["TaiKhoanID"] + "" == "")
            //{
            //    Response.Redirect("DangNhap.aspx");
            //}
            //else
            //{

            //    LayThongTinBanDoc();
            //}
            if (!IsPostBack)
                LayThongTinBanDoc();


        }
        // ham lay thong tin tai khoan
        private void LayThongTinBanDoc()
        {

            if (Session["IDBanDoc"] != null)
            {

                lbTenTaiKhoan.Text = Session["TenBanDoc"].ToString();
                lbSoTien.Text = Session["SoThe"].ToString();
                oBTaiLieuMuon = new cBTaiLieuMuon();
                DataTable dtTemp = oBTaiLieuMuon.GetMuonSachBySoThe(Session["SoThe"].ToString());
                if (dtTemp != null)
                {
                    if (dtTemp.Rows.Count > 0)
                    {
                        GridView1.DataSource = dtTemp;
                        GridView1.DataBind();
                    }
                }
            }
        }

    }
}
