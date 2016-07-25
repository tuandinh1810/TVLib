<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhMucSachMoi.aspx.cs" Inherits="LuuThong_BaoCaoThongKe_DanhMucSachMoi" MasterPageFile="~/MasterPage.master" %>


<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
    <script language="javascript" src="../../Resources/JS/Calendar.js" type="text/javascript"></script>

<body>

    <div>
     <table id="Table1" width="970px" align="center"  >
        <tr class ="TVLibPageTitle" >
            <td colspan ="4" class="style1">
            <asp:Label ID="Label2" Text="Danh mục sách mới" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
         <TR align="center">
					<TD align="right" width="15%">
                        &nbsp;</TD>
					<TD align="left" width="30%">
                        &nbsp;</TD>
					<TD align="right" width="15%">
                        &nbsp;</TD>
					<TD align="left">
                        &nbsp;</TD>
				</TR>
				<TR align="center">
					<TD align="right">
                        <asp:Label ID="Label5" runat="server" Text="Bổ sung từ ngày:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>&nbsp;<a onclick="javascript:mThoiGian.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
                                        var mThoiGian = new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtFromDate']);
                                        mThoiGian.year_scroll = true;
                                        mThoiGian.time_comp = false;
                                  </script>
                    </TD>
					<TD align="right">
                        <asp:Label ID="Label6" runat="server" Text="Đến ngày:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>&nbsp;<a onclick="javascript:mThoiGian1.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
                                        var mThoiGian1 = new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtToDate']);
                                        mThoiGian1.year_scroll = true;
                                        mThoiGian1.time_comp = false;
                                  </script>
                    </TD>
                   
				</TR>
				<TR align="center" style="background-color:Silver " >
					<TD align="right">
                        <asp:Label runat="server" ID="lblTotal" Visible="false"></asp:Label></TD>
					<TD align="left">
                        &nbsp;</TD>
					<TD align="right">
                        &nbsp;</TD>
					<TD align="left" >
                        <asp:Button ID="btnSearch" runat="server" Text="Xem" 
                            onclick="btnSearch_Click" Width="56px" />
                    &nbsp;
                        <asp:Button ID="btnIn" runat="server" onclick="btnIn_Click" 
                            Text="Xuất excel" />
                    </TD>
                 
				</TR>
				 <tr>
         <td colspan=4>
             <asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False" 
                 Width="100%" PageSize="50" AllowPaging="true" OnPageIndexChanging="grvTaiLieu_PageIndexChanging">
                 <Columns>
                     <asp:BoundField DataField="NhanDe" HeaderText="Nhan đề">
                         <ItemStyle Width="30%" />
                     </asp:BoundField>
                 
                     <asp:TemplateField HeaderText="Tác giả" >
                         <ItemTemplate>
                             <asp:Label runat="server" ID="lblTacGia"><%#Eval("TacGia").ToString().Replace("'","") %></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                   <%--  <asp:BoundField DataField="NhaXuatBan" HeaderText="Nhà xuất bản" />--%>
                       <asp:TemplateField HeaderText="Nhà xuất bản" >
                         <ItemTemplate>
                             <asp:Label runat="server" ID="lblTacGia"><%#Eval("NhaXuatBan").ToString().Replace("'","") %></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                      <asp:BoundField DataField="ChiSoPL" HeaderText="Chỉ số phân loại" />
                     
                     <asp:TemplateField HeaderText="Năm xuất bản" >
                         <ItemTemplate>
                             <asp:Label runat="server" ID="lblNhanDe"><%#Eval("NamXuatBan").ToString().Replace("'","") %></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="DonGia" HeaderText="Giá" />
                      <asp:BoundField DataField="SL" HeaderText="Số lượng" />
                     <asp:BoundField DataField="TenKho" HeaderText="Kho" />
                     <%--<asp:BoundField DataField="NamXuatBan" HeaderText="Năm xuất bản">
                         <ItemStyle HorizontalAlign="Center" />
                     </asp:BoundField>
                     --%>
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
