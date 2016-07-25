<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BienMucMarc.aspx.cs" Inherits="BoSungBienMuc_BienMucMarc" %>

<%@ Register src="../Banner.ascx" tagname="Banner" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BIEN MUC TAI LIEU</title>
      <script>
          function XuLyPhimBam(name, e) {
             
              if (e.keyCode == 13) {
                  
                  //eval('document.forms[0].txb' + name).value = ' ';
                  UpdateRecord(name);
                  AddNewRecord(name, 'document.forms[0].nr' + name + '1', 'document.forms[0].nr' + name + '2');
                  return false;
              }
          }
          function Right(str, n) {
              if (n <= 0)
                  return "";
              else if (n > String(str).length)
                  return str;
              else {
                  var iLen = String(str).length;
                  return String(str).substring(iLen, iLen - n);
              }
          }

          function ChuyenTextBox(name, e) {
              if (e.keyCode == 9) {
                  if (eval(name) + 1 == 4) {
                      if (eval('document.forms[0].txb16')) {
                          eval('document.forms[0].txb16').focus();
                          return false;
                      }
                  }
                  else if (eval(name) + 1 == 17) {
                      if (eval('document.forms[0].txb04')) {
                          eval('document.forms[0].txb04').focus();
                          return false;
                      }
                  }
                  else {
                      if (eval('document.forms[0].txb' + Right('0' + (eval(name) + 1), 2))) {
                          eval('document.forms[0].txb' + Right('0' + (eval(name) + 1), 2)).focus();
                          return false;
                      }
                  }
              }
          }
          function ChuyenButtonCapNhat(e) {
              if (e.keyCode == 9) {
                  eval('document.forms[0].btnUpdate').focus();
                  return false;
              }
          }
          function InitValue() {
              if (document.forms[0].txb08.value == '') {
                  document.forms[0].txb08.value = 'G';
                  UpdateRecord('08');
              }
              if (document.forms[0].txb14.value == '') {
                  document.forms[0].txb14.value = 'Thư viện trường CĐ Công nghệ Việt Hàn Bắc Giang';
                  UpdateRecord('14');
              }
          }
    </script>
</head>
<body  style="margin-left:0; margin-top:0; margin-bottom:0; margin-right:0">
    <form id="form1" runat="server">
    
    <div>
    <table  width="970px" align="center" >
    <tr>
    <td>
        <uc1:Banner ID="Banner1" runat="server" />
    </td>
    </tr>
    <tr>
    <td>
    <table width="100%"  cellpadding="0" cellspacing="0" align="center" >
    <tr class="TVLibPageTitle">
    <td width="500px" align=left><asp:Label runat="server" ID="lbltitle" Text="Biên mục tài liệu"></asp:Label></td>
    <td align="right" >
        <asp:HyperLink ID="lnkDanhSachTaiLieu" runat="server" 
    NavigateUrl="DanhSachTaiLieu.aspx"><Font Color='Blue'>>> DANH SÁCH TÀI LIỆU</Font></asp:HyperLink>
        </td>
    </tr>
    <TR style="margin-left:20px">
        
					<TD align="left" colspan="2" >
						<asp:table id="tblDetail"  Width="100%" Runat="server" BorderWidth="0" CellSpacing="5" CellPadding="1"></asp:table></TD>
				</TR>
				<TR style="background-color:silver">
					<TD align="center" colspan="2" ><asp:button id="btnUpdate" runat="server" Height="24px" 
                            Text="Cập nhật(u)" Width="90px" onclick="btnUpdate_Click"></asp:button>&nbsp;
						<asp:button 
                            id="btnQuayVe" runat="server" Height="24px" Text="Quay về(v)" Width="75px" 
                            onclick="btnDelete_Click"></asp:button>&nbsp;<asp:label id="lblJS" runat="server" Width="0"></asp:label>
                            <input id="hidIsLoad" type="hidden" value="0" runat="server"/>
                              <input id="hdMaTaiLieu" type="hidden" value="" runat="server"/>
			<input id="updatehid" name="updatehid" runat="server" value="0" type="hidden"/>
                            <asp:dropdownlist id="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Bạn đang ở bản ghi đầu tiên</asp:ListItem>
				<asp:ListItem Value="1">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
				<asp:ListItem Value="2">Chuyển về bản ghi đầu tiên</asp:ListItem>
				<asp:ListItem Value="3">Chuyển về bản ghi trước</asp:ListItem>
				<asp:ListItem Value="4">Chuyển đến bản ghi tiếp</asp:ListItem>
				<asp:ListItem Value="5">Chuyển đến bản ghi cuối</asp:ListItem>
				<asp:ListItem Value="6">Tạo bản ghi mới</asp:ListItem>
				<asp:ListItem Value="7">Xoá bản ghi hiện hành</asp:ListItem>
				<asp:ListItem Value="8">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="9">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="10">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="11">Cập nhật thành công!</asp:ListItem>
				<asp:ListItem Value="12">Bạn chưa nhập thông tin biên mục nào !</asp:ListItem>
				<asp:ListItem Value="13">Bạn có chắc chắn xoá thông tin biên mục không?</asp:ListItem>
				<asp:ListItem Value="14">Biên mục ấn phẩm điện tử</asp:ListItem>
			</asp:dropdownlist>
                            </TD>
				</TR>
    </table>
    </td>
    </tr>
    </table>
    </div>
     
	</form>		 
   
</body>


			
</html>
