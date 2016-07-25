<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GhiMuon.aspx.cs" Inherits="LuuThong_GhiMuon" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
      <script language="javascript" src="../Resources/JS/Calendar.js" type="text/javascript"></script>
</head>


<body style ="margin-top : 0" >
   
    <div>
  <table align="center" width="970px" >
    <tr>
    <td width="30%" colspan=  "2" valign ="top" >
        <table width ="100%"  >
         <tr class="TVLibPageTitle">
        <td colspan ="2" valign ="top"   >            
            <asp:Label   ID="Label1" runat="server" Text="Ghi Mượn" Width="100%"></asp:Label>
            
        </td>
        </tr>
        <tr>
            <td align ="right" >
            <asp:Label ID="Label5" runat="server" Text="&lt;u&gt;N&lt;/u&gt;gày mượn:"></asp:Label>
            	
        </td>
        <td>
            <asp:TextBox ID="txtNgayMuon" runat="server" TabIndex="1" AutoPostBack="True" 
                ontextchanged="txtNgayMuon_TextChanged" ></asp:TextBox>
            <asp:Label ID="lblSoNgayDuocMuon" runat="server" Text="30" Visible="False"></asp:Label>
            &nbsp;<a onclick="javascript:mNgayMuon.popup();" href="javascript:;"><img alt="Chọn ngày" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mNgayMuon	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtNgayMuon']);
	                  mNgayMuon.year_scroll 	=	true;
	                  mNgayMuon.time_comp 	=	false;	
                      </script> 
        </td>
        </tr>
        <tr>
        <td align ="right" colspan="2" >
            <hr width='70%' /></td>
        </tr>
        <tr>
        <td align ="right" >
            <asp:Label ID="Label21" runat="server" Text="Khóa:"></asp:Label>
            	
        </td>
        <td>
            <asp:DropDownList ID="ddlKhoas" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlKhoas_SelectedIndexChanged">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
        <td align ="right" >
            <asp:Label ID="Label22" runat="server" Text="Lớp:"></asp:Label>
            	
            </td>
        <td>
            <asp:DropDownList ID="ddlLop" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlLop_SelectedIndexChanged">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
        <td align ="right" >
            <asp:Label ID="Label23" runat="server" Text="Sinh viên:"></asp:Label>
            	
            </td>
        <td>
            <asp:DropDownList ID="ddlBanDoc" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlBanDoc_SelectedIndexChanged">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
        <td align ="right" colspan="2" >
            <hr  width='70%' /></td>
        </tr>
        <tr>
        <td align ="right" >
            <asp:Label ID="Label2" runat="server" Text="&lt;u&gt;S&lt;/u&gt;ố thẻ:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtSoThe" runat="server" TabIndex="2" AutoPostBack="True" 
                ontextchanged="txtSoThe_TextChanged"></asp:TextBox>
        </td>
        </tr>
          <tr>
        <td align ="right" >
            <asp:Label ID="Label3" runat="server" 
                Text="&lt;u&gt;M&lt;/u&gt;ã xếp giá:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDKCB" runat="server" TabIndex="3"></asp:TextBox>
        &nbsp;</td>
        </tr>
          <tr>
            <td align ="right" >
            <asp:Label ID="Label6" runat="server" Text="&lt;u&gt;N&lt;/u&gt;gày trả:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtNgayTra" runat="server" TabIndex="4"></asp:TextBox>
                  &nbsp;<a onclick="javascript:mNgayTra.popup();" href="javascript:;"><img alt="Chọn ngày" border="0" height="16" src="../Resources/Images/cal.gif"
                        width="16" /></a>
                        <script language="JavaScript">
	                  var mNgayTra	=	new calendar1(document.forms[0].elements['ctl00$ContentPlaceHolder1$txtNgayTra']);
	                  mNgayTra.year_scroll 	=	true;
	                  mNgayTra.time_comp 	=	false;	
                      </script> 
        </td>
        </tr>
        <tr>
        <td align ="right" >
            <asp:Label ID="Label14" runat="server" Text="&lt;u&gt;P&lt;/u&gt;hí mượn:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPhiMuon" runat="server">0</asp:TextBox>
        </td>
        </tr>
          <tr>
      
        <td colspan="2" align="center" >
            <asp:Button ID="btnGhiMuon" runat="server" Text="Ghi mượn(a)" AccessKey ="a" 
                TabIndex="5" onclick="btnGhiMuon_Click" style="height: 26px" 
                Width="95px" />
            &nbsp;<asp:Button ID="btnGhiPhieu" runat="server" Text="Làm lại" 
                AccessKey ="p" TabIndex="7" onclick="btnGhiPhieu_Click"/>
        </td>
        </tr>
     </table>
                        <br />
    </td>
    <td width="70%" valign ="top" >
        <asp:Panel ID ="pnThongTinGhiMuon" runat ="server" Visible="False" >
       <table width="100%">
        <tr class="TVLibPageTitle">
    <td  colspan ="3">
        <asp:Label  ID="Label4" runat="server" width="100%" 
            Text="Thông tin bạn đọc"></asp:Label>
        </td>
    </tr>
       <tr>
       <td rowspan ="7" align ="center" width="15%" >
           <asp:ImageButton ID="ImageButton1" runat="server" Height="130px" 
               ImageUrl="~/Resources/Images/AnhThe/Empty.gif" Width="95px" /><br>
               </td>
       <td align ="right" width="17%">
           <asp:Label ID="Label7" runat="server" Text="Số thẻ:"  CssClass ="TVlibLabel"></asp:Label>
       </td>
       <td>
           <asp:Label ID="lbSoThe" runat="server" CssClass="TVLibLabel" Font-Bold="True"></asp:Label>
           &nbsp;&nbsp;
           <asp:HyperLink ID="lnkDangMuon" runat="server" CssClass="TVLibLinkFunction" 
               NavigateUrl="#">Đang mượn</asp:HyperLink>
           &nbsp;
           <asp:HyperLink ID="lnkLichSuMuon" runat="server" 
               CssClass="TVLibLinkFunction" NavigateUrl="#">Lịch sử mượn</asp:HyperLink>
       </td>
       </tr>
           <tr>
       <td align ="right">
           <asp:Label ID="Label8" runat="server" Text="Họ Và tên"  CssClass ="TVlibLabel"></asp:Label>
       </td>
       <td>
           <asp:Label ID="lbHoVaTen" runat="server" CssClass="TVLibLabel" Font-Bold="True"></asp:Label>
       </td>
       </tr>
        <tr>
     
       <td align ="right">
           <asp:Label ID="Label17" runat="server" Text="Địa chỉ:"  
               CssClass ="TVlibLabel"></asp:Label>
       </td>
          <td>
              <asp:Label ID="lbDiaChi" runat="server" CssClass="TVLibLabel" 
                  Font-Bold="True"></asp:Label>
       </td>
       </tr>
        <tr>
     
       <td align ="right">
           <asp:Label ID="Label12" runat="server" Text="Nhóm bạn đọc:"  
               CssClass ="TVlibLabel"></asp:Label>
       </td>
          <td>
              <asp:Label ID="lbNhomBanDoc" runat="server" CssClass="TVLibLabel" 
                  Font-Bold="True"></asp:Label>
       </td>
       </tr>
           <tr>
      
       <td align ="right">
           <asp:Label ID="Label9" runat="server" Text="Ngày cấp thẻ:"  
               CssClass ="TVlibLabel"></asp:Label>
       </td>
          <td>
              <asp:Label ID="lbNgayCapThe" runat="server" CssClass="TVLibLabel" 
                  Font-Bold="True"></asp:Label>
       </td>
       </tr>
             
           <tr>
     
       <td align ="right">
           <asp:Label ID="Label10" runat="server" Text="Ngày hết hạn:"  
               CssClass ="TVlibLabel"></asp:Label>
       </td>
          <td>
              <asp:Label ID="lbNgayHetHan" runat="server" CssClass="TVLibLabel" 
                  Font-Bold="True"></asp:Label>
       </td>
       </tr>
           <tr>
      
       <td align ="right">
           <asp:Label ID="Label11" runat="server" Text="Ghi chú:"  CssClass ="TVlibLabel"></asp:Label>
       </td>
          <td>
              <asp:Label ID="lbGhiChu" runat="server" CssClass="TVLibLabel" Font-Bold="True" 
                  Font-Italic="True" ForeColor="Red"></asp:Label>
       </td>
       </tr>  
         <tr class ="TVLibPageTitle">
       <td  colspan ="3">
           <asp:Label ID="Label15" runat="server" CssClass="lbPageTitle" 
               Text="Thông tin hạn ngạch mượn" Width="100%"></asp:Label>
       </td>
       </tr> 
       <tr>
       <td>
           &nbsp;</td>
       <td  align ="right" >
           <asp:Label ID="Label16" runat="server" Text="Hạn ngạch:"></asp:Label>
       </td>
       <td>
           <asp:Label ID="lbHanNgach" runat="server" Font-Bold="True"></asp:Label>
       </td>
       </tr>
       <tr>
       <td>
           &nbsp;</td>
       <td  align ="right" >
           <asp:Label ID="Label18" runat="server" Text="Đang mượn:"></asp:Label>
       </td>
       <td>
           <asp:Label ID="lbDangMuon" runat="server" Font-Bold="True"></asp:Label>
       </td>
       </tr>
       <tr>
       <td>
           &nbsp;</td>
       <td align ="right" >
           <asp:Label ID="Label20" runat="server" Text="Còn được mượn:"></asp:Label>
       </td>
       <td>
           <asp:Label ID="lbConDcMuon" runat="server" Font-Bold="True"></asp:Label>
       </td>
       </tr>
                  
       <tr class ="TVLibPageTitle">
       <td  colspan ="3">
           <asp:Label ID="Label13" runat="server" CssClass="lbPageTitle" 
               Text="Danh sách ấn phẩm vừa ghi mượn" Width="100%"></asp:Label>
       </td>
       </tr>      
       <tr>
       <td colspan ="3">
           <asp:GridView ID="grvGhiMuon" runat="server" AutoGenerateColumns="False" 
               width="100%" onrowdeleting="grvGhiMuon_RowDeleting">
               <Columns>
                   <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            </asp:TemplateField>
                   <asp:BoundField DataField="NhanDe" HeaderText="Nhan đề">
                       <ItemStyle Width="30%" />
                   </asp:BoundField>
                   <asp:TemplateField HeaderText="Mã xếp giá">
                      
                       <ItemTemplate>
                           <asp:Label ID="lbMaXepGia" runat="server" Text='<%# Bind("MaXepGia") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle Width="20%" />
                   </asp:TemplateField>
                   <asp:BoundField DataField="NgayMuon" HeaderText="Ngày mượn">
                       <ItemStyle HorizontalAlign="Center" Width="10%" />
                   </asp:BoundField>
                   <asp:BoundField DataField="NgayTra" HeaderText="Ngày trả">
                       <ItemStyle HorizontalAlign="Center" Width="10%" />
                   </asp:BoundField>
                   <asp:BoundField DataField="PhiMuon" HeaderText="Phí mượn">
                       <ItemStyle HorizontalAlign="Right" Width="10%" />
                   </asp:BoundField>
                   <asp:TemplateField HeaderText="Thu hồi" ShowHeader="False">
                       <ItemTemplate>
                           <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                             OnClientClick ="return confirm('Bạn có chắc chắn muốn thu hồi sách!');"   CommandName="Delete" ImageUrl="~/Resources/Images/delete.gif" Text="Delete" />
                       </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" Width="10%" />
                   </asp:TemplateField>
               </Columns>
           </asp:GridView>
       </td>
       </tr>
       <tr>
       <td colspan ="3">
       
           <asp:Label ID="lbError" runat="server" Font-Bold="True" ForeColor="Red" 
               Visible="False"></asp:Label>
       
       </td>
       </tr>
       </table>
    </asp:Panel>
    </td>
    </tr>
    <tr >
    <td colspan ="3">
    
    <input type ="hidden" id ="hidBanDocID" runat ="server" value ="" />
      <input type ="hidden" id ="hidDKCB" runat ="server" value ="" />
    </td>
    </tr>
    </table>    
  
    </div>

    <p>
&nbsp;</p>
</body>
</asp:Content>

