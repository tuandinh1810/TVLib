<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangNhap.aspx.cs" Inherits="TVLibTraCuuWeb.DangNhap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="margin-top:0" >
    <form id="form1" runat="server">
    <div>
    
    </div>       
        <table width="60%" align="center"  >
            <tr>
                <td colspan="2" align="center" background-position:center; style="height: 39px">
                  <img src ="Resources/Images/Login.gif" style="width: 319px; height: 91px" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
        
        <table align=center  background="Resources/Images/DangNhap.png" style=" background-position:center; width: 600px; height: 300px;" >
            <tr>
                <td align="right" style="height: 29px; width: 500px;">
                </td>
                <td style="width: 174px;" height="10">
                </td>
            </tr>
            <tr>
                <td >
                    </td>
                <td>
                  
                    </td>
            </tr>
            <tr>
                <td >
                <table width="100%" >
                <tr>
                <td align="right"  >
                    <asp:Label ID="Label3" runat="server" Text="Tên đăng nhập:"></asp:Label>
                </td>
                 <td align="left"  >
                  
                             <asp:TextBox ID="txtTenDangNhap" runat="server" Font-Names="Times New Roman" Font-Size="12pt" Width="176px" ></asp:TextBox>
                                         </td>
                </tr>
                <tr>
                <td  align="right">
                    <asp:Label ID="Label2" runat="server" Text="Mật khẩu:"></asp:Label></td>
                 <td align="left" >
                  
                            <asp:TextBox ID="txtMatKhau" runat="server" Font-Names="Times New Roman" Font-Size="12pt" Width="176px" TextMode="Password">
                            </asp:TextBox>
                       
                    </td>
                </tr>               
                <tr>
                <td ></td>
                 <td align="left"  >
                     <asp:Button ID="btnLogin" runat="server" Font-Names="Times New Roman" Font-Size="12pt"
                        Text="Đăng  nhập" OnClick="btnLogin_Click1" /></td>
                </tr>
                 <tr>
                <td ></td>
                 <td >
                     &nbsp;</td>
                </tr>
                <tr>
                <td ></td>
                 <td></td>
                </tr>
                </table>
                     </td>
                <td >
                   </td>
            </tr>
            <tr>
                <td >
                    </td>
                <td >
                 </td>
            </tr>
            <tr>
                <td >
                    </td>
                <td >
                     </td>
            </tr>
        </table>
                </td>
            </tr>
            <tr>
                <td >
               </td>
                <td >
                </td>
            </tr>
        </table>
    </form>
    <script language ="javascript" >
        document.forms[0].txtTenDangNhap.focus();
    </script>
  
</body>
</html>
