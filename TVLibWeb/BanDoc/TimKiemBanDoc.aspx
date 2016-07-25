<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimKiemBanDoc.aspx.cs" Inherits="BanDoc_TimKiemBanDoc" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
     <script language="javascript" src="../Resources/JS/Calendar.js" type="text/javascript"></script>

<body>
		
			<table align="center" width="970px" cellspacing=10 >
				<TR class="TVLibPageTitle">
					<TD align="center" colspan="4">
						<ASP:LABEL id="lblSearch" runat="server"  Width="100%">Tìm kiếm bạn đọc</ASP:LABEL></TD>
				</TR>
				<TR>
					<TD align="right" width="25%">
						<ASP:LABEL id="lblCode" runat="server">Số <u>t</u>hẻ: </ASP:LABEL></TD>
					<TD width="25%">
						<ASP:TEXTBOX id="txtSoThe" runat="server" Width="120px"></ASP:TEXTBOX></TD>
					<TD align="right" width="12%">
						<ASP:LABEL id="lblFullName" runat="server"><u>H</u>ọ tên: </ASP:LABEL></TD>
					<TD width="38%">
						<ASP:TEXTBOX id="txtTenDayDu" runat="server" Width="35%"></ASP:TEXTBOX></TD>
				</TR>
				<TR>
					<TD align="right" width="25%">
						<ASP:LABEL id="lblSex" runat="server"><u>G</u>iới tính: </ASP:LABEL></TD>
					<TD width="25%">
						<ASP:DROPDOWNLIST id="drdlGioiTinh" runat="server" Width="120px">
							<asp:ListItem Value="0">-------- Chọn --------</asp:ListItem>
							<asp:ListItem Value="true">Nam</asp:ListItem>
							<asp:ListItem Value="false">Nữ</asp:ListItem>
						</ASP:DROPDOWNLIST></TD>
					<TD align="right" width="12%">
						<ASP:LABEL id="lblDOB" runat="server"><u>N</u>gày sinh: </ASP:LABEL></TD>
					<TD width="38%">
						<ASP:TEXTBOX id="txtNgaySinh" runat="server" Width="120px"></ASP:TEXTBOX>&nbsp;
						<a onclick="javascript:mNgaySinh.popup();" href="javascript:;"><img alt="Chọn ngày" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mNgaySinh	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtNgaySinh']);
	                  mNgaySinh.year_scroll 	=	true;
	                  mNgaySinh.time_comp 	=	false;	
                      </script> 
						</TD>
				</TR>
				<TR>
					<TD align="right" width="25%">
						<ASP:LABEL id="lblValidDate" runat="server">Ngày <u>c</u>ấp thẻ: </ASP:LABEL></TD>
					<TD width="25%">
						<ASP:TEXTBOX id="txtNgayCapThe" runat="server" Width="120px"></ASP:TEXTBOX>&nbsp;
						 <a onclick="javascript:mNgayCapThe.popup();" href="javascript:;"><img alt="Chọn ngày" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mNgayCapThe	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtNgayCapThe']);
	                  mNgayCapThe.year_scroll 	=	true;
	                  mNgayCapThe.time_comp 	=	false;	
                      </script>    </TD>
					<TD align="right" width="12%">
						<ASP:LABEL id="lblExpiredDate" runat="server">Ngà<u>y</u> hết hạn: </ASP:LABEL></TD>
					<TD width="38%">
						<ASP:TEXTBOX id="txtNgayHetHan" runat="server" Width="120px"></ASP:TEXTBOX>&nbsp;
						<a onclick="javascript:mNgayHetHan.popup();" href="javascript:;"><img alt="Chọn ngày" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mNgayHetHan	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtNgayHetHan']);
	                  mNgayHetHan.year_scroll 	=	true;
	                  mNgayHetHan.time_comp 	=	false;	
                      </script> 
						</TD>
				</TR>
				<TR>
					<TD align="right" width="25%" valign="top">
						<ASP:LABEL id="lblGroupID" runat="server">Nhóm <U>b</U>ạn đọc: </ASP:LABEL></TD>
					<TD>
						<ASP:LISTBOX id="lstNhomBanDoc" runat="server" selectionmode="Multiple" 
                            height="64px" Width="50%"></ASP:LISTBOX></TD>
					<td></td>
					<td></td>
				</TR>
				<TR>
				    <td align ="right" >
                        <asp:Label ID="Label21" runat="server" Text="Khóa:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKhoas" runat="server" AutoPostBack="false" 
                            onselectedindexchanged="ddlKhoas_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
						<ASP:LABEL id="lblOccupation0"  runat="server"><u>D</u>ân tộc:</ASP:LABEL></TD>
					<TD width="38%">
						<ASP:DROPDOWNLIST id="drdlDanToc" runat="server" Width="120px"></ASP:DROPDOWNLIST></TD>
				</TR>
				<TR>
					<td align ="right" >
                        <asp:Label ID="Label22" runat="server" Text="Lớp:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLop" runat="server" AutoPostBack="False" ></asp:DropDownList>
                    </td>
					<TD align="right" width="12%">
						<ASP:LABEL id="lblOccupation" runat="server">N<u>g</u>ành nghề:</ASP:LABEL></TD>
					<TD width="38%">
						<ASP:DROPDOWNLIST id="drdlNganhNghe" runat="server" Width="35%"></ASP:DROPDOWNLIST></TD>
				</TR>
				<TR>
					<TD align="right" width="25%">
						&nbsp;</TD>
					<TD width="25%">
						<asp:button id="btnSearch" runat="server" text="Tìm kiếm(m)" Width="98px" 
                            TabIndex="0" onclick="btnSearch_Click"></asp:button>
						&nbsp;<asp:button id="btnReset" runat="server" text="Làm lại(i)" Width="78px" TabIndex="1"></asp:button>
						</TD>
					<TD align="right" width="12%">
						&nbsp;</TD>
					<TD width="38%">
						&nbsp;</TD>
				</TR>
				<TR>
					<TD align="right" width="25%">
						&nbsp;</TD>
					<TD colspan="3">
						&nbsp;</TD>
				</TR>
				<TR>
					<td></td>
					<TD colspan="3">
						&nbsp;</TD>
				</TR>
			</TABLE>
			
			<input type=hidden runat=server id="hidPatronGroupIDs">
			<INPUT type="hidden" runat="server" id="txtFieldShow" value="0,1,2,17"> <INPUT type="hidden" runat="server" id="txtPageSize" value="20">

	</body>
</asp:Content>
