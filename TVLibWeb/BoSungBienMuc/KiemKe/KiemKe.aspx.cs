using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using TruongViet.TVLib.Business;
using TruongViet.TVLib.Entity;


public partial class BoSungBienMuc_KiemKe_KiemKe : WebBase
{
    cBThuVien oBThuVien;
    ThuVienInfo oThuVienInfor;
    cBKho oBKho;
    cBMaXepGia oBMaXepGia;
    ChucNangInfo oChucNang = new ChucNangInfo();
    cBChucNang oBChucNang = new cBChucNang();
    List<ChucNangInfo> lstChucNang = new List<ChucNangInfo>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["QuyenIDs"] + "").ToString().IndexOf(",13,") >= 0)
        {
            oBThuVien = new cBThuVien();
            oThuVienInfor = new ThuVienInfo();
            oBKho = new cBKho();
            oBMaXepGia = new cBMaXepGia();
            BindJS();
            oChucNang.MaChucNang = "KiemKe";
            lstChucNang = oBChucNang.Get_ByMaChucNang_List(oChucNang);
            if (!IsPostBack)
            {
                LoadThuVien();
            }
        }
        else
            Response.Redirect("Error.aspx");
    }
    private void LoadThuVien()
    {
        oThuVienInfor.ThuVienID = 0;
        ddlLibrary.DataSource = oBThuVien.Get(oThuVienInfor);
        ddlLibrary.DataTextField = "MaThuVien";
        ddlLibrary.DataValueField = "ThuVienID";
        ddlLibrary.DataBind();
        LoadKhoByThuVien(0);
    }
    private void LoadKhoByThuVien(int intThuVienID)
    {
        // load kho
        DataTable dtKho = InsertOneRow(oBKho.GetByThuVienID(intThuVienID), "--- Chọn kho ---", 0, 0); 
        dtKho.DefaultView.RowFilter = "Khoa=1";
        ddlStore.DataSource = dtKho.DefaultView;
        ddlStore.DataTextField = "TenKho";
        ddlStore.DataValueField = "KhoID";
        ddlStore.DataBind();

    }
    private void BindJS()
    {
        Response.Write("<Script src='../../Resources/Js/TVLib.js'" + " ></Script>");
        btnReset.Attributes.Add("Onclick", "document.forms[0].reset(); return false;");
    }
    protected void btnKiemKe_Click(object sender, EventArgs e)
    {
        if (ddlLibrary.Items.Count > 0)
        {
            if (fileUpload.Value != "" || txtDSMXG.Text != "")
            {
                // lay DKCB tu CSDL
               DataTable dtDKCB = oBMaXepGia.Get_InNhanGay(int.Parse(ddlLibrary.SelectedValue.ToString()), int.Parse(ddlStore.SelectedValue.ToString()), "", "");

                string ChuoiDKCB = "",strMaXepGia="";
                if (fileUpload.Value != "")

                    ChuoiDKCB = ReadFile();
                else
                    ChuoiDKCB = txtDSMXG.Text;
                ChuoiDKCB = ChuoiDKCB.Trim();
                string[] arrDKCB = ChuoiDKCB.Split(',');
                // loc bo dkcb trung
                for (int i = 0; i < arrDKCB.Length; i++)
                {
                    if (ChuoiDKCB.IndexOf(arrDKCB[i] + ",") != ChuoiDKCB.LastIndexOf(arrDKCB[i] + ","))
                    {
                        ChuoiDKCB = ChuoiDKCB.Replace(arrDKCB[i] + ",", "");
                    }
                    strMaXepGia += "'" + arrDKCB[i] + "',";
                }
                strMaXepGia = strMaXepGia;
                string[] arrDKCBTemp = ChuoiDKCB.Substring(0, ChuoiDKCB.Trim().Length ).Split(',');
                
                // lay so DKCB bi thieu
                DataTable dtTemp = dtDKCB.Copy();
                dtTemp.DefaultView.RowFilter = " MaXepGia not in (" + strMaXepGia.Substring(0, strMaXepGia.Length ) + ")";
                lblTotalLostResult.Text = dtTemp.DefaultView.Count.ToString();
                string ChuoiMXGThieu = "";
                int intDem = 0;
                
                for (int i = 0; i < dtTemp.DefaultView.Count; i++)
                {
                    if (intDem == 10)
                    {
                        ChuoiMXGThieu += dtTemp.DefaultView[i][0].ToString() + ",<br>";
                        intDem = 0;
                    }
                    else
                        ChuoiMXGThieu += dtTemp.DefaultView[i][0].ToString() + ",";
                    intDem += 1;
                }
                if(ChuoiMXGThieu.Length>0)
                    lbDKCBThieuResult.Text = ChuoiMXGThieu.Trim().Substring(0,ChuoiMXGThieu.Length-1);
                dtTemp.DefaultView.RowFilter = " MaXepGia in (" + strMaXepGia.Substring(0, strMaXepGia.Length) + ")";
                int intSoDKCBTrung = dtTemp.DefaultView.Count;
                lblTotalInventoryResult.Text = arrDKCB.Length.ToString();
                lblTotalNoLoopResult.Text = intSoDKCBTrung.ToString();

                // check DKCB ko có trong csdl
                int ID = 0;
                int SoDKCBKoCo = 0;
                string DKCBKoCo = "";

                for (int i = 0; i < arrDKCBTemp.Length; i++)
                {
                    if (oBMaXepGia.MaXepGiaExisted(arrDKCBTemp[i], ref ID) == true)
                    {
                        dtTemp.DefaultView.RowFilter = " MaXepGia='" + arrDKCBTemp[i] + "'";
                        if (dtTemp.DefaultView.Count == 0)
                        {
                            SoDKCBKoCo += 1;
                            DKCBKoCo += arrDKCBTemp[i] + ",";
                        }
                    }
                    else
                    {
                        SoDKCBKoCo += 1;
                        DKCBKoCo += arrDKCBTemp[i] + ",";
                    }
                }
                lblTotalNoResult.Text = SoDKCBKoCo.ToString();
                lblNoDetailResult.Text = DKCBKoCo;
                ThongBao("Kiểm kê thành công!");
                WriteLog(lstChucNang[0].ChucNangID, "Thực hiện kiểm kê", Request.UserHostAddress, Session["TenDangNhap"].ToString());
            }
            else
                ThongBao("Bạn chưa đưa ĐKCB vào kiểm kê!");
        }
        else
            ThongBao("Bạn chưa chọn thư viện!");
    }
    private string ReadFile()
    {
        StreamReader oRead = new StreamReader(fileUpload.Value);
        //read file
        string DKCBs = "";
        while (oRead.EndOfStream == false)
        {
            DKCBs += oRead.ReadLine() + ",";
        }
        oRead.Close();
        return DKCBs;
    }
}
