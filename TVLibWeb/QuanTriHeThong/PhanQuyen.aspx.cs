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

public partial class QuanTriHeThong_PhanQuyen : WebBase 
{
    NguoiDung_ChucNangInfo oND_CNInfo;
    cBNguoiDung_ChucNang oBND_CN;
    ChucNangInfo oChucNangInfo;
    cBChucNang oBChucNang;
    NguoiDungInfo oNguoiDung = new NguoiDungInfo();
    int intIDPhanHe = 0;
    int intIDNguoiDung = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        oBND_CN = new cBNguoiDung_ChucNang();
        oND_CNInfo = new NguoiDung_ChucNangInfo();
        oChucNangInfo = new ChucNangInfo();
        oBChucNang = new cBChucNang();
        BindJS();
        GetData();

    }
    private void BindJS()
    {
       
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript' src='../Resources/Js/PhanQuyen.js'></script>");      
        btnAdd.Attributes.Add("OnClick", "javascript:AddItem();return false;");
        btnRemove.Attributes.Add("OnClick", "javascript:RemoveItems();return false;");//"javascript:RemoveItem();return(false);");
        btnDong.Attributes.Add("onclick", "self.close();");

    }

    private void GetData()
    {
        // do du lieu vao list chuc nang

        if (Request["PhanHe"] + "" != "")
        {
            intIDPhanHe = int.Parse(Request["PhanHe"].ToString());
            //if (intIDPhanHe == 2)
            //    tvwThuMuc.Visible = true;
            //else
            //    tvwThuMuc.Visible = false;
        }
        if (Request["IDNguoiDung"] + "" != "")
            intIDNguoiDung = int.Parse(Request["IDNguoiDung"].ToString());
        DataTable dtbQuyenKhongDuocCap = oBChucNang.GetQuyenKhongDuocCap(intIDNguoiDung, intIDPhanHe);
        DataTable dtbQuyenDuocCap = oBChucNang.GetQuyenDuocCap(intIDNguoiDung, intIDPhanHe);
        oNguoiDung.NguoiDungID = intIDNguoiDung;
        //DataTable dtbThuMucQuanLy = oBNguoiDung.Get(oNguoiDung);
        //if (dtbThuMucQuanLy.Rows.Count > 0)
        //    txtThuMucQuanLy.Text = dtbThuMucQuanLy.Rows[0]["ThuMucQuanLy"].ToString();
        if (dtbQuyenKhongDuocCap.Rows.Count > 0)
        {
            lsbKhongDuocCap.DataSource = dtbQuyenKhongDuocCap;
            lsbKhongDuocCap.DataTextField = "TenChucNang";
            lsbKhongDuocCap.DataValueField = "ChucNangID";
            lsbKhongDuocCap.DataBind();
        }
        if (dtbQuyenDuocCap.Rows.Count > 0)
        {
            lsbDuocCap.DataSource = dtbQuyenDuocCap;
            lsbDuocCap.DataTextField = "TenChucNang";
            lsbDuocCap.DataValueField = "IDChucNang";
            lsbDuocCap.DataBind();
        }
        DataTable dtTemp = oBChucNang.GetByPhanHe(oChucNangInfo);

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }
}
