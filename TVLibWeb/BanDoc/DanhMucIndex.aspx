<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhMucIndex.aspx.cs" Inherits="BanDoc_DanhMucIndex" MasterPageFile="~/MasterPage.master" %>
<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body>
    
    <div>
     <table id="Table1" width="970px"  cellpadding="4" cellspacing="1" bgcolor="white" align="center"  >
     <tr class ="TVLibPageTitle" >
            <td colspan ="4">
            <asp:Label ID="Label2" Text="Danh mục" 
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
            NavigateUrl="~/BanDoc/NhomBanDoc.aspx">Nhóm bạn đọc</asp:HyperLink>
    </td>   
      <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton2" ImageUrl="~/Resources/Images/NgheNghiep.gif" 
            runat="server"  />
    </td>
    <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/BanDoc/NgheNghiep.aspx">Nghề nghiệp</asp:HyperLink>
    </td>    
    </tr>
     <tr  style="background-color: #f0f3f4;">
    <td width ="10%" align="right" >
          <asp:ImageButton ID="ImageButton3" ImageUrl="~/Resources/Images/DanToc.gif" 
              runat="server" />
    </td>
    <td width="30%">
        &nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/BanDoc/DanToc.aspx">Dân tộc</asp:HyperLink>
    </td>   
      <td width ="10%" align="right"  >
          <asp:ImageButton ID="ImageButton4" ImageUrl="~/Resources/Images/Tinh.gif" 
              runat="server" />
    </td>
    <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/BanDoc/Tinh.aspx">Danh mục tỉnh</asp:HyperLink>
    </td>     
    </tr>
      <tr  style="background-color: #f0f3f4;">
    <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton5" ImageUrl="~/Resources/Images/TrinhDo.gif" 
            runat="server" />
    </td>
    <td width="30%">
        &nbsp;
        <asp:HyperLink ID="HyperLink5" runat="server" 
            NavigateUrl="~/BanDoc/TrinhDo.aspx">Trình độ</asp:HyperLink>
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
