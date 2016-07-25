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

public partial class BoSungBienMuc_DM_LyDoThanhLy : WebBase 
{
    XepGia_LyDoThanhLyInfo oXepGia_LyDoThanhLyInfo;
    cBXepGia_LyDoThanhLy oBXepGia_LyDoThanhLy;
    DataTable dtTemp;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, System.EventArgs e)
    {
        oXepGia_LyDoThanhLyInfo = new XepGia_LyDoThanhLyInfo();
        oBXepGia_LyDoThanhLy = new cBXepGia_LyDoThanhLy();
        BindJS();
        oChucNang.MaChucNang = "QuanLyDanhMuc_BienMuc";
        lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
        if (!IsPostBack)
        {
            GetDuLieu();
        }

    }
    private void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../../Resources/Js/TVLib.js'></script>");
        btnCancel.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
    }
    // load data in Gridview
    private void GetDuLieu()
    {
        oXepGia_LyDoThanhLyInfo.LyDoID  = 0;
        dtTemp = oBXepGia_LyDoThanhLy.Get(oXepGia_LyDoThanhLyInfo);
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                grvLyDo.DataSource = dtTemp;
                grvLyDo.DataBind();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtNoiDungLydo.Text.Trim() != "")
        {
            oXepGia_LyDoThanhLyInfo.NoiDungLyDo = txtNoiDungLydo.Text.Trim();
            int intKetQua = oBXepGia_LyDoThanhLy.Add(oXepGia_LyDoThanhLyInfo);
            // ' message  successful
            ThongBao("Thêm mới thành công! ");
            txtNoiDungLydo.Text = "";
            GetDuLieu();
            WriteLog(lstChucNang[0].ChucNangID, "Thêm mới danh mục lý do: " + txtNoiDungLydo.Text, Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else
            ThongBao("Bạn chưa điền đầy đủ thông tin!");
    }
    protected void grvLyDo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvLyDo.EditIndex = -1;
        GetDuLieu();
    }
    protected void grvLyDo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        oXepGia_LyDoThanhLyInfo.NoiDungLyDo = ((TextBox)(grvLyDo.Rows[e.RowIndex].FindControl("txtgrvNoiDungLyDo"))).Text;
        oXepGia_LyDoThanhLyInfo.LyDoID = int.Parse(grvLyDo.DataKeys[e.RowIndex][0].ToString());
        oBXepGia_LyDoThanhLy.Update(oXepGia_LyDoThanhLyInfo);
        WriteLog(lstChucNang[0].ChucNangID, "Sửa danh mục lý do: " + oXepGia_LyDoThanhLyInfo.NoiDungLyDo, Request.UserHostAddress, Session["TenDangNhap"].ToString());
        // ' message  successful
         ThongBao("Cập nhật thành công! ");
      
        grvLyDo.EditIndex = -1;
        GetDuLieu();
    }
    protected void grvLyDo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvLyDo.EditIndex = e.NewEditIndex;
        GetDuLieu();
    }

    protected void grvLyDo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvLyDo.EditIndex = e.NewPageIndex;
        GetDuLieu();
    }
    protected void grvLyDo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        oXepGia_LyDoThanhLyInfo.LyDoID = int.Parse(grvLyDo.DataKeys[e.RowIndex][0].ToString());
        try 
        {
            oBXepGia_LyDoThanhLy.Delete(oXepGia_LyDoThanhLyInfo);
            ThongBao("Xóa thành công!");
            WriteLog(lstChucNang[0].ChucNangID, "Gộp danh mục lý do: " + oXepGia_LyDoThanhLyInfo.NoiDungLyDo, Request.UserHostAddress, Session["TenDangNhap"].ToString());
            GetDuLieu();
        }
       catch (Exception ex)
        {
            ThongBao("Dữ liệu đang dùng không thể xóa!");
       }
    }
}
