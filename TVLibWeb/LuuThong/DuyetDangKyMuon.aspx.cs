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
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Business;

public partial class LuuThong_DuyetDangKyMuon : WebBase

{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = DateTime.Now.ToShortDateString();
            txtToDate.Text = DateTime.Now.ToShortDateString();
            //LoadData();
            lblHoTen.Visible = false;
            _lblHoTen.Visible = false;
            btnIn.Attributes.Add("Onclick", "javascript:OpenWindow('InTaiLieuDangKyMuon.aspx?LoaiPhieu=4','InPhieu',400,600,50,25);");
        }
        
    }
    protected void btnLoc_Click(object sender, EventArgs e)
    {
        LoadData();
        
    }
    private void LoadData()
    {
        cBYeuCauMuon oBYeuCauMuon = new cBYeuCauMuon();
        cBBanDoc oBBanDoc = new cBBanDoc();
        DataTable dtbBanDoc=oBBanDoc.GetBanDocBySoThe(txtSoThe.Text);
        DataTable dtbYeuCauMuon=oBYeuCauMuon.GetByThoiDiem(DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text), txtSoThe.Text);
        Session["Data"] = dtbYeuCauMuon;
        Session["BanDoc"] = dtbBanDoc;
        if (dtbBanDoc.Rows.Count > 0)
        {
            lblHoTen.Visible = true;
            _lblHoTen.Visible = true;
            _lblHoTen.Text = dtbBanDoc.Rows[0]["TenDayDu"].ToString();
        }
        else
        {
            lblHoTen.Visible = false;
            _lblHoTen.Visible = false;
        }
        if (dtbYeuCauMuon.Rows.Count > 0)
        {
            grvTaiLieu.DataSource = dtbYeuCauMuon;
            grvTaiLieu.DataBind();
            for (int i = 0; i < dtbYeuCauMuon.Rows.Count; i++)
            {
                grvTaiLieu.Rows[i].Cells[0].Text = (i + 1).ToString();
            }
        }
        else
        {
            grvTaiLieu.DataSource = null;
            grvTaiLieu.DataBind();
        }
    }
}
