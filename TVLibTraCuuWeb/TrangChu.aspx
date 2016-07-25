<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="TrangChu.aspx.cs" Inherits="TVLibTraCuuWeb.TrangChu" %>

<%@ Register Src="KetQuaTimKiem.ascx" TagName="KetQuaTimKiem" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="Server">

    <script>
        function XuLyCanTrai() {


            //alert(document.getElementsByName("Left")[0]);

            document.getElementsByName("Main")[0].height = document.body.clientHeight - 180;

        }
        function get_documentIds() {

            var ids = "";
            $("#aspnetForm input:checkbox.chkItem:checked").each(function () {
                ids += $(this).attr('value');
                ids += "k";
            });
            $("input[id*=selecteddocumentIds]").val(ids);
            $.cookie("documentIds", ids);
            OpenWindow('YeuCauMuon.aspx', 'YeuCauMuon', 600, 250, 50, 50);

        }
    </script>
    <table width="970px" align="center">
        <asp:HiddenField ID="selecteddocumentIds" runat="server" Value="" />
        <tr>

            <td align="center">

                <table align="center" cellpadding="0" cellspacing="0" width="970px">
                    <tr>
                        <td align="left" style="margin-left:10px">
                           &nbsp;&nbsp; <asp:Label runat="server" ID="lblDangNhap" Visible="False"></asp:Label>
                              <asp:LinkButton
                                ID="lnkTrangCaNhan" runat="server" 
                                Font-Bold="True" OnClick="lnkTrangCaNhan_Click">Trang cá nhân

                            </asp:LinkButton>
                        </td>

                    </tr>
                    <tr>
                        <td align="right">
                            
&nbsp;&nbsp;<asp:Label runat="server" ID="lblSoThe" Text="Số thẻ :"></asp:Label>&nbsp;&nbsp;
      <asp:TextBox runat="server" ID="txtSoThe"></asp:TextBox>
                            <asp:LinkButton
                                ID="lnkDangNhap" runat="server" OnClick="lnkDangNhap_Click"
                                Font-Bold="True">Đăng nhập</asp:LinkButton>
                          
                            <asp:LinkButton
                                ID="lnkLogOut" runat="server" OnClick="lnkLogOut_Click" Font-Bold="True" Font-Size="Larger">Thoát</asp:LinkButton>&nbsp;&nbsp;
                        </td>

                    </tr>
                    <tr>

                        <td align="center">

                            <table align="center" cellpadding="0" cellspacing="0" width="970px">
                                <tr align="center" style="width: 100%">
                                    <td>
                                        <table width="100%">
                                            <tr class="TVLibPageTitle">
                                                <td colspan="2">
                                                    <asp:Label ID="Label3" runat="server" Text="TRA CỨU"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="35%" align="right">
                                                    <asp:DropDownList ID="ddlFieldName" runat="server" Height="22px">
                                                        <asp:ListItem Value="0">Mọi trường</asp:ListItem>
                                                        <asp:ListItem Value="1">Nhan đề</asp:ListItem>
                                                        <asp:ListItem Value="2">Tác giả</asp:ListItem>
                                                        <asp:ListItem Value="3">Đồng tác giả</asp:ListItem>
                                                        <asp:ListItem Value="4">Mô tả</asp:ListItem>
                                                        <asp:ListItem Value="5">Nhà xuất bản</asp:ListItem>
                                                        <asp:ListItem Value="6">Từ khóa</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearch" runat="server" Width="60%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="35%" align="right">
                                                    <asp:DropDownList ID="ddlToanTu" runat="server">
                                                        <asp:ListItem Value="1">AND</asp:ListItem>
                                                        <asp:ListItem Value="2">OR</asp:ListItem>
                                                        <asp:ListItem Value="3">NOT</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlFieldName1" runat="server">
                                                        <asp:ListItem Value="0">Mọi trường</asp:ListItem>
                                                        <asp:ListItem Value="1">Nhan đề</asp:ListItem>
                                                        <asp:ListItem Value="2">Tác giả</asp:ListItem>
                                                        <asp:ListItem Value="3">Đồng tác giả</asp:ListItem>
                                                        <asp:ListItem Value="4">Mô tả</asp:ListItem>
                                                        <asp:ListItem Value="5">Nhà xuất bản</asp:ListItem>
                                                        <asp:ListItem Value="8">Từ khóa</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearch1" runat="server" Width="60%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="35%" align="right">
                                                    <asp:DropDownList ID="ddlToanTu1" runat="server">
                                                        <asp:ListItem Value="1">AND</asp:ListItem>
                                                        <asp:ListItem Value="2">OR</asp:ListItem>
                                                        <asp:ListItem Value="3">NOT</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlFieldName2" runat="server">
                                                        <asp:ListItem Value="0">Mọi trường</asp:ListItem>
                                                        <asp:ListItem Value="1">Nhan đề</asp:ListItem>
                                                        <asp:ListItem Value="2">Tác giả</asp:ListItem>
                                                        <asp:ListItem Value="3">Đồng tác giả</asp:ListItem>
                                                        <asp:ListItem Value="4">Mô tả</asp:ListItem>
                                                        <asp:ListItem Value="5">Nhà xuất bản</asp:ListItem>
                                                        <asp:ListItem Value="8">Từ khóa</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearch2" runat="server" Width="60%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm"
                                                        OnClick="btnTimKiem_Click" />
                                                    &nbsp;
                                       <asp:Button ID="btnCancel" runat="server" Text="Hủy bỏ"
                                           OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" align="center">
                                           
                                            <tr class="TVLibPageTitle">
                                                <%--<td align="left">

                                                    <asp:HyperLink ID="lnkGuiYeuCau0" Font-Bold="True" NavigateUrl="#" onclick="get_documentIds()"
                                                        runat="server" Visible="false"><Font Color='Blue'> Đặt mượn</Font></asp:HyperLink></td>--%>

                                                <td align="right">

                                                    <asp:HyperLink ID="lnkGuiYeuCau" Font-Bold="True" NavigateUrl="#" onclick="get_documentIds()"
                                                        runat="server"><Font Color='Blue'>&#160;&#160;&#160;&gt;* Gửi yêu cầu mượn</Font></asp:HyperLink></td>

                                            </tr>
                                            <tr>
                                                <td colspan="2" align="left">
                                                    <%-- onclick= '<script>parent.Main.location.href="TaiLieuChiTiet.aspx?TaiLieuID =4"</script>'--%>

                                                    <asp:Label ID="lbRersult" runat="server" Font-Bold="True" ForeColor="Maroon" Visible="false"></asp:Label>
                                                    <br />

                                                    <asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False"
                                                        Width="100%"
                                                        AllowPaging="True" OnRowCreated="grvTaiLieu_RowCreated"
                                                        OnPageIndexChanging="grvTaiLieu_PageIndexChanging" PageSize="15">
                                                        <PagerSettings Position="Top" />
                                                        <RowStyle BorderStyle="Ridge" BorderWidth="1px" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="STT">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nhan đề">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbNhanDe" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="40%" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="TacGia" HeaderText="Tác giả">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="25%" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="NhaXuatBan" HeaderText="Nhà xuất bản">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Năm XB">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NgayXuatBan") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("NgayXuatBan") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mượn" ItemStyle-Width="3%">

                                                                <ItemTemplate>
                                                                    <input id="chkItem" type="checkbox" class="chkItem" value="<%#Eval("TaiLieuID") %>" />
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="column-check" />
                                                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle
                                                            BorderStyle="None" />
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
