<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MauNhanGay.aspx.cs" Inherits="BoSungBienMuc_InAn_MauNhanGay" ValidateRequest="false" MasterPageFile="~/MasterPage.master"  %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body style="margin-top:0;">
  
    <div>
  <table align="center" width="970px" >
        <tr class="TVLibPageTitle">
        <td colspan="2">
            <asp:Label Text="Định dạng mẫu nhãn gáy" ID="lb" runat="server" ></asp:Label>
        </td>
        </tr>
        <tr>
            <td width="15%" align="right" >
                <asp:Label ID="Label1" runat="server" Text="Mẫu nhãn gáy:"></asp:Label>
            </td>
            <td>
                &nbsp;<asp:DropDownList ID="ddlNhanGay" runat="server" Width="15%" 
                    onselectedindexchanged="ddlNhanGay_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
          <tr>
            <td width="15%" align="right" >
                <asp:Label ID="Label4" runat="server" Text="Tên mẫu nhãn gáy:"></asp:Label>
            </td>
            <td>
                &nbsp;<asp:TextBox ID="txtTenMau" runat="server" Width="20%">
                </asp:TextBox>
            </td>
        </tr>
          <tr>
            <td width="15%" align="right" valign="top"  >
                <asp:Label ID="Label2" runat="server" Text="Nội dung:"></asp:Label>
            </td>
            <td>
            &nbsp;<asp:TextBox ID="txtNoiDung" runat="server" Rows="10" TextMode="MultiLine" 
                    Width="45%"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td width="15%" align="right" >
                &nbsp;</td>
            <td>
            &nbsp;</td>
        </tr>
          <tr style="background-color:Silver" >
            <td width="15%" align="right" >
            </td>
            <td>
                &nbsp;<asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật(u)" 
                    onclick="btnCapNhat_Click"  />&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="Đặt lại(r)"    />
            &nbsp;
                <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
                    Text="Xóa(d)" />
            </td>
        </tr>
          <tr>
            <td width="15%" align="right" >
            </td>
            <td>
            </td>
        </tr>
    </table>
    </div>
    
</body>
</asp:Content>
