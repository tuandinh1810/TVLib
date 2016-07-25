<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Kho.aspx.cs" Inherits="BoSungBienMuc_Kho_Kho" MasterPageFile="~/MasterPage.master" %>
<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
	<table align="center" width="970px" >
		<tr>
		<td >
		    <table id ="TableCenter">
		   <TR class="TVLibPageTitle">
					<td width="100%" colspan ="2">
						<asp:label id="lblTitle" runat="server">Danh mục Kho</asp:label></td>
				</TR> 
				<tr>
				<td colspan ="2">
				    <asp:Label ID="Label4" runat="server" Text="Chọn thư viện:"></asp:Label>
				
				    <asp:DropDownList ID="drdlThuVien" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="drdlThuVien_SelectedIndexChanged">
                    </asp:DropDownList>
				
					
						&nbsp;&nbsp;&nbsp;
				</td>
				</tr>
				<tr>
				<td colspan ="2">
					
						<asp:Label ID="Label2" runat="server" Text="Tên Kho (viết tắt):"></asp:Label>
						
						    <asp:TextBox ID="txtMaKho" runat="server"></asp:TextBox>
				
						&nbsp;&nbsp;&nbsp;
				
						<asp:Label ID="Label3" runat="server" Text="Tên Kho (viết đầy đủ):"></asp:Label>
						
						    <asp:TextBox ID="txtTenKho" runat="server"></asp:TextBox>
						
				
						    &nbsp;&nbsp;
						
				
						    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Thêm mới" />
&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Đặt lại" />
						</td>
				</TR>
					
				<TR>
					<TD colspan ="2">
						<asp:GridView ID="grvKho" runat="server" AutoGenerateColumns="False" 
                            Width="100%" DataKeyNames="KhoID" 
                            onrowcancelingedit="grvKho_RowCancelingEdit" 
                            onrowediting="grvKho_RowEditing" onrowupdating="grvKho_RowUpdating" 
                            AllowPaging="True" onpageindexchanging="grvKho_PageIndexChanging" 
                            PageSize="20">
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                               <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Tên Kho (viết tắt)">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvMaKho" runat="server" Text='<%# Bind("MaKho") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvMaKho" runat="server" Text='<%# Bind("MaKho") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên Kho (viết đầy đủ)">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvTenKho" runat="server" Text='<%# Bind("TenKho") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvTenKho" runat="server" Text='<%# Bind("TenKho") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Số thứ tự MXG">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvSTTMXG" runat="server" Text='<%# Bind("MaxMaXepGia") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvSTTMXG" runat="server" Text='<%# Bind("MaxMaXepGia") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" 
                                    CancelImageUrl="~/Resources/Images/Cancel.gif" 
                                    EditImageUrl="~/Resources/Images/Edit.gif" HeaderText="Sửa" 
                                    ShowEditButton="True" UpdateImageUrl="~/Resources/Images/update.gif" >
                                     <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:CommandField>
                                     <asp:TemplateField HeaderText="Chọn">                               
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>                               
                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="false"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </TD>
				</TR>
				<TR style ="background-color:Silver" >
					<TD align="right" colspan ="2">
						<asp:label id="lblProvinceMerger" runat="server"><U>K</U>ho: </asp:label>&nbsp;
						<asp:dropdownlist id="drdlKho" runat="server"></asp:dropdownlist>&nbsp;
						<asp:button id="btnMerger" runat="server" Text="Gộp(g)" Width="70px" 
                            onclick="btnMerger_Click"></asp:button></TD>
				</TR>
		    </table>
		</td>
		</tr>
		</table>
			
		</asp:Content>