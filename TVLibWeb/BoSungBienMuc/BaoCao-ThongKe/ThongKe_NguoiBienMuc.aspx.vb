﻿Imports TruongViet.TVLib.Business
Imports TruongViet.TVLib.Entity
Imports System.Data
Imports System.String

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

End Class