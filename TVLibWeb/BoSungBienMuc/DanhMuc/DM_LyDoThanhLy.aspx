<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DM_LyDoThanhLy.aspx.cs" Inherits="BoSungBienMuc_DM_LyDoThanhLy" MasterPageFile="~/MasterPage.master"  %>
<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body  topmargin="0" leftmargin="0" onload="document.forms[0].ctl00$ContentPlaceHolder1$txtNoiDungLydo.focus()">
		
		<table align="center" width="970px" >
		<tr>
		<td >
		    <table id ="TableCenter">
		   <TR class="TVLibPageTitle">
					<td width="100%" colspan ="2">
						<asp:label id="lblTitle" runat="server">Danh mục Lý do thanh lý</asp:label></td>
				</TR>
				<TR>
					<td align="right" width="30%">
						<asp:Label ID="Label2" runat="server" Text="Nội dung lý do:"></asp:Label>
						</td>
						<td>
						    <asp:TextBox ID="txtNoiDungLydo" runat="server" Width="20%"></asp:TextBox>
						</td>
				</TR>
				<TR  style ="background-color :Silver ">
					<td align="right" width="30%">
						</td>
						<td>
						    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Thêm mới" />
&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Đặt lại" />
						</td>
				</TR>
					
				<TR>
					<TD colspan ="2">
						<asp:GridView ID="grvLyDo" runat="server" AutoGenerateColumns="False" 
                            Width="100%" DataKeyNames="LyDoID" 
                            onrowcancelingedit="grvLyDo_RowCancelingEdit" 
                            onrowediting="grvLyDo_RowEditing" onrowupdating="grvLyDo_RowUpdating" 
                            AllowPaging="True" onpageindexchanging="grvLyDo_PageIndexChanging" 
                            PageSize="20" onrowdeleting="grvLyDo_RowDeleting">
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                               <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nội dung lý do">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvNoiDungLydo" runat="server" Text='<%# Bind("NoiDungLydo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvNoiDungLydo" runat="server" Text='<%# Bind("NoiDungLydo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:CommandField ButtonType="Image" 
                                    CancelImageUrl="~/Resources/Images/Cancel.gif" 
                                    EditImageUrl="~/Resources/Images/Edit.gif" HeaderText="Sửa" 
                                    ShowEditButton="True" UpdateImageUrl="~/Resources/Images/update.gif" >
                                     <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:CommandField>
                                     <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                                         <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                                             OnClientClick="return confirm('Bạn có chắc chắn muốn xóa?');"     CommandName="Delete" ImageUrl="~/Resources/Images/delete.gif" Text="Delete" />
                                         </ItemTemplate>
                                         <HeaderStyle HorizontalAlign="Center" />
                                         <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </TD>
				</TR>				
		    </table>
		</td>
		</tr>
		</table>
			
		
	</body>
</asp:Content>