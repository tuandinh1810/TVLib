<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="BoSungBienMuc_Default" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
    <div>
  
      <table id="Table1" width="970px" align="center"   cellpadding="4" cellspacing="1" bgcolor="white"   >
     <tr class ="TVLibPageTitle" >
            <td colspan ="4" class="style1">
            <asp:Label ID="Label2" Text="Bổ sung - Biên mục" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
    <tr  style="background-color: #f0f3f4;">
    
       <td width ="5%" align="right" >
        <asp:ImageButton ID="ImageButton4" ImageUrl="~/Resources/Images/BienMuc.png" 
            runat="server"  BorderWidth="1" BorderColor="Silver" 
               Enabled="False"            />
    </td>
     <td width="45%">
        &nbsp;
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/BoSungBienMuc/MauBienMucIndex.aspx"  >Biên mục</asp:HyperLink><br />
             &nbsp; Biên mục cho tài liệu mới.</td> 
             <td width ="5%" align="right" >
        <asp:ImageButton ID="ImageButton6" ImageUrl="~/Resources/Images/Kho.png"
            runat="server"  BorderWidth="1" BorderColor="Silver" 
             Enabled="False"            />
    </td>
     <td width="45%">
        &nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink6" runat="server" 
            NavigateUrl="~/BoSungBienMuc/QuanLyKhoIndex.aspx"   >Quản lý kho</asp:HyperLink><br />
             &nbsp;&nbsp; In mã vạch cho tài liệu theo các tiêu chí. </td>          
    </tr>
    <tr  style="background-color: #f0f3f4;">
    <td align="right" >
        <asp:ImageButton ID="ImageButton9" ImageUrl="~/Resources/Images/BienMuc.png" 
            runat="server"  BorderWidth="1" BorderColor="Silver" 
               Enabled="False"            />
    </td>
     <td width="45%">
         &nbsp;
        <asp:HyperLink ID="HyperLink9" runat="server" 
            NavigateUrl="~/BoSungBienMuc/DanhSachTaiLieu.aspx"  >Danh sách tài liệu</asp:HyperLink><br />
             &nbsp; Duyệt danh sách tài liệu đã biên mục.</td> 
             <td align="right" >
        <asp:ImageButton ID="ImageButton8" ImageUrl="~/Resources/Images/KiemKe.png"
            runat="server"  BorderWidth="1" BorderColor="Silver" 
            Enabled="False"            />
          </td>
     <td>
    &nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink8" runat="server" 
            NavigateUrl="~/BoSungBienMuc/KiemKe/MainIndex.aspx"  >Kiểm kê</asp:HyperLink>
         <br />
         &nbsp;&nbsp; In mẫu phích cho tài liệu theo các tiêu chí.  
        
    </tr>
      <tr  style="background-color: #f0f3f4;">
       <td align="right" >
        <asp:ImageButton ID="ImageButton1" ImageUrl="~/Resources/Images/InAn.png"
            runat="server"  BorderWidth="1" BorderColor="Silver" 
            Enabled="False"            />
    </td>
     <td >
        &nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/BoSungBienMuc/InAn/InAnIndex.aspx"  >In ấn</asp:HyperLink><br />
             &nbsp; In nhãn gáy cho tài liệu theo các tiêu chí.     </td> 
      <td align="right" >
        <asp:ImageButton ID="ImageButton7" ImageUrl="~/Resources/Images/DanhMuc.png" 
            runat="server"  BorderWidth="1" BorderColor="Silver" 
              Enabled="False"/>
                  </td>
     <td>
        &nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink7" runat="server" 
            NavigateUrl="~/BoSungBienMuc/DanhMuc/DanhMucIndex.aspx"  >Danh Mục</asp:HyperLink>
         <br />
         &nbsp;Chỉnh sửa định dạng mẫu phích phù hợp với tài liệu của thư viện.</tr>
      <tr  style="background-color: #f0f3f4;">
      <td align="right" >
        <asp:ImageButton ID="ImageButton3" ImageUrl="~/Resources/Images/BaoCaoThongKe.png" 
            runat="server"  BorderWidth="1" BorderColor="Silver" 
              Enabled="False"            />
          </td>
     <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/BoSungBienMuc/BaoCaoThongKe/MainIndex.aspx"  >Báo cáo thống kê</asp:HyperLink><br />
             &nbsp; Các báo cáo thống kê của nghiệp vụ biên mục</td>   
      <td align="right" >
          &nbsp;</td>
     <td >
        &nbsp;
        </td>   
    </tr>
   
    </table>
  
   </asp:Content>