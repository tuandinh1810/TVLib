<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThongKeTaiLieuPhucVuKK.aspx.cs" Inherits="BoSungBienMuc_BaoCao_ThongKe_ThongKeTaiLieuPhucVuKK" MasterPageFile="~/MasterPage.master"  %>



<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body>
    
      <div>
     <table id="Table1" width="970px" align="center"  >
        <tr class ="TVLibPageTitle" >
            <td colspan ="4" class="style1">
            <asp:Label ID="Label2" Text="Báo cáo số lượng tài liệu trong kho" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
				<TR align="center">
					<TD align="right">
                        &nbsp;</TD>
					<TD align="left">
                        &nbsp;
                                    <script language="JavaScript">
	                              var mThoiGian	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtFromDate']);
	                              mThoiGian.year_scroll 	=	true;
	                              mThoiGian.time_comp 	=	false;	
                                  </script>
                    </TD>
					<TD align="right">
                        &nbsp;</TD>
					<TD align="left">
                        &nbsp;
                                    <script language="JavaScript">
	                              var mThoiGian1	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtToDate']);
	                              mThoiGian1.year_scroll 	=	true;
	                              mThoiGian1.time_comp 	=	false;	
                                  </script>
                    </TD>
                   
				</TR>
				<TR align="center" >
					<TD align="right">
                        &nbsp;</TD>
					<TD align="left">
                        &nbsp;</TD>
					<TD align="right">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTongSo" runat="server" Font-Bold="True"></asp:Label>
                    </TD>
					<TD align="left" width="10%" >
                    &nbsp;
                        <asp:button id="btnXuatExcel" Runat="server" Text="Xuất Excel" 
                            onclick="btnXuatExcel_Click"></asp:button>
                        </TD>
                 
				</TR>
				 <tr>
         <td colspan=4>
             <asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False" 
                 Width="100%">
             </asp:GridView>
         </td>
         </tr>
         <tr>
         <td colspan=4 align=center>
                        &nbsp;</td>
         </tr>
         <tr>
         <td colspan=4>
             &nbsp;</td>
         </tr>
   </table> 
    </div>
    </form>
</body>
</asp:Content>
