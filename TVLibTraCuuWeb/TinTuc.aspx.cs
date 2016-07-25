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

namespace TVLibTraCuuWeb
{
    
    public partial class TinTuc : System.Web.UI.Page
    {
        cBTinTuc obTinTuc;
        TinTucInfo pTinTucInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            pTinTucInfo = new TinTucInfo();
            obTinTuc = new cBTinTuc();
            if (Request["TinTucID"] + "" != "")
                LoadTinTuc();
            else
            {
                if (!IsPostBack)
                    LoadData(); 
            }
            

        }
        private void LoadData()
        {             
            DataTable dtbTinTuc ;
            String strTinTuc ="";
            String strTrang   = "";
            int  intTongSoTrang  = 0,intTrangHienTai  = 0,intCount=0,intRecBatDau=0,intRecKetThuc=0,intRecPerPage=5;
            dtbTinTuc = obTinTuc.Get_TomTatTinTuc(0);
            intTongSoTrang = (dtbTinTuc.Rows.Count - 1) / intRecPerPage + 1;
            if (Request["CurrentPage"] + "" !="")  
                intTrangHienTai = int.Parse (Request["CurrentPage"] + "0");
            else 
                intTrangHienTai = 1;
            for (int i = 1; i <   intTongSoTrang;i++)
            {
                if ( intTrangHienTai == i)
                    strTrang = strTrang + "<b>" + "<font face ='Tahoma' size='3'>" + i + "</font>" + "</b>" + "+nbsp;";
                else

                    strTrang = strTrang + "<a class='TruongVietLinkFunction'  href='TinTuc.aspx?CurrentPage= " + i + " ' > " + i + "</a> ";
            }
            intRecBatDau = (intTrangHienTai - 1) * intRecPerPage;
            intRecKetThuc = ((intTrangHienTai - 1) * intRecPerPage) + (intRecPerPage - 1);

            if ( intRecBatDau > dtbTinTuc.Rows.Count - 1)
                intRecBatDau = dtbTinTuc.Rows.Count - 1;

           if  (intRecKetThuc > dtbTinTuc.Rows.Count - 1)
                intRecKetThuc = dtbTinTuc.Rows.Count - 1;
            
            strTinTuc = "<Table width='850px'  style='margin-left:5px;margin-right:5px'>";

            if  (dtbTinTuc.Rows.Count > 0 )
            {
                for (intCount = intRecBatDau ;intCount < intRecKetThuc;intCount++)
                {
                    if ( dtbTinTuc.Rows[intCount]["Loai"].ToString() == "1")
                        strTinTuc = strTinTuc + "<tr><td><a href='" + dtbTinTuc.Rows[intCount]["URL"] + "'><b> " + dtbTinTuc.Rows[intCount]["TieuDe"] + " </b> </a></td></tr>";
                    else
                        strTinTuc = strTinTuc + "<tr><td> <a href='TinTuc.aspx?TinTucID=" + dtbTinTuc.Rows[intCount]["TinTucID"] + "&IDParent=" + dtbTinTuc.Rows[intCount]["IDParent"] + "'><b> " + dtbTinTuc.Rows[intCount]["TieuDe"] + "  </b> </a></td></tr>";
                        strTinTuc = strTinTuc + "<tr><td   style='border-width:1px; vertical-align:top;border-bottom: solid 1px Gainsboro' border='1'><font face='Tahoma'  size='2' color='Black'>" + dtbTinTuc.Rows[intCount]["TomTat"] + "</font></td></tr>";

                }
                strTinTuc = strTinTuc + "</Table>";
            }
            else
                strTinTuc = strTinTuc + "<tr><td></td></tr></Table>";
            lblTinTuc.Text = strTinTuc;
            lblTrang.Text = strTrang;
            lbThongTin.Text = "TIN TỨC";
        }
        private void LoadTinTuc()
        {
            int intTinTucID = -1;
            DataTable dtbNoiDungTinTuc;
            string strNoiDungTinTuc = "", strNgayCapNhat = "";
            int intIDParent = 0;

            intTinTucID = int.Parse(Request.QueryString["TinTucID"]);

            pTinTucInfo.TinTucID = intTinTucID;
            dtbNoiDungTinTuc = obTinTuc.Get(pTinTucInfo);

            if (dtbNoiDungTinTuc.Rows.Count > 0)
            {
                strNoiDungTinTuc =  "<Table style='margin-left:10px;margin-right:10px'><tr><td> <b><font face size='3'> " +  dtbNoiDungTinTuc.Rows[0]["TieuDe"] + "</font></b></td></tr>";
                strNoiDungTinTuc = strNoiDungTinTuc + "<tr><td><B> " + dtbNoiDungTinTuc.Rows[0]["TomTat"] +" </B></td></tr>";
                strNoiDungTinTuc = strNoiDungTinTuc + "<tr><td> " + dtbNoiDungTinTuc.Rows[0]["NoiDung"] +" </td></tr></table>";
            }
            strNoiDungTinTuc = strNoiDungTinTuc + "<ul>";


            lblTinTuc.Text = strNoiDungTinTuc;

        }
    }
}
