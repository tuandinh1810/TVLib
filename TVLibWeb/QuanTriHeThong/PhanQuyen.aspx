<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhanQuyen.aspx.cs" Inherits="QuanTriHeThong_PhanQuyen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DLib - PHAN QUYEN CHI TIET</title>
    
</head>
<body  >
    <form id="form1" runat="server" >
    <div>
    <table width="100%">
    <tr class ="TVLibPageTitle">
    <td colspan ="3" >
    
        <asp:Label ID="Label3" runat="server" 
            Text="Phân quyền chi tiết phân hệ Bổ sung - Biên mục"></asp:Label>
    
    </td>
    </tr>
    <tr class ="TVLibFunctionTitle">
    <td width="40%">
        <asp:Label ID="Label1" runat="server" Text="Các quyền không được cấp"></asp:Label>
    </td>
    <td>
    </td>
    <td >
        <asp:Label ID="Label2" runat="server" Text="Các quyền được cấp"></asp:Label>
    </td>
    </tr>
      <tr>
    <td width="40%">
        <asp:ListBox ID="lsbKhongDuocCap" runat="server" Width="100%" Rows="10" 
            SelectionMode="Multiple"></asp:ListBox>
    </td>
    <td align ="center" >
    
        <asp:Button ID="btnAdd" runat="server" Text="&gt;&gt;" onclick="btnAdd_Click" />
        <br />
        <br />
        <asp:Button ID="btnRemove" runat="server" Text="&lt;&lt;" />
    
    </td>
    <td width="55%">
        <asp:ListBox ID="lsbDuocCap" runat="server" Width="80%" Rows="10" 
            SelectionMode="Multiple"></asp:ListBox>
    </td>
    </tr>
      <tr style="background-color:Silver">
    <td >
    </td>
    <td colspan ="2">
        &nbsp;<asp:Button ID="btnDong" runat="server" Text="Đóng" />
    </td>
    </tr>
    </table>
     <input type ="hidden"  id="hidChuoiQuyen"  runat ="server"  />
    </div>
    </form>
</body>
</html>
