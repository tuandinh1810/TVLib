<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master"   AutoEventWireup="true" CodeFile="TaiLieuChiTiet.aspx.cs" Inherits="TVLibTraCuuWeb.TaiLieuChiTiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
  
      <table width ="970px" align= "center" id="tbl"   >
       <tr valign ="top" class="TVLibPageTitle">
   
    <td align ="left" valign ="top" >
      
         <asp:Label ID="Label2" runat="server" Text="DỮ LIỆU BIÊN MỤC"
             ></asp:Label>   
      
         </td>
    </tr>
       <tr valign ="top">
   
    <td align ="right" valign ="top" >
      
         <asp:HyperLink ID="lnkTraCuu" Font-Bold=True NavigateUrl="~/TrangChu.aspx" 
            runat="server" ><Font Color='Blue'>&#160;&#160;&#160;&gt;* Tra Cứu</Font></asp:HyperLink></td>
    </tr>
      <tr>
    
    <td valign ="top"  >
        <asp:Table ID="tblResult" runat="server" Width="100%">
        </asp:Table>      
        
       <br />
    </td>
    </tr>
  
     <tr>
    
    <td class="TVLibPageTitle" >
      
         <asp:Label ID="Label1" runat="server" Text="DỮ LIỆU XẾP GIÁ"
             ></asp:Label>   
      
         </td>
    </tr>
  <tr>
  <td>
   <tr>
                <td height="17" align="right" class="style1" colspan="6" >
                &nbsp;&nbsp;<img src='Resources/Images/lock.gif' >Đang bị khóa
                &nbsp;&nbsp;<img src='Resources/Images/loan.gif'> Đang cho mượn
                &nbsp;&nbsp;<img src='Resources/Images/available.gif' 
                        style="height: 19px; width: 21px">Sẵn sàng cho mượn
                    &nbsp;</td>
            </tr>
  </td>
  </tr>
     
    <tr>
    <td align ="left" >
        
         <asp:GridView ID="grvMaXepGia" runat="server" width="100%" 
             AutoGenerateColumns="False" onrowcreated="grvMaXepGia_RowCreated" 
             AllowPaging="True" onpageindexchanging="grvMaXepGia_PageIndexChanging" 
             PageSize="20">
             <Columns>
                   <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            </asp:TemplateField>
                 <asp:BoundField DataField="TenThuVien" HeaderText="Tên thư viện" />
                 <asp:BoundField DataField="MaKho" HeaderText="Kho" />
                 <asp:BoundField DataField="MaXepGia" HeaderText="Mã xếp giá" />
                   <asp:TemplateField HeaderText="Mở / đóng">
                       <ItemTemplate>
                           <asp:Label ID="lbLuuThong" runat="server"></asp:Label>
                       </ItemTemplate>                    
                       <HeaderStyle HorizontalAlign="Center" />
                       <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="Tình trạng">
                       <ItemTemplate>
                           <asp:Label ID="lbDangMuon" runat="server" ></asp:Label>
                       </ItemTemplate>                      
                       <HeaderStyle HorizontalAlign="Center" />
                       <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>
             </Columns>
        </asp:GridView>
      
    </td>
    </tr>
   
</table> 
  </asp:Content>
