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

public partial class BoSungBienMuc_InAn_PhanTrangNhanGay : System.Web.UI.Page
{
    int SoTrang = 1, SoNhanTrenTrang = 35;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ChuoiMaXG"] != null)
        {
            string[] MaXepGia = Session["ChuoiMaXG"].ToString().Split(',');
            SoTrang = (int)Math.Ceiling(((float)MaXepGia.Length / SoNhanTrenTrang));
            txtTongSoTrang.Text = SoTrang.ToString();
        }
        else
        {
            txtTrangHienTai.Text = "0";
            txtTongSoTrang.Text = "0";
        }
    }
}
