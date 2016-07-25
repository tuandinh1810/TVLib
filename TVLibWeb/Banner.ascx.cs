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

public partial class Banner : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblImage.Text = "<div class='headerSuuTapSo'><a href='Default.aspx'><img border=0 src='" + Request.ApplicationPath + "Resources/Images/TVLib_Logo.png'/></a></div>";
        if( Session["TenDangNhap"] +""!="")
            ASPxMenu1.Items[6].Text = Session["TenDangNhap"].ToString();
    }
}
