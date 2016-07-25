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
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Business;

public partial class MauPhieu :WebBase
{
    cBMauPhieu ocBMauPhieu;
    MauPhieuInfo oMauPhieu;
    protected void Page_Load(object sender, EventArgs e)
    {
        ocBMauPhieu = new cBMauPhieu();
        oMauPhieu = new MauPhieuInfo();
        Page.RegisterClientScriptBlock("Js", "<script language='javascript' src='../Resources/Js/TVLib.js'  ></script>");
    }
    protected void DrdlTenMau_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(DrdlTenMau.SelectedValue.ToString()) > 0)
        {
            oMauPhieu.MauPhieuID = 0;
            DataTable dtbMauPhieu = ocBMauPhieu.Get(oMauPhieu);
            if (dtbMauPhieu.Rows.Count > 0)
            {
                dtbMauPhieu.DefaultView.RowFilter = "LoaiPhieu =" + DrdlTenMau.SelectedValue.ToString();
                if (dtbMauPhieu.DefaultView.Count > 0)
                {
                    txtContent.Text = dtbMauPhieu.DefaultView[0]["NoiDung"].ToString();
                    txtTenMauPhieu.Text = dtbMauPhieu.DefaultView[0]["TenMauPhieu"].ToString();
                    hidID.Value = dtbMauPhieu.DefaultView[0]["MauPhieuID"].ToString();
                }
                else
                {
                    txtContent.Text = "";
                    hidID.Value = "0";
                }
            }
            else
            {
                txtContent.Text = "";
                hidID.Value = "0";
            }
            txtTenMauPhieu.Text = DrdlTenMau.SelectedItem.Text;
        }
        else
        {
            txtContent.Text = "";
            hidID.Value = "0";
            txtTenMauPhieu.Text = "";
        }
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        if (int.Parse(DrdlTenMau.SelectedValue.ToString()) > 0)
        {
            if (txtContent.Text != "" && txtTenMauPhieu.Text != "")
            {
                oMauPhieu.NoiDung = txtContent.Text;
                oMauPhieu.NgayTao = DateTime.Now;
                oMauPhieu.LoaiPhieu = int.Parse(DrdlTenMau.SelectedValue.ToString());
                oMauPhieu.TenMauPhieu = txtTenMauPhieu.Text;
                int isSuccess = 0;
                if (int.Parse(hidID.Value) == 0)
                {
                    //thêm mới
                    if (txtContent.Text != "")
                    {
                        isSuccess = ocBMauPhieu.Add(oMauPhieu);
                        if (isSuccess > 0)
                        {
                            ThongBao("Thêm mới thành công");
                        }
                    }
                }
                else
                {
                    //Cập nhật sửa
                    oMauPhieu.MauPhieuID = int.Parse(hidID.Value);
                    ocBMauPhieu.Update(oMauPhieu);
                    ThongBao("Cập nhật thành công");
                }
                txtContent.Text = "";
                txtTenMauPhieu.Text = "";
            }
            else
                ThongBao("Bạn chưa nhập đủ thông tin!");
        }
        else
            ThongBao("Bạn chưa chọn loại phiếu!");
    }
    protected void btnBoqua_Click(object sender, EventArgs e)
    {
        DrdlTenMau.SelectedIndex = 0;
        txtContent.Text = "";
        hidID.Value = "0";
        txtTenMauPhieu.Text = "";
    }
   
}
