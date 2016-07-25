<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GhiTra.aspx.cs" Inherits="LuuThong_GhiTra" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat=server ContentPlaceHolderID=ContentPlaceHolder1>
    <body style ="margin-top : 0" >

    <div>
    <table align="center" width="970px" >
    <tr>
    <td width="35%" colspan=  "2" valign ="top" >
        <table width ="100%" >
         <tr  class="TVLibPageTitle">
        <td colspan ="2">
            
            <asp:Label ID="Label1" runat="server" Text="Ghi trả" 
                Width="100%" ></asp:Label>
            
        </td>
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
                Text=" &lt;u&gt;M&lt;/u&gt;ã xếp giá:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDKCB" runat="server" TabIndex="3" AutoPostBack="True" 
                ontextchanged="txtDKCB_TextChanged"></asp:TextBox>
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
            <td align ="right" >
                &nbsp;</td>
        <td>
            <asp:Button ID="btnGhiTra" runat="server" Text="Ghi trả(a)" AccessKey ="a" 
                TabIndex="5" onclick="btnGhiTra_Click" />
        &nbsp;</td>
        </tr>
        <tr>
       <td colspan ="2">
           <asp:Label ID="lbThongBao" runat="server" 
               
               
               Text="Trả sách quá hạn nhấn &quot;GhiTra&quot; dưới đây để tiến hành trả sách hoặc &quot;ThuPhi&quot; để tiến hành thu phí phạt của bạn đọc" 
               Visible="False"></asp:Label>
           </label>
           
           
       </td>
       
              </tr>
              <tr>
              <td>
           <asp:Button ID="btnQuaHan" runat="server" Text="GhiTra" 
               Visible="False" onclick="btnQuaHan_Click" />   
              </td>
              <td>
              <asp:Button ID="btnThuPhi" runat="server" Text="Làm lại" 
               onclick="btnThuPhi_Click" />
              </td>
              </tr>
        </table>
    </td>
    <td width="75%" valign ="top" >
     <asp:Label ID="lbError" runat="server" Font-Bold="False" Font-Italic="False" 
            Cssclass="TVLibPageTitle" Width="100%"></asp:Label>
       <asp:Panel ID ="pnThongTinGhiMuon" runat ="server" Visible="False" >
       <table width="100%">    
         <tr class ="TVLibPageTitle">
       <td colspan ="3">
            
           <asp:Label ID="Label15" runat="server" Text="Thông tin bạn đọc" Width="100%"></asp:Label>
            
       </td>
       </tr>
       <tr>
       <td colspan ="3">
       </td>
       </tr>
       
       <tr>
       <td rowspan ="5" align ="center" width="15%" >
          <asp:ImageButton ID="ImageButton1" runat="server" Height="130px" 
               ImageUrl="~/Resources/Images/AnhThe/Empty.gif" Width="95px" /><br>
               </td>
       <td align ="right" width="15%">
           <asp:Label ID="Label7" runat="server" Text="Số thẻ:"  CssClass ="TVlibLabel"></asp:Label>
       </td>
       <td>
           <asp:Label ID="lbSoThe" runat="server" Font-Bold="True"></asp:Label>
           <asp:HyperLink ID="lnkLichSuMuon" runat="server" CssClass="TVLibLinkFunction" 
               NavigateUrl="#">Lịch sử mượn</asp:HyperLink>
       </td>
       </tr>
           <tr>
       <td align ="right">
           <asp:Label ID="Label8" runat="server" Text="Họ Và tên"  CssClass ="TVlibLabel"></asp:Label>
       </td>
       <td>
           <asp:Label ID="lbHoVaTen" runat="server" Font-Bold="True"></asp:Label>
       </td>
       </tr>
           <tr>
      
       <td align ="right">
           <asp:Label ID="Label18" runat="server" Text="Ngày sinh:"></asp:Label>
               </td>
          <td>
              <asp:Label ID="lbNgaySinh" runat="server" Font-Bold="True"></asp:Label>
               </td>
       </tr>
         <tr>
       <td align ="right" >
            
           <asp:Label ID="Label17" runat="server" Text="Giá trị thẻ:"></asp:Label>
            
       </td>
        <td >
            
            <asp:Label ID="lbGiaTriThe" runat="server" Font-Bold="True"></asp:Label>
            
       </td>
       </tr>
       <tr>
       <td>
       </td>
       <td>
           <asp:Label ID="lbGhiChu" runat="server" Font-Bold="True" Font-Italic="True" 
               ForeColor="Red"></asp:Label>
       </td>
       <td>
       </td>
       </tr>
        
       <tr class ="TVLibPageTitle">
       <td  colspan ="3">
           <asp:Label ID="lbAnPham" runat="server" Text="Thông tin ấn phẩm" Width="100%"></asp:Label>
           </td>
       </tr>
       <tr>
       <td>
       </td>
       <td align ="right" >
           <asp:Label ID="lbNhanDe" runat="server" Text="Nhan đề:"></asp:Label>
           </td>
       <td>
           <asp:Label ID="lbNhanDeValue" runat="server"></asp:Label>
           </td>
       </tr>
        <tr>
       <td>
       </td>
       <td align ="right">
           <asp:Label ID="lbDKCB" runat="server" Text="Mã xếp giá:"></asp:Label>
            </td>
       <td>
           <asp:Label ID="lbMXGValue" runat="server"></asp:Label>
            </td>
       </tr>
        <tr>
       <td>
       </td>
       <td align ="right">
           <asp:Label ID="lbNgayMuon" runat="server" Text="Ngày mượn:"></asp:Label>
            </td>
       <td>
           <asp:Label ID="lbNgayMuonValue" runat="server"></asp:Label>
            </td>
       </tr>
        <tr>
       <td>
       </td>
       <td align ="right">
           <asp:Label ID="lbNgayTra" runat="server" Text="Ngày trả:"></asp:Label>
            </td>
       <td>
           <asp:Label ID="lbNgayTraValue" runat="server"></asp:Label>
            </td>
       </tr>
       <tr class ="TVLibPageTitle">
       <td  colspan ="3">
           <asp:Label ID="Label4" runat="server" Text="Bạn đọc đang mượn các ấn phẩm" 
               Width="100%"></asp:Label>
           </td>
       </tr>
       <tr>
       <td colspan ="3">
           <asp:GridView ID="grvGhiTra" runat="server" AutoGenerateColumns="False" width="100%">
               <Columns>
                    <asp:TemplateField>
                     <HeaderTemplate>
							<input class="lbCheckBox" type="checkbox" id="chkCheckAll" onclick="javascript: CheckAllOptionsVisible('grvGhiTra', 'chkID', 2, 50);">
						</HeaderTemplate>
						<ItemTemplate>
								<asp:CheckBox id="chkID" Runat="server">
								</asp:CheckBox>
						</ItemTemplate>
                      <ItemStyle Width="5%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nhan đề">
                        <ItemTemplate>
                            <asp:Label ID="lbNhanDe" runat="server" Text='<%# Bind("NhanDe") %>'></asp:Label>
                        </ItemTemplate>                       
                        <ItemStyle Width="30%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mã xếp giá">
                        <ItemTemplate>
                            <asp:Label ID="lbMaXepGia" runat="server" Text='<%# Bind("MaXepGia") %>'></asp:Label>
                        </ItemTemplate>
                      
                        <ItemStyle Width="20%" />
                    </asp:TemplateField>
                   <asp:BoundField DataField="MaXepGia" HeaderText="Mã xếp giá">
                       <ItemStyle Width="20%" />
                   </asp:BoundField>
                   <asp:BoundField DataField="NgayTra" HeaderText="Ngày phải trả">
                       <ItemStyle HorizontalAlign="Center" Width="10%" />
                   </asp:BoundField>
                    <asp:TemplateField HeaderText="Ngày quá hạn">
                        <ItemTemplate>
                            <asp:Label ID="lbNgayQuaHan" runat="server" Text='<%# Bind("NgayQuaHan") %>'></asp:Label>
                        </ItemTemplate>
                       <ItemStyle HorizontalAlign="Right" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SoThe" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbSoThe" runat="server" Text='<%# Bind("SoThe") %>'></asp:Label>
                        </ItemTemplate>
                       
                    </asp:TemplateField>
               </Columns>
           </asp:GridView>
       </td>
       </tr>
       <tr style="background-color:Silver ">
       <td>
           <asp:Button ID="btnGhiTra1" runat="server" Text="Ghi trả" 
               onclick="btnGhiTra1_Click" />
       </td>
       <td>
       </td>
       <td>
           &nbsp;</td>
       </tr>
       </table>
    </asp:Panel>
    </td>
    </tr>
    </table>    
<input type ="hidden" id ="hidBanDocID" runat ="server" value ="" />  
    </div>
    
</body>
</asp:Content>
