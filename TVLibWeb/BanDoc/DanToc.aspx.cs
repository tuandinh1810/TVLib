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

public partial class BanDoc_DanToc : WebBase 
{
    DanTocInfo oDanTocInfo;
    cBDanToc oBDanToc;
    DataTable dtTemp;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",22,") >= 0)
        {
            oDanTocInfo = new DanTocInfo();
            oBDanToc = new cBDanToc();
            oChucNang.MaChucNang = "QuanLyDanhMuc_BanDoc";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            BindJS();
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
        string strJSCheckMerge = "if(!CheckOptionsNull('grvDanToc', 'chkSelect', 2, 100, 'Bạn phải chọn ít nhất một dân tộc để gộp!')) return false;";
        string strJSConfirm = "return ConfirmMerger('Bạn có chắc chắn muốn gộp dân tộc!');";
        btnMerger.Attributes.Add("onClick", strJSCheckMerge + " else " + strJSConfirm);
        btnAdd.Attributes.Add("OnClick", "return CheckAddDanToc();");
    }

    // load data in Gridview
    private void GetDropDownList()
    {

        drdlDanToc.DataSource = dtTemp.Copy();
        drdlDanToc.DataTextField = "DanToc";
        drdlDanToc.DataValueField = "DanTocID";
        drdlDanToc.DataBind();
    }

    // load data in Gridview
    private void GetDuLieu()
    {
        oDanTocInfo.DanTocID = 0;
        dtTemp = oBDanToc.Get(oDanTocInfo);
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                grvDanToc.DataSource = dtTemp;
                grvDanToc.DataBind();
            }
        }
    }
    private void GopDanToc(int intDanTocID, int intDanTocIDGop)
    {
        oDanTocInfo.DanTocID = intDanTocID;
        oBDanToc.GopDanToc(oDanTocInfo, intDanTocIDGop);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        oDanTocInfo.DanToc  = txtDescription.Text.Trim();
        int intKetQua = oBDanToc.Add(oDanTocInfo);
        if (intKetQua == 0)
        {
            // ' message  successful
            WriteLog(lstChucNang[0].ChucNangID, "Thêm mới danh mục dân tộc thành công : " + txtDescription.Text, Request.UserHostAddress, Session["TenDangNhap"].ToString());
            ThongBao("Thêm mới dân tộc thành công! ");
            txtDescription.Text = "";
        }
        else if (intKetQua >= 1)
        {
            // message  error
            ThongBao("Tên dân tộc đã tồn tại!");
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
        for (Int32 inti = 0; inti < grvDanToc.Rows.Count; inti++)
        {
            chk = new CheckBox();
            chk = (CheckBox)(grvDanToc.Rows[inti].FindControl("chkSelect"));
            if (chk.Checked == true)
            {
                intDem = intDem + 1;
                if (int.Parse(grvDanToc.DataKeys[inti][0].ToString()) != int.Parse(drdlDanToc.SelectedValue))
                {
                    GopDanToc(int.Parse(grvDanToc.DataKeys[inti][0].ToString()), int.Parse(drdlDanToc.SelectedValue.ToString()));
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
            ThongBao("Gộp dân tộc thành công!");
            WriteLog(lstChucNang[0].ChucNangID, "Gộp danh mục dân tộc thành công ", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else
        {
            ThongBao("Gộp dân tộc không thành công!");
        }
        GetDuLieu();
        GetDropDownList();
    }
    protected void grvDanToc_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (((TextBox)(grvDanToc.Rows[e.RowIndex].FindControl("txtgrvDanToc"))).Text != "")
        {
            oDanTocInfo.DanToc = ((TextBox)(grvDanToc.Rows[e.RowIndex].FindControl("txtgrvDanToc"))).Text;
            oDanTocInfo.DanTocID = int.Parse(grvDanToc.DataKeys[e.RowIndex][0].ToString());
            int intKetQua = oBDanToc.Update(oDanTocInfo);
            if (intKetQua == 0)
            {
                // ' message  successful
                WriteLog(lstChucNang[0].ChucNangID, "Sửa danh mục dân tộc thành công : "+oDanTocInfo.DanToc, Request.UserHostAddress, Session["TenDangNhap"].ToString());
                ThongBao("Cập nhật dân tộc thành công! ");
            }
            else if (intKetQua >= 1)
            {
                // message  error
                ThongBao("Tên dân tộc đã tồn tại!");
            }
            grvDanToc.EditIndex = -1;
            GetDuLieu();
            GetDropDownList();
        }
    }
    protected void grvDanToc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvDanToc.EditIndex = -1;
        GetDuLieu();
    }
    protected void grvDanToc_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvDanToc.EditIndex = e.NewEditIndex;
        GetDuLieu();
    }
    protected void grvDanToc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDanToc.EditIndex = e.NewPageIndex;
        GetDuLieu();
    }
}
