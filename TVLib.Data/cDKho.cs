using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDKho : cDBase
    {
        public void GopKho(KhoInfo pKhoInfo, int intKhoIDGop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KhoID", SqlDbType.Int, pKhoInfo.KhoID));
            colParam.Add(CreateParam("@KhoIDGop", SqlDbType.Int, intKhoIDGop));

            RunProcedure("sp_Kho_Gop", colParam);
        }
        public DataTable  GetByThuVienID(int intThuVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDThuVien", SqlDbType.Int,intThuVienID));
         
            return RunProcedureGet("sp_Kho_GetByThuVien", colParam);
        }
        public DataTable GetByThuVien(KhoInfo pKhoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDThuVien", SqlDbType.Int, pKhoInfo.IDThuVien));

            return RunProcedureGet("sp_Kho_GetByThuVien", colParam);
        }
        public void Update_MaxMaXepGia(int intKhoID, int intMaxMaXepGia)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KhoID", SqlDbType.Int,intKhoID));
            colParam.Add(CreateParam("@MaxMaXepGia", SqlDbType.Int,intMaxMaXepGia ));
            RunProcedureGet("sp_Kho_Update_MaxMaXepGia", colParam);
        }
        public void Update_TrangThai(string KhoiIDs, int TrangThai)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KhoIDs", SqlDbType.VarChar , 3000,KhoiIDs));
            colParam.Add(CreateParam("@TrangThai", SqlDbType.Bit,TrangThai));

            RunProcedureGet("sp_Kho_Update_TrangThai", colParam);
        }
    }
}
