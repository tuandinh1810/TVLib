using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDTaiLieu_MarcField : cDBase
    {
        public DataTable GetByIDTaiLieu(int pIDTaiLieu, string MaXepGia)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu", SqlDbType.Int, pIDTaiLieu));
            colParam.Add(CreateParam("@MaXepGia", SqlDbType.NVarChar, MaXepGia));

            return RunProcedureGet("sp_TaiLieu_MarcField_GetByIDTaiLieu", colParam);
        }

        public int Updates(int intIDTaiLieu, string strTruongDublinID, string strDisplayEntry, string strAccessEntry)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu", SqlDbType.Int, intIDTaiLieu));
            colParam.Add(CreateParam("@strFieldIDs", SqlDbType.VarChar,1000, strTruongDublinID));
            colParam.Add(CreateParam("@strDisplayEntry", SqlDbType.NVarChar,4000, strDisplayEntry));
            colParam.Add(CreateParam("@strAccessEntry", SqlDbType.NVarChar,4000, strAccessEntry));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));
            return RunProcedureOut("sp_TaiLieu_MarcField_Updates", colParam);
        }
        public DataTable GetThongTinTaiLieu(string strTaiLieuID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@strIDTaiLieu", SqlDbType.VarChar,strTaiLieuID));

            return RunProcedureGet("[sp_TaiLieu_MarcField_GetNhanDeByTaiLieuID]", colParam);
        }
        public DataTable RunSql(string strSql)
        {
            return RunStrSql(strSql);
        }
    }
}
