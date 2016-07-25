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
using TruongViet.Lib.Web;
using Aspose.Cells;
using System.IO;
using System.Text;
public partial class BoSungBienMuc_BaoCaoThongKe_BaoCaoTheoNamBoSung : WebBase
{
    cBTaiLieu_MarcField obTaiLieu_MarcField = new cBTaiLieu_MarcField();
    cBTaiLieu oBTaiLieu;
    DataTable dtbDM_Kho;
    private Cells _range;
    private Worksheet _exSheet;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void Loc()
    {
        grvTaiLieu.Columns.Clear();
        oBTaiLieu = new cBTaiLieu();
        DataTable dtbTemp = oBTaiLieu.ThongKeTaiLieuTheoNamBoSung(int.Parse("0"+txtTuNam.Text),int.Parse("0"+txtDenNam.Text));
       // DataTable dtbTaiLieuTK = create_DBTemp();
        //Tao bang tam
        DataTable dtbTaiLieuTK = new DataTable();
        dtbTaiLieuTK.Columns.Add("NhanDe", typeof(string));
        dtbTaiLieuTK.Columns.Add("IDTaiLieu", typeof(string));
        dtbTaiLieuTK.Columns.Add("SoLuong", typeof(string));
        dtbTaiLieuTK.Columns.Add("TongSo", typeof(string));
        DataTable dtbNam = clsCommon.SelectDistinct("dtNam", dtbTemp, "NamBoSung");
        for (int i = 0; i < dtbNam.Rows.Count; i++)
        {
            dtbTaiLieuTK.Columns.Add(dtbNam.Rows[i]["NamBoSung"].ToString(), typeof(string));
        }
        //Add bound field
        BoundField bfield = new BoundField();
        bfield.HeaderText = "Nhan đề";
        bfield.DataField = "NhanDe";
        grvTaiLieu.Columns.Add(bfield);
        // add Tong so tai lieu 
        bfield = new BoundField();
        bfield.HeaderText = "Tổng";
        bfield.DataField = "TongSo";
        grvTaiLieu.Columns.Add(bfield);

        for (int i = 0; i < dtbNam.Rows.Count; i++)
        {
            bfield = new BoundField();
            bfield.HeaderText = "Năm "+dtbNam.Rows[i]["NamBoSung"].ToString();
            bfield.DataField = dtbNam.Rows[i]["NamBoSung"].ToString();
            grvTaiLieu.Columns.Add(bfield);
        }

      
      //  grvTaiLieu.Columns.Add(bfield);
        DataRow dr = null;
        //int SoLuongTheoKho = 0;
        if (dtbTemp.Rows.Count > 0)
        {
            for (int i = 0; i < dtbTemp.Rows.Count; i++)
            {

                if (dr == null)
                {
                    dr = dtbTaiLieuTK.NewRow();
                  //SoLuongTheoKho = 0;
                }
                else if (dr["IDTaiLieu"].ToString().Trim() != dtbTemp.Rows[i]["IDTaiLieu"].ToString().Trim())
                {
                    dtbTaiLieuTK.Rows.Add(dr);
                    dr = dtbTaiLieuTK.NewRow();
                    //SoLuongTheoKho = 0;
                }
                dr["TongSo"] = dtbTemp.Rows[i]["TongSo"].ToString();
                dr["SoLuong"] = dtbTemp.Rows[i]["SoLuong"].ToString();
                dr["IDTaiLieu"] = dtbTemp.Rows[i]["IDTaiLieu"].ToString();
                dr["NhanDe"] = dtbTemp.Rows[i]["NhanDe"].ToString();
                //SoLuongTheoKho += int.Parse(dtbTemp.Rows[i]["SoLuong"].ToString());
                dr[dtbTemp.Rows[i]["NamBoSung"].ToString()] = dtbTemp.Rows[i]["SoLuong"].ToString();
                //dr["ChenhLech"] = int.Parse("0" + dr["Tong"]) - SoLuongTheoKho - int.Parse("0" + dtbTemp.Rows[i]["TongSoMuon"].ToString());
            }
            dtbTaiLieuTK.Rows.Add(dr);
        }
        if (dtbTaiLieuTK.Rows.Count > 0)
        {
            lblTongSo.Text = dtbTaiLieuTK.Rows.Count.ToString();
            grvTaiLieu.DataSource = dtbTaiLieuTK;
            grvTaiLieu.DataBind();
        }

    }
    private DataTable create_DBTemp()
    {
        DataTable dtbThongKe = new DataTable();
        dtbThongKe.Columns.Add("NhanDe", typeof(string));
        dtbThongKe.Columns.Add("IDTaiLieu", typeof(string));
        dtbThongKe.Columns.Add("SoLuong", typeof(string));
        dtbThongKe.Columns.Add("TongSo", typeof(string));
        for (int i = 0; i < dtbDM_Kho.Rows.Count; i++)
        {
            dtbThongKe.Columns.Add(dtbDM_Kho.Rows[i]["MaKho"].ToString(), typeof(string));
        }
        return dtbThongKe;
    }
    private void add_BoundField()
    {
        string sql = "SELECT DISTINCT MaKho,TenKho FROM Kho " +
                   "INNER JOIN MaXepGia " +
                   "ON KhoID=IDKho";
        dtbDM_Kho = obTaiLieu_MarcField.RunSql(sql);
        if (dtbDM_Kho.Rows.Count > 0)
        {
            //add nhan de
            BoundField bfield = new BoundField();
            bfield.HeaderText = "Nhan đề";
            bfield.DataField = "NhanDe";
            grvTaiLieu.Columns.Add(bfield);
            // add Tong so ma xep gia cua tai lieu
            bfield = new BoundField();
            bfield.HeaderText = "Tổng";
            bfield.DataField = "TongSo";
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
    protected void btnLoc_Click(object sender, EventArgs e)
    {
        Loc();
    }
    protected void btnXuatExcel_Click(object sender, EventArgs e)
    {
        HtmlForm form = new HtmlForm();
        string attachment = "attachment; filename=ThongKeTaiLieuTheoNamBoSung_" + DateTime.Now.ToShortDateString() + ".xls";
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
