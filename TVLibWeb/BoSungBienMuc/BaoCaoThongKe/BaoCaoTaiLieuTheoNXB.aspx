<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaoCaoTaiLieuTheoNXB.aspx.cs" Inherits="BoSungBienMuc_BaoCaoThongKe_BaoCaoTaiLieuTheoNXB" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body>
    
      <div>
     <table id="Table1" width="970px" align="center"  >
        <tr class ="TVLibPageTitle" >
            <td colspan ="4" class="style1">
            <asp:Label ID="Label2" Text="Báo cáo hoạt động bổ sung" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
				<TR align="center">
					<TD align="right">
                        <asp:Label ID="Label3" runat="server" Text="Năm xuất bản"></asp:Label>
                    </TD>
					<TD align="left" width="20%">
                        &nbsp;
                                    <script language="JavaScript">
	                              var mThoiGian	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtFromDate']);
	                              mThoiGian.year_scroll 	=	true;
	                              mThoiGian.time_comp 	=	false;	
                                  </script>
                        <asp:TextBox ID="txtNamXuatBan" runat="server"></asp:TextBox>
                    </TD>
					<TD align="right">
                        <asp:Label ID="Label4" runat="server" Text="Năm bổ sung"></asp:Label>
                    </TD>
					<TD align="left">
                        &nbsp;
                                    <script language="JavaScript">
	                              var mThoiGian1	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtToDate']);
	                              mThoiGian1.year_scroll 	=	true;
	                              mThoiGian1.time_comp 	=	false;	
                                  </script>
                        <asp:TextBox ID="txtNamBoSung" runat="server"></asp:TextBox>
                        <asp:Button ID="btnThongKe" runat="server" onclick="btnIn_Click" 
                            Text="Thống kê" />
                    </TD>
                   
				</TR>
				<TR align="center" style="background-color:Silver " >
					<TD align="right">
                        &nbsp;</TD>
					<TD align="left">
                        &nbsp;</TD>
					<TD align="right">
                        &nbsp;</TD>
					<TD align="left" >
                    &nbsp;
                        </TD>
                 
				</TR>
				 <tr>
         <td colspan=4>
             <asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False" 
                 Width="100%" AllowPaging="True" 
                 onpageindexchanging="grvTaiLieu_PageIndexChanging" PageSize="50">
                 <Columns>
                     <asp:BoundField DataField="NhanDe" HeaderText="Tên tài liệu" />
                     <asp:BoundField DataField="NamXuatBan" HeaderText="Năm xuất bản" />
                     <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" />
                 </Columns>
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