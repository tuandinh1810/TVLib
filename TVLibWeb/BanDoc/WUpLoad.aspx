<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WUpLoad.aspx.cs" Inherits="BanDoc_WUpLoad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
  <form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="5" width="100%" border="0">
				<TR Class="TVLibPageTitle">
					<TD align="center">
						<asp:label id="lblFile" runat="server">Tải ảnh độc giả</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:FileUpload ID="FileUpload1" runat="server" /></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center">
						<asp:button id="btnUpload" runat="server" Width="82px" Text="Tải lên(a)" 
                            onclick="btnUpload_Click"></asp:button>&nbsp;
						<asp:button id="btnClose" runat="server" Width="82px" Text="Đóng(o)" 
                            onclick="btnClose_Click"></asp:button></TD>
				</TR>
			</TABLE>
			<input id="hidAllowedFiles" type="hidden" runat="server" NAME="hidAllowedFiles" value="jpg;gif;bmp;JPG">
			<input id="hidValue" type="hidden" runat="server"  >
		
		</form>
</body>
</html>
