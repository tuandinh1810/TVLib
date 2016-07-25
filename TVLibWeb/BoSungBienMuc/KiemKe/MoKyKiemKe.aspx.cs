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
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Business;

public partial class BoSungBienMuc_KiemKe_MoKyKiemKe : WebBase
{
    private cBKyKiemKe oBKyKiemKe;
    private KyKiemKeInfo pKyKiemKeInfo;
    private cBKho oBKho;
    private KhoInfo pKhoInfo;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",13,") >= 0)
        {
            pKyKiemKeInfo = new KyKiemKeInfo();
            oBKyKiemKe = new cBKyKiemKe();
            pKhoInfo = new KhoInfo();
            oBKho = new cBKho();
            oChucNang.MaChucNang = "KiemKe";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            if (!IsPostBack)
            {
                LoadKyKiemKe();
                LoadKho();
            }
            if (hidKyKiemKeID.Value == "")
            {
                btnAll.Visible = false;
                btnOpen.Visible = false;
            }
        }
        else
            Response.Redirect("Error.aspx");
    }
    private void LoadKyKiemKe()
    {
        // load ky kiem ke
        pKyKiemKeInfo.KyKiemKeID = 0;
        DataTable dtKiemKe = oBKyKiemKe.Get(pKyKiemKeInfo);
        dtKiemKe.DefaultView.RowFilter = "TrangThai=1";
        if (dtKiemKe.DefaultView.Count > 0)
        {
            hidKyKiemKeID.Value = dtKiemKe.DefaultView[0]["KyKiemKeID"].ToString();
            txtTenKyKiemKe.Text = dtKiemKe.DefaultView[0]["TenKyKiemKe"].ToString();
        }
    }
    private void LoadKho()
    {
        // load kho
        pKhoInfo.KhoID = 0;
        DataTable dtKho = oBKho.Get(pKhoInfo);
        dtKho.DefaultView.RowFilter = "Khoa=1";
        grvKho.DataSource = dtKho.DefaultView;
        grvKho.DataBind();
    }
    protected void grvKho_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // kiem tra neu da kich hoat roi thi khong hien thi nut kich hoat nua
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbTrangThai = new Label();
            lbTrangThai = (Label)(e.Row.FindControl("lbTrangThai"));
            if (lbTrangThai != null)
            {
                if (e.Row.DataItem != null)
                {
                    string Khoa = DataBinder.Eval(e.Row.DataItem, "Khoa").ToString();
                    if (Khoa.ToLower() == "true".ToLower())
                        lbTrangThai.Text = "<img src ='../../Resources/Images/lock.gif' alt='Kho đang bị khoá' runat ='server' />";
                    else
                        lbTrangThai.Text = "<img src ='../../Resources/Images/available.gif' alt='Sẵn sàng phục vụ bạn đọc' runat ='server' />";
                }
            }
        }
    }
    protected void grvKho_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvKho.PageIndex = e.NewPageIndex;
        LoadKho();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // cap nhat khoa kho
        string strID = "";
        for (int i = 0; i < grvKho.Rows.Count; i++)
        {
            strID = strID + grvKho.DataKeys[i][0].ToString() + ",";
        }
        if (strID != "")
        {
            oBKho.Update_TrangThai(strID.Substring(0, strID.Length - 1), 0);
        }
        ThongBao("Mở kho thành công!");
        WriteLog(lstChucNang[0].ChucNangID, "Mở kho", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        LoadKho();
    }
    protected void btnOpen_Click(object sender, EventArgs e)
    {
        
        pKyKiemKeInfo.KyKiemKeID = int.Parse(hidKyKiemKeID.Value);
        pKyKiemKeInfo.NgayKiemKe = DateTime.Now;
        pKyKiemKeInfo.TrangThai = false;
        pKyKiemKeInfo.TenKyKiemKe = txtTenKyKiemKe.Text.Trim();
        oBKyKiemKe.Update(pKyKiemKeInfo);
        ThongBao("Đóng kỳ kiểm kê thành công!");
        txtTenKyKiemKe.Text = "";
        hidKyKiemKeID.Value = "";
        LoadKho();
        WriteLog(lstChucNang[0].ChucNangID, "Đóng kỳ kiểm kê: "+pKyKiemKeInfo.TenKyKiemKe, Request.UserHostAddress, Session["TenDangNhap"].ToString());
    }
    protected void btnAll_Click(object sender, EventArgs e)
    {
        // cap nhat khoa kho
        string strID = "";
        for (int i = 0; i < grvKho.Rows.Count; i++)
        {
           strID = strID + grvKho.DataKeys[i][0].ToString() + ",";
        }
        if (strID != "")
        {
            oBKho.Update_TrangThai(strID.Substring(0, strID.Length - 1), 0);
        }
        btnOpen_Click(null, null);
        LoadKho();
    }
}
