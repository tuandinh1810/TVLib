using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TruongViet.TVLib.Business;
using TruongViet.TVLib.Entity;
using TruongViet.Lib.Web;
using System.Data;
using Aspose.Cells;
using System.Drawing;
public partial class LuuThong_BaoCaoThongKe_DanhMucSachMoi : WebBase
{
    cBMaXepGia oBMaXepGia;
    private Cells _range;
    private Worksheet _exSheet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = "01/01/2013";
            txtToDate.Text = "30/11/2013";
            LoadData();
            
        }
        Page.RegisterClientScriptBlock("Js", "<script language='javascript' src='../../Resources/Js/TVLib.js'></script>");
        btnSearch.Attributes.Add("onclick", "if(CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtFromDate,'Không đúng kiểu định dạng ngày tháng!')== false ||  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtToDate,'Không đúng kiểu định dạng ngày tháng!')== false ){return false;}");
        
    }
    private void LoadData()
    {
        oBMaXepGia = new cBMaXepGia();
        DataTable dtbSachMoi = oBMaXepGia.DanhMucSachMoi(DateTime.ParseExact(txtFromDate.Text,"dd/MM/yyyy",null),DateTime.ParseExact(txtToDate.Text,"dd/MM/yyyy",null));
        if (dtbSachMoi.Rows.Count > 0)
        {
            lblTotal.Visible = true;
            lblTotal.Text = "<b>Tổng số bản ghi</b> : " + dtbSachMoi.Rows.Count.ToString();
            grvTaiLieu.DataSource = dtbSachMoi;
            grvTaiLieu.DataBind();
        }
        else
        {
            lblTotal.Visible = false;
            lblTotal.Text = "<b>Tổng số bản ghi</b> : " + dtbSachMoi.Rows.Count.ToString();
            grvTaiLieu.DataSource =null;
            grvTaiLieu.DataBind();
        }

        
    }
    protected void grvTaiLieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTaiLieu.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadData();
    }
    protected void btnIn_Click(object sender, EventArgs e)
    {

        #region Chuẩn bị tệp excel mẫu để ghi dữ liệu
        Workbook exBook = new Workbook();
        exBook.Open(Server.MapPath("~/Template/DanhMucSachMoi.xls"), FileFormatType.Excel2003);
        _exSheet = exBook.Worksheets[0];
        

        _range = _exSheet.Cells;

        #endregion

        #region Tạo tiêu đề cho báo cáo
        //_range[2, 0].PutValue("Tháng " + Thang.ToString() + " năm " + Nam.ToString());
        //_range[3, 1].PutValue("Hải dương, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString());
        #endregion

        #region Phần thân báo cáo
        var now = DateTime.Now;
        int STT = 1;
        // Xử lý thêm tiêu đề cột
        ///*
        ///
        #region TieuDe
        Aspose.Cells.Style style = _range["P2"].GetStyle();
        style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
        style.Borders[BorderType.TopBorder].Color = Color.Black;
        style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
        style.Borders[BorderType.BottomBorder].Color = Color.Black;
        style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
        style.Borders[BorderType.LeftBorder].Color = Color.Black;
        style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
        style.Borders[BorderType.RightBorder].Color = Color.Black;
        style.Font.Size = 10;
        style.Font.Name = "Times New Roman";

        Aspose.Cells.Style styleHoTen = _range["P2"].GetStyle(); ;
        styleHoTen.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
        styleHoTen.Borders[BorderType.TopBorder].Color = Color.Black;
        styleHoTen.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
        styleHoTen.Borders[BorderType.BottomBorder].Color = Color.Black;
        styleHoTen.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
        styleHoTen.Borders[BorderType.LeftBorder].Color = Color.Black;
        styleHoTen.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
        styleHoTen.Borders[BorderType.RightBorder].Color = Color.Black;
        styleHoTen.VerticalAlignment = TextAlignmentType.CenterAcross;
        styleHoTen.HorizontalAlignment = TextAlignmentType.Left;
        styleHoTen.Font.IsBold = false;
        styleHoTen.Font.Name = "Times New Roman";
        styleHoTen.Font.Size = 10;
        styleHoTen.IsTextWrapped=true;

        Aspose.Cells.Style styleTien = _range["P2"].GetStyle(); ;
        styleTien.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
        styleTien.Borders[BorderType.TopBorder].Color = Color.Black;
        styleTien.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
        styleTien.Borders[BorderType.BottomBorder].Color = Color.Black;
        styleTien.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
        styleTien.Borders[BorderType.LeftBorder].Color = Color.Black;
        styleTien.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
        styleTien.Borders[BorderType.RightBorder].Color = Color.Black;
        styleTien.VerticalAlignment = TextAlignmentType.CenterAcross;
        styleTien.HorizontalAlignment = TextAlignmentType.Right;
        styleTien.Custom = "#,##0";
        styleTien.Font.IsBold = false;
        styleTien.Font.Name = "Times New Roman";
        styleTien.Font.Size = 10;

        Aspose.Cells.Style styleHeSo = _range["P2"].GetStyle(); ;
        styleHeSo.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
        styleHeSo.Borders[BorderType.TopBorder].Color = Color.Black;
        styleHeSo.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
        styleHeSo.Borders[BorderType.BottomBorder].Color = Color.Black;
        styleHeSo.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
        styleHeSo.Borders[BorderType.LeftBorder].Color = Color.Black;
        styleHeSo.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
        styleHeSo.Borders[BorderType.RightBorder].Color = Color.Black;
        styleHeSo.VerticalAlignment = TextAlignmentType.CenterAcross;
        styleHeSo.HorizontalAlignment = TextAlignmentType.Right;
        styleHeSo.Custom = "#,##0.0";
        styleHeSo.Font.IsBold = false;
        styleHeSo.Font.Name = "Times New Roman";
        styleHeSo.Font.Size = 10;
        #endregion
        //double TongTienLuongBinhThuong = 0;
        //double TongTienLuongThemGio = 0;
        oBMaXepGia = new cBMaXepGia();
        DataTable dtbBaoCao = oBMaXepGia.DanhMucSachMoi(DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", null), DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", null));
        
        int DongHienTai = 5;
        int j = 0;
        dtbBaoCao.DefaultView.Sort = "TenKho";
        // Đưa tiêu đề cột vào excel
        try
        {
            for (int i = 0; i < dtbBaoCao.DefaultView.Count; i++)
            {
                if (i > 0 && dtbBaoCao.DefaultView[i]["TenKho"].ToString() != dtbBaoCao.DefaultView[i - 1]["TenKho"].ToString())
                {
                    //_exSheet.AutoFitRows();
                    j = j + 1;
                    _exSheet = exBook.Worksheets[j];
                    _exSheet.Name = dtbBaoCao.DefaultView[i]["TenKho"].ToString();
                    _range = _exSheet.Cells;
                    DongHienTai = 5;

                }
                else if (i == 0)
                    _exSheet.Name = dtbBaoCao.DefaultView[i]["TenKho"].ToString();

                // STT
                _range[DongHienTai, 0].SetStyle(styleHoTen);
                _range[DongHienTai, 0].PutValue(STT.ToString());
                // _range[DongHienTai, 0].Style.Font.Size = 10;
                //_range[DongHienTai, 0].Style.IsTextWrapped = true;
                // _range[DongHienTai, 0].Style.HorizontalAlignment = TextAlignmentType.Center;
                //Khóa
                _range[DongHienTai, 1].SetStyle(styleHoTen);
                _range[DongHienTai, 1].PutValue(dtbBaoCao.DefaultView[i]["NhanDe"].ToString());
                _range[DongHienTai, 1].Style.Font.Size = 10;
                _range[DongHienTai, 1].Style.IsTextWrapped = true;
                _range[DongHienTai, 1].Style.HorizontalAlignment = TextAlignmentType.Left;
                // Lớp
                _range[DongHienTai, 2].SetStyle(styleHoTen);
                _range[DongHienTai, 2].PutValue(dtbBaoCao.DefaultView[i]["TacGia"].ToString().Replace("'", ""));
                _range[DongHienTai, 2].Style.Font.Size = 10;
                _range[DongHienTai, 2].Style.IsTextWrapped = true;
                _range[DongHienTai, 2].Style.HorizontalAlignment = TextAlignmentType.Left;

                //Mã sinh vien
                _range[DongHienTai, 3].SetStyle(styleHoTen);
                _range[DongHienTai, 3].PutValue(dtbBaoCao.DefaultView[i]["NhaXuatBan"].ToString().Replace("'", ""));
                _range[DongHienTai, 3].Style.Font.Size = 10;
                _range[DongHienTai, 3].Style.IsTextWrapped = true;
                _range[DongHienTai, 3].Style.HorizontalAlignment = TextAlignmentType.Left;

                ////Ho ten
                _range[DongHienTai, 4].SetStyle(styleHoTen);
                _range[DongHienTai, 4].PutValue(dtbBaoCao.DefaultView[i]["ChiSoPL"].ToString().Replace("'", ""));
                _range[DongHienTai, 4].Style.Font.Size = 10;
                _range[DongHienTai, 4].Style.IsTextWrapped = true;
                _range[DongHienTai, 4].Style.HorizontalAlignment = TextAlignmentType.Center;

                ////Ho ten
                _range[DongHienTai, 5].SetStyle(styleHoTen);
                _range[DongHienTai, 5].PutValue(dtbBaoCao.DefaultView[i]["NamXuatBan"].ToString().Replace("'", ""));
                _range[DongHienTai, 5].Style.Font.Size = 10;
                _range[DongHienTai, 5].Style.IsTextWrapped = true;
                _range[DongHienTai, 5].Style.HorizontalAlignment = TextAlignmentType.Center;

                _range[DongHienTai, 6].SetStyle(styleHeSo);
                _range[DongHienTai, 6].PutValue(dtbBaoCao.DefaultView[i]["DonGia"].ToString().Replace("'", ""));
                _range[DongHienTai, 6].Style.Font.Size = 10;
                _range[DongHienTai, 6].Style.IsTextWrapped = true;
                _range[DongHienTai, 6].Style.HorizontalAlignment = TextAlignmentType.Center;


                _range[DongHienTai, 7].SetStyle(styleHoTen);
                _range[DongHienTai, 7].PutValue(dtbBaoCao.DefaultView[i]["SL"].ToString().Replace("'", ""));
                _range[DongHienTai, 7].Style.Font.Size = 10;
                _range[DongHienTai, 7].Style.IsTextWrapped = true;
                _range[DongHienTai, 7].Style.HorizontalAlignment = TextAlignmentType.Center;

                _range[DongHienTai, 8].SetStyle(styleHoTen);
                _range[DongHienTai, 8].PutValue(dtbBaoCao.DefaultView[i]["TenKho"].ToString().Replace("'", ""));
                _range[DongHienTai, 8].Style.Font.Size = 10;
                _range[DongHienTai, 8].Style.IsTextWrapped = true;
                _range[DongHienTai, 8].Style.HorizontalAlignment = TextAlignmentType.Center;

                ////Nhan De
                //_range[DongHienTai, 5].SetStyle(styleHoTen);
                //_range[DongHienTai, 5].PutValue(dtbBaoCao.DefaultView[i]["NhanDe"].ToString());
                //_range[DongHienTai, 5].Style.Font.Size = 10;
                //_range[DongHienTai, 5].Style.IsTextWrapped = true;
                //_range[DongHienTai, 5].Style.HorizontalAlignment = TextAlignmentType.Left;

                ////Ma xep gia
                //_range[DongHienTai, 6].SetStyle(styleHoTen);
                //_range[DongHienTai, 6].PutValue(dtbBaoCao.DefaultView[i]["MaXepGia"].ToString());
                //_range[DongHienTai, 6].Style.Font.Size = 10;
                //_range[DongHienTai, 6].Style.IsTextWrapped = true;
                //_range[DongHienTai, 6].Style.HorizontalAlignment = TextAlignmentType.Center;

                ////Ngay muon
                //_range[DongHienTai, 7].SetStyle(styleHoTen);
                //_range[DongHienTai, 7].PutValue(dtbBaoCao.DefaultView[i]["NgayMuon"].ToString());
                //_range[DongHienTai, 7].Style.Font.Size = 10;
                //_range[DongHienTai, 7].Style.IsTextWrapped = true;
                //_range[DongHienTai, 7].Style.HorizontalAlignment = TextAlignmentType.Right;

                ////Ngay phai tra
                //_range[DongHienTai, 8].SetStyle(styleHoTen);
                //_range[DongHienTai, 8].PutValue(dtbBaoCao.DefaultView[i]["NgayPhaiTra"].ToString());
                //_range[DongHienTai, 8].Style.Font.Size = 10;
                //_range[DongHienTai, 8].Style.IsTextWrapped = true;
                //_range[DongHienTai, 8].Style.HorizontalAlignment = TextAlignmentType.Right;

                ////So ngay qua han
                //_range[DongHienTai, 9].SetStyle(styleHoTen);
                //_range[DongHienTai, 9].PutValue(dtbBaoCao.DefaultView[i]["SoNgayQuaHan"].ToString());
                //_range[DongHienTai, 9].Style.Font.Size = 10;
                //_range[DongHienTai, 9].Style.IsTextWrapped = true;
                //_range[DongHienTai, 9].Style.HorizontalAlignment = TextAlignmentType.Right;
                _exSheet.AutoFitRow(DongHienTai);
                DongHienTai++;
                STT++;


            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        exBook.Save("DanhMucSachMoi" + DateTime.Now.ToString("dd_MM_yyyy") + ".xls", FileFormatType.Excel2003, SaveType.OpenInExcel, System.Web.HttpContext.Current.Response);
        #endregion
    }
}