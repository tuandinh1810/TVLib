using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDLoaiTaiLieu : cDBase
    {
        public DataTable Get(LoaiTaiLieuInfo pLoaiTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LoaiTaiLieuID",SqlDbType.Int,pLoaiTaiLieuInfo.LoaiTaiLieuID));

            return RunProcedureGet("sp_LoaiTaiLieu_Get", colParam);            
        }

        public int Add(LoaiTaiLieuInfo pLoaiTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiTaiLieu",SqlDbType.NVarChar,pLoaiTaiLieuInfo.TenLoaiTaiLieu));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pLoaiTaiLieuInfo.MoTa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_LoaiTaiLieu_Add", colParam);
        }
        
        public int Update(LoaiTaiLieuInfo pLoaiTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiTaiLieu",SqlDbType.NVarChar,pLoaiTaiLieuInfo.TenLoaiTaiLieu));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pLoaiTaiLieuInfo.MoTa));
            colParam.Add(CreateParam("@LoaiTaiLieuID",SqlDbType.Int,pLoaiTaiLieuInfo.LoaiTaiLieuID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_LoaiTaiLieu_Update", colParam);
        }
        
        public void Delete(LoaiTaiLieuInfo pLoaiTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LoaiTaiLieuID",SqlDbType.Int,pLoaiTaiLieuInfo.LoaiTaiLieuID));

            RunProcedure("sp_LoaiTaiLieu_Delete", colParam);
        }
    }
}
