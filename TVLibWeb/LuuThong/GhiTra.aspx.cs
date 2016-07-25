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
using TruongViet.Lib.Web;
using TruongViet.TVLib.Business;
using TruongViet.TVLib.Entity;

public partial class LuuThong_GhiTra : WebBase 
{
    TaiLieuMuonInfo oTaiLieuMuon;
    cBTaiLieuMuon oBTaiLieuMuon;
    BanDocInfo oBanDocInfo;
    cBBanDoc oBBanDoc;
    LichSuMuonInfo oLichSuMuonInfo;
    cBLichSuMuon oBLichSuMuon;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",20,") >= 0)
        {
            oChucNang.MaChucNang = "GhiTra";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            KhoiTao();
            BindJS();
        }
        else
            Response.Redirect("../Error.aspx");
    if (!IsPostBack)
        {
            LoadKhoas();
            LoadLop();
            LoadBanDoc();
        }
    }

    private void LoadKhoas()
    {
        DataTable dtbKhoas = oBBanDoc.GetKhoas(oBanDocInfo);
        ddlKhoas.DataSource = dtbKhoas;
        ddlKhoas.DataTextField = "Khoa";
        ddlKhoas.DataValueField = "Khoa";
        ddlKhoas.DataBind();
    }

    private void LoadLop()
    {
        oBanDocInfo.Khoa = ddlKhoas.SelectedValue;
        DataTable dtbLop = oBBanDoc.GetLop(oBanDocInfo);
        ddlLop.DataSource = dtbLop;
        ddlLop.DataTextField = "Lop";
        ddlLop.DataValueField = "Lop";
        ddlLop.DataBind();
    }

    private void LoadBanDoc()
    {
        oBanDocInfo.Khoa = ddlKhoas.SelectedValue;
        oBanDocInfo.Lop = ddlLop.SelectedValue;
        DataTable dtbBanDoc = InsertOneRow(oBBanDoc.GetBanDoc(oBanDocInfo), "Chọn bạn đọc", 0, 0);
        ddlBanDoc.DataSource = dtbBanDoc;
        ddlBanDoc.DataTextField = "TenDayDu";
        ddlBanDoc.DataValueField = "BanDocID";
        ddlBanDoc.DataBind();
    }

    private void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "JSAdminCommon", "<script language='javascript' src='../Resources/JS/LuuThong.js'></script>");
        btnGhiTra.Attributes.Add("Onclick", "return CheckGhiTra();");
        btnGhiTra1.Attributes.Add("OnClick", "if(!CheckOptionsNull('ctl00_ContentPlaceHolder1_grvGhiTra', 'chkID', 2, 50, 'Bạn phải chọn ít nhất một ấn phẩm để ghi trả!')) return false;");
    }
    private void KhoiTao()
    {
        oTaiLieuMuon = new TaiLieuMuonInfo();
        oBTaiLieuMuon = new cBTaiLieuMuon();
        oLichSuMuonInfo = new LichSuMuonInfo();
        oBLichSuMuon = new cBLichSuMuon();
        oBanDocInfo = new BanDocInfo();
        oBBanDoc = new cBBanDoc();
        txtSoThe.Focus();
    }

    private void AnHienThongTinAnPham(bool visible)
    {
        lbNgayMuon.Visible = visible;
        lbNhanDe.Visible = visible;
        lbNhanDeValue.Visible = visible;
        lbNgayMuonValue.Visible = visible;
        lbNgayTra.Visible = visible;
        lbNgayTraValue.Visible = visible;
        lbMXGValue.Visible = visible;
        lbDKCB.Visible = visible;
    }

    protected void txtSoThe_TextChanged(object sender, EventArgs e)
    {
        LayThongTinBanDoc(txtDKCB.Text.Trim());
        AnHienThongTinAnPham(false);
        txtDKCB.Focus();
    }

    private void GetgrvGhiTra(string SoThe)
    {
        
       DataTable dtTemp =  oBTaiLieuMuon.GetMuonSachBySoThe(SoThe);
       oBanDocInfo = new BanDocInfo();
       oBanDocInfo.SoThe = SoThe;
       DataTable dtbThongTinBanDoc = oBBanDoc.GetBanDoc_GhiMuon(oBanDocInfo);
       if (dtbThongTinBanDoc.Rows.Count > 0)
       {
           lbHoVaTen.Text = dtbThongTinBanDoc.Rows[0]["TenDayDu"].ToString();
           lbSoThe.Text = dtbThongTinBanDoc.Rows[0]["SoThe"].ToString();
           hidBanDocID.Value = dtbThongTinBanDoc.Rows[0]["BanDocID"].ToString();
           if (dtbThongTinBanDoc.Rows[0][oBanDocInfo.strNgaySinh] != null)
           {
               lbNgaySinh.Text = DateTime.Parse(dtbThongTinBanDoc.Rows[0][oBanDocInfo.strNgaySinh].ToString()).ToString("dd/MM/yyyy");
           }
           if (dtbThongTinBanDoc.Rows[0]["AnhUrl"].ToString() != "")
               ImageButton1.ImageUrl = "~/Resources/Images/AnhThe/" + dtbThongTinBanDoc.Rows[0]["AnhUrl"].ToString();

           lbGiaTriThe.Text = DateTime.Parse(dtbThongTinBanDoc.Rows[0][oBanDocInfo.strNgayCap].ToString()).ToString("dd/MM/yyyy") + "-" + DateTime.Parse(dtbThongTinBanDoc.Rows[0][oBanDocInfo.strNgayHetHan].ToString()).ToString("dd/MM/yyyy");
           if (DateTime.Parse(dtbThongTinBanDoc.Rows[0][oBanDocInfo.strNgayHetHan].ToString()) < DateTime.Now)
           {
               lbGhiChu.Text = "Thẻ đã hết hạn sử dụng";
           }
       }
       if (dtTemp != null)
       {
           
           grvGhiTra.DataSource = dtTemp;
           grvGhiTra.DataBind();
           if (dtTemp.Rows.Count > 0)
               btnGhiTra1.Visible = true;
           else
               btnGhiTra1.Visible = false;
       }
       else
           btnGhiTra1.Visible = false;
 
    }

    private void GetgrvGhiTra(int BanDocID)
    {

        DataTable dtTemp = oBTaiLieuMuon.GetMuonSachByBanDocID(BanDocID);
        if (dtTemp != null)
        {

            grvGhiTra.DataSource = dtTemp;
            grvGhiTra.DataBind();
            if (dtTemp.Rows.Count > 0)
                btnGhiTra1.Visible = true;
            else
                btnGhiTra1.Visible = false;
        }
        else
            btnGhiTra1.Visible = false;

    }
    private void LayThongTinBanDoc(string pMaXepGia)
    {
        //oBanDocInfo.SoThe = SoThe;
        //DataTable dtTemp = oBBanDoc.GetBanDoc_GhiMuon(oBanDocInfo);
        if (txtSoThe.Text + "" != "")
        {
            GetgrvGhiTra(txtSoThe.Text.Trim());
            lnkLichSuMuon.Attributes.Add("Onclick", "javascript:OpenWindow('BanDocDaMuon.aspx?BanDocID=" + hidBanDocID.Value + "','',800,450,50,50 );");
            pnThongTinGhiMuon.Visible = true;
        }
        if (pMaXepGia + "" != "")
        {
            DataTable dtTemp = oBBanDoc.GetBanDoc_GhiMuonByMaXepGia(pMaXepGia);
            if (dtTemp != null)
            {
                if (dtTemp.Rows.Count > 0)
                {
                    txtDKCB.Focus();
                    pnThongTinGhiMuon.Visible = true;

                    // hidBanDocID.Value = dtTemp.Rows[0]["BanDocID"].ToString();
                    lbHoVaTen.Text = dtTemp.Rows[0]["TenDayDu"].ToString();
                    lbSoThe.Text = dtTemp.Rows[0]["SoThe"].ToString();
                    if (dtTemp.Rows[0][oBanDocInfo.strNgaySinh] != null)
                    {
                        lbNgaySinh.Text = DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgaySinh].ToString()).ToString("dd/MM/yyyy");
                    }
                    if (dtTemp.Rows[0]["AnhUrl"].ToString() != "")
                        ImageButton1.ImageUrl = "~/Resources/Images/AnhThe/" + dtTemp.Rows[0]["AnhUrl"].ToString();

                    lbGiaTriThe.Text = DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayCap].ToString()).ToString("dd/MM/yyyy") + "-" + DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayHetHan].ToString()).ToString("dd/MM/yyyy");
                    if (DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayHetHan].ToString()) < DateTime.Now)
                    {
                        lbGhiChu.Text = "Thẻ đã hết hạn sử dụng";
                    }
                    lnkLichSuMuon.Attributes.Add("Onclick", "javascript:OpenWindow('BanDocDaMuon.aspx?BanDocID=" + dtTemp.Rows[0]["BanDocID"].ToString() + "','',800,450,50,50 );");
                }
                else
                {
                    pnThongTinGhiMuon.Visible = false;
                    ThongBao("Đăng ký cá biệt này chưa được mượn!");
                }
                
            }
            else
            {
                pnThongTinGhiMuon.Visible = false;
                ThongBao("Đăng ký cá biệt này chưa được mượn!");
            }
        }
     
    }
    protected void btnGhiTra_Click(object sender, EventArgs e)
    {
        GhiTra(txtDKCB.Text.Trim(), 0, 0);
    }
    private void GhiTra(string MaXepGia, float TienPhat, int Type)
    {
        oTaiLieuMuon.MaXepGia = MaXepGia;
        int intKetQua = oBTaiLieuMuon.GhiTra(MaXepGia,TienPhat,Type);
        if (intKetQua == 0)
        {
            // hien thi thong tin an pham tra
            oLichSuMuonInfo.MaXepGia = MaXepGia;
           DataTable dtTaiLieu =  oBLichSuMuon.Get(oLichSuMuonInfo);
           if (dtTaiLieu.Rows.Count > 0)
           {
               pnThongTinGhiMuon.Visible = true;
               AnHienThongTinAnPham(true);
               GetgrvGhiTra(lbSoThe.Text);
               lbMXGValue.Text = dtTaiLieu.Rows[0][oLichSuMuonInfo.strMaXepGia].ToString();
               lbNgayTraValue.Text = DateTime.Parse(DateTime.Now.ToString()).ToString("dd/MM/yyyy");
               lbNgayMuonValue.Text = DateTime.Parse(dtTaiLieu.Rows[0][oLichSuMuonInfo.strNgayMuon].ToString()).ToString("dd/MM/yyyy");
               lbNhanDeValue.Text = dtTaiLieu.Rows[0]["NhanDe"].ToString();
           }
            lbError.Text = "Ghi trả thành công";
            WriteLog(lstChucNang[0].ChucNangID, "Ghi trả thành công : " + txtSoThe.Text + "; ĐKCB :" + txtDKCB.Text, Request.UserHostAddress, Session["TenDangNhap"].ToString());
            txtDKCB.Text = "";
            txtDKCB.Focus();
            //txtSoThe.Text = "";
            pnThongTinGhiMuon.Visible = true;

           // ThongBao("Ghi trả thành công!");
        }
        if (intKetQua == 1)
        {
            pnThongTinGhiMuon.Visible = false;
             lbError.Text = "Ấn phẩm không được mượn";
        }
        // an pham qua han
        if (intKetQua == 2)
        {
            lbError.Text = "Ấn phẩm đã quá hạn";
            lbThongBao.Visible = true;
            btnQuaHan.Visible = true;
            //btnThuPhi.Visible = true;
            
        }
    }
    protected void btnThuPhi_Click(object sender, EventArgs e)
    {
        //GhiTra(txtDKCB.Text.Trim(), float.Parse("0" + txtPhiMuon.Text), 1);
        txtDKCB.Text = "";
        txtSoThe.Text = "";
        txtSoThe.Focus();
        lbNgayMuon.Text = "";
        lbNhanDe.Text = "";
        lbNhanDeValue.Text = "";
        lbNgayMuonValue.Text = "";
        lbNgayTra.Text = "";
        lbNgayTraValue.Text = "";
        lbMXGValue.Text = "";
        lbDKCB.Text = "";
        lbHoVaTen.Text = "";
        lbGiaTriThe.Text = "";
        lbNgaySinh.Text = "";
        lbSoThe.Text = "";
    }
    protected void btnGhiTra1_Click(object sender, EventArgs e)
    {
        int intCount = 0;
        string MaXepGia = "";
        for (intCount = 0; intCount < grvGhiTra.Rows.Count; intCount++)
        {
            if (((CheckBox)(grvGhiTra.Rows[intCount].Cells[1].FindControl("chkID"))).Checked)
            {
                MaXepGia = ((Label)(grvGhiTra.Rows[intCount].Cells[1].FindControl("lbMaXepGia"))).Text;
                if (int.Parse(((Label)(grvGhiTra.Rows[intCount].Cells[1].FindControl("lbNgayQuaHan"))).Text) > 0)
                    oBTaiLieuMuon.GhiTra(MaXepGia, 0, 1);
                else
                    oBTaiLieuMuon.GhiTra(MaXepGia, 0, 0);
            }
            GetgrvGhiTra(((Label)(grvGhiTra.Rows[intCount].Cells[1].FindControl("lbSoThe"))).Text);
            lbError.Text = "Ghi trả thành công"; 
        }
        GetgrvGhiTra(lbSoThe.Text);
    }
    protected void btnQuaHan_Click(object sender, EventArgs e)
    {
        GhiTra(txtDKCB.Text.Trim(), 0, 1);
    }
    protected void ddlKhoas_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadLop();
        LoadBanDoc();
        LayThongTinBanDocByBanDocID();
    }
    protected void ddlLop_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadBanDoc();
        LayThongTinBanDocByBanDocID();
    }
    protected void ddlBanDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        LayThongTinBanDocByBanDocID();
    }

    private void LayThongTinBanDocByBanDocID()
    {
        int BanDocID = 0;
        if (ddlBanDoc.SelectedValue + "" != "")
            BanDocID = int.Parse(ddlBanDoc.SelectedValue);
        if (BanDocID == 0)
            return;
        LayThongTinBanDoc(BanDocID);
        AnHienThongTinAnPham(false);
    }

    private void LayThongTinBanDoc(int BanDocID)
    {
        oBanDocInfo.BanDocID = BanDocID;
        DataTable dtTemp = oBBanDoc.GetBanDoc_GhiMuon_ByBanDocID(oBanDocInfo);
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                txtDKCB.Focus();
                pnThongTinGhiMuon.Visible = true;
                GetgrvGhiTra(BanDocID);
                // hidBanDocID.Value = dtTemp.Rows[0]["BanDocID"].ToString();
                lbHoVaTen.Text = dtTemp.Rows[0]["TenDayDu"].ToString();
                lbSoThe.Text = dtTemp.Rows[0]["SoThe"].ToString();
                if (dtTemp.Rows[0][oBanDocInfo.strNgaySinh] != null)
                {
                    lbNgaySinh.Text = DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgaySinh].ToString()).ToString("dd/MM/yyyy");
                }
                if (dtTemp.Rows[0]["AnhUrl"].ToString() != "")
                    ImageButton1.ImageUrl = "~/Resources/Images/AnhThe/" + dtTemp.Rows[0]["AnhUrl"].ToString();

                lbGiaTriThe.Text = DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayCap].ToString()).ToString("dd/MM/yyyy") + "-" + DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayHetHan].ToString()).ToString("dd/MM/yyyy");
                if (DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayHetHan].ToString()) < DateTime.Now)
                {
                    lbGhiChu.Text = "Thẻ đã hết hạn sử dụng";
                }

            }
            else
            {
                pnThongTinGhiMuon.Visible = false;
                ThongBao("Không tồn tại số thẻ này!");
            }
        }
        else
        {
            pnThongTinGhiMuon.Visible = false;
            ThongBao("Không tồn tại số thẻ này!");
        }
    }
    protected void btnLamLai_Click(object sender, EventArgs e)
    {
        txtDKCB.Text = "";
        txtSoThe.Text = "";
        txtSoThe.Focus();
    }
    protected void txtDKCB_TextChanged(object sender, EventArgs e)
    {
        LayThongTinBanDoc(txtDKCB.Text.Trim());
        AnHienThongTinAnPham(true);
        // hien thi thong tin an pham tra
        oLichSuMuonInfo.MaXepGia = txtDKCB.Text;
        DataTable dtTaiLieu = oBLichSuMuon.Get(oLichSuMuonInfo);
        if (dtTaiLieu.Rows.Count > 0)
        {
            pnThongTinGhiMuon.Visible = true;
            AnHienThongTinAnPham(true);
            GetgrvGhiTra(lbSoThe.Text);
            lbMXGValue.Text = dtTaiLieu.Rows[0][oLichSuMuonInfo.strMaXepGia].ToString();
            lbNgayTraValue.Text = DateTime.Parse(DateTime.Now.ToString()).ToString("dd/MM/yyyy");
            lbNgayMuonValue.Text = DateTime.Parse(dtTaiLieu.Rows[0][oLichSuMuonInfo.strNgayMuon].ToString()).ToString("dd/MM/yyyy");
            lbNhanDeValue.Text = dtTaiLieu.Rows[0]["NhanDe"].ToString();
        }
        GetgrvGhiTra(lbSoThe.Text);
        txtDKCB.Focus();
    }
}
