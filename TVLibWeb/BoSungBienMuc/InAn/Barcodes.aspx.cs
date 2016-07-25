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

public partial class BoSungBienMuc_InAn_Barcodes : WebBase
{
    cBThuVien oBThuVien;
    ThuVienInfo oThuVienInfor;
    cBKho oBKho;
    cBMaXepGia oBMaXepGia;
    cBChucNang oBChucNang = new cBChucNang();
    ChucNangInfo oChucNang = new ChucNangInfo();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",7,") >= 0)
        {
            oBThuVien = new cBThuVien();
            oThuVienInfor = new ThuVienInfo();
            oBKho = new cBKho();
            oBMaXepGia = new cBMaXepGia();
            BindJS();
            oChucNang.MaChucNang = "InMaVach";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            if (!IsPostBack)
            {
                oThuVienInfor.ThuVienID = 0;
                ddlLibrary.DataSource = InsertOneRow(oBThuVien.Get(oThuVienInfor), "-- Chọn thư viện --", 0, 0);
                ddlLibrary.DataTextField = "MaThuVien";
                ddlLibrary.DataValueField = "ThuVienID";
                ddlLibrary.DataBind();
                LoadKhoByThuVien(0);
                if (Request["TaiLieuID"] + "" != "")
                {
                    DataTable dtTemp = oBMaXepGia.GetByTaiLieu(int.Parse(Request["TaiLieuID"].ToString()));
                    rdbMaXepGia.Checked = true;
                    if (dtTemp.Rows.Count >= 2)
                    {
                        txtFromDKCB.Text = dtTemp.Rows[0]["MaXepGia"].ToString();
                        txtToDKCB.Text = dtTemp.Rows[dtTemp.Rows.Count - 1]["MaXepGia"].ToString();
                    }
                    else if (dtTemp.Rows.Count == 1)
                    {
                        txtFromDKCB.Text = txtToDKCB.Text = dtTemp.Rows[0]["MaXepGia"].ToString();
                    }
                }
            }
        }
        else
            Response.Redirect("Error.aspx");
       
    }
    private void BindJS()
    {
        Response.Write("<Script src='../../Resources/Js/TVLib.js'" + " ></Script>");
        lnkTimTaiLieu.Attributes.Add("onclick", "javascript:OpenWindow('TimKiemTaiLieu.aspx','TKTL',850,600,50,25)");
    }
    private void LoadKhoByThuVien(int intThuVienID)
    {
        ddlStore.DataSource = InsertOneRow(oBKho.GetByThuVienID(intThuVienID), "---- Chọn kho ----", 0, 0);
        ddlStore.DataTextField = "TenKho";
        ddlStore.DataValueField = "KhoID";
        ddlStore.DataBind();  
      
    }
    protected void btnBarCode_Click(object sender, EventArgs e)
    {
        oBMaXepGia = new cBMaXepGia();
        string ChuoiMaXG = "";
        string MaTaiLieu = "";
        DateTime dtTuNgay, dtDenNgay;
        dtTuNgay = DateTime.Parse("1/1/1900");
        dtDenNgay = DateTime.Parse("1/1/1900");

        if (rdbMaXepGia.Checked)
        {
            if (txtFromDKCB.Text.Trim() != "" && txtToDKCB.Text.Trim() != "")
            {
                try
                {
                    // in theo ma xep gia
                    string strFromDKCB = txtFromDKCB.Text.Trim();
                    string strToDKCB = txtToDKCB.Text.Trim();
                    double dbKyTuSoTu = 0, dbKyTuSoToi = 0;
                    string strKyTuSoTu = oBMaXepGia.GetNumber(ref strFromDKCB);
                    string strKyTuSoToi = oBMaXepGia.GetNumber(ref strToDKCB);
                    string strKyTu = txtFromDKCB.Text.Trim().Substring(0, txtFromDKCB.Text.Trim().Length-strKyTuSoTu.Length);
                    if (strKyTuSoTu != "")
                    {
                        dbKyTuSoTu = double.Parse(strKyTuSoTu);
                        if (strKyTuSoToi != "")
                        {
                            dbKyTuSoToi = double.Parse(strKyTuSoToi);
                        }
                        else
                            ChuoiMaXG = txtFromDKCB.Text.Trim();
                    }
                    else
                    {
                        if (strKyTuSoToi != "")
                        {
                            ChuoiMaXG = txtToDKCB.Text.Trim();
                        }

                    }
                    if (strKyTuSoTu != "" && strKyTuSoToi != "")
                    {
                        for (double i = dbKyTuSoTu; i <= dbKyTuSoToi; i++)
                        {
                            ChuoiMaXG += "'" + strKyTu + i.ToString() + "',";
                        }
                    }
                }
                catch (Exception exp)
                {
                    ThongBao(exp.Message);
                }
            }
            else
            {
                ThongBao("Bạn chưa điền mã xếp giá!");
                return;
            }
        }
        else if (rdbMaTaiLieu.Checked)
        {
            // in theo ma tai lieu
            if (txtMaTaiLieu.Text.Trim() != "")
                MaTaiLieu = txtMaTaiLieu.Text.Trim();
            else
            {
                ThongBao("Bạn chưa điền mã tài liệu!");
                return;
            }
        }
        else
        {
            // in theo ngay xep gia

            if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
            {
                dtTuNgay = TVDateTime.ChuyenVietSangAnh(txtFromDate.Text.Trim());
                dtDenNgay = TVDateTime.ChuyenVietSangAnh(txtToDate.Text.Trim());
            }
            else
            {
                ThongBao("Bạn chưa điền thời gian hợp lý!");
                return;
            }
        }
        if (ChuoiMaXG != "")
            ChuoiMaXG = ChuoiMaXG.Substring(0, ChuoiMaXG.Length - 1);
        DataTable dtDuLieu = oBMaXepGia.Get_InMaVach(int.Parse(ddlLibrary.SelectedValue.ToString()), int.Parse(ddlStore.SelectedValue.ToString()), ChuoiMaXG, MaTaiLieu, dtTuNgay, dtDenNgay);
        if (dtDuLieu != null && dtDuLieu.Rows.Count > 0)
        {
            ChuoiMaXG = "";
            for (int i = 0; i < dtDuLieu.Rows.Count; i++)
            {
                ChuoiMaXG += dtDuLieu.Rows[i]["MaXepGia"] + ",";
            }
            Session["ChuoiMaXG"] = ChuoiMaXG.Substring(0, ChuoiMaXG.Length - 1);
            Session["KieuBarcode"] = ddlType.SelectedValue.ToString();
        }
        else
        {
            Session["ChuoiMaXG"] = null;
            Session["KieuBarcode"] = null;
            ThongBao("Không tìm thấy dữ liệu để in!");
            return;
        }

        ClientScript.RegisterClientScriptBlock(GetType(), "WBarCodePrintJs", "<script language='javascript'>OpenWindow('BarcodesPrint.aspx','BarcodesPrint',950,600,50,25);void(0);//document.location.href='BarcodesPrint.aspx';void(0);</script>");
        WriteLog(lstChucNang[0].ChucNangID, "In mã vạch", Request.UserHostAddress, Session["TenDangNhap"].ToString());
    }
    protected void ddlLibrary_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadKhoByThuVien(int.Parse(ddlLibrary.SelectedValue.ToString()));
    }
}
