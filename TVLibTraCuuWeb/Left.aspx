<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="TVLibTraCuuWeb.WLeft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="Resources/CSS/white_grey.css" rel="Stylesheet" type ="text/css" />  
</head>
<body style ="margin-left:0;margin-top:0;margin-right:0; background-color: White  ">
<form id="form1" runat="server">
    <table width="210px"  align="left"  > 
    <tr align="center"  >
        <td align="center" valign="Middle"  style="height:30px; background-image:url(Resources/Images/bg.gif)"> 
            <Font Color="Blue" > 10 DOWNLOAD NHIỀU NHẤT</Font>
        </td> 
    </tr> 
    <tr style="margin-left:0">
        <td style="margin-left:0" align=left >
            <marquee behavior=scroll direction=up width=200px height=410px scrollamount=2 scrolldelay=1 onmouseover='this.stop()' onmouseout='this.start()'>
                <asp:Table ID="tblResult" runat="server" ></asp:Table>
            </marquee>
        </td>
    </tr>
    </table>               
    </form>
</body>
</html>
