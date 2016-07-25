<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tinh.aspx.cs" Inherits="BanDoc_Tinh" MasterPageFile="~/MasterPage.master" %>


<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body  topmargin="0" leftmargin="0" onload="document.forms[0].ctl00$ContentPlaceHolder1$txtDescription.focus()">
		
		<table align="center" width="970px" >
		<tr>
		<td >
		  <table align="center" width="970px" >
		   <TR class="TVLibPageTitle">
					<td align="center" width="100%">
						<asp:label id="lblTitle" runat="server" Cssclass="TVLibPageTitle">Danh mục tỉnh thành</asp:label></td>
				</TR>
				<TR>
					<td align="center">
						<asp:label id="lblProvince" runat="server"><U>T</U>ỉnh: </asp:label>&nbsp;
						<asp:textbox id="txtDescription" runat="server"></asp:textbox>&nbsp;
						<asp:button id="btnAdd" runat="server" Text="Thêm(a)" Width="78px" 
                            onclick="btnAdd_Click"></asp:button></td>
				</TR>
				<TR>
					<TD>
						<asp:GridView ID="grvTinh" runat="server" AutoGenerateColumns="False" 
                            Width="100%" DataKeyNames="TinhID" 
                            onrowcancelingedit="grvTinh_RowCancelingEdit1" 
                            onrowediting="grvTinh_RowEditing1" onrowupdating="grvTinh_RowUpdating1" 
                            AllowPaging="True" onpageindexchanging="grvTinh_PageIndexChanging" 
                            PageSize="20">
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                               <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tên tỉnh (thành phố)">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvTenTinh" runat="server" Text='<%# Bind("TenTinh") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvTenTinh" runat="server" Text='<%# Bind("TenTinh") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" 
                                    CancelImageUrl="~/Resources/Images/Cancel.gif" 
                                    EditImageUrl="~/Resources/Images/Edit.gif" HeaderText="Sửa" 
                                    ShowEditButton="True" UpdateImageUrl="~/Resources/Images/update.gif" >
                                     <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:CommandField>
                                     <asp:TemplateField HeaderText="Chọn">                               
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>                               
                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="false"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </TD>
				</TR>
				<TR style ="background-color:Silver" >
					<TD align="right">
						<asp:label id="lblProvinceMerger" runat="server"><U>T</U>ỉnh: </asp:label>&nbsp;
						<asp:dropdownlist id="drdlTinh" runat="server"></asp:dropdownlist>&nbsp;
						<asp:button id="btnMerger" runat="server" Text="Gộp(g)" Width="70px" 
                            onclick="btnMerger_Click1"></asp:button></TD>
				</TR>
		    </table>
		</td>
		</tr>
		</table>
			
		
	</body>
</asp:Content>
