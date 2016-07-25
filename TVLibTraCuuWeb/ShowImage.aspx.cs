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
    public partial class WShowImage : WebBase 
    {

       private const int intMAX_SIZE = 200;
		private const int intAX_JPEG = 3;
		private bool blnIsResized;
		private  GflAx193.GflAx objImage =  new GflAx193.GflAx();
		private int dblNewWidth;
		private int dblNewHeight;
		private string strURL;
		private FiLesInfo oFileInfo = new FiLesInfo ();
        private cBFiLes oBFiles= new cBFiLes ();

	
		private void Page_Load(object sender, System.EventArgs e)
		{
           
	
			DataTable tblEdata = null;
			Response.ClearContent();
			Response.Expires = 0;
			Response.ContentType = "image/jpeg";

			if (Request["FileID"] + "" !="")
			{
                oFileInfo.FileID = int.Parse(Request["FileID"] + "");
				tblEdata = oBFiles.Get(oFileInfo);
				if (tblEdata != null && tblEdata.Rows.Count > 0)
				{
					strURL = tblEdata.Rows[0]["DuongDanVatLy"].ToString();
				}
			}

			if (! (strURL == ""))
			{
                //??
                try
                {
                    ShowImage();
                }
                catch{
                    ThongBao("Không tồn tại đường dẫn file trên máy chủ");
                }
			}
		}

		

		// ShowImage method
		// Purpose: show image in detail
		private void ShowImage()
		{
			// Show image
			objImage.EnableLZW = true;
			objImage.LoadBitmap(strURL);
			dblNewWidth = objImage.Width;
			dblNewHeight = objImage.Height;

			blnIsResized = false;
			if (dblNewWidth > intMAX_SIZE)
			{
				blnIsResized = true;
				dblNewWidth = intMAX_SIZE;
				dblNewHeight = (dblNewWidth * objImage.Height) / objImage.Width;
			}
			if (dblNewHeight > intMAX_SIZE)
			{
				blnIsResized = true;
				dblNewWidth = (dblNewWidth * intMAX_SIZE) / dblNewHeight;
				dblNewHeight = intMAX_SIZE;
			}

            if (blnIsResized)
            {
                objImage.Resize(72, 105); //Resize the picture
            }
			objImage.FontName = "arial";
			objImage.FontSize = 13;
			objImage.FontBold = true;
			//objImage.TextOut("DLIB", 2, 2, BitConverter.ToUInt32(BitConverter.GetBytes(Microsoft.VisualBasic.Information.RGB(255, 255, 255)), 0)); //Write library version on the picture
            objImage.SaveFormat = GflAx193.AX_SaveFormats.AX_JPEG;

			Response.ContentType = "image/jpeg";
			Response.BinaryWrite((byte[])objImage.SendBinary());

			// Release objects
			objImage = null;
		}

		
		
		
    }
}
