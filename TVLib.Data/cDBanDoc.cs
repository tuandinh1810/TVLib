using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDBanDoc : cDBase
    {
        public DataTable RunSql(string strSql)
        {
            return RunStrSql(strSql);
        }
         public DataTable GetBanDoc_GhiMuon(BanDocInfo pBanDocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoThe",SqlDbType.NVarChar,50,pBanDocInfo.SoThe));

            return RunProcedureGet("sp_BanDoc_GhiMuon", colParam);            
         }
         public DataTable GetBySoThe(string SoThe)
         {
             ArrayList colParam = new ArrayList();

             colParam.Add(CreateParam("@SoThe", SqlDbType.VarChar, SoThe));

             return RunProcedureGet("[sp_BanDoc_GetBySoThe]", colParam);
         }
         public int PhongDoc_LuongBanDoc_Add(string SoThe, DateTime NgayGioVao)
         {
             ArrayList colParam = new ArrayList();

             colParam.Add(CreateParam("@SoThe", SqlDbType.NVarChar,SoThe));
             colParam.Add(CreateParam("@NgayGioVao", SqlDbType.DateTime,NgayGioVao));
             colParam.Add(CreateParamOut("@ID", SqlDbType.Int));
             return RunProcedureOut("[sp_PhongDoc_LuotBanDoc_Add]", colParam);
         }
         public int PhongDoc_LuongBanDoc_Update(string SoThe, DateTime NgayGioRa)
         {
             ArrayList colParam = new ArrayList();

             colParam.Add(CreateParam("@SoThe", SqlDbType.NVarChar, SoThe));
             colParam.Add(CreateParam("@NgayGioRa", SqlDbType.DateTime, NgayGioRa));
             colParam.Add(CreateParamOut("@ID", SqlDbType.Int));
             return RunProcedureOut("[sp_PhongDoc_LuotBanDoc_Update]", colParam);
         }
        //
         public DataTable ThongKeLuotBanDoc_PhongDoc(int Thang, int Nam,string Khoa,string Lop,string MaThe)
         {
             ArrayList colParam = new ArrayList();

             colParam.Add(CreateParam("@Thang", SqlDbType.Int, Thang));
             colParam.Add(CreateParam("@Nam", SqlDbType.Int, Nam));
             colParam.Add(CreateParam("@Khoa", SqlDbType.NVarChar,Khoa));
             colParam.Add(CreateParam("@Lop", SqlDbType.NVarChar,Lop));
             colParam.Add(CreateParam("@SoThe", SqlDbType.VarChar, MaThe));
             return RunProcedureGet("[sp_ThongKeLuotBanDoc_PhongDoc_By_Thang]", colParam);
         }

         public DataTable PhongDoc_GetBySoThe_Thang(string SoThe)
         {
             ArrayList colParam = new ArrayList();

             colParam.Add(CreateParam("@SoThe", SqlDbType.NVarChar, SoThe));
           
             return RunProcedureGet("[sp_PhongDoc_GetBySoThe_Thang]", colParam);
         }
         public DataTable PhongDoc_Vaildate(string SoThe,DateTime NgayGio)
         {
             ArrayList colParam = new ArrayList();

             colParam.Add(CreateParam("@SoThe", SqlDbType.NVarChar, SoThe));
             colParam.Add(CreateParam("@NgayGio", SqlDbType.DateTime, NgayGio));
             return RunProcedureGet("[sp_PhongDoc_LuotBanDoc_Check]", colParam);
         }
    
         public DataTable Get_SoLuotMuon_PhongDocMo(string Khoa, string Lop, string SoThe, DateTime TuNgay, DateTime DenNgay)
         {
             ArrayList colParam = new ArrayList();

             colParam.Add(CreateParam("@Khoa", SqlDbType.NVarChar, Khoa));
             colParam.Add(CreateParam("@Lop", SqlDbType.NVarChar, Lop));
             colParam.Add(CreateParam("@SoThe", SqlDbType.NVarChar, SoThe));
             colParam.Add(CreateParam("@TuNgay", SqlDbType.DateTime, TuNgay));
             colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));

             return RunProcedureGet("sp_Get_SoLuotMuon_PhongDocMo", colParam);
         }
         public DataTable GetBanDoc_GhiMuonByMaXepGia(string pMaXepGia)
         {
             ArrayList colParam = new ArrayList();

             colParam.Add(CreateParam("@MaXepGia", SqlDbType.NVarChar, 50, pMaXepGia));

             return RunProcedureGet("sp_TaiLieuMuon_GetBanDocByMaXepGia", colParam);
         }
         public DataTable GetSoLuongBanDoc_ByNhomBanDoc(int IDNhomBanDoc)
         {
             ArrayList colParam = new ArrayList();

             colParam.Add(CreateParam("@IDNhomBanDoc", SqlDbType.Int, IDNhomBanDoc));

             return RunProcedureGet("sp_BanDoc_GetSoLuong_By_NhomBanDoc", colParam);
         }
         public DataTable GetBanDoc_GhiMuon_ByBanDocID(BanDocInfo pBanDocInfo)
         {
             ArrayList colParam = new ArrayList();

             colParam.Add(CreateParam("@BanDocID", SqlDbType.Int, pBanDocInfo.BanDocID));

             return RunProcedureGet("sp_BanDoc_GhiMuon_ByBanDocID", colParam);
         }
         public DataTable GetKhoas(BanDocInfo pBanDocInfo)
         {
             ArrayList colParam = new ArrayList();

             return RunProcedureGet("sp_BanDoc_GetKhoas", colParam);
         }
         public DataTable GetLop(BanDocInfo pBanDocInfo)
         {
             ArrayList colParam = new ArrayList();
             colParam.Add(CreateParam("@Khoas", SqlDbType.NVarChar, pBanDocInfo.Khoa));

             return RunProcedureGet("sp_BanDoc_GetLop", colParam);
         }
         public DataTable GetBanDoc(BanDocInfo pBanDocInfo)
         {
             ArrayList colParam = new ArrayList();
             colParam.Add(CreateParam("@Khoas", SqlDbType.NVarChar, pBanDocInfo.Khoa));
             colParam.Add(CreateParam("@Lop", SqlDbType.NVarChar, pBanDocInfo.Lop));

             return RunProcedureGet("sp_BanDoc_GetBanDoc", colParam);
         }
         public DataTable XoaBanDocTheoLo(string Khoa, string Lop, string TuNgay, string DenNgay)
         {
             ArrayList colParam = new ArrayList();

             colParam.Add(CreateParam("@Khoa", SqlDbType.NVarChar, 50, Khoa ));
             colParam.Add(CreateParam("@Lop", SqlDbType.NVarChar, 50, Lop));
             colParam.Add(CreateParam("@TuNgayCap", SqlDbType.VarChar, 50, TuNgay));
             colParam.Add(CreateParam("@DenNgayCap", SqlDbType.VarChar, 50, DenNgay));

             return RunProcedureGet("sp_BanDoc_XoaTheoLo", colParam);
         }
        public void  MoKhoa()
        {
             ArrayList colParam = new ArrayList();
             RunProcedure("sp_BanDoc_MoKhoa", colParam);

        }

    }
}
