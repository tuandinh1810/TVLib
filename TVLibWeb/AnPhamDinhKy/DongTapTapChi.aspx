<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DongTapTapChi.aspx.cs" Inherits="DongTapTapChi" MasterPageFile="~/MasterPage.master" %>



<asp:Content ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body>

    <div>
  <table align="center" width="970px" >
      <tr>
        <td align="center">
            <table ID="TableCenter" style="border:1;" cellspacing="0" cellpadding="0">
            <tr  class="TVLibPageTitle" >
                <td height="10" align="left" colspan="3">&nbsp;&nbsp;
                    <asp:Label  ID="Label6" runat="server" Text="XẾP GIÁ TÀI LIỆU"></asp:Label>
                </td>                    
                <td align="right" colspan="3">
                    <asp:HyperLink ID="lnkQuanLyTaiLieu" runat="server" ><Font Color='Blue'>&#160;&#160;&#160;&gt;&gt; DANH SÁCH TÀI LIỆU</Font></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="right" style="height: 35px" >
                    <asp:HyperLink ID="lnkQuanLyTaiLieu0" runat="server" 
                        NavigateUrl="MauBienMucIndex.aspx" ><Font Color='Blue'>&#160;&#160;&#160;BIÊN MỤC TÀI LIỆU</Font></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td height="17" align="left" colspan="6" >
                    <asp:Label ID="Label1" runat="server" Font-Bold=True>Nhan đề:</asp:Label>
                    <asp:Label ID="lblTenTaiLieu" runat="server" ForeColor="Blue">Nhan đề</asp:Label>
                </td>
            </tr>
            <tr>
            <td colspan="6">&nbsp;</td>
            
            </tr>
            <tr>
                <td height="17" align="left" width="12%" >
                    <asp:Label ID="Label3" runat="server" Text="Thư viện"></asp:Label>
                 </td>
                 <td height="17" align="left" width="12%" >
                    <asp:Label ID="Label7" runat="server">Chọn kho</asp:Label>
                 </td>
                 <td height="17" align="left" width="12%" >
                    <asp:Label ID="Label10" runat="server">Nhập mã giá</asp:Label>
                 </td>
                 <td height="17" align="left" width="30%" >
                   <asp:Label ID="Label8" runat="server">Mã xếp giá:</asp:Label>
                 </td>
                 <td height="17" align="left"  colspan="2" >
                   <asp:Label ID="Label2" runat="server">Số lượng</asp:Label>
                 </td>
            </tr>
            <tr>
            <td height="17" align="left" width="12%" >
               <asp:DropDownList ID="DrdlThuVien" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DrdlThuVien_SelectedIndexChanged">
                    </asp:DropDownList>
            </td>
            <td height="17" align="left" width="12%" >
              <asp:DropDownList ID="ddlKho" runat="server">
                    </asp:DropDownList>
            </td>
            <td height="17" align="left" width="12%" >
                <asp:TextBox ID="txtMaGia" runat="server" Width="77px"></asp:TextBox>
            </td>
            <td height="17" align="left" width="20%" >
                <asp:TextBox ID="txtMaXepGia" runat="server" Width="113px"></asp:TextBox>&nbsp;
                <asp:Button ID="BtnSinhTuDong" runat="server" Text="Sinh giá trị" 
                    onclick="BtnSinhTuDong_Click" /> 
            </td>
            <td height="17" align="left" width="10%" >
                <asp:TextBox ID="txtSoLuong" runat="server" Width="67px"></asp:TextBox>
            </td>
             <td height="17" align="left" >
                 &nbsp; <asp:Button ID="btnXepGia" runat="server" Text="Xếp giá" onclick="btnXepGia_Click" />
            </td>
            
            </tr>
          
            <tr>
                <td align="left" class="style8" colspan="6"  class="TVLibPageTitle" >
                    &nbsp;</td>
            </tr>
            <tr  class="TVLibPageTitle">
            <td colspan="6" align="center">
                <asp:Button ID="btnInMaVach" runat="server" Text="In mã vạch" onclick="btnInMaVach_Click" 
                     />
&nbsp;<asp:Button ID="btnInNhanGay" runat="server" Text="In Nhãn Gáy" />
                </td>
            </tr>
            <tr>
            <td colspan="6" align="center">
                &nbsp;</td>
            </tr>
            <tr  class="TVLibPageTitle" >
                <td height="17" align="left" class="style1" colspan="6" >
                    <asp:Label  ID="Label9" runat="server" Text="DANH SÁCH XẾP GIÁ"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="17" align="right" class="style1" colspan="6" >
                <img src='../Resources/Images/box closed.ico' >Chưa kiểm nhận
                &nbsp;&nbsp;<img src='../Resources/Images/Lock.ico' >Đang bị khóa
                &nbsp;&nbsp;<img src='../Resources/Images/People.ico'> Đang cho mượn
                &nbsp;&nbsp;<img src='../Resources/Images/available.gif' 
                        style="height: 19px; width: 21px">Sẵn sàng lưu thông
                        <br />
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="6" align="left" >
                    <asp:GridView ID="grvMaXepGia" runat="server" AutoGenerateColumns="False" 
                        Width="100%" DataKeyNames="ID,IDKho" onrowcreated="grvMaXepGia_RowCreated" 
                        onrowdeleting="grvMaXepGia_RowDeleting" AllowPaging="True" 
                        onpageindexchanging="grvMaXepGia_PageIndexChanging" PageSize="6" 
                        onrowdatabound="grvMaXepGia_RowDataBound" 
                        onrowediting="grvMaXepGia_RowEditing" 
                        onrowcancelingedit="grvMaXepGia_RowCancelingEdit" 
                        onrowupdating="grvMaXepGia_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="CheckAll">
                              <HeaderTemplate>
                                <asp:CheckBox ID="cbxCheckAll" runat="server" />
                            </HeaderTemplate>                             
                            <ItemTemplate>
                                <asp:CheckBox ID="cbxDKCB" runat="server" />
                            </ItemTemplate>
                              
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                              
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Mã xếp giá" DataField="MaXepGia" 
                                ApplyFormatInEditMode="True">
                                <ItemStyle Width="350px" HorizontalAlign="Left" VerticalAlign="Middle" 
                                    Wrap="True" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Kho">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DrdlKho" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("TenKho") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="15%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Shelf" HeaderText="Giá">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Trạng thái">
                                <EditItemTemplate>
                                    <asp:Label  ID="Lbl1" runat="server" Text='<%# Bind("IMG") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("IMG") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Image" EditImageUrl="~/Resources/Images/Edit.gif" 
                                EditText="" HeaderText="Sửa" ShowEditButton="True" 
                                CancelImageUrl="~/Resources/Images/Cancel.gif" 
                                UpdateImageUrl="~/Resources/Images/update.gif">
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnXoa" runat="server" CausesValidation="False"
                                        CommandName="Delete" ImageUrl="~/Resources/Images/delete.gif" Text="Delete" />
                                </ItemTemplate> <%--OnClientClick="return confirm('Bạn có chắc chắn muốn xóa không')"--%>
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
            <tr class="TVLibPageTitle">
            <td>
            <asp:Label ID="Label4" runat="server" Text="Lý do loại bỏ"></asp:Label>
            </td>
            <td width="15%" align="left">
                <asp:DropDownList ID="DrdlLyDoLoaiBo" runat="server">
                </asp:DropDownList>
                </td>
            <td colspan="4" align="left" >
                <asp:Button ID="btnLoaiBo" runat="server" Text="Loại Bỏ" 
                    onclick="btnLoaiBo_Click" />&nbsp;
                <asp:Button ID="BtnKiemNhan" runat="server" Text="Kiểm nhận/Mở khóa" 
                    onclick="BtnKiemNhan_Click" />
                </td>
            </tr>
            </table>
        </td>
        </tr>
    </table>    
        
    </div>
    
</body>
</asp:Content>
