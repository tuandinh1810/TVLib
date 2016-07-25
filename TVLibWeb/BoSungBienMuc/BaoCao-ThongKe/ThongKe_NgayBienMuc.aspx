<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ThongKe_NgayBienMuc.aspx.vb" Inherits="BoSungBienMuc_ThongKe_NgayBienMuc" MasterPageFile="~/MasterPage.master" %>

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

<body onload="//if (eval(document.images['Image1'])) {GenURLImg1(9);}">

    <div>
   <table align="center" width="970px" >
      <tr>
    <td >
     <table ID ="TableCenter" Align="center">
                      
                 <tr class ="TVLibPageTitle">
                    <td  colspan ="4">
                        <asp:Label ID="Label1" runat="server"  Width ="100%" 
                            Text="Thống kê theo ngày biên mục"></asp:Label>
                    
                    </td>
                    
                </tr>
               <tr >
                <td colspan ="4" align ="center"  >
            &nbsp;
                                <asp:Label ID="Label2" runat="server" Text="Tháng:"></asp:Label>
                                <asp:DropDownList ID="drdlThang" runat="server">
                                    <asp:ListItem Value="0">Tháng</asp:ListItem>
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="6">6</asp:ListItem>
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="8">8</asp:ListItem>
                                    <asp:ListItem Value="9">9</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                </asp:DropDownList>
                        &nbsp; <asp:Label ID="Label3" runat="server" Text="Năm:"></asp:Label>
                                <asp:DropDownList ID="drdlNam" runat="server">
                                    <asp:ListItem Value="0">Năm</asp:ListItem>
                                    <asp:ListItem>2010</asp:ListItem>
                                    <asp:ListItem>2011</asp:ListItem>
                                    <asp:ListItem>2012</asp:ListItem>
                                    <asp:ListItem>2013</asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                    <asp:ListItem>2015</asp:ListItem>
                                    <asp:ListItem>2016</asp:ListItem>
                    </asp:DropDownList>
                        &nbsp;&nbsp;
                        
                                <asp:Button ID="btnThongKe"  runat="server" Text="Thống Kê" 
                                    onclick="btnLoc_Click" />
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
    
</body>
</asp:Content>