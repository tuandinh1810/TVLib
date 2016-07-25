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

public partial class BoSungBienMuc_InAn_BarcodesPrint : System.Web.UI.Page
{
   private object[] ObjBarCodeImg;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Session["ChuoiMaXG"]);
        object[] objData =(object[])Session["ChuoiMaXG"].ToString().Split(',');
        MakeImgBarcode(objData, 3, 1, 80, int.Parse("0" + Session["KieuBarcode"]), "", "", "", 0);
        objData = ObjBarCodeImg;
        lblDisplay.Text = GenBarCodeImg(true,1, objData, 4, 0, 0, 0, 3);
        ClientScript.RegisterClientScriptBlock(GetType(), "PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>");
    }
    // GenBarCodeImage method
    // In: some infor
    // Out: string
    private string GenBarCodeImg(bool boolPrintMode, long lngStartPosition, object[] objDataToGen, int intColNumber, int intColSpace, int intRowSpace, int intRotation, int intImageType)
    {
        string tempGenBarCodeImg = null;
        long lngi = 0;
        long lngj = 0;
        long lngk = 0;
        string strDisplay = null;
        strDisplay = "";
        if (objDataToGen != null)
        {
                if (boolPrintMode == true) // Print from lazer printer
                {
                    strDisplay = "<TABLE style='border: dotted 1 #000000' border='1' cellpadding=10 ><TR>";
                    for (lngi = 0; lngi < ((Array)objDataToGen).Length; lngi++) //lngStopID
                    {
                        lngk = lngi + 1;
                        lngj = lngStartPosition + 1;
                        if (!(Session["bc" + (lngi + lngStartPosition)] == null))
                        {
                            Session["bc" + (lngi + lngStartPosition)] = null;
                        }
                        Session["bc" + (lngi + lngStartPosition)] = ((Array)objDataToGen).GetValue(lngi);
                        if (lngk == intColNumber + 1)
                        {
                            strDisplay += "</TR><TR>";
                        }
                        else
                        {
                            if (lngk % intColNumber == 1 && lngk > intColNumber)
                            {
                                strDisplay += "<TR>";
                            }
                        }
                    

                        strDisplay += "<TD><IMG src=PrintBarCode.aspx?i=" + (lngi + lngStartPosition) + "&ImgType=" + intImageType + " &rotate=" + intRotation + "Border=0 ></TD>";
                        if (intColSpace > 0)
                        {
                            strDisplay += "<TD><IMG SRC=../../resources/images/bg.gif WIDTH=" + intColSpace + " HEIGHT=1></TD>";
                        }
                        if (intRowSpace > 0)
                        {
                            if (intColSpace == 0)
                            {
                                strDisplay += "<TR><TD COLSPAN=" + intColNumber + "><IMG SRC=\"../../resources/images/bg.gif\" WIDTH=1 HEIGHT=" + intRowSpace + "></TD></TR>";
                            }
                            else
                            {
                                strDisplay += "<TR><TD COLSPAN=" + 2 * intColNumber + "><IMG SRC=\"../../resources/images/bg.gif\" WIDTH=1 HEIGHT=" + intRowSpace + "></TD></TR>";
                            }
                        }
                        if (lngk % intColNumber == 0 && lngk >= 2 * intColNumber)
                        {
                            strDisplay += "</TR>";
                        }
                    }
                    strDisplay += "</TABLE>";
                    tempGenBarCodeImg = strDisplay;
                
            }
            else
            {
                return (null);
            }
        }
        return tempGenBarCodeImg;
    }
    public void MakeImgBarcode(object[] Data, byte bytImageType, int intBarWidth, int intHeight, int intType, string strAddondata, string strCaption, string strAddOnCaption, int intRotate)
    {
        object[] ArrRet = null;



        ArrRet = new object[((Array)Data).Length];
        EASYBAROLib.Barcode objBarCode = null;
        objBarCode = new EASYBAROLib.Barcode();
        objBarCode.ThrowDataError = false;
        objBarCode.InvalidDataAction = 3;
        objBarCode.BarcodeType = intType;
        objBarCode.AddOnData = strAddondata;
        objBarCode.Caption = strCaption;
        objBarCode.AddOnCaption = strAddOnCaption;
        objBarCode.Orientation  = System.Convert.ToInt16(intRotate);
        int inti = 0;
        for (inti = 0; inti < ((Array)Data).Length; inti++)
        {
            objBarCode.Data = ((Array)Data).GetValue(inti).ToString();
            if (objBarCode.Orientation == 0 || objBarCode.Orientation == 2)
            {
                ArrRet[inti] = objBarCode.MakeImage(3, intBarWidth, intHeight, true  );
            }
            else
            {
                ArrRet[inti] = objBarCode.MakeImage(bytImageType, intHeight, intBarWidth, true);
            }
        }
        ObjBarCodeImg = ArrRet;

    }


}
