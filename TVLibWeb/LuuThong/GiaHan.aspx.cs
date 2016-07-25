using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class LuuThong_GiaHan : WebBase 
{
    private cBTaiLieu oBTaiLieu;
    private cBTaiLieuMuon oBTaiLieuMuon;
    private cBKho oBKho;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",21,") >= 0)
        {
            oBTaiLieu = new cBTaiLieu();
            Response.Write("<Script src='../Resources/Js/TVLib.js'" + " ></Script>");
            BindJS();
            oChucNang.MaChucNang = "GiaHan";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
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
        else
            Response.Redirect("../Error.aspx");
    }
    private void BindJS()
    {
        btnFind.Attributes.Add("Onclick", "if((CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtFromDate,'Không đúng kiểu định dạng ngày tháng!')== false) || (CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtToDate,'Không đúng kiểu định dạng ngày tháng!')== false)){return false;}");
        btnGiaHan.Attributes.Add("Onclick", "if(CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtGiaHan,'Không đúng kiểu định dạng ngày tháng!')== false) {return false;}");
        btnCancel.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
        //ClientScript.RegisterClientScriptBlock(GetType(), "Js", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        string SoThe, MaTaiLieu, MaXepGia;
        DateTime TuNgay, DenNgay;
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

        IDKho = (ddlKho.SelectedValue == null ? 0 : int.Parse("0" + ddlKho.SelectedValue.ToString()));
        DataTable dtDangMuon = oBTaiLieu.Get_BaoCao_DangMuon("","",SoThe, TuNgay, DenNgay, MaTaiLieu, MaXepGia, IDKho);
        if (dtDangMuon != null)
        {
            if (dtDangMuon.Rows.Count == 0)
                lblNothing.Visible = true;
            else
                lblNothing.Visible = false;
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
        btnFind_Click(null, null);
    }
    protected void grvTaiLieu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            ((CheckBox)(e.Row.Cells[0].FindControl("cbxCheckAll"))).Attributes.Add("onclick", "CheckAllCheckBox('grvTaiLieu','cbxDKCB',3,10);");
    }
    protected void btnGiaHan_Click(object sender, EventArgs e)
    {
        if (txtGiaHan.Text.Trim() != "")
        {
            string ChuoiTaiLieuMuonID = "";
            for (int i = 0; i < grvTaiLieu.Rows.Count; i++)
            {
                if (((CheckBox)grvTaiLieu.Rows[i].Cells[0].FindControl("cbxDKCB")).Checked)
                {
                    ChuoiTaiLieuMuonID = ChuoiTaiLieuMuonID + "'" + grvTaiLieu.DataKeys[i][0].ToString() + "',";
                }
            }
            if (ChuoiTaiLieuMuonID != "")
            {
                // cap nhat gia han
                oBTaiLieuMuon = new cBTaiLieuMuon();
                oBTaiLieuMuon.UpdateGiaHan(ChuoiTaiLieuMuonID.Substring(0, ChuoiTaiLieuMuonID.Length - 1), TVDateTime.ChuyenVietSangAnh(txtGiaHan.Text.Trim()));
                btnFind_Click(null, null);
                WriteLog(lstChucNang[0].ChucNangID, "Gia hạn tài liệu mượn thành công", Request.UserHostAddress, Session["TenDangNhap"].ToString());
                ThongBao(" Gia hạn tài liệu thành công!");
                
            }
            else
                ThongBao("Bạn chưa chọn dữ liệu để gia hạn!");
        }
        else
            ThongBao("Bạn chưa nhập ngày gia hạn!");
    }
}
