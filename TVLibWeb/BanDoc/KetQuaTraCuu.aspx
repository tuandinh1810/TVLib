<%@ Page Language="C#"  AutoEventWireup="true"    EnableViewStateMAC="False"  EnableEventValidation="false" CodeFile="KetQuaTraCuu.aspx.cs" Inherits="BanDoc_KetQuaTraCuu" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body>
    
    <div>
    <table align="center" width="970px" >
    <tr class ="TVLibPageTitle">
        <td>
        
            <asp:Label ID="lbResult" runat="server" Text="Tổng số bạn đọc tìm thấy : " ></asp:Label>
            <asp:Label ID="lbValue" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
    <td>
        <asp:GridView ID="grvBanDoc" runat="server" AutoGenerateColumns="False" 
            Width="100%" 
            DataKeyNames="BanDocID,SoThe" onrowdeleting="grvBanDoc_RowDeleting" onrowdatabound="grvBanDoc_RowDataBound" 
            >
            <Columns>
                  <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            </asp:TemplateField>
                <asp:BoundField DataField="SoThe" HeaderText="Số thẻ">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="TenDayDu" HeaderText="Họ và tên">
                    <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh">
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="Lop" HeaderText="Lớp">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="TenNhomBanDoc" HeaderText="Nhóm bạn đọc">
                    <ItemStyle Width="20%" />
                </asp:BoundField>
                  <asp:TemplateField HeaderText="Sửa">                      
                      <ItemTemplate>
                          <asp:Label ID="Label2" runat="server"></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" Width="5%" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Xoá" ShowHeader="False">
                      <ItemTemplate>
                          <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False"  OnClientClick ="return confirm('Bạn có chắc chắn muốn xoá!');"
                              CommandName="Delete" ImageUrl="~/Resources/Images/delete.gif" Text="Delete" />
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" Width="5%" />
                  </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </td>
    </tr>
      <tr>
    
    <td align = "right" >

   <input type="hidden" runat ="server" id="hidSoThe" />
   <input type="hidden" runat ="server" id="hidTenDayDu" />
   <input type="hidden" runat ="server" id="hidNgaySinh" />
   <input type="hidden" runat ="server" id="hidNgayCapThe" />
   <input type="hidden" runat ="server" id="hidNgheNghiep" />
   <input type="hidden" runat ="server" id="hidDanToc" />
   <input type="hidden" runat ="server" id="hidNhomBanDoc" />
   <input type="hidden" runat ="server" id="hidNgayHetHan" />
   <input type="hidden" runat ="server" id="hidGioiTinh" />
   <input type="hidden" runat ="server" id="hidKhoa" />
   <input type="hidden" runat ="server" id="hidLop" />
   <input type="hidden" runat ="server" id="hidEvent" value ="0" />
          </td>
    </tr>
    </table>
    </div>
    
</body>
</asp:Content>
