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

public partial class LuuThong_DangMuon : WebBase 
{
    private cBTaiLieu oBTaiLieu;
    private cBKho oBKho;

    protected void Page_Load(object sender, EventArgs e)
    {
        oBTaiLieu = new cBTaiLieu();
        btnFind.Attributes.Add("Onclick", "if((CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtFromDate,'Không đúng kiểu định dạng ngày tháng!')== false) || (CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtToDate,'Không đúng kiểu định dạng ngày tháng!')== false)){return false;}");
        btnCancel.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
        if (!IsPostBack)
        {
            btnFind_Click(null,null);
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
        string SoThe,MaTaiLieu,MaXepGia;
        DateTime TuNgay,DenNgay; 
        int IDKho;

        SoThe = txtSoThe.Text.Trim();
        MaXepGia = txtMaXepGia.Text.Trim();
        MaTaiLieu = txtMaTaiLieu.Text.Trim();
       if (txtFromDate.Text.Trim() == "")
            TuNgay = DateTime.Parse("1/1/1900");
       else
           TuNgay = TVDateTime.ChuyenVietSangAnh(txtFromDate.Text.Trim());
       if (txtToDate.Text.Trim() == "")
           DenNgay = DateTime.Parse("1/1/1900");
       else
           DenNgay = TVDateTime.ChuyenVietSangAnh(txtToDate.Text.Trim());

       IDKho = (ddlKho.SelectedValue == null? 0:int.Parse("0"+ddlKho.SelectedValue.ToString()));
       DataTable dtDangMuon = oBTaiLieu.Get_BaoCao_DangMuon("","",SoThe, TuNgay, DenNgay, MaTaiLieu, MaXepGia, IDKho);
       if (dtDangMuon != null)
       {
           if (dtDangMuon.Rows.Count == 0)
               lblNothing.Visible = true;
           else
               lblNothing.Visible = false ;
           lblTotal.Text = dtDangMuon.Rows.Count.ToString();
           grvTaiLieu.DataSource = dtDangMuon;
           grvTaiLieu.DataBind();
       }
       else
           lblNothing.Visible = true;
    }
    protected void grvTaiLieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTaiLieu.PageIndex = e.NewPageIndex;
         btnFind_Click(null,null);
    }
}
