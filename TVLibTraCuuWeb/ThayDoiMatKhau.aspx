<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThayDoiMatKhau.aspx.cs" Inherits="TVLibTraCuuWeb.WThayDoiMatKhau" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Thay Doi Mat Khau</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id ="TableFull">
    <tr>
    <td>
        <table id="TableCenter">
        <tr class ="TVLibPageTitle">
        <td colspan ="2">
            <asp:Label CssClass ="TVLibPageTitle" ID="Label1" runat="server" Text="Thay đổi mật khẩu" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
        <td align ="right" >
            <asp:Label ID="Label2" runat="server" Text="Tên đăng nhập:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtTenDangNhap" runat="server"></asp:TextBox>
        </td>
        </tr>
         <tr>
        <td align ="right" >
            <asp:Label ID="Label3" runat="server" Text="Mật khẩu:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        </tr>
         <tr>
        <td align ="right" >
            <asp:Label ID="Label4" runat="server" Text="Mật khẩu mới:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtMatKhauMoi" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        </tr>
          <tr>
        <td align ="right" >
            <asp:Label ID="Label5" runat="server" Text="Gõ lại mật khẩu mới:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtGoLaiMatKhauMoi" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        </tr>
        <tr >
        <td>
        </td>
        <td>
            <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" 
                onclick="btnCapNhat_Click" />
&nbsp;
            <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                Text="Làm Lại" />
        </td>
        </tr>
        </table>
    </td>
    </tr>
    </table>
    </div>
    <script language ="javascript" >
        document.forms[0].txtTenDangNhap.focus();
    </script>
    </form>
</body>
</html>
