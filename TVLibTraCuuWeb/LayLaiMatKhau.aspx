<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LayLaiMatKhau.aspx.cs" Inherits="TVLibTraCuuWeb.WLayLaiMatKhau" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id ="TableFull" >
    <tr >
    <td>
        <table id ="TableCenter">
        <tr>
        <td colspan ="2">
            <asp:Label ID="Label3" runat="server" 
                Text="Bạn hãy điền đầy đủ thông tin vào đây để chương trình kiểm tra và cấp lại mật khẩu cho bạn!"></asp:Label>
        </td>
        </tr>
        <tr>
        <td align ="right" >
            <asp:Label ID="lbInfor" runat="server" Text="Mật khẩu của bạn là:" 
                Visible="False" Font-Bold="True" ForeColor="#000099"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbKetQua" runat="server" Text="123456" Visible="False" 
                Font-Bold="True" ForeColor="Red"></asp:Label>
        </td>
        </tr>
        <tr>
        <td align ="right" >
            
            <asp:Label ID="Label1" runat="server" Text="Tên đăng nhập:"></asp:Label>
            
        </td>
        <td>
            
            <asp:TextBox ID="txtTenDangNhap" runat="server"></asp:TextBox>
            
        </td>
        </tr>
        <tr>
        <td align ="right" >
            
            <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
            
        </td>
        <td>
            
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            
        </td>
        </tr>
        <tr>
        <td>
            
        </td>
        <td>
            
            <asp:Button ID="btnKetQua" runat="server" Text="Đồng ý" 
                onclick="btnKetQua_Click" />
            
        &nbsp; <a href ="WThayDoiMatKhau.aspx" runat ="server" > Thay đổi mật khẩu </a>
            
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
