<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaoCaoBoSung.aspx.cs" Inherits="BoSungBienMuc_BaoCao_ThongKe_BaoCaoBoSung" MasterPageFile="~/MasterPage.master" %>


<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.6.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
    <script language="javascript" src="../../Resources/JS/Calendar.js" type="text/javascript"></script>

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
					<TD align="right" width="15%">
                        <asp:Label ID="Label3" runat="server" Text="Thư viện:"></asp:Label>
                    </TD>
					<TD align="left" width="30%">
                        <asp:DropDownList ID="ddlLibrary" runat="server" 
                           >
                        </asp:DropDownList>
                    </TD>
					<TD align="right" width="15%">
                        <asp:Label ID="Label4" runat="server" Text="Kho:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:DropDownList ID="ddlStore" runat="server">
                        </asp:DropDownList>
                    </TD>
				</TR>
				<TR align="center">
					<TD align="right">
                        <asp:Label ID="Label5" runat="server" Text="Bổ sung từ ngày:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>&nbsp;<a onclick="javascript:mThoiGian.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtFromDate']);
	                              mThoiGian.year_scroll 	=	true;
	                              mThoiGian.time_comp 	=	false;	
                                  </script>
                    </TD>
					<TD align="right">
                        <asp:Label ID="Label6" runat="server" Text="Đến ngày:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>&nbsp;<a onclick="javascript:mThoiGian1.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian1	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtToDate']);
	                              mThoiGian1.year_scroll 	=	true;
	                              mThoiGian1.time_comp 	=	false;	
                                  </script>
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
                        <asp:Button ID="btnSearch" runat="server" Text="Xem" 
                            onclick="btnSearch_Click" Width="56px" />
                    &nbsp;
                        <asp:Button ID="btnIn" runat="server" onclick="btnIn_Click" 
                            Text="Xuất ra word" />
                    </TD>
                 
				</TR>
				 <tr>
         <td colspan=4>
             <asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False" 
                 Width="100%">
                 <Columns>
                     <asp:BoundField DataField="TenThuVien" HeaderText="Tên thư viện">
                         <ItemStyle Width="25%" />
                     </asp:BoundField>
                     <asp:BoundField DataField="TenKho" HeaderText="Tên kho">
                         <ItemStyle Width="15%" />
                     </asp:BoundField>
                     <asp:BoundField DataField="NhanDe" HeaderText="Nhan đề tài liệu" />
                     <asp:BoundField DataField="MaXepGia" HeaderText="Mã xếp giá">
                         <ItemStyle HorizontalAlign="Center" />
                     </asp:BoundField>
                     <asp:BoundField DataField="NgayXepGia" HeaderText="Ngày bổ sung">
                         <ItemStyle HorizontalAlign="Center" />
                     </asp:BoundField>
                 </Columns>
             </asp:GridView>
         </td>
         </tr>
         <tr>
         <td colspan=4>
             &nbsp;</td>
         </tr>
   </table> 
    </div>
    
</body>
</asp:Content>
