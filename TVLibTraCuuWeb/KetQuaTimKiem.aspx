<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="false"  CodeFile="KetQuaTimKiem.aspx.cs" Inherits="TVLibTraCuuWeb.KetQuaTimKiem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            height: 96px;
        }
    </style>
</head>
<body style="margin-top:0"  >
    <form id="form1" runat="server">
    <div>
    <table width="100%" align="center"  >
    <tr valign ="top" >
    <td colspan ="2" align="center"   background="Resources/images/title_bg.gif" style="background-repeat:no-repeat " height="30"  width="600" align ="center" valign ="top"  >
     <img src="Resources/Images/HeadKetquaTim.GIF" runat="server" id="imgTimKiem" visible="false"  />
        <asp:Label ID="lbThongBao" runat="server" Text="DANH MỤC SÁCH MỚI" 
            Font-Bold="True" ForeColor="#003366" Enabled="False" Font-Size="Medium"></asp:Label>
     
    </td>
   
    </tr>
    <tr>
    <td colspan ="2" align="left"  >
   <%-- onclick= '<script>parent.Main.location.href="TaiLieuChiTiet.aspx?TaiLieuID =4"</script>'--%>
   
        <asp:Label ID="lbRersult" runat="server" Font-Bold="True" ForeColor="Maroon" Visible ="false"  ></asp:Label>
    <br />
    
        <asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False" 
            Width="100%" CellPadding="0" ForeColor="#333300" GridLines="Horizontal" 
            AllowPaging="True" onrowcreated="grvTaiLieu_RowCreated" 
            onpageindexchanging="grvTaiLieu_PageIndexChanging" PageSize="20">
            <PagerSettings Position="Top" />
            <RowStyle BackColor="#EFF3FB" BorderStyle="Ridge" BorderWidth="1px" />
            <Columns>
              <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                <asp:TemplateField HeaderText="Nhan đề">
                    <ItemTemplate>
                        <asp:Label ID="lbNhanDe" runat="server"  ></asp:Label>
                    </ItemTemplate>                   
                    <ItemStyle Width="50%" />
                </asp:TemplateField>
                <asp:BoundField DataField="TacGia" HeaderText="Tác giả" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle Width="30%" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Năm xuất bản">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NgayXuatBan") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("NgayXuatBan") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                BorderStyle="None" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </td>
    </tr>
   
    
    </table>
    </div>
    </form>
</body>
</html>
