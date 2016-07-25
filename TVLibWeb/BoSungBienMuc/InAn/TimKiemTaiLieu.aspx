<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimKiemTaiLieu.aspx.cs" Inherits="BoSungBienMuc_TimKiemTaiLieu" %>


    
    <script language="javascript" type="text/javascript" src="../../Resources/Js/TVLib.js"></script>

<body>
  <form id="form1" runat="server">
    <div>
   <table align="center" width="100%" >
    <tr>
    <td>
       <table width="100%" cellpadding="0" cellspacing="0">
                <tr class="TVLibPageTitle">
					<td class="lbPageTitle" align="left" colSpan="4"><asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Tìm kiếm tài liệu</asp:label></td>
				</tr>
				<tr height="10">
					<td colSpan="4"></td>
				</tr>
				<TR align="center">
					<TD align="right" width="10%">
                        <asp:Label ID="lblNhanDe" runat="server" Text="Nhan Đề:"></asp:Label>
                    </TD>
					<TD align="left" width="30%">
                        <asp:TextBox ID="TxtNhanDe" runat="server" Width="100%" 
                            style="margin-left: 0px"></asp:TextBox>
                    </TD>
					<TD align="right" width="10%">
                        <asp:Label ID="lblTacGia" runat="server" Text="Tác Giả:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="TxtTacGia" runat="server" Width="60%"></asp:TextBox>
                    </TD>
				</TR>
				<TR align="center">
					<TD align="right">
                        <asp:Label ID="lblMoTa" runat="server" Text="Tóm tắt:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="TxtMoTa" runat="server" Width="100%"></asp:TextBox>
                    </TD>
					<TD align="right">
                        <asp:Label ID="lblTuKhoa" runat="server" Text="Từ Khóa:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="TxtTuKhoa" runat="server" Width="60%"></asp:TextBox>
                    </TD>
                   
				</TR>
				<TR align="center">
					<TD align="right">
                        <asp:Label ID="Label1" runat="server" Text="Mã xếp giá:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtMaXepGia" runat="server" Width="100%"></asp:TextBox>
                    </TD>
					<TD align="right">
                        <asp:Label ID="Label2" runat="server" Text="ISBN:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtChiSoISBN" runat="server" Width="60%"></asp:TextBox>
                    </TD>
                 
				</TR>
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
				<tr class="TVLibPageTitle" id="trlblDanhSachTaiLieu" runat=server >
				<td colSpan="4" align="left" >
				
				    <asp:Label ID="Label4" runat="server" Text="Danh sách tài liệu"></asp:Label>
                    <br />
                    </td>
				</tr>
				<tr>
				<td colSpan="4" align="left" >
				
				    &nbsp;</td>
				</tr>
				<tr >
				<td colSpan="4" align="center">
				
				    <asp:GridView ID="grvResult" runat="server" AutoGenerateColumns="False" 
                        Width="100%" DataKeyNames="TaiLieuID,MaTaiLieu" 
                        onselectedindexchanged="grvResult_SelectedIndexChanged" AllowPaging="True" 
                        onpageindexchanging="grvResult_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="MaTaiLieu" HeaderText="Mã tài liệu" />
                            <asp:BoundField DataField="NhanDe" HeaderText="Nhan đề" />
                           
                            <asp:CommandField ButtonType="Image" 
                                SelectImageUrl="~/Resources/Images/apply.gif" ShowSelectButton="True" 
                                HeaderText="Chọn">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                    </td>
				</tr>
				<tr>
					<td colSpan="4" align="center">
				
				        &nbsp;</td>
				</tr>
				<tr >
				<td colSpan="4" >
                    &nbsp;</td>
				</tr>
				<tr>
				<td colSpan="4" align="center">
				
				    &nbsp;</td>
				</tr>
				<tr>
					<td colSpan="4" align="center">
				
				        &nbsp;</td>
				</tr>
				
				</table>
				<input type="hidden" value="" id="hdTaiLieuID" runat="server" />
				</td>
				</tr>
				</table>
        
    </div>
 </form>   


