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

public partial class BanDoc_NhomBanDoc : WebBase 
{
    NhomBanDocInfo oNhomBanDocInfo;
    cBNhomBanDoc oBNhomBanDoc;
    KhoInfo oKhoInfo;
    cBKho oBKho;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",22,") >= 0)
        {
            oKhoInfo = new KhoInfo();
            oBKho = new cBKho();
            oNhomBanDocInfo = new NhomBanDocInfo();
            oBNhomBanDoc = new cBNhomBanDoc();
            BindJS();
            oChucNang.MaChucNang = "QuanLyDanhMuc_BanDoc";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            if (!IsPostBack)
            {
                GetNhomBanDoc();
                GetKho();
            }
        }
        else
            Response.Redirect("../Error.aspx");
    }
    private void GetNhomBanDoc()
    {
        oNhomBanDocInfo.NhomBanDocID = 0;
       DataTable dtTemp =  oBNhomBanDoc.Get(oNhomBanDocInfo);
       dtTemp = InsertOneRow(dtTemp, "------Thêm mới------", 0, 0);
       drdlNhomBanDoc.DataSource = dtTemp;
       drdlNhomBanDoc.DataTextField = "TenNhomBanDoc";
       drdlNhomBanDoc.DataValueField = "NhomBanDocID";
       drdlNhomBanDoc.DataBind();
       drdlNhomBanDoc.SelectedIndex = 0;
    }
    private void GetKho()
    {
        // do du lieu kho vao
        oKhoInfo.KhoID = 0;
        DataTable dtKho = oBKho.Get(oKhoInfo);
        if (dtKho != null)
        {
            lstKho.DataSource = dtKho;
            lstKho.DataTextField = "MaKho";
            lstKho.DataValueField = "KhoID";
            lstKho.DataBind();
            lstKhoBanDoc.Items.Clear();
        }
    }
    private void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "JSAdminCommon", "<script language='javascript' src='../Resources/JS/BanDoc.js'></script>");
        btnUpdate.Attributes.Add("OnClick", "return CheckAddNhomBanDoc();");
        btnAdd.Attributes.Add("OnClick", "javascript:AddItem();return(false);");
        btnRemove.Attributes.Add("OnClick","javascript:RemoveItem();return(false);");
    }
    protected void drdlNhomBanDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drdlNhomBanDoc.SelectedValue != "0")
        {
            GetKho();
            oNhomBanDocInfo.NhomBanDocID = int.Parse(drdlNhomBanDoc.SelectedValue);
            DataTable dtTemp = oBNhomBanDoc.Get(oNhomBanDocInfo);
            if (dtTemp != null)
            {
                if (dtTemp.Rows.Count > 0)
                {
                    txtNhomBanDoc.Text = dtTemp.Rows[0][oNhomBanDocInfo.strTenNhomBanDoc].ToString();
                    txtSoSachMuonTaiCho.Text = dtTemp.Rows[0][oNhomBanDocInfo.strSoSachDatCho].ToString();
                    txtSoSachMuonVe.Text = dtTemp.Rows[0][oNhomBanDocInfo.strSoSachMuon].ToString();
                    drdlCapDoMat.SelectedIndex = int.Parse(dtTemp.Rows[0][oNhomBanDocInfo.strCapDoMat].ToString());
                    string ChuoiIDKho = dtTemp.Rows[0][oNhomBanDocInfo.strCacKhoDuocMuon].ToString();
                    // do du lieu kho vao
                    if (ChuoiIDKho != "")
                    {
                        int intDem = lstKho.Items.Count;
                        for (int i = 0; i < intDem; i++)
                        {
                            if (ChuoiIDKho.IndexOf("," + lstKho.Items[i].Value + ",") >= 0)
                            {
                                lstKhoBanDoc.Items.Add(new ListItem(lstKho.Items[i].Text,
                                    lstKho.Items[i].Value));

                                lstKho.Items.RemoveAt(i);
                                intDem = intDem - 1;
                                i = i - 1;

                            }
                        }

                    }

                }
            }
        }
        else
        {
            ResetControl();
        }
    }
    private void ResetControl()
    {
        txtNhomBanDoc.Text = "";
        txtSoSachMuonTaiCho.Text = "";
        txtSoSachMuonVe.Text = "";
        GetKho();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (drdlNhomBanDoc.SelectedValue != "0")
        {
            oNhomBanDocInfo.NhomBanDocID = int.Parse(drdlNhomBanDoc.SelectedValue);
            oBNhomBanDoc.Delete(oNhomBanDocInfo);
            ThongBao("Xóa nhóm bạn đọc thành công!");
            txtNhomBanDoc.Text = "";
            txtSoSachMuonTaiCho.Text = "";
            txtSoSachMuonVe.Text = "";
            GetKho();
        }
        else
        {
            ThongBao("Bạn chưa nhóm bạn đọc cần xóa!");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (drdlNhomBanDoc.SelectedValue != "0")
        {
            // cap nhat nhom ban doc
            oNhomBanDocInfo.TenNhomBanDoc = txtNhomBanDoc.Text.Trim();
            oNhomBanDocInfo.SoSachMuon = int.Parse(txtSoSachMuonVe.Text.Trim());
            oNhomBanDocInfo.SoSachDatCho = int.Parse(txtSoSachMuonTaiCho.Text.Trim());
            oNhomBanDocInfo.CapDoMat = int.Parse(drdlCapDoMat.SelectedValue);
            if (hidKhoIDs.Value != "")
            {
                hidKhoIDs.Value = "," + hidKhoIDs.Value;
            }
            oNhomBanDocInfo.CacKhoDuocMuon = hidKhoIDs.Value;
            oNhomBanDocInfo.NhomBanDocID = int.Parse(drdlNhomBanDoc.SelectedValue);

            int intKetQua = oBNhomBanDoc.Update (oNhomBanDocInfo);
            if (intKetQua == 0)
            {
                ThongBao("Cập nhật nhóm bạn đọc thành công!");
                WriteLog(lstChucNang[0].ChucNangID, "Sửa nhóm bạn đọc thành công : " + oNhomBanDocInfo.TenNhomBanDoc, Request.UserHostAddress, Session["TenDangNhap"].ToString());
                GetNhomBanDoc();
                ResetControl();
            }
            else
            {
                ThongBao("Nhóm bạn đọc đã tồn tại!");
            }
           
        }
        else
        { 
            // them moi nhom ban doc
            oNhomBanDocInfo.TenNhomBanDoc = txtNhomBanDoc.Text.Trim();
            oNhomBanDocInfo.SoSachMuon = int.Parse (txtSoSachMuonVe.Text.Trim());
            oNhomBanDocInfo.SoSachDatCho = int.Parse (txtSoSachMuonTaiCho.Text.Trim());
            oNhomBanDocInfo.CapDoMat = int.Parse(drdlCapDoMat.SelectedValue);
            if (hidKhoIDs.Value != "")
            {
                hidKhoIDs.Value = "," + hidKhoIDs.Value;
            }
            oNhomBanDocInfo.CacKhoDuocMuon = hidKhoIDs.Value ;
           
            int intKetQua = oBNhomBanDoc.Add(oNhomBanDocInfo);
            if (intKetQua == 0)
            {
                WriteLog(lstChucNang[0].ChucNangID, "Thêm mới nhóm bạn đọc thành công : " + oNhomBanDocInfo.TenNhomBanDoc, Request.UserHostAddress, Session["TenDangNhap"].ToString());
                ThongBao("Thêm mới nhóm bạn đọc thành công!");
                GetNhomBanDoc();
                ResetControl();
            }
            else
            {
                ThongBao("Nhóm bạn đọc đã tồn tại!");
            }
        }
    }
}
