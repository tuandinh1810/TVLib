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
public partial class BoSungBienMuc_BaoCaoThongKe_BaoCaoTaiLieuTheoNXB : WebBase
{
    private cBTaiLieu_MarcField obTaiLieu_MarcField = new cBTaiLieu_MarcField();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnIn_Click(object sender, EventArgs e)
    {
        string sql = "SELECT dbo.TaiLieu_LayNhanDe (A.IDTaiLieu) AS NhanDe,Count(*) AS  SoLuong,DisplayEnTry AS NamXuatBan " +
                   "FROM TaiLieu_MarcField A " +
                   "LEFT JOIN MaXepGia B ON A.IDTaiLieu=B.IDTaiLieu WHERE IDMarcField=520 ";
        if(txtNamXuatBan.Text+""!="")
            sql=sql+" AND DisplayEnTry='"+ txtNamXuatBan.Text +"'";
        if(txtNamBoSung.Text+""!="")
            sql = sql + " AND Year(NgayXepGia)=" + txtNamBoSung.Text + "";
        sql = sql + "GROUP BY A.IDTaiLieu,DisplayEnTry ORDER BY A.IDTaiLieu";
        DataTable dtbTaiLieuTK=obTaiLieu_MarcField.RunSql(sql);
        grvTaiLieu.DataSource = dtbTaiLieuTK;
        grvTaiLieu.DataBind();
    }
    protected void grvTaiLieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTaiLieu.PageIndex = e.NewPageIndex;
        btnIn_Click(null,null);
    }
}
