<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoTapChi.aspx.cs" Inherits="SoTapChi" MasterPageFile="~/MasterPage.master" %>



<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body>

    <div>
  <table align="center" width="970px" >
      <tr>
        <td align="center">
            <table ID="TableCenter" style="border:1;" cellspacing="0" cellpadding="0">
            <tr  class="TVLibPageTitle" >
                <td height="10" align="left" colspan="2">&nbsp;&nbsp;
                    <asp:Label  ID="Label6" runat="server" Text="GHI NHẬN SỐ TẠP CHÍ"></asp:Label>
                </td>                    
                <td align="right" colspan="2">
                    <asp:HyperLink ID="lnkQuanLyTaiLieu" runat="server" 
                        NavigateUrl="~/AnPhamDinhKy/DanhSachTaiLieu.aspx" ><Font Color='Blue'>&#160;&#160;&#160;&gt;&gt; DANH SÁCH ẤN PHẨM NHIỀU KỲ</Font></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="right" style="height: 19px" >
                </td>
            </tr>
            <tr>
                <td height="17" align="left" colspan="4" >
                    <asp:Label ID="Label1" runat="server" Font-Bold=True>Nhan đề:</asp:Label>
                    <asp:Label ID="lblTenTaiLieu" runat="server" ForeColor="Blue">Nhan đề</asp:Label>
                </td>
            </tr>
            <tr>
            <td colspan="4">&nbsp;</td>
            
            </tr>
            <tr>
                <td height="17" align="left" width="12%" style="width: 24%" >
                    &nbsp;</td>
                 <td height="17" align="left" style="width: 9%" >
                   <asp:Label ID="Label11" runat="server">Tháng phát hành:</asp:Label>
                 </td>
                 <td height="17" align="left" style="width: 34%" >
                <asp:TextBox ID="txtNamPhatHanh" runat="server" Width="250px" AutoPostBack="True" 
                         ontextchanged="txtNamPhatHanh_TextChanged"></asp:TextBox>
                 </td>
                 <td height="17" align="left" >
                     &nbsp;</td>
            </tr>
            <tr>
                <td height="17" align="left" width="12%" style="width: 24%" >
                    &nbsp;</td>
                 <td height="17" align="left" style="width: 9%" >
                    <asp:Label ID="Label10" runat="server">Số theo năm:</asp:Label>
                 </td>
                 <td height="17" align="left" style="width: 34%" >
                <asp:TextBox ID="txtSoTheoNam" runat="server" Width="250px"></asp:TextBox>
                 </td>
                 <td height="17" align="left" >
                     &nbsp;</td>
            </tr>
            <tr>
                <td height="17" align="left" width="12%" style="width: 24%" >
                    &nbsp;</td>
                 <td height="17" align="left" style="width: 9%" >
                   <asp:Label ID="Label8" runat="server">Số toàn cục:</asp:Label>
                 </td>
                 <td height="17" align="left" style="width: 34%" >
                <asp:TextBox ID="txtSoToanCuc" runat="server" Width="250px"></asp:TextBox>
                 </td>
                 <td height="17" align="left" >
                     &nbsp;</td>
            </tr>
          
            <tr>
            <td height="17" align="left" width="12%" style="width: 24%" >
                &nbsp;</td>
            <td height="17" align="left" style="width: 9%" >
                    <asp:Label ID="Label3" runat="server" Text="Đơn giá:"></asp:Label>
            </td>
            <td height="17" align="left" style="width: 34%" >
                <asp:TextBox ID="txtDonGia" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td height="17" align="left" width="10%" >
                &nbsp;</td>
            
            </tr>
          
            <tr>
            <td align="left" width="12%" style="width: 24%" >
            </td>
            <td align="left" style="width: 9%" >
                    <asp:Label ID="Label12" runat="server">Ghi chú:</asp:Label>
            </td>
            <td align="left" style="width: 34%" >
                <asp:TextBox ID="txtGhiChu" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td align="left" width="10%" >
            </td>
            
            </tr>
          
            <tr>
            <td height="17" align="left" width="12%" style="width: 24%" >
                &nbsp;</td>
            <td height="17" align="left" style="width: 9%" >
                    <asp:Label ID="Label7" runat="server">Tóm tắt:</asp:Label>
            </td>
            <td height="17" align="left" style="width: 34%" >
                <asp:TextBox ID="txtTomTat" runat="server" Width="259px" Height="81px" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
            <td height="17" align="left" width="10%" >
                &nbsp;</td>
            
            </tr>
          
            <tr>
            <td height="17" align="left" width="12%" style="width: 24%" >
                &nbsp;</td>
            <td height="17" align="left" style="width: 9%" >
                &nbsp;</td>
            <td height="17" align="left" style="width: 34%" >
                &nbsp;</td>
            <td height="17" align="left" width="10%" >
                &nbsp;</td>
            
            </tr>
          
            <tr>
            <td height="17" align="left" width="12%" style="width: 24%" >
                &nbsp;</td>
            <td height="17" align="left" style="width: 9%" >
                &nbsp;</td>
            <td height="17" align="left" style="width: 34%" >
                <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật" onclick="btnCapNhat_Click" 
                     />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBoQua" runat="server" Text="Bỏ qua" 
                     />
            </td>
            <td height="17" align="left" width="10%" >
                &nbsp;</td>
            
            </tr>
          
            <tr>
            <td colspan="4" align="center">
                &nbsp;</td>
            </tr>
            <tr  class="TVLibPageTitle" >
                <td height="17" align="left" class="style1" colspan="4" >
                    <asp:Label  ID="Label9" runat="server" Text="DANH SÁCH SỐ TẠP CHÍ"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="17" align="right" class="style1" colspan="4" >
                    <asp:GridView ID="grvSoTapChi" runat="server" AutoGenerateColumns="False" 
                        Width="100%" DataKeyNames="SoTapChiID" onrowcreated="grvSoTapChi_RowCreated" 
                        onrowdeleting="grvSoTapChi_RowDeleting" AllowPaging="True" 
                        onpageindexchanging="grvSoTapChi_PageIndexChanging" PageSize="6" onselectedindexchanged="grvSoTapChi_SelectedIndexChanged" 
                        >
                        <Columns>
                            <asp:BoundField HeaderText="Số tạp chí" DataField="SoTheoNam" 
                                ApplyFormatInEditMode="True">
                                <ItemStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Middle" 
                                    Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SoToanCuc" HeaderText="Số toàn cục">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="150px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NamPhatHanh" HeaderText="Tháng phát hành">
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="DonGia">
                                <EditItemTemplate>
                                    <asp:Label  ID="Lbl1" runat="server" Text='<%# Bind("DonGia") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("DonGia") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:TemplateField>
                            <asp:CommandField 
                                EditText="~/Resources/Images/Edit.gif" HeaderText="Sửa" 
                                SelectText="&lt;Img src=&quot;../Resources/Images/Edit.gif&quot;&gt;" 
                                ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnXoa" runat="server" CausesValidation="False"
                                        CommandName="Delete" ImageUrl="~/Resources/Images/delete.gif" Text="Delete" />
                                </ItemTemplate> <%--OnClientClick="return confirm('Bạn có chắc chắn muốn xóa không')"--%>
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="left" >
                    &nbsp;</td>
            </tr>
            </table>
        </td>
        </tr>
    </table>    
        
    </div>
    
</body>
</asp:Content>
