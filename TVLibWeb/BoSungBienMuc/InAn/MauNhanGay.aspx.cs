using System;
using System.Collections;
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

public partial class BoSungBienMuc_InAn_MauNhanGay : WebBase
{
    cBNhanGay oBNhanGay;
    NhanGayInfo pNhanGayInfo;
    DataTable dtData;
    protected void Page_Load(object sender, EventArgs e)
    {
        oBNhanGay = new cBNhanGay();
        pNhanGayInfo = new NhanGayInfo();
        BindJS();
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    private void BindJS()
    {
        Page.RegisterClientScriptBlock("Js", "<script language='javascript'src='../../Resources/Js/TVLib.js'  ></script>");
        Page.RegisterClientScriptBlock("Jsmenu", "<script language='javascript'src='../Js/InAn.js'  ></script>");
        btnCapNhat.Attributes.Add("Onclick", "return CheckInputNhanGay();");
      //  ddlNhanGay.Attributes.Add("Onchange", "ReplaceText();");
        btnReset.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
       // btnDelete.Attributes.Add("Onclick", "ReplaceText();");
    }
    private void LoadData()
    {
        pNhanGayInfo.NhanGayID = 0;
        dtData = InsertOneRow(oBNhanGay.Get(pNhanGayInfo), "---- Thêm mới ----", 0, 0);
        ddlNhanGay.DataSource = dtData;
        ddlNhanGay.DataTextField = "TenNhanGay";
        ddlNhanGay.DataValueField = "NhanGayID";
        ddlNhanGay.DataBind();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (ddlNhanGay.SelectedValue.ToString() != "0")
        {
            pNhanGayInfo.NhanGayID = int.Parse(ddlNhanGay.SelectedValue.ToString());
            oBNhanGay.Delete(pNhanGayInfo);
            ThongBao("Xóa thành công!");
            LoadData();
            ResetControl();
        }
    }
    protected void ddlNhanGay_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNhanGay.SelectedValue.ToString() != "0")
        {
            txtTenMau.Text = ddlNhanGay.SelectedItem.Text;
            pNhanGayInfo.NhanGayID = int.Parse(ddlNhanGay.SelectedValue.ToString());
            DataTable dtTemp = oBNhanGay.Get(pNhanGayInfo);
            txtNoiDung.Text = dtTemp.Rows[0]["NoiDung"].ToString();//.Replace("&lt;", "<").Replace("&gt;", ">");
        }
        else
        {
            txtNoiDung.Text = "";
            txtTenMau.Text = "";
            txtTenMau.Focus();
        }
    }
    private void ResetControl()
    {
        ddlNhanGay.SelectedIndex = 0;
        txtNoiDung.Text = "";
        txtTenMau.Text = "";
        txtTenMau.Focus();
    }
   protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        int NhanGayID = int.Parse("0" + ddlNhanGay.SelectedValue.ToString());
        pNhanGayInfo.NoiDung = txtNoiDung.Text;//.Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "");
        pNhanGayInfo.TenNhanGay = txtTenMau.Text;
        if (NhanGayID > 0)
        {
            // cap nhat
            pNhanGayInfo.NhanGayID = NhanGayID;
            oBNhanGay.Update(pNhanGayInfo);
            ThongBao("Cập nhật thành công!");
        }
        else
        { 
            // them moi
            oBNhanGay.Add(pNhanGayInfo);
            ThongBao("Thêm mới thành công!");
        }
        LoadData();
        ResetControl();
    }
}
