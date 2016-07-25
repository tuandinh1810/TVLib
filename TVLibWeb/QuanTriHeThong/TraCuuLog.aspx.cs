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

public partial class QuanTriHeThong_TraCuuLog : WebBase 
{
    
    private cBChucNang oBChucNang;
    private ChucNangInfo oChucNangInfo = new ChucNangInfo();
    private cBNguoiDung oBNguoiDung;
    private NguoiDungInfo oNguoiDungInfo = new NguoiDungInfo();
    private PhanHeInfo oPhanHeInfo = new PhanHeInfo();
    private cBPhanHe oBPhanHe;
    protected void Page_Load(object sender, EventArgs e)
    {
        oBChucNang = new cBChucNang();
        oBNguoiDung = new cBNguoiDung();
        oBPhanHe = new cBPhanHe();
        LoadForm();
        btnSearch.Attributes.Add("OnClick", "document.forms[0].method='Post';document.forms[0].action='KetQuaTraCuuLog.aspx'; document.forms[0].submit(); return false;");

    }
    public void LoadForm()
    {
         DataTable tblTemp ;
    
           // Create event listbox
         tblTemp = oBPhanHe.Get(oPhanHeInfo);
         tblTemp = InsertOneRow(tblTemp, "-----Chọn-----", 0, 0);
           if (tblTemp != null)
           {
               if (tblTemp.Rows.Count > 0)
               {
                   lsbPhanHe.DataSource = tblTemp;
                   lsbPhanHe.DataTextField = "TenPhanHe";
                   lsbPhanHe.DataValueField = "PhanHeID";
                   lsbPhanHe.DataBind();
                   tblTemp.Clear();
               }
           }

            // Create event listbox
            tblTemp = oBChucNang.GetByPhanHe (oChucNangInfo);
            tblTemp = InsertOneRow(tblTemp, "-----Chọn-----", 0, 0);
           if (tblTemp != null)
           {
               if (tblTemp.Rows.Count > 0)
               {
                lsbGroup.DataSource = tblTemp;
                lsbGroup.DataTextField = "TenChucNang";
                lsbGroup.DataValueField = "ChucNangID";
                lsbGroup.DataBind();
                tblTemp.Clear();
               }
           }
           // Create user listbox

             tblTemp = oBNguoiDung.Get(oNguoiDungInfo);
             tblTemp = InsertOneRow(tblTemp, "-----Chọn-----", 0, 0);
          if (tblTemp != null)
           {
               lsbUser.DataSource = tblTemp;
               lsbUser.DataTextField = "TenNguoiDung";
                lsbUser.DataValueField = "TenDangNhap";
                lsbUser.DataBind();
          }

         
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}
