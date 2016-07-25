<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongKeIndex.aspx.cs" Inherits="BanDoc_ThongKeIndex" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body>

      <table id="Table1" width="970px"  cellpadding="4" cellspacing="1" bgcolor="white" align="center"  >
     <tr class ="TVLibPageTitle" >
            <td colspan ="4">
            <asp:Label ID="Label2" Text="Thống kê bạn đọc" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
    
    <tr  style="background-color: #f0f3f4;">
    <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton6" ImageUrl="~/Resources/Images/ThongKe1.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver"            />
    </td>
     <td width="30%">
        &nbsp;
        <asp:HyperLink ID="HyperLink6" runat="server" 
            NavigateUrl="~/BanDoc/BaoCaoThongKe/ThongKe_NhomBanDoc.aspx"  >Thống kê theo nhóm bạn đọc</asp:HyperLink>
    </td>   
      <td width ="10%" align="right" >
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
  
</body>
</asp:Content>
