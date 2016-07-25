<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongKeIndex.aspx.cs" Inherits="BanDoc_ThongKeIndex" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body>
    
      <table id="Table1" width="970px"  cellpadding="4" cellspacing="1" bgcolor="white"  align="center" >
     <tr class ="TVLibPageTitle" >
            <td colspan ="4" class="style1">
            <asp:Label ID="Label2" Text="Thống kê hoạt động lưu thông" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
    <tr style="background-color: silver">
    <td colspan="2" >
     <font color="green"><B>BÁO CÁO</B></font>
    </td>
    <td colspan="2">
        <font color="green"><B>THỐNG KÊ</B></font>
    </td>
    </tr>
    <tr  style="background-color: #f0f3f4;">
    <td width ="5%" align="right" >
        <asp:ImageButton ID="ImageButton6" ImageUrl="~/Resources/Images/Baocao1.jpg"
            runat="server" Height="34px" BorderWidth="1" BorderColor="Silver" 
            Width="32px" Enabled="False"            />
    </td>
     <td width="45%">
        &nbsp;
        <asp:HyperLink ID="HyperLink6" runat="server" 
            NavigateUrl="~/LuuThong/BaoCaoThongKe/DangMuon.aspx"   >Ấn phẩm đang mượn</asp:HyperLink><br />
             &nbsp;Báo cáo các ẩn phẩm đang nằm trong tay bạn đọc.
    </td>   
       <td width ="5%" align="right" >
        <asp:ImageButton ID="ImageButton4" ImageUrl="~/Resources/Images/ThongKe1.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
               Enabled="False"            />
    </td>
     <td width="45%">
        &nbsp;
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/LuuThong/BaoCaoThongKe/TK_MuonNhieuNhat.aspx"  >Ấn phẩm mượn nhiều nhất</asp:HyperLink><br />
             &nbsp;Thống kê top 20 những ấn phẩm bạn đọc mượn nhiều nhất.
    </td>        
    </tr>
    <tr  style="background-color: #f0f3f4;">
    <td align="right" >
        <asp:ImageButton ID="ImageButton1" ImageUrl="~/Resources/Images/QuaHan.jpg"
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
            Enabled="False"            />
    </td>
     <td >
        &nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/LuuThong/BaoCaoThongKe/AnPhamQuaHan.aspx"  >Ấn phẩm quá hạn</asp:HyperLink><br />
             &nbsp;Báo cáo các ẩn phẩm đã mượn quá hạn.
    </td>   
      <td align="right" >
        <asp:ImageButton ID="ImageButton5" ImageUrl="~/Resources/Images/ThongKe5.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
              Enabled="False"            />
    </td>
     <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink5" runat="server" 
            NavigateUrl="~/LuuThong/BaoCaoThongKe/TK_BanDoc_MuonNhieuNhat.aspx"  >Giao dịch mượn sách của bạn đọc</asp:HyperLink><br />
             &nbsp;Thống kê những bạn đọc thực hiện nhiều giao dịch mượn nhất trong một khoảng 
         thời gian.
    </td>     
    </tr>
      <tr  style="background-color: #f0f3f4;">
    <td align="right" >
        <asp:ImageButton ID="ImageButton7" ImageUrl="~/Resources/Images/Baocao4.jpg"
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
              Width="31px" Enabled="False"            />
    </td>
     <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink7" runat="server" 
            NavigateUrl="~/LuuThong/BaoCaoThongKe/LichSuDaMuon.aspx"  >Lịch sử mượn</asp:HyperLink>
         <br />
&nbsp;Báo cáo lịch sử mượn tài liệu của thư viện theo các tiêu chí. <br />
    </td>   
      <td align="right" >
        <asp:ImageButton ID="ImageButton8" ImageUrl="~/Resources/Images/ThongKe3.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
              Enabled="False"            />
    </td>
     <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink8" runat="server" 
            NavigateUrl="~/LuuThong/BaoCaoThongKe/TK_AnPhamTrongNgay.aspx"  >Ấn phẩm mượn trong ngày</asp:HyperLink><br />
             &nbsp;Thống kê top 20 tài liệu có số lượt mượn nhiều nhất trong ngày.
    </td>   
    </tr>
      <tr  style="background-color: #f0f3f4;">
      <td align="right" >
        <asp:ImageButton ID="ImageButton9" ImageUrl="~/Resources/Images/Baocao4.jpg"
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
              Width="31px" Enabled="False"            />
          </td>
     <td >
        &nbsp;
        <asp:HyperLink ID="HyperLink9" runat="server" 
            NavigateUrl="~/LuuThong/BaoCaoThongKe/ThongKeLuotBanDocPhongDocMo.aspx"  >Thống 
         kê lượt bạn đọc phòng mở</asp:HyperLink>
         <br />
&nbsp;Thống kê số lượt bạn đọc đến phòng mở
        <br />
             &nbsp;</td>     
      <td align="right" >
          &nbsp;</td>
     <td >
        &nbsp;
        <br />
             &nbsp;</tr>
   
    </table>
    
</body>
</asp:Content>
