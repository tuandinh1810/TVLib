<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XoaBanDoc.aspx.cs" Inherits="BanDoc_XoaBanDoc" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body>
    <div>
    <table align="center" width="970px" >
    <tr class ="TVLibPageTitle">
    <td colspan ="2">
    
        <asp:Label ID="Label1" runat="server" Text="Xoá bạn đọc theo lô"></asp:Label>
    
    </td>
    </tr>
    <tr>
    <td width="30%" align ="right" >
        <asp:Label ID="Label2" runat="server" Text="&lt;u&gt;K&lt;/u&gt;hoá:"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtKhoa" runat="server"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td align ="right" >
        <asp:Label ID="Label3" runat="server" Text="&lt;u&gt;L&lt;/u&gt;ớp:"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtLop" runat="server"></asp:TextBox>
    </td>
    </tr>
     <tr>
    <td align ="right" >
        <asp:Label ID="Label4" runat="server" Text="&lt;u&gt;N&lt;/u&gt;gày cấp thẻ:"></asp:Label>
    &nbsp;
        <asp:Label ID="Label6" runat="server" Text="từ:"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtTuNgay" runat="server"></asp:TextBox>
&nbsp; <asp:Label ID="Label5" runat="server" Text="đến:"></asp:Label>
    &nbsp; <asp:TextBox ID="txtDenNgay" runat="server"></asp:TextBox>
    </td>
    </tr>
      <tr style ="background-color:Silver ">
    <td align ="right" >
    </td>
    <td>
        <asp:Button ID="btnXoa" runat="server" Text="Xoá" onclick="btnXoa_Click" />
    </td>
    </tr>
    <tr>
    <td>
    </td>
    <td>
    </td>
    </tr>
      <tr>
    <td>
    </td>
    <td>
    </td>
    </tr>
    </table>
    
    </div>
    
    <p>
        &nbsp;</p>
</body>
</asp:Content>
