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
    public partial class YeuCauMuon : WebBase
    {
        YeuCauMuonInfo oYeuCauMuonInfo;
        cBYeuCauMuon oBYeuCauMuon;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //if (Request.Cookies["documentIds"] != null)
            //{
            //    var value = Request.Cookies["documentIds"].Value;
            //}
            if(!IsPostBack)
                LoadData();
        }
        private void LoadData()
        {
          
            if (Request.Cookies["documentIds"].Value+""!="")
            {
                
                var IDTaiLieus = Request.Cookies["documentIds"].Value;

                IDTaiLieus = IDTaiLieus.Replace("k", ",");

                if (IDTaiLieus.Length > 0)
                {
                    IDTaiLieus = IDTaiLieus.Substring(0, IDTaiLieus.Length-1);
                    if(Session["TaiLieuIDs"]!=null)
                         Session["TaiLieuIDs"] = Session["TaiLieuIDs"].ToString()+ IDTaiLieus+",";
                        
                    else
                        Session["TaiLieuIDs"] = IDTaiLieus+",";
                }
           string strIDTaiLieu="";
           if (Session["TaiLieuIDs"]  != null)
           {
               strIDTaiLieu = Session["TaiLieuIDs"].ToString();
               if(strIDTaiLieu.LastIndexOf(",")==strIDTaiLieu.Length-1)
                strIDTaiLieu = strIDTaiLieu.Substring(0, strIDTaiLieu.Length-1);
               else
                   strIDTaiLieu = strIDTaiLieu.Substring(0, strIDTaiLieu.Length);
           }

           string sql = "SELECT TaiLieuID,'' AS STT,ISNULL(dbo.TaiLieu_LayNhanDe(TaiLieuID),'') as NhanDe,ISNULL(dbo.GetTruongThongTin(TaiLieuID, 312),'') as TacGia FROM TaiLieu WHERE TaiLieuID IN (" + strIDTaiLieu + ") "; 
                cBTaiLieu_TruongDublin objTaiLieu_TruongDublin = new cBTaiLieu_TruongDublin();
                DataTable dtbResult = objTaiLieu_TruongDublin.RunSql(sql);
                grvTaiLieu.DataSource = dtbResult;
                grvTaiLieu.DataBind();
                for (int i = 0; i < dtbResult.Rows.Count; i++)
                {
                    grvTaiLieu.Rows[i].Cells[0].Text = (i + 1).ToString();
                }
            }
           
        }
        protected void btnYeuCau_Click(object sender, EventArgs e)
        {
            if (Session["IDBanDoc"] + "" != "")
            {
                if (Session["TaiLieuIDs"] + "" != "")
                {
                    try
                    {
                        string IDTaiLieus = Session["TaiLieuIDs"].ToString().Substring(0, Session["TaiLieuIDs"].ToString().Length - 1);
                        string[] arrIDs = IDTaiLieus.Split(',');
                        if (arrIDs.Length > 0)
                        {
                            oYeuCauMuonInfo = new YeuCauMuonInfo();
                            oBYeuCauMuon = new cBYeuCauMuon();
                            oYeuCauMuonInfo.IDBanDoc = int.Parse("0" + Session["IDBanDoc"].ToString());
                            for (int i = 0; i < arrIDs.Length; i++)
                            {
                               
                                oYeuCauMuonInfo.IDTaiLieu = int.Parse(arrIDs[i].ToString());
                                oYeuCauMuonInfo.NgayYeuCau = DateTime.Now;
                                oBYeuCauMuon.Add(oYeuCauMuonInfo);
                            }
                        }
                        ThongBao("Gửi yêu cầu mượn thành công");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
            else
                ThongBao("Bạn cần đăng nhập trước khi gửi yêu cầu mượn");

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["TaiLieuIDs"] = null;
            grvTaiLieu.DataSource = null;
            grvTaiLieu.DataBind();
        }
}
}
