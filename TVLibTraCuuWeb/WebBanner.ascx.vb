Imports TruongViet.DataAccess

Partial Class WebBanner
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Put user code to initialize the page here
        'txtSearch.Attributes.Add("onkeypress", "if ((window.event.keyCode==13) && (this.value != 'Tìm kiếm')) {document.location.href='Default.aspx?KeyWord='+this.value;return false;}")
        ''ImgBtnSearch.Attributes.Add("onclick", "if (document.forms[0].txtSearch.value!='Tìm kiếm') document.location.href='Default.aspx?KeyWord='+document.forms[0].txtSearch.value;return false;")
        'If Request("KeyWord") & "" <> "" Then
        '    txtSearch.Text = Request("KeyWord")
        'End If
    End Sub
   
End Class
