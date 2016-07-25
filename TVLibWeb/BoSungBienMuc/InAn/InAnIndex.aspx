<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InAnIndex.aspx.cs" Inherits="BoSungBienMuc_InAn_InAnIndex" MasterPageFile="~/MasterPage.master" %>
<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
      <table id="Table1" width="970px" align="center"   cellpadding="4" cellspacing="1" bgcolor="white"   >
     <tr class ="TVLibPageTitle" >
            <td colspan ="4" class="style1">
            <asp:Label ID="Label2" Text="Hoạt động in ấn" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
    <tr style="background-color: silver">
    <td colspan="2" >
     <font color="green"><B>THỰC HIỆN</B></font>
    </td>
    <td colspan="2">
        <font color="green"><B>MẪU BIỂU</B></font>
    </td>
    </tr>
    <tr  style="background-color: #f0f3f4;">
    <td width ="5%" align="right" >
        <asp:ImageButton ID="ImageButton6" ImageUrl="~/Resources/Images/MaVach.jpg"
            runat="server" Height="34px" BorderWidth="1" BorderColor="Silver" 
            Width="40px" Enabled="False"            />
    </td>
     <td width="45%">
        &nbsp;
        <asp:HyperLink ID="HyperLink6" runat="server" 
            NavigateUrl="~/BoSungBienMuc/InAn/Barcodes.aspx"   >In mã vạch</asp:HyperLink><br />
             &nbsp; In mã vạch cho tài liệu theo các tiêu chí.</td>   
       <td width ="5%" align="right" >
        <asp:ImageButton ID="ImageButton3" ImageUrl="~/Resources/Images/bieumau1.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
              Enabled="False"            />
    </td>
     <td width="45%">
        &nbsp;
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/BoSungBienMuc/InAn/MauNhanGay.aspx"  >Định dạng nhãn gáy</asp:HyperLink>
         <br />
&nbsp;&nbsp;Chỉnh sửa định dạng nhãn gáy phù hợp với tài liệu của thư viện.</td>        
    </tr>
    <tr  style="background-color: #f0f3f4;">
    <td align="right" >
        <asp:ImageButton ID="ImageButton1" ImageUrl="~/Resources/Images/MayIn.jpg"
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
            Enabled="False"            />
    </td>
     <td >
        &nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/BoSungBienMuc/InAn/InNhanGay.aspx"  >In nhãn gáy</asp:HyperLink><br />
             &nbsp; In nhãn gáy cho tài liệu theo các tiêu chí.     </td>   
      <td align="right" >
        <asp:ImageButton ID="ImageButton7" ImageUrl="~/Resources/Images/BienMuc1.jpg" 
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
              Enabled="False" Width="35px"            />
    </td>
     <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink7" runat="server" 
            NavigateUrl="~/BoSungBienMuc/InAn/MauPhich.aspx"  >Mẫu phích</asp:HyperLink>
         <br />
&nbsp; Chỉnh sửa định dạng mẫu phích phù hợp với tài liệu của thư viện.<br />
             </td>     
    </tr>
      <tr  style="background-color: #f0f3f4;">
    <td align="right" >
        <asp:ImageButton ID="ImageButton8" ImageUrl="~/Resources/Images/MayIn.jpg"
            runat="server" Height="32px" BorderWidth="1" BorderColor="Silver" 
            Enabled="False"            />
          </td>
     <td>
    &nbsp;&nbsp;<asp:HyperLink ID="HyperLink8" runat="server" 
            NavigateUrl="~/BoSungBienMuc/InAn/InMauPhich.aspx"  >In phích</asp:HyperLink>
         <br />
&nbsp; In mẫu phích cho tài liệu theo các tiêu chí.
    </td>   
      <td align="right" >
          &nbsp;</td>
     <td>
        &nbsp;&nbsp;
         <br />
         &nbsp;</td>   
    </tr>
      <tr  style="background-color: #f0f3f4;">
      <td align="right" >
          &nbsp;</td>
     <td >
         &nbsp; <br />
             &nbsp;</td>     
      <td align="right" >
          &nbsp;</td>
     <td >
        &nbsp;
        </td>   
    </tr>
   
    </table>
   </asp:Content>