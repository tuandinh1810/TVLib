<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DuyetDangKyMuon.aspx.cs" Inherits="LuuThong_DuyetDangKyMuon" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <script language="javascript" src="../Resources/JS/Calendar.js" type="text/javascript"></script>
        <script language="javascript" src="../Resources/Js/TVLib.js" type="text/javascript"></script>
        <table style="width: 970px;" align="center">
            <tr class="TVLibPageTitle">
                <td>
                    <asp:Label runat="server" ID="lbl1" Text="DANH SÁCH ĐĂNG KÝ MƯỢN"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>

            <tr>
                <td>

                    <asp:Label ID="Label5" runat="server" Text="Thời gian từ:"></asp:Label>
                    <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                    &nbsp;<a onclick="javascript:mThoiGian.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                    <script language="JavaScript">
                        var mThoiGian = new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtFromDate']);
                        mThoiGian.year_scroll = true;
                        mThoiGian.time_comp = false;
                    </script>
                    &nbsp;&nbsp; 
                        &nbsp; 
                        &nbsp;&nbsp;
                         &nbsp;
                                <asp:Label ID="Label2" runat="server" Text="Tới:"></asp:Label>
                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                    &nbsp;<a onclick="javascript:mThoiGian1.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                    <script language="JavaScript">
                        var mThoiGian1 = new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtToDate']);
                        mThoiGian1.year_scroll = true;
                        mThoiGian1.time_comp = false;
                    </script>
                    &nbsp;&nbsp; 
                        &nbsp;
                    <asp:Label runat="server" ID="lbl5" Text="Số thẻ"></asp:Label>
                    <asp:TextBox runat="server" ID="txtSoThe"></asp:TextBox>
                    <asp:Button ID="btnLoc" runat="server" OnClick="btnLoc_Click" Text="Lọc" />
                    &nbsp;&nbsp;
                                <asp:Button ID="btnIn" runat="server" OnClick="btnLoc_Click"
                                    Text="In phiếu mượn" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblHoTen" runat="server" Text="Họ tên"></asp:Label>
                    &nbsp;
                    <asp:Label ID="_lblHoTen" runat="server"></asp:Label>
                </td>
            </tr>
            <td align="center">
                <asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False"
                    Width="100%">
                    <Columns>
                        <asp:BoundField DataField="STT" HeaderText="STT">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SoThe" HeaderText="Số thẻ" />
                        <asp:TemplateField HeaderText="Nhan đề">
                            <ItemTemplate>
                                <a href="../BoSungBienMuc/XepGia.aspx?IDTaiLieu=<%#Eval("IDTaiLieu")%>"><%#Eval("NhanDe")%></a>
                            </ItemTemplate>
                            <ItemStyle Width="50%" />
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="NhanDe" HeaderText="Nhan đề">
                                <ItemStyle HorizontalAlign="Left" Width="45%" />
                            </asp:BoundField>--%>
                        <asp:BoundField DataField="NgayMuon" HeaderText="Ngày yêu cầu" DataFormatString="{0:dd/MM/yyyy}">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
        </table>

    </div>
</asp:Content>
