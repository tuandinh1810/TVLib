<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BanDocDaMuon.aspx.cs" Inherits="LuuThong_BanDocDaMuon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="margin-left:0;" >
    <form id="form1" runat="server">
    <div>
    <table id="TableFull" width="100%">
		<TR class="TVLibPageTitle">
					<TD >
						<asp:label Runat="server" Width="100%">Thông tin ấn phẩm bạn đọc đã mượn</asp:label></TD>
				</TR>
				<tr>
				<td>
				    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="NhanDe" HeaderText="Nhan đề">
                                <ItemStyle Width="35%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MaXepGia" HeaderText="Mã xếp giá" />
                            <asp:BoundField DataField="NgayMuon" HeaderText="Ngày mượn">
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NgayTra" HeaderText="Ngày trả">
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NgayQuaHan" HeaderText="Số ngày quá hạn">
                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PhiPhat" HeaderText="Tiền phạt">
                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
				</td>
				</tr>
				<tr>
				<td align ="center" >
				    <asp:Button ID="btnClose" runat="server" Text="Đóng" />
				</td>
				</tr>
	</TABLE>
	
    </div>
    </form>
</body>
</html>
