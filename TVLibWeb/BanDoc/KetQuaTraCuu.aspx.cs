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

public partial class BanDoc_KetQuaTraCuu : WebBase
{
    BanDocInfo oBanDocInfo;
    cBBanDoc oBBanDoc;


    protected void Page_Load(object sender, EventArgs e)
    {
        oBanDocInfo = new BanDocInfo();
        oBBanDoc = new cBBanDoc();
        //Response.Write("bala bala bala bala bala bala bala");
        //if ((!IsPostBack) || (hidEvent.Value == "1"))
        //{
       // ThongBao("1111111111111111111111");
        //Response.Write("hello hello hello hello hello hello hello");
        DoDuLieu();
        SearchLog();
        //  }


        // BindJS
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");

    }
    private void DoDuLieu()
    {
        //Response.Write(Request["ctl00$ContentPlaceHolder1$txtTenDayDu"]);

        if (Request["ctl00$ContentPlaceHolder1$txtTenDayDu"] + "" != "")
        {
            hidTenDayDu.Value = Request["ctl00$ContentPlaceHolder1$txtTenDayDu"];

        }
       // Response.Write(Request["ctl00$ContentPlaceHolder1$txtSoThe"]);
        if (Request["ctl00$ContentPlaceHolder1$txtSoThe"] + "" != "")
        {
            hidSoThe.Value = Request["ctl00$ContentPlaceHolder1$txtSoThe"];

        }
       // Response.Write(Request["ctl00$ContentPlaceHolder1$txtNgaySinh"]);
        if (Request["ctl00$ContentPlaceHolder1$txtNgaySinh"] + "" != "")
        {
            hidNgaySinh.Value = Request["ctl00$ContentPlaceHolder1$txtNgaySinh"];

        }
       // Response.Write(Request["ctl00$ContentPlaceHolder1$txtNgayCapThe"]);
        if (Request["ctl00$ContentPlaceHolder1$txtNgayCapThe"] + "" != "")
        {
            hidNgayCapThe.Value = Request["ctl00$ContentPlaceHolder1$txtNgayCapThe"];

        }
      //  Response.Write(Request["ctl00$ContentPlaceHolder1$drdlNganhNghe"]);
        if (Request["ctl00$ContentPlaceHolder1$drdlNganhNghe"] + "" != "0")
        {
            hidNgheNghiep.Value = Request["ctl00$ContentPlaceHolder1$drdlNganhNghe"];

        }
      //  Response.Write(Request["ctl00$ContentPlaceHolder1$drdlDanToc"]);
        if (Request["ctl00$ContentPlaceHolder1$drdlDanToc"] + "" != "")
        {
            hidDanToc.Value = Request["ctl00$ContentPlaceHolder1$drdlDanToc"];

        }
      //  Response.Write(Request["ctl00$ContentPlaceHolder1$drdlGioiTinh"]);
        if (Request["ctl00$ContentPlaceHolder1$drdlGioiTinh"] + "" != "")
        {
            hidGioiTinh.Value = Request["ctl00$ContentPlaceHolder1$drdlGioiTinh"];

        }
       // Response.Write(Request["ctl00$ContentPlaceHolder1$ddlLop"]);
        if (Request["ctl00$ContentPlaceHolder1$ddlLop"] + "" != "")
        {
            hidLop.Value = Request["ctl00$ContentPlaceHolder1$ddlLop"];

        }
       // Response.Write(Request["ctl00$ContentPlaceHolder1$txtNgayHetHan"]);
        if (Request["ctl00$ContentPlaceHolder1$txtNgayHetHan"] + "" != "")
        {
            hidNgayHetHan.Value = Request["ctl00$ContentPlaceHolder1$txtNgayHetHan"];
        }
       // Response.Write(Request["ctl00$ContentPlaceHolder1$lstNhomBanDoc"]);
        if (Request["ctl00$ContentPlaceHolder1$lstNhomBanDoc"] + "" != "")
        {
            hidNhomBanDoc.Value = Request["ctl00$ContentPlaceHolder1$lstNhomBanDoc"];
        }
       // Response.Write(Request["ctl00$ContentPlaceHolder1$ddlKhoas"]);
        if (Request["ctl00$ContentPlaceHolder1$ddlKhoas"] + "" != "")
        {
            hidKhoa.Value = Request["ctl00$ContentPlaceHolder1$ddlKhoas"];
        }
    }

    public void SearchLog()
    {

        DataTable tblTemp;
        string response = "";
        bool blnFound = false;

        string strSQL = "";
        string strWhere = "";
        strSQL = "select BanDocID,SoThe,TenDayDu,convert(varchar,NgaySinh,103) as NgaySinh,Lop,TenNhomBanDoc ,'javascript:document.location.href=\"HoSoBanDoc.aspx?BanDocID=' + convert(varchar,BanDocID) + '\"' as Sua,'KetQuaTraCuu.aspx?BanDocID=' + convert(varchar,BanDocID)   as Xoa from BanDoc , NhomBanDoc where IDNhomBanDoc = NhomBanDocID";


        if (hidTenDayDu.Value != "")
        {
            strWhere = strWhere + " and TenDayDu like N'%" + hidTenDayDu.Value + "%'";
        }

        if (hidSoThe.Value != "")
        {
            strWhere = strWhere + " and SoThe = '" + hidSoThe.Value + "'";
        }

        if (hidNgaySinh.Value != "")
        {
            strWhere = strWhere + " and convert(varchar,NgaySinh,103) = '" + hidNgaySinh.Value + "'";
        }

        if (hidNgayCapThe.Value != "")
        {
            strWhere = strWhere + " and convert(varchar,NgayCap,103) = '" + hidNgayCapThe.Value + "'";
        }

        if (hidNgayHetHan.Value != "")
        {
            strWhere = strWhere + " and convert(varchar,NgayHetHan,103) = '" + hidNgayHetHan.Value + "'";
        }
        if (hidNgheNghiep.Value != "")
        {
            strWhere = strWhere + " and IDNgheNghiep = " + hidNgheNghiep.Value;
        }
        if (hidNhomBanDoc.Value != "")
        {
            strWhere = strWhere + " and IDNhomBanDoc = " + hidNhomBanDoc.Value;
        }
        if (hidDanToc.Value != "0")
        {
            strWhere = strWhere + " and IDDanToc = " + hidDanToc.Value;
        }

        if (hidGioiTinh.Value != "0")
        {
            strWhere = strWhere + " and GioiTinh = '" + hidGioiTinh.Value + "'";
        }

        if (hidKhoa.Value != "")
        {
            strWhere = strWhere + " and Khoa = N'" + hidKhoa.Value + "'";
        }

        if (hidLop.Value != "")
        {
            strWhere = strWhere + " and Lop = N'" + hidLop.Value + "'";
        }
       // Response.Write(strSQL + strWhere);
        tblTemp = oBBanDoc.RunSql(strSQL + strWhere);


        if (tblTemp != null)
        {
            if (tblTemp.Rows.Count > 0)
            {
                lbResult.Text = lbResult.Text + tblTemp.Rows.Count.ToString();
                grvBanDoc.DataSource = tblTemp;
                grvBanDoc.DataBind();
                blnFound = true;
            }

            tblTemp.Dispose();
            tblTemp = null;
        }
        if (blnFound == false)
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "AlertJs", "<script language = 'javascript'>alert('Không tìm thấy dữ liệu!');document.location.href='TimKiemBanDoc.aspx';</script>");
        }
    }


    protected void grvBanDoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        oBanDocInfo.BanDocID = int.Parse(grvBanDoc.DataKeys[e.RowIndex][0].ToString());
        int intKetQua = oBBanDoc.Delete(oBanDocInfo);
        if (intKetQua == 0)
        {
            ThongBao("Xoá bạn đọc thành công!");
            SearchLog();
        }
        else
        {
            ThongBao("Bạn đọc đang mượn tài liệu, không thể xoá!");
        }

    }
    protected void grvBanDoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lb = new Label();
            lb = (Label)(e.Row.FindControl("label2"));
            if (lb != null)
            {
                if (e.Row.DataItem != null)
                {
                    lb.Text = "<a href ='" + DataBinder.Eval(e.Row.DataItem, "Sua").ToString() + "' runnat='server'>  <img src='../Resources/Images/Edit.gif' style ='border:0' />  </a>";
                }
            }
        }
    }
}
