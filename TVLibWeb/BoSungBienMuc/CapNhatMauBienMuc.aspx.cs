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

public partial class BoSungBienMuc_CapNhatMauBienMuc : WebBase 
{
    cBMauBienMuc_ChiTiet oBMauBienMuc_ChiTiet;
    MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo;
    cBMauBienMuc oBMauBienMuc;
    MauBienMucInfo pMauBienMucInfo;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, System.EventArgs e)
    {
        pMauBienMucInfo = new MauBienMucInfo();
        oBMauBienMuc = new cBMauBienMuc();
        oBMauBienMuc_ChiTiet = new cBMauBienMuc_ChiTiet();
        pMauBienMuc_ChiTietInfo = new MauBienMuc_ChiTietInfo();
        oChucNang.MaChucNang = "BienMuc";
        lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
        if (!IsPostBack)
        {
            GetDuLieu();
        }
    }
    // load data in Gridview
    private void GetDuLieu()
    {
        if (Request["MauBienMucID"] + "" != "")
        {
            DataTable dtTemp = oBMauBienMuc_ChiTiet.Get_ByMauBienMuc(int.Parse("0" + Request["MauBienMucID"].ToString()));
            grvMauBienMuc.DataSource = dtTemp;
            grvMauBienMuc.DataBind();
            txtTenMauBienMuc.Text = dtTemp.Rows[0]["Ten"].ToString();
        }
    }
    protected void grvMauBienMuc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvMauBienMuc.EditIndex = -1;
        GetDuLieu();
    }
    protected void grvMauBienMuc_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        pMauBienMuc_ChiTietInfo.GiaTriMacDinh = ((TextBox)grvMauBienMuc.Rows[e.RowIndex].FindControl("txtGiaTriMacDinh")).Text;
        // update
        pMauBienMuc_ChiTietInfo.IDMARC_FIELD = int.Parse(grvMauBienMuc.DataKeys[e.RowIndex][1].ToString());
        pMauBienMuc_ChiTietInfo.IDMauBienMuc = int.Parse("0" + Request["MauBienMucID"].ToString());
        pMauBienMuc_ChiTietInfo.ID = int.Parse(grvMauBienMuc.DataKeys[e.RowIndex][0].ToString());
        oBMauBienMuc_ChiTiet.Update(pMauBienMuc_ChiTietInfo);
        grvMauBienMuc.EditIndex = -1;
        GetDuLieu();
    }
    protected void grvMauBienMuc_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvMauBienMuc.EditIndex = e.NewEditIndex;
        GetDuLieu();
    }
    protected void grvMauBienMuc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvMauBienMuc.EditIndex = e.NewPageIndex;
        GetDuLieu();
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript'>self.location.href='MauBienMuc_Marc21.aspx?MauBienMucID=" + Request["MauBienMucID"].ToString() + "';</script>");
    }
    protected void grvMauBienMuc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = int.Parse(grvMauBienMuc.DataKeys[e.RowIndex][0].ToString());
        pMauBienMuc_ChiTietInfo.ID = ID;
        try
        {
            oBMauBienMuc_ChiTiet.Delete(pMauBienMuc_ChiTietInfo);
            GetDuLieu();
        }
        catch (Exception exp)
        {
            ThongBao("Dữ liệu đang dùng không thể xóa!");
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript'>self.location.href='MauBienMucIndex.aspx?TaoMauBM=1';</script>");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        pMauBienMucInfo.Ten = txtTenMauBienMuc.Text.Trim();
        pMauBienMucInfo.IDNguoiDung = int.Parse(Session["TaiKhoanID"].ToString());

        pMauBienMucInfo.NgaySuaCuoi = DateTime.Now;
        pMauBienMucInfo.NgayTao = DateTime.Now;
        pMauBienMucInfo.MauBienMucID = int.Parse("0" + Request["MauBienMucID"].ToString());
        oBMauBienMuc.Update(pMauBienMucInfo);
        ThongBao("Cập nhật tên mẫu biên mục thành công!");
        WriteLog(lstChucNang[0].ChucNangID, "Sửa thông tin biên mục: +"+pMauBienMucInfo.Ten, Request.UserHostAddress, Session["TenDangNhap"].ToString());
    }
}
