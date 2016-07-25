<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KyKiemKe.aspx.cs" Inherits="BoSungBienMuc_KiemKe_KyKiemKe" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body  topmargin="0" leftmargin="0" onload="document.forms[0].ctl00$ContentPlaceHolder1$txtTenKyKiemKe.focus()">
		
		<table align="center" width="970px" >
		<tr>
		<td >
		   <table align="center" width="970px" >
		   <TR class="TVLibPageTitle">
					<td width="100%" colspan ="2">
						<asp:label id="lblTitle" runat="server">Tạo kỳ kiểm kê</asp:label></td>
				</TR>
				<TR>
					<td align="right" width="30%">
						<asp:Label ID="Label2" runat="server" Text="Chọn kỳ kiểm kê:" Visible="False"></asp:Label>
						</td>
						<td>
						    <asp:DropDownList ID="ddlKyKiemKe" runat="server" Visible="False">
                            </asp:DropDownList>
						</td>
				</TR>
				<TR>
					<td align="right" width="30%">
						<asp:Label ID="Label3" runat="server" Text="Tên kỳ kiểm kê:"></asp:Label>
						</td>
						<td>
						    <asp:TextBox ID="txtTenKyKiemKe" runat="server" Width="30%"></asp:TextBox>
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
                                Text="Mở kỳ kiểm kê (a)" Width="121px" />
                                <input type="hidden" runat="server" id="hidKyKiemKeID" />
						</td>
				</TR>
				
		    </table>
		</td>
		</tr>
		</table>
			
		
	</body>
</asp:Content>
