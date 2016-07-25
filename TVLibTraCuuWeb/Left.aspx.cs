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
    public partial class WLeft : WebBase 
    {
        cBFiLes oBFile;
        FiLesInfo oFileInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            oFileInfo = new FiLesInfo();
            oBFile = new cBFiLes();
            if (!IsPostBack )
            {
                GetFiles();
            }
        }
        // get file Information
        private void GetFiles()
        {
            TableRow tblRow = null;
            TableCell tblCell = null;
            DataTable dtTemp = oBFile.GetTop10Download(oFileInfo);           
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                //Add Image
                string strTemp = "";
                switch (dtTemp.Rows[i]["DangFile"].ToString().ToLower())
                {
                    case "jpg":
                    case "bmp":
                    case "png":
                    case "jpeg":
                    case "gif":
                    case "pcx":
                    case "tif":
                    case "jpe":
                        strTemp = "<Img Align='Center' src='ShowImage.aspx?FileID=" + dtTemp.Rows[i]["FileID"] + "' alt='' border='0'/><br>";
                        break;
                    case "mpg":
                    case "avi":
                    case "asf":
                    case "mpeg":
                    case "mov":
                    case "flc":
                    case "mpv":
                    case "swf":
                        strTemp = "<Img Align='Center'   src='ShowImage.aspx?FileID=" + dtTemp.Rows[i]["FileID"] + "' alt='' border='0'/><br>";
                        break;
                    case "doc":
                    case "docx":
                        strTemp = "<Img Align='Center'  Height='110px' src='Resources/Images/Word2007.jpg' Width='80px' /><br>";
                        break;
                    case "xls":
                    case "xlsx":
                        strTemp = "<Img Align='Center'  Height='110px' src='Resources/Images/Excel2007.jpg' Width='80px' /><br>";
                        break;
                    case "txt":
                        strTemp = "<Img Align='Center'  Height='110px' src='Resources/Images/textImage.gif' Width='80px' /><br>";
                        break;
                    case "zip":
                    case "rar":
                    case "iso":
                        strTemp = "<Img Align='Center' Height='110px' src='Resources/Images/winrar.png' Width='80px' /><br>";
                        break;
                    default:
                        strTemp = "&nbsp;";
                        break;
                }
                tblRow = new TableRow();
                tblCell = new TableCell();
                tblCell.HorizontalAlign = HorizontalAlign.Center;
                //  strImg = "<Img Align='Center' src='" + dtTemp.Rows[i]["DuongDanVatLy"].ToString() + "' runat='server' />";
                tblCell.Text = "<a href='#' Style='TEXT-DECORATION: none' onclick=\"javascript:parent.Main.location.href='ShowDetail.aspx?FileID=" + dtTemp.Rows[i]["FileID"] + "&DangFile=" + dtTemp.Rows[i]["DangFile"].ToString().ToLower() + "'\">" + strTemp + "</a>";
                tblRow.Cells.Add(tblCell);
                tblRow.Width = Unit.Percentage(100);
                tblResult.Rows.Add(tblRow);

                tblRow = new TableRow();
                tblCell = new TableCell();
                tblCell.HorizontalAlign = HorizontalAlign.Center;
                tblCell.Text = "<a href='#' Style='TEXT-DECORATION: none' onclick=\"javascript:parent.Main.location.href='ShowDetail.aspx?FileID=" + dtTemp.Rows[i]["FileID"] + "&DangFile=" + dtTemp.Rows[i]["DangFile"].ToString().ToLower() + "'\"><Font Face='Times New Roman' Size='3'>" + dtTemp.Rows[i]["NhanDe"].ToString() + "</Font></a>";
                tblRow.Cells.Add(tblCell);
                tblRow.Width = Unit.Percentage(100);
                tblResult.Rows.Add(tblRow);

                tblRow = new TableRow();
                tblCell = new TableCell();   
                tblCell.HorizontalAlign = HorizontalAlign.Center;
                tblCell.Text = "<Img Align='Center' width='150px'  src='Resources/Images/chi_dangnhap.jpg'/>";
                tblRow.Cells.Add(tblCell);
                tblRow.Width = Unit.Percentage(100);
                tblResult.Rows.Add(tblRow);
                
                tblResult.CellPadding = 5;
                tblResult.CellSpacing = 5;
                tblResult.HorizontalAlign = HorizontalAlign.Center;
                tblResult.Width = Unit.Percentage(100);
            }
        }
    }
}
