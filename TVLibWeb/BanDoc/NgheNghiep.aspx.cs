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

public partial class BanDoc_NgheNghiep : WebBase 
{

    NgheNghiepInfo oNgheNghiepInfo;
    cBNgheNghiep oBNgheNghiep;
    DataTable dtTemp;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",22,") >= 0)
        {
            oNgheNghiepInfo = new NgheNghiepInfo();
            oBNgheNghiep = new cBNgheNghiep();
            BindJS();
            oChucNang.MaChucNang = "QuanLyDanhMuc_BanDoc";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            if (!IsPostBack)
            {
                GetDuLieu();
                GetDropDownList();
            }
        }
        else
            Response.Redirect("../Error.aspx");

    }
    private void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "JSAdminCommon", "<script language='javascript' src='../Resources/JS/BanDoc.js'></script>");
        string strJSCheckMerge = "if(!CheckOptionsNull('ctl00_ContentPlaceHolder1_grvNgheNghiep', 'chkSelect', 2, 100, 'Bạn phải chọn ít nhất một tỉnh (thành phố) để gộp!')) return false;";
        string strJSConfirm = "return ConfirmMerger('Bạn có chắc chắn muốn gộp tỉnh (thành phố)!');";
        btnMerger.Attributes.Add("onClick", strJSCheckMerge + " else " + strJSConfirm);
        btnAdd.Attributes.Add("OnClick", "return CheckAddNgheNghiep();");
    }

    // load data in Gridview
    private void GetDropDownList()
    {

        drdlNgheNghiep.DataSource = dtTemp.Copy();
        drdlNgheNghiep.DataTextField = "TenNgheNghiep";
        drdlNgheNghiep.DataValueField = "NgheNghiepID";
        drdlNgheNghiep.DataBind();
    }

    // load data in Gridview
    private void GetDuLieu()
    {
        oNgheNghiepInfo.NgheNghiepID = 0;
        dtTemp = oBNgheNghiep.Get(oNgheNghiepInfo);
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                grvNgheNghiep.DataSource = dtTemp;
                grvNgheNghiep.DataBind();
            }
        }
    }
    private void GopNgheNghiep(int intNgheNghiepID, int intNgheNghiepIDGop)
    {
        oNgheNghiepInfo.NgheNghiepID = intNgheNghiepID;
        oBNgheNghiep.GopNgheNghiep(oNgheNghiepInfo, intNgheNghiepIDGop);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        oNgheNghiepInfo.TenNgheNghiep = txtDescription.Text.Trim();
        int intKetQua = oBNgheNghiep.Add(oNgheNghiepInfo);
        if (intKetQua == 0)
        {
            // ' message  successful
            ThongBao("Thêm mới danh mục nghề nghiệp thành công! ");
            WriteLog(lstChucNang[0].ChucNangID, "Thêm mới danh mục nghề nghiệp thành công : " + txtDescription.Text.Trim(), Request.UserHostAddress, Session["TenDangNhap"].ToString());
            txtDescription.Text = "";
        }
        else if (intKetQua >= 1)
        {
            // message  error
            ThongBao("Danh mục nghề nghiệp đã tồn tại!");
        }
        GetDuLieu();
        GetDropDownList();
    }
    protected void btnMerger_Click(object sender, EventArgs e)
    {
        CheckBox chk = null;
        Int32 intRet = 0;
        Int32 intDem = 0;
        // check event checked of checkboxs
        for (Int32 inti = 0; inti < grvNgheNghiep.Rows.Count; inti++)
        {
            chk = new CheckBox();
            chk = (CheckBox)(grvNgheNghiep.Rows[inti].FindControl("chkSelect"));
            if (chk.Checked == true)
            {
                intDem = intDem + 1;
                if (int.Parse(grvNgheNghiep.DataKeys[inti][0].ToString()) != int.Parse(drdlNgheNghiep.SelectedValue))
                {
                    GopNgheNghiep(int.Parse(grvNgheNghiep.DataKeys[inti][0].ToString()), int.Parse(drdlNgheNghiep.SelectedValue.ToString()));
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
            ThongBao("Gôp danh mục nghề nghiệp thành công!");
            WriteLog(lstChucNang[0].ChucNangID, "Gôp danh mục nghề nghiệp thành công : ", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else
        {
            ThongBao("Gộp danh mục nghề nghiệp thành công!");
        }
        GetDuLieu();
        GetDropDownList();
    }
    protected void grvNgheNghiep_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (((TextBox)(grvNgheNghiep.Rows[e.RowIndex].FindControl("txtgrvNgheNghiep"))).Text != "")
        {
            oNgheNghiepInfo.TenNgheNghiep = ((TextBox)(grvNgheNghiep.Rows[e.RowIndex].FindControl("txtgrvNgheNghiep"))).Text;
            oNgheNghiepInfo.NgheNghiepID = int.Parse(grvNgheNghiep.DataKeys[e.RowIndex][0].ToString());
            int intKetQua = oBNgheNghiep.Update(oNgheNghiepInfo);
            if (intKetQua == 0)
            {
                // ' message  successful
                ThongBao("Sửa danh mục nghề nghiệp  thành công! ");
                WriteLog(lstChucNang[0].ChucNangID, "Sửa danh mục nghề nghiệp thành công : " + oNgheNghiepInfo.TenNgheNghiep , Request.UserHostAddress, Session["TenDangNhap"].ToString());
            }
            else if (intKetQua >= 1)
            {
                // message  error
                ThongBao("Danh mục nghề nghiệp đã tồn tại !");
            }
            grvNgheNghiep.EditIndex = -1;
            GetDuLieu();
            GetDropDownList();
        }
    }
    protected void grvNgheNghiep_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvNgheNghiep.EditIndex = -1;
        GetDuLieu();
    }
    protected void grvNgheNghiep_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvNgheNghiep.EditIndex = e.NewEditIndex;
        GetDuLieu();
    }
    protected void grvNgheNghiep_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvNgheNghiep.EditIndex = e.NewPageIndex;
        GetDuLieu();
    }
}
