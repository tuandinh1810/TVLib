<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false"  MasterPageFile="~/MasterPage.master"  CodeFile="QTTinTuc.aspx.cs" Inherits="QTTinTuc" %>
<%@ Register TagPrefix="FTB"  Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<TABLE  width ="850px" align="center" bgColor="#f0f3f4" border="0">
				<tr>
				<td colspan="6" align="center" >
                    <asp:Label ID="Label2" runat="server" Text="QUẢN TRỊ TIN TỨC" Font-Bold="True" 
                        ForeColor="#000099"></asp:Label>
				</td>
				</tr>
				<TR width="100%">
					<td align="left" colSpan="1"><asp:label id="lblTieuDe" runat="server" Height="23px" Font-Bold="True"><U>T</U>iêu đề:</asp:label></td>
					<td align="left" colSpan="4"><asp:textbox id="txtTieuDe" runat="server" Height="25px" Width="288px"></asp:textbox></td>
					<td align="right" colSpan="1"></td>
				</TR>
				
				<TR>
					<TD align="left" colSpan="1">
						<asp:label id="lblTomTat" runat="server" Font-Bold="True" Height="23px" Visible="False"> Tóm tắt:</asp:label></TD>
					<td align="left" colSpan="5">&nbsp;</td>
				</TR>
				<TR>
					<TD align="left" colSpan="6">
						<table width="100%">
							<TR>
								<TD align="center">
									<FTB:FreeTextBox id="txtTomTat" Width="100%" Height="100px" SupportFolder="FreeTextBox" JavaScriptLocation="InternalResource" ToolbarImagesLocation="InternalResource"  ButtonImagesLocation="InternalResource" runat="server"  ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"/></TD>
							</TR>
							<TR>
								<TD align="left">
									<asp:label id="lblNoiDung" runat="server" Font-Bold="True" Height="23px" Visible="False"> Nội dung</asp:label></TD>
							</TR>
							<tr>
								<td align="center" colSpan="1">
								<FTB:FreeTextBox id="txtNoiDung" Width="100%" Height="250px" SupportFolder="FreeTextBox" JavaScriptLocation="InternalResource" ToolbarImagesLocation="InternalResource"  ButtonImagesLocation="InternalResource" runat="server"  ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print"/>
									<!-- add a submit button--></td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="1"></TD>
					<TD align="left" colSpan="5">
                        <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới"   Font-Bold="True"
                            onclick="btnThemMoi_Click" />
&nbsp;&nbsp;&nbsp;&nbsp; <asp:button id="btnUpdate" runat="server" 
                            Font-Bold="True" Text=" Cập nhật" onclick="btnUpdate_Click"></asp:button><asp:label id="lblUpdateSuccess" runat="server" Visible="False">Cập nhật thành công!</asp:label><asp:label id="lblUpdateFail" runat="server" Visible="False">Cập nhật có lỗi!</asp:label></TD>
				</TR>
				<tr >
				<td colspan="8" >
				    <asp:label id="Label1" runat="server" Height="23px" Font-Bold="True" 
                        ForeColor="#000099" Width="100%">DANH SÁCH TIN TỨC</asp:label>
				</td>
				</tr>
				<tr>
				<td colspan="8">
				    <asp:GridView ID="grvTinTuc" runat="server" Width="100%" AllowPaging="True" 
                        AutoGenerateColumns="False" DataKeyNames="TinTucID" PageSize="15" 
                        onpageindexchanging="grvTinTuc_PageIndexChanging" 
                        onrowdeleting="grvTinTuc_RowDeleting" 
                        onselectedindexchanging="grvTinTuc_SelectedIndexChanging">
                        <PagerSettings Position="TopAndBottom" />
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                               
                                <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="TieuDe" HeaderText="Tiêu đề" />
                            <asp:CommandField HeaderText="Sửa" ShowSelectButton="True" ButtonType="Image" 
                                SelectImageUrl="~/Resources/Images/Edit.gif">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa?');"
                                        CommandName="Delete" ImageUrl="~/Resources/Images/delete.gif" Text="Delete" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <input type="hidden" runat="server" id="hdID" value="0" />
				</td>
				</tr>
			</TABLE>
			
			</asp:Content> 