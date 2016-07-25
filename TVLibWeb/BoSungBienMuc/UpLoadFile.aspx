<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpLoadFile.aspx.cs" Inherits="BoSungBienMuc_DownloadFile" MasterPageFile="~/MasterPage.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
         <table>
        <tr>
            <td>Chọn file</td>
            <td><asp:FileUpload ID="FileUpload_Doc" runat="server" /></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:LinkButton ID="btnUpDoc" runat="server" ToolTip="Thêm mới" OnClick="btnUpDoc_Click">Thêm mới</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
