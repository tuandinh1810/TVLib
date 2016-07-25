<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KiemKe.aspx.cs" Inherits="BoSungBienMuc_KiemKe_KiemKe" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body >
      
	<table align="center" width="970px" >
		<tr class="TVLibPageTitle">
					<td align="center" width="100%" colSpan="4"><asp:label id="lblTitle" Runat="server" > 
                        Kiểm kê tài liệu trong thư viện</asp:label></td>
				</tr>
				<tr class="TVLibFunctionTitle">
					<td colspan="4" class="style1" ><asp:label id="lblFilter" Runat="server" cssclass="lbGroupTitle">Điều kiện lọc</asp:label>
                    </td>
					
				</tr>
				<tr>
				<td align="right" width="12%"   >
				    <asp:label id="lblLibrary" Runat="server">Chọn thư <u>v</u>iện: </asp:label>
				</td>
				<td width="20%">
				    <asp:dropdownlist id="ddlLibrary" Runat="server"
                       ></asp:dropdownlist>
				</td>
				<td align="right" width="12%"   rowspan ="3" >
				    <asp:Label ID="Label3" runat="server" Text="Danh sách ĐKCB:"></asp:Label>
                    </td>
				<td rowspan ="3">
				    <asp:TextBox ID="txtDSMXG" runat="server" Rows="7" TextMode="MultiLine" 
                        Width="70%" ToolTip='Mã xếp giá cách nhau bằng dấu ","' ></asp:TextBox>
                    </td>
				</tr>
				<tr>
				<td  align="right"  >
                    <asp:label id="lblStore" Runat="server">Kh<u>o</u>:</asp:label>
				</td>
				<td>
                    <asp:dropdownlist id="ddlStore" Runat="server"  ></asp:dropdownlist>
				</td>
			
				</tr>
				<tr>
				<td align="right">
				    <asp:Label ID="Label2" runat="server" 
                        Text="&lt;u&gt;F&lt;/u&gt;ile ĐKCB:"></asp:Label>
				    </td>
				    <td>
				    <input id="fileUpload" runat="server"  type="file" /></td>
				
				</tr>
				<tr>
				<td align="right">
				</td>
				<td colspan="3">
&nbsp;<asp:Button ID="btnKiemKe" runat="server" Text="Kiểm kê (k)" onclick="btnKiemKe_Click" 
                       />
                    &nbsp;<asp:Button ID="btnReset" runat="server" Text="Làm lại(r)" />
				</td>
				</tr>
				<tr class="TVLibPageTitle">
							<td colspan="4"><asp:label id="lblDetailResult" runat="server" >Chi tiết kết quả 
                                kiểm kê</asp:label></td>
							</tr>
							<tr>
								<td colspan="4"><asp:label id="lblTotalInventory" Runat="server">Tổng số bản ghi kiểm kê: </asp:label>
                                    <asp:Label ID="lblTotalInventoryResult" runat="server"></asp:Label>
                                </td>
							</tr>
							<tr>
								<td colspan="4"><asp:label id="lblTotalNoLoop" Runat="server">Tổng số bản ghi thực kiểm kê(lọc bỏ các đăng ký cá biệt trùng): </asp:label>
                                    <asp:Label ID="lblTotalNoLoopResult" runat="server"></asp:Label>
                                </td>
							</tr>
							<tr>
								<td colspan="4"><asp:label id="lblTotalLost" Runat="server">Tổng số ĐKCB bị thiếu:</asp:label>
                                    <asp:Label ID="lblTotalLostResult" runat="server" Text=""></asp:Label>
                                </td>
							</tr>
							<tr>
								<td colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="lbDKCBThieu" Runat="server">Các ĐKCB bị thiếu:</asp:label>
                                    <asp:Label ID="lbDKCBThieuResult" runat="server" ForeColor="#CC0000"></asp:Label>
                                </td>
							</tr>
							<%--<tr>
								<td colspan="4"><asp:label id="lblTotalWrong" Runat="server">Tổng số bản ghi đặt nhầm chỗ: </asp:label>
                                    <asp:Label ID="lblTotalWrongResult" runat="server"></asp:Label>
                                </td>
							</tr>
							<tr>
								<td colspan="4"><asp:label id="lblWrongDetail" Runat="server">&nbsp;&nbsp;&nbsp;&nbsp;Các đăng ký cá biệt đặt nhầm chỗ là: </asp:label>
                                    <asp:Label ID="lblWrongDetailResult" runat="server" Text=""></asp:Label>
                                </td>
							</tr>--%>
							<tr>
								<td colspan="4"><asp:label id="lblTotalNo" Runat="server">Tổng số bản ghi không có trong dữ liệu là: </asp:label>
                                    <asp:Label ID="lblTotalNoResult" runat="server" Text=""></asp:Label>
                                </td>
							</tr>
							<tr>
								<td colspan="4"><asp:label id="lblNoDetail" Runat="server">&nbsp;&nbsp;&nbsp;&nbsp;Các đăng ký cá biệt không có trong dữ liệu là: </asp:label>
                                    <asp:Label ID="lblNoDetailResult" runat="server" Text=""></asp:Label>
                                </td>
							</tr>
				<tr>
				<td>
				<input type="hidden" runat="server" id="hidCount" />
				</td>
				</tr>
	</table>
    
    </div>
    
</body>
</asp:Content>
