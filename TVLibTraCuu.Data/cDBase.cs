using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace TruongViet.TVLibTraCuu.Data
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

        protected void RunProcedure(string ProcedureName, ArrayList colParam)
        {
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
            finally{ }

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


        //Tuannd + Kiemdv
        public void RunSQL(string SQL)
        {
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = SQL;

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

        public DataTable RunSQLGet(string SQL)
        {
            DataTable dtb = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = SQL;
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
    }
}
