using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDSoTapChi : cDBase
    {
        public DataTable Get(SoTapChiInfo pSoTapChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoTapChiID",SqlDbType.Int,pSoTapChiInfo.SoTapChiID));

            return RunProcedureGet("sp_SoTapChi_Get", colParam);            
        }

        public int Add(SoTapChiInfo pSoTapChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pSoTapChiInfo.IDTaiLieu));
            colParam.Add(CreateParam("@NamPhatHanh",SqlDbType.NVarChar,pSoTapChiInfo.NamPhatHanh));
            colParam.Add(CreateParam("@SoTheoNam",SqlDbType.NVarChar,pSoTapChiInfo.SoTheoNam));
            colParam.Add(CreateParam("@SoToanCuc",SqlDbType.NVarChar,pSoTapChiInfo.SoToanCuc));
            colParam.Add(CreateParam("@NgayPhatHanh",SqlDbType.DateTime,pSoTapChiInfo.NgayPhatHanh));
            colParam.Add(CreateParam("@DonGia",SqlDbType.Money,pSoTapChiInfo.DonGia));
            colParam.Add(CreateParam("@TomTat",SqlDbType.NVarChar,pSoTapChiInfo.TomTat));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pSoTapChiInfo.GhiChu));
            colParam.Add(CreateParam("@IDDongTap",SqlDbType.Int,pSoTapChiInfo.IDDongTap));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SoTapChi_Add", colParam);
        }
        
        public void Update(SoTapChiInfo pSoTapChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pSoTapChiInfo.IDTaiLieu));
            colParam.Add(CreateParam("@NamPhatHanh",SqlDbType.NVarChar,pSoTapChiInfo.NamPhatHanh));
            colParam.Add(CreateParam("@SoTheoNam",SqlDbType.NVarChar,pSoTapChiInfo.SoTheoNam));
            colParam.Add(CreateParam("@SoToanCuc",SqlDbType.NVarChar,pSoTapChiInfo.SoToanCuc));
            colParam.Add(CreateParam("@NgayPhatHanh",SqlDbType.DateTime,pSoTapChiInfo.NgayPhatHanh));
            colParam.Add(CreateParam("@DonGia",SqlDbType.Money,pSoTapChiInfo.DonGia));
            colParam.Add(CreateParam("@TomTat",SqlDbType.NVarChar,pSoTapChiInfo.TomTat));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pSoTapChiInfo.GhiChu));
            colParam.Add(CreateParam("@IDDongTap",SqlDbType.Int,pSoTapChiInfo.IDDongTap));
            colParam.Add(CreateParam("@SoTapChiID",SqlDbType.Int,pSoTapChiInfo.SoTapChiID));

            RunProcedure("sp_SoTapChi_Update", colParam);
        }
        
        public void Delete(SoTapChiInfo pSoTapChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoTapChiID",SqlDbType.Int,pSoTapChiInfo.SoTapChiID));

            RunProcedure("sp_SoTapChi_Delete", colParam);
        }
    }
}
