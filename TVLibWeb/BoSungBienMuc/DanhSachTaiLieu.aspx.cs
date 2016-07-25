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
   
public partial class BoSungBienMuc_DanhSachTaiLieu : WebBase 
{
    cBLoaiTaiLieu oBLoaiTaiLieu;
    cBTaiLieu oBTaiLieu;
    cBTaiLieu_MarcField obTaiLieu_MarcField;
    cBMaXepGia obMaXepGia;
    protected void Page_Load(object sender, EventArgs e)
    {
        oBLoaiTaiLieu = new cBLoaiTaiLieu();
        oBTaiLieu = new cBTaiLieu();
        obMaXepGia = new cBMaXepGia();
        obTaiLieu_MarcField = new cBTaiLieu_MarcField();
        if (!IsPostBack)
        {
          //  LoadLoaiTaiLieu();
            LoadDanhSachTaiLieu();
        }
        btnLamLai.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
    }

    private void LoadLoaiTaiLieu()
    {
        LoaiTaiLieuInfo oLoaiTaiLieuInfo = new LoaiTaiLieuInfo();
        LoadDropDownList(drdlLoaiTaiLieu, oBLoaiTaiLieu.Get(oLoaiTaiLieuInfo), "TenLoaiTaiLieuFull", "LoaiTaiLieuID", "--- Chọn loại tài liệu ---");
        if (Request["IDLoaiTaiLieu"] + "" != "")
            drdlLoaiTaiLieu.SelectedValue = Request["IDLoaiTaiLieu"].ToString();
        LoadDanhSachTaiLieu();
    }

    private void LoadDanhSachTaiLieu()
        {
        int intIDLoaiTaiLieu = 0;
        if (drdlLoaiTaiLieu.SelectedIndex >= 0)
        {
            intIDLoaiTaiLieu = int.Parse(drdlLoaiTaiLieu.SelectedValue);
        }
        //DataTable dtbTaiLieu = oBTaiLieu.GetByLoaiTaiLieu(intIDLoaiTaiLieu);
        //grvTaiLieu.PageSize = int.Parse(ddlPageSize.SelectedValue.ToString());
        //if (dtbTaiLieu.Rows.Count == 0)
        //{
        //    dtbTaiLieu = InsertOneRow(dtbTaiLieu, "", 0, 0);
        //    grvTaiLieu.DataSource = dtbTaiLieu;            
        //    grvTaiLieu.DataBind();
        //    grvTaiLieu.Rows[0].Visible = false;
        //    lblTotal.Text = "0";
        //}
        //else
        //{
        //    lblTotal.Text = dtbTaiLieu.Rows.Count.ToString();
        //    grvTaiLieu.DataSource = dtbTaiLieu;
        //    grvTaiLieu.DataBind();
        //}
        //string strSql = "";
        //strSql = "SELECT DISTINCT IDTaiLieu FROM TaiLieu_MarcField INNER JOIN TaiLieu ON TaiLieuID = IDTaiLieu WHERE 1=1 ";
        //if (intIDLoaiTaiLieu != 0)
        //    strSql = strSql + " AND IDLoaiTaiLieu = " + intIDLoaiTaiLieu.ToString();
        //if (TxtNhanDe.Text != "")
        //{
        //    strSql = strSql + "AND DisplayEntry  Like N'%" + TxtNhanDe.Text + "%' AND (IDMarcField=449 OR  IDMarcField=450)";
        //}
        //if (TxtTacGia.Text != "")
        //{
        //    strSql = strSql + "AND DisplayEntry Like N'%" + TxtTacGia.Text + "%' AND (IDMarcField=312 OR IDMarcField=329 OR IDMarcField= 1399 OR IDMarcField= 1433)";
        //}
        //if (txtDongTacGia.Text != "")
        //{
        //    strSql = strSql + "AND DisplayEntry Like N'%" + txtDongTacGia.Text + "%' AND IDMarcField=1342";
        //}
        //if (TxtMoTa.Text != "")
        //{
        //    strSql = strSql + "AND DisplayEntry Like N'%" + TxtMoTa.Text + "%'  AND IDMarcField=911";
        //}
        //if (txtTuKhoa.Text != "")
        //{
        //    strSql = strSql + "AND DisplayEntry Like N'%" + txtTuKhoa.Text + "%'  AND IDMarcField=66 OR IDMarcField= 73";
        //}
        //if (txtNhaXuatBan.Text != "")
        //{
        //    strSql = strSql + "AND IDTaiLieu IN (SELECT IDTaiLieu FROM MaXepGia WHERE MaXepGia='" + txtNhaXuatBan.Text + "')";
        //}

        string strWhere = "";
        string strSelect = "";
        string strSql = "";
        Boolean bnltemp = false;
        string strTaiLieuID = "";
        //Truong du lieu 1
        strSelect = "SELECT DISTINCT A.TaiLieuID FROM TaiLieu A  " + "WHERE LuuThong = 1 ";
        if (TxtNhanDe.Text != "")
            strWhere = strWhere + FormingSql(1,1, TxtNhanDe.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        if (TxtTacGia.Text != "")
            strWhere = strWhere + FormingSql(1, 2, TxtTacGia.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        if (txtDongTacGia.Text != "")
            strWhere = strWhere + FormingSql(1, 3, txtDongTacGia.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        if(txtTuKhoa.Text!="")
            strWhere = strWhere + FormingSql(1, 6, txtTuKhoa.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        if (txtNhaXuatBan.Text != "")
            strWhere = strWhere + FormingSql(1, 5, txtNhaXuatBan.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        if (TxtMoTa.Text != "")
            strWhere = strWhere + FormingSql(1, 4, TxtMoTa.Text.Trim().Replace(" ", " and ").Replace(",", ""));
        strSql = strSelect + strWhere;

        strSql = "select top 100 *,isnull(dbo.TaiLieu_LayNhanDe(TaiLieuID),'') as NhanDe,'' as NgayXuatBan,isnull(dbo.GetTruongThongTin(TaiLieuID, 312),'') as TacGia FROM TaiLieu where LuuThong = 1 and TaiLieuID IN(" + strSql + ") ORDER BY TaiLieuID DESC";
       



        obTaiLieu_MarcField = new cBTaiLieu_MarcField();
        grvTaiLieu.PageSize = int.Parse(ddlPageSize.SelectedValue.ToString());
        DataTable dtbKetQua;
        dtbKetQua = obTaiLieu_MarcField.RunSql(strSql);
       // string strTaiLieuID = "";
        if (dtbKetQua.Rows.Count > 0)
        {
            for (int i = 0; i < dtbKetQua.Rows.Count; i++)
            {
                strTaiLieuID = strTaiLieuID + dtbKetQua.Rows[i]["TaiLieuID"].ToString() + ",";
            }
            if (strTaiLieuID != "")
            {
                strTaiLieuID = strTaiLieuID.Substring(0, strTaiLieuID.Length - 1);
            }
            DataTable dtbThongTinTaiLieu;
            dtbThongTinTaiLieu = obTaiLieu_MarcField.GetThongTinTaiLieu(strTaiLieuID);
            if (dtbThongTinTaiLieu.Rows.Count > 0)
            {
                //ThongBao("Có" + " " + dtbThongTinTaiLieu.Rows.Count.ToString() + "kết quả được tìm thấy");
                lblTotal.Text = dtbThongTinTaiLieu.Rows.Count.ToString();
                grvTaiLieu.DataSource = dtbThongTinTaiLieu;
                grvTaiLieu.DataBind();
            }
            else
            {
                ThongBao("Không tìm thấy kết quả nào!");
                grvTaiLieu.DataSource = null;
                grvTaiLieu.DataBind();
            }

        }
        else
        {
            ThongBao("Không tìm thấy kết quả nào!");
            grvTaiLieu.DataSource = null;
            grvTaiLieu.DataBind();
        }
    }
    protected string FormingSql(int intOperation, int intMetadataID, string strSearch)
    {

        string strTemp = "";
        string strFinalSql = "";
        if (intMetadataID == 0)
        {
            strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID=B.IDTaiLieu WHERE Contains(DisplayEntry,N'" + strSearch + "') ";
        }
        else
        {
            if (intMetadataID == 1)
                // nhan de
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 449 AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
            else if (intMetadataID == 2) // tac gia
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE (IDMarcField = 312 OR IDMarcField=330) AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
            else if (intMetadataID == 3) // Dong tac gia
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE (IDMarcField = 1443 OR IDMarcField=1399) AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
            else if (intMetadataID == 4) // mo ta
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 911  AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
            else if (intMetadataID == 5) // Nha xuat ban
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 519 AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
            else if (intMetadataID == 6) // tu khoa
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 1342 AND Contains(DisplayEntry,N'" + strSearch + "', language 1033)";
        }

        switch (intOperation)
        {
            case 1:
                strFinalSql = " AND A.TaiLieuID IN (" + strTemp + ")";
                break;
            case 2:
                strFinalSql = " UNION " + strTemp;
                break;
            case 3:
                strFinalSql = " AND A.TaiLieuID NOT IN (" + strTemp + ")";
                break;
        }
        return strFinalSql;
    }

    protected void grvTaiLieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTaiLieu.PageIndex = e.NewPageIndex;
        LoadDanhSachTaiLieu();
    }

    //protected void grvTaiLieu_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        if (e.Row.Cells[1].Text.Length > 120)
    //            e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 120) + " <font color='blue'>...</font>";
    //    }
    //}

    protected void grvTaiLieu_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        TaiLieuInfo oTaiLieuInfo = new TaiLieuInfo();
        oTaiLieuInfo.TaiLieuID = int.Parse(grvTaiLieu.DataKeys[e.RowIndex].Value.ToString());
        try
        {
            oBTaiLieu.Delete(oTaiLieuInfo);
        }
        catch (Exception exp)
        {
            ThongBao("Tài liệu đang được sử dụng ko thể xóa!");
        }
        LoadDanhSachTaiLieu();
    }
    protected void btnTimKiem_Click(object sender, EventArgs e)
    {
        LoadDanhSachTaiLieu();
    }
    protected void drdlLoaiTaiLieu_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDanhSachTaiLieu();
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDanhSachTaiLieu();
    }
    protected void btnLamLai_Click(object sender, EventArgs e)
    {

    }
}
