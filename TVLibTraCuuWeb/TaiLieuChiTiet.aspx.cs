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
    public partial class TaiLieuChiTiet : WebBase 
    {
        TaiLieuInfo  oTaiLieuInfo;
        cBTaiLieu oBTaiLieu;
        MaXepGiaInfo oMaXepGia;
        cBMaXepGia oBMaXepGia;
        protected void Page_Load(object sender, EventArgs e)
        {
            oBTaiLieu = new cBTaiLieu();
            oTaiLieuInfo = new TaiLieuInfo();
            oMaXepGia = new MaXepGiaInfo();
            oBMaXepGia = new cBMaXepGia();
            if (Request["TaiLieuID"] != null)
            {
                if (Request["TaiLieuID"].ToString() != "")
                {
                    ShowDetail();
                    ShowMaXepGia();
                    
                }
            }
        }
        private void ShowMaXepGia()
        {
           oMaXepGia.IDTaiLieu=   int.Parse(Request.QueryString["TaiLieuID"].ToString());
           DataTable dtTemp = oBMaXepGia.GetByIDTaiLieu(oMaXepGia);
           if (dtTemp != null)
           {
                grvMaXepGia.DataSource = dtTemp;
                grvMaXepGia.DataBind();
           }
        }

        private void ShowDetail()
        {
            // lay thong tin truong dublincore cua TaiLieu
            oTaiLieuInfo.TaiLieuID = int.Parse(Request.QueryString["TaiLieuID"].ToString());
            DataTable dtTemp = oBTaiLieu.GetTaiLieuInfo(oTaiLieuInfo);

            // do du lieu vao bang

            TableRow tbRow = new TableRow();
            TableCell tbCell;

            if (dtTemp != null)
            {
               

                if (dtTemp.Rows.Count > 0)
                {
                    // do du lieu vao tung dong 

                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        tbRow = new TableRow();
                        // lay ten truong dublin do vao table
                        tbCell = new TableCell();
                        tbCell.Text = "<B>" + dtTemp.Rows[i]["Name"].ToString() + ":</B>";
                        tbCell.Width = Unit.Pixel(350);

                        tbRow.Cells.Add(tbCell);
                        // lay du lieu truong dublin do vao table
                        
                        tbCell = new TableCell();
                        tbCell.Text = dtTemp.Rows[i]["DisplayEntry"].ToString();
                        tbRow.Cells.Add(tbCell);

                        tblResult.Rows.Add(tbRow);
                    }
                }


                DataTable dtTempSoTapChi = oBTaiLieu.GetSoTapChiByTaiLieuID(oTaiLieuInfo);
                // Nếu là ấn phẩm định kỳ thì thêm vào dòng Số tạp chí
                if (dtTempSoTapChi.Rows.Count > 0 && dtTempSoTapChi.Rows[0]["TongHopSoTapChi"] + "" != "")
                {
                    tbRow = new TableRow();
                    // lay ten truong dublin do vao table
                    tbCell = new TableCell();
                    tbCell.Text = "<p><B>Số tạp chí:</B></p>";

                    // lay du lieu truong dublin do vao table
                    tbRow.Cells.Add(tbCell);
                    tblResult.Rows.Add(tbRow);
                    tbRow = new TableRow();
                    // lay ten truong dublin do vao table
                    tbCell = new TableCell();
                    tbCell.Style.Add("Padding-left", "70");
                    tbCell.Text = dtTempSoTapChi.Rows[0]["TongHopSoTapChi"].ToString();

                    // lay du lieu truong dublin do vao table
                    tbRow.Cells.Add(tbCell);
                    tblResult.Rows.Add(tbRow);
                }

            }
        }

        protected void grvMaXepGia_RowCreated(object sender, GridViewRowEventArgs e)
        {

            // kiem tra neu da kich hoat roi thi khong hien thi nut kich hoat nua
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbLuuThong = new Label();
                Label lbDangMuon = new Label();
                lbLuuThong = (Label)(e.Row.FindControl("lbLuuThong"));
                lbDangMuon = (Label)(e.Row.FindControl("lbDangMuon"));
                if ((lbLuuThong != null) && (lbDangMuon != null))
                {
                    if (e.Row.DataItem != null)
                    {
                        string LuuThong = DataBinder.Eval(e.Row.DataItem, "LuuThong").ToString();
                        if (LuuThong.ToLower() == "false".ToLower())
                        {
                            lbDangMuon.Visible = false;
                            lbLuuThong.Text = "<img src ='Resources/Images/lock.gif' alt='Mã xếp giá đang bị khoá' runat ='server' />";

                        }
                        else
                        {
                            lbLuuThong.Visible = false;
                            string DangMuon = DataBinder.Eval(e.Row.DataItem, "DangMuon").ToString();
                            if (DangMuon.ToLower() == "false".ToLower())
                            {
                                lbDangMuon.Text = "<img src ='Resources/Images/available.gif' alt='sẵn sàng phục vụ bạn đọc' runat ='server' />";
                            }
                            else
                            {
                                lbDangMuon.Text = "<img src ='Resources/Images/loan.gif' alt='Mã xếp giá đang cho mượn' runat ='server' />";
                            }
                        }
                    }
                }
            }
        }
        protected void grvMaXepGia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvMaXepGia.PageIndex = e.NewPageIndex;
            ShowMaXepGia();
        }
}
}
