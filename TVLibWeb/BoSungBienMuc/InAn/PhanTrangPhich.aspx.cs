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

public partial class BoSungBienMuc_InAn_PhanTrangPhich : System.Web.UI.Page
{
    int SoTrang = 1, SoPhichTrenTrang = 6;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChuoiTaiLieu"] != null)
        {
            string[] ChuoiTaiLieu = Session["ChuoiTaiLieu"].ToString().Split(',');
            SoTrang = (int)Math.Ceiling(((float)ChuoiTaiLieu.Length / SoPhichTrenTrang));
            txtTongSoTrang.Text = SoTrang.ToString();
        }
    }
}
