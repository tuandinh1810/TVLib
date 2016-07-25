<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>TVLib - Login</title>   
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="Resources/Css/Admin.css" type="text/css" rel="stylesheet" />
<link rel="shortcut icon" href="Resources/Images/favicon.png" type="image/x-icon" />
<link rel="stylesheet" href="Resources/css/layout.css" type="text/css" media="all"/>
	<script type="text/javascript" src="Resources/Js/break.js"></script>	
	<script type="text/javascript" src="Resources/Js/break.js"></script>		
	<script type="text/javascript" src="Resources/Js/jquery-1.4.2.min.js"></script>	
	<style type="text/css">div.spotlight dd.date {color: #c60;margin:10px 0 0 0;font-size: 0.9em;border-top:2px dotted #cecece}</style>
	<!--[if IE 6]><link rel="stylesheet" href="global/style/ie6.css" type="text/css"media="screen" />
	<script type="text/javascript" src="global/js/minmax.js"></script><![endif]-->
	<!--[if IE 7]><link rel="stylesheet" href="global/style/ie7.css" type="text/css" media="screen" /><![endif]-->
	<!--[if IE]>
	<style type="text/css" media="screen">
	body {behavior: url(global/style/csshover.htc);font-size: 100%;}
	#menu span ul li {float: left; width: 100%;}
	#menu span ul li a {height: 1%;} 
	#menu span a, #menu span h2 {font:11px arial, helvetica, sans-serif;}
	</style>
	<![endif]-->
	<SCRIPT LANGUAGE="JavaScript">
<!--
	maxWindow();
//-->
</SCRIPT>
<script LANGUAGE="JavaScript">
<!--
function LoadPage (url, winname, h, w) {
  winname = window.open (url, winname, "resizable,menubar=yes,statusbar");
}
function LoadAdminPage (url, winname, h, w) {
  winname = window.open (url, winname, "scrollbars=yes,resizable,menubar=yes,scrollbars=yes,width=" + w + ",height=" + h);
}
//-->
</script>
<link rel="shortcut icon" href="Resources/images/favicon.png" type="image/x-icon">
<script type="text/javascript" src="Resources/Js/jquery-1.4.min.js"></script>
<script type="text/javascript" src="Resources/Js/dropshadow.js"></script>
<script src="Resources/Js/loopedslider.min.js" type="text/javascript"></script>
<script type="text/javascript">
$(document).ready(function(){

closetimer = 0;
	if($("#nav")) {
		
		$("#nav li b").mouseover(function() {
			if($(this).parent().parent().hasClass('sub'))
			{
				clearTimeout(closetimer);
				if(this.className.indexOf("hover") != -1) {			
					
					$("#nav em").removeClass("hover");
					$("#nav i").removeClass("hover");
					$(this).parent().next().fadeIn("slow");
					$('.shadow2').show();
					$(this).removeClass("hover");
				}
				else {
					
					$('.shadow2').show();
					$("#nav b").removeClass();
					$(this).addClass("hover");
					$("#nav em").removeClass("hover");
					$("#nav i").removeClass("hover");
					$("#nav ul:visible").fadeOut("slow");
					$(this).parent().next().fadeIn("slow");
				}
			}				
			else
			{
				if($("#nav li ul").is(':visible'))
				{
					$("#nav li ul").hide();
					$('.shadow2').hide();
				}
				
			}
			return false;
		});

		$("#nav i").mouseover(function() {
		clearTimeout(closetimer);
			if(this.className.indexOf("hover") != -1) {
				$("#nav em").removeClass("hover");
				$(this).parent().next().slideUp(500);
				$(this).removeClass("hover");
			}
			else {
				$("#nav i").removeClass();
				$(this).addClass("hover");
				$("#nav em").removeClass("hover");
				$(this).parent().next().slideDown(500);
			}
			return false;
		});

		$("#nav em").mouseover(function() {
		clearTimeout(closetimer);
			if(this.className.indexOf("hover") != -1) {
				$(this).parent().next().fadeOut("slow");
				$(this).removeClass("hover");
			}
			else {
				$("#nav em").removeClass();
				$(this).addClass("hover");
				$(this).parent().next().fadeIn("slow");
			}
			return false;
		});

		$("#nav").mouseover(function() {
			clearTimeout(closetimer);			
		});

		$("#nav").mouseout(function() {
			
			closetimer = window.setTimeout(function(){
			$("#nav em").removeClass("hover");
			$("#nav i").removeClass("hover");
			}, 2000);
			
		}); 
		
				
		$("#nav ul").bind("mouseenter",function(){
		  //alert('over');
		}).bind("mouseleave",function(){
		  $("#nav ul").hide();
		  $('.shadow2').hide();
		});

	}

});
</script>

<style type="text/css">
    @font-face {
      font-family: "Arial";
    }
    
    body { font-family: "Arial";}
   
    
  </style>
  <style>
  .headerSuuTapSo
{
	width:970px;
	background:url(Resources/Images/TVLIb_ThuVienDienTu.png) no-repeat; 	
	margin-top:3px;
	-webkit-border-top-left-radius: 10px;
	-webkit-border-top-right-radius: 10px;
	-moz-border-radius-topleft: 10px;
	-moz-border-radius-topright: 10px;
	border-top-left-radius: 10px;
	border-top-right-radius: 10px;
	height:50px;
}
  </style>    
</head>

<body bgcolor="#FFFFFF" text="#000000" link="#336699" vlink="#336699"
alink="#990000" style="font-family:Arial;font-size:12pt;" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <table width="970px" align="center" cellpadding="0" cellspacing="0" align="center">
    <tr>
    <td>
        <asp:Label runat=server ID="lblImage"></asp:Label>
       
    </td>
    </tr>
    </table>
        <%--<uc7:ucBanner ID="ucBanner1" runat="server" />--%>
        <%--<uc1:ucHeader ID="ucHeader1" runat="server" />--%>
        <div id="container">	
	    <div id="content" style="text-align:center">
            
            &nbsp;
   <%-- <div class="header">
	        <div id="logo"><a href="javascript:;"><img src="Resources/Images/admin_logo.png" class="AdminLogo" /></a></div>
       </div>--%>
       <div class="mainlogin">
	    <div class="bgform">
    	    <div class="bgform_in">
        	    <h1 class="AdminLogo">ĐĂNG NHẬP HỆ THỐNG</h1>
        	       <div class="bglogin">
            	    <ul>
                	    <li style="text-align:left">Tên đăng nhập:
                            <asp:TextBox ID="txtTenDangNhap" runat="server" Height="25px" Width="270px">
                            </asp:TextBox>
                        </li>
                        <li style="text-align:left">Mật khẩu:
                            <asp:TextBox ID="txtMatKhau" runat="server" Height="25px" Width="270px" TextMode="Password" 
                                ></asp:TextBox>
                        </li>
                        <li>
                    	    <span class="left" style="padding-top:5px;"><input type="checkbox" name="" value="" style="border:0; padding:0; margin:0;" />Lưu mật khẩu</span>
                            <span class="right">
                             <iframe name="LogonLibol" id="LogonLibol" width=0 height=0></iframe>                    
                             
                            <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" 
                                ToolTip="Đăng nhập" onclick="btnLogin_Click" />
                            </asp:Button>
                            </span>
                        </li>
                        <li class="end">
                    	    <span class="left"><a href="#">Trang chủ</a></span>
                            <span class="right"><a href="#">Quên mật khẩu ?</a></span>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
       </div>    
       </div>
       </div>      
    </form>
</body>
</html>
