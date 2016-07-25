
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblImage.Text = "<img border=0 src='" + Request.ApplicationPath + "Resources/Images/TVLib_TraCuu_TaiChinhThaiNguyen.png'/>"


    End Sub
End Class

