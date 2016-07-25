<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangTaiLieu.aspx.cs" Inherits="BoSungBienMuc_DanhMuc_DangTaiLieu" MasterPageFile ="~/MasterPage.master" %>
<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>

<body  topmargin="0" leftmargin="0" onload="document.forms[0].ctl00$ContentPlaceHolder1$txtMaLoaiTaiLieu.focus()">
		
		<table align="center" width="970px" >
		<tr>
		<td >
		   <table align="center" width="970px" >
		   <TR class="TVLibPageTitle">
					<td width="100%" colspan ="2">
						<asp:label id="lblTitle" runat="server">Danh mục loại tài liệu</asp:label></td>
				</TR>
				<TR>
					<td align="right" width="30%">
						<asp:Label ID="Label2" runat="server" Text="Tên loại tài liệu (viết tắt):"></asp:Label>
						</td>
						<td>
						    <asp:TextBox ID="txtMaLoaiTaiLieu" runat="server" Width="20%"></asp:TextBox>
						</td>
				</TR>
				<TR>
					<td align="right" width="30%">
						<asp:Label ID="Label3" runat="server" Text="Tên loại tài liệu (viết đầy đủ):"></asp:Label>
						</td>
						<td>
						    <asp:TextBox ID="txtTenLoaiTaiLieu" runat="server" Width="30%"></asp:TextBox>
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
						<asp:GridView ID="grvLoaiTaiLieu" runat="server" AutoGenerateColumns="False" 
                            Width="100%" DataKeyNames="LoaiTaiLieuID" 
                            onrowcancelingedit="grvLoaiTaiLieu_RowCancelingEdit" 
                            onrowediting="grvLoaiTaiLieu_RowEditing" onrowupdating="grvLoaiTaiLieu_RowUpdating" 
                            AllowPaging="True" onpageindexchanging="grvLoaiTaiLieu_PageIndexChanging" 
                            PageSize="20">
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                               <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Tên loại tài liệu (viết tắt)">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvMaLoaiTaiLieu" runat="server" Text='<%# Bind("TenLoaiTaiLieu") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvMaLoaiTaiLieu" runat="server" Text='<%# Bind("TenLoaiTaiLieu") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
    
                                <asp:TemplateField HeaderText="Tên loại tài liệu (viết đầy đủ)">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvTenLoaiTaiLieu" runat="server" Text='<%# Bind("MoTa") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvTenLoaiTaiLieu" runat="server" Text='<%# Bind("MoTa") %>'></asp:Label>
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
						<asp:label id="lblProvinceMerger" runat="server"><U>D</U>ạng tài liệu: </asp:label>&nbsp;
						<asp:dropdownlist id="drdlLoaiTaiLieu" runat="server"></asp:dropdownlist>&nbsp;
						<asp:button id="btnMerger" runat="server" Text="Gộp(g)" Width="70px" 
                            onclick="btnMerger_Click"></asp:button></TD>
				</TR>
		    </table>
		</td>
		</tr>
		</table>
			
		
	</body>
</asp:Content>
