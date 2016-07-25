<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MauBienMuc_MARC21.aspx.cs" Inherits="BoSungBienMuc_MauBienMuc_MARC21" %>

<%@ Register src="../Banner.ascx" tagname="Banner" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MAU BIEN MUC MARC 21</title>
</head>
<body style="margin-left:0; margin-top:0; margin-bottom:0; margin-right:0">
<form id="form1" runat="server">
<div>
 <table align="center" width="970px" >
 <tr>
    <td colspan=2>
       
        <uc1:Banner ID="Banner1" runat="server" />
       
    </td>
    </tr>
    <tr class="TVLibPageTitle" >
    <td colspan="2">
        <asp:Label ID="Label1" runat="server" Text="Tạo mẫu biên mục" Width="100%"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td style="background-color:Silver " colspan="2">
        <asp:Label ID="Label2" runat="server" Text="Khối trường:" Font-Bold="True" 
            ForeColor="#0066FF"></asp:Label>
&nbsp;
        <asp:DropDownList ID="ddlKhoiTruong" runat="server" AutoPostBack="True" 
            Width="30%" onselectedindexchanged="ddlKhoiTruong_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
   
    </tr>
    <tr>
    <td width="50%" valign="top" >
        <asp:GridView ID="grvTruong" runat="server" AutoGenerateColumns="False" 
            Width="100%" DataKeyNames="MARC_FIELD_ID" 
            onselectedindexchanged="grvTruong_SelectedIndexChanged" AllowPaging="True" 
          
            onpageindexchanging="grvTruong_PageIndexChanging" PageSize="16">
            <PagerSettings Position="TopAndBottom" />
            <Columns>
             
                <asp:BoundField DataField="Code" HeaderText="Tên trường" >
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="Mô tả" />
                <asp:CommandField HeaderText="Chọn" ShowSelectButton="True" 
                    SelectText="&gt;&gt;">
                    <ItemStyle Width="10%" Wrap="True" HorizontalAlign="Center" />
                </asp:CommandField>
            </Columns>
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
    </td>
    <td valign="top" >
        <asp:GridView ID="grvTruongCon" runat="server" AutoGenerateColumns="False" 
            Width="100%" DataKeyNames="MARC_FIELD_ID" 
            onrowcreated="grvTruongCon_RowCreated">
            <Columns>
               <asp:TemplateField HeaderText="Chọn">
                 <ItemTemplate>
                          <asp:CheckBox ID="cbxDKCB" runat="server" />
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" Width="8%" />
                  </asp:TemplateField>
                <asp:BoundField DataField="Code" HeaderText="Tên trường con" />
                <asp:BoundField DataField="Name" HeaderText="Mô tả" />
            </Columns>
        </asp:GridView>
    </td>
    </tr>
    <tr>
    <td colspan="2"></td>
    </tr>
    <td colspan="2" style="background-color:Silver ">
        <asp:Label ID="Label3" runat="server" Text="Tên: " Font-Bold="True" 
            ForeColor="#0066FF"></asp:Label>
&nbsp;<asp:TextBox ID="txtTen" runat="server"></asp:TextBox>
&nbsp;
        <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới(a)" 
            onclick="btnThemMoi_Click" />
    &nbsp;&nbsp;
    </td>
  
    </tr>
   
</table>
</div>
<input type="hidden" id="hdIDs" value="" runat="server"  />
</form>
</body>
</html>
