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

public partial class BoSungBienMuc_MauBienMuc_MARC21 : WebBase
{
    MARCInfo pMarcInfo;
    cBMARC oBMarc;
    MARC_FIELDInfo pMarc_FieldInfo;
    cBMARC_FIELD oBMarc_Field;
    cBMauBienMuc oBMauBienMuc;
    MauBienMucInfo pMauBienMucInfo;
    cBMauBienMuc_ChiTiet oBMauBienMuc_Chitiet;
    MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",14,") >= 0)
        {
            if (Session["TaiKhoanID"] + "" == "")
                Response.Redirect("../Default.aspx");
            pMarc_FieldInfo = new MARC_FIELDInfo();
            pMarcInfo = new MARCInfo();
            oBMarc = new cBMARC();
            oBMarc_Field = new cBMARC_FIELD();
            oBMauBienMuc_Chitiet = new cBMauBienMuc_ChiTiet();
            pMauBienMuc_ChiTietInfo = new MauBienMuc_ChiTietInfo();
            pMauBienMucInfo = new MauBienMucInfo();
            oBMauBienMuc = new cBMauBienMuc();
            BindJS();
            oChucNang.MaChucNang = "BienMuc";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            if (!IsPostBack)
            {
                GetMarc();
            }
            if (Request["MauBienMucID"] + "" != "")
            {
                GetData();
            }
        }
        else
            Response.Redirect("Error.aspx");
    }
    private void BindJS()
    {
        btnThemMoi.Attributes.Add("OnClick","if(document.forms[0].txtTen.value==''){alert('Bạn chưa nhập tên mẫu biên mục!');return false;}");
    }
    private void GetData()
    {
        DataTable dtTemp = oBMauBienMuc_Chitiet.Get_ByMauBienMuc(int.Parse("0" + Request["MauBienMucID"].ToString()));
        for (int i = 0; i < dtTemp.Rows.Count; i++)
        {
            hdIDs.Value += dtTemp.Rows[i]["Marc_Field_ID"].ToString() + ",";
        }
        txtTen.Text = dtTemp.Rows[0]["Ten"].ToString();
    }
    private void GetMarc()
    {
        ddlKhoiTruong.DataSource = oBMarc.Get(pMarcInfo);
        ddlKhoiTruong.DataTextField = "Name";
        ddlKhoiTruong.DataValueField = "MARCID";
        ddlKhoiTruong.DataBind();
        ddlKhoiTruong_SelectedIndexChanged(null, null);
    }
    protected void ddlKhoiTruong_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvTruong.DataSource = oBMarc_Field.Get_ByMARC(int.Parse(ddlKhoiTruong.SelectedValue.ToString()));
        grvTruong.DataBind();
        grvTruong.SelectedIndex = 0;
        if (e != null)
        {
            grvTruong.PageIndex = 0;
        }
        grvTruong_SelectedIndexChanged(null, null);
    }
    protected void grvTruong_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvTruongCon.DataSource = oBMarc_Field.Get_ByParent(int.Parse(grvTruong.DataKeys[grvTruong.SelectedIndex][0].ToString()));
        grvTruongCon.DataBind();
    }
     protected void grvTruong_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       grvTruong.PageIndex = e.NewPageIndex;
      ddlKhoiTruong_SelectedIndexChanged(null,null);
       //grvTruongCon.DataSource = null;
    }
     protected void grvTruongCon_RowCreated(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             CheckBox chk = (CheckBox)e.Row.FindControl("cbxDKCB");
             if (chk != null && e.Row.DataItem != null)
             {
                 chk.Attributes.Add("Onclick", "if(this.checked== true) {document.forms[0].hdIDs.value=document.forms[0].hdIDs.value +" + DataBinder.Eval(e.Row.DataItem, "MARC_FIELD_ID").ToString() + " +',' ;}else{document.forms[0].hdIDs.value=document.forms[0].hdIDs.value.replace('" + DataBinder.Eval(e.Row.DataItem, "MARC_FIELD_ID").ToString() + "'+ ',','') ;}");
                 if (hdIDs.Value.IndexOf(DataBinder.Eval(e.Row.DataItem, "MARC_FIELD_ID").ToString() + ",") >= 0)
                 {
                     chk.Checked = true;
                 }
                 
             }
             
         }
     }
     protected void btnThemMoi_Click(object sender, EventArgs e)
     {
         if (hdIDs.Value != "")
         {
            string[] arIDs = hdIDs.Value.Substring(0,hdIDs.Value.Length-1).Split(',');
            pMauBienMucInfo.Ten = txtTen.Text.Trim();
            pMauBienMucInfo.IDNguoiDung = int.Parse("0"+Session["TaiKhoanID"]);

            pMauBienMucInfo.NgaySuaCuoi = DateTime.Now;
            pMauBienMucInfo.NgayTao  = DateTime.Now;
            int MauBienMucID;
            if (Request["MauBienMucID"] + "" != "")
            {
                MauBienMucID = pMauBienMucInfo.MauBienMucID = int.Parse("0" + Request["MauBienMucID"].ToString());
                oBMauBienMuc.Update(pMauBienMucInfo);
            }
            else
            {
                MauBienMucID = oBMauBienMuc.Add(pMauBienMucInfo);
            }
             for (int i = 0; i < arIDs.Length; i++)
             {
                 pMauBienMuc_ChiTietInfo.GiaTriMacDinh = "";
                 pMauBienMuc_ChiTietInfo.IDMARC_FIELD = int.Parse(arIDs[i]);
                 pMauBienMuc_ChiTietInfo.IDMauBienMuc = MauBienMucID;
                 oBMauBienMuc_Chitiet.Add(pMauBienMuc_ChiTietInfo);
             }
             hdIDs.Value = "";
             txtTen.Text = "";
             if (Request["MauBienMucID"] + "" != "")
             {
                 ThongBao("Cập nhật mẫu biên mục thành công!");
                 ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript'>self.location.href='CapNhatMauBienMuc.aspx?MauBienMucID=" + Request["MauBienMucID"].ToString() + "';</script>");
                 WriteLog(lstChucNang[0].ChucNangID, "Sửa mẫu biên mục thành công: +" + pMauBienMucInfo.Ten, Request.UserHostAddress, Session["TenDangNhap"].ToString());
                 
             }
             else
             {
                 ThongBao("Thêm mới mẫu biên mục thành công!");
                 WriteLog(lstChucNang[0].ChucNangID, "Thêm mới mẫu biên mục thành công: +" + pMauBienMucInfo.Ten, Request.UserHostAddress, Session["TenDangNhap"].ToString());
             }


         }
         else
         {
             ThongBao("Bạn phải chọn ít nhất 1 trường con!");
         }
     }
}
