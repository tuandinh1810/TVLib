<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popupBarcodes.aspx.cs" Inherits="BoSungBienMuc_InAn_Barcodes"  %>

<head>
<title>IN MA VACH</title>
</head>

<form id="form1" runat="server">
<script language="javascript" src="../../Resources/JS/Calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../Resources/Js/TVLib.js" type="text/javascript"></script>
   

<body>

 
			<input id="hdStore" type="hidden" value="0" name="hdStore" runat="server">
			<table id="AcqBarCode" cellSpacing="1" cellPadding="2" width="970px" align="center"  >
				<tr class="TVLibPageTitle">
					<td align="left" width="100%" colSpan="2"><asp:label id="lblTitle" Runat="server" > In mã vạch cho tài liệu</asp:label></td>
				</tr>
				<tr class="TVLibFunctionTitle">
					<td colspan="2" class="style1" ><asp:label id="lblFilter" Runat="server" cssclass="lbGroupTitle">Điều kiện lọc</asp:label></td>
					
				</tr>
				<tr>
				<td align="right" width="12%"   >
				    <asp:label id="lblLibrary" Runat="server">Chọn thư <u>v</u>iện: </asp:label>
				</td>
				<td>
				    <asp:dropdownlist id="ddlLibrary" Runat="server" 
                        onselectedindexchanged="ddlLibrary_SelectedIndexChanged" 
                        AutoPostBack="True"></asp:dropdownlist>
				</td>
				
				</tr>
				<tr>
				<td  align="right"  >
                    <asp:label id="lblStore" Runat="server">Kh<u>o</u>:</asp:label>
				</td>
				<td>
                    <asp:dropdownlist id="ddlStore" Runat="server"  ></asp:dropdownlist>
				</td>
				
				</tr>
				<tr  style="background-color: #ddeeff">
				<td  align="left"  colspan="2" > &nbsp;&nbsp;&nbsp;<asp:radiobutton id="rdbThoiGian" tabIndex="3" Runat="server" Text="<u>T</u>hời gian xếp giá" GroupName="FilterChoice"
										></asp:radiobutton>
				</td>
				</tr>
					<tr>
				<td  align="right"  >
				    <asp:label id="lblFromDate" Runat="server">T<u>h</u>ời 
                                    gian từ: </asp:label>
				</td>
				<td>
				    <asp:textbox id="txtFromDate" Runat="server"></asp:textbox>&nbsp;<a onclick="javascript:mThoiGian.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian	=	new calendar1(document.forms[0].elements['txtFromDate']);
	                              mThoiGian.year_scroll 	=	true;
	                              mThoiGian.time_comp 	=	false;	
                                  </script>
				</td>
				
				</tr>
					<tr>
				<td  align="right"  >
				    <asp:label id="lblToDate" Runat="server">Tớ<u>i</u>: </asp:label>
				</td>
				<td>
				    <asp:textbox id="txtToDate" Runat="server" style="margin-bottom: 0px"></asp:textbox>&nbsp;<a onclick="javascript:mThoiGian1.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian1	=	new calendar1(document.forms[0].elements['txtToDate']);
	                              mThoiGian1.year_scroll 	=	true;
	                              mThoiGian1.time_comp 	=	false;	
                                  </script>
				</td>
				
				</tr>
					<tr style="background-color: #ddeeff">
				<td class="style1" colspan="2"  >
				    &nbsp;&nbsp;
				    <asp:radiobutton id="rdbMaTaiLieu" tabIndex="3" Runat="server" 
                        Text="<u>M</u>ã tài  liệu" GroupName="FilterChoice"  ></asp:radiobutton>
				</td>
				
				</tr>
				<tr>
				<td align="right"  >
				    <asp:label id="lblFromCodeItem" Runat="server">Mã <u>t</u>ài liệu: </asp:label>
				</td>
				<td>
				    <asp:textbox id="txtMaTaiLieu" Runat="server"  ></asp:textbox>&nbsp;
				     </td>
				</tr>
			
				<tr style="background-color: #ddeeff">
				<td colspan="2"  >
				    &nbsp;&nbsp;
				    <asp:radiobutton id="rdbMaXepGia" Runat="server" Text="Mã <u>x</u>ếp giá"  Checked="True"
                        GroupName="FilterChoice"></asp:radiobutton>
				</td>
				
				</tr>
				<tr>
				<td align="right"  >
				    <asp:label id="lblFromCopyNumber" Runat="server">Từ ĐK<U>C</U>B: </asp:label>
				</td>
				<td>
				    <asp:textbox id="txtFromDKCB" Runat="server"></asp:textbox>
				</td>
				</tr>
				<tr>
				<td align="right"  >
				    <asp:label id="lblToCopyNumber" Runat="server">Tới Đ<u>K</u>CB: </asp:label>
				</td>
				<td>
				    <asp:textbox id="txtToDKCB" Runat="server"></asp:textbox>
				</td>
				</tr>
				<tr>
				<td align="right"  >
				    <asp:label id="lblType" Runat="server">Kiểu <u>B</u>arcode: </asp:label>
				</td>
				<td>
				  <asp:dropdownlist id="ddlType" Runat="server">
										<asp:ListItem Value="1">EAN-13</asp:ListItem>
										<asp:ListItem Value="2">EAN-8</asp:ListItem>
										<asp:ListItem Value="3">UPC-A</asp:ListItem>
										<asp:ListItem Value="4">Code 39 Check</asp:ListItem>
										<asp:ListItem Value="5">Codabar</asp:ListItem>
										<asp:ListItem Value="6" Selected="True">Code 39</asp:ListItem>
										<asp:ListItem Value="7">2 of 5</asp:ListItem>
										<asp:ListItem Value="8">Interleaved 2 of 5 (ITF)</asp:ListItem>
										<asp:ListItem Value="9">UPC-E</asp:ListItem>
										<asp:ListItem Value="10">EAN-13 + 2</asp:ListItem>
										<asp:ListItem Value="11">EAN-13 + 5</asp:ListItem>
										<asp:ListItem Value="12">EAN-8 + 2</asp:ListItem>
										<asp:ListItem Value="13">EAN-8 + 5</asp:ListItem>
										<asp:ListItem Value="14">UPC-A + 2</asp:ListItem>
										<asp:ListItem Value="15">UPC-A + 5</asp:ListItem>
										<asp:ListItem Value="16">UPC-E + 2</asp:ListItem>
										<asp:ListItem Value="17">UPC-E + 5</asp:ListItem>
										<asp:ListItem Value="18">EAN-128 A</asp:ListItem>
										<asp:ListItem Value="19">EAN-128 B</asp:ListItem>
										<asp:ListItem Value="20">EAN-128 C</asp:ListItem>
										<asp:ListItem Value="21">Code 93</asp:ListItem>
										<asp:ListItem Value="22">POSTNET</asp:ListItem>
										<asp:ListItem Value="23">Code-128 A</asp:ListItem>
										<asp:ListItem Value="24">Code-128 B</asp:ListItem>
										<asp:ListItem Value="25">Code-128 C</asp:ListItem>
									</asp:dropdownlist>
				</td>
				</tr>
				<tr style="background-color:#ddeeff">
				<td align="right"  >
				    &nbsp;</td>
				<td>
                        <asp:button id="btnBarCode" Runat="server" Text="In mã vạch" 
                            Width="160px" onclick="btnBarCode_Click"></asp:button>
				</td>
				</tr>
				<tr vAlign="top">
					<td class="style1"  >
						</td>
					
					<td width="35%" class="style1" >
						</td>
				</tr>
				<tr class="lbControlBar">
					<td class="style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</td>
					
					<td align="right" class="style2">
                        </td>
				</tr>
			</table>
			<input id="hdChoice" type="hidden" value="1" name="hdChoice" runat="server">

		<script language="javascript">
			document.forms[0].ctl00$ContentPlaceHolder1$txtFromDKCB.focus();
		</script>
	</body>

</form>