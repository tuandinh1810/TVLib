<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NhomBanDoc.aspx.cs" Inherits="BanDoc_NhomBanDoc" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout" onload="document.forms[0].ctl00$ContentPlaceHolder1$txtNhomBanDoc.focus()">
			<TABLE id="Table1" cellPadding="2" width="970px" align="center" border="0">
				<TR class="TVLibPageTitle">
					<td align="center" width="100%" colSpan="2">
						<asp:label id="lblTitle" runat="server" >Thông tin nhóm bạn đọc</asp:label></td>
				</TR>
				<tr>
					<td align="right" width="30%"><asp:label id="lblPatronGroup" Runat="server"><U>N</U>hóm bạn đọc:</asp:label></td>
					<td><asp:dropdownlist id="drdlNhomBanDoc" Runat="server" AutoPostBack="True" 
                            onselectedindexchanged="drdlNhomBanDoc_SelectedIndexChanged"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td align="right">
						<asp:label id="lblNameGroup" Runat="server">Tên nhó<U>m</U>:</asp:label></td>
					<td>
						<asp:textbox id="txtNhomBanDoc" Runat="server" MaxLength="32"></asp:textbox>&nbsp;
						<asp:label id="lblMan" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc" Runat="server">(*)</asp:label>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<hr width="100%">
					</td>
				</tr>
			</TABLE>
			<TABLE id="Table2" cellPadding="2" width="100%" align="center" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table cellPadding="2" width="100%">
							<tr>
								<td align="right" width="60%"><asp:label id="lblLoanQuota" Runat="server"><U>S</U>ố sách được mượn về:</asp:label></td>
								<td><asp:textbox id="txtSoSachMuonVe" Runat="server" Width="80px" MaxLength="2"></asp:textbox></td>
							</tr>
							<tr>
								<td align="right">
                                    <asp:Label ID="Label1" runat="server" Text="&lt;u&gt;C&lt;/u&gt;ấp độ mật:"></asp:Label>
                                </td>
								<td>
                                    <asp:DropDownList ID="drdlCapDoMat" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
							</tr>
							<tr>
								<td align="right">
                                    &nbsp;</td>
								<td>
                                    &nbsp;</td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblInlibraryQuota" Runat="server" Visible="False">Số sách được mượn <u>t</u>ại chỗ:</asp:label></td>
								<td><asp:textbox id="txtSoSachMuonTaiCho" Runat="server" Width="80px" MaxLength="2" 
                                        Visible="False">0</asp:textbox></td>
							</tr>
							<tr>
								<td align="right">&nbsp;</td>
								<td vAlign="top">&nbsp;</td>
							</tr>
							<tr>
								<td align="right">&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td align="right">&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
					<td vAlign="top">
						<table cellPadding="2" width="100%">
							<tr>
								<td></td>
								<td></td>
								<td colSpan="2"><asp:label id="lblStore" Runat="server">Các <U>k</U>ho được quyền mượn</asp:label></td>
							</tr>
							<tr>
								<td width="45%"><asp:listbox id="lstKho" Runat="server" Width="100%" 
                                        SelectionMode="Multiple" Rows="11"></asp:listbox></td>
								<td align="center" width="10%"><asp:button id="btnAdd" Runat="server" Text=" >> "></asp:button><br>
									<asp:button id="btnRemove" Runat="server" Text=" << "></asp:button></td>
								<td><asp:listbox id="lstKhoBanDoc" Runat="server" Width="100%" 
                                        SelectionMode="Multiple" Rows="11"></asp:listbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style ="background-color :Silver ">
					<td align="center" colSpan="2"><asp:button id="btnUpdate" Runat="server" 
                            Width="98px" Text="Cập nhật(u)" onclick="btnUpdate_Click"></asp:button>&nbsp;&nbsp;
						<asp:button id="btnReset" Runat="server" Width="82px" Text="Làm lại(r)"></asp:button>&nbsp;&nbsp;
						<asp:button id="btnDelete" Runat="server" Width="64px" Text="Xoá(d)" 
                            onclick="btnDelete_Click"></asp:button>
                            <input id="hidKhoIDs" type="hidden" name="hidKhoIDs" runat="server">
                            </td>
				</tr>
			</TABLE>
			
		
	</body>
</asp:Content>
