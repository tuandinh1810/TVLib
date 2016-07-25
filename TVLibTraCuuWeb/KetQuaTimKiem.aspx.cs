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

    public partial class KetQuaTimKiem : System.Web.UI.Page
    {
        TaiLieuInfo oTaiLieuInfo;
        cBTaiLieu oBTaiLieu;
        protected void Page_Load(object sender, EventArgs e)
        {
            imgTimKiem.Visible = false;
            oTaiLieuInfo = new TaiLieuInfo();
            oBTaiLieu = new cBTaiLieu();
            if (Request["type"] + "" == "")
            {
                      //lay du lieu TaiLieus
                    oTaiLieuInfo.TaiLieuID = 0;
                    DataTable dtTemp = oBTaiLieu.GetTop20(oTaiLieuInfo);
                    LayDuLieu(dtTemp);
               
            }
            else
            {
                lbThongBao.Text = "";
                lbThongBao.Visible = false;
                imgTimKiem.Visible = true;
                    TimKiem();
               
            }
        }

        private void LayDuLieu(DataTable dtTemp)
        {
            if (dtTemp != null)
            {

                grvTaiLieu.DataSource = dtTemp;
                grvTaiLieu.DataBind();
                if (lbThongBao.Text =="")
                {
                    if (dtTemp.Rows.Count > 0)
                    {
                        lbThongBao.Text = " KẾT QUẢ TÌM KIẾM";
                        lbRersult.Visible = true;
                        lbRersult.Text = dtTemp.Rows.Count.ToString() + "   kết quả";
                    }
                    else
                    {
                        lbRersult.Visible = false ;
                        lbThongBao.Text = "KHÔNG TÌM THẤY KẾT QUẢ";
                    }
                }
            }
        }
        private void TimKiem()
        {
            cBTaiLieu_TruongDublin objTaiLieu_TruongDublin = new cBTaiLieu_TruongDublin();
           DataTable  dtbResult = objTaiLieu_TruongDublin.RunSql(Session["Chuoi"] + "");
            if (dtbResult != null)
            {
                LayDuLieu(dtbResult);
            }
        }

        protected void grvTaiLieu_RowCreated(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lb = new Label();
                lb = (Label)(e.Row.FindControl("lbNhanDe"));
                if (lb != null)
                {
                    if (e.Row.DataItem != null)
                    {
                        lb.Text = "<a href ='TaiLieuChiTiet.aspx?TaiLieuID=" + DataBinder.Eval(e.Row.DataItem, "TaiLieuID").ToString() + "'" + " runnat='server'>  " + DataBinder.Eval(e.Row.DataItem, "NhanDe").ToString() + "  </a>";
                    }
                }
            }
        }

        protected void grvTaiLieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTaiLieu.PageIndex = e.NewPageIndex;
            if (Request["type"] + "" != "")
            {               
                TimKiem();
            }
        }
        
       
    }
}
