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
    public partial class WSearch :  WebBase 
    {
        TaiLieuInfo oTaiLieusInfo;
        cBTaiLieu oBTaiLieus;
        protected void Page_Load(object sender, EventArgs e)
        {
            oBTaiLieus = new cBTaiLieu();
            BindJS();            
        }
        private void BindJS()
        { 

        }     

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
           Session["Chuoi"]= TimKiem();
           //ClientScript.RegisterClientScriptBlock(GetType(), "key1", "<script> javascript:parent.Main.location.href='KetQuaTimKiem.aspx?type=1' </script>");
        }
        protected string TimKiem()
        {
            string strWhere = "";
            string strSelect = "";
            string strSql = "";
            Boolean bnltemp = false;
            string strTaiLieuID = "";
            //Truong du lieu 1
            strSelect = "SELECT DISTINCT A.TaiLieuID FROM TaiLieu A  " + "WHERE LuuThong = 1 ";

            strWhere = strWhere + FormingSql(1, int.Parse(ddlFieldName.SelectedValue.ToString()), txtSearch.Text.Trim());
            strWhere = strWhere + FormingSql( int.Parse(ddlToanTu.SelectedValue.ToString()),int.Parse(ddlFieldName1.SelectedValue.ToString()), txtSearch1.Text.Trim());
            strWhere = strWhere + FormingSql(int.Parse(ddlToanTu1.SelectedValue.ToString()), int.Parse(ddlFieldName2.SelectedValue.ToString()), txtSearch1.Text.Trim());
           
            strSql = strSelect + strWhere;
           
            strSql = "select *,isnull(dbo.TaiLieu_LayNhanDe(TaiLieuID),'') as NhanDe,'' as NgayXuatBan,isnull(dbo.GetTruongThongTin(TaiLieuID, 312),'') as TacGia FROM TaiLieu where LuuThong = 1 and TaiLieuID IN(" + strSql + ")";
            return strSql;

        }
        protected string FormingSql(int intOperation, int intMetadataID, string strSearch)
        {

            string strTemp = "";
            string strFinalSql = "";
            if (intMetadataID == 0)
            {
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID=B.IDTaiLieu WHERE DisplayEntry like N'%" + strSearch + "%'";
            }
            else
            {
                if (intMetadataID==1 )
                    // nhan de
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 449 AND DisplayEntry like N'%" + strSearch + "%'";
                else if (intMetadataID == 2) // tac gia
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE (IDMarcField = 312 OR IDMarcField=330) AND DisplayEntry like N'%" + strSearch + "%'";
                else if (intMetadataID == 3) // Dong tac gia
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE (IDMarcField = 1443 OR IDMarcField=1399) AND DisplayEntry like N'%" + strSearch + "%'";
                else if (intMetadataID == 4) // mo ta
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 911  AND DisplayEntry like N'%" + strSearch + "%'";
                else if (intMetadataID == 5) // Nha xuat ban
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 518 AND DisplayEntry like N'%" + strSearch + "%'";
                else if (intMetadataID == 6) // tu khoa
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 1342 AND DisplayEntry like N'%" + strSearch + "%'";
            }

            switch (intOperation)
            {
                case 1:
                    strFinalSql = " AND A.TaiLieuID IN (" + strTemp + ")";
                    break;
                case 2:
                    strFinalSql = " UNION " + strTemp;
                    break;
                case 3:
                    strFinalSql = " AND A.TaiLieuID NOT IN (" + strTemp + ")";
                    break;
            }
            return strFinalSql;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch1.Text = "";
            txtSearch2.Text = "";
            ddlFieldName.SelectedIndex = 0;
            ddlFieldName1.SelectedIndex = 0;
            ddlFieldName2.SelectedIndex = 0;
            Session["Chuoi"] = "";
           // ClientScript.RegisterClientScriptBlock(GetType(), "key2", "<script> javascript:parent.Main.location.href='KetQuaTimKiem.aspx?type=1' </script>");
        }
    }
}
