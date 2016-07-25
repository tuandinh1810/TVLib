<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="False" CodeFile="KetQuaTraCuuLog.aspx.cs" Inherits="QuanTriHeThong_KetQuaTraCuuLog" MasterPageFile="~/MasterPage.master" %>



<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <table id="Table1" cellspacing="0" cellpadding="5" width="970px" border="0">
            <tr class="TVLibPageTitle">
                <td width="50%">
                    <asp:Label ID="TVLibPageTitle" runat="server">Kết quả tra cứu log</asp:Label></td>
                <td align="right">
                    <a href="TraCuuLog.aspx" runat="server">
                        <asp:Label ID="lbSearch" runat="server" Text="Tìm mới"></asp:Label></a>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                        PageSize="30" Width="100%">
                        <PagerSettings Position="TopAndBottom" />
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    n 
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="CongViec" HeaderText="Sự kiện" />
                            <asp:BoundField DataField="TenDangNhap" HeaderText="Người thực hiện">
                                <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IPMay" HeaderText="IP  máy trạm">
                                <ItemStyle Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NgayTaoLog" HeaderText="Thời gian">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <input type="hidden" id="hidWord" runat="server">
        <input type="hidden" id="hidGroup" runat="server">
        <input type="hidden" id ="hidPhanHe" runat="server"/>
        <input type="hidden" id="hidUser" runat="server">
        <input type="hidden" id="hidFromDate" runat="server">
        <input type="hidden" id="hidToDate" runat="server">
        <input type="hidden" id="hidFromTime" runat="server">
        <input type="hidden" id="hidToTime" runat="server">
        <asp:DropDownList runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Không có dữ liệu thoả mãn điều kiện tìm kiếm!</asp:ListItem>
            <asp:ListItem Value="3">Không có dữ liệu thoả mãn điều kiện tìm kiếm!</asp:ListItem>
        </asp:DropDownList>

    </body>
</asp:Content>
