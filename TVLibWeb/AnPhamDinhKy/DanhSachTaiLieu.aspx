<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachTaiLieu.aspx.cs" Inherits="AnPhamDinhKy_DanhSachTaiLieu" MasterPageFile="~/MasterPage.master" %>



<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
    <div align="right">
 <TABLE id="Table1" cellPadding="2" width="970px" border="0" align="center"  >
     <tr  class="TVLibPageTitle" >
                <td height="10" colspan="3" align="left">&nbsp;&nbsp;
                    <asp:Label  ID="Label6" runat="server" Text="DANH SÁCH ẤN PHẨM NHIỀU KỲ"></asp:Label>
               </td>
               <td align="right" >
                </td>
            </tr>
            <tr>
                <TD align="right">
                        <asp:Label ID="Label3" runat="server" Text="Dạng tài liệu:"></asp:Label>
                    </TD>
					<TD align="left" colspan="2">
                      
                        <asp:DropDownList ID="drdlLoaiTaiLieu" runat="server" width="76%" 
                            onselectedindexchanged="drdlLoaiTaiLieu_SelectedIndexChanged" 
                            Enabled="False" Height="22px" >
                        </asp:DropDownList>
                      
                    </TD>
                <td align="right" >
               <asp:HyperLink ID="lnkQuanLyTaiLieu" Font-Bold=True 
                        NavigateUrl="~/BoSungBienMuc/MauBienMucIndex.aspx" runat="server" ><Font Color='Blue'>&#160;&#160;&#160;&gt;* THÊM MỚI TÀI LIỆU</Font></asp:HyperLink>
                </td>
            </tr>
           <TR align="center">
					<TD align="right" width="10%">
                        <asp:Label ID="lblNhanDe" runat="server" Text="Nhan Đề:"></asp:Label>
                    </TD>
					<TD align="left" width="30%">
                        <asp:TextBox ID="TxtNhanDe" runat="server" Width="100%" 
                            style="margin-left: 0px"></asp:TextBox>
                    </TD>
					<TD align="right" width="10%">
                        <asp:Label ID="lblTacGia" runat="server" Text="Nhà xuất bản:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtNhaXuatBan" runat="server" Width="68%"></asp:TextBox>
                    </TD>
				</TR>
				<tr>
				<td colspan="4" align="center">
				
				    &nbsp;</td>
				</tr>
				<tr class="TVLibPageTitle">
				<td colspan="4" align="center" class="style1">
				
				    <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" onclick="btnTimKiem_Click" 
                        />&nbsp;
                    <asp:Button ID="btnLamLai" runat="server" Text="Làm lại" />
				
				</td>
				</tr>
            <tr>
            <td height="17" colspan ="2" align="left" valign="middle">
                	<asp:label id="lblTotallb0" Runat="server" Font-Bold="True" 
                    ForeColor="#0066FF">&nbsp;&nbsp;&nbsp;Số bản ghi trên trang:</asp:label>
						&nbsp;<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlPageSize_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="10">10 kết quả</asp:ListItem>
                    <asp:ListItem Value="20">20 kết quả</asp:ListItem>
                    <asp:ListItem Value="50">50 kết quả</asp:ListItem>
                    <asp:ListItem Value="100">100 kết quả</asp:ListItem>
                    <asp:ListItem Value="200">200 kết quả</asp:ListItem>
                    <asp:ListItem Value="500">500 kết quả</asp:ListItem>
                </asp:DropDownList>
                </td> 
                <td height="17" colspan ="2" align="right" >
                	<asp:label id="lblTotallb" Runat="server" Font-Bold="True" ForeColor="#0066FF">&nbsp;&nbsp;&nbsp;Tổng số bản ghi:&nbsp;</asp:label>
						<asp:label id="lblTotal" Runat="server" Font-Bold="True" ForeColor="#990000"></asp:label>
              </td>
            </tr>
            <tr>
            <td height="17" colspan ="2">&nbsp;</td> 
                <td height="17" colspan ="2" align="right" >
                	&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" ><asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False" 
                        Width="100%" DataKeyNames="TaiLieuID"   onrowdeleting="grvTaiLieu_RowDeleting" AllowPaging="True" 
                        onpageindexchanging="grvTaiLieu_PageIndexChanging" PageSize="20" >
                        <PagerSettings Position="TopAndBottom" />
                        <Columns>
                            <asp:BoundField DataField="STT" HeaderText="STT" >
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Nhan đề" DataField="NhanDe" 
                                ApplyFormatInEditMode="True">
                                <ItemStyle Width="500px" HorizontalAlign="Left" VerticalAlign="Middle" 
                                    Wrap="True" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="LienKetSoTapChi" 
                                DataNavigateUrlFormatString="{0}" HeaderText="Bổ sung số tạp chí" 
                                Text="&lt;Img src='../Resources/Images/XG1.jpg' border=0&gt;">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:HyperLinkField>
                            <asp:HyperLinkField DataNavigateUrlFields="LienKetTongHop" 
                                DataNavigateUrlFormatString="{0}" HeaderText="T.Tin tổng hợp" 
                                Text="&lt;Img src='../Resources/Images/XG1.jpg' border=0&gt;">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                            <asp:HyperLinkField DataNavigateUrlFields="LienKetSoTapChi" 
                                DataNavigateUrlFormatString="{0}" HeaderText="Đóng tập" 
                                Text="&lt;Img src='../Resources/Images/XG1.jpg' border=0&gt;">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                            <asp:HyperLinkField HeaderText="Biên mục" DataNavigateUrlFields="LienKetSuaAPDK" 
                                DataNavigateUrlFormatString="{0}" 
                                Text="&lt;Img src='../Resources/Images/Edit.gif' border=0&gt;" >
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                            </asp:HyperLinkField>
                            <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False"  OnClientClick="return confirm('Bạn có chắc chắn muốn xóa?');"
                                        CommandName="Delete" ImageUrl="~/Resources/Images/delete.gif" Text="Delete" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                 
   </td>
   </tr>
   </table> 
    </div>
   </asp:Content>