<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Banner.ascx.cs" Inherits="Banner" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.6.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxMenu" tagprefix="dxm" %>



<body  style="margin-left:0; margin-top:-5px; margin-bottom:0; margin-right:0">
<table width="970px" align="center" cellpadding="0" cellspacing="0" align="center">
    <tr>
    <td>
        <asp:Label runat=server ID="lblImage"></asp:Label>
       
    </td>
    </tr>
    <tr>
    <td>
    
        <dxm:ASPxMenu ID="ASPxMenu1" runat="server" AutoSeparators="RootOnly" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            GutterImageSpacing="7px" ImageFolder="~/App_Themes/Aqua/{0}/" ItemSpacing="0px" 
            SeparatorColor="#AECAF0" SeparatorHeight="100%" SeparatorWidth="1px" 
            ShowPopOutImages="True" Width="970px">
            <rootitemsubmenuoffset firstitemx="-1" firstitemy="-1" x="-1" y="-1" />
            <Items>
                <dxm:MenuItem Text="Bổ sung - Biên mục" 
                    NavigateUrl="~/BoSungBienMuc/Default.aspx">
                    <Items>
                        <dxm:MenuItem Text="Biên mục" 
                            NavigateUrl="~/BoSungBienMuc/MauBienMucIndex.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem NavigateUrl="~/BoSungBienMuc/DanhSachTaiLieu.aspx" 
                            Text="Danh sách tài liệu">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="In ấn" NavigateUrl="~/BoSungBienMuc/InAn/InAnIndex.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Quản lý kho" 
                            NavigateUrl="~/BoSungBienMuc/QuanLyKhoIndex.aspx">
                        </dxm:MenuItem>                        
                        <dxm:MenuItem Text="Kiểm kê kho" 
                            NavigateUrl="~/BoSungBienMuc/KiemKe/MainIndex.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Báo cáo thống kê" 
                            NavigateUrl="~/BoSungBienMuc/BaoCaoThongKe/MainIndex.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Danh mục" 
                            NavigateUrl="~/BoSungBienMuc/DanhMuc/DanhMucIndex.aspx">
                        </dxm:MenuItem>
                         <dxm:MenuItem Text="Import Excel" 
                            NavigateUrl="~/BoSungBienMuc/UpLoadFile.aspx">
                        </dxm:MenuItem>
                    </Items>
                </dxm:MenuItem>
                <dxm:MenuItem Text="Bạn đọc" NavigateUrl="~/BanDoc/Default.aspx">
                    <Items>
                        
                        <dxm:MenuItem Text="Hồ sơ bạn đọc" NavigateUrl="~/BanDoc/HoSoBanDoc.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Quản lý bạn đọc" NavigateUrl="~/BanDoc/Default.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Báo cáo thống kê" 
                            NavigateUrl="~/BanDoc/BaoCaoThongKe/ThongKeIndex.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Danh mục" NavigateUrl="~/BanDoc/DanhMucIndex.aspx">
                        </dxm:MenuItem>
                    </Items>
                </dxm:MenuItem>
                <dxm:MenuItem Text="Lưu thông" NavigateUrl="~/LuuThong/Default.aspx">
                    <Items>
                        <dxm:MenuItem Text="Ghi mượn" NavigateUrl="~/LuuThong/GhiMuon.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem NavigateUrl="~/LuuThong/DuyetDangKyMuon.aspx" Text="Yêu Cầu Mượn">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Ghi trả" NavigateUrl="~/LuuThong/GhiTra.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Gia hạn" NavigateUrl="~/LuuThong/GiaHan.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Mẫu phiếu" NavigateUrl="~/LuuThong/MauPhieu.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Báo cáo thống kê" 
                            NavigateUrl="~/LuuThong/BaoCaoThongKe/ThongKeIndex.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem NavigateUrl="~/LuuThong/PhongDocMo_LuotBanDoc.aspx" 
                            Text="Lượt bạn đọc">
                        </dxm:MenuItem>
                    </Items>
                </dxm:MenuItem>
                <dxm:MenuItem NavigateUrl="~/AnPhamDinhKy/Default.aspx" Text="Ấn phẩm định kỳ" Visible="true">
                    <Items>
                        <dxm:MenuItem NavigateUrl="~/AnPhamDinhKy/DanhSachTaiLieu.aspx" 
                            Text="Danh sách ấn phẩm định kỳ">
                        </dxm:MenuItem>
                        <dxm:MenuItem NavigateUrl="~/AnPhamDinhKy/SoTapChi.aspx" 
                            Text="Ghi nhận số ấn phẩm">
                        </dxm:MenuItem>
                        <dxm:MenuItem NavigateUrl="~/AnPhamDinhKy/TongHop.aspx" Text="Tổng hợp">
                        </dxm:MenuItem>
                        <%--<dxm:MenuItem NavigateUrl="~/AnPhamDinhKy/DongTapTapChi.aspx" Text="Đóng tập">
                        </dxm:MenuItem>--%>
                    </Items>
                </dxm:MenuItem>
                <dxm:MenuItem Text="Tra cứu trực tuyến" NavigateUrl="http://localhost:8080/TrangChu.aspx">
                </dxm:MenuItem>
                <dxm:MenuItem Text="Quản trị hệ thống" NavigateUrl="~/QuanTriHeThong/NguoiDung.aspx">
                    <Items>
                        <dxm:MenuItem Text="Quản lý người dùng" 
                            NavigateUrl="~/QuanTriHeThong/NguoiDung.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Đặt chề độ ghi log" 
                            NavigateUrl="~/QuanTriHeThong/DatCheDoGhiLog.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Tra cứu log" NavigateUrl="~/QuanTriHeThong/TraCuuLog.aspx">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Thống kê log" Visible="False" 
                            NavigateUrl="~/QuanTriHeThong/ThongKeLog.aspx">
                        </dxm:MenuItem>
                    </Items>
                </dxm:MenuItem>
                <dxm:MenuItem NavigateUrl="logout.aspx" Text="Thoát">
                </dxm:MenuItem>
            </Items>
            <verticalpopoutimage height="11px" width="11px" />
            <ItemStyle Font-Bold="True" HorizontalAlign="Center" ImageSpacing="5px" 
                PopOutImageSpacing="18px" VerticalAlign="Middle" />
            <submenustyle backcolor="#F9F9F9" gutterwidth="0px" separatorcolor="#AECAF0">
            </submenustyle>
            <submenuitemstyle horizontalalign="Justify" imagespacing="7px">
            </submenuitemstyle>
            <border bordercolor="#AECAF0" borderstyle="Solid" borderwidth="1px"></border>
            <horizontalpopoutimage height="7px" width="7px" />
        </dxm:ASPxMenu>
    
    </td>
    </tr>
    </table>
    </body>