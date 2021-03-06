using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDLoaiTien : cDBase
    {
        public DataTable Get(LoaiTienInfo pLoaiTienInfo)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@LoaiTienID", SqlDbType.Int, pLoaiTienInfo.LoaiTienID));

            return RunProcedureGet("sp_LoaiTien_Get", colParam);            
        }

        public int Add(LoaiTienInfo pLoaiTienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LoaiTienID",SqlDbType.Int,pLoaiTienInfo.LoaiTienID));
            colParam.Add(CreateParam("@LoaiTien",SqlDbType.VarChar,pLoaiTienInfo.LoaiTien));
            colParam.Add(CreateParam("@TyGia",SqlDbType.Float,pLoaiTienInfo.TyGia));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_LoaiTien_Add", colParam);
        }
        
        public int  Update(LoaiTienInfo pLoaiTienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LoaiTienID",SqlDbType.Int,pLoaiTienInfo.LoaiTienID));
            colParam.Add(CreateParam("@LoaiTien",SqlDbType.VarChar,pLoaiTienInfo.LoaiTien));
            colParam.Add(CreateParam("@TyGia",SqlDbType.Float,pLoaiTienInfo.TyGia));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

          return   RunProcedureOut("sp_LoaiTien_Update", colParam);
        }
        
        public void Delete(LoaiTienInfo pLoaiTienInfo)
        {
            ArrayList colParam = new ArrayList();


            RunProcedure("sp_LoaiTien_Delete", colParam);
        }
    }
}
