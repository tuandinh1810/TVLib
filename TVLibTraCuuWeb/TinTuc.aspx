<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/MasterPage.master"   CodeFile="TinTuc.aspx.cs" Inherits="TVLibTraCuuWeb.TinTuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
   
     <script  language="javascript" type ="text/javascript">
    function ChangePage(intPg,intMaxPg){
    var strJs;
	strJs='';
	/*
	for(i=1;i<=intMaxPg;i++){		
		if(i==intPg) strJs=strJs + '<B>' + i + '</B>';
		else strJs=strJs + '<a class="lbLinkFunction" href="#" OnClick="javascript:ChangePage(' + i + ',' + intMaxPg +');">' + i +'</a> ';			
	}
	document.forms[0].hidViewPage.value=strJs;	
	*/
	document.forms[0].action='TinTuc.aspx?CurrentPage=' + intPg;
	document.forms[0].submit();
}
    </script>
    <div>
     <table style="margin-left:5px;margin-right:5px"  width ="850px" >
        <tr >
      <td   
             align="left"  > 
           <font color='blue'> <B>
           <asp:Label ID="lbThongTin" runat="server" Width="100%">TIN TỨC - SỰ KIỆN</asp:Label>
           </B> </font>                                                      
       </td>
      </tr>
      </table>
      <asp:Label ID="lblTinTuc" runat="server"></asp:Label>
      <br>
       <asp:Label ID="lblTrang" runat="server" ></asp:Label>
      <%--  <table width ="100%" style="margin-left:5px;margin-right:5px">
        <tr >
      <td   style ="background-image:url('Resources/Images/k1.jpg');height:36px"  
             align="left"  > 
           <font color='white'> <B>
           <asp:Label ID="lbThongTin" runat="server"></asp:Label>
           </B> </font>                                                      
       </td>
      </tr>
        <tr>
        <td  style="margin-left:5px;margin-right:10px">
            <asp:Label ID="lblTinTuc" runat="server" Text="Label" Font-Size="14pt"></asp:Label>
        </td>
        </tr>
        <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lblTrang" runat="server" ></asp:Label>
            </td>
            </tr>
          </table>
            --%>
       
    </div>
   </asp:Content>
