using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace TruongViet.TVLib.Data
{
    public class cDBase
    {
        public static SqlConnection sqlCn;


        protected string mErrorMessage;
        protected int mErrorNumber;

        public int ErrorNumber
        {
            get
            {
                return mErrorNumber;
            }
        }

        public string ErrorMessages
        {
            get
            {
                return mErrorMessage;
            }
        }
        // string strCon = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"].ToString();
        //TruongViet.TVLib.Data.cDBase.sqlCn = new System.Data.SqlClient.SqlConnection();
        //TruongViet.TVLib.Data.cDBase.sqlCn.ConnectionString = strCon;
        //try
        //{
        //    TruongViet.TVLib.Data.cDBase.sqlCn.Open();
        //}
        //catch (System.Data.SqlClient.SqlException sqlEx)
        //{
        //}
        public void KetNoiLai()
        {
            string strConnect = ConfigurationSettings.AppSettings["ConnectionString"];
           sqlCn = new SqlConnection();
           sqlCn.ConnectionString = strConnect;
            try
            {
                sqlCn.Open();
            }
            catch(SqlException sqlEx)
            {
                throw sqlEx;
            }
        }
        public static DataTable RunStrSql(string strSql)
        {
            //if (sqlCn.State == ConnectionState.Closed)
            //    KetNoiLai();
            DataTable dtb = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = strSql;
                sqlCmd.CommandType = CommandType.Text;

                sqlDA.Fill(dtb);
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;            
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;

            return dtb;
        }
        public void RunSql(string strSql)
        {

            if (sqlCn.State == ConnectionState.Closed)
                KetNoiLai();
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = strSql;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;            
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;

        }
        protected void RunProcedure(string ProcedureName, ArrayList colParam)
        {
            if (sqlCn.State == ConnectionState.Closed)
                KetNoiLai();
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < colParam.Count; i++)
                    sqlCmd.Parameters.Add((SqlParameter)colParam[i]);
                sqlCmd.ExecuteNonQuery();
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;            
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;
        }

        /// <summary>
        /// Thuc thi thu tuc co tra lai gia tri la so tu tang cua bang
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="colParam"></param>
        /// <returns></returns>
        protected int RunProcedureOut(string ProcedureName, ArrayList colParam)
        {
            if (sqlCn.State == ConnectionState.Closed)
                KetNoiLai();
            int ID = 0;
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < colParam.Count; i++)
                    sqlCmd.Parameters.Add((SqlParameter)colParam[i]);
                sqlCmd.ExecuteNonQuery();
                ID = (int)sqlCmd.Parameters["@ID"].Value;
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;            
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;
            return ID;
        }

        /// <summary>
        /// Ham goi thu tuc truy van
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="colParam"></param>
        /// <returns></returns>
        protected DataTable RunProcedureGet(string ProcedureName, ArrayList colParam)
        {
            if (sqlCn.State == ConnectionState.Closed)
                KetNoiLai();
            DataTable dtb = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < colParam.Count; i++)
                    sqlCmd.Parameters.Add((SqlParameter)colParam[i]);

                sqlDA.Fill(dtb);
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;            
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;

            return dtb;
        }
        //Tuannd
        //protected DataTable RunStrSql(string strSql)
        //{
        //    DataTable dtb = new DataTable();
        //    SqlCommand sqlCmd = new SqlCommand();
        //    SqlDataAdapter sqlDA = new SqlDataAdapter();
        //    try
        //    {
        //        sqlCmd.Connection = sqlCn;
        //        sqlDA.SelectCommand = sqlCmd;
        //        sqlCmd.CommandText = strSql;
        //        sqlCmd.CommandType = CommandType.Text;

        //        sqlDA.Fill(dtb);
        //    }
        //    //catch(SqlException sqlEx) {
        //    //    strErrorMessage = sqlEx.Message;
        //    //    intErrorNumber = sqlEx.Number;            
        //    //}
        //    finally { }

        //    sqlDA.Dispose();
        //    sqlDA = null;
        //    sqlCmd.Dispose();
        //    sqlCmd = null;

        //    return dtb;
        //}
        /// <summary>
        /// Tao tham so cho thu tuc
        /// </summary>
        /// <param name="_TenThamSo"></param>
        /// <param name="_KieuDuLieu"></param>
        /// <param name="_GiaTri"></param>
        /// <returns></returns>
        public SqlParameter CreateParam(string _TenThamSo, SqlDbType _KieuDuLieu, object _GiaTri)
        {
            SqlParameter sqlParam = new SqlParameter();
            sqlParam.ParameterName = _TenThamSo;
            sqlParam.SqlDbType = _KieuDuLieu;
            sqlParam.Value = _GiaTri;
            return sqlParam;
        }

        /// <summary>
        /// Tao tham so output cho thu tuc
        /// </summary>
        /// <param name="_TenThamSo"></param>
        /// <param name="_KieuDuLieu"></param>
        /// <returns></returns>
        public SqlParameter CreateParamOut(string _TenThamSo, SqlDbType _KieuDuLieu)
        {
            SqlParameter sqlParam = new SqlParameter();
            sqlParam.ParameterName = _TenThamSo;
            sqlParam.SqlDbType = _KieuDuLieu;
            sqlParam.Direction = ParameterDirection.Output;
            return sqlParam;
        }

        /// <summary>
        /// Tao tham so cho thu tuc
        /// </summary>
        /// <param name="_TenThamSo"></param>
        /// <param name="_KieuDuLieu"></param>
        /// <param name="_KichThuoc"></param>
        /// <param name="_GiaTri"></param>
        /// <returns></returns>
        public SqlParameter CreateParam(string _TenThamSo, SqlDbType _KieuDuLieu, int _KichThuoc, object _GiaTri)
        {
            SqlParameter sqlParam = CreateParam(_TenThamSo, _KieuDuLieu, _GiaTri);
            sqlParam.Size = _KichThuoc;
            return sqlParam;
        }

        /// <summary>
        /// Tao tham so output cho thu tuc
        /// </summary>
        /// <param name="_TenThamSo"></param>
        /// <param name="_KieuDuLieu"></param>
        /// <param name="_KichThuoc"></param>
        /// <returns></returns>
        public SqlParameter CreateParamOut(string _TenThamSo, SqlDbType _KieuDuLieu, int _KichThuoc)
        {
            SqlParameter sqlParam = CreateParamOut(_TenThamSo, _KieuDuLieu);
            sqlParam.Size = _KichThuoc;
            return sqlParam;
        }
        /// <summary>
        /// chuyen dinh dang ngay thang
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <param name="blnShowTime"></param>
        /// <returns></returns>
        public string ConvertDateBack(string strDateTime, bool blnShowTime)
        {
            string strDate = null;
            string strTime = null;
            string strDeli = null;
            string strRet = null;
            string[] strPara = new string[2];
            string[] strARet = new string[2];
            string strTypeCurent = null;
            strPara[0] = "DATE_FORMAT";
            // strARet = GetSystemParameters(strPara);
            //if (strARet[0] != "")
            //{
            // strTypeCurent = strARet[0];
            //}
            //  else
            // {
            strTypeCurent = "DD/MM/YYYY";
            //}
            //strTypeCurent = "DD/MM/YYYY"
            strDateTime = strDateTime.Trim(' ');
            if (strDateTime != "")
            {
                if ((strDateTime.IndexOf(" ", 0) + 1) > 0)
                {
                    strDate = strDateTime.Substring(0, (strDateTime.IndexOf(" ", 0) + 1) - 1);
                    strTime = System.Convert.ToString(strDateTime.Substring(strDateTime.Length - (strDateTime.Length - (strDateTime.IndexOf(" ", 0) + 1)))).Trim(' ');
                }
                else
                {
                    strDate = strDateTime;
                }
                if ((strDate.IndexOf("/", 0) + 1) != 0)
                {
                    strDeli = "/";
                }
                if ((strDate.IndexOf("-", 0) + 1) != 0)
                {
                    strDeli = "-";
                }
            }
            if (strDeli != "" & strDate != "")
            {
                int bytPos1 = 0;
                int bytPos2 = 0;
                bytPos1 = (strDate.IndexOf(strDeli, 0) + 1);
                bytPos2 = (strDate.LastIndexOf(strDeli) + 1);
                // convert to format mm/dd/yyyy
                switch (strTypeCurent.ToUpper())
                {
                    case "DD/MM/YYYY":
                        strRet = strDate.Substring(bytPos1, bytPos2 - bytPos1 - 1) + "/" + strDate.Substring(0, bytPos1 - 1) + "/" + strDate.Substring(strDate.Length - (strDate.Length - bytPos2));
                        break;
                    case "MM/DD/YYYY":
                        strRet = strDate;
                        break;
                    case "YYYY/DD/MM":
                        strRet = strDate.Substring(strDate.Length - (strDate.Length - bytPos2)) + "/" + strDate.Substring(bytPos1, bytPos2 - bytPos1 - 1) + "/" + strDate.Substring(0, bytPos1 - 1);
                        break;
                    case "YYYY/MM/DD":
                        strRet = strDate.Substring(bytPos1, bytPos2 - bytPos1 - 1) + "/" + strDate.Substring(strDate.Length - (strDate.Length - bytPos2)) + "/" + strDate.Substring(0, bytPos1 - 1);
                        break;
                }
                if (blnShowTime)
                {
                    if (strTime != "")
                    {
                        strRet = strRet + " " + strTime;
                    }
                    else
                    {
                        strRet = strRet + " 00:00:00";
                    }
                }
            }
            else
            {
                strRet = strDateTime;
            }
            return strRet;
        }




    }
}
