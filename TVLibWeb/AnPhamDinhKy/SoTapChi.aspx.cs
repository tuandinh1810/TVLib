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

public partial class SoTapChi : WebBase 
{
    cBLoaiTaiLieu oBLoaiTaiLieu;
    TaiLieuInfo oTaiLieuInfo = new TaiLieuInfo();
    cBTaiLieu oBTaiLieu;
    KhoInfo oKhoInfo = new KhoInfo();
    cBKho oBKho;
    cBSoTapChi oBSoTapChi;
    cBThuVien oBThuVien;
    ThuVienInfo oThuVienInfor = new ThuVienInfo();
    SoTapChiInfo oSoTapChiInfo = new SoTapChiInfo();
    XepGia_LyDoThanhLyInfo pThanhLyInfo;
    cBXepGia_LyDoThanhLy oBThanhLy;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",26,") < 0)
        {
            Response.Redirect("Error.aspx");
            return;
        }
        if (Session["IDTaiLieu"] + "" == "" && Request["IDTaiLieu"] + "" == "")
        {
            Response.Redirect("DanhSachTaiLieu.aspx");
            return;
        }
        if (Request["IDTaiLieu"] + "" != "")
            Session["IDTaiLieu"] = Request["IDTaiLieu"] + "";

        BindJS();
        oChucNang.MaChucNang = "XepGia";
        lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
        if (Session["IDTaiLieu"] + "" == "")
        {
            Response.Write("<HTML></HTML>");
            Response.End();
        }
        oBLoaiTaiLieu = new cBLoaiTaiLieu();
        oBTaiLieu = new cBTaiLieu();
        oBKho = new cBKho();
        oBSoTapChi = new cBSoTapChi();
        if (!IsPostBack)
        {
            LoadTaiLieu();
            txtNamPhatHanh.Text = DateTime.Now.Year.ToString();
            LoadSoTapChi();
        }
    }
    private void BindJS()
    {
        Response.Write("<Script src='../Resources/Js/TVLib.js'" + " ></Script>");
    }
    private void LoadTaiLieu()    
    {
        if (Session["IDTaiLieu"] + "" == "")
            return;
        oTaiLieuInfo.TaiLieuID = int.Parse(Session["IDTaiLieu"] + "");
        DataTable dtbTaiLieu = oBTaiLieu.Get(oTaiLieuInfo);
        lblTenTaiLieu.Text = dtbTaiLieu.Rows[0]["NhanDe"].ToString();
        
    }

    private void LoadSoTapChi()
    {
        if (Session["IDTaiLieu"] + "" == "")
            return;
        int intIDTaiLieu = int.Parse(Session["IDTaiLieu"]+"");
       // int NamPhatHanh = -1;
       // NamPhatHanh = int.Parse("0" + txtNamPhatHanh.Text);
        DataTable dtbSoTapChi=oBSoTapChi.GetByTaiLieuID_NamPhatHanh(intIDTaiLieu);
        if (dtbSoTapChi.Rows.Count > 0)
        {
            grvSoTapChi.DataSource = dtbSoTapChi;
            grvSoTapChi.DataBind();
        }
        else
        {
            grvSoTapChi.DataSource = null;
            grvSoTapChi.DataBind();
        }
    }

    protected void grvSoTapChi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        oSoTapChiInfo.SoTapChiID =int.Parse(grvSoTapChi.DataKeys[e.RowIndex][0].ToString());
        oBSoTapChi.Delete(oSoTapChiInfo);
        LoadSoTapChi();
    }

    protected void grvSoTapChi_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Controls.Count > 0) ((ImageButton)e.Row.Cells[5].FindControl("btnXoa")).Attributes.Add("onclick", "dtgSwapBG(this,'lightcoral');if (confirm('Bạn chắc chắn muốn xóa mã xếp giá này?')==false) {dtgSwapBG(this,'lightcoral');return false};");
        }
    }

    protected void grvSoTapChi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSoTapChi.PageIndex = e.NewPageIndex;
        LoadSoTapChi();
    }

    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        oSoTapChiInfo.IDTaiLieu = int.Parse(Session["IDTaiLieu"]+"");
        oSoTapChiInfo.NamPhatHanh = txtNamPhatHanh.Text;
        oSoTapChiInfo.SoTheoNam = txtSoTheoNam.Text;
        oSoTapChiInfo.SoToanCuc = txtSoToanCuc.Text;
        oSoTapChiInfo.NgayPhatHanh = ChuyenVietSangAnh("");
        oSoTapChiInfo.DonGia = double.Parse("0" + txtDonGia.Text);
        oSoTapChiInfo.GhiChu = txtGhiChu.Text;
        oSoTapChiInfo.TomTat = txtTomTat.Text;
        if (Session["SoTapChiID"] + "" != "")
        {
            oBSoTapChi.Update(oSoTapChiInfo);
        }
        else
        {
            oBSoTapChi.Add(oSoTapChiInfo);
        }
        //WriteLog(lstChucNang[0].ChucNangID, "Xếp giá thành công", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        LoadSoTapChi();
    }
    protected void grvSoTapChi_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadThongTinSoTapChi();
    }

    private void LoadThongTinSoTapChi()
    {
        int SoTapChiID   = int.Parse(grvSoTapChi.SelectedDataKey[0].ToString());
        oSoTapChiInfo.SoTapChiID = SoTapChiID;
        Response.Write(SoTapChiID);
        DataTable dtbSoTapChi = oBSoTapChi.Get(oSoTapChiInfo);
        if (dtbSoTapChi.Rows.Count <= 0)
            return;
        txtSoTheoNam.Text = dtbSoTapChi.Rows[0]["SoTheoNam"] + "";
        txtSoToanCuc.Text = dtbSoTapChi.Rows[0]["SoToanCuc"] + "";
        //txtNgayPhatHanh.Text = dtbSoTapChi.Rows[0]["_NgayPhatHanh"] + "";
        txtDonGia.Text = dtbSoTapChi.Rows[0]["DonGia"] + "";
        txtGhiChu.Text = dtbSoTapChi.Rows[0]["GhiChu"] + "";
        txtTomTat.Text = dtbSoTapChi.Rows[0]["TomTat"] + "";
    }
    protected void txtNamPhatHanh_TextChanged(object sender, EventArgs e)
    {
        LoadSoTapChi();
    }
}
