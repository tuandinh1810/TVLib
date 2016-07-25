using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDKyKiemKe : cDBase
    {
        public DataTable Get(KyKiemKeInfo pKyKiemKeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KyKiemKeID",SqlDbType.Int,pKyKiemKeInfo.KyKiemKeID));

            return RunProcedureGet("sp_KyKiemKe_Get", colParam);            
        }

        public int Add(KyKiemKeInfo pKyKiemKeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenKyKiemKe",SqlDbType.NVarChar,pKyKiemKeInfo.TenKyKiemKe));
            colParam.Add(CreateParam("@TrangThai",SqlDbType.Bit,pKyKiemKeInfo.TrangThai));
            colParam.Add(CreateParam("@NgayKiemKe",SqlDbType.DateTime,pKyKiemKeInfo.NgayKiemKe));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_KyKiemKe_Add", colParam);
        }
        
        public void Update(KyKiemKeInfo pKyKiemKeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenKyKiemKe",SqlDbType.NVarChar,pKyKiemKeInfo.TenKyKiemKe));
            colParam.Add(CreateParam("@TrangThai",SqlDbType.Bit,pKyKiemKeInfo.TrangThai));
            colParam.Add(CreateParam("@NgayKiemKe",SqlDbType.DateTime,pKyKiemKeInfo.NgayKiemKe));
            colParam.Add(CreateParam("@KyKiemKeID",SqlDbType.Int,pKyKiemKeInfo.KyKiemKeID));

            RunProcedure("sp_KyKiemKe_Update", colParam);
        }
        
        public void Delete(KyKiemKeInfo pKyKiemKeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KyKiemKeID",SqlDbType.Int,pKyKiemKeInfo.KyKiemKeID));

            RunProcedure("sp_KyKiemKe_Delete", colParam);
        }
    }
}
