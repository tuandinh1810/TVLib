<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhMucIndex.aspx.cs" Inherits="BoSungBienMuc_DanhMucIndex" MasterPageFile="~/MasterPage.master" %>
<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
    <div>
     <table id="Table1" width="970px"  cellpadding="4" cellspacing="1" bgcolor="white" align="center"  >
     <tr class ="TVLibPageTitle" >
            <td colspan ="4">
            <asp:Label ID="Label2" Text="Quản lý danh mục" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
    
    <tr  style="background-color: #f0f3f4;">
    <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton6" ImageUrl="~/Resources/Images/TL8.jpg"  BorderColor=Silver  BorderWidth=1
            runat="server" Height="32px" 
            />
    </td>
     <td width="30%">
        &nbsp;<asp:HyperLink ID="HyperLink6" runat="server" 
            NavigateUrl="~/BoSungBienMuc/DanhMuc/ThuVien.aspx">Thư viện</asp:HyperLink>
    </td>   
      <td width ="10%" align="right" >
           <asp:ImageButton ID="ImageButton1" ImageUrl="~/Resources/Images/bieumau.jpg"  BorderColor=Silver  BorderWidth=1
            runat="server" Height="32px" 
            /></td>
    <td>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/BoSungBienMuc/MauBienMucIndex.aspx?TaoMauBM=1" >Mẫu biên mục</asp:HyperLink>
        </td>    
    </tr>
     <tr  style="background-color: #f0f3f4;">
    <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton7" ImageUrl="~/Resources/Images/TL7.jpg"  BorderColor=Silver  BorderWidth=1
            runat="server" 
            />
    </td>
    <td width="30%">
        &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/BoSungBienMuc/DanhMuc/Kho.aspx">Kho</asp:HyperLink>
    </td>   
      <td width ="10%" align="right"  >
          <asp:ImageButton ID="ImageButton4" ImageUrl="~/Resources/Images/BienMuc.jpg"  BorderWidth="1" BorderColor="Silver" 
              runat="server" Height="29px" Width="34px" />
         </td>
    <td>
        &nbsp;<asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/BoSungBienMuc/DanhMuc/DM_LyDoThanhLy.aspx" >Lý do thanh lý</asp:HyperLink>
        </td>     
    </tr>
      <tr  style="background-color: #f0f3f4;">
    <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton8" ImageUrl="~/Resources/Images/DangTaiLieu.jpg"  
            BorderColor=Silver  BorderWidth=1
            runat="server" Height="30px" Width="32px" 
            />
          </td>
    <td width="30%">
        &nbsp;<asp:HyperLink ID="HyperLink7" runat="server" 
            NavigateUrl="~/BoSungBienMuc/DanhMuc/DangTaiLieu.aspx">Dạng tài liệu</asp:HyperLink>
        </td>   
      <td width ="10%" align="right"  >
          &nbsp;</td>
    <td>
        &nbsp;
        </td>     
    </tr>
    
   
    </table>
    </div>
   </asp:Content>