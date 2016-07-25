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

public partial class BoSungBienMuc_BaoCao_ThongKe_BaoCaoBoSung : WebBase
{
    cBThuVien oBThuVien;
    ThuVienInfo oThuVienInfor;
    cBKho oBKho;
    cBMaXepGia oBMaXepGia;

    protected void Page_Load(object sender, EventArgs e)
    {
        oBThuVien = new cBThuVien();
        oThuVienInfor = new ThuVienInfo();
        oBKho = new cBKho();
        oBMaXepGia = new cBMaXepGia();
        BindJS();
        if (!IsPostBack)
        {
            LoadThuVien();
        }
    }
    private void LoadThuVien()
    {
        oThuVienInfor.ThuVienID = 0;
        ddlLibrary.DataSource = InsertOneRow(oBThuVien.Get(oThuVienInfor), "-- Chọn thư viện --", 0, 0);
        ddlLibrary.DataTextField = "MaThuVien";
        ddlLibrary.DataValueField = "ThuVienID";
        ddlLibrary.DataBind();
        LoadKhoByThuVien(0);
    }
    private void LoadKhoByThuVien(int intThuVienID)
    {
        ddlStore.DataSource = InsertOneRow(oBKho.GetByThuVienID(intThuVienID), "---- Chọn kho ----", 0, 0);
        ddlStore.DataTextField = "TenKho";
        ddlStore.DataValueField = "KhoID";
        ddlStore.DataBind();

    }
    private void BindJS()
    {
        Response.Write("<Script src='../../Resources/Js/TVLib.js'" + " ></Script>");
        btnSearch.Attributes.Add("Onclick", "if(CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtFromDate,'Không đúng kiểu định dạng ngày tháng!')== false ||  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtToDate,'Không đúng kiểu định dạng ngày tháng!')== false ){return false;}");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DateTime dtTuNgay, dtDenNgay;
        dtTuNgay = DateTime.Parse("1/1/1900");
        dtDenNgay = DateTime.Parse("1/1/1900");

        if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        {
            dtTuNgay = TVDateTime.ChuyenVietSangAnh(txtFromDate.Text.Trim());
            dtDenNgay = TVDateTime.ChuyenVietSangAnh(txtToDate.Text.Trim());
        }
        DataTable dtData = oBMaXepGia.Get_BaoCaoBoSung(int.Parse(ddlLibrary.SelectedValue.ToString()), int.Parse(ddlStore.SelectedValue.ToString()), dtTuNgay, dtDenNgay);
        grvTaiLieu.DataSource = dtData;
        grvTaiLieu.DataBind();
        //if ((dtData != null) && (dtData.Rows.Count >0))
        //{
        //    TableCell tblCell;
        //    TableRow tblRow;
        //    string ThuVienID, KhoID, TaiLieuID;
          
        //    for (int i = 0; i < dtData.Rows.Count; i++)
        //    {
        //        tblRow = new TableRow();
        //        tblCell = new TableCell();
        //        tblCell.Text = dtData.Rows[i]["TenThuVien"].ToString();
        //        tblRow.Cells.Add(tblCell);
        //        tblCell = new TableCell();
        //        tblCell.Text = dtData.Rows[i]["TenKho"].ToString();
        //        tblRow.Cells.Add(tblCell);
        //        tblCell = new TableCell();
        //        tblCell.Text = dtData.Rows[i]["MaXepGia"].ToString();
        //        tblRow.Cells.Add(tblCell);
        //        tblCell = new TableCell();
        //        tblCell.Text = dtData.Rows[i]["NgayXepGia"].ToString();
        //        tblRow.Cells.Add(tblCell);
        //        if (i % 2 == 0)
        //            tblRow.CssClass = "TVLibGridAlterCell";
        //        else
        //            tblRow.CssClass = "TVLibGridCell";
        //        tblResult.Rows.Add(tblRow);
        //    }
        //}
    }
    protected void btnIn_Click(object sender, EventArgs e)
    {
        if (grvTaiLieu.Rows.Count > 0)
        {
            string mstr = "";

            // tao header
            mstr = mstr + "<tr>";
            mstr = mstr + "<Td align='center' width='5%' ><B>STT</B></Td>";
            mstr = mstr + "<Td align='center' width='15%'><B>Thư viện</B></Td>";
            mstr = mstr + "<Td align='center' width='20%'><B>Kho</B></Td>";
            mstr = mstr + "<Td align='center' width='30%'><B>Nhan đề tài liệu</B></Td>";
            mstr = mstr + "<Td align='center' width='15%'><B>Mã xếp giá</B></Td>";
            mstr = mstr + "<Td align='center'><B>Ngày bổ sung</B></Td>";
            mstr = mstr + "</tr>";

            for (int i = 0; i < grvTaiLieu.Rows.Count; i++)
            {


                mstr = mstr + "<tr>";
                mstr = mstr + "<Td align='center' ><Font face='Times New Roman' style='Font-Size:12pt'>" + (i + 1).ToString() + "</Font></Td>";
                mstr = mstr + "<Td  ><Font face='Times New Roman' style='Font-Size:12pt'>" + grvTaiLieu.Rows[i].Cells[1].Text.ToString() + "</Font></Td>";
                mstr = mstr + "<Td  ><Font face='Times New Roman' style='Font-Size:12pt'>" + grvTaiLieu.Rows[i].Cells[2].Text.ToString() + "</Font></Td>";
                mstr = mstr + "<Td  ><Font face='Times New Roman' style='Font-Size:12pt'>" + grvTaiLieu.Rows[i].Cells[4].Text.ToString() + "</Font></Td>";
                mstr = mstr + "<Td  ><Font face='Times New Roman' style='Font-Size:12pt'>" + grvTaiLieu.Rows[i].Cells[3].Text.ToString() + "</Font></Td>";
                mstr = mstr + "<Td  ><Font face='Times New Roman' style='Font-Size:12pt'>" + grvTaiLieu.Rows[i].Cells[5].Text.ToString() + "</Font></Td>";
                mstr = mstr + "</tr>";


            }

            mstr = "<html><head><meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\"></head><body><Font face='Times New Roman' style='font-size:14' Color='#0066CC' ><span align='center'><B>BÁO CÁO CHI</B></span></Font><br /><br /><table border='1' cellspacing=0 cellpadding=0 width=100%>" + mstr + "</table></Body></HTML>";

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=BaoCaoBoSung.doc");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Buffer = true;
            Response.ContentType = "application/vnd.word";

            Response.Output.WriteLine(mstr);
            Response.Flush();
            Response.End();
        }
        else
            ThongBao("Chưa có dữ liệu!");
    }
    protected void grvTaiLieu_PageIndexChanged(object sender, EventArgs e)
    {
         btnSearch_Click(null, null);
    }
}
