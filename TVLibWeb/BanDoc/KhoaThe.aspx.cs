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


public partial class BanDoc_KhoaThe : WebBase 
{
    BanDoc_KhoaTheInfo oBanDoc_KhoaTheInfo;
    cBBanDoc_KhoaThe oBBanDoc_KhoaTheInfo;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",17,") >= 0)
        {
            BindJS();
            oBanDoc_KhoaTheInfo = new BanDoc_KhoaTheInfo();
            oBBanDoc_KhoaTheInfo = new cBBanDoc_KhoaThe();
            oChucNang.MaChucNang = "KhoaTheBanDoc";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            if (!IsPostBack)
            {
                LayDuLieu();
            }
        }
        else
            Response.Redirect("../Error.aspx");
    }
    private void BindJS()
    {
        txtNgayBatDau.Text = DateTime.Parse(DateTime.Now.ToString()).ToString("dd/MM/yyyy");
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "JSAdminCommon", "<script language='javascript' src='../Resources/JS/BanDoc.js'></script>");
        btnDelete.Attributes.Add("OnClick", "if(!CheckOptionsNull('ctl00_ContentPlaceHolder1_grvKhoaThe', 'chkID', 2, 50, 'Bạn phải chọn ít nhất một thẻ bạn đọc để mở khoá!')) return false;");
        btnKhoa.Attributes.Add("Onclick", "return CheckKhoaThe();");
    }
    private void LayDuLieu()
    {
        oBanDoc_KhoaTheInfo.BanDocID = 0;
       DataTable dtTemp = oBBanDoc_KhoaTheInfo.Get(oBanDoc_KhoaTheInfo);
       if (dtTemp != null)
       {
           grvKhoaThe.DataSource = dtTemp;
           grvKhoaThe.DataBind();
           btnDelete.Visible = true;
           if (dtTemp.Rows.Count == 0)
           {
               btnDelete.Visible = false;
           }
       }
       else
       {
           btnDelete.Visible = false;
       }
    }
    protected void btnKhoa_Click(object sender, EventArgs e)
    {
        
        oBanDoc_KhoaTheInfo.NgayBatDau = TVDateTime.ChuyenVietSangAnh(txtNgayBatDau.Text.Trim());
        oBanDoc_KhoaTheInfo.SoNgay = int.Parse(txtSoNgay.Text.Trim());
        oBanDoc_KhoaTheInfo.GhiChu = txtGhiChu.Text.Trim();
        int intKetQua = oBBanDoc_KhoaTheInfo.Add(oBanDoc_KhoaTheInfo, txtSoThe.Text.Trim());
        if (intKetQua == 0)
        {
            WriteLog(lstChucNang[0].ChucNangID, "Khóa thẻ  bạn đọc thành công : " + txtSoThe.Text, Request.UserHostAddress, Session["TenDangNhap"].ToString());
            ThongBao("Khoá thẻ thành công!");
            LayDuLieu();
        }
        else
        {
            ThongBao("Thẻ không tồn tại!");
        }
    }
    protected void grvKhoaThe_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvKhoaThe.EditIndex = e.NewEditIndex;
        LayDuLieu();
    }
    protected void grvKhoaThe_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvKhoaThe.EditIndex = -1;
        LayDuLieu();
    }
    protected void MoTheBanDoc(int intBanDocID)
    {
        oBanDoc_KhoaTheInfo.BanDocID = intBanDocID;
        oBBanDoc_KhoaTheInfo.Delete(oBanDoc_KhoaTheInfo);
        WriteLog(lstChucNang[0].ChucNangID, "Mở thẻ bạn đọc thành công", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        ThongBao("Mở thẻ bạn đọc thành công!");
        
    }
    protected void grvKhoaThe_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if ( TVDateTime.KiemTraNgayThang(((TextBox)(grvKhoaThe.Rows[e.RowIndex].FindControl("txtgrvNgayBatDau"))).Text.Trim(),"") == true )
        {
            oBanDoc_KhoaTheInfo.NgayBatDau = TVDateTime.ChuyenVietSangAnh(((TextBox)(grvKhoaThe.Rows[e.RowIndex].FindControl("txtgrvNgayBatDau"))).Text.Trim());
            oBanDoc_KhoaTheInfo.SoNgay = int.Parse(((TextBox)(grvKhoaThe.Rows[e.RowIndex].FindControl("txtgrvSoNgay"))).Text.Trim());
            oBanDoc_KhoaTheInfo.GhiChu = ((TextBox)(grvKhoaThe.Rows[e.RowIndex].FindControl("txtgrvGhiChu"))).Text.Trim();
            oBanDoc_KhoaTheInfo.BanDocID = int.Parse(grvKhoaThe.DataKeys[e.RowIndex][0].ToString());
            oBBanDoc_KhoaTheInfo.Update(oBanDoc_KhoaTheInfo);
            ThongBao("Cập nhật thành công!");
            grvKhoaThe.EditIndex = -1;
            LayDuLieu();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CheckBox chk = null;       
        // check event checked of checkboxs
        for (Int32 inti = 0; inti < grvKhoaThe.Rows.Count; inti++)
        {
            chk = new CheckBox();
            chk = (CheckBox)(grvKhoaThe.Rows[inti].FindControl("chkID"));
            if (chk.Checked == true)
            {
                MoTheBanDoc(int.Parse(grvKhoaThe.DataKeys[inti][0].ToString()));
                
            }
            
        }
        LayDuLieu();
    }
}
