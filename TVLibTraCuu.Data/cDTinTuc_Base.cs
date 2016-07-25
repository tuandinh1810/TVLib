using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDTinTuc : cDBase
    {
        public DataTable Get(TinTucInfo pTinTucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TinTucID",SqlDbType.Int,pTinTucInfo.TinTucID));

            return RunProcedureGet("sp_TinTuc_Get", colParam);            
        }

        public int Add(TinTucInfo pTinTucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TieuDe",SqlDbType.NVarChar,pTinTucInfo.TieuDe));
            colParam.Add(CreateParam("@Loai",SqlDbType.VarChar,pTinTucInfo.Loai));
            colParam.Add(CreateParam("@URL",SqlDbType.VarChar,pTinTucInfo.URL));
            colParam.Add(CreateParam("@TomTat",SqlDbType.NVarChar,pTinTucInfo.TomTat));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NText,pTinTucInfo.NoiDung));
            colParam.Add(CreateParam("@NgayCapNhat",SqlDbType.DateTime,pTinTucInfo.NgayCapNhat));
            colParam.Add(CreateParam("@Duyet",SqlDbType.Bit,pTinTucInfo.Duyet));
            colParam.Add(CreateParam("@NgonNgu",SqlDbType.Int,pTinTucInfo.NgonNgu));
            colParam.Add(CreateParam("@UuTien",SqlDbType.Int,pTinTucInfo.UuTien));
            colParam.Add(CreateParam("@IDParent",SqlDbType.Int,pTinTucInfo.IDParent));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TinTuc_Add", colParam);
        }
        
        public void Update(TinTucInfo pTinTucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TieuDe",SqlDbType.NVarChar,pTinTucInfo.TieuDe));
            colParam.Add(CreateParam("@Loai",SqlDbType.VarChar,pTinTucInfo.Loai));
            colParam.Add(CreateParam("@URL",SqlDbType.VarChar,pTinTucInfo.URL));
            colParam.Add(CreateParam("@TomTat",SqlDbType.NVarChar,pTinTucInfo.TomTat));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NText,pTinTucInfo.NoiDung));
            colParam.Add(CreateParam("@Duyet",SqlDbType.Bit,pTinTucInfo.Duyet));
            colParam.Add(CreateParam("@NgonNgu",SqlDbType.Int,pTinTucInfo.NgonNgu));
            colParam.Add(CreateParam("@UuTien",SqlDbType.Int,pTinTucInfo.UuTien));
            colParam.Add(CreateParam("@IDParent",SqlDbType.Int,pTinTucInfo.IDParent));
            colParam.Add(CreateParam("@TinTucID",SqlDbType.Int,pTinTucInfo.TinTucID));

            RunProcedure("sp_TinTuc_Update", colParam);
        }
        
        public void Delete(TinTucInfo pTinTucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TinTucID",SqlDbType.Int,pTinTucInfo.TinTucID));

            RunProcedure("sp_TinTuc_Delete", colParam);
        }
    }
}
