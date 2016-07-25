<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TongHop.aspx.cs" Inherits="AnPhamDinhKy_TongHop" MasterPageFile="~/MasterPage.master" %>



<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
    <div align="right">
 <TABLE id="Table1" cellPadding="2" width="970px" border="0" align="center"  >
     <tr  class="TVLibPageTitle" >
                <td height="10" colspan="3" align="left">&nbsp;&nbsp;
                    <asp:Label  ID="Label6" runat="server" Text="DANH SÁCH THÔNG TIN BỔ SUNG SỐ ẤN PHẨM NHIỀU KỲ "></asp:Label>
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
                        <asp:Label ID="lblTacGia" runat="server" Text="Tác Giả:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="TxtTacGia" runat="server" Width="60%"></asp:TextBox>
                    </TD>
				</TR>
				<TR align="center">
					<TD align="right">
                        <asp:Label ID="lblMoTa" runat="server" Text="Tóm tắt:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="TxtMoTa" runat="server" Width="100%"></asp:TextBox>
                    </TD>
					<TD align="right">
                        <asp:Label ID="lblTuKhoa" runat="server" Text="Từ Khóa:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="TxtTuKhoa" runat="server" Width="60%"></asp:TextBox>
                    </TD>
				</TR>
				<TR align="center">
					<TD align="right">
                        <asp:Label ID="Label1" runat="server" Text="Mã xếp giá:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtMaXepGia" runat="server" Width="100%"></asp:TextBox>
                    </TD>
					<TD align="right">
                        <asp:Label ID="Label2" runat="server" Text="ISBN:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtChiSoISBN" runat="server" Width="60%"></asp:TextBox>
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
                                <ItemStyle Width="400px" HorizontalAlign="Left" VerticalAlign="Middle" 
                                    Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TongHopSoTapChi" HeaderText="Tổng hợp số tạp chí" 
                                HtmlEncode="False">
                                <ItemStyle HorizontalAlign="Left" Width="400px" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="LienKetSoTapChi" 
                                DataNavigateUrlFormatString="{0}" HeaderText="Bổ sung số tạp chí" 
                                Text="&lt;Img src='../Resources/Images/XG1.jpg' border=0&gt;">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:HyperLinkField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                 
   </td>
   </tr>
   </table> 
    </div>
   </asp:Content>