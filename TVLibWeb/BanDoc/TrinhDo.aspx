<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrinhDo.aspx.cs" Inherits="BanDoc_TrinhDo" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat=server ContentPlaceHolderID=ContentPlaceHolder1>
<body  topmargin="0" leftmargin="0" onload="document.forms[0].ctl00$ContentPlaceHolder1$txtDescription.focus()">
		<table align="center" width="970px" >
		<tr>
		<td >
		    <table id ="TableCenter">
		   <TR class="TVLibPageTitle">
					<td align="center" width="100%">
						<asp:label id="lblTitle" runat="server" Cssclass="TVLibPageTitle">Danh mục trình 
                        độ</asp:label></td>
				</TR>
				<TR>
					<td align="center">
						<asp:label id="lblTrinhDo" runat="server"><U>T</U>rình độ: </asp:label>&nbsp;
						<asp:textbox id="txtDescription" runat="server"></asp:textbox>&nbsp;
						<asp:button id="btnAdd" runat="server" Text="Thêm(a)" Width="78px" onclick="btnAdd_Click" 
                           ></asp:button></td>
				</TR>
				<TR>
					<TD>
						<asp:GridView ID="grvTrinhDo" runat="server" AutoGenerateColumns="False" 
                            Width="100%" DataKeyNames="TrinhDoID" AllowPaging="True" 
                            onpageindexchanging="grvTrinhDo_PageIndexChanging" 
                            onrowcancelingedit="grvTrinhDo_RowCancelingEdit" 
                            onrowediting="grvTrinhDo_RowEditing" onrowupdating="grvTrinhDo_RowUpdating" PageSize="20" >
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                               <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Trình độ">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvTrinhDo" runat="server" Text='<%# Bind("TrinhDo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvTrinhDo" runat="server" Text='<%# Bind("TrinhDo") %>'></asp:Label>
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
						<asp:label id="lblProvinceMerger" runat="server"><U>T</U>rình độ: </asp:label>&nbsp;
						<asp:dropdownlist id="drdlTrinhDo" runat="server"></asp:dropdownlist>&nbsp;
						<asp:button id="btnMerger" runat="server" Text="Gộp(g)" Width="70px" onclick="btnMerger_Click" 
                          ></asp:button></TD>
				</TR>
		    </table>
		</td>
		</tr>
		</table>
			
		
	</body>
</asp:Content>
		


