<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuanLyLog.aspx.cs" Inherits="QuanTriHeThong_QuanLyLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="Table1" width="970px" border="0" cellpadding="4" cellspacing="1" >
     <tr class ="TVLibPageTitle">
            <td colspan ="4">
            <asp:Label ID="Label2" CssClass ="TVLibPageTitle"  Text="Thống kê các hoạt động sử dụng hệ thống" Width="100%" runat="server" >
            </asp:Label>
            </td>
            </tr>
    
    <tr>
    <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton1" ImageUrl="~/Resources/Images/dat_che_do_ghi_log.gif" runat="server" />
    </td>
    <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/QuanTriHeThong/DatCheDoGhiLog.aspx">Đặt chế độ ghi Log</asp:HyperLink>
    </td>
      <td width ="10%" align="right" >
          <asp:ImageButton ID="ImageButton3" ImageUrl="~/Resources/Images/tra_cuu_log.gif" runat="server" />
    </td>
    <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/QuanTriHeThong/TraCuuLog.aspx">Tra cứu log</asp:HyperLink>
    </td>    
    </tr>
     <tr>
    <td width ="10%" align="right" >
        <asp:ImageButton ID="ImageButton2" ImageUrl="~/Resources/Images/xoa_log.gif" runat="server" />
    </td>
    <td width="30%">
        &nbsp;
        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="~/QuanTriHeThong/XoaLog.aspx">Xóa log</asp:HyperLink>
    </td>   
      <td width ="10%" align="right"  >
          <asp:ImageButton ID="ImageButton4" ImageUrl="~/Resources/Images/ReportRequests.gif" runat="server" />
    </td>
    <td>
        &nbsp;
        <asp:HyperLink ID="HyperLink4" runat="server" 
            NavigateUrl="~/QuanTriHeThong/ThongKeLog.aspx">Thống kê Log</asp:HyperLink>
    </td>     
    </tr>
   
    </table>
    </div>
    </form>
</body>
</html>
