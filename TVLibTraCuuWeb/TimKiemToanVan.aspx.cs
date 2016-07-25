using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace TVLibTraCuuWeb
{
    public partial class TimKiemToanVan : System.Web.UI.Page
    {
        SqlConnection sqlCn;
        TruongViet.TVLibTraCuu.Data.cDBase oDBase = new TruongViet.TVLibTraCuu.Data.cDBase();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
                return;
            string strSearch = txtTimKiem.Text;
            //if (strSearch.IndexOf("AND") > 0 || strSearch.IndexOf("OR") > 0)
            //{
            //    strSearch = "SELECT IDDoc FROM Doc_Word WHERE IDWord = (SELECT WordID FROM Word WHERE WordName=N'" + strSearch + "')";
            //    //strSearch = strSearch.Replace(" AND ", "' INTERSECT SELECT ID_URL FROM URL_Word WHERE Word = N'");
            //    //strSearch = strSearch.Replace(" OR ", "' UNION SELECT ID_URL FROM URL_Word WHERE Word=N'");                
            //    //strSearch = strSearch + "'";
            //    strSearch = "SELECT * FROM Doc WHERE DocID IN (" + strSearch + ")";
            //}
            //else
            //{
            //    strSearch = "SELECT * FROM URL WHERE URL_ID IN (SELECT ID_URL FROM URL_Word WHERE Word=N'" + strSearch + "')";
            //}
            //string[] arrWord = strSearch.Split(new char[] {'' });
            string[] arrAND_Keywords = new string[0];
            string[] arrOR_Keywords = new string[0];
            string[] arrOrder_Words = new string[0];
            string[] arrOR_Words = new string[0];
            if (strSearch.IndexOf("AND") == 0 || strSearch.IndexOf("OR") == 0)
            {
                Response.Write("Từ khóa tìm kiếm chưa đúng!");
                return;
            }
            if (strSearch.IndexOf("AND") > 0)
            {
                strSearch = strSearch.Replace("OR", "");
                arrAND_Keywords = strSearch.Split(new string[] { "AND" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else if (strSearch.IndexOf("OR") > 0)
            {
                arrOR_Keywords = strSearch.Split(new string[] { "OR" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else if (strSearch.IndexOf("\"") >= 0)
            {
                strSearch = strSearch.Replace("\"", "");
                arrOrder_Words = strSearch.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                arrOR_Words = strSearch.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            string strIDDocs = "";
            strSearch = "";
            if (arrAND_Keywords.Length > 0)
            {
                strSearch = "";
                for (int i = 0; i < arrAND_Keywords.Length; i++)
                {
                    if (arrAND_Keywords[i].Trim().Length > 0)
                    {
                        arrAND_Keywords[i] = arrAND_Keywords[i].Replace("\"", "");
                        string[] arrSubOrder_Words = arrAND_Keywords[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        // Xử lý Order
                        if (strSearch.Length == 0)
                        {
                            if (GenSQL_Order_Word(arrSubOrder_Words).Length > 0)
                                strSearch = "SELECT DocID FROM Doc WHERE DocID IN (" + GenSQL_Order_Word(arrSubOrder_Words) + ")";
                        }
                        else
                        {
                            if (GenSQL_Order_Word(arrSubOrder_Words).Length > 0)
                                strSearch += " INTERSECT SELECT DocID FROM Doc WHERE DocID IN (" + GenSQL_Order_Word(arrSubOrder_Words) + ")";
                            else
                                strSearch = "";
                        }
                    }
                }
                if (strSearch.Length > 0)
                    strSearch = "SELECT * FROM Doc WHERE DocID IN (" + strSearch + ")";
            }
            else if (arrOR_Keywords.Length > 0)
            {
                strSearch = "";
                for (int i = 0; i < arrOR_Keywords.Length; i++)
                {
                    if (arrOR_Keywords[i].Trim().Length > 0)
                    {
                        arrOR_Keywords[i] = arrOR_Keywords[i].Replace("\"", "");
                        string[] arrSubOrder_Words = arrOR_Keywords[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        // Xử lý Order
                        if (strSearch.Length == 0)
                        {
                            if (GenSQL_Order_Word(arrSubOrder_Words).Length > 0)
                                strSearch = "SELECT DocID FROM Doc WHERE DocID IN (" + GenSQL_Order_Word(arrSubOrder_Words) + ")";
                        }
                        else
                        {
                            if (GenSQL_Order_Word(arrSubOrder_Words).Length > 0)
                                strSearch += " UNION SELECT DocID FROM Doc WHERE DocID IN (" + GenSQL_Order_Word(arrSubOrder_Words) + ")";
                        }
                    }
                }
                if (strSearch.Length > 0)
                    strSearch = "SELECT * FROM Doc WHERE DocID IN (" + strSearch + ")";
            }
            else if (arrOrder_Words.Length > 0)
            {
                // Xử lý Order
                strIDDocs = GenSQL_Order_Word(arrOrder_Words);
                if (strIDDocs.Length > 0)
                    strSearch = "SELECT * FROM Doc WHERE DocID IN (" + strIDDocs + ")";
            }
            else if (arrOR_Words.Length > 0)
            {
                // Xử lý OR
                strIDDocs = GenSQL_OR_Word(arrOR_Words);
                if (strIDDocs.Length > 0)
                    strSearch = "SELECT * FROM Doc WHERE DocID IN (" + strIDDocs + ")";
            }
            if (strSearch.Length > 0)
            {
                DataTable dtbSearch = oDBase.RunSQLGet(strSearch);
                grvResult.DataSource = dtbSearch;
                grvResult.DataBind();
            }
            else
            {
                grvResult.DataSource = null;
                grvResult.DataBind();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arrKeyword"></param>
        /// <returns>Trả về tập IDDoc</returns>
        private string GenSQL_Order_Word(string[] arrKeyword)
        {
            string IDDocs = "";
            if (arrKeyword.Length == 1)
            {
                DataTable dtbTmp = oDBase.RunSQLGet("SELECT IDDoc FROM Doc_Word WHERE IDWord IN (SELECT WordID FROM Word WHERE WordName=N'" + arrKeyword[0] + "')");
                for (int i = 0; i < dtbTmp.Rows.Count; i++)
                {
                    if (IDDocs.Length == 0)
                    {
                        IDDocs = dtbTmp.Rows[0]["IDDoc"].ToString();
                    }
                    else
                    {
                        IDDocs = IDDocs + "," + dtbTmp.Rows[0]["IDDoc"].ToString();
                    }
                }
                return IDDocs;
            }
            string strResult = "";
            DataTable dtbAND = oDBase.RunSQLGet(GenSQL_SubAND_Word(arrKeyword));
            if (dtbAND.Rows.Count == 0)
                return "";
            DataTable dtbTruoc, dtbSau;
            int intIDDoc = -1;
            for (int i = 0; i < dtbAND.Rows.Count; i++)
            {
                intIDDoc = int.Parse(dtbAND.Rows[i]["IDDoc"].ToString());
                dtbSau = oDBase.RunSQLGet("SELECT IDWordPre FROM Doc_Word WHERE IDDoc = " + intIDDoc.ToString() + " AND IDWord IN (SELECT WordID FROM Word WHERE WordName=N'" + arrKeyword[arrKeyword.Length - 1] + "')");
                int j = arrKeyword.Length - 2;
                for (; j >= 0; j--)
                {
                    dtbTruoc = oDBase.RunSQLGet("SELECT IDWordPre FROM Doc_Word WHERE IDDoc = " + intIDDoc.ToString() + " AND IDWord IN (SELECT WordID FROM Word WHERE WordName=N'" + arrKeyword[j] + "') AND IDWord IN (" + dtbSau.Rows[0]["IDWordPre"].ToString() + ")");
                    if (dtbTruoc.Rows.Count == 0)
                        break;
                    dtbSau = dtbTruoc;
                }
                if (j == -1)
                {
                    if (IDDocs.Length == 0)
                        IDDocs = intIDDoc.ToString();
                    else
                        IDDocs = IDDocs + "," + intIDDoc.ToString();
                }
            }
            return IDDocs;
            //strSearch = strSearch.Replace(" AND ", "' INTERSECT SELECT ID_URL FROM URL_Word WHERE Word = N'");
            //strSearch = strSearch.Replace(" OR ", "' UNION SELECT ID_URL FROM URL_Word WHERE Word=N'");
            //strSearch = strSearch + "'";
            //strSearch = "SELECT * FROM Doc WHERE DocID IN (" + strSearch + ")";
        }

        private string GenSQL_SubAND_Word(string[] arrKeyword)
        {
            string strResult = "";
            for (int i = 0; i < arrKeyword.Length; i++)
            {
                if (strResult.Length == 0)
                    strResult = strResult + "SELECT IDDoc FROM Doc_Word WHERE IDWord IN (SELECT WordID FROM Word WHERE WordName=N'" + arrKeyword[i] + "')";
                else
                    strResult = strResult + " INTERSECT  SELECT IDDoc FROM Doc_Word WHERE IDWord IN (SELECT WordID FROM Word WHERE WordName=N'" + arrKeyword[i] + "')";
            }
            return strResult;
        }

        private string GenSQL_OR_Word(string[] arrKeyword)
        {
            string strSQL = "";
            for (int i = 0; i < arrKeyword.Length; i++)
            {
                if (strSQL.Length == 0)
                    strSQL = "SELECT IDDoc FROM Doc_Word WHERE IDWord IN (SELECT WordID FROM Word WHERE WordName=N'" + arrKeyword[i] + "')";
                else
                    strSQL = strSQL + " UNION  SELECT IDDoc FROM Doc_Word WHERE IDWord IN (SELECT WordID FROM Word WHERE WordName=N'" + arrKeyword[i] + "')";
            }
            string strIDDocs = "";
            DataTable dtbOR_Word = oDBase.RunSQLGet(strSQL);
            for (int i = 0; i < dtbOR_Word.Rows.Count; i++)
            {
                if (strIDDocs.Length == 0)
                {
                    strIDDocs = dtbOR_Word.Rows[i]["IDDoc"].ToString();
                }
                else
                {
                    strIDDocs = strIDDocs + "," + dtbOR_Word.Rows[i]["IDDoc"].ToString();
                }
            }
            return strIDDocs;
        }
    }
}
