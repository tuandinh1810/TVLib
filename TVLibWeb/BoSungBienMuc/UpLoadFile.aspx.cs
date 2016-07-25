using System;
using System.IO;
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
using System.Data.OleDb;
using TruongViet.TVLib.Business;

public partial class BoSungBienMuc_DownloadFile : WebBase
{
    clsCommon objUpload;
    private System.Data.OleDb.OleDbConnection cnnDuLieuNguon = new System.Data.OleDb.OleDbConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnUpDoc_Click(object sender, EventArgs e)
    {
        string TenFile = FileUpload_Doc.FileName.ToString();
        string[] arrTenFile = TenFile.Split('.');
        if (arrTenFile.Count() > 0)
            TenFile = arrTenFile[0] + DateTime.Now.ToString("ddMMyyyyhhss")+"." + arrTenFile[1];
        //oSlideShowInfo.MoTa = txtMoTa.Text;
        if (FileUpload_Doc.HasFile)
        {
            FileUpload_Doc.PostedFile.SaveAs(Server.MapPath("~/UploadFiles/") + TenFile);
            var resultSummary = string.Empty;
            var folderPath = Server.MapPath("~/UploadFiles/");
            var fileInfo = new FileInfo(Server.MapPath("~/UploadFiles/") + TenFile);
            TaoKetNoiOleDB(cnnDuLieuNguon, "Excel", Server.MapPath("~/UploadFiles/") + TenFile);
            ArrayList arlist = null;
            HienThiDanhSachCacSheet(cnnDuLieuNguon, ref  arlist);
            DataTable dtExcel = GetDuLieuOleDb(cnnDuLieuNguon, "Sheet1$");
        }
        else
        {
            ltMessage.Text = "Không có file upload";
        }
    }
    public DataTable GetDuLieuOleDb(OleDbConnection cnn, string SheetName)
    {
        // Lấy dữ liệu
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbCommand cd = new OleDbCommand();
        cd.CommandText = "select * from [" + SheetName + "]";
        cd.Connection = cnn;
        da.SelectCommand = cd;
        DataSet ds = new DataSet();
        da.Fill(ds, "DuLieuNguon");

        return ds.Tables["DuLieuNguon"];
    }
    public void HienThiDanhSachCacSheet(OleDbConnection cnn, ref ArrayList lst)
    {
        DataTable dt = default(DataTable);
        dt = cnn.GetSchema("tables");
        lst = new ArrayList();
        //lst.Clear();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["TABLE_TYPE"].ToString() == "TABLE")
            {
                //lst.Items.Add(dt.Rows[i]["TABLE_NAME"].ToString().Replace("Print_Titles",""));
                if (dt.Rows[i]["TABLE_NAME"].ToString().IndexOf("Print_Titles") < 0)
                    lst.Add(dt.Rows[i]["TABLE_NAME"]);
            }
        }
    }
    public void TaoKetNoiOleDB(OleDbConnection cnn, string LoaiNguon, string FileName)
    {
        string strKetNoi = "";
        string strFileType = "";
        strFileType = FileName.Substring(FileName.LastIndexOf("."));
        if (LoaiNguon != "Foxpro")
        {
            if (strFileType == ".mdb" | strFileType == ".xls")
            {
                strKetNoi = "Provider=Microsoft.Jet.OLEDB.4.0;";
            }
            else
            {
                strKetNoi = "Provider=Microsoft.ACE.OLEDB.12.0;";
            }
            strKetNoi += "Data source=" + FileName + ";";
            if (strFileType == ".xls" | strFileType == ".xlsx")
            {
                strKetNoi += "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
            }
        }
        else
        {
            strKetNoi = "Provider=VFPOLEDB;Data Source=" + FileName + ";Collating Sequence=machine;";
        }
        if (cnn.State == ConnectionState.Open) cnn.Close();
        cnn.ConnectionString = strKetNoi;
        cnn.Open();
    }

}
