// Created by Kiemdv
using System;
using System.Web;
using System.Web.UI;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Collections;

namespace TVLibTraCuuWeb
{
    public class WebBase : System.Web.UI.Page
    {
        protected string mUserName = "";
        protected bool isLoadCss = true;
        protected bool isLoadJs = true;
        protected string mIP;

        protected override void OnInit(EventArgs e)
        {
            mIP = (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] + "").ToString();
            if (mIP + "" == "")
                mIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            base.OnInit(e);
            //this.Error += new EventHandler(ShowError);
            this.Load += new EventHandler(WebBase_Load);
        }

        void WebBase_Load(object sender, EventArgs e)
        {
            if (isLoadCss)
            {
                LoadCss();
                if (!(IsPostBack))
                {
                    SetStyleForControls(Page);
                }
            }
            if (isLoadJs)
            {
                LoadJs();
            }
        }

        /// <summary>
        /// Dua thong bao loi bang JavaScript
        /// </summary>
        /// <param name="ThongBao"></param>
        protected void ThongBao(string ThongBao)
        {
            this.RegisterClientScriptBlock("ThongBaoLoi", "<Script>alert('" + ThongBao + "')</Script>");
        }

        /// <summary>
        /// Thi hanh lenh cua java script
        /// </summary>
        /// <param name="MaLenh"></param>
        protected void ThiHanhScript(string Script)
        {
            this.RegisterClientScriptBlock("ThiHanhScript", "<Script language='JavaScript'>" + Script + "</Script>");
        }


        // ??? Xem lai
        protected void ShowError(object sender, EventArgs e)
        {
            Exception currentError = Server.GetLastError();
            //if (!((currentError is AppException))) 
            //{ 
            //    //AppException.LogError(currentError.Message); 
            //} 
            HttpContext context = HttpContext.Current;
            context.Response.Write("<h2><Font Color='Red'>Stop!</Font></h2><hr/>" + "Máy chủ đang bận! Tình trạng thi của bạn đã được lưu trữ đầy đủ. Đề nghị thông báo với cán bộ coi thi! Có thể khởi động lại máy chủ"); //<br/>" + "<br/><b>Error:</b>" + "<pre>" + context.Request.Url + "</pre>" + "<br/><b>Error message:</b>" + "<pre>" + currentError.Message + "</pre>" + "<br/><b>Errors:</b>" + "<pre>" + currentError + "</pre>"); 
            Server.ClearError();
        }

        // CheckPermission()
        public bool CheckPermission()
        {
            if (Session["User_ID"] + "" == "")
            {
                ThiHanhScript("top.document.location.href='\\Login.aspx';void(0);");
                return false;
            }
            return true;
        }

        // Load CSS
        protected void LoadCss()
        {
            if (Request.ApplicationPath == "/")
            {
                Response.Write("<link href='Resources/CSS/TVlib.css'  type='text/css' rel='StyleSheet'>");
            }
            else
            {
                Response.Write("<link href='" + Request.ApplicationPath + "/Resources/CSS/TVlib.css'" + " type='text/css' rel='StyleSheet'>");
            }
        }

        // Load JS
        protected void LoadJs()
        {
            if (Request.ApplicationPath == "/")
            {
                Response.Write("<script language = 'javascript' src = 'Resources/JS/TVlib.js'></script>");
                Response.Write("<script language = 'javascript' src = 'Resources/JS/jquery-1.7.1.js'></script>");
                Response.Write("<script language = 'javascript' src = 'Resources/JS/jquery-cookie.js'></script>");
            }
            else
            {
                Response.Write("<script language = 'javascript' src = '" + Request.ApplicationPath + "/Resources/JS/TVlib.js'></script>");
                Response.Write("<script language = 'javascript' src = '" + Request.ApplicationPath + "/Resources/JS/jquery-1.7.1.js'></script>");
                Response.Write("<script language = 'javascript' src = '" + Request.ApplicationPath + "/Resources/JS/jquery-cookie.js'></script>");
                
            }
            
        }

        /// <summary>
        /// Load Drop Down List
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="dtb"></param>
        /// <param name="TruongHienThi"></param>
        /// <param name="TruongGiaTri"></param>
        public void LoadDropDownList(DropDownList ddl, System.Data.DataTable dtb, string TruongHienThi, string TruongGiaTri, string DongThongBao)
        {
            if (DongThongBao != "")
                ddl.DataSource = InsertOneRow(dtb, DongThongBao, 0, 0);
            else
                ddl.DataSource = dtb;
            ddl.DataTextField = TruongHienThi;
            ddl.DataValueField = TruongGiaTri;
            ddl.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scrTable"></param>
        /// <param name="objInsert"></param>
        /// <param name="objKey"></param>
        /// <param name="ViTri"></param>
        /// <returns></returns>
        public System.Data.DataTable InsertOneRow(System.Data.DataTable scrTable, object objInsert, int objKey, int ViTri)
        {
            System.Data.DataRow objrow;
            if (!((scrTable == null)))
            {
                objrow = scrTable.NewRow();
                for (int byti = 0; byti <= scrTable.Columns.Count - 1; byti++)
                {
                    switch (scrTable.Columns[byti].DataType.ToString())
                    {
                        case "System.Boolean":
                            objrow[byti] = true;
                            break;
                        case "System.Byte":
                            objrow[byti] = objKey;
                            break;
                        case "System.Bit":
                            objrow[byti] = 0;
                            break;
                        case "System.Int64":
                            objrow[byti] = objKey;
                            break;
                        case "System.Int32":
                            objrow[byti] = objKey;
                            break;
                        case "System.Int16":
                            objrow[byti] = objKey;
                            break;
                        case "System.Decimal":
                            objrow[byti] = objKey;
                            break;
                        case "System.DateTime":
                            objrow[byti] = DateTime.Now;
                            break;
                        case "System.VarChar":
                            objrow[byti] = objInsert;
                            break;
                        case "System.NVarChar":
                            objrow[byti] = objInsert;
                            break;
                        default:
                            objrow[byti] = objInsert;
                            break;
                    }
                }
                scrTable.Rows.InsertAt(objrow, ViTri);
            }
            return scrTable;
        }


        // SetStyleForControls
        public void SetStyleForControls(Control ctls)
        {

            //foreach (Control ctl in ctls.Controls)
            //{
            //    Response.Write(ctl.GetType().ToString() + " = " + ctl.ID + "<BR>");
            //    SetStyleForControls(ctl);
            //    //Response.Write("<P>");
            //}

            Control ctlPage;


            for (int ctlPageCount = 0; ctlPageCount <= Page.Controls.Count - 1; ctlPageCount++)
            {
                ctlPage = Page.Controls[ctlPageCount];
                if ((ctlPage) is System.Web.UI.HtmlControls.HtmlForm)
                {
                    SetStyleForControl(ctlPage);
                }
            }
        }

        private void SetStyleForControl(Control ctlPage)
        {
            Control ctl;
            string strCtlName;
            string strCtlValue;
            string strAccKey = "";

            for (int ctlCount = 0; ctlCount <= ctlPage.Controls.Count - 1; ctlCount++)
            {
                ctl = ctlPage.Controls[ctlCount];
                if (ctl.ID != "")
                {
                    strCtlValue = "";
                    strCtlName = ctl.ID;
                    switch (ctl.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.Panel":
                            SetStyleForControl(ctl);
                            break;
                        case "System.Web.UI.WebControls.GridView":
                            if (((GridView)(ctl)).CssClass + "" == "")
                            {
                                ((GridView)(ctl)).CssClass = "TVLibGrid";
                                ((GridView)(ctl)).PagerStyle.CssClass = "TVLibGridPager";
                                ((GridView)(ctl)).HeaderStyle.CssClass = "TVLibGridHeader";
                                ((GridView)(ctl)).RowStyle.CssClass = "TVLibGridCell";
                                ((GridView)(ctl)).AlternatingRowStyle.CssClass = "TVLibGridAlterCell";
                                ((GridView)(ctl)).EditRowStyle.CssClass = "TVLibGridEdit";
                            }
                            break;
                        case "System.Web.UI.WebControls.Button":
                            strCtlValue = ((Button)ctl).Text;
                            if (((Button)(ctl)).CssClass == "")
                            {
                                ((Button)(ctl)).CssClass = "TVLibButton";
                            }
                            if (strCtlValue.IndexOf("(") > 0)
                            {
                                string strBtnAccKey;
                                strBtnAccKey = strCtlValue.Substring(strCtlValue.IndexOf("("), 1);
                                strBtnAccKey = strBtnAccKey.ToUpper();
                                ((Button)(ctl)).AccessKey = strBtnAccKey;
                            }
                            break;
                        case "System.Web.UI.WebControls.Label":
                            strCtlValue = ((Label)(ctl)).Text;
                            if (((Label)(ctl)).CssClass == "")
                            {
                                ((Label)(ctl)).CssClass = "TVLibLabel";
                            }
                            if (strCtlValue.IndexOf("<U>") >= 0 | strCtlValue.IndexOf("<u>") >= 0)
                            {
                                strAccKey = strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1).ToUpper();
                            }
                            break;
                        case "System.Web.UI.WebControls.HyperLink":
                            strCtlValue = ((HyperLink)(ctl)).Text;
                            break;
                        case "System.Web.UI.WebControls.TextBox":
                            if (((TextBox)(ctl)).CssClass == "")
                            {
                                ((TextBox)(ctl)).CssClass = "TVLibTextbox";
                            }
                            ((TextBox)(ctl)).AccessKey = strAccKey;
                            strAccKey = "";
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            strCtlValue = ((RadioButton)(ctl)).Text;
                            if (((RadioButton)(ctl)).CssClass == "")
                            {
                                ((RadioButton)(ctl)).CssClass = "TVLibRadio";
                            }
                            if (strCtlValue.IndexOf("<U>") >= 0 | strCtlValue.IndexOf("<u>") >= 0)
                            {
                                string strOptAccKey;
                                strOptAccKey = strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1);
                                strOptAccKey = strOptAccKey.ToUpper();
                                ((RadioButton)(ctl)).AccessKey = strOptAccKey;
                            }
                            break;
                        case "System.Web.UI.WebControls.CheckBox":
                            strCtlValue = ((CheckBox)(ctl)).Text;
                            if (((CheckBox)(ctl)).CssClass == "")
                            {
                                ((CheckBox)(ctl)).CssClass = "TVLibCheckbox";
                            }
                            if (strCtlValue.IndexOf("<U>") >= 0 | strCtlValue.IndexOf("<u>") >= 0)
                            {
                                string strCbxAccKey;
                                strCbxAccKey = strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1);
                                strCbxAccKey = strCbxAccKey.ToUpper();
                                ((CheckBox)(ctl)).AccessKey = strCbxAccKey;
                            }
                            break;
                        case "System.Web.UI.WebControls.ListBox":
                            if (((ListBox)(ctl)).CssClass == "")
                            {
                                ((ListBox)(ctl)).CssClass = "TVLibListbox";
                            }
                            ((ListBox)(ctl)).AccessKey = strAccKey;
                            strAccKey = "";
                            break;
                        case "System.Web.UI.WebControls.DropDownList":
                            ((DropDownList)(ctl)).AccessKey = strAccKey;
                            strAccKey = "";
                            break;

                        case "ASP.nganhangcauhoi_uccauhoiluachon_ascx":
                            SetStyleForControl((UserControl)(ctl));
                            break;
                    }
                }
            }
        }

        protected void SetEnable(Control[] arrControl, bool Value)
        {
            foreach (Control ctl in arrControl)
            {
                switch (ctl.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.GridView":
                        ((GridView)ctl).Enabled = Value;
                        break;
                    case "System.Web.UI.WebControls.Button":
                        ((Button)ctl).Enabled = Value;
                        if (Value)
                        {
                            ((Button)(ctl)).CssClass = "TVLibButton";
                        }
                        else
                        {
                            ((Button)(ctl)).CssClass = "TVLibButtonDisable";
                        }
                        break;
                    case "System.Web.UI.WebControls.Label":
                        ((Label)ctl).Enabled = Value;
                        break;
                    case "System.Web.UI.WebControls.HyperLink":
                        ((HyperLink)ctl).Enabled = Value;
                        break;
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)ctl).Enabled = Value;
                        break;
                    case "System.Web.UI.WebControls.RadioButton":
                        ((RadioButton)ctl).Enabled = Value;
                        break;
                    case "System.Web.UI.WebControls.CheckBox":
                        ((CheckBox)ctl).Enabled = Value;
                        break;
                    case "System.Web.UI.WebControls.ListBox":
                        ((ListBox)ctl).Enabled = Value;
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)ctl).Enabled = Value;
                        break;
                }
            }
        }

        protected void SetVisible(Control[] arrControl, bool Value)
        {
            foreach (Control ctl in arrControl)
            {
                switch (ctl.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.GridView":
                        ((GridView)ctl).Visible = Value;
                        break;
                    case "System.Web.UI.WebControls.Button":
                        ((Button)ctl).Visible = Value;
                        break;
                    case "System.Web.UI.WebControls.Label":
                        ((Label)ctl).Visible = Value;
                        break;
                    case "System.Web.UI.WebControls.HyperLink":
                        ((HyperLink)ctl).Visible = Value;
                        break;
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)ctl).Visible = Value;
                        break;
                    case "System.Web.UI.WebControls.RadioButton":
                        ((RadioButton)ctl).Visible = Value;
                        break;
                    case "System.Web.UI.WebControls.CheckBox":
                        ((CheckBox)ctl).Visible = Value;
                        break;
                    case "System.Web.UI.WebControls.ListBox":
                        ((ListBox)ctl).Visible = Value;
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)ctl).Visible = Value;
                        break;
                }
            }
        }
    }
}

