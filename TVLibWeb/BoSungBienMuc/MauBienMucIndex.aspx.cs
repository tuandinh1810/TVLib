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

public partial class BoSungBienMuc_MauBienMucIndex : WebBase
{
    private cBMauBienMuc oBMauBienMuc;
    private MauBienMucInfo pMauBienMucInfo;
    private cBLoaiTaiLieu oBLoaiTaiLieu;
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        pMauBienMucInfo = new MauBienMucInfo();
        oBMauBienMuc = new cBMauBienMuc();
        oBLoaiTaiLieu = new cBLoaiTaiLieu();
        pMauBienMucInfo.MauBienMucID = 0;
        if (!IsPostBack)
        {
            lsbMauBienMuc.DataSource = oBMauBienMuc.Get(pMauBienMucInfo);
            lsbMauBienMuc.DataBind();
        }
        if (Request["TaoMauBM"] + "" != "")
        {
            btnUpdate.Visible = false;
            btnTaoMoi.Visible = true;
            btnCapNhat.Visible = true;
            btnDelete.Visible = true;
        }
        else
        {
            btnUpdate.Visible = true;
            btnTaoMoi.Visible = false;
            btnCapNhat.Visible = false;
            btnDelete.Visible = false;
        }
        LoadLoaiTaiLieu();
    }

    private void LoadLoaiTaiLieu()
    {
        LoaiTaiLieuInfo oLoaiTaiLieuInfo = new LoaiTaiLieuInfo();
        LoadDropDownList(drdlLoaiTaiLieu, oBLoaiTaiLieu.Get(oLoaiTaiLieuInfo), "TenLoaiTaiLieuFull", "LoaiTaiLieuID", "");
        if (Request["IDLoaiTaiLieu"] + "" != "")
            drdlLoaiTaiLieu.SelectedValue = Request["IDLoaiTaiLieu"].ToString();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (lsbMauBienMuc.SelectedIndex >= 0)
        {
            if (drdlLoaiTaiLieu.SelectedValue + "" != "")
                ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript'>self.location.href='BienMucMarc.aspx?IDMauBienMuc=" + lsbMauBienMuc.SelectedValue.ToString() + "&IDLoaiTaiLieu=" + drdlLoaiTaiLieu.SelectedValue.ToString() + "';</script>");
            else
            {
                ThongBao("Bạn phải chọn loại tài liệu trước khi biên mục tài liệu!");
            }
            //ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript'>self.location.href='BienMucMarc.aspx?IDMauBienMuc=" + lsbMauBienMuc.SelectedValue.ToString() + "';</script>");
        }
    }
    protected void btnTaoMoi_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript'>self.location.href='MauBienMuc_Marc21.aspx';</script>");
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        if (lsbMauBienMuc.SelectedIndex >= 0)
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script language='javascript'>self.location.href='CapNhatMauBienMuc.aspx?MauBienMucID=" + lsbMauBienMuc.SelectedValue.ToString() + "';</script>");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (lsbMauBienMuc.SelectedIndex >= 0)
        {
            pMauBienMucInfo.MauBienMucID = int.Parse(lsbMauBienMuc.SelectedValue.ToString());
            try
            {
                oBMauBienMuc.Delete(pMauBienMucInfo);
                ThongBao("Xóa mẫu biên mục thành công!");
                pMauBienMucInfo.MauBienMucID = 0;
                lsbMauBienMuc.DataSource = oBMauBienMuc.Get(pMauBienMucInfo);
                lsbMauBienMuc.DataBind();
            }
            catch (Exception exp)
            {
                ThongBao("Mẫu biên mục đang dùng ko thể xóa!");
            }
        }
    }
}
