<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TVLib</title>
     <style type="text/css">
        .SubMenu
        {
            font-family: "Times New Roman", Times, serif;
            font-size: 11pt;
            font-weight: normal;
            Color: Blue;
        }
        .ActiveSubMenu
        {
            font-family: "Times New Roman", Times, serif;
            font-size: 11pt;
            font-weight: Bold;
            color: Green;
        }
        .ActiveMenu
        {
            font-family: "Times New Roman", Times, serif;
            font-size: 11pt;
            font-weight: Bold;
            color: Green;
        }
        .Menu
        {
            font-family: "Times New Roman", Times, serif;
            font-size: 11pt;
            font-weight:Normal;
            color: Blue; 
        }
        </style>
    
</head>
<body leftMargin="0" topMargin="1" rightMargin="0" MS_POSITIONING="GridLayout" background="Resources/images/bg_NenChinh.gif" >
    <form id="form1" runat="server">
    <table width ="100%" >
        
        <tr>
            <td class="style39">
                </td>
            <td class="style40">
                </td>
            <td class="style5" colspan="2">
              <a href ="QuanTriHeThong/Default.aspx" > <asp:Image ID="Image7" runat="server" 
                    ImageUrl="~/Resources/Images/HocVien.jpg" /> </a> 
            </td>
            <td class="style41">
                </td>
            <td class="style5" colspan="4">
               <a href="QuanLyPhi/QuanLyPhiIndex.aspx"> <asp:Image ID="Image3" runat="server" 
                    ImageUrl="~/Resources/Images/NganHangCauHoi.jpg" 
                    style="text-align: center" /></a>
            </td>
            <td class="style42">
                </td>
            <td class="style5" colspan="2">
               <a href="SuuTapSo/SuuTapSoIndex.aspx"><asp:Image ID="Image8" runat="server" 
                    ImageUrl="~/Resources/Images/HoTroNguoiDung.jpg" /> </a> 
            </td>
            <td class="style5">
                </td>
        </tr>
        <tr>
            <td class="style14">
                </td>
            <td class="style20">
                </td>
            <td class="style33">
                </td>
            <td class="style15" colspan="2">
                <asp:Image ID="Image5" runat="server" 
                    ImageUrl="~/Resources/Images/ThiTracNghiem.jpg" />
            </td>
            <td class="style15">
                &nbsp;</td>
            <td class="style34" colspan="2">
                &nbsp;</td>
            <td class="style15" colspan="3">
                <asp:Image ID="Image6" runat="server" 
                    ImageUrl="~/Resources/Images/ThiTracNghiem.jpg" />
            </td>
            <td class="style15" colspan="2">
                &nbsp;</td>
        </tr>
    </table>
    </form>
</body>
</html>
