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
public partial class LuuThong_BaoCao_ThongKe_ThongKeLuotBanDocPhongDocMo : WebBase
{
    private cBTaiLieu oBTaiLieu;
    private cBKho oBKho;
    cBBanDoc oBBanDoc;
    BanDocInfo oBanDocInfo;
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
            LoadThang();
            LoadNam();
            LoadKhoas();
            LoadLop();
        }
    }
    private void LoadThang()
    {
        _ddlThang.Items.Clear();
        for (int i = 1; i <= 12; i++)
            _ddlThang.Items.Add(new ListItem(i.ToString(), i.ToString()));
        _ddlThang.SelectedValue = DateTime.Now.Month.ToString();
    }
    private void LoadNam()
    {
        _ddlNam.Items.Clear();
        for (int i = DateTime.Now.Year + 1; i >= DateTime.Now.Year - 3; i--)
            _ddlNam.Items.Add(new ListItem(i.ToString(), i.ToString()));
        _ddlNam.SelectedValue = DateTime.Now.Year.ToString();
    }
    private void Loc(int Thang, int Nam)
    {
        //Tao bang tam
        DataTable dtbThongKe = new DataTable();
        dtbThongKe.Columns.Add("Lop", typeof(string));
        dtbThongKe.Columns.Add("Khoa", typeof(string));
        dtbThongKe.Columns.Add("TenDayDu", typeof(string));
        dtbThongKe.Columns.Add("MaThe", typeof(string));
        dtbThongKe.Columns.Add("TongSoGio", typeof(string));
        //Add bound field
        grvTaiLieu.Columns.Clear();
        BoundField bfield = new BoundField();
        bfield.HeaderText = "Khóa";
        bfield.DataField = "Khoa";
        bfield.ItemStyle.Width = Unit.Pixel(10);
        grvTaiLieu.Columns.Add(bfield);
        //Add lop
        bfield = new BoundField();
        bfield.HeaderText = "Lớp";
        bfield.DataField = "Lop";
        bfield.ItemStyle.Width = Unit.Pixel(100);
        grvTaiLieu.Columns.Add(bfield);
        //Add Ma sinh vien
        bfield = new BoundField();
        bfield.HeaderText = "Mã SV";
        bfield.DataField = "MaThe";
        bfield.ItemStyle.Width = Unit.Pixel(100);
        grvTaiLieu.Columns.Add(bfield);
        bfield = new BoundField();
        bfield.HeaderText = "Tên";
        bfield.DataField = "TenDayDu";
        bfield.ItemStyle.Width = Unit.Pixel(600);

        grvTaiLieu.Columns.Add(bfield);
        //// add Tong so tai lieu 
        bfield = new BoundField();
        bfield.HeaderText = "Tổng";
        bfield.DataField = "TongSoGio";
        bfield.ItemStyle.Width = Unit.Pixel(50);
        bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
        grvTaiLieu.Columns.Add(bfield);


        //Add them cac cot ngay trong thang
        for (int i = 1; i < 32; i++)
        {

            string strNgay = "";
            if (i < 10)
                strNgay = "0" + i.ToString();
            else
                strNgay = i.ToString();
            bfield = new BoundField();
            bfield.HeaderText = strNgay;
            bfield.DataField = i.ToString();
            bfield.ItemStyle.Width = Unit.Pixel(50);
            bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            grvTaiLieu.Columns.Add(bfield);
            dtbThongKe.Columns.Add(i.ToString(), typeof(string));
        }
        string Khoa="";
        string Lop = "";
        if (ddlKhoas.SelectedValue + "" != "")
            Khoa = ddlKhoas.SelectedValue.ToString();
        if (ddlLop.SelectedValue + "" != "")
            Lop = ddlLop.SelectedValue.ToString();
        DataTable dtbTemp = oBBanDoc.ThongKeLuotBanDoc_PhongDoc(Thang, Nam,Khoa,Lop,txtSoThe.Text);
        DataRow dr = null;
        float intTong = 0;
        if (dtbTemp.Rows.Count > 0)
        {
            for (int i = 0; i < dtbTemp.Rows.Count; i++)
            {

                if (dr == null)
                {
                    dr = dtbThongKe.NewRow();
                    //SoLuongTheoKho = 0;
                }
                else if (dr["MaThe"].ToString().Trim() != dtbTemp.Rows[i]["MaThe"].ToString().Trim())
                {
                    dtbThongKe.Rows.Add(dr);
                    dr = dtbThongKe.NewRow();
                    //SoLuongTheoKho = 0;
                }
                dr["TongSoGio"] = dtbTemp.Rows[i]["TongSoGio"].ToString();
                dr["Lop"] = dtbTemp.Rows[i]["Lop"].ToString();
                dr["Khoa"] = dtbTemp.Rows[i]["Khoa"].ToString();
                dr["TenDayDu"] = dtbTemp.Rows[i]["TenDayDu"].ToString();
                dr["MaThe"] = dtbTemp.Rows[i]["MaThe"].ToString();
                dr[dtbTemp.Rows[i]["Ngay"].ToString()] = dtbTemp.Rows[i]["SoGio"].ToString();
                intTong += float.Parse("0" + dtbTemp.Rows[i]["SoGio"].ToString());

                //dr["ChenhLech"] = int.Parse("0" + dr["Tong"]) - SoLuongTheoKho - int.Parse("0" + dtbTemp.Rows[i]["TongSoMuon"].ToString());
            }
            dtbThongKe.Rows.Add(dr);
        }
        if (dtbThongKe.Rows.Count > 0)
        {
            lblTotal.Text = intTong.ToString();
            grvTaiLieu.DataSource = dtbThongKe;
            grvTaiLieu.DataBind();
        }
        else
        {
            grvTaiLieu.DataSource = null;
            grvTaiLieu.DataBind();
        }

    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        if (_ddlThang.SelectedValue + "" != "" && _ddlThang.SelectedValue + "" != "")
            Loc(int.Parse("0" + _ddlThang.SelectedValue.ToString()), int.Parse("0" + _ddlNam.SelectedValue.ToString()));
    }
    protected void grvTaiLieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTaiLieu.PageIndex = e.NewPageIndex;
        btnFind_Click(null, null);
    }

    protected void ddlKhoas_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadLop();
    }
    private void LoadKhoas()
    {
        DataTable dtbKhoas = InsertOneRow(oBBanDoc.GetKhoas(oBanDocInfo), "", 0, 0);
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
    protected void btnFind_Click1(object sender, EventArgs e)
    {

    }
    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        int Thang = int.Parse("0" + _ddlThang.SelectedValue);
        int Nam = int.Parse("0" + _ddlNam.SelectedValue);
        #region Chuan bi du lieu
        DataTable dtbThongKe = new DataTable();
        dtbThongKe.Columns.Add("Lop", typeof(string));
        dtbThongKe.Columns.Add("Khoa", typeof(string));
        dtbThongKe.Columns.Add("TenDayDu", typeof(string));
        dtbThongKe.Columns.Add("MaThe", typeof(string));
        dtbThongKe.Columns.Add("TongSo", typeof(string));

        //Add them cac cot ngay trong thang
        for (int i = 1; i < 32; i++)
        {
            dtbThongKe.Columns.Add(i.ToString(), typeof(string));
        }
        string Khoa = "";
        string Lop = "";
        if (ddlKhoas.SelectedValue + "" != "")
            Khoa = ddlKhoas.SelectedValue.ToString();
        if (ddlLop.SelectedValue + "" != "")
            Lop = ddlLop.SelectedValue.ToString();
        DataTable dtbTemp = oBBanDoc.ThongKeLuotBanDoc_PhongDoc(Thang, Nam, Khoa, Lop, txtSoThe.Text);
        DataRow dr = null;
        float intTong = 0;
        if (dtbTemp.Rows.Count > 0)
        {
            for (int i = 0; i < dtbTemp.Rows.Count; i++)
            {

                if (dr == null)
                {
                    dr = dtbThongKe.NewRow();
                    //SoLuongTheoKho = 0;
                }
                else if (dr["MaThe"].ToString().Trim() != dtbTemp.Rows[i]["MaThe"].ToString().Trim())
                {
                    dtbThongKe.Rows.Add(dr);
                    dr = dtbThongKe.NewRow();
                    //SoLuongTheoKho = 0;
                }
                dr["TongSo"] = dtbTemp.Rows[i]["TongSoGio"].ToString();
                dr["Lop"] = dtbTemp.Rows[i]["Lop"].ToString();
                dr["Khoa"] = dtbTemp.Rows[i]["Khoa"].ToString();
                dr["TenDayDu"] = dtbTemp.Rows[i]["TenDayDu"].ToString();
                dr["MaThe"] = dtbTemp.Rows[i]["MaThe"].ToString();
                dr[dtbTemp.Rows[i]["Ngay"].ToString()] = dtbTemp.Rows[i]["SoGio"].ToString();
                intTong += float.Parse("0" + dtbTemp.Rows[i]["SoGio"].ToString());

                //dr["ChenhLech"] = int.Parse("0" + dr["Tong"]) - SoLuongTheoKho - int.Parse("0" + dtbTemp.Rows[i]["TongSoMuon"].ToString());
            }
            dtbThongKe.Rows.Add(dr);
        }
        #endregion

        #region Chuẩn bị tệp excel mẫu để ghi dữ liệu
        Workbook exBook = new Workbook();
        exBook.Open(Server.MapPath("~/Template/BaoCaoSoLuotBanDoc.xls"), FileFormatType.Excel2003);
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

        int DongHienTai = 6;
        // Đưa tiêu đề cột vào excel
        for (int i = 0; i < dtbThongKe.Rows.Count; i++)
        {
            // STT
            _range[DongHienTai, 0].SetStyle(styleHoTen);
            _range[DongHienTai, 0].PutValue(STT.ToString());
            _range[DongHienTai, 0].Style.Font.Size = 10;
            _range[DongHienTai, 0].Style.IsTextWrapped = true;
            _range[DongHienTai, 0].Style.HorizontalAlignment = TextAlignmentType.Center;
            //Khóa
            _range[DongHienTai, 1].SetStyle(styleHoTen);
            _range[DongHienTai, 1].PutValue(dtbThongKe.Rows[i]["Khoa"].ToString());
            _range[DongHienTai, 1].Style.Font.Size = 10;
            _range[DongHienTai, 1].Style.IsTextWrapped = true;
            _range[DongHienTai, 1].Style.HorizontalAlignment = TextAlignmentType.Center;
            // Lớp
            _range[DongHienTai, 2].SetStyle(styleHoTen);
            _range[DongHienTai, 2].PutValue(dtbThongKe.Rows[i]["Lop"].ToString());
            _range[DongHienTai, 2].Style.Font.Size = 10;
            _range[DongHienTai, 2].Style.IsTextWrapped = true;
            _range[DongHienTai, 2].Style.HorizontalAlignment = TextAlignmentType.Left;

            //Mã sinh vien
            _range[DongHienTai, 3].SetStyle(styleHoTen);
            _range[DongHienTai, 3].PutValue(dtbThongKe.Rows[i]["MaThe"].ToString());
            _range[DongHienTai, 3].Style.Font.Size = 10;
            _range[DongHienTai, 3].Style.IsTextWrapped = true;
            _range[DongHienTai, 3].Style.HorizontalAlignment = TextAlignmentType.Left;
            //Ho ten
            _range[DongHienTai, 4].SetStyle(styleHoTen);
            _range[DongHienTai, 4].PutValue(dtbThongKe.Rows[i]["TenDayDu"].ToString());
            _range[DongHienTai, 4].Style.Font.Size = 10;
            _range[DongHienTai, 4].Style.IsTextWrapped = true;
            _range[DongHienTai, 4].Style.HorizontalAlignment = TextAlignmentType.Left;
            //Tong
            _range[DongHienTai, 5].SetStyle(styleHoTen);
            _range[DongHienTai, 5].PutValue(dtbThongKe.Rows[i]["TongSo"].ToString());
            _range[DongHienTai, 5].Style.Font.Size = 10;
            _range[DongHienTai, 5].Style.IsTextWrapped = true;
            _range[DongHienTai, 5].Style.HorizontalAlignment = TextAlignmentType.Right;
            //Ngay
            for (int j = 1; j < 32; j++)
            {
                int cot = j + 5;
                _range[DongHienTai, cot].SetStyle(styleHoTen);
                _range[DongHienTai, cot].PutValue(dtbThongKe.Rows[i][j.ToString()].ToString());
                _range[DongHienTai, cot].Style.Font.Size = 10;
                _range[DongHienTai, cot].Style.IsTextWrapped = true;
                _range[DongHienTai, cot].Style.HorizontalAlignment = TextAlignmentType.Right;
            }
                DongHienTai++;
            STT++;

           // TongTienLuongBinhThuong += double.Parse("0" + dtbThongKe.Rows[i]["LuongBinhThuong"]);
           // TongTienLuongThemGio += double.Parse("0" + dtbThongKe.Rows[i]["LuongThemGio"]);
        }
        //for (int j = 0; j <= 3; j++)
        //{
        //    _range[DongHienTai, j].SetStyle(styleHoTen);
        //}

        //_range[DongHienTai, 0].PutValue("TT:");
        //_range[DongHienTai, 0].Style.Font.IsBold = true;
        //_range[DongHienTai, 0].Style.HorizontalAlignment = TextAlignmentType.Center;

        //_range[DongHienTai, 1].PutValue("");
        //_range[DongHienTai, 1].Style.Font.IsBold = true;
        //_range[DongHienTai, 1].Style.HorizontalAlignment = TextAlignmentType.Center;


        //_range[DongHienTai, 2].PutValue(TongTienLuongBinhThuong.ToString("###,###"));
        //_range[DongHienTai, 2].Style.Font.IsBold = true;
        //_range[DongHienTai, 2].Style.HorizontalAlignment = TextAlignmentType.Right;

        //_range[DongHienTai, 3].PutValue(TongTienLuongThemGio.ToString("###,###"));
        //_range[DongHienTai, 3].Style.Font.IsBold = true;
        //_range[DongHienTai, 3].Style.HorizontalAlignment = TextAlignmentType.Right;
        exBook.Save("BaoCaoSoLuotBanDoc" + DateTime.Now.ToString("dd_MM_yyyy") + ".xls", FileFormatType.Excel2003, SaveType.OpenInExcel, System.Web.HttpContext.Current.Response);
        #endregion
    }
}
