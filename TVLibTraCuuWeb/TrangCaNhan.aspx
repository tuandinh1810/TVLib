<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrangCaNhan.aspx.cs" Inherits="TVLibTraCuuWeb.TrangCaNhan" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="Server">


    <table width="970px" align="center">
        <tr class="TVLibPageTitle">
            <td align="left">
                <asp:Label runat="server" ID="Label2">THÔNG TIN BẠN ĐỌC</asp:Label>
            </td>


        </tr>
        <tr valign="top">

            <td align="right" valign="top">

                <asp:HyperLink ID="lnkTraCuu" Font-Bold="True" NavigateUrl="~/TrangChu.aspx"
                    runat="server"><Font Color='Blue'>&#160;&#160;&#160;&gt;* Tra Cứu</Font></asp:HyperLink></td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lb1" runat="server" Text="Số thẻ:"></asp:Label>
                <asp:Label ID="lbSoTien" runat="server" Font-Bold="True"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label3" runat="server" Text="Tên tài khoản:"></asp:Label>
                <asp:Label ID="lbTenTaiKhoan" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td class="style1" align="left">&nbsp;</td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label7" runat="server" Text="Năm sinh:"></asp:Label>
                <asp:Label ID="lbNgayTao" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td align="left">&nbsp;</td>
        </tr>
        <tr>

            <td align="center">

                <table align="center" cellpadding="0" cellspacing="0" width="970px">

                    <tr>
                        <td>
                            <table width="100%" align="center">

                                <tr class="TVLibPageTitle">
                                    <td align="left">
                                        <asp:Label runat="server" ID="lblTaiLieuMuon">DANH SÁCH TÀI LIỆU ĐANG MƯỢN</asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">


                                            <Columns>
                                                <asp:TemplateField HeaderText="STT">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="5%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="MaXepGia" HeaderText="Mã xếp giá" />
                                                <asp:BoundField DataField="NhanDe" HeaderText="Nhan đề" />
                                                <asp:BoundField DataField="NgayMuon" HeaderText="Ngày mượn" />
                                                <asp:BoundField DataField="NgayTra" HeaderText="Ngày phải trả" />
                                                <asp:BoundField DataField="NgayQuaHan" HeaderText="Số ngày quá hạn" />
                                            </Columns>

                                        </asp:GridView>
                                    </td>

                                </tr>

                            </table>
                            <%--<uc2:KetQuaTimKiem ID="KetQuaTimKiem1" runat="server" />--%>
              
                        </td>

                    </tr>
                </table>


            </td>
        </tr>

    </table>
</asp:Content>
