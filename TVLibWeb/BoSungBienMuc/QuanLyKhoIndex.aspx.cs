using System;
using System.Collections;
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

public partial class BoSungBienMuc_QuanLyKhoIndex : WebBase
{
    KhoInfo oKhoInfo = new KhoInfo();
    cBKho oBKho;
    cBMaXepGia oBMaXepGia;
    cBThuVien oBThuVien;
    ThuVienInfo oThuVienInfor = new ThuVienInfo();
    XepGia_LyDoThanhLyInfo pThanhLyInfo;
    cBXepGia_LyDoThanhLy oBThanhLy;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",10,") >= 0)
            BtnKiemNhan.Enabled = true;
        else
            BtnKiemNhan.Enabled = false;
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",12,") >= 0)
            btnThanhLy.Enabled = true;
        else
            btnThanhLy.Enabled = false;
        Response.Write("<Script src='../Resources/Js/TVLib.js'" + " ></Script>");
        
        oBKho = new cBKho();
        oBMaXepGia = new cBMaXepGia();
        if (!IsPostBack)
        {
            trlblXepGia.Visible = false;
            trlblTotal.Visible = false;
            trChucNang.Visible = false;
            LoadDropdownlist();
            LoadKhoByThuVien(int.Parse(DrdlThuVien.SelectedValue.ToString()));
        }

    }
    private void LoadKhoByThuVien(int intThuVienID)
    {
        DataTable dtbKho = oBKho.GetByThuVienID(intThuVienID);
        LoadDropDownList(ddlKho, dtbKho, "TenKho", "KhoID", "");
    }
    private void LoadDropdownlist()
    {
        DataTable dtbTemp;

        oBThuVien = new cBThuVien();
        oThuVienInfor.ThuVienID = 0;
        dtbTemp = oBThuVien.Get(oThuVienInfor);
        LoadDropDownList(DrdlThuVien, dtbTemp, "MaThuVien", "ThuVienID", "");
        if (DrdlThuVien.Items.Count > 0)
            DrdlThuVien.SelectedIndex = 0;

        // lay ly do thanh ly
        oBThanhLy = new cBXepGia_LyDoThanhLy();
        pThanhLyInfo = new XepGia_LyDoThanhLyInfo();
        dtbTemp = oBThanhLy.Get(pThanhLyInfo);
        LoadDropDownList(ddlLyDoLoaiBo, dtbTemp, "NoiDungLyDo", "LyDoID", "");
        if (ddlLyDoLoaiBo.Items.Count > 0)
            ddlLyDoLoaiBo.SelectedIndex = 0;
    }
    protected void DrdlThuVien_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadKhoByThuVien(int.Parse(DrdlThuVien.SelectedValue.ToString()));
    }
    protected void btnLoc_Click1(object sender, EventArgs e)
    {
        DataTable dtTemp;
        if (txtDKCB.Text.Trim() != "")
        {
            dtTemp = oBMaXepGia.GetQuanLyKho(txtDKCB.Text, 0, int.Parse(ddlChucNang.SelectedValue.ToString()));
        }
        else
            dtTemp = oBMaXepGia.GetQuanLyKho("", int.Parse(ddlKho.SelectedValue.ToString()), int.Parse(ddlChucNang.SelectedValue.ToString()));
        if (dtTemp != null)
        {
            trlblXepGia.Visible = true;
            trlblTotal.Visible = true;
            trChucNang.Visible = true;
            grvMaXepGia.DataSource = dtTemp;
            grvMaXepGia.DataBind();
            lbToltal.Text = dtTemp.Rows.Count.ToString();
            if (dtTemp.Rows.Count == 0)
            {
                trlblXepGia.Visible = false;
                trlblTotal.Visible = false;
                trChucNang.Visible = false;
                ThongBao("Không tìm thấy dữ liệu thỏa mãn yêu cầu!");
            }
        }
        else
        {
            trlblXepGia.Visible = false;
            trlblTotal.Visible = false;
            trChucNang.Visible = false;
            ThongBao("Không tìm thấy dữ liệu thỏa mãn yêu cầu!");
        }
    }
    protected void grvMaXepGia_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // kiem tra neu da kich hoat roi thi khong hien thi nut kich hoat nua
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbTrangThai = new Label();
            lbTrangThai = (Label)(e.Row.FindControl("lbTrangThai"));
            if (lbTrangThai != null)
            {
                if (e.Row.DataItem != null)
                {
                    string LuuThong = DataBinder.Eval(e.Row.DataItem, "LuuThong").ToString();
                    if (LuuThong.ToLower() == "false".ToLower())
                        lbTrangThai.Text = "<img src ='../Resources/Images/lock.gif' alt='Mã xếp giá đang bị khoá' runat ='server' />";
                    else
                    {
                        string DangMuon = DataBinder.Eval(e.Row.DataItem, "DangMuon").ToString();
                        if (DangMuon.ToLower() == "true".ToLower())
                        {
                            lbTrangThai.Text = "<img src ='../Resources/Images/loan.gif' alt='Mã xếp giá đang cho mượn' runat ='server' />";
                        }
                        else
                        {
                            string KiemNhan = DataBinder.Eval(e.Row.DataItem, "KiemNhan").ToString();
                            if (KiemNhan.ToLower() == "false".ToLower())
                                lbTrangThai.Text = "<img src ='../Resources/Images/estat2.gif' alt='Mã xếp giá chưa được kiểm nhận' runat ='server' />";
                            else
                                lbTrangThai.Text = "<img src ='../Resources/Images/available.gif' alt='Sẵn sàng phục vụ bạn đọc' runat ='server' />";
                        }
                    }
                }
            }
        }
    }
    protected void grvMaXepGia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            ((CheckBox)(e.Row.Cells[0].FindControl("cbxCheckAll"))).Attributes.Add("onclick", "_CheckAllCheckBox('grvMaXepGia','cbxDKCB',3,23);");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string DangMuon = DataBinder.Eval(e.Row.DataItem, "DangMuon").ToString();
            if (DangMuon.ToLower() == "true".ToLower())
            {
                // ẩn check để không cho người dùng Thanh lý
                CheckBox cbxDKCB = new CheckBox();
                cbxDKCB = (CheckBox)(e.Row.FindControl("cbxDKCB"));
                cbxDKCB.Visible = false;
            }
        }

    }
    protected void BtnKiemNhan_Click(object sender, EventArgs e)
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
            strID = clsCommon.Left(strID, strID.Length - 1);
            oBMaXepGia.KiemNhanMoKhoa(strID);
            ThongBao("Kiểm nhận và mở khóa thành công!");
            btnLoc_Click1(null, null);
        }
    }
    protected void grvMaXepGia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvMaXepGia.PageIndex = e.NewPageIndex;
        btnLoc_Click1(null, null);
    }
    protected void btnThanhLy_Click(object sender, EventArgs e)
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
            oBMaXepGia.ThanhLyDKCB(strID, int.Parse(ddlLyDoLoaiBo.SelectedValue == null ? "0" : ddlLyDoLoaiBo.SelectedValue.ToString()));
            ThongBao("Thanh lý thành công!");
            btnLoc_Click1(null, null);
        }
    }
    protected void btnPhucHoi_Click(object sender, EventArgs e)
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
            oBMaXepGia.PhucHoiDKCB(strID);
            ThongBao("Phục hồi thành công!");
            btnLoc_Click1(null, null);
        }
    }
}
