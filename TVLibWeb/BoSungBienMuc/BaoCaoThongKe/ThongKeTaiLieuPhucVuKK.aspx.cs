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
using TruongViet.TVLib.Business;
using TruongViet.TVLib.Entity;
using TruongViet.Lib.Web;
using System.Xml.Linq;
using System.Text;
using System.IO;

public partial class BoSungBienMuc_BaoCao_ThongKe_ThongKeTaiLieuPhucVuKK : WebBase
{
    cBTaiLieu_MarcField obTaiLieu_MarcField = new cBTaiLieu_MarcField();
    cBTaiLieu oBTaiLieu;
    DataTable dtbDM_Kho;
    protected void Page_Load(object sender, EventArgs e)
    {
        oBTaiLieu = new cBTaiLieu();
        add_BoundField();
        DataTable dtbThongKeTaiLieuTrongKho = Fill_DB();
        if (dtbThongKeTaiLieuTrongKho.Rows.Count > 0)
            lblTongSo.Text = "Tổng số : " + dtbThongKeTaiLieuTrongKho.Rows.Count.ToString() + "";
        grvTaiLieu.DataSource = dtbThongKeTaiLieuTrongKho;
        grvTaiLieu.DataBind();
    }
    protected void btnIn_Click(object sender, EventArgs e)
    {
    }
    
    private DataTable Fill_DB()
    {
        DataTable dtbTemp = oBTaiLieu.ThongKeTaiLieuTrongKho();
        DataTable dtbTaiLieuTK = create_DBTemp();
        DataRow dr = null;
        int SoLuongTheoKho = 0;
        if (dtbTemp.Rows.Count > 0)
        {
            for (int i = 0; i < dtbTemp.Rows.Count; i++)
            {
                
                if (dr == null)
                {
                    dr = dtbTaiLieuTK.NewRow();
                    SoLuongTheoKho = 0;
                }
                else if (dr["IDTaiLieu"].ToString().Trim() != dtbTemp.Rows[i]["IDTaiLieu"].ToString().Trim())
                {
                    dtbTaiLieuTK.Rows.Add(dr);
                    dr = dtbTaiLieuTK.NewRow();
                    SoLuongTheoKho = 0;
                }
                dr["Tong"] = dtbTemp.Rows[i]["Tong"].ToString();
                dr["TongSoMuon"] = dtbTemp.Rows[i]["TongSoMuon"].ToString();
                dr["IDTaiLieu"] = dtbTemp.Rows[i]["IDTaiLieu"].ToString();
                dr["NhanDe"] = dtbTemp.Rows[i]["NhanDe"].ToString();
                SoLuongTheoKho +=  int.Parse(dtbTemp.Rows[i]["SoLuong"].ToString());
                dr[dtbTemp.Rows[i]["MaKho"].ToString()] = dtbTemp.Rows[i]["SoLuong"].ToString();
                dr["ChenhLech"] = int.Parse("0" + dr["Tong"]) - SoLuongTheoKho - int.Parse("0" + dtbTemp.Rows[i]["TongSoMuon"].ToString());
            }
            dtbTaiLieuTK.Rows.Add(dr);
        }
        return dtbTaiLieuTK;
    }
    private DataTable create_DBTemp()
    {
        DataTable dtbThongKe = new DataTable();
        dtbThongKe.Columns.Add("NhanDe", typeof(string));
        dtbThongKe.Columns.Add("IDTaiLieu", typeof(string));
        dtbThongKe.Columns.Add("Tong", typeof(string));
        dtbThongKe.Columns.Add("TongSoMuon", typeof(string));
        dtbThongKe.Columns.Add("ChenhLech", typeof(string));
        for (int i = 0; i < dtbDM_Kho.Rows.Count; i++)
        {
            dtbThongKe.Columns.Add(dtbDM_Kho.Rows[i]["MaKho"].ToString(),typeof(string));
        }
          return dtbThongKe;
    }
    private void add_BoundField()
    {
        string sql = "SELECT DISTINCT MaKho,TenKho FROM Kho " +
                   "INNER JOIN MaXepGia " +
                   "ON KhoID=IDKho";
        dtbDM_Kho=obTaiLieu_MarcField.RunSql(sql);
        grvTaiLieu.Columns.Clear();
        if (dtbDM_Kho.Rows.Count > 0)
        {
            //add nhan de
            BoundField bfield = new BoundField();
            bfield.HeaderText = "Nhan đề";
            bfield.DataField = "NhanDe";
            grvTaiLieu.Columns.Add(bfield);
           // add Tong so ma xep gia cua tai lieu
            bfield = new BoundField();
            bfield.HeaderText ="Tổng";
            bfield.DataField = "Tong";
            grvTaiLieu.Columns.Add(bfield);
           
            for (int i = 0; i < dtbDM_Kho.Rows.Count; i++)
            {
                bfield = new BoundField();
                bfield.HeaderText = dtbDM_Kho.Rows[i]["TenKho"].ToString();
                bfield.DataField = dtbDM_Kho.Rows[i]["MaKho"].ToString();
                grvTaiLieu.Columns.Add(bfield);
            }
            //add Tong so muon
            bfield = new BoundField();
            bfield.HeaderText = "SV Mượn";
            bfield.DataField = "TongSoMuon";
            grvTaiLieu.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "Chênh lệch";
            bfield.DataField = "ChenhLech";
            grvTaiLieu.Columns.Add(bfield);
           
        }
    }
    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        HtmlForm form = new HtmlForm();
        string attachment = "attachment; filename=ThongKeTaiLieuTrongKho_" + DateTime.Now.ToShortDateString() + ".xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        Response.Charset = "";
        Response.ContentEncoding = Encoding.Unicode;
        Response.BinaryWrite(Encoding.Unicode.GetPreamble());
        StringWriter stw = new StringWriter();
        HtmlTextWriter htextw = new HtmlTextWriter(stw);
        form.Controls.Add(grvTaiLieu); // gvParent là gridview
        this.Controls.Add(form);
        form.RenderControl(htextw);


        Response.Write(stw.ToString());
        Response.End(); 
    }
}
