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

public partial class LuuThong_BanDoc_DangMuon : WebBase
{
    cBTaiLieuMuon oBTaiLieuMuon;
    TaiLieuMuonInfo oTaiLieuMuonInfo;
    protected void Page_Load(object sender, EventArgs e)
    {

        oTaiLieuMuonInfo = new TaiLieuMuonInfo();
        oBTaiLieuMuon = new cBTaiLieuMuon();
        if (!IsPostBack)
        {
            LayDuLieu();

        }
        btnClose.Attributes.Add("onclick", "self.close();");
    }
    private void LayDuLieu()
    {
        if (Request["BanDocID"] + "" != "")
        {

            DataTable dtTtemp = oBTaiLieuMuon.Search(int.Parse(Request["BanDocID"] + ""), "", "", "", "", "", "");
            if (dtTtemp != null)
            {
                GridView1.DataSource = dtTtemp;
                GridView1.DataBind();
            }

        }
    }
}
