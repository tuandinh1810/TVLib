using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDQuaTrinhNapTien : cDBase
    {
        public DataTable Get(QuaTrinhNapTienInfo pQuaTrinhNapTienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@QuaTrinhNapTienID",SqlDbType.Int,pQuaTrinhNapTienInfo.QuaTrinhNapTienID));

            return RunProcedureGet("sp_QuaTrinhNapTien_Get", colParam);            
        }

        public int Add(QuaTrinhNapTienInfo pQuaTrinhNapTienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiKhoan",SqlDbType.Int,pQuaTrinhNapTienInfo.IDTaiKhoan));
            colParam.Add(CreateParam("@NgayNapTien",SqlDbType.DateTime,pQuaTrinhNapTienInfo.NgayNapTien));
            colParam.Add(CreateParam("@SoTienNap",SqlDbType.Money,pQuaTrinhNapTienInfo.SoTienNap));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pQuaTrinhNapTienInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_QuaTrinhNapTien_Add", colParam);
        }
        
        public void Update(QuaTrinhNapTienInfo pQuaTrinhNapTienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiKhoan",SqlDbType.Int,pQuaTrinhNapTienInfo.IDTaiKhoan));
            colParam.Add(CreateParam("@NgayNapTien",SqlDbType.DateTime,pQuaTrinhNapTienInfo.NgayNapTien));
            colParam.Add(CreateParam("@SoTienNap",SqlDbType.Money,pQuaTrinhNapTienInfo.SoTienNap));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pQuaTrinhNapTienInfo.GhiChu));
            colParam.Add(CreateParam("@QuaTrinhNapTienID",SqlDbType.Int,pQuaTrinhNapTienInfo.QuaTrinhNapTienID));

            RunProcedure("sp_QuaTrinhNapTien_Update", colParam);
        }
        
        public void Delete(QuaTrinhNapTienInfo pQuaTrinhNapTienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@QuaTrinhNapTienID",SqlDbType.Int,pQuaTrinhNapTienInfo.QuaTrinhNapTienID));

            RunProcedure("sp_QuaTrinhNapTien_Delete", colParam);
        }
    }
}
