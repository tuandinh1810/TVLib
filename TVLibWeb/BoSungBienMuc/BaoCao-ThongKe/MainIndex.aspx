<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainIndex.aspx.cs" Inherits="BoSungBienMuc_BaoCao_ThongKe_MainIndex" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
      <table id="Table1" width="970px"  cellpadding="4" cellspacing="1" bgcolor="white" align="center"  >
     <tr class ="TVLibPageTitle" >
            <td colspan ="4" class="style1">
            <asp:Label ID="Label2" Text="Báo cáo - thống kê tài liệu được bổ sung và biên mục" 
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
      <td align="right" >
        <asp:ImageButton ID="ImageButton2" ImageUrl="~/Resources/Images/Baocao3.jpg"
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
            Enabled="False"  />
         </td>
     <td >
        <asp:HyperLink ID="HyperLink6" runat="server" 
            NavigateUrl="~/BoSungBienMuc/BaoCao-ThongKe/BaoCaoBoSung.aspx"   >Báo cáo bổ sung</asp:HyperLink>
         <br />
         Báo cáo hoạt động bổ sung sách trong một khoảng thời gian</td>     
      <td align="right" >
        <asp:ImageButton ID="ImageButton6" ImageUrl="~/Resources/Images/ThongKe7.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
               Enabled="False"            />
                  </td>
     <td >
        <asp:HyperLink ID="HyperLink7" runat="server" 
            NavigateUrl="~/BoSungBienMuc/BaoCao-ThongKe/ThongKe_BoSung.aspx"  >Thống kê 
         hoạt động bổ sung</asp:HyperLink>
         <br />
         Thống kê số lượng sách tài liệu bổ sung vào thư viện trong một khoảng thời gian </td>   
    </tr>
    <tr  style="background-color: #f0f3f4;">
    <td width ="5%" align="right" >
        &nbsp;</td>
     <td width="45%">
        &nbsp;
        <br />
                      &nbsp;</td>   
       <td width ="5%" align="right" >
        <asp:ImageButton ID="ImageButton4" ImageUrl="~/Resources/Images/ThongKe1.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
               Enabled="False"            />
    </td>
     <td width="45%">
        &nbsp;
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/BoSungBienMuc/BaoCao-ThongKe/ThongKe_DangTaiLieu.aspx"  >Thống kê theo 
         dạng tài liệu</asp:HyperLink><br />
             &nbsp;Thống kê số lượng sách biên mục theo dạng tài liệu
    </td>        
    </tr>
    <tr  style="background-color: #f0f3f4;">
    <td align="right" >
        &nbsp;</td>
     <td >
        &nbsp;
        <br />
             &nbsp;</td>   
      <td align="right" >
        <asp:ImageButton ID="ImageButton3" ImageUrl="~/Resources/Images/ThongKe3.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
              Enabled="False"            />
    </td>
     <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/BoSungBienMuc/BaoCao-ThongKe/ThongKe_NguoiBienMuc.aspx"  >Thống kê theo người biên mục</asp:HyperLink><br />
             &nbsp;Thống kê số lượng sách biên mục theo người biên mục trong một khoảng thời gian</td>     
    </tr>
      <tr  style="background-color: #f0f3f4;">
    <td align="right" >
        &nbsp;</td>
     <td>
        &nbsp;</td>   
      <td align="right" >
        <asp:ImageButton ID="ImageButton5" ImageUrl="~/Resources/Images/ThongKe5.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
              Enabled="False"            />
    </td>
     <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink5" runat="server" 
            NavigateUrl="~/BoSungBienMuc/BaoCao-ThongKe/ThongKe_NgayBienMuc.aspx"  >Thống kê theo thời gian biên mục</asp:HyperLink><br />
             &nbsp;Thống kê số lượng tài liệu biên mục trong một khoảng thời gian theo 
         từng ngày.
    </td>   
    </tr>
     
   
      <tr  style="background-color: #f0f3f4;">
    <td align="right" >
        &nbsp;</td>
     <td>
         &nbsp;</td>   
      <td align="right" >
        <asp:ImageButton ID="ImageButton7" ImageUrl="~/Resources/Images/ThongKe5.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
              Enabled="False"            />
    </td>
     <td>
        &nbsp;<asp:HyperLink ID="HyperLink8" runat="server" 
            NavigateUrl="~/BoSungBienMuc/BaoCao-ThongKe/ThongKeTaiLieuPhucVuKK.aspx"  >Thống 
         kê tài liệu phục vụ kiểm kê</asp:HyperLink><br />
             &nbsp;Thống kê tài liệu phục vụ kiểm kê
    </td>   
    </tr>
     
   
    </table>
   </asp:Content>