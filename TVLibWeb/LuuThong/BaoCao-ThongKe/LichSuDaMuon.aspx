<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LichSuDaMuon.aspx.cs" Inherits="LuuThong_LichSuDaMuon" MasterPageFile="~/MasterPage.master" %>

<asp:Content  ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
       <script language="javascript" src="../../Resources/JS/Calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../Resources/Js/TVLib.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0" >
		
		<table align="center" width="970px" >
		<tr>
		<td>		
			<TABLE id="TableCenter" cellSpacing="0" cellPadding="2"  border="0" align="center"  >
				<TR class="TVLibPageTitle">
					<TD colSpan="7">
						<asp:label id="lblTitleGroup" Runat="server"  Width="100%">Thông tin ấn phẩm đã được mượn</asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblPatronCode" Runat="server"><u>S</u>ố thẻ:&nbsp;</asp:label></TD>
					<TD><asp:textbox id="txtSoThe" Runat="server"></asp:textbox></TD>
					<TD align="right"><asp:label id="lblCheckOutDateFrom" Runat="server"><u>M</u>ượn từ ngày:&nbsp;</asp:label></TD>
					<TD><asp:textbox id="txtMuonTuNgay" Runat="server" Width="90" ></asp:textbox>&nbsp;<a onclick="javascript:mThoiGian.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtMuonTuNgay']);
	                              mThoiGian.year_scroll 	=	true;
	                              mThoiGian.time_comp 	=	false;	
                                  </script>
                      </TD>
					<TD align="right"><asp:label id="lblCheckOutDateTo" Runat="server">&nbsp;tớ<u>i</u>:&nbsp;</asp:label></TD>
					<TD><asp:textbox id="txtMuonDenNgay" Runat="server" Width="90"></asp:textbox>&nbsp;<a onclick="javascript:mThoiGian1.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian1	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtMuonDenNgay']);
	                              mThoiGian1.year_scroll 	=	true;
	                              mThoiGian1.time_comp 	=	false;	
                                  </script>
                                  </TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblCopyNumber" Runat="server">Mã <u>x</u>ếp giá:&nbsp;</asp:label></TD>
					<TD><asp:textbox id="txtMaXepGia" Runat="server"></asp:textbox></TD>
					<TD align="right"><asp:label id="lblDueDateFrom" Runat="server"><u>T</u>rả từ ngày:&nbsp;</asp:label></TD>
					<TD><asp:textbox id="txtTraTuNgay" Runat="server" Width="90"></asp:textbox>&nbsp;<a onclick="javascript:mThoiGian2.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian2	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtTraTuNgay']);
	                              mThoiGian2.year_scroll 	=	true;
	                              mThoiGian2.time_comp 	=	false;	
                                  </script>
                                  </TD>
					<TD align="right"><asp:label id="lblDueDateTo" Runat="server">&nbsp;tớ<u>i</u>:&nbsp;</asp:label></TD>
					<TD><asp:textbox id="txtTraDenNgay" Runat="server" Width="90"></asp:textbox>&nbsp;<a onclick="javascript:mThoiGian3.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian3	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtTraDenNgay']);
	                              mThoiGian3.year_scroll 	=	true;
	                              mThoiGian3.time_comp 	=	false;	
                                  </script>
                         </TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblLocationID0" Runat="server">Mã <u>t</u>ài liệu:&nbsp;</asp:label></TD>
					<TD>
                        <asp:TextBox ID="txtMaTaiLieu" runat="server"></asp:TextBox>
                    </TD>
					<TD align="right"><asp:label id="lblLocationID" Runat="server">Tìm trong <u>k</u>ho:&nbsp;</asp:label></TD>
					<TD><asp:dropdownlist id="ddlKho" Runat="server"></asp:dropdownlist></TD>
					<TD></TD>
					<TD><asp:button id="btnFind" Runat="server"  Text="Tìm (t)" 
                            onclick="btnFind_Click"></asp:button>&nbsp;<asp:button id="btnCancel" Runat="server"  Text="Đặt lại(r)"></asp:button></TD>
				</TR>
				<tr class="TVLibFunctionTitle">
					<td colSpan="4">
						<asp:label id="lblTitleDataGrid"  Runat="server">Nhật ký ấn phẩm đã được mượn</asp:label></td>
					<td colSpan="3" align="right">
						<asp:label id="lblTotallb" Runat="server" Visible="False">Tổng số:&nbsp;</asp:label>
						<asp:label id="lblTotal" Runat="server" Visible="False" ></asp:label></td>
				</tr>
				<TR>
					<TD colSpan="7" align="center"  >
						<asp:Label ID="lblNothing" Runat="server" Visible="False" Font-Bold="True" 
                            ForeColor="Maroon"> Không tồn tại dữ liệu thoả mãn điều kiện tìm kiếm</asp:Label>
						<asp:GridView ID="grvDaMuon" runat="server" AutoGenerateColumns="False" 
                            Width="100%" AllowPaging="True" 
                            onpageindexchanging="grvDaMuon_PageIndexChanging" PageSize="20">
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                                <asp:BoundField DataField="NhanDe" HeaderText="Nhan đề" />
                                <asp:BoundField DataField="MaXepGia" HeaderText="Đăng ký cá biệt" />
                                <asp:BoundField DataField="SoThe" HeaderText="Bạn đọc">
                                    <ItemStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NgayMuon" HeaderText="Ngày mượn" />
                                <asp:BoundField DataField="NgayTra" HeaderText="Ngày trả" />
                                <asp:BoundField DataField="SoNgayQuaHan" HeaderText="Ngày quá hạn" />
                                <asp:BoundField DataField="SoTienPhat" HeaderText="Phí phạt" />
                            </Columns>
                        </asp:GridView>
					</TD>
				</TR>
			</TABLE>
		</td>
		</tr>
		</table>	
		
		<script language = "javascript">
			document.forms[0].ctl00$ContentPlaceHolder1$txtSoThe.focus();
		</script>
	</body>
</asp:Content>