<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TK_AnPhamTrongNgay.aspx.vb" Inherits="BoSungBienMuc_ThongKe_AnPhamTrongNgay" MasterPageFile="~/MasterPage.master" %>

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
                            Text="Thống kê những tài liệu được mượn nhiều nhất trong ngày"></asp:Label>
                    
                    </td>
                    
                </tr>
               <tr >
                <td colspan ="4" align ="center"  >
            &nbsp;
                                <asp:Label ID="Label5" runat="server" Text="Thời gian:"></asp:Label>
                                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox> &nbsp;<a onclick="javascript:mThoiGian.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a> 
                        &nbsp;&nbsp;
                        
                                &nbsp;&nbsp;<asp:Button ID="btnThongKe" runat="server" 
                        Text="Thống kê" />
                   </td>
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