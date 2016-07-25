
Partial Class BoSungBienMuc_Chart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.ContentType = "images/gif"
        If Not Session("chart1") Is Nothing Then
            Response.BinaryWrite(Session("chart1"))
        End If
    End Sub
End Class
