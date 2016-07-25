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

public partial class BoSungBienMuc_TimKiemTaiLieu : WebBase
{
    cBTaiLieu_MarcField obTaiLieu_MarcField;

    protected void Page_Load(object sender, EventArgs e)
    {
        trlblDanhSachTaiLieu.Visible = false;
       
    }
    public void TimKiem()
    {
        string strSql = "";
        strSql = "SELECT DISTINCT IDTaiLieu FROM TaiLieu_MarcField WHERE 1=1 ";
        if (TxtNhanDe.Text != "")
        {
            strSql = strSql + "AND DisplayEntry  Like N'%" + TxtNhanDe.Text + "%' AND (IDMarcField=449 OR  IDMarcField=450)";
        }
        if (TxtTacGia.Text != "")
        {
            strSql = strSql + "AND DisplayEntry Like N'%" + TxtTacGia.Text + "%' AND (IDMarcField=312 OR IDMarcField=329 OR IDMarcField= 1399 OR IDMarcField= 1433)";
        }
        if (TxtTuKhoa.Text != "")
        {
            strSql = strSql + "AND DisplayEntry Like N'%" + TxtTuKhoa.Text + "%' AND IDMarcField=1342";
        }
        if (TxtMoTa.Text != "")
        {
            strSql = strSql + "AND DisplayEntry Like N'%" + TxtMoTa.Text + "%'  AND IDMarcField=911";
        }
        if (txtChiSoISBN.Text != "")
        {
            strSql = strSql + "AND DisplayEntry Like N'%" + txtChiSoISBN.Text + "%'  AND IDMarcField=66 OR IDMarcField= 73";
        }
        if (txtMaXepGia.Text != "")
        {
            strSql = strSql + "AND IDTaiLieu IN (SELECT IDTaiLieu FROM MaXepGia WHERE MaXepGia='" + txtMaXepGia.Text + "')";
        }
        obTaiLieu_MarcField = new cBTaiLieu_MarcField();
        
        DataTable dtbKetQua;
        dtbKetQua = obTaiLieu_MarcField.RunSql(strSql);
        string strTaiLieuID = "";
        if (dtbKetQua.Rows.Count > 0)
        {
            for (int i = 0; i < dtbKetQua.Rows.Count; i++)
            { 
                strTaiLieuID=strTaiLieuID +dtbKetQua.Rows[i]["IDTaiLieu"].ToString()+",";
            }
            if(strTaiLieuID!="")
            {
                strTaiLieuID = strTaiLieuID.Substring(0, strTaiLieuID.Length - 1);
            }
            DataTable dtbThongTinTaiLieu;
            dtbThongTinTaiLieu = obTaiLieu_MarcField.GetThongTinTaiLieu(strTaiLieuID);
            if (dtbThongTinTaiLieu.Rows.Count > 0)
            {
                trlblDanhSachTaiLieu.Visible = true;
                //ThongBao("Có" + " " + dtbThongTinTaiLieu.Rows.Count.ToString() + "kết quả được tìm thấy");
                grvResult.DataSource = dtbThongTinTaiLieu;
                grvResult.DataBind();
            }
            else
            {
                trlblDanhSachTaiLieu.Visible = false;
                ThongBao("Không tìm thấy kết quả nào!");
                grvResult.DataSource = null;
                grvResult.DataBind();
            }
            
        }
        else
        {
            ThongBao("Không tìm thấy kết quả nào!");
            grvResult.DataSource = null;
            grvResult.DataBind();
        }
    }
    protected void grvResult_SelectedIndexChanged(object sender, EventArgs e)
    {
        hdTaiLieuID.Value = grvResult.DataKeys[grvResult.SelectedIndex][0].ToString();
        ClientScript.RegisterClientScriptBlock(GetType(), "PrintJs", "<script language='javascript'>opener.document.forms[0].ctl00_ContentPlaceHolder1_txtMaTaiLieu.value='" + grvResult.DataKeys[grvResult.SelectedIndex][1].ToString() + "';self.close();</script>");
    }
    
     protected void btnTimKiem_Click(object sender, EventArgs e)
    {
        TimKiem();
    }
     protected void btnLamLai_Click(object sender, EventArgs e)
     {
         txtChiSoISBN.Text = "";
         txtMaXepGia.Text = "";
         TxtMoTa.Text = "";
         TxtNhanDe.Text = "";
         TxtTacGia.Text = "";
         TxtTuKhoa.Text = "";
         
         grvResult.DataSource = null;
         grvResult.DataBind();
     }
     protected void grvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         grvResult.PageIndex = e.NewPageIndex;
         TimKiem();
     }
}
