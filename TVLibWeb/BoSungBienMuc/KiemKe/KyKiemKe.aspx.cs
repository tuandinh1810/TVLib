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

public partial class BoSungBienMuc_KiemKe_KyKiemKe : WebBase
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
        }
        else
            Response.Redirect("Error.aspx");
    }
    private void LoadKyKiemKe()
    { 
        //ddlKyKiemKe.DataSource = InsertOneRow(oBKyKiemKe.Get(pKyKiemKeInfo), "----Tạo mới-----", 0, 0);
        //ddlKyKiemKe.DataTextField = "TenKyKiemKe";
        //ddlKyKiemKe.DataValueField = "KyKiemKeID";
        //ddlKyKiemKe.DataBind();
        //// load ky kiem ke
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
        grvKho.DataSource = oBKho.Get(pKhoInfo);
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
        // them moi ky kiem ke
        pKyKiemKeInfo.TenKyKiemKe = txtTenKyKiemKe.Text.Trim();
        pKyKiemKeInfo.NgayKiemKe = DateTime.Now;
        pKyKiemKeInfo.TrangThai = true;
        oBKyKiemKe.Add(pKyKiemKeInfo);
        // cap nhat khoa kho
        string strID = "";
        for (int i = 0; i < grvKho.Rows.Count; i++)
        {
            if (((CheckBox)grvKho.Rows[i].Cells[0].FindControl("chkSelect")).Checked)
            {
                strID = strID + grvKho.DataKeys[i][0].ToString() + ",";
            }
        }
        if (strID != "")
        {
            oBKho.Update_TrangThai(strID.Substring(0, strID.Length - 1), 1);
        }
        ThongBao("Tạo kỳ kiểm kê thành công!");
        LoadKho();
        btnAdd.Enabled = false;
        WriteLog(lstChucNang[0].ChucNangID, "Thêm mới kỳ kiểm kê : "+txtTenKyKiemKe.Text, Request.UserHostAddress, Session["TenDangNhap"].ToString());
    }
}
