<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MauPhieu.aspx.cs" Inherits="MauPhieu" ValidateRequest="false" MasterPageFile="~/MasterPage.master" %>
<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body style="margin-top:0;">
    
    <table align="center" width="970px" >
        <tr class="TVLibPageTitle">
        <td colspan="2">
        <asp:Label ID="Label1" runat="server" Text="KHUÔN DẠNG MẪU PHIẾU"></asp:Label>
    </td>
   
    </tr>
    <tr>
    <td colspan="2">
    
    </td>
    </tr>
    <tr>
    <td align="right">
     <asp:Label ID="Label3" runat="server" Text="Chọn Mẫu: "></asp:Label></td>
        <td>
      <asp:DropDownList ID="DrdlTenMau" runat="server" Height="19px" 
            Width="162px" AutoPostBack="True" 
                onselectedindexchanged="DrdlTenMau_SelectedIndexChanged">
          <asp:ListItem Value="0">---- Loại phiếu ----</asp:ListItem>
          <asp:ListItem Value="1">Ghi mượn</asp:ListItem>
          <asp:ListItem Value="2">Ghi trả</asp:ListItem>
          <asp:ListItem Value="3">Quá hạn</asp:ListItem>
          <asp:ListItem Value="4">Phiếu đăng ký mượn</asp:ListItem>
      </asp:DropDownList>
     </Td>
    
    </tr>
   <tr>
    <td width="10%" align="right">
    
        <asp:Label ID="Label2" runat="server" Text="Tên mẫu phiếu:"></asp:Label>
    
    </td>
    <td >
        <asp:TextBox ID="txtTenMauPhieu" runat="server" Width="185px" ></asp:TextBox>
       </td>
    </tr>
    <tr>
    <td width="10%" valign="top" align="right">
    
        <asp:Label ID="Label4" runat="server" Text="Nội Dung:"></asp:Label>
&nbsp;
    
    </td>
    <td valign="top">
        <asp:TextBox ID="txtContent" Runat="server" Columns="100" Height="224px" 
            Rows="10" TextMode="MultiLine" Width="542px" Wrap="False"></asp:TextBox>
        </td>
    </tr>
    <tr style="background-color:Silver ">
    <td width="7%" valign="top">
    
        &nbsp;</td>
    <td valign="top">
    <input type="hidden" id="hidID" runat ="server" />
        <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" Width="86px" 
            onclick="btnCapNhat_Click" />
&nbsp;&nbsp;&nbsp;<asp:Button 
            ID="btnBoqua" runat="server" Text="Bỏ qua" onclick="btnBoqua_Click" />
        </td>
    </tr>
    </table>
    
</body>
</asp:Content>
