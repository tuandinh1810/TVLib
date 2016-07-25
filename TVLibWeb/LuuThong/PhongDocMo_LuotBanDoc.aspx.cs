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

public partial class LuuThong_PhongDocMo_LuotBanDoc : WebBase 
{
    BanDocInfo oBanDocInfo;
    cBBanDoc oBBanDoc;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",27,") >= 0)
        {
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
            rdInOut.SelectedValue = "GioVao";
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
    private void Load_QuetTheByBanDoc()
    {
        oBBanDoc = new cBBanDoc();
        DataTable dtbQuetThe = oBBanDoc.PhongDoc_GetBySoThe_Thang(txtSoThe.Text);
        if (dtbQuetThe.Rows.Count > 0)
        {
            grvQuetThe.DataSource = dtbQuetThe;
            grvQuetThe.DataBind();
        }
        else
        {
            grvQuetThe.DataSource = null;
            grvQuetThe.DataBind();
        }

    }
    private void KhoiTao()
    {
        txtSoThe.Focus(); 
    }

    private void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "JSAdminCommon", "<script language='javascript' src='../Resources/JS/LuuThong.js'></script>");
    }
    protected void txtSoThe_TextChanged(object sender, EventArgs e)
    {
        //oBBanDoc.PhongDoc_LuongBanDoc_Add(txtSoThe.Text, DateTime.Now);
        LayThongTinBanDoc();
        Load_QuetTheByBanDoc();
    }
    
    private void LayThongTinBanDoc ()
    {
        hidDKCB.Value = "";
        Session["BanDoc"] = null;
        Session["Data"] = null;
        oBanDocInfo.SoThe = txtSoThe.Text;
      DataTable dtTemp =   oBBanDoc.GetBanDoc_GhiMuon(oBanDocInfo);
      if (dtTemp != null)
      {
          if (dtTemp.Rows.Count > 0)
          {
              Session["BanDoc"] = dtTemp;
              pnThongTinGhiMuon.Visible = true;
              hidBanDocID.Value = dtTemp.Rows[0]["BanDocID"].ToString();
              lbHoVaTen.Text = dtTemp.Rows[0]["TenDayDu"].ToString();
              lbSoThe.Text = dtTemp.Rows[0]["SoThe"].ToString();
              lbNhomBanDoc.Text = dtTemp.Rows[0]["TenNhomBanDoc"].ToString();
              lbDiaChi.Text = dtTemp.Rows[0][oBanDocInfo.strDiaChi].ToString();
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
                          lbGhiChu.Text = "Thẻ đã hết hạn sử dụng";

                      }
                      else
                          lbGhiChu.Text = "";
                  }
              }

              lnkSoLuot.Attributes.Add("Onclick", "javascript:OpenWindow('A.aspx?BanDocID=" + hidBanDocID.Value + "','',800,450,50,50 );");
          }
          else
          {
              ThongBao("Không tồn tại số thẻ này!");
              pnThongTinGhiMuon.Visible = false ;
          }
      }
      else
      {
          ThongBao("Không tồn tại số thẻ này!");
          pnThongTinGhiMuon.Visible = false ;
      }
       
    }
    private int SubDate(DateTime date1, DateTime date2)
    {
        TimeSpan subDate = date2 - date1;
        return subDate.Days;
    }

    protected void btnGhiNhan_Click(object sender, EventArgs e)
    {
        
        //if (intKetQua == 5)
        //{
        //    lbError.Visible = true;
        //    lbError.Text = "Thẻ bạn đọc đã bị khóa";
        //}
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
        Load_QuetTheByBanDoc();
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
        DataTable dtTemp = oBBanDoc.GetBanDoc_GhiMuon_ByBanDocID(oBanDocInfo);
        if (dtTemp != null)
        {
            if (dtTemp.Rows.Count > 0)
            {
                Session["BanDoc"] = dtTemp;
                pnThongTinGhiMuon.Visible = true;
                hidBanDocID.Value = dtTemp.Rows[0]["BanDocID"].ToString();
                lbHoVaTen.Text = dtTemp.Rows[0]["TenDayDu"].ToString();
                txtSoThe.Text = dtTemp.Rows[0]["SoThe"].ToString();
                lbSoThe.Text = dtTemp.Rows[0]["SoThe"].ToString();
                lbNhomBanDoc.Text = dtTemp.Rows[0]["TenNhomBanDoc"].ToString();
                lbDiaChi.Text = dtTemp.Rows[0][oBanDocInfo.strDiaChi].ToString();
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
                            lbGhiChu.Text = "Thẻ đã hết hạn sử dụng";

                        }
                        else
                            lbGhiChu.Text = "";
                    }
                }

                lnkSoLuot.Attributes.Add("Onclick", "javascript:OpenWindow('A.aspx?BanDocID=" + hidBanDocID.Value + "','',800,450,50,50 );");
            }
            else
            {
                ThongBao("Không tồn tại số thẻ này!");
                pnThongTinGhiMuon.Visible = false;
            }
        }
        else
        {
            ThongBao("Không tồn tại số thẻ này!");
            pnThongTinGhiMuon.Visible = false;
        }

    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        DataTable dtbValidate = oBBanDoc.PhongDoc_Vaildate(txtSoThe.Text, DateTime.Now);
        if (rdInOut.SelectedValue == "GioVao")
        {
            if (dtbValidate.Rows.Count == 0)
                oBBanDoc.PhongDoc_LuongBanDoc_Add(txtSoThe.Text, DateTime.Now);
            else
                ThongBao("Thẻ bạn đọc này chưa được quẹt ra");
        }
        else if(dtbValidate.Rows.Count>0)
            oBBanDoc.PhongDoc_LuongBanDoc_Update(txtSoThe.Text, DateTime.Now);
        else
            ThongBao("Thẻ bạn đọc này chưa được quẹt vào");
        
        LayThongTinBanDoc();
        Load_QuetTheByBanDoc();
    }
}
