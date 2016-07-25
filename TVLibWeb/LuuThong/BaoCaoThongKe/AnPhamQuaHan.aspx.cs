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
using Aspose.Cells;
using System.Drawing;

public partial class LuuThong_BaoCao_ThongKe_AnPhamQuaHan : WebBase
{
    private cBTaiLieu oBTaiLieu;
    private cBKho oBKho;
    cBBanDoc oBBanDoc;
    BanDocInfo oBanDocInfo;
    public int i = 1;
    private Cells _range;
    private Worksheet _exSheet;
    protected void Page_Load(object sender, EventArgs e)
    {
        oBTaiLieu = new cBTaiLieu();
        oBBanDoc = new cBBanDoc();
        oBanDocInfo = new BanDocInfo();
        btnFind.Attributes.Add("Onclick", "if((CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtFromDate,'Không đúng kiểu định dạng ngày tháng!')== false) || (CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtToDate,'Không đúng kiểu định dạng ngày tháng!')== false)){return false;}");
        btnCancel.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
        if (!IsPostBack)
        {
            // load du lieu vao ddlKho
            oBKho = new cBKho();
            ddlKho.DataSource = InsertOneRow(oBKho.GetByThuVienID(0), "-- Chọn kho --", 0, 0);
            ddlKho.DataTextField = "MaKho";
            ddlKho.DataValueField = "KhoID";
            ddlKho.DataBind();
            LoadKhoas();
            LoadLop();
        }
    }

    private void LoadKhoas()
    {
        DataTable dtbKhoas = InsertOneRow(oBBanDoc.GetKhoas(oBanDocInfo),"",0,0);
        ddlKhoas.DataSource = dtbKhoas;
        ddlKhoas.DataTextField = "Khoa";
        ddlKhoas.DataValueField = "Khoa";
        ddlKhoas.DataBind();
    }

    private void LoadLop()
    {
        oBanDocInfo.Khoa = ddlKhoas.SelectedValue;
        DataTable dtbLop = InsertOneRow(oBBanDoc.GetLop(oBanDocInfo), "", 0, 0); 
        ddlLop.DataSource = dtbLop;
        ddlLop.DataTextField = "Lop";
        ddlLop.DataValueField = "Lop";
        ddlLop.DataBind();
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        DataTable dtDangMuon = Loc();
        if (dtDangMuon != null)
        {
            if (dtDangMuon.DefaultView.Count == 0)
                lblNothing.Visible = true;
            else
                lblNothing.Visible = false;
        }
        else
            lblNothing.Visible = true;
        dtDangMuon.DefaultView.RowFilter = "SoNgayQuaHan >0";
        lblTotal.Text = dtDangMuon.DefaultView.Count.ToString();
        grvTaiLieu.DataSource = dtDangMuon;
        grvTaiLieu.DataBind();
    }
    private DataTable Loc()
    {
        string Khoa, Lop, SoThe, MaTaiLieu, MaXepGia;
        DateTime TuNgay, DenNgay;
        int IDKho;

        Khoa = ddlKhoas.SelectedValue;
        Lop = ddlLop.SelectedValue;
        SoThe = txtSoThe.Text.Trim();
        MaXepGia = txtMaXepGia.Text.Trim();
        MaTaiLieu = txtMaTaiLieu.Text.Trim();
        if (txtFromDate.Text.Trim() == "")
            TuNgay = DateTime.Parse("1/1/1900");
        else
            TuNgay = TVDateTime.ChuyenVietSangAnh(txtFromDate.Text.Trim());
        if (txtToDate.Text.Trim() == "")
            DenNgay = DateTime.Parse("1/1/1900");
        else
            DenNgay = TVDateTime.ChuyenVietSangAnh(txtToDate.Text.Trim());

        IDKho = (ddlKho.SelectedValue == null ? 0 : int.Parse("0" + ddlKho.SelectedValue.ToString()));
        DataTable dtDangMuon = oBTaiLieu.Get_BaoCao_DangMuon(Khoa, Lop, SoThe, TuNgay, DenNgay, MaTaiLieu, MaXepGia, IDKho);
        return dtDangMuon;
    }
    protected void grvTaiLieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTaiLieu.PageIndex = e.NewPageIndex;
        i = e.NewPageIndex * grvTaiLieu.PageSize + 1; 
        btnFind_Click(null, null);
    }

    protected void ddlKhoas_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadLop();
    }
    protected void grvTaiLieu_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        

        #region Chuẩn bị tệp excel mẫu để ghi dữ liệu
        Workbook exBook = new Workbook();
        exBook.Open(Server.MapPath("~/Template/BaoCaoAnPhamMuonQuaHan.xls"), FileFormatType.Excel2003);
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
        DataTable dtbBaoCao = Loc();
        dtbBaoCao.DefaultView.RowFilter = "SoNgayQuaHan >0";
        
        
        int DongHienTai = 5;
        // Đưa tiêu đề cột vào excel
        for (int i = 0; i < dtbBaoCao.DefaultView.Count; i++)
        {

            _exSheet.AutoFitRow(DongHienTai, 0, 9);
            // STT
            _range[DongHienTai, 0].SetStyle(styleHoTen);
            _range[DongHienTai, 0].PutValue(STT.ToString());
            _range[DongHienTai, 0].Style.Font.Size = 10;
            _range[DongHienTai, 0].Style.IsTextWrapped = true;
            _range[DongHienTai, 0].Style.HorizontalAlignment = TextAlignmentType.Center;
            //Khóa
            _range[DongHienTai, 1].SetStyle(styleHoTen);
            _range[DongHienTai, 1].PutValue(dtbBaoCao.DefaultView[i]["Khoa"].ToString());
            _range[DongHienTai, 1].Style.Font.Size = 10;
            _range[DongHienTai, 1].Style.IsTextWrapped = true;
            _range[DongHienTai, 1].Style.HorizontalAlignment = TextAlignmentType.Center;
            // Lớp
            _range[DongHienTai, 2].SetStyle(styleHoTen);
            _range[DongHienTai, 2].PutValue(dtbBaoCao.DefaultView[i]["Lop"].ToString());
            _range[DongHienTai, 2].Style.Font.Size = 10;
            _range[DongHienTai, 2].Style.IsTextWrapped = true;
            _range[DongHienTai, 2].Style.HorizontalAlignment = TextAlignmentType.Left;

            //Mã sinh vien
            _range[DongHienTai, 3].SetStyle(styleHoTen);
            _range[DongHienTai, 3].PutValue(dtbBaoCao.DefaultView[i]["TenDayDu"].ToString());
            _range[DongHienTai, 3].Style.Font.Size = 10;
            _range[DongHienTai, 3].Style.IsTextWrapped = true;
            _range[DongHienTai, 3].Style.HorizontalAlignment = TextAlignmentType.Left;
            //Ho ten
            _range[DongHienTai, 4].SetStyle(styleHoTen);
            _range[DongHienTai, 4].PutValue(dtbBaoCao.DefaultView[i]["SoThe"].ToString());
            _range[DongHienTai, 4].Style.Font.Size = 10;
            _range[DongHienTai, 4].Style.IsTextWrapped = true;
            _range[DongHienTai, 4].Style.HorizontalAlignment = TextAlignmentType.Left;

            //Nhan De
            _range[DongHienTai, 5].SetStyle(styleHoTen);
            _range[DongHienTai, 5].PutValue(dtbBaoCao.DefaultView[i]["NhanDe"].ToString());
            _range[DongHienTai, 5].Style.Font.Size = 10;
            _range[DongHienTai, 5].Style.IsTextWrapped = true;
            _range[DongHienTai, 5].Style.HorizontalAlignment = TextAlignmentType.Left;

            //Ma xep gia
            _range[DongHienTai, 6].SetStyle(styleHoTen);
            _range[DongHienTai, 6].PutValue(dtbBaoCao.DefaultView[i]["MaXepGia"].ToString());
            _range[DongHienTai, 6].Style.Font.Size = 10;
            _range[DongHienTai, 6].Style.IsTextWrapped = true;
            _range[DongHienTai, 6].Style.HorizontalAlignment = TextAlignmentType.Center;

            //Ngay muon
            _range[DongHienTai, 7].SetStyle(styleHoTen);
            _range[DongHienTai, 7].PutValue(dtbBaoCao.DefaultView[i]["NgayMuon"].ToString());
            _range[DongHienTai, 7].Style.Font.Size = 10;
            _range[DongHienTai, 7].Style.IsTextWrapped = true;
            _range[DongHienTai, 7].Style.HorizontalAlignment = TextAlignmentType.Right;

            //Ngay phai tra
            _range[DongHienTai, 8].SetStyle(styleHoTen);
            _range[DongHienTai, 8].PutValue(dtbBaoCao.DefaultView[i]["NgayPhaiTra"].ToString());
            _range[DongHienTai, 8].Style.Font.Size = 10;
            _range[DongHienTai, 8].Style.IsTextWrapped = true;
            _range[DongHienTai, 8].Style.HorizontalAlignment = TextAlignmentType.Right;

            //So ngay qua han
            _range[DongHienTai, 9].SetStyle(styleHoTen);
            _range[DongHienTai, 9].PutValue(dtbBaoCao.DefaultView[i]["SoNgayQuaHan"].ToString());
            _range[DongHienTai, 9].Style.Font.Size = 10;
            _range[DongHienTai, 9].Style.IsTextWrapped = true;
            _range[DongHienTai, 9].Style.HorizontalAlignment = TextAlignmentType.Right;
           
            DongHienTai++;
            STT++;

           
        }
        
        exBook.Save("BaoCaoAnPhamMuonQuaHan" + DateTime.Now.ToString("dd_MM_yyyy") + ".xls", FileFormatType.Excel2003, SaveType.OpenInExcel, System.Web.HttpContext.Current.Response);
        #endregion
    }
}
