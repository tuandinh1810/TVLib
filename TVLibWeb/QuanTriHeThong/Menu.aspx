<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="QuanTriHeThong_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản trị hệ thống</title>
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
            font-size: 13pt;
            font-weight: Bold;
            color: Pink;
        }
        .Menu
        {
            font-family: "Times New Roman", Times, serif;
            font-size: 12pt;
            font-weight:Normal;
            color: White; 
        }
        </style>
    <script>
        oldSubMenuCtl = "";
        function GotoSubMenu(id,url)
        {   
            SubMenuCtl = document.getElementById(id);
            if (oldSubMenuCtl=="")
            {
                document.getElementById("lnkQuanLyNguoiDung").className = "SubMenu";
            }
            if (oldSubMenuCtl!=SubMenuCtl)
            {
                oldSubMenuCtl.className = "SubMenu";
                oldSubMenuCtl = SubMenuCtl;
            }
            SubMenuCtl.className='ActiveSubMenu';
            top.main.document.location = url;
        }
        function GotoMenu(id,url)
        {            
            top.document.location = url;
        }
    </script>
</head>
<body style="margin-top:0px; margin-left:0px">    
 <form id="form1" runat="server">
  <table ID="TableFull" align="Center" width="970px" cellspacing="0" cellpadding="0" style="margin-left:0px" >
    <tr align="Center" style="width:100%">
        <td align="center" style="width:100%;margin-left:0px">
        <table style="background-image:url(../Resources/Images/DLib_Menu_Pen.gif);" cellspacing="0" cellpadding="0" border="0" style="height:86px">
         <tr align="left"  style="height:40px; margin-top:5px" >
            <td style="Width: 6%;margin-left: 0px" align=left rowspan=2>
                <a href="javascript:top.document.location.href='../Default.aspx'"><img height="86px" border=0 src="../Resources/Images/TVLib_LogoPen.gif" /></a>
            </td>            
            <td style="Width: 20%; Text-Align:Center">
                <a  id="lnkBoSungBienMuc" class="Menu" href="javascript:GotoMenu('lnkBoSungBienMuc','../BoSungBienMuc/Default.aspx');void(0);">Bổ sung Biên mục</a>
            </td>
            <td style="Width: 16%; Text-Align:Center">
                <a ID="lnkBanDoc" class="Menu" href="javascript:GotoMenu('lnkBanDoc','../BanDoc/Default.aspx');void(0);">Bạn đọc</a>
            </td>
            <td style="Width: 16%; Text-Align:Center" >
                <a ID="lnkLuuThong" class="Menu" href="javascript:GotoMenu('lnkLuuThong','../LuuThong/Default.aspx');void(0);">Lưu thông</a>
            </td>                        
            <td style="Width: 16%; Text-Align:Center">
                <a ID="lnkQuanTriHeThong" class="ActiveMenu" href="javascript:GotoMenu('lnkQuanTriHeThong','../QuanTriHeThong/Default.aspx');void(0);">Quản trị hệ thống</a>
            </td>
            <td style="Width: 16%; Text-Align:Center" >
                <a ID="lnkTraCuu" class="Menu" href="javascript:GotoMenu('lnkTraCuu','../TroGiup.aspx');void(0);">Tra cứu</a>
            </td>
            <td style="Width: 14%; Text-Align:Center" >
                <a ID="lnkThoat" class="Menu" href="javascript:GotoMenu('lnkThoat','../Logout.aspx');void(0);">Thoát</a>
            </td>
        </tr>
        <tr align=center style="height:40px; vertical-align:top; margin-top:0px" >
            <td colspan="8" style="width:100%">
                <table  style="width:100%">
                    <tr  style="width:100%">                                        
                        <td align="center" style="width:0%">&nbsp;</td>
                        <td align="center" style="width:20%" >
                            <a ID="lnkQuanLyNguoiDung"  class="ActiveSubMenu" href="javascript:GotoSubMenu('lnkQuanLyNguoiDung','NguoiDung.aspx');void(0);">Quản lý người dùng</a>
                        </td>
                        <td align="center" style="width:15%" >
                            <a ID="lnkTraCuuLog"  class="SubMenu" href="javascript:GotoSubMenu('lnkTraCuuLog','TraCuuLog.aspx');void(0);">Tra cứu log</a>
                        </td> 
                        <td align="center" style="width:20%" >
                            <a ID="lnkDatCheDoGhiLog"  class="SubMenu" href="javascript:GotoSubMenu('lnkDatCheDoGhiLog','DatCheDoGhiLog.aspx');void(0);">Đặt chế độ ghi log</a>
                        </td> 
                        <td align="center" style="width:15%" >
                            <a ID="lnkXoaLog"  class="SubMenu" href="javascript:GotoSubMenu('lnkXoaLog','XoaLog.aspx');void(0);">Xóa log</a>
                        </td> 
                        <td align="center" style="width:15%" >
                            <a ID="lnkThongKeLog"  class="SubMenu" href="javascript:GotoSubMenu('lnkThongKeLog','ThongKeLog.aspx');void(0);">Thống kê log</a>
                        </td>                        
                    </tr>
                </table>
            </td>
        </tr>
        </table>
        </td>
        </tr>    
    </table>
    </form>
      
</body>
</html>