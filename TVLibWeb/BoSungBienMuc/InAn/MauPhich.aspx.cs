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
public partial class MauPhich :WebBase
{
    cBMauPhich ocBMauPhich;
    MauPhichInfo oMauPhich;
    protected void Page_Load(object sender, EventArgs e)
    {
        ocBMauPhich = new cBMauPhich();
        oMauPhich = new MauPhichInfo();
        if(!IsPostBack)
        {
            LoadMauPhich();
        }
        Page.RegisterClientScriptBlock("Js", "<script language='javascript'src='../../Resources/Js/TVLib.js'  ></script>");
        btnXoa.Attributes.Add("onclick","if(confirm('Bạn nhấn Ok để xóa')) return true; else return false;");
    }
    protected void LoadMauPhich()
    {
        oMauPhich.MauPhichID = 0;
        DataTable dtbMauPhich = ocBMauPhich.Get(oMauPhich);
        LoadDropDownList(DrdlTenMau, dtbMauPhich, "TenMauPhich", "MauPhichID", "---Tạo mới---");
    }
    protected void DrdlTenMau_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(int.Parse(DrdlTenMau.SelectedValue.ToString())>0)
        {
            oMauPhich.MauPhichID = int.Parse(DrdlTenMau.SelectedValue.ToString());
            DataTable dtbMauPhich = ocBMauPhich.Get(oMauPhich);
            if(dtbMauPhich.Rows.Count>0)
            {
                txtTenMau.Text=dtbMauPhich.Rows[0]["TenMauPhich"].ToString();
                txtContent.Text = dtbMauPhich.Rows[0]["GiaTri"].ToString();
            }
        }
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        oMauPhich.TenMauPhich = txtTenMau.Text;
        oMauPhich.GiaTri = txtContent.Text;
        int isSuccess = 0;
        if(int.Parse(DrdlTenMau.SelectedValue.ToString())==0)
        {
            //Kiểm tra trùng
            if(txtTenMau.Text!="")
            {
                //DataTable dtbCheckTen = ocBMauPhich.GetMauPhichByTenTemp(txtTenMau.Text);
                //if (dtbCheckTen.Rows.Count > 0)
                //{
                //    ThongBao("Tên mẫu này đã tồn tại");
                //    return;
                //}
                //else
                //{
                    //Thêm mới MauPhich
                    isSuccess = ocBMauPhich.Add(oMauPhich);
                    if (isSuccess > 0)
                    {
                        ThongBao("Thêm mới thành công");
                       
                    }
              //  }
            }
           
        }
        else
        {
            //Cập nhật sửa
            oMauPhich.MauPhichID = int.Parse(DrdlTenMau.SelectedValue.ToString());
            ocBMauPhich.Update(oMauPhich);
            ThongBao("Cập nhật thành công");
        }
        txtContent.Text = "";
        txtTenMau.Text = "";
        LoadMauPhich();
    }
    protected void btnBoqua_Click(object sender, EventArgs e)
    {
        DrdlTenMau.SelectedIndex = 0;
        txtTenMau.Text = "";
        txtContent.Text = "";
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        if(int.Parse(DrdlTenMau.SelectedValue.ToString())>0)
        {
            oMauPhich.MauPhichID=int.Parse(DrdlTenMau.SelectedValue.ToString());
            ocBMauPhich.Delete(oMauPhich);
        }
        LoadMauPhich();
    }
}
