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

        Response.Write("<Script src='../../Resources/Js/TVLib.js'" + " ></Script>");
        oChucNang.MaChucNang = "InNhanGay";
        lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
        if(!IsPostBack)
        {
            
            trChucNang.Visible = false;
            trlblDanhSachTaiLieu.Visible = false;
            trlblDanhSachXepGia.Visible = false;
            LoadNhanGay(0);
            if (Request["TaiLieuID"] + "" != "")
            {
                pTaiLieuInfo = new TaiLieuInfo();
                oBTaiLieu = new cBTaiLieu();
                pTaiLieuInfo.TaiLieuID = int.Parse(Request["TaiLieuID"].ToString());
                grvResult.DataSource = oBTaiLieu.Get(pTaiLieuInfo);
                grvResult.DataBind();
                grvResult.SelectedIndex = 0;
                grvResult_SelectedIndexChanged(null, null);
            }
        }
    }
    public void TimKiem()
    {
        grvResult.PageSize = int.Parse(ddlPageSize.SelectedValue.ToString());
        trlblDanhSachXepGia.Visible = false;
        trChucNang.Visible = false;
        string strSql = "";
        strSql = "SELECT DISTINCT IDTaiLieu FROM TaiLieu_MarcField WHERE 1=1 ";
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
        
        DataTable dtbKetQua;
        dtbKetQua = obTaiLieu_MarcField.RunSql(strSql);
        string strTaiLieuID = "";
        if (dtbKetQua.Rows.Count > 0)
        {
            for (int i = 0; i < dtbKetQua.Rows.Count; i++)
            { 
                strTaiLieuID=strTaiLieuID +dtbKetQua.Rows[i]["IDTaiLieu"].ToString()+",";
            }
            if(strTaiLieuID!="")
            {
                strTaiLieuID = strTaiLieuID.Substring(0, strTaiLieuID.Length - 1);
            }
            DataTable dtbThongTinTaiLieu;
            dtbThongTinTaiLieu = obTaiLieu_MarcField.GetThongTinTaiLieu(strTaiLieuID);
            if (dtbThongTinTaiLieu.Rows.Count > 0)
            {
                trlblDanhSachTaiLieu.Visible = true;
                //ThongBao("Có" + " " + dtbThongTinTaiLieu.Rows.Count.ToString() + "kết quả được tìm thấy");
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
            ThongBao("Không tìm thấy kết quả nào!");
            grvResult.DataSource = null;
            grvResult.DataBind();
            grvMaXepGia.DataSource = null;
            grvMaXepGia.DataBind();
        }
    }
    protected void grvResult_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdTaiLieuID.Value = grvResult.DataKeys[grvResult.SelectedIndex][0].ToString();
        if (hdTaiLieuID.Value != "")
            GetMaXepGia();
    }
    private void GetMaXepGia()
    {
        obMaXepGia = new cBMaXepGia();
        grvMaXepGia.PageSize = int.Parse(ddlPageSizeMXG.SelectedValue.ToString()); 
        if (hdTaiLieuID.Value != "")
        {
            DataTable dtbMaXepGia = obMaXepGia.GetByTaiLieu(int.Parse(hdTaiLieuID.Value));
            if (dtbMaXepGia.Rows.Count > 0)
            {
                trlblDanhSachXepGia.Visible = true;
                trChucNang.Visible = true;
                grvMaXepGia.DataSource = dtbMaXepGia;
                grvMaXepGia.DataBind();
            }
            else
            {
                trlblDanhSachXepGia.Visible = false;
                trChucNang.Visible = false;
                grvMaXepGia.DataSource = null;
                grvMaXepGia.DataBind();
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
        if(drdlMauNhanGay.SelectedValue+""!="")
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
                ChuoiMaXG = ChuoiMaXG +  grvMaXepGia.DataKeys[i][0].ToString() + ",";
            }
        }
        if (ChuoiMaXG !="")
        {
            Session["ChuoiMaXG"] = ChuoiMaXG.Substring(0, ChuoiMaXG.Length - 1);
            Session["MauNhanGay"] = drdlMauNhanGay.SelectedValue.ToString();
            WriteLog(lstChucNang[0].ChucNangID, "In Nhãn Gáy", Request.UserHostAddress, Session["TenDangNhap"].ToString());
            ClientScript.RegisterClientScriptBlock(GetType(), "WLabelPrintJs", "<script language='javascript'>document.location.href='PrintLabel.aspx';void(0);</script>");
            //btnInNhan.Attributes.Add("Onclick", "javascript:OpenWindow('PrintLabel.aspx','InNhan',850,600,50,25);");
        }
        else
            ThongBao("Không tìm thấy dữ liệu để in!");
       
    }
    protected void grvMaXepGia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            ((CheckBox)(e.Row.Cells[0].FindControl("cbxCheckAll"))).Attributes.Add("onclick", "_CheckAllCheckBoxNotMaster('grvMaXepGia','cbxDKCB',1," + ddlPageSizeMXG.SelectedValue + ");");
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
                ClientScript.RegisterClientScriptBlock(GetType(), "WLabelPrintJs", "<script language='javascript'>document.location.href='PrintLabel.aspx';void(0);</script>");
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
        txtChiSoISBN.Text = "";
        txtMaXepGia.Text = "";
        TxtNhanDe.Text = "";
        TxtMoTa.Text = "";
        TxtTacGia.Text = "";
        TxtTuKhoa.Text = "";
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
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        TimKiem();
    }
    protected void ddlPageSizeMXG_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetMaXepGia();
    }
}

