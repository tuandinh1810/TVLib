<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MoKyKiemKe.aspx.cs" Inherits="BoSungBienMuc_KiemKe_MoKyKiemKe" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body  topmargin="0" leftmargin="0" onload="document.forms[0].ctl00$ContentPlaceHolder1$txtTenKyKiemKe.focus()">

		<table align="center" width="970px" >
		<tr>
		<td >
		   <table align="center" width="970px" >
		   <TR class="TVLibPageTitle">
					<td width="100%" colspan ="2">
						<asp:label id="lblTitle" runat="server">Đóng kỳ kiểm kê và mở kho</asp:label></td>
				</TR>
				
				<TR>
					<td align="right" width="30%">
						<asp:Label ID="Label3" runat="server" Text="Tên kỳ kiểm kê:"></asp:Label>
						</td>
						<td>
						    <asp:TextBox ID="txtTenKyKiemKe" runat="server" Width="30%" ReadOnly="True"></asp:TextBox>
						&nbsp;
                            <asp:Button ID="btnOpen" runat="server" onclick="btnOpen_Click" 
                                Text="Đóng kỳ kiểm kê" />
&nbsp;
                            <asp:Button ID="btnAll" runat="server" Text="Đóng kỳ kiểm kê &amp; mở kho" 
                                Width="193px" onclick="btnAll_Click" />
						</td>
				</TR>
				
					
				<TR>
					<TD colspan ="2">
						<asp:GridView ID="grvKho" runat="server" AutoGenerateColumns="False" 
                            Width="100%" DataKeyNames="KhoID" 
                            AllowPaging="True" onpageindexchanging="grvKho_PageIndexChanging" 
                            onrowcreated="grvKho_RowCreated">
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                               <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Thư viện">
                                  
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvMaKho" runat="server" Text='<%# Bind("TenThuVien") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
    
                                <asp:TemplateField HeaderText="Mã kho">
                                
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvTenKho" runat="server" Text='<%# Bind("MaKho") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                <asp:BoundField DataField="TenKho" HeaderText="Tên kho" />
                                     <asp:TemplateField HeaderText="Trạng thái">
                                         <ItemTemplate>
                                             <asp:Label ID="lbTrangThai" runat="server" ></asp:Label>
                                         </ItemTemplate>
                                        
                                         <ItemStyle HorizontalAlign="Center" />
                                        
                                </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Chọn">                               
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>                               
                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="false"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </TD>
				</TR>
				<TR  style ="background-color :Silver ">
					<td align="right" width="30%">
						</td>
						<td align="right" >
						    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" 
                                Text="Mở kho" />
                                <input type="hidden" id="hidKyKiemKeID" runat="server" />
						</td>
				</TR>
				
		    </table>
		</td>
		</tr>
		</table>
			
		
	</body>

</asp:Content>
