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
using TruongViet.TVLibTraCuu.Business;
using TruongViet.TVLibTraCuu.Entity;

public partial class QTTinTuc : System.Web.UI.Page
{
    private cBTinTuc oBTinTuc;
    private TinTucInfo pTinTucInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        oBTinTuc = new cBTinTuc();
        pTinTucInfo = new TinTucInfo();
        if (!IsPostBack)
            LoadData();
    }

    private void LoadData()
    {
        //oDTinTuc.TinTucID = Request("TinTucID")
        DataTable dtbTinTuc;
        pTinTucInfo.TinTucID = 0;
        dtbTinTuc = oBTinTuc.Get(pTinTucInfo );
        grvTinTuc.DataSource = dtbTinTuc;
        grvTinTuc.DataBind();
        //if (dtbTinTuc.Rows.Count > 0)
        //    txtTieuDe.Text = dtbTinTuc.Rows[0]["TieuDe"].ToString();
        //if (dtbTinTuc.Rows.Count > 0)
        //{
        //    txtTomTat.Text = dtbTinTuc.Rows[0]["TomTat"].ToString();
        //    txtNoiDung.Text = dtbTinTuc.Rows[0]["NoiDung"].ToString();
        //}

    }
    protected void grvTinTuc_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        if (grvTinTuc.SelectedIndex >=0)
        {
            pTinTucInfo.TinTucID = int.Parse(grvTinTuc.DataKeys[grvTinTuc.SelectedIndex][0].ToString());
            hdID.Value = pTinTucInfo.TinTucID.ToString();
            DataTable dtbTinTuc;
            dtbTinTuc = oBTinTuc.Get(pTinTucInfo);
            if (dtbTinTuc.Rows.Count > 0)
            {
                txtTieuDe.Text = dtbTinTuc.Rows[0]["TieuDe"].ToString();
                txtTomTat.Text = dtbTinTuc.Rows[0]["TomTat"].ToString();
                txtNoiDung.Text = dtbTinTuc.Rows[0]["NoiDung"].ToString();
            }
        }
    }
    protected void grvTinTuc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTinTuc.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void grvTinTuc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
            pTinTucInfo.TinTucID = int.Parse(grvTinTuc.DataKeys[e.RowIndex][0].ToString());
            hdID.Value = pTinTucInfo.TinTucID.ToString();
            oBTinTuc.Delete(pTinTucInfo);
            LoadData();
       
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        pTinTucInfo.TinTucID = int.Parse(hdID.Value);
        pTinTucInfo.TieuDe = txtTieuDe.Text;
        pTinTucInfo.TomTat  = txtTomTat.Text;
        pTinTucInfo.NoiDung = txtNoiDung.Text;
        pTinTucInfo.Loai = "2";
        pTinTucInfo.URL = "";
        oBTinTuc.Update(pTinTucInfo);
        txtTomTat.Text = "";
        txtTieuDe.Text = "";
        txtNoiDung.Text = "";
        hdID.Value = "0";
        LoadData();
    }
    protected void btnThemMoi_Click(object sender, EventArgs e)
    {
        pTinTucInfo.TieuDe = txtTieuDe.Text;
        pTinTucInfo.TomTat = txtTomTat.Text;
        pTinTucInfo.NoiDung = txtNoiDung.Text;
        pTinTucInfo.NgayCapNhat = DateTime.Now;
        pTinTucInfo.Loai = "2";
        pTinTucInfo.URL = "";
        oBTinTuc.Add(pTinTucInfo);
        txtTomTat.Text = "";
        txtTieuDe.Text = "";
        txtNoiDung.Text = "";
        LoadData();
    }
}
