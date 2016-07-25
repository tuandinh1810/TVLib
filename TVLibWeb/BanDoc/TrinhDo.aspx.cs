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


public partial class BanDoc_TrinhDo : WebBase 
{
    TrinhDoInfo oTrinhDoInfo;
    cBTrinhDo oBTrinhDo;
    DataTable dtTemp;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",22,") >= 0)
        {
            oTrinhDoInfo = new TrinhDoInfo();
            oBTrinhDo = new cBTrinhDo();
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
        string strJSCheckMerge = "if(!CheckOptionsNull('ctl00_ContentPlaceHolder1_grvTrinhDo', 'chkSelect', 2, 100, 'Bạn phải chọn ít nhất một tỉnh (thành phố) để gộp!')) return false;";
        string strJSConfirm = "return ConfirmMerger('Bạn có chắc chắn muốn gộp trình độ !');";
        btnMerger.Attributes.Add("onClick", strJSCheckMerge + " else " + strJSConfirm);
        btnAdd.Attributes.Add("OnClick", "return CheckAddTrinhDo();");
    }

    // load data in Gridview
    private void GetDropDownList()
    {

        drdlTrinhDo.DataSource = dtTemp.Copy();
        drdlTrinhDo.DataTextField = "TrinhDo";
        drdlTrinhDo.DataValueField = "TrinhDoID";
        drdlTrinhDo.DataBind();
    }

    // load data in Gridview
    private void GetDuLieu()
    {
        oTrinhDoInfo.TrinhDoID = 0;
        dtTemp = oBTrinhDo.Get(oTrinhDoInfo);
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                grvTrinhDo.DataSource = dtTemp;
                grvTrinhDo.DataBind();
            }
        }
    }
    private void GopTrinhDo(int intTrinhDoID, int intTrinhDoIDGop)
    {
        oTrinhDoInfo.TrinhDoID = intTrinhDoID;
        oBTrinhDo.GopTrinhDo(oTrinhDoInfo, intTrinhDoIDGop);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        oTrinhDoInfo.TrinhDo = txtDescription.Text.Trim();
        int intKetQua = oBTrinhDo.Add(oTrinhDoInfo);
        if (intKetQua == 0)
        {
            // ' message  successful
            ThongBao("Thêm mới trình độ thành công! ");
            WriteLog(lstChucNang[0].ChucNangID, "Thêm mới danh mục trình độ thành công : " + oTrinhDoInfo.TrinhDo, Request.UserHostAddress, Session["TenDangNhap"].ToString());
            txtDescription.Text = "";
        }
        else if (intKetQua >= 1)
        {
            // message  error
            ThongBao("Tên trình độ đã tồn tại!");
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
        for (Int32 inti = 0; inti < grvTrinhDo.Rows.Count; inti++)
        {
            chk = new CheckBox();
            chk = (CheckBox)(grvTrinhDo.Rows[inti].FindControl("chkSelect"));
            if (chk.Checked == true)
            {
                intDem = intDem + 1;
                if (int.Parse(grvTrinhDo.DataKeys[inti][0].ToString()) != int.Parse(drdlTrinhDo.SelectedValue))
                {
                    GopTrinhDo(int.Parse(grvTrinhDo.DataKeys[inti][0].ToString()), int.Parse(drdlTrinhDo.SelectedValue.ToString()));
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
            ThongBao("Gộp trình độ thành công!");
        }
        else
        {
            ThongBao("Gộp trình độ không thành công!");
        }
        GetDuLieu();
        GetDropDownList();
    }
    protected void grvTrinhDo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (((TextBox)(grvTrinhDo.Rows[e.RowIndex].FindControl("txtgrvTrinhDo"))).Text.Trim() != "")
        {
            oTrinhDoInfo.TrinhDo = ((TextBox)(grvTrinhDo.Rows[e.RowIndex].FindControl("txtgrvTrinhDo"))).Text.Trim();
            oTrinhDoInfo.TrinhDoID = int.Parse(grvTrinhDo.DataKeys[e.RowIndex][0].ToString());
            int intKetQua = oBTrinhDo.Update(oTrinhDoInfo);
            if (intKetQua == 0)
            {
                // ' message  successful
                ThongBao("Cập nhật trình độ thành công! ");
                WriteLog(lstChucNang[0].ChucNangID, "Sửa danh mục trình độ thành công : " + oTrinhDoInfo.TrinhDo, Request.UserHostAddress, Session["TenDangNhap"].ToString());
            }
            else if (intKetQua >= 1)
            {
                // message  error
                ThongBao("Tên trình độ đã tồn tại!");
            }
            grvTrinhDo.EditIndex = -1;
            GetDuLieu();
            GetDropDownList();
        }
    }
    protected void grvTrinhDo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvTrinhDo.EditIndex = -1;
        GetDuLieu();
    }
    protected void grvTrinhDo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvTrinhDo.EditIndex = e.NewEditIndex;
        GetDuLieu();
    }
    protected void grvTrinhDo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTrinhDo.EditIndex = e.NewPageIndex;
        GetDuLieu();
    }
}
