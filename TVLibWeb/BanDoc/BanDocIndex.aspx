<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BanDocIndex.aspx.cs" Inherits="BanDoc_BanDocIndex" MasterPageFile="~/MasterPage.master"  %>

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
        <asp:ImageButton ID="ImageButton9" ImageUrl="~/Resources/Images/HoSoBanDoc.png" 
            runat="server" 
            />
    </td>
     <td width="30%">
        &nbsp;
        <asp:HyperLink ID="HyperLink7" runat="server" 
            NavigateUrl="~/BanDoc/HoSoBanDoc.aspx">Hồ sơ bạn đọc</asp:HyperLink>
    </td>   
      <td width ="10%" align="right" >
          <asp:ImageButton ID="ImageButton4" ImageUrl="~/Resources/Images/BaoCaoThongKe.png" 
              runat="server" />
    </td>
    <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/BanDoc/BaoCao-ThongKe/ThongKeIndex.aspx">Báo cáo thống kê</asp:HyperLink>
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
            NavigateUrl="~/BanDoc/BanDoc.aspx">Quản lý bạn đọc</asp:HyperLink>
    </td>   
      <td width ="10%" align="right"  >
        <asp:ImageButton ID="ImageButton8" ImageUrl="~/Resources/Images/DanhMuc.png" 
            runat="server" Height="31px" BorderWidth="1" BorderColor="Silver" 
              Enabled="False" Width="30px"            />
                    </td>
    <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/BanDoc/DanhMucIndex.aspx">Danh mục</asp:HyperLink>
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

