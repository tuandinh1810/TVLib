using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLibTraCuu.Entity;

namespace TruongViet.TVLibTraCuu.Data
{
    public partial class cDBanDoc : cDBase
    {
        public DataTable Get(BanDocInfo pBanDocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@BanDocID",SqlDbType.Int,pBanDocInfo.BanDocID));

            return RunProcedureGet("sp_BanDoc_Get", colParam);            
        }

        public int Add(BanDocInfo pBanDocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoThe",SqlDbType.NVarChar,pBanDocInfo.SoThe));
            colParam.Add(CreateParam("@TenDayDu",SqlDbType.NVarChar,pBanDocInfo.TenDayDu));
            colParam.Add(CreateParam("@NgaySinh",SqlDbType.DateTime,pBanDocInfo.NgaySinh));
            colParam.Add(CreateParam("@NgayCap",SqlDbType.DateTime,pBanDocInfo.NgayCap));
            colParam.Add(CreateParam("@NgayHieuLuc",SqlDbType.DateTime,pBanDocInfo.NgayHieuLuc));
            colParam.Add(CreateParam("@NgayHetHan",SqlDbType.DateTime,pBanDocInfo.NgayHetHan));
            colParam.Add(CreateParam("@IDDanToc",SqlDbType.Int,pBanDocInfo.IDDanToc));
            colParam.Add(CreateParam("@IDNhomBanDoc",SqlDbType.Int,pBanDocInfo.IDNhomBanDoc));
            colParam.Add(CreateParam("@IDTrinhDo",SqlDbType.Int,pBanDocInfo.IDTrinhDo));
            colParam.Add(CreateParam("@IDNgheNghiep",SqlDbType.NChar,pBanDocInfo.IDNgheNghiep));
            colParam.Add(CreateParam("@Khoa",SqlDbType.NVarChar,pBanDocInfo.Khoa));
            colParam.Add(CreateParam("@Lop",SqlDbType.NVarChar,pBanDocInfo.Lop));
            colParam.Add(CreateParam("@NoiLamViec",SqlDbType.NVarChar,pBanDocInfo.NoiLamViec));
            colParam.Add(CreateParam("@GioiTinh",SqlDbType.Bit,pBanDocInfo.GioiTinh));
            colParam.Add(CreateParam("@DiaChi",SqlDbType.NVarChar,pBanDocInfo.DiaChi));
            colParam.Add(CreateParam("@ThanhPho",SqlDbType.NVarChar,pBanDocInfo.ThanhPho));
            colParam.Add(CreateParam("@IDTinh",SqlDbType.Int,pBanDocInfo.IDTinh));
            colParam.Add(CreateParam("@SoCMT",SqlDbType.NVarChar,pBanDocInfo.SoCMT));
            colParam.Add(CreateParam("@SoDienThoai",SqlDbType.NVarChar,pBanDocInfo.SoDienThoai));
            colParam.Add(CreateParam("@Email",SqlDbType.NVarChar,pBanDocInfo.Email));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pBanDocInfo.GhiChu));
            colParam.Add(CreateParam("@MaVung",SqlDbType.VarChar,pBanDocInfo.MaVung));
            colParam.Add(CreateParam("@KhoaThe",SqlDbType.Bit,pBanDocInfo.KhoaThe));
            colParam.Add(CreateParam("@AnhURL",SqlDbType.NVarChar,pBanDocInfo.AnhURL));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_BanDoc_Add", colParam);
        }
        
        public void Update(BanDocInfo pBanDocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoThe",SqlDbType.NVarChar,pBanDocInfo.SoThe));
            colParam.Add(CreateParam("@TenDayDu",SqlDbType.NVarChar,pBanDocInfo.TenDayDu));
            colParam.Add(CreateParam("@NgaySinh",SqlDbType.DateTime,pBanDocInfo.NgaySinh));
            colParam.Add(CreateParam("@NgayCap",SqlDbType.DateTime,pBanDocInfo.NgayCap));
            colParam.Add(CreateParam("@NgayHieuLuc",SqlDbType.DateTime,pBanDocInfo.NgayHieuLuc));
            colParam.Add(CreateParam("@NgayHetHan",SqlDbType.DateTime,pBanDocInfo.NgayHetHan));
            colParam.Add(CreateParam("@IDDanToc",SqlDbType.Int,pBanDocInfo.IDDanToc));
            colParam.Add(CreateParam("@IDNhomBanDoc",SqlDbType.Int,pBanDocInfo.IDNhomBanDoc));
            colParam.Add(CreateParam("@IDTrinhDo",SqlDbType.Int,pBanDocInfo.IDTrinhDo));
            colParam.Add(CreateParam("@IDNgheNghiep",SqlDbType.NChar,pBanDocInfo.IDNgheNghiep));
            colParam.Add(CreateParam("@Khoa",SqlDbType.NVarChar,pBanDocInfo.Khoa));
            colParam.Add(CreateParam("@Lop",SqlDbType.NVarChar,pBanDocInfo.Lop));
            colParam.Add(CreateParam("@NoiLamViec",SqlDbType.NVarChar,pBanDocInfo.NoiLamViec));
            colParam.Add(CreateParam("@GioiTinh",SqlDbType.Bit,pBanDocInfo.GioiTinh));
            colParam.Add(CreateParam("@DiaChi",SqlDbType.NVarChar,pBanDocInfo.DiaChi));
            colParam.Add(CreateParam("@ThanhPho",SqlDbType.NVarChar,pBanDocInfo.ThanhPho));
            colParam.Add(CreateParam("@IDTinh",SqlDbType.Int,pBanDocInfo.IDTinh));
            colParam.Add(CreateParam("@SoCMT",SqlDbType.NVarChar,pBanDocInfo.SoCMT));
            colParam.Add(CreateParam("@SoDienThoai",SqlDbType.NVarChar,pBanDocInfo.SoDienThoai));
            colParam.Add(CreateParam("@Email",SqlDbType.NVarChar,pBanDocInfo.Email));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pBanDocInfo.GhiChu));
            colParam.Add(CreateParam("@MaVung",SqlDbType.VarChar,pBanDocInfo.MaVung));
            colParam.Add(CreateParam("@KhoaThe",SqlDbType.Bit,pBanDocInfo.KhoaThe));
            colParam.Add(CreateParam("@AnhURL",SqlDbType.NVarChar,pBanDocInfo.AnhURL));
            colParam.Add(CreateParam("@BanDocID",SqlDbType.Int,pBanDocInfo.BanDocID));

            RunProcedure("sp_BanDoc_Update", colParam);
        }
        
        public void Delete(BanDocInfo pBanDocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@BanDocID",SqlDbType.Int,pBanDocInfo.BanDocID));

            RunProcedure("sp_BanDoc_Delete", colParam);
        }
    }
}
