<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanToc.aspx.cs" Inherits="BanDoc_DanToc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body  topmargin="0" leftmargin="0" onload="document.forms[0].txtDescription.focus()">
		<form id="Form1" method="post" runat="server">
		<table align="center" width="970px" >
		<tr>
		<td >
		    <table id ="TableCenter">
		   <TR class="TVLibPageTitle">
					<td align="center" width="100%">
						<asp:label id="lblTitle" runat="server" Cssclass="TVLibPageTitle">Danh mục dân 
                        tộc</asp:label></td>
				</TR>
				<TR>
					<td align="center">
						<asp:label id="lblProvince" runat="server"><U>D</U>ân tộc: </asp:label>&nbsp;
						<asp:textbox id="txtDescription" runat="server"></asp:textbox>&nbsp;
						<asp:button id="btnAdd" runat="server" Text="Thêm(a)" Width="78px" onclick="btnAdd_Click" 
                           ></asp:button></td>
				</TR>
				<TR>
					<TD>
						<asp:GridView ID="grvDanToc" runat="server" AutoGenerateColumns="False" 
                            Width="100%" DataKeyNames="DanTocID" AllowPaging="True" 
                            onpageindexchanging="grvDanToc_PageIndexChanging" 
                            onrowcancelingedit="grvDanToc_RowCancelingEdit" 
                            onrowediting="grvDanToc_RowEditing" onrowupdating="grvDanToc_RowUpdating" PageSize="20" >
                            <PagerSettings Position="TopAndBottom" />
                            <Columns>
                               <asp:TemplateField HeaderText="STT">                           
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"> <%# Container.DataItemIndex + 1 %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="5%" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dân tộc">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtgrvDanToc" runat="server" Text='<%# Bind("DanToc") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbgrvDanToc" runat="server" Text='<%# Bind("DanToc") %>'></asp:Label>
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
						<asp:label id="lblProvinceMerger" runat="server"><U>D</U>ân tộc: </asp:label>&nbsp;
						<asp:dropdownlist id="drdlDanToc" runat="server"></asp:dropdownlist>&nbsp;
						<asp:button id="btnMerger" runat="server" Text="Gộp(g)" Width="70px" onclick="btnMerger_Click" 
                          ></asp:button></TD>
				</TR>
		    </table>
		</td>
		</tr>
		</table>
			
		</form>
	</body>
</html>
