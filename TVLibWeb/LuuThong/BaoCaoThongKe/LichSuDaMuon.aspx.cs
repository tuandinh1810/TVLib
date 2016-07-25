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
using TruongViet.Lib.Web;

public partial class LuuThong_LichSuDaMuon : WebBase 
{
    private cBTaiLieu oBTaiLieu;
    private cBKho oBKho;

    protected void Page_Load(object sender, EventArgs e)
    {
        oBTaiLieu = new cBTaiLieu();
        btnFind.Attributes.Add("Onclick", "if((CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtMuonTuNgay,'Không đúng kiểu định dạng ngày tháng!')== false) || (CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtMuonDenNgay,'Không đúng kiểu định dạng ngày tháng!')== false)|| (CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtTraTuNgay,'Không đúng kiểu định dạng ngày tháng!')== false)|| (CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtTraDenNgay,'Không đúng kiểu định dạng ngày tháng!')== false)){return false;}");
        btnCancel.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
        if (!IsPostBack)
        {
            btnFind_Click(null, null);
            // load du lieu vao ddlKho
            oBKho = new cBKho();
            ddlKho.DataSource = InsertOneRow(oBKho.GetByThuVienID(0), "-- Chọn kho --", 0, 0);
            ddlKho.DataTextField = "MaKho";
            ddlKho.DataValueField = "KhoID";
            ddlKho.DataBind();
        }
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        string SoThe, MaTaiLieu, MaXepGia;
        DateTime MuonTuNgay, MuonDenNgay,TraTuNgay, TraDenNgay;
        int IDKho;

        SoThe = txtSoThe.Text.Trim();
        MaXepGia = txtMaXepGia.Text.Trim();
        MaTaiLieu = txtMaTaiLieu.Text.Trim();
        if (txtMuonTuNgay.Text.Trim() == "")
            MuonTuNgay = DateTime.Parse("1/1/1900");
        else
            MuonTuNgay = TVDateTime.ChuyenVietSangAnh(txtMuonTuNgay.Text.Trim());
        if (txtMuonDenNgay.Text.Trim() == "")
            MuonDenNgay = DateTime.Parse("1/1/1900");
        else
            MuonDenNgay = TVDateTime.ChuyenVietSangAnh(txtMuonDenNgay.Text.Trim());
        if (txtTraTuNgay.Text.Trim() == "")
            TraTuNgay = DateTime.Parse("1/1/1900");
        else
            TraTuNgay = TVDateTime.ChuyenVietSangAnh(txtTraTuNgay.Text.Trim());
        if (txtTraDenNgay.Text.Trim() == "")
            TraDenNgay = DateTime.Parse("1/1/1900");
        else
            TraDenNgay = TVDateTime.ChuyenVietSangAnh(txtTraDenNgay.Text.Trim());

        IDKho = (ddlKho.SelectedValue == null ? 0 : int.Parse("0" + ddlKho.SelectedValue.ToString()));
        DataTable dtDangMuon = oBTaiLieu.Get_BaoCao_LichSuMuon(SoThe, MuonTuNgay, MuonDenNgay,TraTuNgay,TraDenNgay, MaTaiLieu, MaXepGia, IDKho);
        if (dtDangMuon != null)
        {
            if (dtDangMuon.Rows.Count == 0)
                lblNothing.Visible = true;
            else
                lblNothing.Visible = false;
            lblTotal.Text = dtDangMuon.Rows.Count.ToString();
            grvDaMuon.DataSource = dtDangMuon;
            grvDaMuon.DataBind();
        }
        else
            lblNothing.Visible = true;
    }
    protected void grvDaMuon_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}
