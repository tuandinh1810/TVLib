using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDTaiLieu : cDBase
    {
        public DataTable Get(TaiLieuInfo pTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiLieuID",SqlDbType.Int,pTaiLieuInfo.TaiLieuID));

            return RunProcedureGet("sp_TaiLieu_Get", colParam);            
        }

        public int Add(TaiLieuInfo pTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaTaiLieu", SqlDbType.VarChar, pTaiLieuInfo.MaTaiLieu));
            colParam.Add(CreateParam("@LuuThong",SqlDbType.Bit,pTaiLieuInfo.LuuThong));
            colParam.Add(CreateParam("@CapDoMat",SqlDbType.Int,pTaiLieuInfo.CapDoMat));
            colParam.Add(CreateParam("@GiaTien",SqlDbType.Float,pTaiLieuInfo.GiaTien));
            colParam.Add(CreateParam("@IDNguoiNhapTin",SqlDbType.Int,pTaiLieuInfo.IDNguoiNhapTin));
            colParam.Add(CreateParam("@IDLoaiTaiLieu",SqlDbType.Int,pTaiLieuInfo.IDLoaiTaiLieu));
            colParam.Add(CreateParam("@IDMauBienMuc", SqlDbType.Int, pTaiLieuInfo.IDMauBienMuc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_TaiLieu_Add", colParam);
        }
        
        //Chuyen doi du lieu

        public  void UpdateTempHTT(int IDTaiLieu,float STT)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTaiLieu", SqlDbType.Int, IDTaiLieu));
            colParam.Add(CreateParam("@STT", SqlDbType.Float, STT));


            RunProcedure("sp_TempHTT_Update", colParam);
        }
        
        public void Update(TaiLieuInfo pTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LuuThong",SqlDbType.Bit,pTaiLieuInfo.LuuThong));
            colParam.Add(CreateParam("@CapDoMat",SqlDbType.Int,pTaiLieuInfo.CapDoMat));
            colParam.Add(CreateParam("@GiaTien",SqlDbType.Float,pTaiLieuInfo.GiaTien));
            colParam.Add(CreateParam("@IDNguoiNhapTin",SqlDbType.Int,pTaiLieuInfo.IDNguoiNhapTin));
            colParam.Add(CreateParam("@IDLoaiTaiLieu",SqlDbType.Int,pTaiLieuInfo.IDLoaiTaiLieu));
            colParam.Add(CreateParam("@TaiLieuID",SqlDbType.Int,pTaiLieuInfo.TaiLieuID));

            RunProcedure("sp_TaiLieu_Update", colParam);
        }
        
        public void Delete(TaiLieuInfo pTaiLieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TaiLieuID",SqlDbType.Int,pTaiLieuInfo.TaiLieuID));

            RunProcedure("sp_TaiLieu_Delete", colParam);
        }
    }
}
