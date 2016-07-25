using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
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
using System.IO;
using System.Net.Mime;
using System.Drawing;
using Aspose.Words;
class MarcField
{
    public string Field { get; set; }
    public string Value { get; set; }
}
public partial class BoSungBienMuc_XemBieuGhiBienMuc : WebBase
{
    private string IDTaiLieu;
    protected void Page_Load(object sender, EventArgs e)
    {
        List<MarcField> lst_Marc = new List<MarcField>();
        for (int i = 0; i < 17; i++)
        {
            //MarcField objField = new MarcField();
            //objField.Field = "";

        }
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",3,") >= 0)
            btnXepGia.Enabled = true;
        else
            btnXepGia.Enabled = false;

        if (Request["IDTaiLieu"] + "" != "")
        {
            IDTaiLieu = Request["IDTaiLieu"].ToString();
            LoadCatalog();
        }

        //btnDong.Attributes.Add("OnClick", "javascript:if (parent.window && ! parent.window.closed) { parent.opener.document.forms[0].hidChucNang.value='LoadBackBienMuc';parent.opener.document.forms[0].submit();parent.self.close();} else parent.self.close();");
    }
    protected void LoadCatalog()
    {
        cBTaiLieu_MarcField oBTaiLieu_MarcField = new cBTaiLieu_MarcField();
        DataTable dtbCatalog = oBTaiLieu_MarcField.GetByIDTaiLieu(int.Parse(IDTaiLieu), "");
        lblISBD.Text = HienThiISBD(dtbCatalog) + HienThiMGX();

        TableRow tbleRow;
        TableCell tblCell;

        // Tao Header
        //Tao cot ten truong
        tbleRow = new TableRow();
        tblCell = new TableCell();
        tblCell.HorizontalAlign = HorizontalAlign.Left;
        tblCell.Width = Unit.Pixel(130);
        tblCell.Text = "Tên trường";
        tblCell.ForeColor = Color.Blue;
        tblCell.Font.Size = FontUnit.Larger;
        tbleRow.Cells.Add(tblCell);

        //Tao cot noi dung truong dublin
        tblCell = new TableCell();
        tblCell.HorizontalAlign = HorizontalAlign.Left;
        tblCell.Text = "Nội dung";
        tblCell.Width = Unit.Pixel(800);
        tblCell.ForeColor = Color.Blue;
        tblCell.Font.Size = FontUnit.Larger;
        tbleRow.Cells.Add(tblCell);
        tbleRow.CssClass = "TVLibGridCell";
        tblViewCata.Rows.Add(tbleRow);

        Label lbl;
        int IDMarcField = 0;
        for (int i = 0; i < dtbCatalog.Rows.Count; i++)
        {
            //Cot thu tu
            tbleRow = new TableRow();

            if (IDMarcField != int.Parse(dtbCatalog.Rows[i]["IDMarcField"].ToString()))
            {
                //Hien thi ten truong
                IDMarcField = int.Parse(dtbCatalog.Rows[i]["IDMarcField"].ToString());

                lbl = new Label();
                tblCell = new TableCell();
                tblCell.HorizontalAlign = HorizontalAlign.Right;
                lbl.Text = dtbCatalog.Rows[i]["Code"].ToString();
                lbl.Font.Bold = true;
                lbl.CssClass = "TVLibLabel";
                tblCell.HorizontalAlign = HorizontalAlign.Left;
                tblCell.Controls.Add(lbl);
                tbleRow.Cells.Add(tblCell);
            }
            else
            {
                lbl = new Label();
                tblCell = new TableCell();
                lbl.Text = "";
                lbl.CssClass = "TVLibLabel";
                tblCell.HorizontalAlign = HorizontalAlign.Left;
                tblCell.Controls.Add(lbl);
                tbleRow.Cells.Add(tblCell);
            }


            //Cot gia tri
            lbl = new Label();
            tblCell = new TableCell();
            lbl.Text = dtbCatalog.Rows[i]["DisplayEntry"].ToString();
            lbl.CssClass = "TVLibLabel";
            tblCell.HorizontalAlign = HorizontalAlign.Left;
            tblCell.Controls.Add(lbl);
            if (i % 2 == 0)
                tbleRow.CssClass = "TVLibGridAlterCell";
            else
                tbleRow.CssClass = "TVLibGridCell";
            tbleRow.Cells.Add(tblCell);
            tblViewCata.Rows.Add(tbleRow);
            tblViewCata.CellSpacing = 2;
            tblViewCata.CellPadding = 5;
            tblViewCata.Width = Unit.Pixel(930);
        }
    }
    private void exportToWord(string strHTMLContent)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.ContentType = "application/msword";
        string strFileName = "DocumentName" + ".doc";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);
        System.Text.StringBuilder bc = new System.Text.StringBuilder(strHTMLContent);
        //   StringBuilder strHTMLContent = new StringBuilder();
        // strHTMLContent.Append(RadEditor1.Content);

        HttpContext.Current.Response.Write(bc);
        HttpContext.Current.Response.End();
        HttpContext.Current.Response.Flush();
    }
    private string HienThiMGX()
    {
        string strMXG = "";
        int intIDTaiLieu = int.Parse(Request["IDTaiLieu"]);
        cBMaXepGia oBMaXepGia = new cBMaXepGia();
        DataTable dtbMaXepGia = oBMaXepGia.Get_MaXepGiaInfo_ByIDTaiLieu(intIDTaiLieu);
        if (dtbMaXepGia.Rows.Count > 0)
        {
            strMXG = "<b>MXG:</b> " + dtbMaXepGia.Rows[0]["MaXepGia"].ToString() + " --- " + dtbMaXepGia.Rows[dtbMaXepGia.Rows.Count - 1]["MaXepGia"].ToString();
        }
        return "<br><br>" + strMXG;
    }
    private string HienThiISBD(DataTable dtbCatalog)
    {
        string strISBD = "";
        if (dtbCatalog.Rows.Count > 0)
        {
            string author = "";

            for (int i = 0; i < dtbCatalog.Rows.Count; i++)
            {
                string code = dtbCatalog.Rows[i]["Code"].ToString();
                string content = dtbCatalog.Rows[i]["DisplayEntry"].ToString();
                if (code.IndexOf("$") > 0)
                {
                    string subField = code.Substring(code.IndexOf("$") + 1, 1);
                    string field = code.Substring(0, code.IndexOf("$"));

                    switch (field)
                    {
                        case "100":
                            if (subField == "a")
                                author = content;
                            break;
                        case "245":
                            if (subField == "a")
                                strISBD = content;
                            else if (subField == "b")
                                strISBD = strISBD + ": " + content;
                            else if (subField == "c")
                                strISBD = strISBD + "/ " + content + author;
                            if (strISBD.IndexOf("/") < 0)
                                strISBD = strISBD + "/ " + author;

                            break;
                        case "260":
                            if (subField == "a")
                                strISBD = strISBD + " - " + content;
                            else if (subField == "b")
                                strISBD = strISBD + " . : " + content;
                            else if (subField == "c")
                                strISBD = strISBD + ", " + content;
                            break;
                        case "300":
                            if (subField == "a")
                                strISBD = strISBD + " - " + content;
                            else if (subField == "c")
                                strISBD = strISBD + ".; " + content;
                            break;
                        case "350":
                            if (subField == "a")
                                strISBD = strISBD + "</br></br>" + "<b>Giá:</b> " + content;

                            break;
                    }

                }
            }

        }
        return strISBD;
    }
    protected void btnSua_Click(object sender, EventArgs e)
    {
        Response.Redirect("BienMucMarc.aspx?IDTaiLieu=" + IDTaiLieu + "&IDMauBienMuc=" + Request["IDMauBienMuc"]);
    }
    protected void btnXepGia_Click(object sender, EventArgs e)
    {
        Response.Redirect("XepGia.aspx?IDTaiLieu=" + IDTaiLieu);
    }
    protected void btnDong_Click(object sender, EventArgs e)
    {
        CallJS("BienMuc", "document.location.href='BienMucMarc.aspx?IDLoaiTaiLieu=" + ("" + Request["IDLoaiTaiLieu"]) + "&IDMauBienMuc=" + Request["IDMauBienMuc"] + "';void(0);");
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);
        builder.InsertHtml(lblISBD.Text);

        doc.Save(DateTime.Now.ToString("yyyyMMddhhmmss") + "bieughi_marc.doc", SaveFormat.Doc, SaveType.OpenInWord, System.Web.HttpContext.Current.Response);
        Response.End();
    }
    

}
