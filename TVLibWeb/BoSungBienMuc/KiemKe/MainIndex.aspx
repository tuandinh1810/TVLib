<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainIndex.aspx.cs" Inherits="BoSungBienMuc_BaoCao_ThongKe_MainIndex" MasterPageFile="~/MasterPage.master" %>
<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>

      <table id="Table1" width="970px"  cellpadding="4" cellspacing="1" bgcolor="white" align="center"  >
     <tr class ="TVLibPageTitle" >
            <td colspan ="4" class="style1">
            <asp:Label ID="Label2" Text="Hoạt động kiểm kê trong thư viện" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
    <tr style="background-color: silver">
    <td colspan="2" >
     <font color="green"><B>KIỂM KÊ</B></font>
    </td>
    <td colspan="2">
        <font color="green"><B>BÁO CÁO</B></font>
    </td>
    </tr>
     <tr  style="background-color: #f0f3f4;">
      <td align="right" >
        <asp:ImageButton ID="ImageButton6" ImageUrl="~/Resources/Images/KiemKe1.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
               Enabled="False"            />
         </td>
     <td >
        <asp:HyperLink ID="HyperLink7" runat="server" 
            NavigateUrl="~/BoSungBienMuc/KiemKe/KyKiemKe.aspx"  >Kỳ kiểm kê</asp:HyperLink>
         <br />
         Thêm mới, cập nhật, xóa kỳ kiểm kê .</td>     
      <td align="right" >
          &nbsp;</td>
     <td >
         <br />
                  </td>   
    </tr>
    <tr  style="background-color: #f0f3f4;">
    <td width ="5%" align="right" >
        <asp:ImageButton ID="ImageButton4" ImageUrl="~/Resources/Images/KiemKe2.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
               Enabled="False"            />
        </td>
     <td width="45%">
        &nbsp;<asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/BoSungBienMuc/KiemKe/KiemKe.aspx"  >Kiểm 
         kê</asp:HyperLink><br />
             &nbsp;Thực hiện quá trình kiểm kê.&nbsp;</td>   
       <td width ="5%" align="right" >
           &nbsp;</td>
     <td width="45%">
        &nbsp;
        </td>        
    </tr>
    <tr  style="background-color: #f0f3f4;">
    <td align="right" >
        <asp:ImageButton ID="ImageButton3" ImageUrl="~/Resources/Images/KiemKe3.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
              Enabled="False" Width="33px"            />
        </td>
     <td >
        &nbsp;<asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/BoSungBienMuc/KiemKe/MoKyKiemKe.aspx"  >Đóng kỳ kiểm kê</asp:HyperLink><br />
             &nbsp;Đóng kỳ kiểm kê và mở kho.&nbsp;</td>   
      <td align="right" >
          &nbsp;</td>
     <td>
        &nbsp;</td>     
    </tr>
      <tr  style="background-color: #f0f3f4;">
    <td align="right" >
        &nbsp;</td>
     <td>
        &nbsp;</td>   
      <td align="right" >
          &nbsp;</td>
     <td>
        &nbsp;</td>   
    </tr>
     
   
    </table>
   </asp:Content>