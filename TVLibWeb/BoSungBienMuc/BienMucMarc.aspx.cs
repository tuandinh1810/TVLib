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
using TruongViet.TVLib.Data;

public partial class BoSungBienMuc_BienMucMarc : WebBase
{
    DataTable tblDublinName;
    string strJS = "";
    int IDTaiLieu, IDMauBienMuc, IDLoaiTaiLieu;
    DataTable tblData;
    MauBienMuc_ChiTietInfo pMauBienMuc_ChiTietInfo;
    cBMauBienMuc_ChiTiet oBMauBienMuc_ChiTiet;
    TaiLieuInfo oTaiLieuInfo = new TaiLieuInfo();
    cBTaiLieu oBTaiLieu = new cBTaiLieu();
    TaiLieu_MarcFieldInfo oTaiLieuMarcFieldInfo;
    cBTaiLieu_MarcField oBTaiLieu_MarcField;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    private string MaTaiLieu;

    protected void Page_Load(object sender, EventArgs e)
    {

        ////Chuyên đổi dữ liệu
        //DataTable dtTemp = cDBase.RunStrSql("SELECT * FROM TempHTT ");

        //if (dtTemp.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dtTemp.Rows.Count; i++)
        //    {
        //        oTaiLieuInfo.MaTaiLieu = oBTaiLieu.SinhMaTaiLieu();
        //        oTaiLieuInfo.IDMauBienMuc = 10;
        //        oTaiLieuInfo.IDLoaiTaiLieu = 1;
        //        oTaiLieuInfo.LuuThong = true;
        //        oTaiLieuInfo.IDNguoiNhapTin = 1;
        //        IDTaiLieu = oBTaiLieu.Add(oTaiLieuInfo);
        //        float stt = float.Parse(dtTemp.Rows[i]["STT"].ToString());
        //        oBTaiLieu.UpdateTempHTT(IDTaiLieu, stt);
        //    }
        //}



        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",2,") >= 0)
        {
            LoadJS();
            GetMaTaiLieu();
            oChucNang.MaChucNang = "BienMuc";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            Session["DuLieuSoLoad"] = "1";
            if (Request["IDTaiLieu"] + "" != "")
            {
                IDTaiLieu = Convert.ToInt32(Request["IDTaiLieu"].ToString());
            }
            if (Request["IDLoaiTaiLieu"] + "" != "")
            {
                IDLoaiTaiLieu = Convert.ToInt32(Request["IDLoaiTaiLieu"].ToString());
                lnkDanhSachTaiLieu.NavigateUrl = "DanhSachTaiLieu.aspx?IDLoaiTaiLieu=" + IDLoaiTaiLieu.ToString();
            }
            else
                lnkDanhSachTaiLieu.NavigateUrl = "DanhSachTaiLieu.aspx";
            if (Request["IDMauBienMuc"] + "" != "")
            {
                IDMauBienMuc = Convert.ToInt32(Request["IDMauBienMuc"].ToString());
                Initialize();
                if (!IsPostBack)
                {
                    HienThiFormBienMuc();
                }
            }
        }
        else
            Response.Redirect("Error.aspx");
    }
    private void LoadJS()
    {
        Page.RegisterClientScriptBlock("JsBienMuc", "<script language='javascript'src='Js/Bienmuc.js'  ></script>");
        //btnClose.Attributes.Add("OnClick", "javascript:opener.document.forms[0].hidFunc.value='LoadBackBienMuc';opener.document.forms[0].submit();self.close();");
       // btnDelete.Attributes.Add("OnClick", "if(confirm('" + ddlLabel.Items[13].Text + "')) return true;return false;");
        btnQuayVe.Attributes.Add("Onclick", "history.go(-1);return false;");
    }
    private void GetMaTaiLieu()
    {
        hdMaTaiLieu.Value = oBTaiLieu.SinhMaTaiLieu();
    }
    private void Initialize()
    {
        if (Request["IDTaiLieu"] != null)
        {
            IDTaiLieu = Convert.ToInt32(Request["IDTaiLieu"].ToString());
        }
        pMauBienMuc_ChiTietInfo = new MauBienMuc_ChiTietInfo();
        oBMauBienMuc_ChiTiet = new cBMauBienMuc_ChiTiet();
        tblDublinName = oBMauBienMuc_ChiTiet.Get_ByMauBienMuc(IDMauBienMuc);
    }
    public void HienThiFormBienMuc()
    { 
        int intIndex;
        for (intIndex = 0; intIndex <= tblDublinName.Rows.Count - 1;intIndex++ )
        {
            HienThiMotDong(intIndex);
        }
        if (hidIsLoad.Value == "0")
        {
            strJS = LoadHiddenValue() + strJS;
        }
        else
        { 
            if(hidIsLoad.Value=="2")
            {
                strJS = ClearFormValue() + strJS;
            }
        }
        Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "CallBack", "" + strJS + "", true);
    }
    private string ClearFormValue()
    {
        string strTemp = "";
        int intIndex;
        for (intIndex = 0; intIndex <= tblDublinName.Rows.Count - 1;intIndex++ )
        {
            if (Convert.ToInt16( tblDublinName.Rows[intIndex]["Marc_Field_ID"]) < 10)
            {
                strTemp = strTemp + "document.forms[0].hid0" + tblDublinName.Rows[intIndex]["Marc_Field_ID"].ToString() + ".value='';";
            }
            else
            {
                strTemp = strTemp + "document.forms[0].hid" + tblDublinName.Rows[intIndex]["Marc_Field_ID"].ToString() + ".value='';";
            }
        }
        return strTemp;
    }

    public void HienThiMotDong(int intIndex)
    {
        TableRow tblRow;
        TableCell tblCell;
        Button btnEData;
        Label lblEData;
        TextBox txbEData;
        HiddenField hidEData;
        HiddenField hidTemp;
        pMauBienMuc_ChiTietInfo = new MauBienMuc_ChiTietInfo();
        string strTemp = "";
        string strMess1 = ddlLabel.Items[0].Text;
        string strMess2 = ddlLabel.Items[1].Text;
        // tao header
        tblRow = new TableRow();
        tblRow.CssClass = "TVLibRow";
        tblCell = new TableCell();
        tblCell.Text = tblDublinName.Rows[intIndex]["Name"].ToString();
        tblCell.ColumnSpan = 4;
        tblRow.Cells.Add(tblCell);
        tblDetail.Rows.Add(tblRow);
        tblRow = new TableRow();
        strTemp = tblDublinName.Rows[intIndex]["Marc_Field_ID"].ToString();
        if ((int)tblDublinName.Rows[intIndex]["Marc_Field_ID"] < 10)
        {
            strTemp = "0" + tblDublinName.Rows[intIndex]["Marc_Field_ID"].ToString();
        }

        // Add label
        lblEData = new Label();
        lblEData.ID = "lb" + strTemp;
        lblEData.Text = "<B>" + tblDublinName.Rows[intIndex]["Code"].ToString() + "</B>";
        lblEData.CssClass = "TVLibLabel";
        // add hidden
        hidEData = new HiddenField();
        hidEData.ID = "hid" + strTemp;
        tblCell = new TableCell();
        tblCell.HorizontalAlign = HorizontalAlign.Right;
        tblCell.Controls.Add(hidEData);
        tblCell.Controls.Add(lblEData);
        tblCell.HorizontalAlign = HorizontalAlign.Right;
        tblCell.Width = Unit.Percentage(12);
        tblRow.Controls.Add(tblCell);

        // Add textbox
        txbEData = new TextBox();
        txbEData.ID = "txb" + strTemp;
        txbEData.CssClass = "TVLibTextBox";
        txbEData.Text = tblDublinName.Rows[intIndex]["GiaTriMacDinh"].ToString();
        txbEData.Width = Unit.Percentage(100);
        txbEData.Attributes.Add("OnChange", "UpdateRecord('" + strTemp + "')");
        if ((bool)tblDublinName.Rows[intIndex]["Repeat"] == true)
        {
            
            txbEData.Attributes.Add("onkeypress", "return XuLyPhimBam('" + strTemp + "',event);");
            txbEData.Attributes.Add("onkeydown", "return ChuyenTextBox('" + strTemp + "',event);");
        }
            //txbEData.Attributes.Add("onkeypress", "alert('1111');");
       // txbEData.Attributes.Add("OnFocus", "alert('122333');");
        tblCell = new TableCell();
        tblCell.HorizontalAlign = HorizontalAlign.Left;
        tblCell.Controls.Add(txbEData);
        // nếu là trường 001 thì hiển thị nút sinh giá trị
        if (tblDublinName.Rows[intIndex]["Code"].ToString() == "001")
        {
            tblCell.Controls.Add(new LiteralControl(" "));
            btnEData = new Button();
            btnEData.CssClass = "TVLibButton";
            btnEData.Text = "Sinh giá trị";
            btnEData.Attributes.Add("OnClick", "document.forms[0].txb" + strTemp + ".value=document.forms[0].hdMaTaiLieu.value; return false;");
            tblCell.Controls.Add(btnEData);
        }
        tblRow.Controls.Add(tblCell);

        //Add navigate buttons
        tblCell = new TableCell();
        tblCell.Width = Unit.Percentage(26);
        tblCell.HorizontalAlign = HorizontalAlign.Left;
        //khai bao bien visible
        bool mVisible = false;
        if ((bool)tblDublinName.Rows[intIndex]["Repeat"] == true)
        {
            mVisible = true;
        }
        // Move first
        btnEData = new Button();
        btnEData.ID = "btn" + strTemp + "1";
        btnEData.CssClass = "TVLibButton";
        btnEData.Text = "|<";
        btnEData.Width = Unit.Pixel(20);
        btnEData.Attributes.Add("OnClick", "javascript:ViewRecord('" + strTemp + "', 1, '" + strMess1 + "', '" + strMess2 + "'); return false;");
        btnEData.ToolTip = ddlLabel.Items[2].Text;
        btnEData.Visible = mVisible;
        tblCell.Controls.Add(btnEData);
        tblCell.Controls.Add(new LiteralControl(" "));

        //Move prev
        btnEData = new Button();
        btnEData.ID = "btn" + strTemp + "2";
        btnEData.CssClass = "TVLibButton";
        btnEData.Text = "<";
        btnEData.Width = Unit.Pixel(20);
        btnEData.Attributes.Add("OnClick", "javascript:ViewRecord('" + strTemp + "', parseInt(document.forms[0].nr" + strTemp + "1.value)-1, '" + strMess1 + "', '" + strMess2 + "'); return false;");
        btnEData.ToolTip = ddlLabel.Items[3].Text;
        btnEData.Visible = mVisible;
        tblCell.Controls.Add(btnEData);
        tblCell.Controls.Add(new LiteralControl(" "));


        // Add nr1 textbox
        // Add nr2 textbox
        if (mVisible == true)
        {
            txbEData = new TextBox();
            txbEData.ID = "nr" + strTemp + "1";
            txbEData.CssClass = "TVLibTextbox";
            txbEData.Width = Unit.Pixel(25);
            txbEData.Enabled = false;
            txbEData.Text = "0";
         
            txbEData.Visible = mVisible;
            tblCell.Controls.Add(txbEData);
            tblCell.Controls.Add(new LiteralControl(" "));
        }
        else
        {
            hidTemp = new HiddenField();
            hidTemp.ID = "nr" + strTemp + "1";
            hidTemp.Value = "0";
            tblCell.Controls.Add(hidTemp);
            tblCell.Controls.Add(new LiteralControl(" "));
        }


        //Move next
        btnEData = new Button();
        btnEData.ID = "btn" + strTemp + "3";
        btnEData.CssClass = "TVLibButton";
        btnEData.Text = ">";
        btnEData.Width = Unit.Pixel(20);
        btnEData.Attributes.Add("OnClick", "javascript:ViewRecord('" + strTemp + "', parseInt(document.forms[0].nr" + strTemp + "1.value)+1, '" + strMess1 + "', '" + strMess2 + "'); return false;");
        btnEData.ToolTip = ddlLabel.Items[4].Text;
        btnEData.Visible = mVisible;
        tblCell.Controls.Add(btnEData);
        tblCell.Controls.Add(new LiteralControl(" "));

        //Move last
        btnEData = new Button();
        btnEData.ID = "btn" + strTemp + "4";
        btnEData.CssClass = "TVLibButton";
        btnEData.Text = ">|";
        btnEData.Width = Unit.Pixel(20);
        btnEData.Attributes.Add("OnClick", "javascript:ViewRecord('" + strTemp + "', parseInt(document.forms[0].nr" + strTemp + "2.value), '" + strMess1 + "', '" + strMess2 + "'); return false;");
        btnEData.ToolTip = ddlLabel.Items[5].Text;
        btnEData.Visible = mVisible;
        tblCell.Controls.Add(btnEData);
        tblCell.Controls.Add(new LiteralControl(" "));

        // New
        btnEData = new Button();
        btnEData.ID = "btn" + strTemp + "5";
        btnEData.CssClass = "TVLibButton";
        btnEData.Text = ">*";
        btnEData.Width = Unit.Pixel(20);
        btnEData.Attributes.Add("OnClick", "javascript:AddNewRecord('" + strTemp + "', 'document.forms[0].nr" + strTemp + "1', 'document.forms[0].nr" + strTemp + "2'); return false;");
        btnEData.ToolTip = ddlLabel.Items[6].Text;
        btnEData.Visible = mVisible;
        tblCell.Controls.Add(btnEData);
        tblCell.Controls.Add(new LiteralControl(" "));

        // Add nr2 textbox
        if (mVisible == true)
        {
            txbEData = new TextBox();
            txbEData.ID = "nr" + strTemp + "2";
            txbEData.CssClass = "TVLibTextbox";
            txbEData.Width = Unit.Pixel(25);
            txbEData.Enabled = false;
            txbEData.Text = "0";
            txbEData.Attributes.Add("onkeypress", "return XuLyPhimBam('" + strTemp + "',event);");
            txbEData.Attributes.Add("onkeydown", "return ChuyenTextBox('" + strTemp + "',event);");
            tblCell.Controls.Add(txbEData);
            tblCell.Controls.Add(new LiteralControl(" "));
        }
        else
        {
            hidTemp = new HiddenField();
            hidTemp.ID = "nr" + strTemp + "2";
            hidTemp.Value = "0";

            tblCell.Controls.Add(hidTemp);
            tblCell.Controls.Add(new LiteralControl(" "));
        }

        // Delete
        btnEData = new Button();
        btnEData.ID = "btn" + strTemp + "6";
        btnEData.CssClass = "TVLibButton";
        btnEData.Text = "X";
        btnEData.Width = Unit.Pixel(20);
        btnEData.Attributes.Add("OnClick", "javascript:DeleteRecord('" + strTemp + "', parseInt(document.forms[0].nr" + strTemp + "1.value)); return false;");
        btnEData.ToolTip = ddlLabel.Items[7].Text;
        btnEData.Visible = mVisible;
        tblCell.Controls.Add(btnEData);
        //Add cell to row

        tblRow.Controls.Add(tblCell);

        //Add row to table
        tblDetail.Rows.Add(tblRow);
        strJS = strJS + "LoadRecNo('" + strTemp + "')" + (char)10;
        strJS = strJS + "ViewRecord('" + strTemp + "', 1, '', '')" + (char)10;
        //Create JS string

    }
    public string LoadHiddenValue()
    {
        string strJSload = "";
        int intIndex;
        string strTemp = "";
        string strTruongDublinNam;
        DataRow[] dtrow;
        int intSubIndex;
        oTaiLieuMarcFieldInfo = new TaiLieu_MarcFieldInfo();
        oBTaiLieu_MarcField = new cBTaiLieu_MarcField();
        tblData = oBTaiLieu_MarcField.GetByIDTaiLieu(IDTaiLieu,"");

        if (tblData != null)
        {
            if (tblData.Rows.Count > 0)
            {
                updatehid.Value = tblData.Rows.Count.ToString();
            }
            else
            {
                updatehid.Value = "0";
            }

        }
        else
        {
            updatehid.Value = "0";
        }
        // Get metadata of the selected object

        for (intIndex = 0; intIndex <= tblDublinName.Rows.Count - 1; intIndex++)
        {
              strTruongDublinNam = tblDublinName.Rows[intIndex]["Marc_Field_ID"].ToString();
                if ((int)tblDublinName.Rows[intIndex]["Marc_Field_ID"] < 10)
                {
                    strTruongDublinNam = "0" + strTruongDublinNam;
                }
                dtrow = tblData.Select("IDMarcField=" + tblDublinName.Rows[intIndex]["Marc_Field_ID"]);
                if (dtrow.Length > 0)
                {
                    for (intSubIndex = 0; intSubIndex <= dtrow.Length - 1; intSubIndex++)
                    {
                        strTemp = strTemp + dtrow[intSubIndex][oTaiLieuMarcFieldInfo.strDisplayEntry].ToString() + "$";
                    }
                }
            //ctl00$ContentPlaceHolder1$
                if (strTemp != "")
                {
                  
                    strJSload = strJSload + "document.forms[0].hid" + strTruongDublinNam + ".value='" + strTemp.Replace("'","\\\'") + "';" + (char)10;
                    
                }
                strTemp = "";
        }
        hidIsLoad.Value = "1";
        return strJSload;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int intCounter = 0;
        int intIndex = 0;
        string[] arrTemp;
        string strTruongDublinID = "";
        string strDublinValue = "";
        string strAccessEntry = "";
        //char a;
        //a = (char)14(char)14;
        foreach (string strControlName in Request.Form)
        {
            if (strControlName.Substring(0, 3) == "hid" && Request.Form[strControlName].Trim() != "" && strControlName.ToLower() != "hidisload")
            {
                if (strControlName == "hid01")
                    MaTaiLieu = Request.Form[strControlName].ToString().Substring(0, Request.Form[strControlName].ToString().Length-1);
                arrTemp = Request.Form[strControlName].ToString().Split('$');
                    for (intIndex = 0; intIndex <= arrTemp.Length - 1; intIndex++)
                    {
                        if (arrTemp[intIndex].ToString() != "")
                        {
                            strTruongDublinID = strTruongDublinID + strControlName.Substring(3, strControlName.Length - 3) + ",";
                            strDublinValue = strDublinValue + arrTemp[intIndex] + "$$$";
                            strAccessEntry = strAccessEntry + arrTemp[intIndex].ToUpper() + "$$$";
                        }
                    }
            }
            else
                if (strControlName.Substring(0, 3) == "txb" && Request.Form[strControlName].Trim() != "" && strTruongDublinID.IndexOf(strControlName.Substring(3, strControlName.Length - 3) + ",") < 0)
                {
                    if (strControlName == "txb01")
                        MaTaiLieu = Request.Form[strControlName].Trim();
                    strTruongDublinID = strTruongDublinID + strControlName.Substring(3, strControlName.Length - 3) + ",";
                    strDublinValue = strDublinValue + Request.Form[strControlName].Trim() + "$$$";
                    strAccessEntry = strAccessEntry + Request.Form[strControlName].Trim().ToUpper() + "$$$";
                }
        }
        if (strDublinValue != "" && strTruongDublinID != "")
        {
            string strTemp = "," + strTruongDublinID;
            if (strTemp.IndexOf(",449,") >= 0 && strTemp.IndexOf(",01,") >= 0)
            {
                if (Request["IDTaiLieu"] + "" == "")
                {
                    // Them moi tai lieu
                    oTaiLieuInfo.MaTaiLieu = MaTaiLieu;
                    oTaiLieuInfo.IDMauBienMuc = int.Parse(Request["IDMauBienMuc"] + "");
                    oTaiLieuInfo.IDLoaiTaiLieu = IDLoaiTaiLieu;
                    oTaiLieuInfo.LuuThong = true;
                    if (Session["TaiKhoanID"] + "" != "")
                        oTaiLieuInfo.IDNguoiNhapTin = int.Parse(Session["TaiKhoanID"].ToString());
                    IDTaiLieu = oBTaiLieu.Add(oTaiLieuInfo);
                    if (IDTaiLieu == 0)
                    {
                        ThongBao("Mã tài liệu đã bị trùng đề nghị bạn sinh lại mã tài liệu");
                        return;
                    }
                }

                oBTaiLieu_MarcField = new cBTaiLieu_MarcField();
                oBTaiLieu_MarcField.Updates(IDTaiLieu, strTruongDublinID, strDublinValue, strAccessEntry);
                if (Request["IDTaiLieu"] + "" == "")
                {
                    btnQuayVe.Attributes.Add("Onclick", "document.location.href='DanhSachTaiLieu.aspx?IDLoaiTaiLieu=" + Request["IDLoaiTaiLieu"] + "';return false;");
                    Page.RegisterClientScriptBlock("SuccessUpdated", "<script language='javascript'>alert('Thêm mới thành công!')</script>");
                    WriteLog(lstChucNang[0].ChucNangID, "Biên mục tài liệu mới :" +oTaiLieuInfo.MaTaiLieu, Request.UserHostAddress, Session["TenDangNhap"].ToString());
                }
                else
                {
                    btnQuayVe.Attributes.Add("Onclick", "document.location.href='DanhSachTaiLieu.aspx?IDLoaiTaiLieu=" + Request["IDLoaiTaiLieu"] + "';return false;");
                    Page.RegisterClientScriptBlock("SuccessUpdated", "<script language='javascript'>alert('" + ddlLabel.Items[11].Text + "')</script>");
                    WriteLog(lstChucNang[0].ChucNangID, "Sửa tài liệu : "+oTaiLieuInfo.MaTaiLieu, Request.UserHostAddress, Session["TenDangNhap"].ToString());
                }
                CallJS("XemBieuGhi", "document.location.href='XemBieuGhiBienMuc.aspx?IDTaiLieu=" + IDTaiLieu.ToString() + "&IDLoaiTaiLieu=" + Request["IDLoaiTaiLieu"] + "&IDMauBienMuc=" + Request["IDMauBienMuc"] + "';void(0);");

            }
            else
                ThongBao("Thông tin chưa đầy đủ, bạn cần nhập lại các trường bắt buộc(001,245$a)!");

        }
        else
        {
            Page.RegisterClientScriptBlock("ErrorUpdated", "<script language='javascript'>alert('" + ddlLabel.Items[12].Text + "')</script>");
        }
      
       // HienThiFormBienMuc();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        
        //oTaiLieuTruongDubInfo = new TaiLieu_MarcFieldInfo();
        //oBTaiLieu_MarcField = new cBTaiLieu_MarcField();
        //oTaiLieuTruongDubInfo.IDTaiLieu = IDTaiLieu;
        //oBTaiLieu_MarcField.Delete(oTaiLieuTruongDubInfo);
        //hidIsLoad.Value = "2";
        //HienThiFormBienMuc();
    }
}
