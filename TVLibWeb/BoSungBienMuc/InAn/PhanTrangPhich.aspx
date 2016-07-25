<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhanTrangPhich.aspx.cs" Inherits="BoSungBienMuc_InAn_PhanTrangPhich" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <table align="center" width="400">
            <tr>
                <td style="text-align: right">
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="javascript:if (document.forms[0].txtTrangHienTai.value&gt;1) {document.forms[0].txtTrangHienTai.value=eval(document.forms[0].txtTrangHienTai.value)-1;parent.PrintPhichTraCuu.location.href='PrintPhichTraCuu.aspx?Page='+document.forms[0].txtTrangHienTai.value;void(0);}">Trang 
                    trước</asp:HyperLink>
                </td>
                <td style="text-align: right">
                    Trang số:</td>
                <td style="text-align: right">
                    <asp:TextBox ID="txtTrangHienTai" runat="server" Width="44px">1</asp:TextBox>
                </td>
                <td style="text-align: center">
                    /</td>
                <td>
                    <asp:TextBox ID="txtTongSoTrang" runat="server" ReadOnly="True" Width="44px"></asp:TextBox>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl="javascript:if (document.forms[0].txtTrangHienTai.value&lt;document.forms[0].txtTongSoTrang.value) {document.forms[0].txtTrangHienTai.value=eval(document.forms[0].txtTrangHienTai.value)+1;parent.PrintPhichTraCuu.location.href='PrintPhichTraCuu.aspx?Page='+document.forms[0].txtTrangHienTai.value;void(0);}">Trang 
                    sau</asp:HyperLink>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
