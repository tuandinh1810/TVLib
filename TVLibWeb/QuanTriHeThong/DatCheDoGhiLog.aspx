<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatCheDoGhiLog.aspx.cs" Inherits="QuanTriHeThong_DatCheDoGhiLog" MasterPageFile="~/MasterPage.master" %>



<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body >
		
			  <table align="center" width="970px" >
                  <tr  >
                <td >
                 <table ID ="TableCenter">
				<TR class ="TVLibPageTitle" >
					<TD>
						<asp:Label id="lblPageTitle" runat="server"   Width="100%">Thiết lập chế độ ghi nhật ký hệ thống</asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lblGroup" runat="server"><U>N</U>hóm sự kiện:</asp:Label>
						<asp:DropDownList id="ddlGroup" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlGroup_SelectedIndexChanged1"></asp:DropDownList>
                    </TD>
				</TR>
				<TR>
					<TD>
					
						<asp:GridView ID="dtgEvents" runat="server" AutoGenerateColumns="False" 
                            PageSize="50" Width="100%">
                            <Columns>
                            <asp:TemplateField HeaderText="ChucNangID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ChucNangID") %>'></asp:Label>
                                    </ItemTemplate>                                  
                                </asp:TemplateField>
                                <asp:TemplateField>
                                   <HeaderTemplate>
										<input class="lbCheckBox" type="checkbox" id="chkCheckAll" onclick="javascript: CheckAllOptionsVisible('ctl00_ContentPlaceHolder1_dtgEvents', 'chkID', 2, 50);">
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox id="chkID" Runat="server" Checked='<%# Bind("LogMode") %>'>
										</asp:CheckBox>
									</ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="TenChucNang" HeaderText="Tên sự kiện">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                
                            </Columns>
                        </asp:GridView>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Button id="btnUpdate" runat="server" Width="90px" Text="Cập nhật(u)" 
                            onclick="btnUpdate_Click1"></asp:Button></TD>
				</TR>
			</TABLE>
			</td>
			</tr>
			</table>
			

	</body>
</asp:Content>
