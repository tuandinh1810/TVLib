<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaoCaoTheoNamBoSung.aspx.cs" Inherits="BoSungBienMuc_BaoCaoThongKe_BaoCaoTheoNamBoSung" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID=ContentPlaceHolder1 runat=server>
<body>
    
      <div>
     <table id="Table1" width="970px" align="center"  >
        <tr class ="TVLibPageTitle" >
            <td colspan ="4" class="style1">
            <asp:Label ID="Label2" Text="Báo cáo số lượng tài liệu trong kho" 
                    Width="100%" runat="server" ></asp:Label>
            </td>
            </tr>
				<TR align="center">
					<TD align="right" >
                        <asp:Label ID="Label3" runat="server" Text="Bổ sung từ năm"></asp:Label>
                    </TD>
					<TD align="left" width="20%" id="txtTuNam">
                        &nbsp;
                                  
                        <asp:TextBox ID="txtTuNam" runat="server"></asp:TextBox>
                                  
                    </TD>
					<TD align="left" width="10%">
                        <asp:Label ID="Label4" runat="server" Text="Đến năm"></asp:Label>
                    </TD>
					<TD align="left">
                        &nbsp;
                              
                        <asp:TextBox ID="txtDenNam" runat="server"></asp:TextBox>
                                  
                    &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnLoc" runat="server" onclick="btnLoc_Click" Text="Lọc" />
                                  
                    &nbsp;
                        <asp:Button ID="btnXuatExcel" runat="server" onclick="btnXuatExcel_Click" 
                            Text="Xuất excel" />
                                  
                    </TD>
                   
				</TR>
				<TR align="center" >
					<TD align="right">
                        &nbsp;</TD>
					<TD align="left">
                        &nbsp;</TD>
					<TD align="right">
                        &nbsp;</TD>
					<TD align="right" >
                    &nbsp;
                        <asp:Label ID="lblTongSo" runat="server" Font-Bold="True"></asp:Label>
                        </TD>
                 
				</TR>
				 <tr>
         <td colspan=4>
             <asp:GridView ID="grvTaiLieu" runat="server" AutoGenerateColumns="False" 
                 Width="100%">
             </asp:GridView>
         </td>
         </tr>
         <tr>
         <td colspan=4 align=center>
                        &nbsp;</td>
         </tr>
         <tr>
         <td colspan=4>
             &nbsp;</td>
         </tr>
   </table> 
    </div>
    </form>
</body>
</asp:Content>