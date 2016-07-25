<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowDetail.aspx.cs" Inherits="TVLibTraCuuWeb.WShowDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
   

   
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>
   

   
</head>
<body style ="margin-left:0;margin-top :0; background-color:White">
    <form id="form1" runat="server">
    <div>
      <table class="TableContent"  width ="80%" align="left">
   <tr>
   <td class="LeftTopTableContent" ></td>
   <td class="TopCenterTableContent"></td>
  <td class="RightTopTableContent"></td></tr>
    <tr>
    <td class="LeftMidTableContent"></td>
  <td align="center">
    <table width ="100%"  align="left"   >
    <tr>
    <td >
        <asp:Table ID="tblResult" runat="server" Width="100%">
        </asp:Table>      
        <br />
       
    </td>
    </tr>
    <tr>
    <td style ="background-image:url(Resources/Images/bg.gif)" class="style1" >
        
        <asp:Label ID="Label1" runat="server"
            ForeColor="#666666" Text="DANH SÁCH FILE LIÊN KẾT" Font-Bold="True" 
            Font-Italic="True" ></asp:Label>
       
    </td>
    </tr>
     <tr>
     
    <td>
      
        <asp:Table ID="tblLienKet" runat="server" Width="100%">
        </asp:Table>      
        
    </td>
    </tr>
    </table>
       <td class="RightMidTableContent"></td></tr>
    <tr>
    <td class="LeftBottomTableContent" ></td>
    <td class="BottomCenterTableContent"></td>
    <td class="RightBottomTableContent"></td>
      </tr>
</table> 
    </div>
    </form>
</body>
</html>
