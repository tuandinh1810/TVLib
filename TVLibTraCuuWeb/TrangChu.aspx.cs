using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
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
    public partial class TrangChu : WebBase
    {
        TaiLieuInfo oTaiLieusInfo;
        cBTaiLieu oBTaiLieus;
        BanDocInfo oBanDocInfor;
        cBBanDoc oBanDoc;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            oBTaiLieus = new cBTaiLieu();
            BindJS();
//            imgTimKiem.Visible = false;
            oTaiLieusInfo = new TaiLieuInfo();
            oBTaiLieus = new cBTaiLieu();
            if (Session["IDBanDoc"] == null)
            {
                lblDangNhap.Visible = false;
                lnkDangNhap.Visible = true;
                lnkLogOut.Visible = false;
                lnkTrangCaNhan.Visible = false;
                txtSoThe.Visible = true;
                lblSoThe.Visible = true;
            }
            else
            {
                lblDangNhap.Visible = false;
                lnkDangNhap.Visible = false;
                lnkLogOut.Visible = true;
                lnkTrangCaNhan.Visible = true;
                lnkTrangCaNhan.Text = "<b>Chào mừng bạn " + Session["TenBanDoc"].ToString() + "</b>";
                txtSoThe.Visible = false;
                lblSoThe.Visible = false;
            }
            if (!IsPostBack)
                TimKiem();
//            if (Session["Chuoi"] + "" == "")
//            {
//                //lay du lieu TaiLieus
//                oTaiLieusInfo.TaiLieuID = 0;
//                DataTable dtTemp = oBTaiLieus.GetTop20(oTaiLieusInfo);
//                LayDuLieu(dtTemp);

//            }
//            else
//            {
//                //lbThongBao.Text = "";
//                //lbThongBao.Visible = false;
//                //titleThongBao.Visible = false;
////                imgTimKiem.Visible = true;
//                TimKiem();

//            }
        }
        private void BindJS()
        {
            //lnkGuiYeuCau.Attributes.Add("onclick", "OpenWindow('YeuCauMuon.aspx','YeuCauMuon',600,250,50,50)");
        }
        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            Session["Chuoi"] = null;
            Session["Chuoi"] = Search();
            TimKiem();
            //Page_Load(null, null);
           // ClientScript.RegisterClientScriptBlock(GetType(), "key1", "<script> javascript:top.location.href='TrangChu.aspx?Type=1' </script>");
            //Response.Redirect("TrangChu.aspx?field1=" + ddlFieldName.SelectedValue.ToString() + "&fieldContent1=" + txtSearch.Text + "&operator1=" + ddlToanTu.SelectedValue.ToString() + "&fieldConten2="++"");
        }
        protected string Search()
        {
            string strWhere = "";
            string strSelect = "";
            string strSql = "";
            Boolean bnltemp = false;
            string strTaiLieuID = "";
            //Truong du lieu 1
            strSelect = "SELECT DISTINCT A.TaiLieuID FROM TaiLieu A  " + "WHERE LuuThong = 1 ";
            if(txtSearch.Text!="")
                strWhere = strWhere + FormingSql(1, int.Parse(ddlFieldName.SelectedValue.ToString()), txtSearch.Text.Trim().Replace(" "," and ").Replace(",",""));
            if (txtSearch1.Text != "")
                strWhere = strWhere + FormingSql(int.Parse(ddlToanTu.SelectedValue.ToString()), int.Parse(ddlFieldName1.SelectedValue.ToString()), txtSearch1.Text.Trim().Replace(" "," and ").Replace(",",""));
            if (txtSearch2.Text != "")
                strWhere = strWhere + FormingSql(int.Parse(ddlToanTu1.SelectedValue.ToString()), int.Parse(ddlFieldName2.SelectedValue.ToString()), txtSearch2.Text.Trim().Replace(" "," and ").Replace(",",""));
            
            strSql = strSelect + strWhere;

            strSql = "select *,isnull(dbo.TaiLieu_LayNhanDe(TaiLieuID),'') as NhanDe,isnull(dbo.GetTruongThongTin(TaiLieuID,520),'') as NgayXuatBan,isnull(dbo.GetTruongThongTin(TaiLieuID,519),'') as NhaXuatBan,isnull(dbo.GetTruongThongTin(TaiLieuID, 312),'') as TacGia FROM TaiLieu where LuuThong = 1 and TaiLieuID IN(" + strSql + ") ORDER BY TaiLieuID DESC";
            return strSql;

        }
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        protected string FormingSql(int intOperation, int intMetadataID, string strSearch)
        {

            string strTemp = "";
            string strFinalSql = "";
            if (intMetadataID == 0)
            {
                strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID=B.IDTaiLieu WHERE Contains(DisplayEntry,N'"+ strSearch+"') ";
            }
            else
            {
                if (intMetadataID == 1)
                    // nhan de
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 449 AND Contains(DisplayEntry,N'" + strSearch + "')";
                else if (intMetadataID == 2) // tac gia
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE (IDMarcField = 312 OR IDMarcField=330) AND Contains(DisplayEntry,N'" + strSearch + "')";
                else if (intMetadataID == 3) // Dong tac gia
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE (IDMarcField = 1443 OR IDMarcField=1399) AND Contains(DisplayEntry,N'" + strSearch + "')";
                else if (intMetadataID == 4) // mo ta
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 911  AND Contains(DisplayEntry,N'" + strSearch + "')";
                else if (intMetadataID == 5) // Nha xuat ban
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 519 AND Contains(DisplayEntry,N'" + strSearch + "')";
                else if (intMetadataID == 6) // tu khoa
                    strTemp = "SELECT A.TaiLieuID FROM TaiLieu A LEFT JOIN TaiLieu_MarcField B ON A.TaiLieuID = B.IDTaiLieu WHERE IDMarcField = 1342 AND Contains(DisplayEntry,N'" + strSearch + "')";
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
            //lay du lieu TaiLieus
            lbRersult.Visible = false ;
            oTaiLieusInfo.TaiLieuID = 0;
            DataTable dtTemp = oBTaiLieus.GetTop20(oTaiLieusInfo);
            LayDuLieu(dtTemp);
           // ClientScript.RegisterClientScriptBlock(GetType(), "key2", "<script> javascript:parent.Main.location.href='KetQuaTimKiem.aspx?type=1' </script>");
        }
        private void LayDuLieu(DataTable dtTemp)
        {
            if (dtTemp != null)
            {

                grvTaiLieu.DataSource = dtTemp;
                grvTaiLieu.DataBind();
                //if (lbThongBao.Text == "")
                //{
                    if (dtTemp.Rows.Count > 0)
                    {
                       // lbThongBao.Text = " KẾT QUẢ TÌM KIẾM";
                        //titleThongBao.Visible = true;
                        lbRersult.Visible = true;
                        lbRersult.Text = dtTemp.Rows.Count.ToString() + "   kết quả";
                    }
                    else
                    {
                        lbRersult.Visible = false;
                        //lbThongBao.Text = "KHÔNG TÌM THẤY KẾT QUẢ";
                        //titleThongBao.Visible = false;
                    }
               // }
            }
        }
        private void TimKiem()
        {
            if (Session["Chuoi"] + "" == "")
            {
                //lay du lieu TaiLieus
                oTaiLieusInfo.TaiLieuID = 0;
                DataTable dtTemp = oBTaiLieus.GetTop20(oTaiLieusInfo);
                LayDuLieu(dtTemp);

            }
            else
            {
                cBTaiLieu_TruongDublin objTaiLieu_TruongDublin = new cBTaiLieu_TruongDublin();
                DataTable dtbResult = objTaiLieu_TruongDublin.RunSql(Session["Chuoi"] + "");
                if (dtbResult != null)
                {
                    LayDuLieu(dtbResult);
                }
            }
        }

        protected void grvTaiLieu_RowCreated(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lb = new Label();
                lb = (Label)(e.Row.FindControl("lbNhanDe"));
                if (lb != null)
                {
                    if (e.Row.DataItem != null)
                    {
                        lb.Text = "<a href ='TaiLieuChiTiet.aspx?TaiLieuID=" + DataBinder.Eval(e.Row.DataItem, "TaiLieuID").ToString() + "'" + " runnat='server'>  " + DataBinder.Eval(e.Row.DataItem, "NhanDe").ToString() + "  </a>";
                    }
                }
            }
        }

        protected void grvTaiLieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTaiLieu.PageIndex = e.NewPageIndex;
            TimKiem();
           
        }

        protected void lnkDangNhap_Click(object sender, EventArgs e)
        {
            TimKiem();
            if (txtSoThe.Text != "")
            {
                oBanDoc = new cBBanDoc();
                DataTable dtbBanDoc = oBanDoc.GetBySoThe(txtSoThe.Text);
                if (dtbBanDoc.Rows.Count > 0)
                {
                    lblDangNhap.Visible = false;
                    lnkLogOut.Visible = true;
                    txtSoThe.Visible = false;
                    lblSoThe.Visible = false;
                    lnkDangNhap.Visible = false;
                    
                    //lblDangNhap.Text = "Chào mừng : Bạn " + dtbBanDoc.Rows[0]["TenDayDu"].ToString();
                    Session["IDBanDoc"] = dtbBanDoc.Rows[0]["BanDocID"].ToString();
                    Session["TenBanDoc"] = dtbBanDoc.Rows[0]["TenDayDu"].ToString();
                    Session["SoThe"] = txtSoThe.Text;
                    lnkTrangCaNhan.Visible = true;
                    lnkTrangCaNhan.Text = "<b>Chào mừng bạn " + Session["TenBanDoc"].ToString() + "</b>";
                    
                }
                else
                {
                    txtSoThe.Visible = true;
                    lnkDangNhap.Visible = true;
                    lnkTrangCaNhan.Visible = false;
                    lnkLogOut.Visible = false;
                    lblSoThe.Visible = true;
                    lblDangNhap.Visible = false;
                    ClientScript.RegisterClientScriptBlock(GetType(), "jsThongBao", "<script> alert('Số thẻ không tồn tại'); </script>");
                }
            }
        }
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            TimKiem();
             Session["IDBanDoc"] = null;
            Session["TenBanDoc"] = null;
            txtSoThe.Visible = true;
            lnkDangNhap.Visible = true;
            lblSoThe.Visible = true;
            lblDangNhap.Visible = false;
            lnkLogOut.Visible = false;
            lnkTrangCaNhan.Visible = false;
            
        }
        protected void lnkTrangCaNhan_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrangCaNhan.aspx");
        }
}
}
