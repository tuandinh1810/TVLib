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

public partial class QuanTriHeThong_KetQuaTraCuuLog : WebBase
{
    private cBNhatKyHeThong oBLog;
    private NhatKyHeThongInfo oLogInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        oLogInfo = new NhatKyHeThongInfo();
        oBLog = new cBNhatKyHeThong();
        SearchLog();
    }
    public void SearchLog()
    {
        string strWord, strFromDate, strToDate, strFromTime, strToTime,strPhanHeIDs, strGroupIDs, strUserNames;

        DataTable tblTemp;
        bool blnFound = false;

        if (Request["ctl00$ContentPlaceHolder1$txtWord"]+"" != "")
        {
            hidWord.Value = Request["ctl00$ContentPlaceHolder1$txtWord"];
        }
        if (Request["ctl00$ContentPlaceHolder1$txtFromDate"]+"" != "")
        {
            hidFromDate.Value = Request["ctl00$ContentPlaceHolder1$txtFromDate"];
        }
        if (Request["ctl00$ContentPlaceHolder1$txtToDate"] + "" != "")
        {
            hidToDate.Value = Request["ctl00$ContentPlaceHolder1$txtToDate"];
        }

        if (Request["ctl00$ContentPlaceHolder1$lsbPhanHe"] + "" != "")
        {
            hidPhanHe.Value = Request["ctl00$ContentPlaceHolder1$lsbPhanHe"];
        }
        if (Request["ctl00$ContentPlaceHolder1$lsbGroup"] + "" != "")
        {
            hidGroup.Value = Request["ctl00$ContentPlaceHolder1$lsbGroup"];
        }
        
        if (Request["ctl00$ContentPlaceHolder1$lsbUser"]+"" != "")
        {
            hidUser.Value = Request["ctl00$ContentPlaceHolder1$lsbUser"];
        }

        strWord = hidWord.Value;
        strFromDate = hidFromDate.Value;
        strToDate = hidToDate.Value;
        strFromTime = hidFromTime.Value;
        strToTime = hidToTime.Value;
        strGroupIDs = hidGroup.Value;
        strPhanHeIDs = hidPhanHe.Value;
        strUserNames = hidUser.Value;


        //  oBLog.Message = strWord;
        //   oBLog.EventGroupIDs = strGroupIDs;
        //   oBLog.UserNames = strUserNames;
        //if  ( strFromDate == "" )
        //{
        //    oBLog.LogTimeFrom = strFromDate;
        //}
        //if (strToDate == "")
        //{
        //    oBLog.LogTimeTo = strToDate;
        //}

        tblTemp = oBLog.Search(strPhanHeIDs,strGroupIDs, strWord, strFromDate, strToDate, strUserNames);


        if (tblTemp != null)
        {
            if (tblTemp.Rows.Count > 0)
            {
                GridView1.DataSource = tblTemp;
                GridView1.DataBind();
                blnFound = true;
            }

            tblTemp.Dispose();
            tblTemp = null;
        }
        if (blnFound == false)
        {
            ClientScript.RegisterClientScriptBlock(GetType(),"AlertJs", "<script language = 'javascript'>alert('Không tìm thấy dữ liệu!');document.location.href='TraCuuLog.aspx';</script>");
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        SearchLog();
    }
}
