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

public partial class BoSungBienMuc_Kho_ThuVien : WebBase 
{
    ThuVienInfo oThuVienInfo;
    cBThuVien oBThuVien;
    DataTable dtTemp;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, System.EventArgs e)
    {
        oThuVienInfo = new ThuVienInfo();
        oBThuVien = new cBThuVien();
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
        btnAdd.Attributes.Add("OnClick", "return CheckAddThuVien();");
        string strJSCheckMerge = "if(!CheckOptionsNull('ctl00_ContentPlaceHolder1_grvThuVien', 'chkSelect', 2, 100, 'Bạn phải chọn ít nhất một thư viện để gộp!')) return false;";
        string strJSConfirm = "return ConfirmMerger('Bạn có chắc chắn muốn gộp thư viện!');";
        btnMerger.Attributes.Add("onClick", strJSCheckMerge + " else " + strJSConfirm);
      
        btnCancel.Attributes.Add("Onclick","document.forms[0].reset(); return false;");
    }

    // load data in Gridview
    private void GetDropDownList()
    {

        drdlThuVien.DataSource = dtTemp.Copy();
        drdlThuVien.DataTextField = "TenThuVien";
        drdlThuVien.DataValueField = "ThuVienID";
        drdlThuVien.DataBind();
    }

    // load data in Gridview
    private void GetDuLieu()
    {
        oThuVienInfo.ThuVienID = 0;
        dtTemp = oBThuVien.Get(oThuVienInfo);
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                grvThuVien.DataSource = dtTemp;
                grvThuVien.DataBind();
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        oThuVienInfo.TenThuVien = txtTenThuVien.Text.Trim();
        oThuVienInfo.MaThuVien = txtMaThuVien.Text.Trim();
        int intKetQua = oBThuVien.Add(oThuVienInfo);
        if (intKetQua == 0)
        {
            // ' message  successful
            ThongBao("Thêm mới thư viện thành công! ");
            txtTenThuVien.Text = "";
            txtMaThuVien.Text = "";
            WriteLog(lstChucNang[0].ChucNangID, "Thêm mới thư viện : "+txtTenThuVien.Text, Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else if (intKetQua >= 1)
        {
            // message  error
            ThongBao("Mã thư viện này đã tồn tại!");
        }
        GetDuLieu();
        GetDropDownList();
    }
    private void GopThuVien(int intThuVienID, int intThuVienIDGop)
    {
        oThuVienInfo.ThuVienID = intThuVienID;
        oBThuVien.GopThuVien(oThuVienInfo, intThuVienIDGop);
    }

    protected void grvThuVien_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvThuVien.EditIndex = -1;
        GetDuLieu();
    }
    protected void grvThuVien_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        oThuVienInfo.TenThuVien = ((TextBox)(grvThuVien.Rows[e.RowIndex].FindControl("txtgrvTenThuVien"))).Text;
        oThuVienInfo.MaThuVien = ((TextBox)(grvThuVien.Rows[e.RowIndex].FindControl("txtgrvMaThuVien"))).Text;
        oThuVienInfo.ThuVienID = int.Parse(grvThuVien.DataKeys[e.RowIndex][0].ToString());
        int intKetQua = oBThuVien.Update(oThuVienInfo);
        if (intKetQua == 0)
        {
            // ' message  successful
            ThongBao("Cập nhật thư viện thành công! ");
            WriteLog(lstChucNang[0].ChucNangID, "Sửa thông tin thư viện: "+oThuVienInfo.TenThuVien, Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else if (intKetQua >= 1)
        {
            // message  error
            ThongBao("Mã thư viện này đã tồn tại!");
        }
        grvThuVien.EditIndex = -1;
        GetDuLieu();
        GetDropDownList();
    }
    protected void grvThuVien_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvThuVien.EditIndex = e.NewEditIndex;
        GetDuLieu();
    }
   
    protected void grvThuVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvThuVien.EditIndex = e.NewPageIndex;
        GetDuLieu();
    }
    protected void btnMerger_Click(object sender, EventArgs e)
    {
        CheckBox chk = null;
        Int32 intRet = 0;
        Int32 intDem = 0;
        // check event checked of checkboxs
        for (Int32 inti = 0; inti < grvThuVien.Rows.Count; inti++)
        {
            chk = new CheckBox();
            chk = (CheckBox)(grvThuVien.Rows[inti].FindControl("chkSelect"));
            if (chk.Checked == true)
            {
                intDem = intDem + 1;
                if (int.Parse(grvThuVien.DataKeys[inti][0].ToString()) != int.Parse(drdlThuVien.SelectedValue))
                {
                    GopThuVien(int.Parse(grvThuVien.DataKeys[inti][0].ToString()), int.Parse(drdlThuVien.SelectedValue.ToString()));
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
            ThongBao("Gộp thư viện thành công!");
            WriteLog(lstChucNang[0].ChucNangID, "Gộp thư viện", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else
        {
            ThongBao("Gộp thư viện không thành công!");
        }
        GetDuLieu();
        GetDropDownList();
    }
}
