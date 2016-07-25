<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YeuCauMuon.aspx.cs" Inherits="TVLibTraCuuWeb.YeuCauMuon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Danh sách tài liệu yêu cầu mượn</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table width="100%" align="center">
            <tr class="TVLibPageTitle">
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" Text="DANH SÁCH TÀI LIỆU YÊU CẦU MƯỢN"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="STT" HeaderText="STT" >
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NhanDe" HeaderText="Nhan đề" />
                            <asp:BoundField DataField="TacGia" HeaderText="Tác giả" >
                                <ItemStyle Width="30%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
            <td align="right" width="40%">
           
            </td>
            <td align="left" colspan="2">
            
            &nbsp;<asp:Button ID="btnYeuCau" runat="server" Text="Gửi yêu cầu" 
                    onclick="btnYeuCau_Click" />
                 &nbsp;<asp:Button ID="Button1" runat="server" Text="Hủy yêu cầu" OnClick="Button1_Click" 
                   />
            </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
