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

public partial class AnPhamDinhKy_TongHop : WebBase 
{
    cBLoaiTaiLieu oBLoaiTaiLieu;
    cBTaiLieu oBTaiLieu;
    cBTaiLieu_MarcField obTaiLieu_MarcField;
    cBMaXepGia obMaXepGia;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",26,") < 0)
        {
            Response.Redirect("Error.aspx");
            return;
        }
        oBLoaiTaiLieu = new cBLoaiTaiLieu();
        oBTaiLieu = new cBTaiLieu();
        obMaXepGia = new cBMaXepGia();
        obTaiLieu_MarcField = new cBTaiLieu_MarcField();
        if (!IsPostBack)
        {
            LoadTaiLieu();
            LoadLoaiTaiLieu();
            LoadDanhSachTaiLieu();
        }
        btnLamLai.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
    }

    private void LoadTaiLieu()
    {
        if (Request["IDTaiLieu"] + "" == "")
            return;
        TaiLieuInfo oTaiLieuInfo = new TaiLieuInfo();
        oTaiLieuInfo.TaiLieuID = int.Parse(Request["IDTaiLieu"] + "");
        DataTable dtbTaiLieu = oBTaiLieu.Get(oTaiLieuInfo);
        TxtNhanDe.Text = dtbTaiLieu.Rows[0]["NhanDe"].ToString();
    }

    private void LoadLoaiTaiLieu()
    {
        LoaiTaiLieuInfo oLoaiTaiLieuInfo = new LoaiTaiLieuInfo();
        DataTable dtbLoaiTaiLieu = oBLoaiTaiLieu.Get(oLoaiTaiLieuInfo);
        LoadDropDownList(drdlLoaiTaiLieu, dtbLoaiTaiLieu, "TenLoaiTaiLieuFull", "LoaiTaiLieuID", "");
        //if (Request["IDLoaiTaiLieu"] + "" != "")
        //    drdlLoaiTaiLieu.SelectedValue = Request["IDLoaiTaiLieu"].ToString();
        DataView dtvLoaiTaiLieu = dtbLoaiTaiLieu.DefaultView;
        dtvLoaiTaiLieu.RowFilter = "TenLoaiTaiLieu = 'APDK'";
        int IDAnPhamDinhKy = -1;
        if (dtvLoaiTaiLieu.Count > 0)
            IDAnPhamDinhKy = int.Parse("0" + dtvLoaiTaiLieu[0]["LoaiTaiLieuID"]);
        drdlLoaiTaiLieu.SelectedValue = IDAnPhamDinhKy.ToString();
        lnkQuanLyTaiLieu.NavigateUrl = "~/BoSungBienMuc/MauBienMucIndex.aspx?IDLoaiTaiLieu=" + IDAnPhamDinhKy.ToString();
        LoadDanhSachTaiLieu();
    }

    private void LoadDanhSachTaiLieu()
    {
        int intIDLoaiTaiLieu = 0;
        if (drdlLoaiTaiLieu.SelectedIndex >= 0)
        {
            intIDLoaiTaiLieu = int.Parse(drdlLoaiTaiLieu.SelectedValue);
        }
        //DataTable dtbTaiLieu = oBTaiLieu.GetByLoaiTaiLieu(intIDLoaiTaiLieu);
        //grvTaiLieu.PageSize = int.Parse(ddlPageSize.SelectedValue.ToString());
        //if (dtbTaiLieu.Rows.Count == 0)
        //{
        //    dtbTaiLieu = InsertOneRow(dtbTaiLieu, "", 0, 0);
        //    grvTaiLieu.DataSource = dtbTaiLieu;            
        //    grvTaiLieu.DataBind();
        //    grvTaiLieu.Rows[0].Visible = false;
        //    lblTotal.Text = "0";
        //}
        //else
        //{
        //    lblTotal.Text = dtbTaiLieu.Rows.Count.ToString();
        //    grvTaiLieu.DataSource = dtbTaiLieu;
        //    grvTaiLieu.DataBind();
        //}
        string strSql = "";
        strSql = "SELECT DISTINCT IDTaiLieu FROM TaiLieu_MarcField INNER JOIN TaiLieu ON TaiLieuID = IDTaiLieu WHERE 1=1 ";
        if (intIDLoaiTaiLieu != 0)
            strSql = strSql + " AND IDLoaiTaiLieu = " + intIDLoaiTaiLieu.ToString();
        if (TxtNhanDe.Text != "")
        {
            strSql = strSql + "AND DisplayEntry  Like N'%" + TxtNhanDe.Text + "%' AND (IDMarcField=449 OR  IDMarcField=450)";
        }
        if (TxtTacGia.Text != "")
        {
            strSql = strSql + "AND DisplayEntry Like N'%" + TxtTacGia.Text + "%' AND (IDMarcField=312 OR IDMarcField=329 OR IDMarcField= 1399 OR IDMarcField= 1433)";
        }
        if (TxtTuKhoa.Text != "")
        {
            strSql = strSql + "AND DisplayEntry Like N'%" + TxtTuKhoa.Text + "%' AND IDMarcField=1342";
        }
        if (TxtMoTa.Text != "")
        {
            strSql = strSql + "AND DisplayEntry Like N'%" + TxtMoTa.Text + "%'  AND IDMarcField=911";
        }
        if (txtChiSoISBN.Text != "")
        {
            strSql = strSql + "AND DisplayEntry Like N'%" + txtChiSoISBN.Text + "%'  AND IDMarcField=66 OR IDMarcField= 73";
        }
        if (txtMaXepGia.Text != "")
        {
            strSql = strSql + "AND IDTaiLieu IN (SELECT IDTaiLieu FROM MaXepGia WHERE MaXepGia='" + txtMaXepGia.Text + "')";
        }
        obTaiLieu_MarcField = new cBTaiLieu_MarcField();
        grvTaiLieu.PageSize = int.Parse(ddlPageSize.SelectedValue.ToString());
        DataTable dtbKetQua;
        dtbKetQua = obTaiLieu_MarcField.RunSql(strSql);
        string strTaiLieuID = "";
        if (dtbKetQua.Rows.Count > 0)
        {
            for (int i = 0; i < dtbKetQua.Rows.Count; i++)
            {
                strTaiLieuID = strTaiLieuID + dtbKetQua.Rows[i]["IDTaiLieu"].ToString() + ",";
            }
            if (strTaiLieuID != "")
            {
                strTaiLieuID = strTaiLieuID.Substring(0, strTaiLieuID.Length - 1);
            }
            DataTable dtbThongTinTaiLieu;
            dtbThongTinTaiLieu = obTaiLieu_MarcField.GetThongTinTaiLieu(strTaiLieuID);
            if (dtbThongTinTaiLieu.Rows.Count > 0)
            {
                //ThongBao("Có" + " " + dtbThongTinTaiLieu.Rows.Count.ToString() + "kết quả được tìm thấy");
                lblTotal.Text = dtbThongTinTaiLieu.Rows.Count.ToString();
                grvTaiLieu.DataSource = dtbThongTinTaiLieu;
                grvTaiLieu.DataBind();
            }
            else
            {
                ThongBao("Không tìm thấy kết quả nào!");
                grvTaiLieu.DataSource = null;
                grvTaiLieu.DataBind();
            }

        }
        else
        {
            ThongBao("Không tìm thấy kết quả nào!");
            grvTaiLieu.DataSource = null;
            grvTaiLieu.DataBind();
        }
    }


    protected void grvTaiLieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTaiLieu.PageIndex = e.NewPageIndex;
        LoadDanhSachTaiLieu();
    }

    //protected void grvTaiLieu_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        if (e.Row.Cells[1].Text.Length > 120)
    //            e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 120) + " <font color='blue'>...</font>";
    //    }
    //}

    protected void grvTaiLieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TaiLieuInfo oTaiLieuInfo = new TaiLieuInfo();
        oTaiLieuInfo.TaiLieuID = int.Parse(grvTaiLieu.DataKeys[e.RowIndex].Value.ToString());
        try
        {
            oBTaiLieu.Delete(oTaiLieuInfo);
        }
        catch (Exception exp)
        {
            ThongBao("Tài liệu đang được sử dụng ko thể xóa!");
        }
        LoadDanhSachTaiLieu();
    }
    protected void btnTimKiem_Click(object sender, EventArgs e)
    {
        LoadDanhSachTaiLieu();
    }
    protected void drdlLoaiTaiLieu_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDanhSachTaiLieu();
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDanhSachTaiLieu();
    }
}
