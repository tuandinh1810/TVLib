<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuanLyKhoIndex.aspx.cs" Inherits="BoSungBienMuc_QuanLyKhoIndex" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID=ContentPlaceHolder1 runat=server>

    <div>
    <table align="center" width="970px" >
            <tr  class="TVLibPageTitle" >
                <td align="left" colspan="5">
                    <asp:Label  ID="Label6" runat="server" Text="QUẢN LÝ ĐKCB TRONG KHO"></asp:Label>
                </td>                   
              
            </tr>          
            <tr>
                <td align="left" class="style1" colspan="5" >
                    </td>
            </tr>
            <tr>
            <td align="left" colspan="5"  ><nobr>
                <asp:Label ID="Label10" runat="server" Text="Thư viện:"></asp:Label>
               &nbsp;<asp:DropDownList ID="DrdlThuVien" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DrdlThuVien_SelectedIndexChanged"  >
                    </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Label ID="Label11" runat="server" Text="Kho:"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="ddlKho" runat="server">
                    </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Label ID="Label12" runat="server" Text="Chức năng:"></asp:Label>
                 <asp:DropDownList ID="ddlChucNang" runat="server">
                     <asp:ListItem Value="0"> Kiểm nhận mở khóa</asp:ListItem>
                     <asp:ListItem Value="1">Thanh lý</asp:ListItem>
                      <asp:ListItem Value="2">Phục hồi thanh lý</asp:ListItem>
                 </asp:DropDownList>
                 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 
            <asp:Label ID="Label13" runat="server" Text="Đăng ký cá biệt:"></asp:Label>
                 
                    &nbsp;<asp:TextBox ID="txtDKCB" runat="server" ></asp:TextBox>
                &nbsp;&nbsp;
                &nbsp;<asp:Button ID="btnLoc" runat="server" Text="Lọc(s)" onclick="btnLoc_Click1"/>
                </nobr>
            </td>
            
            </tr>
           <tr>
           <td colspan="5">&nbsp;&nbsp; &nbsp;</td>
           </tr>
            <tr>
            <td align="right">
                &nbsp;</td>
                <td align="right" colspan="2">
                &nbsp;  
                </td>
                <td align="left" >
                    &nbsp;</td>
                <td align="left" >&nbsp;&nbsp;
                    </td>
            </tr>
            <tr >
            <td colspan="5" class="style2">&nbsp;&nbsp; &nbsp;</td>
            </tr>
            <tr  class="TVLibPageTitle" id="trlblXepGia" runat=server>
                <td height="10" align="left" colspan="5" >
                    <asp:Label  ID="Label9" runat="server" Text="DANH SÁCH XẾP GIÁ"></asp:Label>
                </td>
            </tr>
            <tr id="trlblTotal" runat=server>
                <td height="17" align="right" class="style1" colspan="5" >
                    <asp:Label ID="Label14" runat="server" Text="Tổng số:"></asp:Label>
&nbsp;<asp:Label ID="lbToltal" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" align="left" >
                    <asp:GridView ID="grvMaXepGia" runat="server" AutoGenerateColumns="False" 
                        Width="100%" DataKeyNames="ID,IDKho" 
                        onrowcreated="grvMaXepGia_RowCreated" AllowPaging="True" 
                        onpageindexchanging="grvMaXepGia_PageIndexChanging" 
                        onrowdatabound="grvMaXepGia_RowDataBound" PageSize="20" >
                        <PagerSettings Position="TopAndBottom" />
                        <Columns>
                            <asp:TemplateField HeaderText="CheckAll">
                              <HeaderTemplate>
                                <asp:CheckBox ID="cbxCheckAll" runat="server" />
                            </HeaderTemplate>                             
                            <ItemTemplate>
                                <asp:CheckBox ID="cbxDKCB" runat="server" />
                            </ItemTemplate>
                              
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                              
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Mã xếp giá" DataField="MaXepGia" 
                                ApplyFormatInEditMode="True">
                                <ItemStyle Width="100px" HorizontalAlign="Left" VerticalAlign="Middle" 
                                    Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NhanDe" HeaderText="Nhan đề">
                                <ItemStyle Width="250px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Kho">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DrdlKho" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("TenKho") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="15%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Shelf" HeaderText="Giá">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Trạng thái">
                                <EditItemTemplate>
                                    <asp:Label  ID="lbTrangThai" runat="server"></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbTrangThai" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" Font-Bold="True" ForeColor="Blue" />
                    </asp:GridView>
                </td>
            </tr>
            <tr class="TVLibPageTitle" id="trChucNang" runat="server">
            <td colspan="2">
            <asp:Label ID="Label4" runat="server" Text="Lý do thanh lý"></asp:Label>
            </td>
            <td width="7%" align="left">
                <asp:DropDownList ID="ddlLyDoLoaiBo" runat="server">
                </asp:DropDownList>
                </td>
            <td colspan="2" align="left" >
                                &nbsp;
                <asp:Button ID="btnThanhLy" runat="server" Text="Thanh lý" onclick="btnThanhLy_Click" />&nbsp;
                <asp:Button ID="BtnKiemNhan" runat="server" Text="Kiểm nhận/Mở khóa" 
                                    onclick="BtnKiemNhan_Click"  />
                &nbsp;<asp:Button ID="btnPhucHoi" runat="server" Text="Phục hồi" OnClick="btnPhucHoi_Click"  />
                </td>
            </tr>
            </table>
      
    </div>
   </asp:Content>