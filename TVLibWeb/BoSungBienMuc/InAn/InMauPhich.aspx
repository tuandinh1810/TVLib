<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InMauPhich.aspx.cs" Inherits="BoSungBienMuc_InAn_InMauPhich" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1 >
     <script language="javascript" src="../../Resources/JS/Calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../Resources/Js/TVLib.js" type="text/javascript"></script>
    <script>
        function GenRanNum(intNumber) {
            var str = '';
            var intCount;
            for(intCount = 1; intCount<=intNumber;intCount++){ 
	            str=str + (String)(parseInt(9 * Math.random()+48));
            } 
            return(str);
        }
        
        function GenURLImg1(intNumber){
	        document.images["Image1"].src='Chart.aspx?i=1&x='+GenRanNum(intNumber);
	        //document.images["Image2"].src='WChartDir.aspx?i=2&x='+GenRanNum(intNumber);	
        }
    </script>

<body>
    <div>
    <table width="100%" align="center"  >
    <tr>
    <td>
     <table align="center" width="970px" >
                <tr class="TVLibPageTitle">
					<td class="lbPageTitle" align="left" colSpan="4"><asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Tìm kiếm tài liệu</asp:label></td>
				</tr>
				<tr>
					<td colSpan="4"></td>
				</tr>
				<TR align="center">
					<TD align="right" width="10%">
                        <asp:Label ID="lblNhanDe" runat="server" Text="Nhan Đề:"></asp:Label>
                    </TD>
					<TD align="left" width="20%">
                        <asp:TextBox ID="TxtNhanDe" runat="server" 
                            style="margin-left: 0px" Width="250px"></asp:TextBox>
                    </TD>
					<TD align="right" width="10%">
                        <asp:Label ID="lblTacGia" runat="server" Text="Tác Giả:"></asp:Label>
                    </TD>
					<TD align="left" width="30%">
                        <asp:TextBox ID="TxtTacGia" runat="server" Width="250px"></asp:TextBox>
                    </TD>
				</TR>
				<TR align="center">
					<TD align="right">
                        <asp:Label ID="lblMoTa" runat="server" Text="Tóm tắt:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="TxtMoTa" runat="server" Width="250px" TextMode="MultiLine"></asp:TextBox>
                    </TD>
					<TD align="right">
                        <asp:Label ID="lblTuKhoa" runat="server" Text="Từ Khóa:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="TxtTuKhoa" runat="server" Width="250px"></asp:TextBox>
                    </TD>
                   
				</TR>
				<TR align="center">
					<TD align="right">
                        <asp:Label ID="Label1" runat="server" Text="Mã xếp giá:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtMaXepGia" runat="server" Width="250px"></asp:TextBox>
                    </TD>
					<TD align="right">
                        <asp:Label ID="Label2" runat="server" Text="ISBN:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtChiSoISBN" runat="server" Width="250px"></asp:TextBox>
                    </TD>
                 
				</TR>
				<TR align="center">
					<TD align="right">
                        <asp:Label ID="Label3" runat="server" Text="Từ ngày biên mục:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txtFromDate" runat="server" Width="250px"></asp:TextBox>
                          <a onclick="javascript:mThoiGian.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>
                                    <script language="JavaScript">
	                              var mThoiGian	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtFromDate']);
	                              mThoiGian.year_scroll 	=	true;
	                              mThoiGian.time_comp 	=	false;	
                                  </script> 
                    </TD>
					<TD align="right">
                        <asp:Label ID="Label6" runat="server" Text="Đến ngày biên mục:"></asp:Label>
                    </TD>
					<TD align="left">
                        <asp:TextBox ID="txToDate" runat="server" Width="250px"></asp:TextBox>
                          <a onclick="javascript:mThoiGian1.popup();" href="javascript:;"><img alt="Chọn ngày lập biểu" border="0" height="16" src="../../Resources/Images/cal.gif"
                                    width="16" /></a>&nbsp;
                           <script language="JavaScript">
	                              var mThoiGian1	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txToDate']);
	                              mThoiGian1.year_scroll 	=	true;
	                              mThoiGian1.time_comp 	=	false;	
                                  </script>  
                    </TD>
                 
				</TR>
				<tr>
					<td colSpan="4" align="center">
				
				    &nbsp;</td>
				</tr>
				
					<tr style="background-color:Silver ">
				<td colSpan="4" align="center" class="style1">
				
				    <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" onclick="btnTimKiem_Click" 
                       />&nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Làm lại" 
                        onclick="btnReset_Click" />
				
				</td>
				</tr>
				<tr>
					<td colSpan="4" align="center">
				
				    &nbsp;</td>
				</tr>			
				<tr class="TVLibPageTitle" runat=server id="trlblDanhSachTaiLieu">
				<td colSpan="4" align="left" height="10" >
				
				    <asp:Label ID="Label4" runat="server" Text="Danh sách tài liệu"></asp:Label>
                    <br />
                    </td>
				</tr>
				<tr >
				<td colSpan="4" align="center">
				
				    <asp:GridView ID="grvResult" runat="server" AutoGenerateColumns="False" 
                        Width="100%" DataKeyNames="TaiLieuID" AllowPaging="True" 
                        onpageindexchanging="grvResult_PageIndexChanging" onrowdatabound="grvResult_RowDataBound" 
                      >
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
                            <asp:BoundField DataField="NhanDe" HeaderText="Tài liệu" />
                        </Columns>
                    </asp:GridView>
                    </td>
				</tr>
				
				<tr style="background-color:Silver " runat=server id="trChucNang">
				<td colspan="4" align="left" width="10%">
				    
				    <asp:Label ID="Label5" runat="server" Text="Mẫu phích" ForeColor="Black"></asp:Label>
				    
				&nbsp;<asp:DropDownList ID="drdlMauPhich" runat="server" AutoPostBack="True" 
                        >
                    </asp:DropDownList> &nbsp;
				    
				<asp:Button ID="btnInNhan" runat="server" Text="In chọn" onclick="btnInNhan_Click" 
                         />
				&nbsp;
                    <asp:Button ID="btnInAll" runat="server" Text="In tất cả" onclick="btnInAll_Click" 
                         />
				</td>
				
				</tr>
				</table>
				<input type="hidden" value="" id="hdTaiLieuID" runat="server" />
				</td>
				</tr>
				</table>
        
    </div>
    
</body></asp:Content>