<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThayDoiThongTinNguoiDung.aspx.cs" Inherits="QuanTriHeThong_ThayDoiThongTinNguoiDung" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body>

    <div>
    <TABLE id="table3" cellSpacing=0 cellPadding=2 width="100%" border=0>
                            <TBODY>
                            <TR class="TVLibPageTitle">
                            <TD colspan="4">  
                                <asp:Label ID="Label9" runat="server" Text="THAY ĐỔI THÔNG TIN CÁ NHÂN"></asp:Label>
                                </TD>
                            </TR>
                                            
                            <TR>
                            <TD align=right>
                                            <asp:Label ID="Label2" runat="server" Text="Họ tên:"></asp:Label>
                            </TD><TD align=left colspan="3">
                                            <asp:TextBox ID="txthoten" runat="server" Width="200px"></asp:TextBox>
                                </TD></TR>
                               <TD align=right>
                                             <asp:Label ID="Label3" runat="server" Text="Tên đăng nhập:"></asp:Label>
                            </TD><TD align=left colspan="3">
                                            <asp:TextBox ID="txtTenDangNhap" runat="server" Width="200px" Enabled="False" ></asp:TextBox> 
                                </TD></TR>
                               <TD align=right>
                                            <asp:Label ID="Label7" runat="server" Text="Email: "></asp:Label>
                            </TD><TD align=left colspan="3">
                                            
                                            <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                                            
                                </TD></TR>                             
                                                                   <TR><TD align=right>
                                            
                                            <asp:Label ID="Label4" runat="server" Text="Điên thoại:"></asp:Label>
                                            
                                                                       </TD><TD align=left colspan="3">
                                            
                                            <asp:TextBox ID="txtDienthoai" runat="server" Width="200px"></asp:TextBox>
                                            
                                                                       </TD></TR><TR><TD align=right>
                                            
                                            <asp:Label ID="Label8" runat="server" Text="Ghi chú:"></asp:Label>
                                            
                                            </TD><TD align=left colspan="3"> 
                                            
                                            <asp:TextBox ID="txtGhiChu" runat="server" Width="200px"></asp:TextBox>
                                            
                                    </TD></TR><TR><TD align=right style="height: 26px">
                                             <asp:Label ID="Label5" runat="server" Text="Mật khẩu:"></asp:Label>
                                        </TD><TD align=left colspan="3" style="height: 26px"> 
                                            <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                                    </TD></TR>
                                    <TR >
                                    <TD align=right><asp:label id="lbReTypePass" runat="server" Width="60%"><u>G</u>õ lại mật khẩu:</asp:label></TD>
                                        <TD align=left colspan="3">
                                    <asp:textbox id="txtGoLaiMatKhau" runat="server" CssClass="lbTextBox" 
                                        Width="200px" MaxLength="50" TextMode="Password"></asp:textbox> </TD></TR>
                                        <TR class ="TVLibFunctionTitle">
                                    <TD style="HEIGHT: 8px" class="lbPageTitle" align=justify>&nbsp;</TD>
                                    <TD style="HEIGHT: 8px" class="lbPageTitle" align=justify> &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnThemmoi" runat="server" Text="Thêm mới" Width="79px" 
                                                onclick="btnThemmoi_Click" />
                        &nbsp;&nbsp;&nbsp;</TD><TD style="HEIGHT: 8px" class="lbPageTitle" align=center>&nbsp;</TD>
                                    <TD style="HEIGHT: 8px" class="lbPageTitle" align=center>&nbsp;</TD></TR></TBODY></TABLE>
                                       <INPUT id="hdPassword" type=hidden runat="server" /> 
    </div>
    
</body>
</asp:Content>