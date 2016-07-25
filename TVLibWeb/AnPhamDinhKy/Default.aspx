<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="AnPhamDinhKyDefault" MasterPageFile="~/MasterPage.master"  %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body>
    <div>
     <table id="Table1" width="970px"  cellpadding="4" cellspacing="1" bgcolor="white" align="center"  >
     <tr class ="TVLibPageTitle" >
            <td colspan ="4">
            <asp:Label ID="Label2" Text="Quản lý ấn phẩm định kỳ" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
    
    <tr  style="background-color: #f0f3f4;">
    <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton9" ImageUrl="~/Resources/Images/BienMuc.png" 
            runat="server"  BorderWidth="1" BorderColor="Silver" 
               Enabled="False"            />
    </td>
     <td width="30%">
        &nbsp;
        <asp:HyperLink ID="HyperLink7" runat="server" 
            NavigateUrl="~/AnPhamDinhKy/DanhSachTaiLieu.aspx">Danh sách ấn phẩm nhiều kỳ</asp:HyperLink>
    </td>   
      <td width ="10%" align="right" >
          <asp:ImageButton ID="ImageButton4" ImageUrl="~/Resources/Images/BaoCaoThongKe.png" 
              runat="server" />
    </td>
    <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/AnPhamDinhKy/TongHop.aspx">Tổng hợp số tạp chí</asp:HyperLink>
    </td>    
    </tr>
     <tr  style="background-color: #f0f3f4;">
    <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton10" ImageUrl="~/Resources/Images/KiemKe.png"
            runat="server"  BorderWidth="1" BorderColor="Silver" 
            Enabled="False"            />
    </td>
    <td width="30%">
        &nbsp;
        <asp:HyperLink ID="HyperLink6" runat="server" 
            NavigateUrl="~/AnPhamDinhKy/SoTapChi.aspx">Ghi nhận số tạp chí</asp:HyperLink>
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

