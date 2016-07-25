<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MauBienMucIndex.aspx.cs" Inherits="BoSungBienMuc_MauBienMucIndex" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body>
    
    <div>
 <table align="center" width="970px" >
    <tr>
    <td>
    <table id="TableCenter" cellpadding="0" cellspacing="0" align="center" >
    <tr >
    <td align="Center"><asp:Label ID="Label2" runat="server" Text="Chọn loại tài liệu" Font-Bold="True" 
            ForeColor="#006699"></asp:Label></td>
    <td align="right" >
        &nbsp;</td>
    </tr>
    <tr >
    <td align=center >
                      
                        <asp:DropDownList ID="drdlLoaiTaiLieu" runat="server" width="200px">
                        </asp:DropDownList>
                      
                    </td>
    <td align="right" >
        &nbsp;</td>
    </tr>
    <tr >
    <td align=left ></td>
    <td align="right" >
        &nbsp;</td>
    </tr>
    <tr>
    <td colspan="2" align="center" >
    
        <asp:Label ID="Label1" runat="server" Text="Chọn mẫu biên mục" Font-Bold="True" 
            ForeColor="#006699"></asp:Label>
    
    </td>
    </tr>
    <tr>
        
					<TD align="center"  colspan="2" >
						<asp:ListBox ID="lsbMauBienMuc" Rows="10" runat="server" Width="200px" 
                          DataTextField="Ten" DataValueField="MauBienMucID" 
                        ></asp:ListBox>
                    </TD>
				</TR>
				<tr>
				<td  colspan="2" >
				</td>
				</tr>
				<TR style="background-color:Silver">
					<TD align="center" colspan="2" >
                        <asp:button id="btnUpdate" runat="server" Height="24px" 
                            Text="Biên mục(n)" Width="90px" onclick="btnUpdate_Click"></asp:button>&nbsp;<asp:Button 
                            ID="btnTaoMoi" runat="server" onclick="btnTaoMoi_Click" Text="Tạo mới (a)" />
&nbsp;
                        <asp:Button ID="btnCapNhat" runat="server" onclick="btnCapNhat_Click" 
                            Text="Cập nhật(u)" />
                    &nbsp;
                        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
                            Text="Xóa(d)" />
                    </TD>
				</TR>
    </table>
    </td>
    </tr>
    </table>
    </div>

</body>
</asp:Content>
