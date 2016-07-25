<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TK_BanDoc_MuonNhieuNhat.aspx.vb" Inherits="BoSungBienMuc_ThongKe_NgayBienMuc" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
   <script language="javascript" src="../../Resources/JS/Calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../Resources/Js/TVLib.js" type="text/javascript"></script>
    <script>
        function GenRanNum(intNumber) {
            var str = '';
            var intCount;
            for(intCount = 1; intCount<=intNumber;intCount++){ 
	            str=str + (String)(parseInt(9 * Math.random()+48));
            } 
            return(str);
        }
        
        function GenURLImg1(intNumber){
	        document.images["Image1"].src='Chart.aspx?i=1&x='+GenRanNum(intNumber);
	        //document.images["Image2"].src='WChartDir.aspx?i=2&x='+GenRanNum(intNumber);	
        }
    </script>

<body>
    
    <div>
   <table align="center" width="970px" >
      <tr>
    <td >
     <table ID ="TableCenter" Align="center">
                      
                 <tr class ="TVLibPageTitle">
                    <td  colspan ="4">
                        <asp:Label ID="Label1" runat="server"  Width ="100%" 
                            Text="Thống kê top 20 bạn đọc có số lần giao dịch mượn nhiều nhất"></asp:Label>
                    
                    </td>
                    
                </tr>
               <tr >
                <td colspan ="4" align ="center"  >
            &nbsp;
                                <asp:Label ID="Label5" runat="server" Text="Thời gian từ:"></asp:Label>
                                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox> &nbsp;<a onclick="javascript:mThoiGian.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtFromDate']);
	                              mThoiGian.year_scroll 	=	true;
	                              mThoiGian.time_comp 	=	false;	
                                  </script>    
            &nbsp;&nbsp; 
                        &nbsp; 
                        &nbsp;&nbsp;
                         &nbsp;
                                <asp:Label ID="Label2" runat="server" Text="Tới:"></asp:Label>
                                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox> &nbsp;<a onclick="javascript:mThoiGian1.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian1	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtToDate']);
	                              mThoiGian1.year_scroll 	=	true;
	                              mThoiGian1.time_comp 	=	false;	
                                  </script>    
            &nbsp;&nbsp; 
                        &nbsp; 
                        <asp:Button ID="btnThongKe" runat="server" Text="Thống kê" />
                    &nbsp;&nbsp;
                                &nbsp;&nbsp;</td>
                </tr>
                  <tr   class ="TVLibPageTitle" >
                <td colspan ="3" class="style2"  width="60%"  >
                    &nbsp;<asp:Label ID="Label6" runat="server" Text="Chi tiết"></asp:Label>
                                </td>
                                <td>
                                </td>
                               
                </tr>
                
                
                <tr >
                <td colspan ="4" align="center">
                  <IMG src="" useMap="#map1" border="0" name="Image1"> 
                </td>
                </tr>
                 <tr >
                <td colspan ="4">
                </td>
                </tr>
                </table>
         </td>
         </tr>
        </table>
    </div>
    
    <script language="javascript"  >
        document.forms[0].ctl00$ContentPlaceHolder1$txtFromDate.focus();
    </script>
</body>
</asp:Content>