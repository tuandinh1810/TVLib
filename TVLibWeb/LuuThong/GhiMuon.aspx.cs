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

public partial class LuuThong_GhiMuon : WebBase 
{
    TaiLieuMuonInfo oTaiLieuMuon;
    cBTaiLieuMuon oBTaiLieuMuon;
    BanDocInfo oBanDocInfo;
    cBBanDoc oBBanDoc;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",19,") >= 0)
        {
            oTaiLieuMuon = new TaiLieuMuonInfo();
            oBTaiLieuMuon = new cBTaiLieuMuon();
            oBanDocInfo = new BanDocInfo();
            oBBanDoc = new cBBanDoc();
            oChucNang.MaChucNang = "GhiMuon";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            if (!IsPostBack)
                KhoiTao();
            BindJS();
            TuDongMoThe();
        }
        else
        {
            Response.Redirect("../Error.aspx");
        } 
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

    private void TuDongMoThe()
    {
        oBBanDoc.MoKhoa();
    }

    private void KhoiTao()
    {
        txtSoThe.Focus(); 
        txtNgayMuon.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtNgayTra.Text = DateTime.Now.AddDays(int.Parse(lblSoNgayDuocMuon.Text)).ToString("dd/MM/yyyy");
    }

    private void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "JSAdminCommon", "<script language='javascript' src='../Resources/JS/LuuThong.js'></script>");
        btnGhiMuon.Attributes.Add("Onclick","return CheckGhiMuon();");
        //btnGhiPhieu.Attributes.Add("Onclick","javascript:OpenWindow('InPhieu.aspx?LoaiPhieu=1','InPhieu',850,600,50,25);");
    }
    protected void txtSoThe_TextChanged(object sender, EventArgs e)
    {
        LayThongTinBanDoc();
    }
    private void LayThongTinGhiMuon()
    {
        grvGhiMuon.Visible = true;
        DataTable dtTemp = new DataTable();
        if (hidDKCB.Value.IndexOf(",") == 0)
        {
            hidDKCB.Value = hidDKCB.Value.Substring(1, hidDKCB.Value.Length - 1);
        }
        dtTemp = oBTaiLieuMuon.GetByChuoiMaXepGia(hidDKCB.Value);
        if (dtTemp != null)
        {
            grvGhiMuon.DataSource = dtTemp;
            grvGhiMuon.DataBind();
        }
        Session["Data"] = dtTemp;
    }
    private void LayThongTinBanDoc ()
    {
        hidDKCB.Value = "";
        Session["BanDoc"] = null;
        Session["Data"] = null;
        oBanDocInfo.SoThe = txtSoThe.Text;
        grvGhiMuon.Visible = false;
      DataTable dtTemp =   oBBanDoc.GetBanDoc_GhiMuon(oBanDocInfo);
      if (dtTemp != null)
      {
          if (dtTemp.Rows.Count > 0)
          {
              Session["BanDoc"] = dtTemp;
              btnGhiMuon.Enabled = true;
              txtDKCB.Focus();
              pnThongTinGhiMuon.Visible = true;
              hidBanDocID.Value = dtTemp.Rows[0]["BanDocID"].ToString();
              lbHoVaTen.Text = dtTemp.Rows[0]["TenDayDu"].ToString();
              lbSoThe.Text = dtTemp.Rows[0]["SoThe"].ToString();
              lbNhomBanDoc.Text = dtTemp.Rows[0]["TenNhomBanDoc"].ToString();
              lbDiaChi.Text = dtTemp.Rows[0][oBanDocInfo.strDiaChi].ToString();
              lbHanNgach.Text = dtTemp.Rows[0]["SoSachMuon"].ToString();
              lbDangMuon.Text = dtTemp.Rows[0]["SoSachDangMuon"].ToString();
              lbConDcMuon.Text = (int.Parse(dtTemp.Rows[0]["SoSachMuon"].ToString()) - int.Parse(dtTemp.Rows[0]["SoSachDangMuon"].ToString())).ToString();
              if (dtTemp.Rows[0]["AnhUrl"].ToString() !="")
                  ImageButton1.ImageUrl = "~/Resources/Images/AnhThe/" + dtTemp.Rows[0]["AnhUrl"].ToString();

              if (dtTemp.Rows[0][oBanDocInfo.strNgayCap] != null )
                  {
                      lbNgayCapThe.Text =  DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayCap].ToString()).ToString("dd/MM/yyyy");
                  }
              // kiem tra the dang bi khoa
              if (dtTemp.Rows[0]["KhoaThe"].ToString().ToLower() == "true".ToLower())
              {
                  lbGhiChu.Text = "Thẻ đang bị khoá không thể sử dụng";
              }
              else
              {
                  // kiem tra the het han
                  if (dtTemp.Rows[0][oBanDocInfo.strNgayHetHan] != null)
                  {

                      lbNgayHetHan.Text = DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayHetHan].ToString()).ToString("dd/MM/yyyy");
                      if (DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayHetHan].ToString()) < DateTime.Now)
                      {
                          btnGhiMuon.Enabled = false;
                          lbGhiChu.Text = "Thẻ đã hết hạn sử dụng";

                      }
                      else
                          lbGhiChu.Text = "";
                  }
              }

              lnkLichSuMuon.Attributes.Add("Onclick", "javascript:OpenWindow('BanDocDaMuon.aspx?BanDocID=" + hidBanDocID.Value + "','',800,450,50,50 );");
              lnkDangMuon.Attributes.Add("Onclick", "javascript:OpenWindow('BanDoc_DangMuon.aspx?BanDocID=" + hidBanDocID.Value + "','',800,450,50,50 );");
          }
          else
          {
              ThongBao("Không tồn tại số thẻ này!");
              btnGhiMuon.Enabled = false;
              pnThongTinGhiMuon.Visible = false ;
          }
      }
      else
      {
          ThongBao("Không tồn tại số thẻ này!");
          btnGhiMuon.Enabled = false;
          pnThongTinGhiMuon.Visible = false ;
      }
       
    }
    private int SubDate(DateTime date1, DateTime date2)
    {
        TimeSpan subDate = date2 - date1;
        return subDate.Days;
    }

    protected void btnGhiMuon_Click(object sender, EventArgs e)
    {

        oTaiLieuMuon.IDBanDoc = int.Parse(hidBanDocID.Value);
        oTaiLieuMuon.MaXepGia = txtDKCB.Text;
        oTaiLieuMuon.NgayMuon = TVDateTime.ChuyenVietSangAnh( txtNgayMuon.Text);
        oTaiLieuMuon.NgayPhaiTra = TVDateTime.ChuyenVietSangAnh(txtNgayTra.Text);
        oTaiLieuMuon.PhiMuon =  int.Parse (txtPhiMuon.Text);
        int intSoNgay = SubDate(TVDateTime.ChuyenVietSangAnh(txtNgayMuon.Text), TVDateTime.ChuyenVietSangAnh(txtNgayTra.Text));
        int intKetQua = oBTaiLieuMuon.Add(oTaiLieuMuon);
        if (intKetQua == 0)
        {
            // check han ngach
            lbDangMuon.Text = (int.Parse (lbDangMuon.Text) + 1).ToString();
            lbConDcMuon.Text = (int.Parse(lbConDcMuon.Text) - 1).ToString();
            if (lbConDcMuon.Text == "0")
            {
                btnGhiMuon.Enabled = false ;
            }
            else
            {
                btnGhiMuon.Enabled = true;
            }
            hidDKCB.Value = hidDKCB.Value + ",'" +txtDKCB.Text + "'";
            WriteLog(lstChucNang[0].ChucNangID, "Ghi muợn thành công : " + txtSoThe.Text + "; ĐKCB :" + txtDKCB.Text, Request.UserHostAddress, Session["TenDangNhap"].ToString());
            txtDKCB.Text = "";
            txtDKCB.Focus();
            lbError.Visible = false;
            LayThongTinGhiMuon();
            
        }
        if (intKetQua == 1)
        {
            txtDKCB.Focus();
            lbError.Visible = true;
            lbError.Text = "Không tồn tại đăng ký cá biệt này";
        }
        if (intKetQua == 2)
        {
            lbError.Visible = true;
            lbError.Text = "Đăng ký cá biệt chưa được lưu thông";
            
        }
        if (intKetQua == 3)
        {
            lbError.Visible = true;
            lbError.Text = "Đăng ký cá biệt đang cho mượn";
           
        }
        if (intKetQua == 4)
        {
            lbError.Visible = true;
            lbError.Text = "Số sách mượn đã vượt quá hạn ngạch - Bạn đọc không thể tiếp tục mượn";

        }
        if (intKetQua == 5)
        {
            lbError.Visible = true;
            lbError.Text = "Thẻ bạn đọc đã bị khóa";
        }
        //if (grvGhiMuon.Rows.Count > 0)
        //    btnGhiPhieu.Visible = true;
    }
    protected void grvGhiMuon_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        oTaiLieuMuon.MaXepGia = ((Label)(grvGhiMuon.Rows[e.RowIndex].FindControl("lbMaXepGia"))).Text;
        oBTaiLieuMuon.Delete(oTaiLieuMuon);
        ThongBao("Thu hồi thành công!");
    }

    protected void btnGhiPhieu_Click(object sender, EventArgs e)
    {
        txtDKCB.Text = "";
        txtSoThe.Text = "";
        txtSoThe.Focus();
    }
    protected void txtNgayMuon_TextChanged(object sender, EventArgs e)
    {
        txtNgayTra.Text = TVDateTime.ChuyenVietSangAnh(txtNgayMuon.Text).AddDays(int.Parse(lblSoNgayDuocMuon.Text)).ToString("dd/MM/yyyy");
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
        hidDKCB.Value = "";
        Session["BanDoc"] = null;
        Session["Data"] = null;
        oBanDocInfo.BanDocID = BanDocID;
        grvGhiMuon.Visible = false;
        DataTable dtTemp = oBBanDoc.GetBanDoc_GhiMuon_ByBanDocID(oBanDocInfo);
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                Session["BanDoc"] = dtTemp;
                btnGhiMuon.Enabled = true;
                txtDKCB.Focus();
                pnThongTinGhiMuon.Visible = true;
                hidBanDocID.Value = dtTemp.Rows[0]["BanDocID"].ToString();
                lbHoVaTen.Text = dtTemp.Rows[0]["TenDayDu"].ToString();
                txtSoThe.Text = dtTemp.Rows[0]["SoThe"].ToString();
                lbSoThe.Text = dtTemp.Rows[0]["SoThe"].ToString();
                lbNhomBanDoc.Text = dtTemp.Rows[0]["TenNhomBanDoc"].ToString();
                lbDiaChi.Text = dtTemp.Rows[0][oBanDocInfo.strDiaChi].ToString();
                lbHanNgach.Text = dtTemp.Rows[0]["SoSachMuon"].ToString();
                lbDangMuon.Text = dtTemp.Rows[0]["SoSachDangMuon"].ToString();
                lbConDcMuon.Text = (int.Parse(dtTemp.Rows[0]["SoSachMuon"].ToString()) - int.Parse(dtTemp.Rows[0]["SoSachDangMuon"].ToString())).ToString();
                if (dtTemp.Rows[0]["AnhUrl"].ToString() != "")
                    ImageButton1.ImageUrl = "~/Resources/Images/AnhThe/" + dtTemp.Rows[0]["AnhUrl"].ToString();

                if (dtTemp.Rows[0][oBanDocInfo.strNgayCap] != null)
                {
                    lbNgayCapThe.Text = DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayCap].ToString()).ToString("dd/MM/yyyy");
                }
                // kiem tra the dang bi khoa
                if (dtTemp.Rows[0]["KhoaThe"].ToString().ToLower() == "true".ToLower())
                {
                    lbGhiChu.Text = "Thẻ đang bị khoá không thể sử dụng";
                }
                else
                {
                    // kiem tra the het han
                    if (dtTemp.Rows[0][oBanDocInfo.strNgayHetHan] != null)
                    {

                        lbNgayHetHan.Text = DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayHetHan].ToString()).ToString("dd/MM/yyyy");
                        if (DateTime.Parse(dtTemp.Rows[0][oBanDocInfo.strNgayHetHan].ToString()) < DateTime.Now)
                        {
                            btnGhiMuon.Enabled = false;
                            lbGhiChu.Text = "Thẻ đã hết hạn sử dụng";

                        }
                        else
                            lbGhiChu.Text = "";
                    }
                }

                lnkLichSuMuon.Attributes.Add("Onclick", "javascript:OpenWindow('BanDocDaMuon.aspx?BanDocID=" + hidBanDocID.Value + "','',800,450,50,50 );");
                lnkDangMuon.Attributes.Add("Onclick", "javascript:OpenWindow('BanDoc_DangMuon.aspx?BanDocID=" + hidBanDocID.Value + "','',800,450,50,50 );");
            }
            else
            {
                ThongBao("Không tồn tại số thẻ này!");
                btnGhiMuon.Enabled = false;
                pnThongTinGhiMuon.Visible = false;
            }
        }
        else
        {
            ThongBao("Không tồn tại số thẻ này!");
            btnGhiMuon.Enabled = false;
            pnThongTinGhiMuon.Visible = false;
        }

    }
}
