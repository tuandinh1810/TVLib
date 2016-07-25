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

public partial class QuanTriHeThong_NguoiDung : WebBase 
{
    NguoiDungInfo oNguoiDungInfo = new NguoiDungInfo ();
    cBNguoiDung oBNguoiDung;
    NguoiDung_PhanHeInfo  oNguoiDung_PhanHeInfo = new NguoiDung_PhanHeInfo();
    cBNguoiDung_PhanHe  oBNguoiDung_PhanHe;
    NguoiDung_ChucNangInfo oND_CNInfo;
    cBNguoiDung_ChucNang oBND_CN;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        oND_CNInfo = new NguoiDung_ChucNangInfo();
        oBND_CN = new cBNguoiDung_ChucNang();
        oBNguoiDung_PhanHe = new cBNguoiDung_PhanHe();
        oBNguoiDung_PhanHe = new cBNguoiDung_PhanHe();
        oBNguoiDung = new cBNguoiDung();
        if (Session["TenDangNhap"] + "" != "" && Session["TenDangNhap"].ToString().ToUpper() == "ADMIN")
        {
            BindJS();
            oChucNang.MaChucNang = "QuanTriHeThong";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);

            if (!IsPostBack)
            {
                txtMatKhau.Text = "";
                GetUserInfor();
            }
        }
        else
            Response.Redirect("ThayDoiThongTinNguoiDung.aspx");
    }
    public void BindJS()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript' src='../Resources/Js/QTHT.js'></script>");
        btnThemmoi.Attributes.Add("OnClick", "return CheckUserInfor();");
        lnkBSBM.Attributes.Add("onclick", "javascript:OpenWindow('PhanQuyen.aspx?IDNguoiDung='+ document.forms[0].ctl00_ContentPlaceHolder1_hidUserID.value+'&PhanHe=1&Dest='+document.forms[0].ctl00_ContentPlaceHolder1_hidQuyenIDs.value,'PhanQuyen1',600,400,200,200);");
        lnkBanDoc.Attributes.Add("onclick", "javascript:OpenWindow('PhanQuyen.aspx?IDNguoiDung='+ document.forms[0].ctl00_ContentPlaceHolder1_hidUserID.value+'&PhanHe=2&Dest='+document.forms[0].ctl00_ContentPlaceHolder1_hidQuyenIDs.value,'PhanQuyen2',600,400,50,50);");
        lnkQLLuuThong.Attributes.Add("onclick", "javascript:OpenWindow('PhanQuyen.aspx?IDNguoiDung='+ document.forms[0].ctl00_ContentPlaceHolder1_hidUserID.value+'&PhanHe=3&Dest='+document.forms[0].ctl00_ContentPlaceHolder1_hidQuyenIDs.value,'PhanQuyen3',600,400,50,50);");
        lnkQTHT.Attributes.Add("onclick", "javascript:OpenWindow('PhanQuyen.aspx?IDNguoiDung='+ document.forms[0].ctl00_ContentPlaceHolder1_hidUserID.value+'&PhanHe=5&Dest='+document.forms[0].ctl00_ContentPlaceHolder1_hidQuyenIDs.value,'PhanQuyen5',600,400,50,50);");
        lnkAPDK.Attributes.Add("onclick", "javascript:OpenWindow('PhanQuyen.aspx?IDNguoiDung='+ document.forms[0].ctl00_ContentPlaceHolder1_hidUserID.value+'&PhanHe=6&Dest='+document.forms[0].ctl00_ContentPlaceHolder1_hidQuyenIDs.value,'PhanQuyen6',600,400,50,50);");

        //lnkQTHT.Attributes.Add("onclick", "alert(document.forms[0].ctl00_ContentPlaceHolder1_hidQuyenIDs.value);return false;");
    }
    public void GetUserInfor()
    {
        oNguoiDungInfo.NguoiDungID = 0;
       DataTable dtTemp = new DataTable ();
        dtTemp  = oBNguoiDung.Get(oNguoiDungInfo);
        if (dtTemp != null)
        {
            grvNguoiDung.DataSource = dtTemp;
            grvNguoiDung.DataBind();
            LayThongTinNguoiDung_PhanHe(oNguoiDungInfo.NguoiDungID);
            LayThongTinNguoiDung_ChucNang(oNguoiDungInfo.NguoiDungID);
        }

    }
    public string MaHoaMatKhau(string strMatKhau)
    {
        AspCrypt.CryptClass cryp = new AspCrypt.CryptClass();
        string strMaBoSung = "pl";
        string strOut = cryp.Crypt(strMaBoSung, strMatKhau);
        return strOut;
    }
    protected void btnThemmoi_Click(object sender, EventArgs e)
    {
        oNguoiDungInfo.TenNguoiDung = txthoten.Text.Trim();
        if (txtMatKhau.Text + "" != "")
            //oNguoiDungInfo.MatKhau = MaHoaMatKhau(txtMatKhau.Text);
            oNguoiDungInfo.MatKhau = txtMatKhau.Text;
        else
            oNguoiDungInfo.MatKhau = "";
        //oNguoiDungInfo.MatKhau = txtMatKhau.Text.Trim();
        oNguoiDungInfo.DienThoai = txtDienthoai.Text.Trim();
        oNguoiDungInfo.Email = txtEmail.Text.Trim();
        oNguoiDungInfo.TenDangNHap = txtTenDangNhap.Text.Trim();
        oNguoiDungInfo.GhiChu = txtGhiChu.Text.Trim();
        if ((hidUserID.Value != "") && (hidUserID.Value != "0"))
        {
            //oNguoiDungInfo.MatKhau  = hdPassword.Value;
            oNguoiDungInfo.NguoiDungID = int.Parse(hidUserID.Value);
            int intKetQua = oBNguoiDung.Update(oNguoiDungInfo);
            if (intKetQua == 0)
            {
                CapNhatNguoiDung_PhanHe(int.Parse(hidUserID.Value));
                CapNhatNguoiDung_ChucNang(int.Parse(hidUserID.Value));
                ThongBao("Cập nhật người dùng thành công!");
                GetUserInfor();
                ResetControls();
                // write log
                WriteLog(lstChucNang[0].ChucNangID, "Sửa người dùng thành công : " + oNguoiDungInfo.TenNguoiDung, Request.UserHostAddress, Session["TenDangNhap"].ToString());
            }
            else
                ThongBao("Tên đăng nhập đã tồn tại!");
        }
        else
        {
           
            int intKetQua = oBNguoiDung.Add(oNguoiDungInfo);
            if (intKetQua > 0)
            {
                
                CapNhatNguoiDung_PhanHe(intKetQua);
                CapNhatNguoiDung_ChucNang(intKetQua);
                GetUserInfor();
                ThongBao("Thêm mới người dùng thành công!");
                ResetControls();
                // write log
                WriteLog(lstChucNang[0].ChucNangID, "Thêm mới người dùng thành công : " + oNguoiDungInfo.TenNguoiDung, Request.UserHostAddress, Session["TenDangNhap"].ToString());
            }
            else if(intKetQua==-1)
                ThongBao("Tên đăng nhập đã tồn tại!");
        }
    }
    private void CapNhatNguoiDung_ChucNang(int NguoiDungID)
    {
        if (hidQuyenIDs.Value != "")
        {
            if (hidQuyenIDs.Value.Substring(0, 1) == ",")
                hidQuyenIDs.Value = hidQuyenIDs.Value.Substring(1, hidQuyenIDs.Value.Length - 1);
            if (Session["NguoiDungID"] != null)
            {
                if (int.Parse(Session["NguoiDungID"] + "") == NguoiDungID)
                {
                    Session["QuyenIDs"] = "," + hidQuyenIDs.Value;
                }
            }
            oND_CNInfo.IDNguoiDung = NguoiDungID;
            oBND_CN.Add(oND_CNInfo, hidQuyenIDs.Value);
        }
    }
    public void ResetControls()
    {
        txtDienthoai.Text = "";
        txtEmail.Text = "";
        txtGhiChu.Text = "";
        txtGoLaiMatKhau.Text = "";
        txthoten.Text = "";
        txtMatKhau.Text = "";
        txtTenDangNhap.Text = "";
        hdPassword.Value = "";
        hidQuyenIDs.Value = "";
        hidUserID.Value = "";
        btnThemmoi.Text = "Thêm mới";
        drdlLuuThong.SelectedIndex = 0;
        drdlQTHT.SelectedIndex = 0;
        drdlBSBM.SelectedIndex = 0;

    }
    protected void btnThoi_Click(object sender, EventArgs e)
    {
        ResetControls();
    }
    protected void grvNguoiDung_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        oNguoiDungInfo.NguoiDungID = int.Parse(grvNguoiDung.DataKeys[e.RowIndex][0].ToString());
        oBNguoiDung.Delete(oNguoiDungInfo);
        GetUserInfor();
        ThongBao("Xóa người dùng thành công!");
        WriteLog(lstChucNang[0].ChucNangID, "Xóa người dùng thành công", Request.UserHostAddress, Session["TenDangNhap"].ToString());
        ResetControls();
    }
       protected void grvNguoiDung_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvNguoiDung.EditIndex = -1;
        GetUserInfor();
    }
    protected void grvNguoiDung_RowEditing(object sender, GridViewEditEventArgs e)
    {
        hidUserID.Value = grvNguoiDung.DataKeys[e.NewEditIndex][0].ToString();
        oNguoiDungInfo.NguoiDungID = int.Parse(hidUserID.Value);
       DataTable dtTemp =  oBNguoiDung.Get(oNguoiDungInfo);
       txtDienthoai.Text = dtTemp.Rows[0]["DienThoai"].ToString ();
       txtEmail.Text = dtTemp.Rows[0]["Email"].ToString();
       txtGhiChu.Text = dtTemp.Rows[0]["GhiChu"].ToString();
       txtTenDangNhap.Text = dtTemp.Rows[0]["TenDangNHap"].ToString();
      // hdPassword.Value = dtTemp.Rows[0]["MatKhau"].ToString();
       txthoten.Text = dtTemp.Rows[0]["TenNguoiDung"].ToString();
       //txtMatKhau.Text = dtTemp.Rows[0]["MatKhau"].ToString(); 
        btnThemmoi.Text = "Cập nhật";
        LayThongTinNguoiDung_PhanHe(int.Parse(hidUserID.Value));
        LayThongTinNguoiDung_ChucNang(int.Parse(hidUserID.Value));
    }
    private void LayThongTinNguoiDung_ChucNang(int NguoiDungID)
    {
        if (NguoiDungID > 0)
        {
            oND_CNInfo.IDNguoiDung = NguoiDungID;
            DataTable dtTemp = oBND_CN.Get(oND_CNInfo);
            if (dtTemp != null)
            {
                if (dtTemp.Rows.Count > 0)
                {
                    hidQuyenIDs.Value = ",";
                    for (int inti = 0; inti < dtTemp.Rows.Count; inti++)
                    {
                        hidQuyenIDs.Value = hidQuyenIDs.Value + dtTemp.Rows[inti]["IDChucNang"].ToString() + ",";
                    }

                }
                else
                {
                    hidQuyenIDs.Value = "";
                }
            }
            else
            {
                hidQuyenIDs.Value = "";
            }

        }
    }
    public void CapNhatNguoiDung_PhanHe(int NguoiDungID)
    {
        oNguoiDung_PhanHeInfo.IDNguoiDung = NguoiDungID;
        oBNguoiDung_PhanHe.Delete(oNguoiDung_PhanHeInfo);
        if (drdlQTHT.SelectedValue  == "1")
        {
            oNguoiDung_PhanHeInfo.IDPhanHe = 5;
            oBNguoiDung_PhanHe.Add(oNguoiDung_PhanHeInfo);
        }
        if (drdlBSBM.SelectedValue == "1")
        {
            oNguoiDung_PhanHeInfo.IDPhanHe = 1;
            oBNguoiDung_PhanHe.Add(oNguoiDung_PhanHeInfo);
        }
        if (drdlLuuThong.SelectedValue == "1")
        {
            oNguoiDung_PhanHeInfo.IDPhanHe = 3;

            oBNguoiDung_PhanHe.Add(oNguoiDung_PhanHeInfo);
        }
        if (drdlBanDoc.SelectedValue == "1")
        {
            oNguoiDung_PhanHeInfo.IDPhanHe = 2;

            oBNguoiDung_PhanHe.Add(oNguoiDung_PhanHeInfo);
        }
    }
    public void LayThongTinNguoiDung_PhanHe(int NguoiDungID)
    {
        drdlQTHT.SelectedIndex = 0;
        drdlBSBM.SelectedIndex = 0;
        drdlLuuThong.SelectedIndex = 0;
        drdlBanDoc.SelectedIndex = 0;
       DataTable dtTemp =  oBNguoiDung_PhanHe.GetNguoiDung_PhanHe(NguoiDungID);
       if (dtTemp != null)
       {
           if (dtTemp.Rows.Count > 0)
           {
               for (int i = 0; i < dtTemp.Rows.Count; i++)
               {
                   switch (dtTemp.Rows[i]["IDPhanHe"].ToString())
                   {
                       case "1":
                           drdlBSBM.SelectedIndex = 1;
                           break;
                       case "2":
                           drdlBanDoc.SelectedIndex = 1;
                           break;
                       case "3":
                           drdlLuuThong.SelectedIndex = 1;
                           break;
                       case "5":
                           drdlQTHT.SelectedIndex = 1;
                           break;
                   }
               }
                   
           }
           else
           {
               drdlQTHT.SelectedIndex = 0;
               drdlBSBM.SelectedIndex = 0;
               drdlLuuThong.SelectedIndex = 0;
               drdlBanDoc.SelectedIndex = 0;
           }

       }
    }
}
