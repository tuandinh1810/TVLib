<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NguoiDung.aspx.cs" Inherits="QuanTriHeThong_NguoiDung" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>

        <div>
            <table align="center" width="970px">
                <tr>
                    <td>
                        <table id="TableCenter">
                            <tbody>
                                <tr class="TVLibPageTitle">
                                    <td width="50%">
                                        <asp:Label ID="Label9" runat="server" Text="DANH SÁCH NGƯỜI DÙNG"></asp:Label>

                                    </td>
                                    <td colspan="2">
                                        <asp:Label ID="lblPageTitle2" runat="server">THÔNG TIN CHI TIỂT</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="45%">
                                        <asp:HyperLink ID="lnkUser" runat="server">Thay đổi thông tin cá nhân</asp:HyperLink><br />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" Text="* Khi cập nhật tài khoản, chỉ nhập mật khẩu khi muốn thay đổi mật khẩu cũ"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table id="table4" cellspacing="0" cellpadding="2" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td align="left">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grvNguoiDung" runat="server" Width="100%"
                                                            AutoGenerateColumns="False" DataKeyNames="NguoiDungID"
                                                            OnRowCancelingEdit="grvNguoiDung_RowCancelingEdit"
                                                            OnRowDeleting="grvNguoiDung_RowDeleting"
                                                            OnRowEditing="grvNguoiDung_RowEditing">

                                                            <Columns>
                                                                <%-- <asp:TemplateColumn HeaderText="Căn lề">
										                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
										                        <ItemTemplate>
											                        <asp:DropDownList Runat="server" ID="ddlAlign" Width="100%">
												                        <asp:ListItem Value="CenterTop">Center</asp:ListItem>
												                        <asp:ListItem Value="RightTop">Right</asp:ListItem>
												                        <asp:ListItem Value="LeftTop">Left</asp:ListItem>
											                        </asp:DropDownList>
										                        </ItemTemplate>
									                        </asp:TemplateColumn>--%>

                                                                <asp:TemplateField HeaderText="Họ tên">

                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblHoVaTen" runat="server" Text='<%# Bind("TenNguoiDung") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="TenDangNHap" HeaderText="Tên đăng nhập" />
                                                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                                                <asp:BoundField DataField="NguoiDungID" HeaderText="NguoiDungID"
                                                                    Visible="False" />
                                                                <asp:CommandField ButtonType="Image"
                                                                    CancelImageUrl="~/Resources/Images/Cancel.gif"
                                                                    EditImageUrl="~/Resources/Images/Edit.gif" HeaderText="Sửa"
                                                                    ShowEditButton="True" UpdateImageUrl="~/Resources/Images/Edit.gif">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:CommandField>
                                                                <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton OnClientClick="return confirm('Bạn có chắc chắn muốn xóa?')" ID="ImageButton1" runat="server"
                                                                            CommandName="Delete" ImageUrl="~/Resources/Images/delete.gif" Text="Delete" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

                                                        <br />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <table id="table3" cellspacing="0" cellpadding="2" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="WIDTH: 208px" align="right">
                                                        <asp:Label ID="Label2" runat="server" Text="Họ tên:"></asp:Label>
                                                    </td>
                                                    <td style="WIDTH: 246px; HEIGHT: 20px" align="left">
                                                        <asp:TextBox ID="txthoten" runat="server" Width="60%"></asp:TextBox>
                                                        <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="(*)"></asp:Label>
                                                    </td>
                                                </tr>
                                                <td style="WIDTH: 208px" align="right">
                                                    <asp:Label ID="Label3" runat="server" Text="Tên đăng nhập:"></asp:Label>
                                                </td>
                                                <td style="WIDTH: 246px; HEIGHT: 20px" align="left">
                                                    <asp:TextBox ID="txtTenDangNhap" runat="server" Width="50%"></asp:TextBox>
                                                    <asp:Label ID="Label12" runat="server" ForeColor="Red" Text="(*)"></asp:Label>
                                                </td>
                                </tr>
                                <td style="WIDTH: 208px" align="right">
                                    <asp:Label ID="Label7" runat="server" Text="Email: "></asp:Label>
                                </td>
                                <td style="WIDTH: 246px; HEIGHT: 20px" align="left">

                                    <asp:TextBox ID="txtEmail" runat="server" Width="60%"></asp:TextBox>

                                </td>
                </tr>
                <tr>
                    <td style="WIDTH: 208px; HEIGHT: 20px" align="right">

                        <asp:Label ID="Label4" runat="server" Text="Điên thoại:"></asp:Label>

                    </td>
                    <td style="WIDTH: 246px; HEIGHT: 20px" align="left">

                        <asp:TextBox ID="txtDienthoai" runat="server" Width="40%"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="WIDTH: 208px" align="right">

                        <asp:Label ID="Label8" runat="server" Text="Ghi chú:"></asp:Label>

                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtGhiChu" runat="server" Width="70%"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="WIDTH: 208px" align="right">
                        <asp:Label ID="Label5" runat="server" Text="Mật khẩu:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password" Width="50%"></asp:TextBox>
                        <asp:Label ID="lbRedPassword" runat="server" ForeColor="Red" Text="(*)"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="WIDTH: 208px" align="right">
                        <asp:Label ID="lbReTypePass" runat="server" Width="60%"><u>G</u>õ lại mật khẩu:</asp:Label></td>
                    <td style="WIDTH: 246px; HEIGHT: 15px" align="left">
                        <asp:TextBox ID="txtGoLaiMatKhau" runat="server" CssClass="lbTextBox"
                            Width="50%" MaxLength="50" TextMode="Password"></asp:TextBox><asp:Label ID="lbRetPassword2" runat="server" ForeColor="Red" Text="(*)"></asp:Label>
                    </td>
                </tr>
                <tr class="TVLibFunctionTitle">
                    <td style="HEIGHT: 8px" class="lbPageTitle" align="center" colspan="2">
                        <asp:Label ID="Label15" runat="server" Text="Quyền truy cập vào các phân hệ"></asp:Label></td>
                    <td style="HEIGHT: 8px"></td>
                </tr>
                <tr>
                    <td style="WIDTH: 208px; HEIGHT: 20px" align="right">
                        <asp:Label ID="lblAdmin" runat="server"
                            Text="&lt;u&gt;Q&lt;/u&gt;uản trị hệ thống" Width="60%"></asp:Label></td>
                    <td style="HEIGHT: 20px">
                        <table width="100%">
                            <tbody>
                                <tr>
                                    <td align="left" width="20%">
                                        <asp:DropDownList ID="drdlQTHT" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" width="80%">
                                        <asp:HyperLink ID="lnkQTHT" runat="server"
                                            NavigateUrl="#">Gán quyền</asp:HyperLink>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="WIDTH: 208px; HEIGHT: 20px" align="right">
                        <asp:Label ID="lblRequest" runat="server" Text="&lt;u&gt;B&lt;/u&gt;ổ sung - Biên mục"
                            Width="60%"></asp:Label></td>
                    <td style="HEIGHT: 20px">
                        <table width="100%">
                            <tbody>
                                <tr>
                                    <td align="left" width="20%">
                                        <asp:DropDownList ID="drdlBSBM" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" width="80%">
                                        <asp:HyperLink ID="lnkBSBM" runat="server"
                                            NavigateUrl="#">Gán quyền</asp:HyperLink>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="WIDTH: 208px; HEIGHT: 20px" align="right">
                        <asp:Label ID="lblRequest0" runat="server" Text="&lt;u&gt;L&lt;/u&gt;ưu thông"
                            Width="60%"></asp:Label></td>
                    <td style="HEIGHT: 20px">
                        <table width="100%">
                            <tbody>
                                <tr>
                                    <td align="left" width="20%">
                                        <asp:DropDownList ID="drdlLuuThong" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" width="80%">
                                        <asp:HyperLink ID="lnkQLLuuThong" runat="server"
                                            NavigateUrl="#">Gán quyền</asp:HyperLink>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="WIDTH: 208px; HEIGHT: 20px" align="right">
                        <asp:Label ID="Label6" runat="server" Text="Bạn &lt;u&gt;Đ&lt;/u&gt;ọc"
                            Width="60%"></asp:Label></td>
                    <td style="HEIGHT: 20px">
                        <table width="100%">
                            <tbody>
                                <tr>
                                    <td align="left" width="20%">
                                        <asp:DropDownList ID="drdlBanDoc" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" width="80%">
                                        <asp:HyperLink ID="lnkBanDoc" runat="server" NavigateUrl="#">Gán quyền</asp:HyperLink>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="WIDTH: 208px; HEIGHT: 20px" align="right">
                        <asp:Label ID="Label10" runat="server" Text="Ấn phẩm định kỳ"
                            Width="60%"></asp:Label></td>
                    <td style="HEIGHT: 20px">
                        <table width="100%">
                            <tbody>
                                <tr>
                                    <td align="left" width="20%">
                                        <asp:DropDownList ID="drdlAPDK" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" width="80%">
                                        <asp:HyperLink ID="lnkAPDK" runat="server" NavigateUrl="#">Gán quyền</asp:HyperLink>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnThemmoi" runat="server" Text="Thêm mới" Width="79px"
                            OnClick="btnThemmoi_Click" />
                        &nbsp;&nbsp;
                                            <asp:Button ID="btnThoi" runat="server" Text="Làm Lại" Width="79px"
                                                OnClick="btnThoi_Click" />
                    </td>
                </tr>
                <tr class="TVLibControlBar">
                    <td align="center" colspan="2">&nbsp;</td>
                </tr>
                </TBODY>
            </table>
            </TD></TR></TBODY>
                      </TABLE>
                      
                  </td>
                  </tr>
                  </table>    
    <input id="hdParams" type="hidden" runat="server" />
            <input id="hdPassword" type="hidden" runat="server" />
            <input id="hidParentID" type="hidden" runat="server" />
            <input id="hidUserID" type="hidden" value="0" runat="server" />
            <input id="hdRights" type="hidden" runat="server" />
            <input id="hidUpdate" type="hidden" runat="server" />
            <input id="hidQuyenIDs" type="hidden" runat="server" />

        </div>
        <%-- <asp:TemplateColumn HeaderText="Căn lề">
										                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
										                        <ItemTemplate>
											                        <asp:DropDownList Runat="server" ID="ddlAlign" Width="100%">
												                        <asp:ListItem Value="CenterTop">Center</asp:ListItem>
												                        <asp:ListItem Value="RightTop">Right</asp:ListItem>
												                        <asp:ListItem Value="LeftTop">Left</asp:ListItem>
											                        </asp:DropDownList>
										                        </ItemTemplate>
									                        </asp:TemplateColumn>--%>
    </div>
    
    </body>
</asp:Content>

