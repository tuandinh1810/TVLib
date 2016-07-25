Imports TruongViet.TVLib.Business
Imports TruongViet.TVLib.Entity
Imports System.Data
Imports System.String
Imports Aspose.Cells
Imports System.Drawing

Partial Class BoSungBienMuc_ThongKe_NguoiBienMuc

    Inherits WebBase
    Private objStream As Object
    Private objMapImg As Object
    Private ObjBarCodeImg As Object
    Private intVHeight As Integer
    Private intVLong As Integer
    Private intWchart As Integer
    Private intHchart As Integer
    Private objChartDir As Object 'ChartDirector.API
    Private objNguoiDung As New cBNguoiDung
    Private objNguoiDungInfo As New NguoiDungInfo
    Private _range As Cells
    Private _exSheet As Worksheet

    Public Function MakebarchartLarge(ByVal ArrData As Object, ByVal ArrLabel As Object, ByVal strHtitle As String, ByVal strVtitle As String, ByVal bytAngle As Byte, ByVal strFullPathImg As String, ByVal strFileChart As String, Optional ByVal strURL As String = "") As Object

        'Dim objChartDir As Object
        Dim intHeight As Integer
        Dim intLong As Integer
        Dim intWchart As Integer
        Dim intHchart As Integer
        Dim objChart As Object ' ChartDirector.XYChart
        objChartDir = CreateObject("ChartDirector.API")

        If UBound(ArrData) <= 15 Then
            intHeight = 300
            intLong = 600
            intWchart = 500
            intHchart = 250
        Else
            intHeight = 420
            intLong = 700
            intWchart = 600
            intHchart = 410
        End If
        If bytAngle = 0 Then
        Else
            intHeight = 400
        End If
        objChart = objChartDir.XYChart(intLong, intHeight)

        objChart.setPlotArea(70, 30, intWchart, intHchart)
        objChart.setWallpaper(strFullPathImg)
        objChart.YAxis().setTitle(strHtitle, , 12, 128)
        objChart.XAxis().setTitle(strVtitle, , 12, 128)
        Dim layer As Object ' ChartDirector.BarLayer
        layer = objChart.addBarLayer(ArrData, &HC3C3E6)
        layer.setAggregateLabelStyle("Arial.ttf", 12, 12).setBackground(&HFFCC66, objChartDir.Transparent, 1)
        layer.set3D()
        objChart.XAxis().setLabels(ArrLabel)

        If bytAngle > 0 Then
            objChart.XAxis().setLabelStyle("", 8).setFontAngle(bytAngle)
        End If

        objStream = objChart.makeChart2(objChartDir.GIF) '
        objMapImg = objChart.getHTMLImageMap(strFileChart, strURL)        '
        'objChartDir = Nothing
        objChart = Nothing
        MakebarchartLarge = objStream
    End Function
    Protected Sub LoadJs()
        Page.RegisterClientScriptBlock("Js", "<script language='javascript' src='../../Resources/Js/TVLib.js'></script>")
        btnThongKe.Attributes.Add("Onclick", "if(CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtFromDate,'Không đúng kiểu định dạng ngày tháng!')== false ||  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txToDate,'Không đúng kiểu định dạng ngày tháng!')== false ){return false;}")
    End Sub
    Protected Sub btnLoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnThongKe.Click
        If (txToDate.Text.Trim() = "" And txtFromDate.Text = "") Then
            ThongBao("Bạn chưa điền đủ thông tin")
            txtFromDate.Focus()
        Else
            DrawTop20Stat()
            Page.RegisterStartupScript("Hehe", "<Script>GenURLImg1(9)</Script>")
        End If
    End Sub

    Private Sub DrawTop20Stat()
        Dim arrData As String()
        Dim arrLabel As String()
        Dim strImage As String
        Dim strVTitle As String
        Dim strHTitle1 As String
        Dim strHTitle2 As String
        Dim objTemp As New cBFile_TruongDublin
        Dim objTaiLieu As New cBTaiLieu()
        Dim dtbThongKe As New DataTable
        dtbThongKe = objTemp.RunSql("Select * from NguoiDung")
        ' dtbThongKe = objFile.GetTopDowLoad(txtThoiGian.Text, drdlThang.SelectedValue, txtNam.Text.Trim)
        ' ***************** Get the top Item statistic **************
        If dtbThongKe.Rows.Count > 0 Then
            ReDim arrData(dtbThongKe.Rows.Count - 1)
            ReDim arrLabel(dtbThongKe.Rows.Count - 1)

            For intRowIndex = 0 To dtbThongKe.Rows.Count - 1
                arrData(intRowIndex) = objTaiLieu.GetSoLuongTaiLieu(txtFromDate.Text.Trim(), txToDate.Text.Trim(), CInt(dtbThongKe.Rows(intRowIndex).Item("NguoiDungID"))).Rows(0)(0).ToString()
                arrLabel(intRowIndex) = dtbThongKe.Rows(intRowIndex).Item("TenDangNHap")
            Next
        End If
        strImage = Server.MapPath("../Resources/Images/bground.gif")
        strVTitle = "Số lượng tài liệu đã biên mục"
        strHTitle1 = "Người biên mục"
        strHTitle2 = ""

        If Not arrData Is Nothing Then
            If UBound(arrData) > -1 Then
                Try
                    Session("chart1") = MakebarchartLarge(arrData, arrLabel, strVTitle, strHTitle1, 15, strImage, "", "")

                    Dim strOutput As String
                    strOutput = objMapImg
                    'strOutput = Replace(strOutput, "xLabel", "")
                    'strOutput = Replace(strOutput, "xLabel", "")
                    strOutput = strOutput.Replace("xLabel", "")
                    Response.Write("<MAP NAME=""map1"">" & strOutput & "</MAP>")

                    'Catch
                Finally
                End Try
            Else
                Session("chart1") = Nothing
                Session("chart2") = Nothing

            End If
        Else
            Session("chart1") = Nothing
            Session("chart2") = Nothing
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadJs()
    End Sub

    Protected Sub btnXuatExcel_Click(sender As Object, e As EventArgs) Handles btnXuatExcel.Click
        If (txToDate.Text.Trim() = "" And txtFromDate.Text = "") Then
            ThongBao("Bạn chưa điền đủ thông tin")
            txtFromDate.Focus()

        Else
            Dim dtbThongKe As New DataTable
            Dim objTaiLieu As New cBTaiLieu
            Dim dateTuNgay As DateTime
            Dim dateDenNgay As DateTime
            If (txtFromDate.Text = "") Then
                dateTuNgay = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", Nothing)
            Else
                dateTuNgay = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", Nothing)

            End If
            If (txToDate.Text = "") Then
                dateDenNgay = DateTime.MaxValue
            Else
                dateDenNgay = DateTime.ParseExact(txToDate.Text, "dd/MM/yyyy", Nothing)

            End If
            dtbThongKe = objTaiLieu.GetSoLuongTaiLieuByUser(dateTuNgay, dateDenNgay)


            ' *****************  Chuẩn bị tệp excel mẫu để ghi dữ liệu*******************
            Dim exBook As New Workbook()
            exBook.Open(Server.MapPath("~/Template/BaoCaoNguoiBienMuc.xls"), FileFormatType.Excel2003)
            _exSheet = exBook.Worksheets(0)
            _range = _exSheet.Cells






            Dim now = DateTime.Now
            Dim STT As Integer = 1
            ' Xử lý thêm tiêu đề cột

            'Tiêu đề
            Dim style As Aspose.Cells.Style = _range("P2").GetStyle()
            style.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Thin
            style.Borders(BorderType.TopBorder).Color = Color.Black
            style.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Thin
            style.Borders(BorderType.BottomBorder).Color = Color.Black
            style.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Thin
            style.Borders(BorderType.LeftBorder).Color = Color.Black
            style.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Thin
            style.Borders(BorderType.RightBorder).Color = Color.Black
            style.Font.Size = 10
            style.Font.Name = "Times New Roman"

            Dim styleHoTen As Aspose.Cells.Style = _range("P2").GetStyle()


            styleHoTen.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Thin
            styleHoTen.Borders(BorderType.TopBorder).Color = Color.Black
            styleHoTen.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Thin
            styleHoTen.Borders(BorderType.BottomBorder).Color = Color.Black
            styleHoTen.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Thin
            styleHoTen.Borders(BorderType.LeftBorder).Color = Color.Black
            styleHoTen.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Thin
            styleHoTen.Borders(BorderType.RightBorder).Color = Color.Black
            styleHoTen.VerticalAlignment = TextAlignmentType.CenterAcross
            styleHoTen.HorizontalAlignment = TextAlignmentType.Left
            styleHoTen.Font.IsBold = False
            styleHoTen.Font.Name = "Times New Roman"
            styleHoTen.Font.Size = 10

            Dim styleTien As Aspose.Cells.Style = _range("P2").GetStyle()


            styleTien.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Thin
            styleTien.Borders(BorderType.TopBorder).Color = Color.Black
            styleTien.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Thin
            styleTien.Borders(BorderType.BottomBorder).Color = Color.Black
            styleTien.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Thin
            styleTien.Borders(BorderType.LeftBorder).Color = Color.Black
            styleTien.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Thin
            styleTien.Borders(BorderType.RightBorder).Color = Color.Black
            styleTien.VerticalAlignment = TextAlignmentType.CenterAcross
            styleTien.HorizontalAlignment = TextAlignmentType.Right
            styleTien.[Custom] = "#,##0"
            styleTien.Font.IsBold = False
            styleTien.Font.Name = "Times New Roman"
            styleTien.Font.Size = 10

            Dim styleHeSo As Aspose.Cells.Style = _range("P2").GetStyle()


            styleHeSo.Borders(BorderType.TopBorder).LineStyle = CellBorderType.Thin
            styleHeSo.Borders(BorderType.TopBorder).Color = Color.Black
            styleHeSo.Borders(BorderType.BottomBorder).LineStyle = CellBorderType.Thin
            styleHeSo.Borders(BorderType.BottomBorder).Color = Color.Black
            styleHeSo.Borders(BorderType.LeftBorder).LineStyle = CellBorderType.Thin
            styleHeSo.Borders(BorderType.LeftBorder).Color = Color.Black
            styleHeSo.Borders(BorderType.RightBorder).LineStyle = CellBorderType.Thin
            styleHeSo.Borders(BorderType.RightBorder).Color = Color.Black
            styleHeSo.VerticalAlignment = TextAlignmentType.CenterAcross
            styleHeSo.HorizontalAlignment = TextAlignmentType.Right
            styleHeSo.[Custom] = "#,##0.0"
            styleHeSo.Font.IsBold = False
            styleHeSo.Font.Name = "Times New Roman"
            styleHeSo.Font.Size = 10



            Dim DongHienTai As Integer = 5
            ' Đưa tiêu đề cột vào excel
            For i As Integer = 0 To dtbThongKe.Rows.Count - 1
                ' STT
                _range(DongHienTai, 0).SetStyle(styleHoTen)
                _range(DongHienTai, 0).PutValue(STT.ToString())
                _range(DongHienTai, 0).Style.Font.Size = 11
                _range(DongHienTai, 0).Style.IsTextWrapped = True
                _range(DongHienTai, 0).Style.HorizontalAlignment = TextAlignmentType.Center
                'Ten kho
                _range(DongHienTai, 1).SetStyle(styleHoTen)
                _range(DongHienTai, 1).PutValue(dtbThongKe.Rows(i)("TenNguoiDung").ToString())
                _range(DongHienTai, 1).Style.Font.Size = 11
                _range(DongHienTai, 1).Style.IsTextWrapped = True
                _range(DongHienTai, 1).Style.HorizontalAlignment = TextAlignmentType.Left

                'Số lượng
                _range(DongHienTai, 2).SetStyle(styleHoTen)
                _range(DongHienTai, 2).PutValue(dtbThongKe.Rows(i)("SL").ToString())
                _range(DongHienTai, 2).Style.Font.Size = 11
                _range(DongHienTai, 2).Style.IsTextWrapped = True
                _range(DongHienTai, 2).Style.HorizontalAlignment = TextAlignmentType.Right
                DongHienTai += 1

                ' TongTienLuongBinhThuong += double.Parse("0" + dtbThongKe.Rows[i]["LuongBinhThuong"]);
                ' TongTienLuongThemGio += double.Parse("0" + dtbThongKe.Rows[i]["LuongThemGio"]);
                STT += 1
            Next
            System.Web.HttpContext.Current.Response.Clear()

            exBook.Save("BaoCaoNguoiBienMuc" & DateTime.Now.ToString("dd_MM_yyyy") & ".xls", FileFormatType.Excel2003, SaveType.OpenInExcel, System.Web.HttpContext.Current.Response)

        End If

      
    End Sub
End Class