<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongKeLuotBanDocPhongDocMo.aspx.cs" Inherits="LuuThong_BaoCao_ThongKe_ThongKeLuotBanDocPhongDocMo" MasterPageFile="~/MasterPage.master" %>


<asp:Content  ContentPlaceHolderID=ContentPlaceHolder1 runat=server>

       <script language="javascript" src="../../Resources/JS/Calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../Resources/Js/TVLib.js" type="text/javascript"></script>
    
<body>
	
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="970px" border="0" align=center>
				<TR class="TVLibPageTitle">
					<TD colSpan="6" class="style1">
						<asp:label id="lblTitleGroup" Runat="server" Width="100%">Điều kiện lọc dữ liệu</asp:label></TD>
				</TR>
				<tr>
				    <td align ="right" >
                        <asp:Label ID="Label21" runat="server" Text="Khóa:"></asp:Label>
                        	
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKhoas" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlKhoas_SelectedIndexChanged">
                        </asp:DropDownList>
                        </td>
                        <td align ="right" >
                        <asp:Label ID="Label22" runat="server" Text="Lớp:"></asp:Label>
                        	
                        </td>
                        <td>
                        <asp:DropDownList ID="ddlLop" runat="server" AutoPostBack="True" 
                            >
                        </asp:DropDownList>
                        </td>
                </tr>
				<TR>
					<TD align="right" width="10%"><asp:label id="lblPatronCode" Runat="server"><u>S</u>ố thẻ:&nbsp;</asp:label></TD>
					<TD><asp:textbox id="txtSoThe" Runat="server"></asp:textbox></TD>
					<TD align="right" width="10%"><asp:label id="lblCheckOutDateFrom" Runat="server">Tháng</asp:label></TD>
					<TD>&nbsp;<script language="JavaScript">
	                              var mThoiGian	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtFromDate']);
	                              mThoiGian.year_scroll 	=	true;
	                              mThoiGian.time_comp 	=	false;	
                                  </script><asp:DropDownList ID="_ddlThang" runat="server">
                        </asp:DropDownList>
&nbsp; <asp:label id="lblCheckOutDateFrom0" Runat="server">Năm</asp:label>&nbsp;<asp:DropDownList 
                            ID="_ddlNam" runat="server">
                        </asp:DropDownList>
                    </TD>
					<TD align="right" width="10%">&nbsp;</TD>
					<TD>&nbsp;
                                    <script language="JavaScript">
	                              var mThoiGian1	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtToDate']);
	                              mThoiGian1.year_scroll 	=	true;
	                              mThoiGian1.time_comp 	=	false;	
                                  </script>  
                     </TD>
				</TR>
				<TR>
					<TD align="right">&nbsp;</TD>
					<TD>&nbsp;</TD>
					<TD align="right">&nbsp;</TD>
					<TD><asp:button id="btnFind" Runat="server" Text="Lọc" onclick="btnFind_Click" 
                            ></asp:button>&nbsp;&nbsp; 
                        <asp:button id="btnXuatExcel" Runat="server" Text="Xuất Excel" 
                            onclick="btnXuatExcel_Click"></asp:button>&nbsp;&nbsp; <asp:button id="btnCancel" 
                            Runat="server" Text="Đặt lại(d)"></asp:button></TD>
					<TD></TD>
					<TD>&nbsp;</TD>
				</TR>
				<tr Class="TVLibFunctionTitle">
					<td colSpan="4">
						<asp:label id="lblTitleDataGrid" Runat="server" CssClass="lbSubFormTitle">Danh 
                        sách bạn đọc và số lượt</asp:label></td>
					<td align="left" colspan="2" >
						<asp:label id="lblTotallb" Runat="server" Font-Bold="True" ForeColor="#0066FF">|&nbsp;&nbsp;&nbsp;Tổng số:&nbsp;</asp:label>
						<asp:label id="lblTotal" Runat="server" Font-Bold="True" ForeColor="#990000"></asp:label></td>
				</tr>
				<TR>
					<TD colSpan="6" align="center"  >
						<asp:Label ID="lblNothing" Runat="server" Visible="False" Font-Bold="True" ForeColor="#990000"> Không tồn tại dữ liệu thoả mãn điều kiện lọc</asp:Label>
						</TD>
				</TR>
				<tr>
				<td colspan="6">
				<asp:GridView ID="grvTaiLieu" runat="server" 
                        width="100%" AllowPaging="True" 
                        onpageindexchanging="grvTaiLieu_PageIndexChanging" PageSize="100" 
                        AutoGenerateColumns="False" >
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle Font-Bold="True" HorizontalAlign="Center" />
                </asp:GridView>
				</td>
				</tr>
			</TABLE>
		<script language = javascript>
			document.forms[0].ctl00$ContentPlaceHolder1$txtSoThe.focus();
		</script>
	        
		
		</body>
</asp:Content>
