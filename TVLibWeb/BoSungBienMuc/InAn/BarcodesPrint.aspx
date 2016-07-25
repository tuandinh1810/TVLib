<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BarcodesPrint.aspx.cs" Inherits="BoSungBienMuc_InAn_BarcodesPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MA VACH CHO TAI LIEU</title>
</head>
<body>
   <form id="Form1" method="post" runat="server">
			<table width="100%" bgcolor=#ffffff>
				<tr>
					<td><asp:Label ID="lblDisplay" Runat="server" Visible="true"></asp:Label></td>
				</tr>
				<tr>
					<td><asp:HyperLink ID="hrf" Runat="server" Visible="False" NavigateUrl="#"></asp:HyperLink></td>
					
				</tr>
			</table>
		</form>
</body>
</html>
