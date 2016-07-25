<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimKiemToanVan.aspx.cs" Inherits="TVLibTraCuuWeb.TimKiemToanVan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Tìm kiếm toàn văn</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table title="Tìm Kiếm Thông Tin" width="100%">
            <tr>
                <td colspan="3" style="height: 3px; text-align: center">
                    <asp:Label ID="Label1" runat="server" Text="Tìm kiếm thông tin"></asp:Label>
                    <asp:TextBox ID="txtTimKiem" runat="server" Width="432px"></asp:TextBox>
                    <asp:Button ID="btnTimKiem" runat="server" Text="Tìm Kiếm" OnClick="btnTimKiem_Click" /></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 221px; text-align: left">
                    &nbsp;&nbsp;
                    <asp:GridView ID="grvResult" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="DocName" HeaderText="Tên file" />
                            <asp:HyperLinkField DataNavigateUrlFields="DocPath" DataTextField="DocPath" HeaderText="Duong dan vat ly"
                                Target="_blank" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
