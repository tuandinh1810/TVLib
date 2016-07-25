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
using TruongViet.Lib.Web;

public partial class BanDoc_TimKiemBanDoc : WebBase
{
    DanTocInfo oDanTocInfo;
    cBDanToc oBDanToc;
    NgheNghiepInfo oNgheNghiepInfo;
    cBNgheNghiep oBNgheNghiep;
    NhomBanDocInfo oNhomBanDocInfo;
    cBNhomBanDoc oBNhomBanDoc;
    BanDocInfo oBanDocInfo;
    cBBanDoc oBBanDoc;

    protected void Page_Load(object sender, EventArgs e)
    {
        KhoiTao();
        BindJS();
        if (!IsPostBack)
        {
            GetData();
            LoadKhoas();
            LoadLop();
        }
    }
    private void KhoiTao()
    {
        oDanTocInfo = new DanTocInfo();
        oBDanToc = new cBDanToc();
        oNgheNghiepInfo = new NgheNghiepInfo();
        oBNgheNghiep = new cBNgheNghiep();
        oNhomBanDocInfo = new NhomBanDocInfo();
        oBNhomBanDoc = new cBNhomBanDoc();
        oBanDocInfo = new BanDocInfo();
        oBBanDoc = new cBBanDoc();
    }
    private void LoadKhoas()
    {
        DataTable dtbKhoas = InsertOneRow(oBBanDoc.GetKhoas(oBanDocInfo), "", 0, 0);
        ddlKhoas.DataSource = dtbKhoas;
        ddlKhoas.DataTextField = "Khoa";
        ddlKhoas.DataValueField = "Khoa";
        ddlKhoas.DataBind();
    }

    private void LoadLop()
    {
        //oBanDocInfo.Khoa = ddlKhoas.SelectedValue;
        DataTable dtbLop = InsertOneRow(oBBanDoc.GetLop(oBanDocInfo), "", 0, 0);
        ddlLop.DataSource = dtbLop;
        ddlLop.DataTextField = "Lop";
        ddlLop.DataValueField = "Lop";
        ddlLop.DataBind();
    }
    private void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "JSAdminCommon", "<script language='javascript' src='../Resources/JS/BanDoc.js'></script>");
        btnReset.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
        btnSearch.Attributes.Add("OnClick", "document.forms[0].method='Post';document.forms[0].action='KetQuaTraCuu.aspx'; document.forms[0].submit(); return false;");
    }

    private void GetData()
    {
        DataTable dtTemp;
        // get nghe nghiep
        oNgheNghiepInfo.NgheNghiepID = 0;
        dtTemp = oBNgheNghiep.Get(oNgheNghiepInfo);
        dtTemp = InsertOneRow(dtTemp, "-----Chọn nghề nghiệp-----", 0, 0);
        drdlNganhNghe.DataSource = dtTemp;
        drdlNganhNghe.DataTextField = "TenNgheNghiep";
        drdlNganhNghe.DataValueField = "NgheNghiepID";
        drdlNganhNghe.DataBind();

        // get dan toc
        oDanTocInfo.DanTocID = 0;
        dtTemp = oBDanToc.Get(oDanTocInfo);
        dtTemp = InsertOneRow(dtTemp, "---Chọn dân tộc---", 0, 0);
        drdlDanToc.DataSource = dtTemp;
        drdlDanToc.DataTextField = "DanToc";
        drdlDanToc.DataValueField = "DanTocID";
        drdlDanToc.DataBind();
      
        
        // get nhom ban doc
        oNhomBanDocInfo.NhomBanDocID = 0;
        dtTemp = oBNhomBanDoc.Get(oNhomBanDocInfo);
        dtTemp = InsertOneRow(dtTemp, "---Chọn nhóm bạn đọc---", 0, 0);
        lstNhomBanDoc.DataSource = dtTemp;
        lstNhomBanDoc.DataTextField = "TenNhomBanDoc";
        lstNhomBanDoc.DataValueField = "NhomBanDocID";
        lstNhomBanDoc.DataBind();
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }

    protected void ddlKhoas_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LoadLop();
    }
}
