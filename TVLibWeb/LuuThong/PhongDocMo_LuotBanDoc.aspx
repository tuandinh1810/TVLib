<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhongDocMo_LuotBanDoc.aspx.cs" Inherits="LuuThong_PhongDocMo_LuotBanDoc" MasterPageFile="~/MasterPage.master" %>

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
            <asp:Label   ID="Label1" runat="server" Text="Ghi nhận lượt bạn đọc" 
                Width="100%"></asp:Label>
            
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
      
        <td colspan="2" align="center" >
            &nbsp;&nbsp;
            <asp:RadioButtonList ID="rdInOut" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="GioVao">Giờ vào</asp:ListItem>
                <asp:ListItem Value="GioRa">Giờ ra</asp:ListItem>
            </asp:RadioButtonList>
              </td>
        </tr>
          <tr>
      
        <td colspan="2" align="center" >
            <asp:Button ID="btnCapNhat" runat="server" onclick="btnCapNhat_Click" 
                Text="Cập nhật" />
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
           &nbsp;&nbsp; &nbsp;
           <asp:HyperLink ID="lnkSoLuot" runat="server" CssClass="TVLibLinkFunction" 
               NavigateUrl="#" Visible="False">Số lượt</asp:HyperLink>
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
    <td>
    
    <input type ="hidden" id ="hidBanDocID" runat ="server" value ="" />
      <input type ="hidden" id ="hidDKCB" runat ="server" value ="" />
    </td>
    <td colspan ="2">
    
        <asp:GridView ID="grvQuetThe" runat="server" AutoGenerateColumns="False" 
            Width="100%">
            <Columns>
                <asp:BoundField DataField="STT" HeaderText="STT" />
                <asp:BoundField DataField="Ngay" HeaderText="Ngày vào phòng đọc" />
                <asp:BoundField DataField="GioVao" HeaderText="Giờ vào" />
                <asp:BoundField DataField="GioRa" HeaderText="Giờ ra" />
            </Columns>
        </asp:GridView>
    </td>
    </tr>
    </table>    
  
    </div>

    <p>
&nbsp;</p>
</body>
</asp:Content>

