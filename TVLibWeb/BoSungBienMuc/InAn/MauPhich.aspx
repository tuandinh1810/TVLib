﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MauPhich.aspx.cs" Inherits="MauPhich" ValidateRequest="false" MasterPageFile="~/MasterPage.master" %>
<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body style="margin-top:0;">

    <table align="center" width="970px" >
        <tr class="TVLibPageTitle">
        <td colspan="2">
        <asp:Label ID="Label1" runat="server" Text="KHUÔN DẠNG MẪU PHÍCH"></asp:Label>
    </td>
   
    </tr>
    <tr>
    <td colspan="2">
    
    </td>
    </tr>
    <tr>
    <td>
     <asp:Label ID="Label3" runat="server" Text="Chọn Mẫu: "></asp:Label></td>
        <td>
      <asp:DropDownList ID="DrdlTenMau" runat="server" Height="19px" 
            Width="162px" AutoPostBack="True" 
                onselectedindexchanged="DrdlTenMau_SelectedIndexChanged">
      </asp:DropDownList>
     </Td>
    
    </tr>
    <tr>
    <td >
        <asp:Label ID="Label2" runat="server" Text="Tên mẫu:  "></asp:Label>
&nbsp;&nbsp;
    </td>
      <td>
        <asp:TextBox ID="txtTenMau" runat="server" Width="159px"></asp:TextBox>
  
    </td>
    </tr>
    <tr>
    <td width="7%" valign="top">
    
        <asp:Label ID="Label4" runat="server" Text="Nội Dung:"></asp:Label>
&nbsp;
    
    </td>
    <td valign="top">
        <asp:TextBox ID="txtContent" Runat="server" Columns="100" Height="224px" 
            Rows="10" TextMode="MultiLine" Width="542px" Wrap="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td width="7%" valign="top">
    
        &nbsp;</td>
    <td valign="top">
        <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" Width="86px" 
            onclick="btnCapNhat_Click" />
&nbsp;&nbsp;&nbsp;<asp:Button 
            ID="btnBoqua" runat="server" Text="Bỏ qua" onclick="btnBoqua_Click" />&nbsp;
&nbsp;<asp:Button ID="btnXoa" runat="server" Text="Xóa" Width="51px" 
            onclick="btnXoa_Click" />
        </td>
    </tr>
    </table>
    
</body>

</asp:Content>