<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XemBieuGhiBienMuc.aspx.cs" Inherits="BoSungBienMuc_XemBieuGhiBienMuc" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>

        <div>
            <table align="center" width="970px">
                <tr>
                    <td>
                        <table width="100%">
                            <tr class="TVLibPageTitle">
                                <td>
                                    <asp:Label ID="lblPageTitle" runat="server" Text="HIỂN THỊ MARC"></asp:Label>
                                </td>

                            </tr>
                           
                             <tr>
                                <td>&nbsp;</td>
                            </tr>
                             <tr>
                                <td><asp:Label runat="server" ID="lblISBD" Font-Size="Larger"></asp:Label>
                                    <br />     <br />
                                    <asp:Button runat="server" Text="Xuất word" ID="btnExport" OnClick="btnExport_Click" />
                                </td>
                            </tr>
                              <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr class="TVLibPageTitle">
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="HIỂN THỊ ĐẦY ĐỦ"></asp:Label>
                                </td>

                            </tr>
                           
                            <tr>
                                <td>
                                    <asp:Table ID="tblViewCata" runat="server" Width="100%">
                                    </asp:Table>
                                </td>

                            </tr>
                            <tr>
                                <td height="5">&nbsp;</td>

                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnXepGia" runat="server" OnClick="btnXepGia_Click"
                                        Text="Xếp giá" />
                                    &nbsp;&nbsp;
        <asp:Button ID="btnSua" runat="server" OnClick="btnSua_Click" Text="Sửa"
            Width="80px" />
                                    &nbsp;&nbsp;
        <asp:Button ID="btnDong" runat="server" Text="Đóng" Width="80px"
            OnClick="btnDong_Click" />
                                </td>

                            </tr>
                        </table>
                    </td>
                </tr>

            </table>
        </div>


    </body>
</asp:Content>
