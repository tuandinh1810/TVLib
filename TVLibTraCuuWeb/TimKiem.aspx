<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimKiem.aspx.cs" Inherits="TVLibTraCuuWeb.WSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
   <table width ="100%">
   <tr class ="TVLibPageTitle">
   <td colspan ="2" align="center"  >
       <%--
       <asp:Label ID="Label1" runat="server" CssClass="TVLibPageTitle" 
           Text="Tìm kiếm tài liệu điện tử" Width="100%"></asp:Label>--%>
   </td>
   </tr>
    <tr>
   <td width="35%" align ="right" >
       <asp:DropDownList ID="ddlFieldName" runat="server" >
                                    <asp:ListItem Value="0">Mọi trường</asp:ListItem>
                                    <asp:ListItem Value="1">Nhan đề</asp:ListItem>
                                    <asp:ListItem Value="2">Tác giả</asp:ListItem>
                                    <asp:ListItem Value="3">Đồng tác giả</asp:ListItem>
                                    <asp:ListItem Value="4">Mô tả</asp:ListItem>
                                    <asp:ListItem Value="5">Nhà xuất bản</asp:ListItem>
                                    <asp:ListItem Value="8">Từ khóa</asp:ListItem>
                                </asp:DropDownList>
   </td>
   <td>
       <asp:TextBox ID="txtSearch" runat="server" Width="60%"></asp:TextBox>
   </td>
   </tr>
    <tr>
  <td width="35%" align ="right" >
       <asp:DropDownList ID="ddlToanTu" runat="server">
           <asp:ListItem Value="1">AND</asp:ListItem>
           <asp:ListItem Value="2">OR</asp:ListItem>
           <asp:ListItem Value="3">NOT</asp:ListItem>
       </asp:DropDownList>
        <asp:DropDownList ID="ddlFieldName1" runat="server">
                                    <asp:ListItem Value="0">Mọi trường</asp:ListItem>
                                    <asp:ListItem Value="1">Nhan đề</asp:ListItem>
                                    <asp:ListItem Value="2">Tác giả</asp:ListItem>
                                      <asp:ListItem Value="3">Đồng tác giả</asp:ListItem>
                                    <asp:ListItem Value="4">Mô tả</asp:ListItem>
                                    <asp:ListItem Value="5">Nhà xuất bản</asp:ListItem>
                                    <asp:ListItem Value="8">Từ khóa</asp:ListItem>
                                </asp:DropDownList>
   </td>
   <td>
       <asp:TextBox ID="txtSearch1" runat="server" Width="60%"></asp:TextBox>
   </td>
   </tr>
    <tr>
   <td width="35%" align ="right" >
       <asp:DropDownList ID="ddlToanTu1" runat="server">
           <asp:ListItem Value="1">AND</asp:ListItem>
           <asp:ListItem Value="2">OR</asp:ListItem>
           <asp:ListItem Value="3">NOT</asp:ListItem>
       </asp:DropDownList>
       <asp:DropDownList ID="ddlFieldName2" runat="server">
                                    <asp:ListItem Value="0">Mọi trường</asp:ListItem>
                                    <asp:ListItem Value="1">Nhan đề</asp:ListItem>
                                    <asp:ListItem Value="2">Tác giả</asp:ListItem>
                                    <asp:ListItem Value="3">Đồng tác giả</asp:ListItem>
                                    <asp:ListItem Value="4">Mô tả</asp:ListItem>
                                    <asp:ListItem Value="5">Nhà xuất bản</asp:ListItem>
                                    <asp:ListItem Value="8">Từ khóa</asp:ListItem>
                                </asp:DropDownList>
   </td>
   <td>
       <asp:TextBox ID="txtSearch2" runat="server" Width="60%"></asp:TextBox>
   </td>
   </tr>
    <tr>
   <td>
   </td>
   <td>
       <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" 
           onclick="btnTimKiem_Click" />
&nbsp;
       <asp:Button ID="btnCancel" runat="server" Text="Hủy bỏ" 
           onclick="btnCancel_Click" />
   </td>
   </tr>
   </table>
    </form>
</body>
</html>
