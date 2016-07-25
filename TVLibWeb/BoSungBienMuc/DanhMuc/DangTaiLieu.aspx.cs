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

public partial class BoSungBienMuc_DanhMuc_DangTaiLieu :WebBase
{
   
    LoaiTaiLieuInfo oLoaiTaiLieuInfo;
    cBLoaiTaiLieu oBLoaiTaiLieu;
    DataTable dtTemp;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang=new List<ChucNangInfo>();
    protected void Page_Load(object sender, System.EventArgs e)
    {
        oLoaiTaiLieuInfo = new LoaiTaiLieuInfo();
        oBLoaiTaiLieu = new cBLoaiTaiLieu();
        BindJS();
        oChucNang.MaChucNang = "QuanLyDanhMuc_BienMuc";
        lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
        
        if (!IsPostBack)
        {
            GetDuLieu();
            GetDropDownList();
        }

    }
    private void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "JSAdminCommon", "<script language='javascript' src='../../Resources/JS/Kho.js'></script>");
        btnAdd.Attributes.Add("OnClick", "if(CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtMaLoaiTaiLieu,'Mã dạng tài liệu không được để trống!')== false){return false;}");

        string strJSCheckMerge = "if(!CheckOptionsNull('ctl00_ContentPlaceHolder1_grvLoaiTaiLieu', 'chkSelect', 2, 100, 'Bạn phải chọn ít nhất một dạng tài liệu để gộp!')) return false;";
        string strJSConfirm = "return ConfirmMerger('Bạn có chắc chắn muốn gộp dạng tài liệu!');";
        btnMerger.Attributes.Add("onClick", strJSCheckMerge + " else " + strJSConfirm);

        btnCancel.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
    }

    // load data in Gridview
    private void GetDropDownList()
    {

        drdlLoaiTaiLieu.DataSource = dtTemp.Copy();
        drdlLoaiTaiLieu.DataTextField = "TenLoaiTaiLieu";
        drdlLoaiTaiLieu.DataValueField = "LoaiTaiLieuID";
        drdlLoaiTaiLieu.DataBind();
    }

    // load data in Gridview
    private void GetDuLieu()
    {
        oLoaiTaiLieuInfo.LoaiTaiLieuID = 0;
        dtTemp = oBLoaiTaiLieu.Get(oLoaiTaiLieuInfo);
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                grvLoaiTaiLieu.DataSource = dtTemp;
                grvLoaiTaiLieu.DataBind();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        oLoaiTaiLieuInfo.MoTa = txtTenLoaiTaiLieu.Text.Trim();
        oLoaiTaiLieuInfo.TenLoaiTaiLieu= txtMaLoaiTaiLieu.Text.Trim();
        int intKetQua = oBLoaiTaiLieu.Add(oLoaiTaiLieuInfo);
        if (intKetQua == 0)
        {
            // ' message  successful
            ThongBao("Thêm mới dạng tài liệu thành công! ");
            txtTenLoaiTaiLieu.Text = "";
            txtMaLoaiTaiLieu.Text = "";
            WriteLog(lstChucNang[0].ChucNangID, "Thêm mới dạng tài liệu : " +txtTenLoaiTaiLieu.Text, Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else if (intKetQua >= 1)
        {
            // message  error
            ThongBao("Dạng tài liệu này đã tồn tại!");
        }
        GetDuLieu();
        GetDropDownList();
    }
    private void GopLoaiTaiLieu(int intLoaiTaiLieuID, int intLoaiTaiLieuIDGop)
    {
        oLoaiTaiLieuInfo.LoaiTaiLieuID = intLoaiTaiLieuID;
        oBLoaiTaiLieu.GopLoaiTaiLieu(oLoaiTaiLieuInfo, intLoaiTaiLieuIDGop);
    }

    protected void grvLoaiTaiLieu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvLoaiTaiLieu.EditIndex = -1;
        GetDuLieu();
    }
    protected void grvLoaiTaiLieu_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        oLoaiTaiLieuInfo.MoTa = ((TextBox)(grvLoaiTaiLieu.Rows[e.RowIndex].FindControl("txtgrvTenLoaiTaiLieu"))).Text;
        oLoaiTaiLieuInfo.TenLoaiTaiLieu = ((TextBox)(grvLoaiTaiLieu.Rows[e.RowIndex].FindControl("txtgrvMaLoaiTaiLieu"))).Text;
        oLoaiTaiLieuInfo.LoaiTaiLieuID = int.Parse(grvLoaiTaiLieu.DataKeys[e.RowIndex][0].ToString());
        int intKetQua = oBLoaiTaiLieu.Update(oLoaiTaiLieuInfo);
        if (intKetQua == 0)
        {
            // ' message  successful
            ThongBao("Cập nhật dạng tài liệu thành công! ");
            WriteLog(lstChucNang[0].ChucNangID, "Sửa dạng tài liệu : "+oLoaiTaiLieuInfo.TenLoaiTaiLieu, Request.UserHostAddress, Session["TenDangNhap"].ToString());
         
        }
        else if (intKetQua >= 1)
        {
            // message  error
            ThongBao("Dạng tài liệu này đã tồn tại!");
        }
        grvLoaiTaiLieu.EditIndex = -1;
        GetDuLieu();
        GetDropDownList();
    }
    protected void grvLoaiTaiLieu_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvLoaiTaiLieu.EditIndex = e.NewEditIndex;
        GetDuLieu();
    }

    protected void grvLoaiTaiLieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvLoaiTaiLieu.EditIndex = e.NewPageIndex;
        GetDuLieu();
    }
    protected void btnMerger_Click(object sender, EventArgs e)
    {
        CheckBox chk = null;
        Int32 intRet = 0;
        Int32 intDem = 0;
        // check event checked of checkboxs
        for (Int32 inti = 0; inti < grvLoaiTaiLieu.Rows.Count; inti++)
        {
            chk = new CheckBox();
            chk = (CheckBox)(grvLoaiTaiLieu.Rows[inti].FindControl("chkSelect"));
            if (chk.Checked == true)
            {
                intDem = intDem + 1;
                if (int.Parse(grvLoaiTaiLieu.DataKeys[inti][0].ToString()) != int.Parse(drdlLoaiTaiLieu.SelectedValue))
                {
                    GopLoaiTaiLieu(int.Parse(grvLoaiTaiLieu.DataKeys[inti][0].ToString()), int.Parse(drdlLoaiTaiLieu.SelectedValue.ToString()));
                }
                else
                {
                    intRet = 1;
                }
            }
        }
        if ((intRet == 1) & (intDem == 1))
        {
            // message  successful
            ThongBao("Gộp dạng tài liệu thành công!");
            WriteLog(lstChucNang[0].ChucNangID, "Gộp dạng tài liệu", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else
        {
            ThongBao("Gộp dạng tài liệu không thành công!");
        }
        GetDuLieu();
        GetDropDownList();
    }
}
