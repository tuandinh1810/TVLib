<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InNhanGay.aspx.cs" Inherits="BoSungBienMuc_InNhanGay" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
    <script language="javascript" type="text/javascript" src="../../Resources/Js/TVLib.js"></script>

<body>

    <div>
   <table align="center" width="970px" >
    <tr>
    <td>
       <table width="100%" cellpadding="2" border="0" align="center">
                <tr class="TVLibPageTitle">
					<td class="lbPageTitle" align="left" colSpan="4"><asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Tìm kiếm tài liệu</asp:label></td>
				</tr>
				<tr height="10">
					<td colSpan="4"></td>
				</tr>
				 <tr align="center">
                <td align="right" width="10%">
                    <asp:Label ID="lblNhanDe" runat="server" Text="Nhan Đề:"></asp:Label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="TxtNhanDe" runat="server" Width="100%"
                        Style="margin-left: 0px"></asp:TextBox>
                </td>
                <td align="right" width="10%">
                    <asp:Label ID="lblTacGia" runat="server" Text="Tác Giả:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TxtTacGia" runat="server" Width="60%"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td align="right">
                    <asp:Label ID="lblMoTa" runat="server" Text="Tóm tắt:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TxtMoTa" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="lblTuKhoa" runat="server" Text="Đồng tác giả"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtDongTacGia" runat="server" Width="60%"></asp:TextBox>
                </td>
            </tr>
            <tr align="center">
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Nhà xuất bản"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNhaXuatBan" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Từ khóa"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTuKhoa" runat="server" Width="60%"></asp:TextBox>
                </td>
            </tr>
			<tr>
			<td colspan="4">
			&nbsp;
			</td>
			</tr>
				<tr style="background-color:Silver ">
				<td colSpan="4" align="center" class="style1">
				
				    <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" 
                        onclick="btnTimKiem_Click" />&nbsp;
                    <asp:Button ID="btnLamLai" runat="server" Text="Làm lại" 
                        onclick="btnLamLai_Click" />
				
				</td>
				</tr>
				<tr>
					<td colSpan="4" align="center">
				
				    &nbsp;</td>
				</tr>				
				<tr class="TVLibPageTitle" runat=server id="trlblDanhSachTaiLieu">
				<td colSpan="4" align="left" >
				
				    <asp:Label ID="Label4" runat="server" Text="Danh sách tài liệu"></asp:Label>
                    <br />
                    </td>
				</tr>
				<tr>
				<td colSpan="4" align="left" >
				
				    &nbsp;</td>
				</tr>
				<tr>
				<td colSpan="4" align="left" >
				
				    
				    <asp:label id="lblTotallb0" Runat="server" Font-Bold="True" 
                    ForeColor="#0066FF">&nbsp;&nbsp;&nbsp;Số bản ghi trên trang:</asp:label>
						&nbsp;<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlPageSize_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="10">10 kết quả</asp:ListItem>
                    <asp:ListItem Value="20">20 kết quả</asp:ListItem>
                    <asp:ListItem Value="50">50 kết quả</asp:ListItem>
                    <asp:ListItem Value="100">100 kết quả</asp:ListItem>
                    <asp:ListItem Value="200">200 kết quả</asp:ListItem>
                    <asp:ListItem Value="500">500 kết quả</asp:ListItem>
                </asp:DropDownList>&nbsp;</td>
				</tr>
				<tr >
				<td colSpan="4" align="center">
				
				    <asp:GridView ID="grvResult" runat="server" AutoGenerateColumns="False" 
                        Width="100%" DataKeyNames="TaiLieuID" 
                       AllowPaging="True" 
                        onpageindexchanging="grvResult_PageIndexChanging" OnRowDataBound="grvResult_RowDataBound">
                        <PagerSettings Position="TopAndBottom" />
                        <Columns>
                             <asp:BoundField DataField="STT" HeaderText="STT">
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NhanDe" HeaderText="Nhan đề" />
                          <%--  <asp:CommandField ButtonType="Image" 
                                SelectImageUrl="~/Resources/Images/apply.gif" ShowSelectButton="True" 
                                HeaderText="Chọn">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>--%>
                             <asp:TemplateField HeaderText="CheckAll">
                              <HeaderTemplate>
                                <asp:CheckBox ID="cbxCheckAll" runat="server" />
                            </HeaderTemplate>                             
                            <ItemTemplate>
                                <asp:CheckBox ID="cbxDKCB" runat="server" />
                            </ItemTemplate>
                              
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                              
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                    </td>
				</tr>
				<tr>
					<td colSpan="4" align="right">
				
				<asp:Button ID="btnChon" runat="server" Text="Chọn" 
                         style="height: 26px" OnClick="btnChon_Click" />
				    </td>
				</tr>
				<tr class="TVLibPageTitle" runat=server id="trlblDanhSachXepGia">
				<td colSpan="4" >
                    <asp:Label ID="Label3" runat="server" Text="Danh sách mã xếp giá"></asp:Label>
                    </td>
				</tr>
				<tr>
				<td colSpan="4" style="height: 25px" >
                    </td>
				</tr>
				<tr>
				<td colSpan="4" >
                    <asp:label id="lblTotal" Runat="server" Font-Bold="True" 
                    ForeColor="#0066FF">&nbsp;&nbsp;&nbsp;Số bản ghi trên trang:</asp:label>
						&nbsp;<asp:DropDownList ID="ddlPageSizeMXG" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlPageSizeMXG_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="10">10 kết quả</asp:ListItem>
                    <asp:ListItem Value="20">20 kết quả</asp:ListItem>
                    <asp:ListItem Value="50">50 kết quả</asp:ListItem>
                    <asp:ListItem Value="100">100 kết quả</asp:ListItem>
                    <asp:ListItem Value="200">200 kết quả</asp:ListItem>
                    <asp:ListItem Value="500">500 kết quả</asp:ListItem>
                </asp:DropDownList>&nbsp;</td>
				</tr>
				<tr>
				<td colSpan="4" align="center">
				
				    <asp:GridView ID="grvMaXepGia" runat="server" AutoGenerateColumns="False" 
                        Width="100%" AllowPaging="True" 
                        onpageindexchanging="grvMaXepGia_PageIndexChanging" 
                        onrowdatabound="grvMaXepGia_RowDataBound" DataKeyNames="MaXepGia" 
                        onselectedindexchanged="grvMaXepGia_SelectedIndexChanged">
                        <PagerSettings Position="TopAndBottom" />
                        <Columns>
                        <asp:TemplateField HeaderText="CheckAll">
                              <HeaderTemplate>
                                <asp:CheckBox ID="cbxCheckAll" runat="server" />
                            </HeaderTemplate>                             
                            <ItemTemplate>
                                <asp:CheckBox ID="cbxDKCB" runat="server" />
                            </ItemTemplate>
                              
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                              
                            </asp:TemplateField>
                            <asp:BoundField DataField="MaXepGia" HeaderText="Mã xếp giá" />
                            <asp:BoundField DataField="TenThuVien" HeaderText="Thư viện" />
                            <asp:BoundField DataField="MaKho" HeaderText="Kho" />
                            <asp:BoundField DataField="Shelf" HeaderText="Giá" />
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
				
				</td>
				</tr>
				<tr>
					<td colSpan="4" align="center">
				
				    &nbsp;</td>
				</tr>
				<tr style="background-color:Silver " id="trChucNang" runat=server>
				<td colspan="4" align="left" width="10%">
				    
				    <asp:Label ID="Label5" runat="server" Text="Mẫu nhãn gáy" ForeColor="Black"></asp:Label>
				    
				&nbsp;<asp:DropDownList ID="drdlMauNhanGay" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="drdlMauNhanGay_SelectedIndexChanged">
                    </asp:DropDownList> &nbsp;
				    
				<asp:Button ID="btnInNhan" runat="server" Text="In chọn" 
                        onclick="btnInNhan_Click" style="height: 26px" />
				&nbsp;
                    <asp:Button ID="btnInAll" runat="server" Text="In tất cả" 
                        onclick="btnInAll_Click" />
				</td>
				
				</tr>
				</table>
				<input type="hidden" value="" id="hdTaiLieuID" runat="server" />
				</td>
				</tr>
				</table>
        
    </div>
    
</body>
</asp:Content>
