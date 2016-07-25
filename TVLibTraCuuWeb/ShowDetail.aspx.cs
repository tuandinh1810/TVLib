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
using TruongViet.TVLibTraCuu.Business;
using TruongViet.TVLibTraCuu.Entity;


namespace TVLibTraCuuWeb
{
    public partial class WShowDetail : WebBase 
    {
        FiLesInfo oFileInfo;
        cBFiLes oBFile;
        protected void Page_Load(object sender, EventArgs e)
        {
            oBFile = new cBFiLes();
            oFileInfo = new FiLesInfo();
            if (Request["FileID"] != null)
            {
                if (Request["FileID"].ToString() != "")
                {
                    ShowDetail();
                    ShowFileLienKet();
                }
            }
        }
        private void ShowFileLienKet()
        {
            
            TableCell tbCell;
            TableRow tbRow;
            // lay thong tin truong dublincore cua file
            oFileInfo.FileID = int.Parse(Request.QueryString["FileID"].ToString());
            DataTable dtTemp = oBFile.GetFileLienKet(oFileInfo);
            if (dtTemp != null)
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    tbCell = new TableCell();                  
                    tbCell.VerticalAlign = VerticalAlign.Top;
                    tbCell.HorizontalAlign = HorizontalAlign.Left;
                    //Add Image

                  
                    // string  strImg = "";
                    string strImg = " &nbsp;&nbsp;&nbsp;<img src='Resources/Images/catid_icon.gif' runat='server' />";

                    tbCell.Text = strImg + " &nbsp;&nbsp;&nbsp;<a href='ShowDetail.aspx?FileID=" + dtTemp.Rows[i]["FileID"] + "&DangFile=" + dtTemp.Rows[i]["DangFile"].ToString().ToLower() + "'>" + dtTemp.Rows[i]["NhanDe"].ToString() + "</a>";
                  tbRow = new TableRow();
                    tbRow.Cells.Add(tbCell);                   

                    tblLienKet.Rows.Add(tbRow);
                }
            }
        }
        private void ShowDetail()
        {
            // lay thong tin truong dublincore cua file
            oFileInfo.FileID = int.Parse(Request.QueryString["FileID"].ToString());
           DataTable dtTemp = oBFile.GetFileDetail(oFileInfo);

            // do du lieu vao bang

           TableRow tbRow = new TableRow();
           TableCell tbCell;
         
           if (dtTemp != null)
           {
               // tao header
               tbRow = new TableRow();

               //tbCell = new TableCell();
               //tbCell.Width = Unit.Percentage(15);
               //tbCell.Text = "<B>MÔ TẢ</B><br><br>";
               //tbRow.Cells.Add(tbCell);
               // tbRow.CssClass = "TVLibPageTitle";
               tbCell = new TableCell();
               tbCell.CssClass = "TVLibPageTitle";
               tbCell.Text = "<B>CHI TIẾT</B>";
               tbRow.Cells.Add(tbCell);
               tblResult.Rows.Add(tbRow);
             
                   //Add Image
                   // tbRow = new TableRow();                
                   tbCell = new TableCell();
                   tbCell.Width = Unit.Percentage(25);
                   tbCell.HorizontalAlign = HorizontalAlign.Center;
                   tbCell.RowSpan = dtTemp.Rows.Count +2;
                   string strTemp = "";
                   if (Request["DangFile"] != null)
                   {
                       switch (Request["DangFile"].ToString().ToLower())
                       {
                           case "jpg":
                           case "bmp":
                           case "png":
                           case "jpeg":
                           case "gif":
                           case "pcx":
                           case "tif":
                           case "jpe":
                               strTemp = "<Img src='ShowImage.aspx?FileID=" + Request["FileID"] + "' alt='' border='0'>";
                               break;
                           case "mpg":
                           case "avi":
                           case "asf":
                           case "mpeg":
                           case "mov":
                           case "flc":
                           case "mpv":
                           case "swf":
                               strTemp = "<Img src='ShowImage.aspx?FileID=" + Request["FileID"] + "' alt='' border='0'>";
                               break;
                           case "doc":
                           case "docx":
                               strTemp = "<img Height='105px' src='Resources/Images/Word2007.jpg' Width='90px' />";
                               break;
                           case "xls":
                           case "xlsx":
                               strTemp = "<img Height='105px' src='Resources/Images/Excel2007.jpg' Width='90px' />";
                               break;
                           case "txt":
                               strTemp = "<img Height='105px' src='Resources/Images/textimage.gif' Width='90px' />";
                               break;
                           case "zip":
                           case "rar":
                           case "iso":
                               strTemp = "<img Height='105px' src='Resources/Images/WinRAR.png' Width='90px' />";
                               break;
                           default:
                               strTemp = "&nbsp;";
                               break;
                       }
                   }
                   tbCell.VerticalAlign = VerticalAlign.Middle ;
                   tbCell.Text = strTemp;
                   tbRow.Cells.Add(tbCell);
                   tblResult.Rows.Add(tbRow);

                   if (dtTemp.Rows.Count > 0)
                   {

                   tbRow = new TableRow();
                   tbCell = new TableCell();
                   tbCell.Text = "<h2 class='IMAGE'>" + dtTemp.Rows[0]["DisplayEntry"].ToString() + "</h2>";
                   tbRow.Cells.Add(tbCell);
                   tblResult.Rows.Add(tbRow);

                   // do du lieu vao tung dong 

                   for (int i = 0; i < dtTemp.Rows.Count; i++)
                   {
                       tbRow = new TableRow();
                       // lay ten truong dublin do vao table
                       tbCell = new TableCell();
                       tbCell.Text = "<p><B>" + dtTemp.Rows[i]["TenTruongDublin"].ToString() + ":</B>" + dtTemp.Rows[i]["DisplayEntry"].ToString() + "</p>";
                    //   tbRow.Cells.Add(tbCell);

                       // lay du lieu truong dublin do vao table
                     //  tbCell = new TableCell();
                     //  tbCell.Text =dtTemp.Rows[i]["DisplayEntry"].ToString();
                       tbRow.Cells.Add(tbCell);

                       tblResult.Rows.Add(tbRow);
                   }
                   // thong tin ve ngay dang file va so lan tai file ve

                   tbRow = new TableRow();
                   tbCell = new TableCell();
                   tbCell.ColumnSpan = 2;
                   string Text = "";
                       // lay thong tin chi tiet cua file
                   oFileInfo.FileID = int.Parse(dtTemp.Rows[0]["IDFile"].ToString());
                   DataTable dtFile =  oBFile.Get(oFileInfo);
                   if (dtFile != null)
                   {
                       if (dtFile.Rows.Count > 0)
                       {
                           Text = Text + "<B>Ngày đăng file: </B>"  + dtFile.Rows[0]["NgayCapNhat"]  ;
                           tbCell.Text = "<B>Số lần tải file: </B>"  + dtFile.Rows[0]["SoLanDownload"] + "<br>" + Text + "<br>";
                           tbCell.Text = tbCell.Text + "<B>Chi phí mua tài liệu: </B>"  + float.Parse(dtFile.Rows[0]["ChiPhi"].ToString()).ToString("N0") ;
                       }
                   }
                   tbRow.Cells.Add(tbCell);
                   tblResult.Rows.Add(tbRow);

                   // download file

                   tbRow = new TableRow();
                   tbCell = new TableCell();
                   Image img = new Image();
                   img.ImageUrl = "Resources/Images/btndownload.jpg";
                   img.Attributes.Add("Onclick", "javascript:document.location.href='Download.aspx?FileID=" + dtTemp.Rows[0]["IDFile"] + "'");
                   img.ToolTip = "Nhấn vào đây để tải file về";
                   tbCell.Controls.Add(img);
                   tbRow.Cells.Add(tbCell);
                   tblResult.Rows.Add(tbRow);
                                 
               }
               else
               {

               }
           }
        }
    }
}
