<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CapNhatMauBienMuc.aspx.cs" Inherits="BoSungBienMuc_CapNhatMauBienMuc" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body>
		
	<table align="center" width="970px" >
		<tr>
		<td >
		    <table id ="TableCenter">
		   <TR class="TVLibPageTitle">
					<td width="100%" >
						<asp:label id="lblTitle" runat="server">Cập nhật mẫu biên mục</asp:label></td>
				</TR> 
				<tr>
				<td align ="center" >
				    <asp:Label ID="Label3" runat="server" Text="Tên mẫu biên mục:"></asp:Label>
                                        &nbsp;
                    <asp:TextBox ID="txtTenMauBienMuc" runat="server"></asp:TextBox>
                            &nbsp;
                    <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật(u)" 
                        onclick="btnUpdate_Click" />
				</td>
				</tr>
				<TR>
					<TD >
						<asp:GridView ID="grvMauBienMuc" runat="server" AutoGenerateColumns="False" 
                            Width="100%" DataKeyNames="ID,Marc_Field_ID" 
                            onrowcancelingedit="grvMauBienMuc_RowCancelingEdit" 
                            onrowediting="grvMauBienMuc_RowEditing" 
                            onrowupdating="grvMauBienMuc_RowUpdating" 
                            onrowdeleting="grvMauBienMuc_RowDeleting" >
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                               <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Trường con">                                  
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvMaMauBienMuc" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                    </ItemTemplate>
                                      <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mô tả">
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvTenMauBienMuc" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Giá trị mặc định">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtGiaTriMacDinh" runat="server" Text='<%# Bind("GiaTriMacDinh") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("GiaTriMacDinh") %>'></asp:Label>
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
                                            CommandName="Delete" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa?');" ImageUrl="~/Resources/Images/delete.gif" Text="Delete" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </TD>
				</TR>
				<TR style ="background-color:Silver" >
					<TD align="center" >
					 <asp:Button ID="btnCapNhat" runat="server" Text="Thêm trường(a)" 
                onclick="btnCapNhat_Click" />
            &nbsp;
						<asp:button id="btnClose" runat="server" Text="Đóng(c)" 
                            onclick="btnClose_Click" ></asp:button></TD>
				</TR>
		    </table>
		</td>
		</tr>
		</table>
			
		
	</body>

</asp:Content>