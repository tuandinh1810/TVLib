<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KhoaThe.aspx.cs" Inherits="BanDoc_KhoaThe" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
    <script language="javascript" src="../Resources/JS/Calendar.js" type="text/javascript"></script>

<body topMargin="0" onload="document.forms[0].ctl00$ContentPlaceHolder1$txtSoThe.focus();">
		
			<table align="center" width="970px" >
			<tr>
			    <td>			
			    <TABLE id="TableCenTer">
				<TR class ="TVLibPageTitle">
					<TD vAlign="top" colSpan="4">
						<asp:label id="lblPageTitle" runat="server"  Width="100%">Thông tin thẻ bạn đọc bị khoá</asp:label></TD>
				</TR>
				<TR class="TVLibFunctionTitle">
					<TD colSpan="4" vAlign="top">
						<asp:label id="lblLockPatronCode" Runat="server"  Width="100%">Khoá thẻ</asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%">
						<asp:label id="lblPatronCodeText" Runat="server"><U>S</U>ố thẻ:&nbsp;</asp:label></TD>
					<TD width="20%">
						<asp:textbox id="txtSoThe" Runat="server" Width="112px"></asp:textbox></TD>
					<TD align="center" width="72" style="WIDTH: 72px">
						<asp:label id="lblNoteText" Runat="server"><U>G</U>hi chú:&nbsp;</asp:label></TD>
					<TD vAlign="top" height="100%" rowSpan="3">
						<asp:textbox id="txtGhiChu" Runat="server" Width="304px" TextMode="MultiLine" Rows="5" Columns="30"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblStartedDateText" Runat="server"><U>N</U>gày bắt đầu:&nbsp;</asp:label></TD>
					<TD>
						<asp:textbox id="txtNgayBatDau" Runat="server" Width="112px"></asp:textbox>
						 <a onclick="javascript:mNgayBatDau.popup();" href="javascript:;"><img alt="Chọn ngày" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mNgayBatDau	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtNgayBatDau']);
	                  mNgayBatDau.year_scroll 	=	true;
	                  mNgayBatDau.time_comp 	=	false;	
                      </script>    
						</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblLockedDaysText" Runat="server">Số n<U>g</U>ày:&nbsp;</asp:label></TD>
					<TD>
						<asp:textbox id="txtSoNgay" Runat="server" Width="112px"></asp:textbox></TD>
					<TD style="WIDTH: 72px"></TD>
				</TR>
				<TR>
					<TD colspan="4" align="center">
						<asp:button id="btnKhoa" Runat="server" Text="Khoá(k)" Width="64px" 
                            onclick="btnKhoa_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4" height="3"><hr color="#999999" 
                            style="height: -12px" >
					</TD>
				</TR>
				
				<TR class="TVLibFunctionTitle">
					<TD align="left" colSpan="4">
						<asp:label id="lblPatronLockCodes" Runat="server" CssClass="lbSubFormTitle">Danh sách những thẻ đang bị khoá</asp:label></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="4">
				        <asp:GridView ID="grvKhoaThe" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" Width="100%" DataKeyNames="BanDocID" 
                            onrowcancelingedit="grvKhoaThe_RowCancelingEdit" 
                             onrowediting="grvKhoaThe_RowEditing" 
                            onrowupdating="grvKhoaThe_RowUpdating">
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                                <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%#  Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            </asp:TemplateField>
                                <asp:BoundField DataField="SoThe" HeaderText="Số thẻ" ReadOnly="True" />
                                <asp:BoundField DataField="TenDayDu" HeaderText="Tên bạn đọc" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Ngày khoá">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvNgayBatDau" runat="server" Text='<%# Bind("NgayBatDau") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("NgayBatDau") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Số ngày khoá">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvSoNgay" onkeypress="if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;" runat="server" Text='<%# Bind("SoNgay") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("SoNgay") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NgayKetThuc" HeaderText="Ngày kết thúc" 
                                    ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Ghi chú">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvGhiChu" width="100%" runat="server" Text='<%# Bind("GhiChu") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("GhiChu") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="25%" />
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" 
                                    EditImageUrl="~/Resources/Images/Edit.gif" HeaderText="Sửa" 
                                    ShowEditButton="True" UpdateImageUrl="~/Resources/Images/update.gif" 
                                    CancelImageUrl="~/Resources/Images/Cancel.gif">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:CommandField>
                                 <asp:TemplateField>
                                   <HeaderTemplate>
										<input  type="checkbox" id="chkCheckAll" onclick="javascript: CheckAllOptionsVisible('grvKhoaThe', 'chkID', 2, 50);">
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox id="chkID" Runat="server" >
										</asp:CheckBox>
									</ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
				</TD>
				</TR>
				<TR>
					<TD align="right" colSpan="4">
						<asp:button id="btnDelete" Runat="server" Text="Mở(d)" Width="64px" 
                            onclick="btnDelete_Click" Visible="False"></asp:button></TD>
				</TR>
			</TABLE>	
			</td>
			</tr>
			</TABLE>
				
			
		</form>
	</body>
</asp:Content>