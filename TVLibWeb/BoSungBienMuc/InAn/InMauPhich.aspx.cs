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

public partial class BoSungBienMuc_InAn_InMauPhich : WebBase
{
    cBTaiLieu_MarcField obTaiLieu_MarcField;
    cBMauPhich oBMauPhich;
    MauPhichInfo pMauPhichInfo;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",9,") >= 0)
        {
            BindJS();
            oChucNang.MaChucNang = "InPhich";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            if (!IsPostBack)
            {
                trlblDanhSachTaiLieu.Visible = false;
                trChucNang.Visible = false;
                GetMauPhich();
            }
        }
        else
            Response.Redirect("Error.aspx");
    }
    public void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(),"Js", "<script language='javascript' src='../../Resources/Js/TVLib.js'></script>");
        btnTimKiem.Attributes.Add("Onclick", "if(CheckDate(document.forms[0].'ctl00$ContentPlaceHolder1$txtFromDate,'Không đúng kiểu định dạng ngày tháng!')== false ||  CheckDate(document.forms[0].'ctl00$ContentPlaceHolder1$txToDate,'Không đúng kiểu định dạng ngày tháng!')== false ){return false;}");
//        btnReset.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
    }
    public void GetMauPhich()
    {
        pMauPhichInfo = new MauPhichInfo();
        oBMauPhich = new cBMauPhich();
        drdlMauPhich.DataSource = oBMauPhich.Get(pMauPhichInfo);
        drdlMauPhich.DataTextField = "TenMauPhich";
        drdlMauPhich.DataValueField = "MauPhichID";
        drdlMauPhich.DataBind();
    }
    public void TimKiem()
    {
        string strSql = "";
        strSql = "SELECT DISTINCT IDTaiLieu FROM TaiLieu_MarcField WHERE 1=1 ";
        if (TxtNhanDe.Text != "")
        {
            strSql = strSql + " AND DisplayEntry  Like N'%" + TxtNhanDe.Text + "%' AND (IDMarcField=449 OR  IDMarcField=450)";
        }
        if (TxtTacGia.Text != "")
        {
            strSql = strSql + " AND DisplayEntry Like N'%" + TxtTacGia.Text + "%' AND (IDMarcField=312 OR IDMarcField=329 OR IDMarcField= 1399 OR IDMarcField= 1433)";
        }
        if (TxtTuKhoa.Text != "")
        {
            strSql = strSql + " AND DisplayEntry Like N'%" + TxtTuKhoa.Text + "%' AND IDMarcField=1342";
        }
        if (TxtMoTa.Text != "")
        {
            strSql = strSql + " AND DisplayEntry Like N'%" + TxtMoTa.Text + "%'  AND IDMarcField=911";
        }
        if (txtChiSoISBN.Text != "")
        {
            strSql = strSql + " AND DisplayEntry Like N'%" + txtChiSoISBN.Text + "%'  AND IDMarcField=66 OR IDMarcField= 73";
        }
        if (txtMaXepGia.Text != "")
        {
            strSql = strSql + " AND IDTaiLieu IN (SELECT IDTaiLieu FROM MaXepGia WHERE MaXepGia='" + txtMaXepGia.Text + "')";
        }
        if (txtFromDate.Text != "")
        {
            txtFromDate.Text = txtFromDate.Text + " 00:00:00";
            strSql = strSql + " AND IDTaiLieu IN (select TaiLieuID From  TaiLieu where NgayCapNhat >= convert(datetime,'" + txtFromDate.Text + "',103) )";
        }
        if (txToDate.Text != "")
        {
            txToDate.Text = txToDate.Text + " 23:59:59";
            strSql = strSql + " AND IDTaiLieu IN (select TaiLieuID From  TaiLieu where NgayCapNhat <= convert(datetime,'" + txToDate.Text + "',103) )";
        }
        obTaiLieu_MarcField = new cBTaiLieu_MarcField();

        DataTable dtbKetQua;
        dtbKetQua = obTaiLieu_MarcField.RunSql(strSql);
        string strTaiLieuID = "";
        hdTaiLieuID.Value = "";
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
            strTaiLieuID = "";
            for (int i = 0; i < dtbThongTinTaiLieu.Rows.Count; i++)
            {
                strTaiLieuID = strTaiLieuID + dtbThongTinTaiLieu.Rows[i]["TaiLieuID"].ToString() + ",";
            }
            hdTaiLieuID.Value = strTaiLieuID;
            if (dtbThongTinTaiLieu.Rows.Count > 0)
            {
                trlblDanhSachTaiLieu.Visible = true;
                trChucNang.Visible = true;
                //ThongBao("Có" + " " + dtbThongTinTaiLieu.Rows.Count.ToString() + "kết quả được tìm thấy");
                grvResult.DataSource = dtbThongTinTaiLieu;
                grvResult.DataBind();
            }
            else
            {
                trlblDanhSachTaiLieu.Visible = false;
                trChucNang.Visible = false;
                ThongBao("Không tìm thấy kết quả nào!");
                grvResult.DataSource = null;
                grvResult.DataBind();
            }

        }
        else
        {
            trlblDanhSachTaiLieu.Visible = false;
            trChucNang.Visible = false;
            ThongBao("Không tìm thấy kết quả nào!");
            grvResult.DataSource = null;
            grvResult.DataBind();
        }
    }
    protected void btnTimKiem_Click(object sender, EventArgs e)
    {
        TimKiem();
    }
    protected void grvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvResult.PageIndex = e.NewPageIndex;
        TimKiem();
    }
    protected void btnInNhan_Click(object sender, EventArgs e)
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
            Session["ChuoiTaiLieu"] = ChuoiTaiLieuID.Substring(0, ChuoiTaiLieuID.Length - 1);
            Session["MauPhich"] = drdlMauPhich.SelectedValue.ToString();
            WriteLog(lstChucNang[0].ChucNangID, "In phích", Request.UserHostAddress, Session["TenDangNhap"].ToString());

            ClientScript.RegisterClientScriptBlock(GetType(), "WLabelPrintJs", "<script language='javascript'>OpenWindow('PrintPhich.aspx','InNhan',950,600,50,25);</script>");
        }
        else
            ThongBao("Không tìm thấy dữ liệu để in!");
    }
    protected void btnInAll_Click(object sender, EventArgs e)
    {
        if (hdTaiLieuID.Value != "")
        {
            Session["ChuoiTaiLieu"] = hdTaiLieuID.Value.Substring(0, hdTaiLieuID.Value.Length - 1);
            Session["MauPhich"] = drdlMauPhich.SelectedValue.ToString();
            WriteLog(lstChucNang[0].ChucNangID, "In phích", Request.UserHostAddress, Session["TenDangNhap"].ToString());
            ClientScript.RegisterClientScriptBlock(GetType(), "WLabelPrintJs", "<script language='javascript'>OpenWindow('PrintPhich.aspx','InNhan',950,600,50,25);</script>");
        }
        else
            ThongBao("Không tìm thấy dữ liệu để in!");
    }
    protected void grvResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            ((CheckBox)(e.Row.Cells[0].FindControl("cbxCheckAll"))).Attributes.Add("onclick", "_CheckAllCheckBox('grvResult','cbxDKCB',1,10);");
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtChiSoISBN.Text = "";
        txtFromDate.Text = "";
        txToDate.Text = "";
        txtMaXepGia.Text = "";
        TxtTuKhoa.Text = "";
        TxtNhanDe.Text = "";
        TxtMoTa.Text = "";
        TxtTacGia.Text = "";
        grvResult.DataSource = null;
        grvResult.DataBind();
        trlblDanhSachTaiLieu.Visible = false;
        trChucNang.Visible = false;
    }
}
