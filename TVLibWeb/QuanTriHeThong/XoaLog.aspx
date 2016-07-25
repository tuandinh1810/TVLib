<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XoaLog.aspx.cs" Inherits="QuanTriHeThong_XoaLog" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
       <script language="javascript" src="../Resources/JS/Calendar.js" type="text/javascript"></script>
</head>
<body>
    <div>
    <table align="center" width="970px" >    
    <tr class ="TVLibPageTitle">
    <td colspan ="2" >
        <asp:Label ID="Label1" runat="server" Text="Xóa nhật ký hệ thống"></asp:Label>
    </td>
    </tr>
    <tr>
        <td width="35%" align ="right" >
            <asp:Label ID="Label2" runat="server" Text="<u>T</u>ừ ngày:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtFromTime" runat="server"></asp:TextBox>
                                <a onclick="javascript:mFromTime.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mFromTime	=	new calendar1(document.forms['form1'].elements['txtFromTime']);
	                  mFromTime.year_scroll 	=	true;
	                  mFromTime.time_comp 	=	false;	
                      </script>    
        </td>
    </tr>
     <tr>
        <td align ="right" > 
            <asp:Label  ID="Label3" runat="server" Text="<u>Đ</u>ến ngày:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtToTime" runat="server"></asp:TextBox>
                                <a onclick="javascript:mToTime.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mToTime	=	new calendar1(document.forms['form1'].elements['txtToTime']);
	                  mToTime.year_scroll 	=	true;
	                  mToTime.time_comp 	=	false;	
                      </script>    
        </td>
    </tr>
     <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="btnXoa" runat="server" Text="Xóa" onclick="btnXoa_Click" />
        </td>
    </tr>
     <tr>
        <td>
        </td>
        <td>
        </td>
    </tr>
    </table>
    </div>
    
</body>
</asp:Content>
