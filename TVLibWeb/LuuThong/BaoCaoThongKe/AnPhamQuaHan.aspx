﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnPhamQuaHan.aspx.cs" Inherits="LuuThong_BaoCao_ThongKe_AnPhamQuaHan" MasterPageFile="~/MasterPage.master" %>


<asp:Content  ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
       <script language="javascript" src="../../Resources/JS/Calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../Resources/Js/TVLib.js" type="text/javascript"></script>
    
<body>
	
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="970px" border="0" align=center>
				<TR class="TVLibPageTitle">
					<TD colSpan="7" class="style1">
						<asp:label id="lblTitleGroup" Runat="server" Width="100%">Điều kiện tìm kiếm ấn 
                        phẩm</asp:label></TD>
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
					<TD align="right" width="10%"><asp:label id="lblCheckOutDateFrom" Runat="server"><u>M</u>ượn từ ngày:&nbsp;</asp:label></TD>
					<TD><asp:TextBox ID="txtFromDate" runat="server" Width="128px"></asp:TextBox> &nbsp;<a onclick="javascript:mThoiGian.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtFromDate']);
	                              mThoiGian.year_scroll 	=	true;
	                              mThoiGian.time_comp 	=	false;	
                                  </script>
                    </TD>
					<TD align="right" width="10%"><asp:label id="lblCheckOutDateTo" Runat="server">&nbsp;tớ<u>i</u>:&nbsp;</asp:label></TD>
					<TD><asp:TextBox ID="txtToDate" runat="server"></asp:TextBox> &nbsp;<a onclick="javascript:mThoiGian1.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian1	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtToDate']);
	                              mThoiGian1.year_scroll 	=	true;
	                              mThoiGian1.time_comp 	=	false;	
                                  </script>  
                     </TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblItemCode" Runat="server"><u>N</u>han đề:</asp:label>&nbsp;&nbsp; </TD>
					<TD><asp:textbox id="txtMaTaiLieu" Runat="server"></asp:textbox></TD>
					<TD align="right"><asp:label id="lblCopyNumber" Runat="server">Mã <u>x</u>ếp giá:&nbsp;</asp:label></TD>
					<TD><asp:textbox id="txtMaXepGia" Runat="server"></asp:textbox></TD>
					<TD align="right"><asp:label id="lblLocationID" Runat="server">Tìm t<u>r</u>ong kho:&nbsp;</asp:label></TD>
					<TD><asp:dropdownlist id="ddlKho" Runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right">&nbsp;</TD>
					<TD>&nbsp;</TD>
					<TD align="right">&nbsp;</TD>
					<TD>&nbsp;</TD>
					<TD></TD>
					<TD><asp:button id="btnFind" Runat="server" Text="Tìm(t)" 
                            onclick="btnFind_Click"></asp:button>&nbsp;<asp:button id="btnCancel" 
                            Runat="server" Text="Đặt lại(d)"></asp:button>&nbsp;<asp:button 
                            id="btnXuatExcel" Runat="server" Text="Xuất excel" 
                            onclick="btnXuatExcel_Click"></asp:button>&nbsp;<asp:button id="btnSendEmail" Runat="server" Text="Gửi email" 
                            ></asp:button></TD>
				</TR>
				<tr Class="TVLibFunctionTitle">
					<td colSpan="4">
						<asp:label id="lblTitleDataGrid" Runat="server" CssClass="lbSubFormTitle">Danh 
                        sách ấn phẩm quá hạn</asp:label></td>
					<td align="left" colspan="3" >
						<asp:label id="lblTotallb" Runat="server" Font-Bold="True" ForeColor="#0066FF">|&nbsp;&nbsp;&nbsp;Tổng số:&nbsp;</asp:label>
						<asp:label id="lblTotal" Runat="server" Font-Bold="True" ForeColor="#990000"></asp:label></td>
				</tr>
				<TR>
					<TD colSpan="7" align="center"  >
						<asp:Label ID="lblNothing" Runat="server" Visible="False" Font-Bold="True" ForeColor="#990000"> Không tồn tại dữ liệu thoả mãn điều kiện tìm kiếm</asp:Label>
						</TD>
				</TR>
				<tr>
				<td colspan="7">
				<asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False" 
                        width="100%" AllowPaging="True" 
                        onpageindexchanging="grvTaiLieu_PageIndexChanging" PageSize="100" 
                        onselectedindexchanged="grvTaiLieu_SelectedIndexChanged" >
                    <PagerSettings Position="TopAndBottom" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# i++ %>'></asp:Label>
                            </ItemTemplate>                            
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Khoa" HeaderText="Khóa" />
                        <asp:BoundField DataField="Lop" HeaderText="Lớp" />
                        <asp:BoundField DataField="TenDayDu" HeaderText="Họ Tên" >
                        <HeaderStyle Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SoThe" HeaderText="Số thẻ bạn đọc" />  
                                              
                        <asp:BoundField DataField="NhanDe" HeaderText="Nhan đề">
                            <HeaderStyle Width="40%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MaXepGia" HeaderText="Mã xếp giá">
                            <HeaderStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NgayMuon" HeaderText="Ngày mượn">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NgayPhaiTra" HeaderText="Ngày phải trả">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SoNgayQuaHan" HeaderText="Số ngày quá hạn">
                            <ItemStyle Font-Bold="True" ForeColor="#FF6600" HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
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
