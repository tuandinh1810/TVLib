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

public partial class BanDoc_Tinh : WebBase
{
    TinhInfo oTinhInfo;
    cBTinh oBTinh;
    DataTable dtTemp;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",22,") >= 0)
        {
            oTinhInfo = new TinhInfo();
            oBTinh = new cBTinh();
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
        string strJSCheckMerge = "if(!CheckOptionsNull('ctl00_ContentPlaceHolder1_grvTinh', 'chkSelect', 2, 100, 'Bạn phải chọn ít nhất một tỉnh (thành phố) để gộp!')) return false;";
        string strJSConfirm = "return ConfirmMerger('Bạn có chắc chắn muốn gộp tỉnh (thành phố)!');";
        btnMerger.Attributes.Add("onClick", strJSCheckMerge + " else " + strJSConfirm);
        btnAdd.Attributes.Add("OnClick", "return CheckAddTinh();");
    }

    // load data in Gridview
    private void GetDropDownList()
    {

        drdlTinh.DataSource = dtTemp.Copy();
        drdlTinh.DataTextField = "TenTinh";
        drdlTinh.DataValueField = "TinhID";
        drdlTinh.DataBind();
    }

    // load data in Gridview
    private void GetDuLieu()
    {
        oTinhInfo.TinhID = 0;
        dtTemp = oBTinh.Get(oTinhInfo);
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                grvTinh.DataSource = dtTemp;
                grvTinh.DataBind();
            }
        }
    }


    protected void btnAdd_Click(object sender, System.EventArgs e)
    {
        oTinhInfo.TenTinh = txtDescription.Text.Trim();
        int intKetQua = oBTinh.Add(oTinhInfo);
        if (intKetQua == 0)
        {
            // ' message  successful
            ThongBao("Thêm mới tỉnh(thành phố) thành công! ");
            WriteLog(lstChucNang[0].ChucNangID, "Thêm mới tỉnh (thành phố thành công) : " + oTinhInfo.TenTinh, Request.UserHostAddress, Session["TenDangNhap"].ToString());
            txtDescription.Text = "";
        }
        else if (intKetQua >= 1)
        {
            // message  error
          ThongBao("Tên tỉnh(thành phố) này đã tồn tại!");
        }
        GetDuLieu();
       GetDropDownList();
    }


    private void GopTinh(int intTinhID, int intTinhIDGop)
    {
        oTinhInfo.TinhID = intTinhID;
        oBTinh.GopTinh(oTinhInfo, intTinhIDGop);        
    }

    //protected void grvTinh_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    ////{
    ////    switch (e.Row.RowType)
    ////    {
    ////        case ListItemType.Item:
    ////        case ListItemType.AlternatingItem:
    ////        case ListItemType.EditItem:
    ////            LinkButton lnkbtnUp = null;
    ////            int iID = 0;
    ////            lnkbtnUp = (LinkButton)(e.Row.FindControl("lnkbtnUpdate"));
    ////            if (lnkbtnUp != null)
    ////            {
    ////                lnkbtnUp.Attributes.Add("OnClick", "javascript:return(CheckUpdate('" + DataBinder.Eval(e.Row.DataItem, "ProvinceID") + "',document.getElementById('ctl00_content_grvProvinces_ctl" + System.Convert.ToString(e.Row.RowIndex + 2).PadLeft(2, "0") + "_txtgrvProvince'),document.getElementById('ctl00_content_ddlProvinces'),'" + ddlLabel.Items[6].Text + "','" + ddlLabel.Items[8].Text + "','" + ddlLabel.Items[7].Text + "'));");
    ////            }
    ////            LinkButton lnkbtnEdit = null;
    ////            lnkbtnEdit = (LinkButton)(e.Row.FindControl("lnkbtnCancel"));
    ////            if (lnkbtnEdit != null)
    ////            {
    ////                lnkbtnEdit.Attributes.Add("OnClick", "javascript:return(CheckCancel(document.getElementById('ctl00_content_grvProvinces_ctl" + System.Convert.ToString(e.Row.RowIndex + 2).PadLeft(2, "0") + "_txtgrvProvince')))");
    ////            }
    ////            break;
    ////    }
    //}
    protected void grvTinh_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
    {
        grvTinh.EditIndex = -1;
        GetDuLieu();
    }
    protected void grvTinh_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {
        if (((TextBox)(grvTinh.Rows[e.RowIndex].FindControl("txtgrvTenTinh"))).Text.Trim() != "")
        {
            oTinhInfo.TenTinh = ((TextBox)(grvTinh.Rows[e.RowIndex].FindControl("txtgrvTenTinh"))).Text;
            oTinhInfo.TinhID = int.Parse(grvTinh.DataKeys[e.RowIndex][0].ToString());
            int intKetQua = oBTinh.Update(oTinhInfo);
            if (intKetQua == 0)
            {
                // ' message  successful
                ThongBao("Cập nhật tỉnh(thành phố) thành công! ");
                WriteLog(lstChucNang[0].ChucNangID, "Sửa danh mục  tỉnh(thành phố thành công) : " + oTinhInfo.TenTinh, Request.UserHostAddress, Session["TenDangNhap"].ToString());
            }
            else if (intKetQua >= 1)
            {
                // message  error
                ThongBao("Tên tỉnh(thành phố) này đã tồn tại!");
            }
            grvTinh.EditIndex = -1;
            GetDuLieu();
            GetDropDownList();
        }
    }
    protected void grvTinh_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        grvTinh.EditIndex = e.NewEditIndex;
        GetDuLieu();
    }
    protected void btnMerger_Click1(object sender, EventArgs e)
    {

        CheckBox chk = null;
        Int32 intRet = 0;
        Int32 intDem = 0;
        // check event checked of checkboxs
        for (Int32 inti = 0; inti < grvTinh.Rows.Count; inti++)
        {
            chk = new CheckBox();
            chk = (CheckBox)(grvTinh.Rows[inti].FindControl("chkSelect"));
            if (chk.Checked == true)
            {
                intDem = intDem + 1;
                if (int.Parse(grvTinh.DataKeys[inti][0].ToString()) != int.Parse(drdlTinh.SelectedValue))
                {
                    GopTinh(int.Parse(grvTinh.DataKeys[inti][0].ToString()), int.Parse(drdlTinh.SelectedValue.ToString()));
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
            ThongBao("Gộp tỉnh (thành phố) thành công!");
            WriteLog(lstChucNang[0].ChucNangID, "Gộp tỉnh(thành phố thành công) : ", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else
        {
            ThongBao("Gộp tỉnh (thành phố) không thành công!");
        }
        GetDuLieu();
        GetDropDownList();
    }
    protected void grvTinh_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTinh.EditIndex = e.NewPageIndex;
        GetDuLieu();
    }
}
