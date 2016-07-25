using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using TruongViet.TVLib.Business;
using TruongViet.TVLib.Entity;

public partial class DongTapTapChi : WebBase 
{
    cBLoaiTaiLieu oBLoaiTaiLieu;
    TaiLieuInfo oTaiLieuInfo = new TaiLieuInfo();
    cBTaiLieu oBTaiLieu;
    KhoInfo oKhoInfo = new KhoInfo();
    cBKho oBKho;
    cBMaXepGia oBMaXepGia;
    cBThuVien oBThuVien;
    ThuVienInfo oThuVienInfor = new ThuVienInfo();
    MaXepGiaInfo oMaXepGiaInfo = new MaXepGiaInfo();
    XepGia_LyDoThanhLyInfo pThanhLyInfo;
    cBXepGia_LyDoThanhLy oBThanhLy;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindJS();
        oChucNang.MaChucNang = "XepGia";
        lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
        if (Request["IDTaiLieu"] + "" == "")
        {
            Response.Write("<HTML></HTML>");
            Response.End();
        }
        oBLoaiTaiLieu = new cBLoaiTaiLieu();
        oBTaiLieu = new cBTaiLieu();
        oBKho = new cBKho();
        oBMaXepGia = new cBMaXepGia();
        if (!IsPostBack)
        {
            LoadThuVien();
            LoadKhoByThuVien(int.Parse(DrdlThuVien.SelectedValue.ToString()));
            LoadTaiLieu();
            LoadMaXepGia();
        }
    }
    private void BindJS()
    {
        Response.Write("<Script src='../Resources/Js/TVLib.js'" + " ></Script>");
        lnkQuanLyTaiLieu.NavigateUrl = "DanhSachTaiLieu.aspx?IDLoaiTaiLieu=" + Request["IDLoaiTaiLieu"];
        // 
        //btnInMaVach.Attributes.Add("onclick", "javascript:OpenWindow('InAn/popupBarcodes.aspx?TaiLieuID=" + Request["IDTaiLieu"].ToString() + "','BienMuc123',850,600,50,25)");
        //btnInNhanGay.Attributes.Add("onclick", "javascript:OpenWindow('InAn/popupInNhanGay.aspx?TaiLieuID=" + Request["IDTaiLieu"].ToString() + "','NhanGay',950,600,50,25)");
   
    }
    private void LoadTaiLieu()    
    {
        oTaiLieuInfo.TaiLieuID = int.Parse(Request["IDTaiLieu"] + "");
        DataTable dtbTaiLieu = oBTaiLieu.Get(oTaiLieuInfo);
        lblTenTaiLieu.Text = dtbTaiLieu.Rows[0]["NhanDe"].ToString();
    }

    private void LoadKhoByThuVien(int intThuVienID)
    {
        DataTable dtbKho = oBKho.GetByThuVienID(intThuVienID);
        LoadDropDownList(ddlKho, dtbKho, "TenKho", "KhoID", "");
    }
    private void LoadThuVien()
    {
        oBThuVien = new cBThuVien();
        oThuVienInfor.ThuVienID = 0;
        DataTable dtbThuVien = oBThuVien.Get(oThuVienInfor);
        LoadDropDownList(DrdlThuVien, dtbThuVien, "MaThuVien","ThuVienID" ,"");
        DrdlThuVien.SelectedIndex = 0;
        // load ly do thanh ly
        oBThanhLy = new cBXepGia_LyDoThanhLy();
        pThanhLyInfo = new XepGia_LyDoThanhLyInfo();
        DataTable dtbTemp = oBThanhLy.Get(pThanhLyInfo);
        LoadDropDownList(DrdlLyDoLoaiBo, dtbTemp, "NoiDungLyDo", "LyDoID", "");
        if (DrdlLyDoLoaiBo.Items.Count > 0)
            DrdlLyDoLoaiBo.SelectedIndex = 0;
    }

    private void LoadLoaiTaiLieu()
    {
        LoaiTaiLieuInfo oLoaiTaiLieuInfo = new LoaiTaiLieuInfo();
    }

    private void LoadMaXepGia()
    {
        int intIDTaiLieu = int.Parse(Request["IDTaiLieu"]);
        DataTable dtbMaXepGia=oBMaXepGia.Get_MaXepGiaInfo_ByIDTaiLieu(intIDTaiLieu);
        if (dtbMaXepGia.Rows.Count > 0)
        {
            grvMaXepGia.DataSource = dtbMaXepGia;
            grvMaXepGia.DataBind();
        }
        else
        {
            grvMaXepGia.DataSource = null;
            grvMaXepGia.DataBind();
        }
    }

    protected void grvMaXepGia_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        oMaXepGiaInfo.ID =int.Parse(grvMaXepGia.DataKeys[e.RowIndex][0].ToString());
        oBMaXepGia.Delete(oMaXepGiaInfo);
        LoadMaXepGia();
    }
    protected void grvMaXepGia_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[6].Controls.Count > 0) ((ImageButton)e.Row.Cells[6].FindControl("btnXoa")).Attributes.Add("onclick", "dtgSwapBG(this,'lightcoral');if (confirm('Bạn chắc chắn muốn xóa mã xếp giá này?')==false) {dtgSwapBG(this,'lightcoral');return false};");
        }
    }

    protected void grvMaXepGia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvMaXepGia.PageIndex = e.NewPageIndex;
        LoadMaXepGia();
    }

    protected void grvMaXepGia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[4].Text.IndexOf("box closed.ico") > 0)
                e.Row.Cells[4].Text = "<img src='../Resources/Images/box closed.ico' alt='Chưa kiểm nhận' >";
            else if(e.Row.Cells[4].Text.IndexOf("Lock.ico")>0)
                e.Row.Cells[4].Text = "<img src='../Resources/Images/Lock.ico' alt='Đang bị khóa'>";
            else if(e.Row.Cells[4].Text.IndexOf("People.ico") > 0)
                e.Row.Cells[4].Text = "<img src='../Resources/Images/People.ico' alt='Đang cho mượn'>";
            else if (e.Row.Cells[4].Text.IndexOf("available.gif") > 0)
                e.Row.Cells[4].Text = "<img src='../Resources/Images/available.gif' alt='Sẵn sàng lưu thông'>";
            
        }
        else if(e.Row.RowType==DataControlRowType.Header)
            ((CheckBox)(e.Row.Cells[0].FindControl("cbxCheckAll"))).Attributes.Add("onclick", "_CheckAllCheckBox('grvMaXepGia','cbxDKCB',1,10);");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string KiemNhan = DataBinder.Eval(e.Row.DataItem, "KiemNhan").ToString();
            if (KiemNhan.ToLower() == "true".ToLower())
            {
                // ẩn check để không cho người dùng kiểm nhận mở khóa và xóa
                ImageButton imgXoa = new ImageButton();
                imgXoa = (ImageButton)(e.Row.FindControl("btnXoa"));
                imgXoa.Visible = false;
            }
        }
        
    }
    protected void btnXepGia_Click(object sender, EventArgs e)
    {
        if (ddlKho.SelectedValue + "" != "" && txtSoLuong.Text.Trim() !="")
        {
            oMaXepGiaInfo.IDKho = int.Parse(ddlKho.SelectedValue.ToString());
            oMaXepGiaInfo.IDTaiLieu = int.Parse(Request["IDTaiLieu"].ToString());
            oMaXepGiaInfo.LuuThong = false;
            oMaXepGiaInfo.DangMuon = false;
            oMaXepGiaInfo.Shelf = txtMaGia.Text;
            oMaXepGiaInfo.KiemNhan = false;
            oBMaXepGia.Add_MaXepGia(oMaXepGiaInfo, txtMaXepGia.Text, int.Parse(txtSoLuong.Text));
            WriteLog(lstChucNang[0].ChucNangID, "Xếp giá thành công", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        }
        else
        {
            ThongBao("Bạn chưa chọn kho");
        }

        LoadMaXepGia();

    }
    protected void grvMaXepGia_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DrdlThuVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadKhoByThuVien(int.Parse(DrdlThuVien.SelectedValue.ToString()));
    }
    protected void BtnSinhTuDong_Click(object sender, EventArgs e)
    {
        if (ddlKho.SelectedValue + "" != "")
        {
            txtMaXepGia.Text = oBMaXepGia.SinhMaXepGia(int.Parse(ddlKho.SelectedValue.ToString()));
        }
        else
        {
            ThongBao("Bạn chưa chọn kho");
        }
       
    }
    protected void grvMaXepGia_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvMaXepGia.EditIndex = e.NewEditIndex;
        LoadMaXepGia();
        DropDownList DrdlKho = (DropDownList)grvMaXepGia.Rows[e.NewEditIndex].Cells[2].FindControl("DrdlKho");
        oKhoInfo.KhoID = 0;
        DataTable dtbKho = oBKho.Get(oKhoInfo);
        DrdlKho.DataSource = dtbKho;
        DrdlKho.DataTextField = "TenKho";
        DrdlKho.DataValueField = "KhoID";
        DrdlKho.DataBind();

        DrdlKho.SelectedValue = grvMaXepGia.DataKeys[e.NewEditIndex][1].ToString();
    }
    protected void grvMaXepGia_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        oMaXepGiaInfo.ID = int.Parse(grvMaXepGia.DataKeys[e.RowIndex][0].ToString());
        oMaXepGiaInfo.MaXepGia = ((TextBox)grvMaXepGia.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        oMaXepGiaInfo.IDKho = int.Parse(((DropDownList)grvMaXepGia.Rows[e.RowIndex].Cells[2].FindControl("DrdlKho")).SelectedValue.ToString());
        oMaXepGiaInfo.Shelf = ((TextBox)grvMaXepGia.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        if (!oBMaXepGia.Update(oMaXepGiaInfo))
        {
            ThongBao("Mã xếp giá đã tồn tại");
        }
        else
            WriteLog(lstChucNang[0].ChucNangID, "Sửa đăng ký cá biệt thành công ", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        grvMaXepGia.EditIndex = -1;
        LoadMaXepGia();
    }
    protected void grvMaXepGia_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvMaXepGia.EditIndex = -1;
        LoadMaXepGia();
    }
    protected void BtnKiemNhan_Click(object sender, EventArgs e)
    {
        string strID = "";
        for (int i = 0; i < grvMaXepGia.Rows.Count;i++ )
        {
            if (((CheckBox)grvMaXepGia.Rows[i].Cells[0].FindControl("cbxDKCB")).Checked)
            {
                strID = strID + grvMaXepGia.DataKeys[i][0].ToString() +",";
            }
        }
        if(strID!="")
        {
            strID = clsCommon.Left(strID, strID.Length - 1);
            oBMaXepGia.KiemNhanMoKhoa(strID);
            LoadMaXepGia();
        }

    }
    protected void btnLoaiBo_Click(object sender, EventArgs e)
    {
        string strID = "";
        for (int i = 0; i < grvMaXepGia.Rows.Count; i++)
        {
            if (((CheckBox)grvMaXepGia.Rows[i].Cells[0].FindControl("cbxDKCB")).Checked)
            {
                strID = strID + grvMaXepGia.DataKeys[i][0].ToString() + ",";
            }
        }
        if (strID != "")
        {
            //strID = clsCommon.Left(strID, strID.Length - 1);
            oBMaXepGia.ThanhLyDKCB(strID, int.Parse(DrdlLyDoLoaiBo.SelectedValue == null ? "0" : DrdlLyDoLoaiBo.SelectedValue.ToString()));
            ThongBao("Thanh lý thành công!");
            LoadMaXepGia();
        }
    }
    protected void btnInMaVach_Click(object sender, EventArgs e)
    {

    }
}
