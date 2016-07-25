<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachTaiLieu.aspx.cs" Inherits="BoSungBienMuc_DanhSachTaiLieu" MasterPageFile="~/MasterPage.master" %>



<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="right">
        <table id="Table1" cellpadding="2" width="970px" border="0" align="center">
            <tr class="TVLibPageTitle">
                <td height="10" colspan="3" align="left">&nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server" Text="DANH SÁCH TÀI LIỆU"></asp:Label>
                </td>
                <td align="right"></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="Dạng tài liệu:" Visible="false"></asp:Label>
                </td>
                <td align="left" colspan="2">

                    <asp:DropDownList ID="drdlLoaiTaiLieu" runat="server" Width="40%" Visible="false" AutoPostBack="true"
                        OnSelectedIndexChanged="drdlLoaiTaiLieu_SelectedIndexChanged">
                    </asp:DropDownList>

                </td>
                <td align="right">
                    <asp:HyperLink ID="lnkQuanLyTaiLieu" Font-Bold="true" NavigateUrl="MauBienMucIndex.aspx" runat="server"><Font Color='Blue'>&#160;&#160;&#160;&gt;* THÊM MỚI TÀI LIỆU</Font></asp:HyperLink>
                </td>
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
                <td colspan="4" align="center">&nbsp;</td>
            </tr>
            <tr class="TVLibPageTitle">
                <td colspan="4" align="center" class="style1">

                    <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" OnClick="btnTimKiem_Click" />&nbsp;
                    <asp:Button ID="btnLamLai" runat="server" Text="Làm lại" OnClick="btnLamLai_Click" />

                </td>
            </tr>
            <tr>
                <td height="17" colspan="2" align="left" valign="middle">
                    <asp:Label ID="lblTotallb0" runat="server" Font-Bold="True"
                        ForeColor="#0066FF">&nbsp;&nbsp;&nbsp;Số bản ghi trên trang:</asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="10">10 kết quả</asp:ListItem>
                        <asp:ListItem Value="20">20 kết quả</asp:ListItem>
                        <asp:ListItem Value="50">50 kết quả</asp:ListItem>
                        <asp:ListItem Value="100">100 kết quả</asp:ListItem>
                        <asp:ListItem Value="200">200 kết quả</asp:ListItem>
                        <asp:ListItem Value="500">500 kết quả</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td height="17" colspan="2" align="right">
                    <asp:Label ID="lblTotallb" runat="server" Font-Bold="True" ForeColor="#0066FF">&nbsp;&nbsp;&nbsp;Tổng số bản ghi:&nbsp;</asp:Label>
                    <asp:Label ID="lblTotal" runat="server" Font-Bold="True" ForeColor="#990000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="17" colspan="2">&nbsp;</td>
                <td height="17" colspan="2" align="right">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False"
                        Width="100%" DataKeyNames="TaiLieuID" OnRowDeleting="grvTaiLieu_RowDeleting" AllowPaging="True"
                        OnPageIndexChanging="grvTaiLieu_PageIndexChanging" PageSize="20">
                        <PagerSettings Position="TopAndBottom" />
                        <Columns>
                            <asp:BoundField DataField="STT" HeaderText="STT">
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Nhan đề" DataField="NhanDe"
                                ApplyFormatInEditMode="True">
                                <ItemStyle Width="650px" HorizontalAlign="Left" VerticalAlign="Middle"
                                    Wrap="True" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="LienKetXepGia"
                                DataNavigateUrlFormatString="{0}" HeaderText="Xếp giá"
                                Text="&lt;Img src='../Resources/Images/XG1.jpg' border=0&gt;">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                            <asp:HyperLinkField HeaderText="Biên mục" DataNavigateUrlFields="LienKetSua"
                                DataNavigateUrlFormatString="{0}"
                                Text="&lt;Img src='../Resources/Images/Edit.gif' border=0&gt;">
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                            </asp:HyperLinkField>
                             <asp:HyperLinkField HeaderText="Xem" DataNavigateUrlFields="ViewMarc"
                                DataNavigateUrlFormatString="{0}"
                                Text="&lt;Img src='../Resources/Images/Edit.gif' border=0&gt;">
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:HyperLinkField>
                            <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa?');"
                                        CommandName="Delete" ImageUrl="~/Resources/Images/delete.gif" Text="Delete" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>

                </td>
            </tr>
        </table>
    </div>
</asp:Content>
