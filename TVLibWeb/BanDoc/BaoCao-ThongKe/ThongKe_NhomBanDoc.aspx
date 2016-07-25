<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ThongKe_NhomBanDoc.aspx.vb" Inherits="ThongKe_NhomBanDoc" MasterPageFile="~/MasterPage.master" %>
<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>

    <script language="javascript" src="../Resources/JS/Calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../Resources/Js/TVLib.js" type="text/javascript"></script>
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

<body onload="//if (eval(document.images['Image1'])) {GenURLImg1(9);}">

    <div>
    <table width="970px"  cellspacing="0" cellpadding="0" align="center"  >
      <tr>
    <td >
     <table ID ="TableCenter" Align="center">
                      
                 <tr class ="TVLibPageTitle">
                    <td  colspan ="4">
                        <asp:Label ID="Label1" runat="server"  Width ="100%" 
                            Text="Thống kê bạn đọc theo nhóm bạn đọc"></asp:Label>
                    
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
    
</body>
</asp:Content>