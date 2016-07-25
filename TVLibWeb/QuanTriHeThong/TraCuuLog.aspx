<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TraCuuLog.aspx.cs" Inherits="QuanTriHeThong_TraCuuLog" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" src="../Resources/JS/Calendar.js" type="text/javascript"></script>
    </head>
    <body>
        <table id="Table1" cellspacing="0" cellpadding="3" width="970px" border="0" align="center">
            <tr class="TVLibPageTitle">
                <td colspan="2">
                    <asp:Label ID="lblPageTitle" runat="server" Width="100%">Tra cứu Log</asp:Label></td>
            </tr>
            <tr>
                <td align="right" width="30%">
                    Từ khóa</td>
                <td>
                    <asp:TextBox Width="316px" ID="txtWord" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="30%">
                    <asp:Label ID="lblFromDate" runat="server">Thời gian <U>t</U>ừ:</asp:Label></td>
                <td>
                    <asp:TextBox Width="80px" ID="txtFromDate" runat="server"></asp:TextBox>&nbsp;
						    <a onclick="javascript:mFromTime.popup();" href="javascript:;">
                                <img alt="Chọn ngày lập biểu" border="0" height="16" src="../Resources/Images/cal.gif"
                                    width="16" /></a>
                    <script language="JavaScript">
                        var mFromTime = new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtFromDate']);
                        mFromTime.year_scroll = true;
                        mFromTime.time_comp = false;
                    </script>
                    &nbsp;
						đến
                    <asp:TextBox Width="80px" ID="txtToDate" runat="server"></asp:TextBox>&nbsp;&nbsp;
						   <a onclick="javascript:mToTime.popup();" href="javascript:;">
                               <img alt="Chọn ngày lập biểu" border="0" height="16" src="../Resources/Images/cal.gif"
                                   width="16" /></a></td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;&nbsp;
                    <script language="JavaScript">
                        var mToTime = new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtToDate']);
                        mToTime.year_scroll = true;
                        mToTime.time_comp = false;
                    </script>
                    &nbsp;
						</td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    <asp:Label ID="lblGroup" runat="server">Nhóm <U>s</U>ự kiện:</asp:Label></td>
                <td>&nbsp;<select id="lsbPhanHe" size="10" width="50%" name="lsbGroup0" runat="server" multiple="true">
                </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<select id="lsbGroup" size="10" width="50%" name="lsbGroup" runat="server" multiple="true">
                        </select></td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    <asp:Label ID="lblUser" runat="server">Người <U>d</U>ùng:</asp:Label></td>
                <td>
                    <asp:ListBox ID="lsbUser" runat="server" Rows="5" SelectionMode="Multiple"></asp:ListBox></td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="lbControlBar">
                <td></td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Width="65px" Text="Tìm(s)" OnClick="btnSearch_Click"></asp:Button>&nbsp;
						<asp:Button ID="btnReset" runat="server" Width="92px" Text="Đặt lại(r)"></asp:Button>
                    <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
                        <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                        <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                        <asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
                        <asp:ListItem Value="3">Khuôn dạng giờ không hợp lệ</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>


    </body>
</asp:Content>
