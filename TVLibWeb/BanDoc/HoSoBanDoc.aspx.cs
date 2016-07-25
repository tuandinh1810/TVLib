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
using TruongViet.Lib.Web;

public partial class BanDoc_HoSoBanDoc : WebBase 
{

    DanTocInfo oDanTocInfo;
    cBDanToc oBDanToc;
    TrinhDoInfo oTrinhDoInfo;
    cBTrinhDo oBTrinhDo;
    NgheNghiepInfo oNgheNghiepInfo;
    cBNgheNghiep oBNgheNghiep;
    TinhInfo oTinhInfo;
    cBTinh oBTinh;
    NhomBanDocInfo oNhomBanDocInfo;
    cBNhomBanDoc oBNhomBanDoc;
    BanDocInfo oBanDocInfo;
    cBBanDoc oBBanDoc;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",16,") >= 0)
        {
            KhoiTao();
            BindJS();
            oChucNang.MaChucNang = "HoSoBanDoc";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            if (!IsPostBack)
            {
                GetData();
            }
            imgPatron.Src = "~/Resources/Images/AnhThe/" + hidImage.Value;
        }
        else
            Response.Redirect("../Error.aspx");
    }
    private void KhoiTao()
    {
        oDanTocInfo = new DanTocInfo();
        oBDanToc = new cBDanToc();
        oTrinhDoInfo = new TrinhDoInfo();
        oBTrinhDo = new cBTrinhDo();
        oNgheNghiepInfo = new NgheNghiepInfo();
        oBNgheNghiep = new cBNgheNghiep();
        oTinhInfo = new TinhInfo();
        oBTinh = new cBTinh();
        oNhomBanDocInfo = new NhomBanDocInfo();
        oBNhomBanDoc = new cBNhomBanDoc();
        oBanDocInfo = new BanDocInfo();
        oBBanDoc = new cBBanDoc();
    }

    private void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "JSAdminCommon", "<script language='javascript' src='../Resources/JS/BanDoc.js'></script>");
        btnReset.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
        btnUpdate.Attributes.Add("Onclick", "return CheckThongTinBanDoc();");
        lnkPatronImage.NavigateUrl = "javascript:OpenWindow('WUpLoad.aspx','PatronImage',340,60,50,050);";

    }

    private void GetData()
    {
        txtNgayCap.Text = DateTime.Parse(DateTime.Now.ToString()).ToString("dd/MM/yyyy");
        txtNgayHieuLuc.Text = DateTime.Parse(DateTime.Now.ToString()).ToString("dd/MM/yyyy");
        DataTable dtTemp;
        // get nghe nghiep
        oNgheNghiepInfo.NgheNghiepID = 0;
        dtTemp = oBNgheNghiep.Get(oNgheNghiepInfo);
        dtTemp = InsertOneRow(dtTemp, "-----Chọn nghề nghiệp-----", 0, 0);
        drdlNgheNghiep.DataSource = dtTemp;
        drdlNgheNghiep.DataTextField = "TenNgheNghiep";
        drdlNgheNghiep.DataValueField = "NgheNghiepID";
        drdlNgheNghiep.DataBind();
        // get dan toc
        oDanTocInfo.DanTocID = 0;
        dtTemp = oBDanToc.Get(oDanTocInfo);
        dtTemp = InsertOneRow(dtTemp, "---Chọn dân tộc---", 0, 0);
        drdlDanToc.DataSource = dtTemp;
        drdlDanToc.DataTextField = "DanToc";
        drdlDanToc.DataValueField = "DanTocID";
        drdlDanToc.DataBind();
        // get trinh do
        oTrinhDoInfo.TrinhDoID = 0;
        dtTemp = oBTrinhDo.Get(oTrinhDoInfo);
        dtTemp = InsertOneRow(dtTemp, "--------Chọn trình độ--------", 0, 0);
        drdlTrinhDo.DataSource = dtTemp;
        drdlTrinhDo.DataTextField = "TrinhDo";
        drdlTrinhDo.DataValueField = "TrinhDoID";
        drdlTrinhDo.DataBind();
        // get tinh
        oTinhInfo.TinhID = 0;
        dtTemp = oBTinh.Get(oTinhInfo);
        dtTemp = InsertOneRow(dtTemp, "-----Chọn tỉnh-----", 0, 0);
        drdlTinh.DataSource = dtTemp;
        drdlTinh.DataTextField = "TenTinh";
        drdlTinh.DataValueField = "TinhID";
        drdlTinh.DataBind();
        // get nhom ban doc
        oNhomBanDocInfo.NhomBanDocID = 0;
        dtTemp = oBNhomBanDoc.Get(oNhomBanDocInfo);
        dtTemp = InsertOneRow(dtTemp, "---Chọn nhóm bạn đọc---", 0, 0);
        drdlNhomBanDoc.DataSource = dtTemp;
        drdlNhomBanDoc.DataTextField = "TenNhomBanDoc";
        drdlNhomBanDoc.DataValueField = "NhomBanDocID";
        drdlNhomBanDoc.DataBind();
        // sua ban doc
       
       if (Request["BanDocID"] + "" != "")
        {
            btnClose.Visible = true;
            btnSearch.Visible = false;

            oBanDocInfo.BanDocID = int.Parse(Request["BanDocID"].ToString());
            dtTemp = oBBanDoc.Get(oBanDocInfo);
            txtDiaChi.Text = dtTemp.Rows[0][oBanDocInfo.strDiaChi].ToString();
            txtDienThoai.Text = dtTemp.Rows[0][oBanDocInfo.strSoDienThoai].ToString();
            txtEmail.Text = dtTemp.Rows[0][oBanDocInfo.strEmail].ToString();
            txtGhiChu.Text = dtTemp.Rows[0][oBanDocInfo.strGhiChu].ToString();
            txtKhoa.Text = dtTemp.Rows[0][oBanDocInfo.strKhoa].ToString();
            txtLop.Text = dtTemp.Rows[0][oBanDocInfo.strLop].ToString();
            txtMaVung.Text = dtTemp.Rows[0][oBanDocInfo.strMaVung].ToString();
            txtNgayCap.Text = DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayCap].ToString()).ToString("dd/MM/yyyy");
            txtNgayHetHan.Text = DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayHetHan].ToString()).ToString("dd/MM/yyyy");
            txtNgayHieuLuc.Text = DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayHieuLuc].ToString()).ToString("dd/MM/yyyy");
            txtNgaySinh.Text = DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgaySinh].ToString()).ToString("dd/MM/yyyy");
            txtNoiLamViec.Text = dtTemp.Rows[0][oBanDocInfo.strNoiLamViec].ToString();
            txtSCMT.Text = dtTemp.Rows[0][oBanDocInfo.strSoCMT].ToString();
            txtSoThe.Text = dtTemp.Rows[0][oBanDocInfo.strSoThe].ToString();
            txtThanhPho.Text = dtTemp.Rows[0][oBanDocInfo.strThanhPho].ToString();
            txtHoVaTen.Text = dtTemp.Rows[0][oBanDocInfo.strTenDayDu].ToString();
            drdlDanToc.SelectedValue = dtTemp.Rows[0][oBanDocInfo.strIDDanToc].ToString();
            drdlNgheNghiep.SelectedValue = dtTemp.Rows[0][oBanDocInfo.strIDNgheNghiep].ToString();
            drdlNhomBanDoc.SelectedValue = dtTemp.Rows[0][oBanDocInfo.strIDNhomBanDoc].ToString();
            drdlTinh.SelectedValue = dtTemp.Rows[0][oBanDocInfo.strIDTinh].ToString();
            drdlTrinhDo.SelectedValue = dtTemp.Rows[0][oBanDocInfo.strIDTrinhDo].ToString();
            hidImage.Value = dtTemp.Rows[0][oBanDocInfo.strAnhURL].ToString();
          
            if (bool.Parse (dtTemp.Rows[0][oBanDocInfo.strGioiTinh].ToString()) == true)
            {
                optNam.Checked =true;
            }
            else
            {
                optNu.Checked =true;
            }
        }
    }

    private void ResetControls()
    {
        txtDiaChi.Text = "";
        txtDienThoai.Text = "";
        txtEmail.Text = "";
        txtGhiChu.Text = "";
        txtHoVaTen.Text = "";
        txtKhoa.Text = "";
        txtLop.Text = "";
        txtMaVung.Text = "";
        txtNgayCap.Text = DateTime.Parse(DateTime.Now.ToString()).ToString("dd/MM/yyyy");
        txtNgayHieuLuc.Text = DateTime.Parse(DateTime.Now.ToString()).ToString("dd/MM/yyyy");
        txtNgayHetHan.Text = "";       
        txtNgaySinh.Text = "";
        txtNoiLamViec.Text = "";
        txtSCMT.Text = "";
        txtSoThe.Text = "";
        txtThanhPho.Text = "";
        drdlDanToc.SelectedIndex = 0;
        drdlNgheNghiep.SelectedIndex = 0;
        drdlTinh.SelectedIndex = 0;
        drdlTrinhDo.SelectedIndex = 0;
        imgPatron.Src = "";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        oBanDocInfo.DiaChi = txtDiaChi.Text;
        oBanDocInfo.AnhURL = hidImage.Value;
        oBanDocInfo.Email = txtEmail.Text;
        oBanDocInfo.GhiChu = txtGhiChu.Text;
        if (optNam.Checked == true)
        {
            oBanDocInfo.GioiTinh = true;
        }
        if (optNu.Checked == true)
        {
            oBanDocInfo.GioiTinh = false;
        }
        oBanDocInfo.IDDanToc = int.Parse(drdlDanToc.SelectedValue);
        oBanDocInfo.IDNgheNghiep = int.Parse(drdlNgheNghiep.SelectedValue);
        oBanDocInfo.IDNhomBanDoc = int.Parse(drdlNhomBanDoc.SelectedValue);
        oBanDocInfo.IDTinh = int.Parse(drdlTinh.SelectedValue);
        oBanDocInfo.IDTrinhDo = int.Parse(drdlTrinhDo.SelectedValue);
        oBanDocInfo.Khoa = txtKhoa.Text;
        oBanDocInfo.Lop = txtLop.Text;
        oBanDocInfo.MaVung = txtMaVung.Text;
        oBanDocInfo.NgayCap = TVDateTime.ChuyenVietSangAnh(txtNgayCap.Text);
        oBanDocInfo.NgayHieuLuc = TVDateTime.ChuyenVietSangAnh(txtNgayHieuLuc.Text);
        oBanDocInfo.NgayHetHan = TVDateTime.ChuyenVietSangAnh(txtNgayHetHan.Text);
        oBanDocInfo.NgaySinh = TVDateTime.ChuyenVietSangAnh(txtNgaySinh.Text);
        oBanDocInfo.NoiLamViec = txtNoiLamViec.Text;
        oBanDocInfo.SoCMT = txtSCMT.Text;
        oBanDocInfo.SoDienThoai = txtDienThoai.Text;
        oBanDocInfo.SoThe = txtSoThe.Text;
        oBanDocInfo.TenDayDu = txtHoVaTen.Text;
        oBanDocInfo.ThanhPho = txtThanhPho.Text;
        int intKetQua = 0;

        if (Request["BanDocID"] + "" != "")
        {
            oBanDocInfo.BanDocID = int.Parse(Request["BanDocID"] + "");
            intKetQua = oBBanDoc.Update(oBanDocInfo);
            if (intKetQua == 0)
            {
                WriteLog(lstChucNang[0].ChucNangID, "Sửa  bạn đọc thành công : " + oBanDocInfo.TenDayDu, Request.UserHostAddress, Session["TenDangNhap"].ToString());
                ThongBao("Cập nhật bạn đọc thành công!");
               
            }
            else
            {
                ThongBao("Số thẻ bạn đọc đã tồn tại!");
            }
        }
        else
        {
           
             intKetQua = oBBanDoc.Add(oBanDocInfo);
            if (intKetQua == 0)
            {
                WriteLog(lstChucNang[0].ChucNangID, "Thêm mới bạn đọc thành công : " + oBanDocInfo.TenDayDu, Request.UserHostAddress, Session["TenDangNhap"].ToString());
                ThongBao("Thêm mới bạn đọc thành công!");
                ResetControls();
            }
            else
            {
                ThongBao("Số thẻ bạn đọc đã tồn tại!");
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("TimKiemBanDoc.aspx");
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "CloseSelf1", "<script language='javascript' >self.close();window.opener.document.forms[0].hidEvent.value ='1'; window.opener.document.forms[0].submit();</script>");
    }
}
