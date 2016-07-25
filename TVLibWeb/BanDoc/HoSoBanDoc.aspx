<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HoSoBanDoc.aspx.cs" Inherits="BanDoc_HoSoBanDoc" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<BODY>
		<script language="javascript" src="../Resources/JS/Calendar.js" type="text/javascript"></script>
		<table align="center" width="970px" >
		<tr>
		<td>
			<table id="TableCenter" cellSpacing="0" cellPadding="2"  border="0" align="center"  >
				<TR  class="TVLibPageTitle">
					<TD align="left" colSpan="7"><asp:label id="lb1" runat="server" >Cập nhật thông tin bạn đọc</asp:label></TD>
				</TR>
				<tr>
					<td align="right"><asp:label id="lblFirstName" runat="server"><U>H</U>ọ và tên:</asp:label></td>
					<td colSpan="5"><nobr>
                        <asp:textbox id="txtHoVaTen" 
                            Width="150px" Runat="server" TabIndex="1"></asp:textbox>&nbsp;
							<asp:radiobutton id="optNam" runat="server" Text="<u>N</u>am" 
                            GroupName="Gender" Checked="True"></asp:radiobutton>
                        <asp:radiobutton id="optNu" runat="server" Text="<u>N</u>ữ" GroupName="Gender"></asp:radiobutton>&nbsp;<asp:Label 
                            ID="Label2" runat="server" ForeColor="Red" Text="(*)"></asp:Label>
                        </nobr></td>
					<TD align="center" rowSpan="5">&nbsp;<IMG id="imgPatron" alt="" 
                            src="~/Resources/Images/AnhThe/Empty.gif" runat="server" height="140" 
                            width="110">
					</TD>
				</tr>
				<TR>
					<td align="right" width="6%"><asp:label id="lblDOB" runat="server"><U>N</U>gày sinh:</asp:label></td>
					<td style="margin-left: 80px">
                        <asp:textbox id="txtNgaySinh"  runat="server" 
                            Width="85px" TabIndex="2"></asp:textbox>&nbsp;
                             <a onclick="javascript:mNgaySinh.popup();" href="javascript:;"><img alt="Chọn ngày" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mNgaySinh	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtNgaySinh']);
	                  mNgaySinh.year_scroll 	=	true;
	                  mNgaySinh.time_comp 	=	false;	
                      </script>    
                            </td>
					<td align="right"><asp:label id="lblEthnic" runat="server"><u>D</u>ân tộc:</asp:label></td>
					<td colSpan="3">
                        <asp:dropdownlist id="drdlDanToc"  
                            runat="server" TabIndex="7"></asp:dropdownlist>&nbsp;</td>
				</TR>
				<tr>
					<td align="right" width="4%"><asp:label id="lblCode" runat="server"><u>S</u>ố thẻ:</asp:label></td>
					<td><asp:textbox id="txtSoThe"  runat="server" Width="100px" TabIndex="3"></asp:textbox>
                        <nobr>
                        &nbsp;<asp:Label ID="Label4" runat="server" ForeColor="Red" Text="(*)"></asp:Label>
                        </nobr></td>
					<td align="right"><asp:label id="lblPatronGroup" runat="server"><u>N</u>hóm bạn đọc:</asp:label></td>
					<td colSpan="3">
                        <asp:dropdownlist id="drdlNhomBanDoc"  
                            runat="server" TabIndex="8"></asp:dropdownlist>&nbsp;<nobr><asp:Label 
                            ID="Label5" runat="server" ForeColor="Red" Text="(*)"></asp:Label>
                        </nobr></td>
				</tr>
				<TR>
					<TD align="right"><asp:label id="lblLastIssuedDate" runat="server"><U>N</U>gày cấp:</asp:label></TD>
					<TD><asp:textbox id="txtNgayCap"  runat="server" Width="85px" TabIndex="4"></asp:textbox>&nbsp;
						 <a onclick="javascript:mNgayCap.popup();" href="javascript:;"><img alt="Chọn ngày" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mNgayCap	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtNgayCap']);
	                  mNgayCap.year_scroll 	=	true;
	                  mNgayCap.time_comp 	=	false;	
                      </script>    
                        <nobr>
                        <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="(*)"></asp:Label>
&nbsp;&nbsp; </nobr>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblValidDate" runat="server" width="85px"><U>N</U>gày hiệu lực:</asp:label>
						<asp:textbox id="txtNgayHieuLuc"
						 runat="server" 
                            Width="85px" TabIndex="5"></asp:textbox>&nbsp; <a onclick="javascript:mNgayHieuLuc.popup();" href="javascript:;"><img alt="Chọn ngày" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mNgayHieuLuc	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtNgayHieuLuc']);
	                  mNgayHieuLuc.year_scroll 	=	true;
	                  mNgayHieuLuc.time_comp 	=	false;	
                      </script><nobr>
                        <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="(*)"></asp:Label>
                        </nobr></TD>
					<TD align="right">
						<asp:label id="lblExpiredDate" runat="server" width="85px"><U>N</U>gày hết hạn:</asp:label></TD>
					<TD colSpan="3">
						<asp:textbox id="txtNgayHetHan"  runat="server" 
                            Width="85px" TabIndex="6"></asp:textbox>&nbsp;
                             <a onclick="javascript:mNgayHetHan.popup();" href="javascript:;"><img alt="Chọn ngày" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mNgayHetHan	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtNgayHetHan']);
	                  mNgayHetHan.year_scroll 	=	true;
	                  mNgayHetHan.time_comp 	=	false;	
                      </script>
                            <nobr>
                        <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="(*)"></asp:Label>
                        </nobr>
                            </TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblEducationLevel" runat="server">Trình <u>đ</u>ộ:</asp:label></TD>
					<td><asp:dropdownlist id="drdlTrinhDo"  runat="server" 
                            Width="300px" TabIndex="9"></asp:dropdownlist>&nbsp;</td>
					<td align="right"><asp:label id="lblOccupation" runat="server">Nghề ngh<u>i</u>ệp:</asp:label></td>
					<TD colSpan="3">
						<asp:dropdownlist id="drdlNgheNghiep" runat="server" 
                            Width="70%" TabIndex="10"></asp:dropdownlist>&nbsp;</TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblWorkPlace" runat="server" Width="88px">Nơi làm <u>v</u>iệc:</asp:label></TD>
					<TD colSpan="5">
                        <asp:textbox id="txtNoiLamViec"
                            runat="server" Width="385px" TabIndex="11"></asp:textbox></TD>
					<TD align="center"><asp:hyperlink id="lnkPatronImage" runat="server">Ảnh</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblGrade" runat="server"><u>K</u>hóa:</asp:label></TD>
					<TD colSpan="6">
                        <asp:textbox id="txtKhoa"
                            runat="server" Width="75px" TabIndex="12"></asp:textbox>&nbsp;
						<asp:label id="lblClass" runat="server"><u>L</u>ớp:</asp:label>
                        <asp:textbox id="txtLop"  runat="server" Width="65px" TabIndex="13"></asp:textbox></TD>
				</TR>
				<TR class="TVLibPageTitle">
					<td align="left" colSpan="8"><asp:label id="lblCPOA" runat="server">Địa chỉ</asp:label></td>
					
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblAddress" runat="server"><u>Ð</u>ịa chỉ:</asp:label></TD>
					<TD colSpan="3">
                        <asp:textbox id="txtDiaChi"  runat="server" 
                            Width="385px" TabIndex="14"></asp:textbox></TD>
					<TD align="right"><asp:label id="lblCity" runat="server">Thành <u>p</u>hố:</asp:label></TD>
					<TD colSpan="2">
                        <asp:textbox id="txtThanhPho"  
                            runat="server" TabIndex="15"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblProvince" runat="server">T<u>ỉ</u>nh:</asp:label></TD>
					<TD colSpan="3">
                        <asp:dropdownlist id="drdlTinh" 
                            runat="server" TabIndex="16"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						&nbsp;
						</TD>
					<TD align="right"><asp:label id="lblZip" runat="server" Width="68px"><u>M</u>ã vùng:</asp:label></TD>
					<TD width="89" colSpan="2"><nobr>
                        <asp:textbox id="txtMaVung" 
                            runat="server" Width="44px" TabIndex="17"></asp:textbox>&nbsp;
							</nobr>
                    </TD>
				</TR>
				<TR class="TVLibPageTitle">
					<TD align="left" colSpan="7"><asp:label id="lblOtherInfor" runat="server" >Thông tin khác</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblTelephone" runat="server"><u>Đ</u>iện thoại:</asp:label></TD>
					<TD><asp:textbox id="txtDienThoai"  runat="server" 
                            Width="120px" TabIndex="18"></asp:textbox></TD>
					<TD align="right"><asp:label id="lblEmail" runat="server"><u>E</u>mail:</asp:label></TD>
					<TD width="143"><asp:textbox id="txtEmail"  runat="server" Width="120px" 
                            TabIndex="19"></asp:textbox></TD>
					<TD align="right"></TD>
					<TD colSpan="2"></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="Label1" runat="server"><u>S</u>ố chứng minh thư:</asp:label></TD>
					<TD><asp:textbox id="txtSCMT" runat="server" Width="120px" TabIndex="20"></asp:textbox></TD>
					<TD align="right">&nbsp;</TD>
					<TD width="143">&nbsp;</TD>
					<TD align="right"></TD>
					<TD colSpan="2"></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblNote" runat="server">G<u>h</u>i chú:</asp:label></TD>
					<TD colSpan="6">
                        <asp:textbox id="txtGhiChu"  runat="server" 
                            Width="648px" TextMode="MultiLine"
							Rows="3" TabIndex="21"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="515" colSpan="7"><asp:button id="btnUpdate" runat="server" Width="98px" 
                            Text="Cập nhật(u)" AccessKey="u" 
                            onclick="btnUpdate_Click" TabIndex="22"></asp:button>&nbsp;
						<asp:Button ID="btnReset" runat="server" Text="Đặt lại(i)" />
                        &nbsp;
						<asp:button id="btnSearch" runat="server" Width="102px" 
                            Text="Tìm kiếm(f)" AccessKey="f" TabIndex="24" onclick="btnSearch_Click"></asp:button>
                        &nbsp;&nbsp;<asp:Button ID="btnClose" runat="server" AccessKey="c" 
                            onclick="btnClose_Click" Text="Đóng(c)" Visible="False" />
						</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="515" colSpan="7">
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="515" colSpan="7">
						<P>
						</P>
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="515" colSpan="7"><INPUT id="hidCode" type="hidden" name="hidCode" runat="Server">
					<INPUT id="hidImage" type="hidden" name="hidImage" runat="Server">
                        <br />
                    </TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="515" colSpan="7"></TD>
				</TR>
			</table>
			</td>
		</tr>
	</table>
			
		
	</BODY>
</asp:Content>
