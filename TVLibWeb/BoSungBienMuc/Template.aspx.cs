﻿using System;
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
public partial class Template :WebBase
{
    cBTemplate ocBTemplate;
    TemplateInfo oTemplate;
    protected void Page_Load(object sender, EventArgs e)
    {
        ocBTemplate = new cBTemplate();
        oTemplate = new TemplateInfo();
        if(!IsPostBack)
        {
            LoadTemplate();
        }
        btnXoa.Attributes.Add("onclick","if(confirm('Bạn nhấn Ok để xóa')) return true; else return false;");
    }
    protected void LoadTemplate()
    {
        oTemplate.TemplateID = 0;
        DataTable dtbTemplate = ocBTemplate.Get(oTemplate);
        LoadDropDownList(DrdlTenMau, dtbTemplate, "TenTemplate", "TemplateID", "---Tạo mới---");
    }
    protected void DrdlTenMau_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(int.Parse(DrdlTenMau.SelectedValue.ToString())>0)
        {
            oTemplate.TemplateID = int.Parse(DrdlTenMau.SelectedValue.ToString());
            DataTable dtbTemplate = ocBTemplate.Get(oTemplate);
            if(dtbTemplate.Rows.Count>0)
            {
                txtTenMau.Text=dtbTemplate.Rows[0]["TenTemplate"].ToString();
                txtContent.Text = dtbTemplate.Rows[0]["GiaTri"].ToString();
            }
        }
    }
    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        oTemplate.TenTemplate = txtTenMau.Text;
        oTemplate.GiaTri = txtContent.Text;
        int isSuccess = 0;
        if(int.Parse(DrdlTenMau.SelectedValue.ToString())==0)
        {
            //Kiểm tra trùng
            if(txtTenMau.Text!="")
            {
                DataTable dtbCheckTen = ocBTemplate.GetTemplateByTenTemp(txtTenMau.Text);
                if (dtbCheckTen.Rows.Count > 0)
                {
                    ThongBao("Tên mẫu này đã tồn tại");
                    return;
                }
                else
                {
                    //Thêm mới Template
                    isSuccess = ocBTemplate.Add(oTemplate);
                    if (isSuccess > 0)
                    {
                        ThongBao("Thêm mới thành công");
                    }
                }
            }
           
        }
        else
        {
            //Cập nhật sửa
            oTemplate.TemplateID = int.Parse(DrdlTenMau.SelectedValue.ToString());
            ocBTemplate.Update(oTemplate);
            ThongBao("Cập nhật thành công");
        }
        LoadTemplate();
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
            oTemplate.TemplateID=int.Parse(DrdlTenMau.SelectedValue.ToString());
            ocBTemplate.Delete(oTemplate);
        }
        LoadTemplate();
    }
}
