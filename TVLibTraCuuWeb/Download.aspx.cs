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
using System.IO;

namespace TVLibTraCuuWeb
{
    public partial class WDownload : WebBase 
    {
        cBFiLes objFiles = new cBFiLes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int intKetQua= CheckUser();
                if (intKetQua == 1)
                {
                    TaiFile();
                }
                else if (intKetQua == 2)
                {
                    ThongBao("Số tiền trong tài khoản không đủ để mua down tài liệu này!");
                }
                else if (intKetQua == 3)
                {
                    ThongBao("Tài khoản không được phép down tài liệu!");
                }
                else
                {
                   // ClientScript.RegisterClientScriptBlock(GetType(), "Key", "<script language='javascript'> top.location.href='DangNhap.aspx'; </script>");
                    Response.Redirect("DangNhap.aspx");
                }

            }
        }
        private int   CheckUser()
        {
            if (Session["TaiKhoanID"] != null)
            {
                return objFiles.CheckUser_DownloadFile(int.Parse(Session["TaiKhoanID"].ToString()), int.Parse(Request["FileID"].ToString()));
            }
            else
            {
                return objFiles.CheckUser_DownloadFile(0, int.Parse(Request["FileID"].ToString()));
            }
        }
        protected void TaiFile()
        {
          
            DataTable dtbFile;
            string strFullName = "";
            string strFileExtenxion = "";
            string strFileContentType = "";
            int intFileID = 0;
            FileInfo objFileInfor;
            FiLesInfo objFilesInFor = new FiLesInfo();
            if (Request["FileID"] != null)
            {
                if (Request["FileID"].ToString() != "")
                {
                    intFileID = int.Parse(Request["FileID"].ToString());
                    dtbFile = objFiles.GetFileExisted(intFileID);
                    if (dtbFile.Rows.Count > 0)
                    {
                        strFullName = dtbFile.Rows[0]["DuongDanVatLy"].ToString();
                        objFileInfor = new FileInfo(strFullName);
                        if (objFileInfor.Exists)
                        {
                            strFileExtenxion = dtbFile.Rows[0][objFilesInFor.strDangFile].ToString();
                            switch (strFileExtenxion)
                            {
                                case "pdf":
                                    strFileContentType = "application/pdf";
                                    break;
                                case "doc":
                                    strFileContentType = "application/msword";
                                    break;
                                case "txt":
                                    strFileContentType = "text/plain";
                                    break;
                                case "rtf":
                                    strFileContentType = "application/rtf";
                                    break;
                                case "html":
                                    strFileContentType = "text/html";
                                    break;
                                case "htm":
                                    strFileContentType = "text/html";
                                    break;
                                case "xls":
                                    strFileContentType = "application/vnd.ms-excel";
                                    break;
                                case "ppt":
                                    strFileContentType = "application/vnd.ms-powerpoint";
                                    break;
                                case "jpg":
                                    strFileContentType = "image/jpeg";
                                    break;
                                case "gif":
                                    strFileContentType = "application/gif";
                                    break;
                                case "png":
                                    strFileContentType = "application/png";
                                    break;
                                default:
                                    strFileContentType = "application/x-application";
                                    break;
                            }
                            // Clear the current output content from the buffer
                            Response.Clear();

                            // Add the header that specifies the default filename 
                            //for the Download/SaveAs dialog
                            Response.AddHeader("Content-Disposition", "attachment; filename=" + objFileInfor.Name);

                            //Add the header that specifies the file size, so that the 
                            //browser can show the download progress
                            Response.AddHeader("Content-Length", objFileInfor.Length.ToString());

                            //Specify that the response is a stream that cannot be read _
                            //by the client and must be downloaded
                            Response.ContentType = strFileContentType;

                            //Send the file stream to the client
                            Response.WriteFile(objFileInfor.FullName);

                            //Release objects
                            objFileInfor = null;
                            dtbFile = null;

                            //Stop the execution of this page
                            Response.End();
                        }
                    }
                }
            }
        }
    }
}
