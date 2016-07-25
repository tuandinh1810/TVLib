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

public partial class BoSungBienMuc_Kho_Kho : WebBase 
{
    KhoInfo oKhoInfo;
    cBKho oBKho;
    ThuVienInfo oThuVienInfo;
    cBThuVien oBThuVien;
    DataTable dtTemp;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, System.EventArgs e)
    {
        oKhoInfo = new KhoInfo();
        oBKho = new cBKho();
        oThuVienInfo = new ThuVienInfo();
        oBThuVien = new cBThuVien();
        BindJS();
        oChucNang.MaChucNang = "QuanLyDanhMuc_BienMuc";
        lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
        if (!IsPostBack)
        {
            
            GetThuVien();
            GetDuLieu();
            GetDropDownList();
        }

    }
    private void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "JSAdminCommon", "<script language='javascript' src='../../Resources/JS/Kho.js'></script>");
        btnAdd.Attributes.Add("OnClick", "return CheckAddKho();");
        string strJSCheckMerge = "if(!CheckOptionsNull('ctl00_ContentPlaceHolder1_grvKho', 'chkSelect', 2, 100, 'Bạn phải chọn ít nhất một Kho để gộp!')) return false;";
        string strJSConfirm = "return ConfirmMerger('Bạn có chắc chắn muốn gộp Kho!');";
        btnMerger.Attributes.Add("onClick", strJSCheckMerge + " else " + strJSConfirm);

        btnCancel.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
    }

    private void GetThuVien()
    {
        oThuVienInfo.ThuVienID = 0;
        DataTable dtThuVien = oBThuVien.Get(oThuVienInfo);
        drdlThuVien.DataSource = dtThuVien;
        drdlThuVien.DataTextField = "TenThuVien";
        drdlThuVien.DataValueField = "ThuVienID";
        drdlThuVien.DataBind();
    }

    // load data in Gridview
    private void GetDropDownList()
    {

        drdlKho.DataSource = dtTemp.Copy();
        drdlKho.DataTextField = "TenKho";
        drdlKho.DataValueField = "KhoID";
        drdlKho.DataBind();
    }

    // load data in Gridview
    private void GetDuLieu()
    {
        oKhoInfo.IDThuVien = int.Parse (drdlThuVien.SelectedValue);
        dtTemp = oBKho.GetByThuVien(oKhoInfo);
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                grvKho.DataSource = dtTemp;
                grvKho.DataBind();
            }
            else
            {
                grvKho.DataSource = null;
                grvKho.DataBind();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        oKhoInfo.TenKho = txtTenKho.Text.Trim();
        oKhoInfo.MaKho = txtMaKho.Text.Trim();
        oKhoInfo.IDThuVien = int.Parse(drdlThuVien.SelectedValue);
        int intKetQua = oBKho.Add(oKhoInfo);
        if (intKetQua == 0)
        {
            // ' message  successful
            ThongBao("Thêm mới Kho thành công! ");
            txtTenKho.Text = "";
            txtMaKho.Text = "";
            WriteLog(lstChucNang[0].ChucNangID, "Thêm mới kho: "+txtTenKho.Text, Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else if (intKetQua >= 1)
        {
            // message  error
            ThongBao("Mã Kho này đã tồn tại!");
        }
        GetDuLieu();
        GetDropDownList();
    }
    private void GopKho(int intKhoID, int intKhoIDGop)
    {
        oKhoInfo.KhoID = intKhoID;
        oBKho.GopKho(oKhoInfo, intKhoIDGop);
    }

    protected void grvKho_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvKho.EditIndex = -1;
        GetDuLieu();
    }
    protected void grvKho_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        oKhoInfo.TenKho = ((TextBox)(grvKho.Rows[e.RowIndex].FindControl("txtgrvTenKho"))).Text;
        oKhoInfo.MaKho = ((TextBox)(grvKho.Rows[e.RowIndex].FindControl("txtgrvMaKho"))).Text;
        oKhoInfo.STTMGX = int.Parse(((TextBox)(grvKho.Rows[e.RowIndex].FindControl("txtgrvSTTMXG"))).Text);
        oKhoInfo.KhoID = int.Parse(grvKho.DataKeys[e.RowIndex][0].ToString());
        oKhoInfo.IDThuVien = int.Parse(drdlThuVien.SelectedValue);
        int intKetQua = oBKho.Update(oKhoInfo);
        if (intKetQua == 0)
        {
            // ' message  successful
            ThongBao("Cập nhật Kho thành công! ");
            WriteLog(lstChucNang[0].ChucNangID, "Sửa thông tin kho: "+oKhoInfo.TenKho, Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else if (intKetQua >= 1)
        {
            // message  error
            ThongBao("Mã Kho này đã tồn tại!");
        }
        grvKho.EditIndex = -1;
        GetDuLieu();
        GetDropDownList();
    }
    protected void grvKho_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvKho.EditIndex = e.NewEditIndex;
        GetDuLieu();
    }

    protected void grvKho_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvKho.EditIndex = e.NewPageIndex;
        GetDuLieu();
    }
    protected void btnMerger_Click(object sender, EventArgs e)
    {
        CheckBox chk = null;
        Int32 intRet = 0;
        Int32 intDem = 0;
        // check event checked of checkboxs
        for (Int32 inti = 0; inti < grvKho.Rows.Count; inti++)
        {
            chk = new CheckBox();
            chk = (CheckBox)(grvKho.Rows[inti].FindControl("chkSelect"));
            if (chk.Checked == true)
            {
                intDem = intDem + 1;
                if (int.Parse(grvKho.DataKeys[inti][0].ToString()) != int.Parse(drdlKho.SelectedValue))
                {
                    GopKho(int.Parse(grvKho.DataKeys[inti][0].ToString()), int.Parse(drdlKho.SelectedValue.ToString()));
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
            ThongBao("Gộp Kho thành công!");
            WriteLog(lstChucNang[0].ChucNangID, "Gộp kho ", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else
        {
            ThongBao("Gộp Kho không thành công!");
        }
        GetDuLieu();
        GetDropDownList();
    }
    protected void drdlThuVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDuLieu();
        GetDropDownList();
    }
}
