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

public partial class QuanTriHeThong_DatCheDoGhiLog : WebBase
{
    private cBPhanHe oBPhanHe;
    private PhanHeInfo oPhanHeInfo = new PhanHeInfo () ;
    private cBChucNang oBChucNang;
    private ChucNangInfo oChucNangInfo = new ChucNangInfo ();
    private cBNhatKyHeThong oBNhatKyHeThong;
    private NhatKyHeThongInfo oNhatKyHeThongInfo = new NhatKyHeThongInfo ();
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        BindScript();
        if (!IsPostBack)
        {
            GetPhanHe();
        }
    }

    private void Initialize()
    {
        oBPhanHe = new cBPhanHe();
        oBChucNang = new cBChucNang();
        oBNhatKyHeThong = new cBNhatKyHeThong();
    }


    private void BindScript()
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "key", "<script language='javascript' src='../Resources/Js/TVLib.js'></script>");
        ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript' src='../Resources/Js/QTHT.js'></script>");
        btnUpdate.Attributes.Add("OnClick", "if(!CheckOptionsNull('dtgEvents', 'chkID', 2, 50, 'Bạn phải chọn ít nhất một chức năng trước khi cập nhật!')) return false;");
    }

    // GetPhanHe method
    // Purpose: lay toan bo phan he
    private void GetPhanHe()
    {
        DataTable tblTemp = new DataTable ();
        oPhanHeInfo.PhanHeID = 0;
        tblTemp = oBPhanHe.Get (oPhanHeInfo);
 
        if (tblTemp != null)
        {
            if (tblTemp.Rows.Count > 0)
            {
                ddlGroup.DataSource = tblTemp;
                ddlGroup.DataTextField = "TenPhanHe";
                ddlGroup.DataValueField = "PhanHeID";
                ddlGroup.DataBind();
                ddlGroup.SelectedIndex = 0;
                GetChucNang();
            }        
        }
    }

    // GetChucNang method
   
    private void GetChucNang()
    {
        DataTable tblTemp = null;

        oChucNangInfo.IDPhanHe = int.Parse (ddlGroup.SelectedValue);
        tblTemp = oBChucNang.GetByPhanHe (oChucNangInfo );

        if (tblTemp != null)
        {
            dtgEvents.DataSource = tblTemp;
                dtgEvents.DataBind();
           
        }
    }


    // dtgEvents_ItemCreated event
    private void dtgEvents_ItemCreated(object sender,  DataGridItemEventArgs e)
    {
        switch (e.Item.ItemType)
        {
            case ListItemType.Item:
            case ListItemType.AlternatingItem:
            case ListItemType.EditItem:
              
                int inti = 0;

                for (inti = 2; inti < e.Item.Cells.Count; inti++)
                {
                    e.Item.Cells[inti].Attributes.Add("onClick", "javascript:CheckOptionVisible('dtgEvents','chkID'," + (e.Item.ItemIndex + 2) + ");");
                }
                break;
        }
    }


    protected void ddlGroup_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GetChucNang();
    }
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        string strChucNangIDs = null;
        int intChucNangID = 0;
        int intCount = 0;
        CheckBox chkTemp = null;


        for (intCount = 0; intCount < dtgEvents.Rows.Count; intCount++)
        {
            if (((CheckBox)(dtgEvents.Rows[intCount].Cells[1].FindControl("chkID"))).Checked)
            {
                intChucNangID = int.Parse(((Label)(dtgEvents.Rows[intCount].Cells[0].FindControl("lblID"))).Text);
                strChucNangIDs = strChucNangIDs + intChucNangID.ToString() + ",";
            }
        }

        if (!(strChucNangIDs == ""))
        {
            strChucNangIDs = strChucNangIDs.Substring(0, strChucNangIDs.Length - 1);

            oBNhatKyHeThong.SetLogMode(int.Parse(ddlGroup.SelectedValue), strChucNangIDs);
            ThongBao("Đặt chế độ ghi log thành công!");
        }
    }
}
