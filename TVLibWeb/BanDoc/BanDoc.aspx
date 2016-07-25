<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BanDoc.aspx.cs" Inherits="BanDoc_BanDoc" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body>

    <div>
     <table id="Table1" width="970px"  cellpadding="4" cellspacing="1" bgcolor="white" align="center"  >
     <tr class ="TVLibPageTitle" >
            <td colspan ="4">
            <asp:Label ID="Label2" Text="Quản lý bạn đọc" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
    
    <tr  style="background-color: #f0f3f4;">
    <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton6" ImageUrl="~/Resources/Images/NgheNghiep.gif" 
            runat="server" 
            />
    </td>
     <td width="30%">
        &nbsp;
        <asp:HyperLink ID="HyperLink6" runat="server" 
            NavigateUrl="~/BanDoc/TimKiemBanDoc.aspx">Tìm kiếm bạn đọc</asp:HyperLink>
    </td>   
      <td width ="10%" align="right" >
          <asp:ImageButton ID="ImageButton4" ImageUrl="~/Resources/Images/Tinh.gif" 
              runat="server" />
    </td>
    <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/BanDoc/KhoaThe.aspx">Khoá thẻ bạn đọc</asp:HyperLink>
    </td>    
    </tr>
     <tr  style="background-color: #f0f3f4;">
    <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton8" ImageUrl="~/Resources/Images/ThongKe6.jpg" 
            runat="server" Height="31px" BorderWidth="1" BorderColor="Silver" 
              Enabled="False" Width="30px"            />
    </td>
    <td width="30%">
        &nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/BanDoc/XoaBanDoc.aspx">Xoá bạn đọc theo lô</asp:HyperLink>
    </td>   
      <td width ="10%" align="right"  >
          &nbsp;</td>
    <td>
        &nbsp;
        </td>     
    </tr>
      <tr  style="background-color: #f0f3f4;">
    <td width ="10%" align="right" >
        &nbsp;</td>
    <td width="30%">
        &nbsp;
        </td>   
      <td width ="10%" align="right"  >
          &nbsp;</td>
    <td>
        &nbsp;
        </td>     
    </tr>
    
   
    </table>
    </div>

</body>
</asp:Content>
