<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangKy.aspx.cs" Inherits="TVLibTraCuuWeb.WDangKy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Quan Ly Tai Khoan</title>
   </head>
<body style="margin-left:0;margin-top:0;">
    <form id="form1" runat="server">
    <div>
 <table ID="TableFull" cellspacing="0" cellpadding="0" width ="100%" >
 <tr>
    <td>
    <table ID ="TableCenter" cellpadding="10" cellspacing="10">
    <tr class="TVLibPageTitle" style="height:25px">
    <td colspan ="4">&nbsp;&nbsp;&nbsp;Đăng ký tài khoản
    </td>
    </tr>
    <tr>
    <td align="right" width="15%" >
        <asp:Label ID="Label1" runat="server" Text="Tên tài khoản:"></asp:Label>
    </td>
     <td width="30%" style="color: #FF0000" >
         <asp:TextBox ID="txtTenDayDu" runat="server" TabIndex="1" ></asp:TextBox>
    &nbsp;(*)</td>
     <td align="right" width="10%" >
        <asp:Label ID="Label3" runat="server" Text="Địa chỉ:"></asp:Label>
    </td>
     <td style="color: #FF0000">
         <asp:TextBox ID="txtDiaChi" runat="server" TabIndex="7" Width="70%"></asp:TextBox>
    &nbsp;(*)</td>
    </tr>
    <tr>
    <td align="right" class="style5">
         <asp:Label ID="Label2" runat="server" Text="Giới tính:"></asp:Label>
    </td>
     <td class="style5" style="color: #FF0000">
         <asp:DropDownList ID="drdlGioiTinh" runat="server" TabIndex="2">
             <asp:ListItem Value="0">Nam</asp:ListItem>
             <asp:ListItem Value="1">Nữ</asp:ListItem>
         </asp:DropDownList>
         (*)</td>
     <td align="right" class="style5">
         <asp:Label ID="Label4" runat="server" Text="Đơn vị:"></asp:Label>
    </td>
     <td class="style5">
         <asp:TextBox ID="txtDonVi" runat="server" TabIndex="8" Width="60%"></asp:TextBox>
                    </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="Label9" runat="server" Text="Mã tài khoản:"></asp:Label>
    </td>
     <td style="color: #FF0000">
         <asp:TextBox ID="txtTenDangNhap" runat="server" TabIndex="3"></asp:TextBox>
         &nbsp;(*)</td>
     <td align="right">
        <asp:Label ID="Label5" runat="server" Text="Phòng ban:"></asp:Label>
    </td>
     <td>
         <asp:TextBox ID="txtPhongBan" runat="server" TabIndex="11" Width="50%"></asp:TextBox>
         </td>
    </tr>
    <tr>
    <td align="right">
         <asp:Label ID="Label10" runat="server" Text="Mật khẩu:"></asp:Label>
    </td>
     <td style="color: #FF0000">
         <asp:TextBox ID="txtMatKhau" runat="server" TabIndex="4" TextMode="Password"></asp:TextBox>
         &nbsp;(*)</td>
     <td align="right">
        <asp:Label ID="Label7" runat="server" Text="Điện thoại:"></asp:Label>
    </td>
     <td>
         <asp:TextBox ID="txtDienThoai" runat="server" TabIndex="9"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td align="right" class="style2">
        <asp:Label ID="Label13" runat="server" Text="Gõ lại mật khẩu:"></asp:Label>
    </td>
     <td class="style2" style="color: #FF0000">
         <asp:TextBox ID="txtGoLaiMatKhau" runat="server" TabIndex="5" Height="21px" 
             TextMode="Password"></asp:TextBox>
         &nbsp;(*)</td>
     <td align="right" class="style2" rowspan ="2">
         <asp:Label ID="Label14" runat="server" Text="Ghi chú:"></asp:Label>
    </td>
     <td class="style2" rowspan ="2">
         <asp:TextBox ID="txtGhiChu" runat="server" Rows="3" TextMode="MultiLine" 
             Width="251px" TabIndex="10"></asp:TextBox>
                    </td>
    </tr>
    <tr>
    <td align="right" class="style4">
         <asp:Label ID="Label6" runat="server" Text="Email:"></asp:Label>
    </td>
     <td class="style4" style="color: #FF0000">
         <asp:TextBox ID="txtEmail" runat="server" TabIndex="6"></asp:TextBox>
    &nbsp;(*)</td>
   
    </tr>   
    
    <tr >
    <td colspan ="4" align ="center" >
    
         <asp:Button ID="btnUpdate" runat="server" Text="Đăng ký" TabIndex="13" onclick="btnUpdate_Click" 
              />&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="btnCancel" runat="server" Text="Làm lại" TabIndex="14" 
            />
    
    </td>
    </tr>
    
    </table>
    </td>
    </tr>
    </table>
    </div>
    <input type ="hidden" value ="" runat ="server" id ="hidTaiKhoanID" />
    <input type ="hidden" value ="" runat ="server" id ="hidPassword" />
    <script language ="javascript" >
        document.forms[0].txtTenDayDu.focus();
    </script>
    </form>
</body>
</html>

