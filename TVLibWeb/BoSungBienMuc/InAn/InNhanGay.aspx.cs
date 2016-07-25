using System;
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

public partial class BoSungBienMuc_InNhanGay : WebBase
{
    cBTaiLieu_MarcField obTaiLieu_MarcField;
    cBMaXepGia obMaXepGia;
    cBNhanGay obNhanGay;
    NhanGayInfo oNhanGayInfo;
    TaiLieuInfo pTaiLieuInfo;
    cBTaiLieu oBTaiLieu;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",5,") >= 0)
        {
            Response.Write("<Script src='../../Resources/Js/TVLib.js'" + " ></Script>");
            oChucNang.MaChucNang = "InNhanGay";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            if (!IsPostBack)
            {
                trChucNang.Visible = false;
                trlblDanhSachTaiLieu.Visible = false;
                trlblDanhSachXepGia.Visible = false;
                ddlPageSizeMXG.Visible = false;
                lblTotal.Visible = false;
                btnChon.Visible = false;
                LoadNhanGay(0);
                if (Request["TaiLieuID"] + "" != "")
                {
                    pTaiLieuInfo = new TaiLieuInfo();
                    oBTaiLieu = new cBTaiLieu();
                    pTaiLieuInfo.TaiLieuID = int.Parse(Request["TaiLieuID"].ToString());
                    grvResult.DataSource = oBTaiLieu.Get(pTaiLieuInfo);
                    grvResult.DataBind();
                    // grvResult.SelectedIndex = 0;
                    // grvResult_SelectedIndexChanged(null, null);
                }
            }
        }
        else
            Response.Redirect("Error.aspx");

    }
    public void TimKiem()
    {
        grvResult.PageSize = int.Parse(ddlPageSize.SelectedValue.ToString());
        trlblDanhSachXepGia.Visible = false;
        trChucNang.Visible = false;
        //string strSql = "";
        //strSql = "SELECT DISTINCT IDTaiLieu FROM TaiLieu_MarcField WHERE 1=1 ";
        //if (TxtNhanDe.Text != "")
        //{
        //    strSql = strSql + "AND DisplayEntry  Like N'%" + TxtNhanDe.Text + "%' AND (IDMarcField=449 OR  IDMarcField=450)";
        //}
        //if (TxtTacGia.Text != "")
        //{
        //    strSql = strSql + "AND DisplayEntry Like N'%" + TxtTacGia.Text + "%' AND (IDMarcField=312 OR IDMarcField=329 OR IDMarcField= 1399 OR IDMarcField= 1433)";
        //}
        //if (TxtTuKhoa.Text != "")
        //{
        //    strSql = strSql + "AND DisplayEntry Like N'%" + TxtTuKhoa.Text + "%' AND IDMarcField=1342";
        //}
        //if (TxtMoTa.Text != "")
        //{
        //    strSql = strSql + "AND DisplayEntry Like N'%" + TxtMoTa.Text + "%'  AND IDMarcField=911";
        //}
        //if (txtChiSoISBN.Text != "")
        //{
        //    strSql = strSql + "AND DisplayEntry Like N'%" + txtChiSoISBN.Text + "%'  AND IDMarcField=66 OR IDMarcField= 73";
        //}
        //if (txtMaXepGia.Text != "")
        //{
        //    strSql = strSql + "AND IDTaiLieu IN (SELECT IDTaiLieu FROM MaXepGia WHERE MaXepGia='" + txtMaXepGia.Text + "')";
        //}

        string strWhere = "";
        string strSelect = "";
        string strSql = "";
        Boolean bnltemp = false;
        string strTaiLieuID = "";
        //Truong du lieu 1
        strSelect = "SELECT DISTINCT A.TaiLieuID FROM TaiLieu A  " + "WHERE LuuThong = 1 ";
        if (TxtNhanDe.Text != "")
            strWhere = strWhere + FormingSql(1, 1, TxtNhanDe.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        if (TxtTacGia.Text != "")
            strWhere = strWhere + FormingSql(1, 2, TxtTacGia.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        if (txtDongTacGia.Text != "")
            strWhere = strWhere + FormingSql(1, 3, txtDongTacGia.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        if (txtTuKhoa.Text != "")
            strWhere = strWhere + FormingSql(1, 6, txtTuKhoa.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        if (txtNhaXuatBan.Text != "")
            strWhere = strWhere + FormingSql(1, 5, txtNhaXuatBan.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        if (TxtMoTa.Text != "")
            strWhere = strWhere + FormingSql(1, 4, TxtMoTa.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        strSql = strSelect + strWhere;

        strSql = "select *,isnull(dbo.TaiLieu_LayNhanDe(TaiLieuID),'') as NhanDe,'' as NgayXuatBan,isnull(dbo.GetTruongThongTin(TaiLieuID, 312),'') as TacGia FROM TaiLieu where LuuThong = 1 and TaiLieuID IN(" + strSql + ") ORDER BY TaiLieuID DESC";

        obTaiLieu_MarcField = new cBTaiLieu_MarcField();

        DataTable dtbKetQua;
        dtbKetQua = obTaiLieu_MarcField.RunSql(strSql);

        if (dtbKetQua.Rows.Count > 0)
        {
            for (int i = 0; i < dtbKetQua.Rows.Count; i++)
            {
                strTaiLieuID = strTaiLieuID + dtbKetQua.Rows[i]["TaiLieuID"].ToString() + ",";
            }
            if (strTaiLieuID != "")
            {
                strTaiLieuID = strTaiLieuID.Substring(0, strTaiLieuID.Length - 1);
            }
            DataTable dtbThongTinTaiLieu;
            dtbThongTinTaiLieu = obTaiLieu_MarcField.GetThongTinTaiLieu(strTaiLieuID);
            if (dtbThongTinTaiLieu.Rows.Count > 0)
            {
                trlblDanhSachTaiLieu.Visible = true;
                //ThongBao("Có" + " " + dtbThongTinTaiLieu.Rows.Count.ToString() + "kết quả được tìm thấy");
                btnChon.Visible = true;
                grvResult.DataSource = dtbThongTinTaiLieu;
                grvResult.DataBind();
                grvMaXepGia.DataSource = null;
                grvMaXepGia.DataBind();
            }
            else
            {
                trChucNang.Visible = false;
                trlblDanhSachTaiLieu.Visible = false;
                trlblDanhSachXepGia.Visible = false;
                btnChon.Visible = false;
                ThongBao("Không tìm thấy kết quả nào!");
                grvResult.DataSource = null;
                grvResult.DataBind();
                grvMaXepGia.DataSource = null;
                grvMaXepGia.DataBind();
            }

        }
        else
        {
            trChucNang.Visible = false;
            trlblDanhSachTaiLieu.Visible = false;
            trlblDanhSachXepGia.Visible = false;
            btnChon.Visible = false;
            ThongBao("Không tìm thấy kết quả nào!");
            grvResult.DataSource = null;
            grvResult.DataBind();
            grvMaXepGia.DataSource = null;
            grvMaXepGia.DataBind();
        }
    }
    protected string FormingSql(int intOperation, int intMetadataID, string strSearch)
    {

        string strTemp = "";
        string strFinalSql = "";
        if (intMetadataID == 0)
        {
            strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID=B.IDTaiLieu WHERE Contains(DisplayEntry,N'" + strSearch + "') ";
        }
        else
        {
            if (intMetadataID == 1)
                // nhan de
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 449 AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
            else if (intMetadataID == 2) // tac gia
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE (IDMarcField = 312 OR IDMarcField=330) AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
            else if (intMetadataID == 3) // Dong tac gia
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE (IDMarcField = 1443 OR IDMarcField=1399) AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
            else if (intMetadataID == 4) // mo ta
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 911  AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
            else if (intMetadataID == 5) // Nha xuat ban
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 519 AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
            else if (intMetadataID == 6) // tu khoa
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 1342 AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
        }

        switch (intOperation)
        {
            case 1:
                strFinalSql = " AND A.TaiLieuID IN (" + strTemp + ")";
                break;
            case 2:
                strFinalSql = " UNION " + strTemp;
                break;
            case 3:
                strFinalSql = " AND A.TaiLieuID NOT IN (" + strTemp + ")";
                break;
        }
        return strFinalSql;
    }
    //protected void grvResult_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    hdTaiLieuID.Value = grvResult.DataKeys[grvResult.SelectedIndex][0].ToString();
    //    if (hdTaiLieuID.Value != "")
    //        GetMaXepGia();
    //}
    private void GetMaXepGia()
    {
        grvMaXepGia.PageSize = int.Parse(ddlPageSizeMXG.SelectedValue.ToString());
        obMaXepGia = new cBMaXepGia();
        if (hdTaiLieuID.Value != "")
        {
            DataTable dtbMaXepGia = obMaXepGia.GetByIDTaiLieus(hdTaiLieuID.Value);
            if (dtbMaXepGia.Rows.Count > 0)
            {
                trlblDanhSachXepGia.Visible = true;
                trChucNang.Visible = true;
                ddlPageSizeMXG.Visible = true;
                lblTotal.Visible = true;
                grvMaXepGia.DataSource = dtbMaXepGia;
                grvMaXepGia.DataBind();
            }
            else
            {
                trlblDanhSachXepGia.Visible = false;
                trChucNang.Visible = false;
                ddlPageSizeMXG.Visible = false;
                lblTotal.Visible = false;
                grvMaXepGia.DataSource = null;
                grvMaXepGia.DataBind();
                ThongBao("Tài liệu chưa được xếp giá");
            }
        }
    }
    public void LoadNhanGay(int intNhanGayID)
    {
        oNhanGayInfo = new NhanGayInfo();
        obNhanGay = new cBNhanGay();
        oNhanGayInfo.NhanGayID = intNhanGayID;
        DataTable dtbNhanGay = obNhanGay.Get(oNhanGayInfo);
        LoadDropDownList(drdlMauNhanGay, dtbNhanGay, "TenNhanGay", "NhanGayID", "");
    }
    protected void btnTimKiem_Click(object sender, EventArgs e)
    {
        TimKiem();
    }
    protected void drdlMauNhanGay_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drdlMauNhanGay.SelectedValue + "" != "")
        {
            LoadNhanGay(int.Parse(drdlMauNhanGay.SelectedValue.ToString()));
        }

    }
    protected void btnInNhan_Click(object sender, EventArgs e)
    {
        string ChuoiMaXG = "";
        for (int i = 0; i < grvMaXepGia.Rows.Count; i++)
        {
            if (((CheckBox)grvMaXepGia.Rows[i].Cells[0].FindControl("cbxDKCB")).Checked)
            {
                ChuoiMaXG = ChuoiMaXG + grvMaXepGia.DataKeys[i][0].ToString() + ",";
            }
        }
        if (ChuoiMaXG != "")
        {
            Session["ChuoiMaXG"] = ChuoiMaXG.Substring(0, ChuoiMaXG.Length - 1);
            Session["MauNhanGay"] = drdlMauNhanGay.SelectedValue.ToString();
            WriteLog(lstChucNang[0].ChucNangID, "In Nhãn Gáy", Request.UserHostAddress, Session["TenDangNhap"].ToString());
            ClientScript.RegisterClientScriptBlock(GetType(), "WLabelPrintJs", "<script language='javascript'>OpenWindow('PrintLabel.aspx','PrintLabel',950,600,50,25);void(0);//document.location.href='PrintLabel.aspx';void(0);</script>");

            //btnInNhan.Attributes.Add("Onclick", "javascript:OpenWindow('PrintLabel.aspx','InNhan',850,600,50,25);");
        }
        else
            ThongBao("Không tìm thấy dữ liệu để in!");

    }
    protected void grvMaXepGia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            ((CheckBox)(e.Row.Cells[0].FindControl("cbxCheckAll"))).Attributes.Add("onclick", "_CheckAllCheckBox('grvMaXepGia','cbxDKCB',1," + ddlPageSizeMXG.SelectedValue + ");");
    }
    protected void grvMaXepGia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvMaXepGia.PageIndex = e.NewPageIndex;
        GetMaXepGia();
    }
    protected void btnInAll_Click(object sender, EventArgs e)
    {
        if (hdTaiLieuID.Value != "")
        {
            obMaXepGia = new cBMaXepGia();
            DataTable dtbMaXepGia = obMaXepGia.GetByTaiLieu(int.Parse(hdTaiLieuID.Value));
            if (dtbMaXepGia.Rows.Count > 0)
            {
                string ChuoiMaXG = "";
                for (int i = 0; i < dtbMaXepGia.Rows.Count; i++)
                {
                    ChuoiMaXG = ChuoiMaXG + dtbMaXepGia.Rows[i]["MaXepGia"].ToString() + ",";
                }
                Session["ChuoiMaXG"] = ChuoiMaXG.Substring(0, ChuoiMaXG.Length - 1).Replace("'", "");
                Session["MauNhanGay"] = drdlMauNhanGay.SelectedValue.ToString();
                WriteLog(lstChucNang[0].ChucNangID, "In Nhãn Gáy", Request.UserHostAddress, Session["TenDangNhap"].ToString());
                ClientScript.RegisterClientScriptBlock(GetType(), "WLabelPrintJs", "<script language='javascript'>OpenWindow('PrintLabel.aspx','PrintLabel',950,600,50,25);void(0);;//document.location.href='PrintLabel.aspx';void(0);</script>");
            }
            else
                ThongBao("Không tìm thấy dữ liệu để in!");
        }
    }
    protected void btnLamLai_Click(object sender, EventArgs e)
    {
        trlblDanhSachXepGia.Visible = false;
        trlblDanhSachTaiLieu.Visible = false;
        trChucNang.Visible = false;
        btnChon.Visible = false;
        txtDongTacGia.Text = "";
        TxtNhanDe.Text = "";
        TxtMoTa.Text = "";
        TxtTacGia.Text = "";
        txtTuKhoa.Text = "";
        grvResult.DataSource = null;
        grvResult.DataBind();
        grvMaXepGia.DataSource = null;
        grvMaXepGia.DataBind();
    }
    protected void grvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvResult.PageIndex = e.NewPageIndex;
        TimKiem();
    }
    protected void grvMaXepGia_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlPageSizeMXG_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetMaXepGia();
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        TimKiem();
    }
    protected void grvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            ((CheckBox)(e.Row.Cells[2].FindControl("cbxCheckAll"))).Attributes.Add("onclick", "_CheckAllCheckBox('grvResult','cbxDKCB',1," + ddlPageSizeMXG.SelectedValue + ");");
    }
    protected void btnChon_Click(object sender, EventArgs e)
    {
        string ChuoiTaiLieuID = "";
        for (int i = 0; i < grvResult.Rows.Count; i++)
        {
            if (((CheckBox)grvResult.Rows[i].Cells[0].FindControl("cbxDKCB")).Checked)
            {
                ChuoiTaiLieuID = ChuoiTaiLieuID + grvResult.DataKeys[i][0].ToString() + ",";
            }
        }
        if (ChuoiTaiLieuID != "")
        {
            ChuoiTaiLieuID = ChuoiTaiLieuID.Substring(0, ChuoiTaiLieuID.Length - 1);
            hdTaiLieuID.Value = ChuoiTaiLieuID;
        }
        GetMaXepGia();
    }
}
