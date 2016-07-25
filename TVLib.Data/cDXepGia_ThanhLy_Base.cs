using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDXepGia_ThanhLy : cDBase
    {
        public DataTable Get(XepGia_ThanhLyInfo pXepGia_ThanhLyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ID",SqlDbType.Int,pXepGia_ThanhLyInfo.ID));

            return RunProcedureGet("sp_XepGia_ThanhLy_Get", colParam);            
        }

        public int Add(XepGia_ThanhLyInfo pXepGia_ThanhLyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pXepGia_ThanhLyInfo.MaXepGia));
            colParam.Add(CreateParam("@LuuThong",SqlDbType.Bit,pXepGia_ThanhLyInfo.LuuThong));
            colParam.Add(CreateParam("@DangMuon",SqlDbType.Bit,pXepGia_ThanhLyInfo.DangMuon));
            colParam.Add(CreateParam("@Shelf",SqlDbType.NVarChar,pXepGia_ThanhLyInfo.Shelf));
            colParam.Add(CreateParam("@KiemNhan",SqlDbType.Bit,pXepGia_ThanhLyInfo.KiemNhan));
            colParam.Add(CreateParam("@NgayThanhLy",SqlDbType.DateTime,pXepGia_ThanhLyInfo.NgayThanhLy));
            colParam.Add(CreateParam("@NgayXepGia",SqlDbType.DateTime,pXepGia_ThanhLyInfo.NgayXepGia));
            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pXepGia_ThanhLyInfo.IDTaiLieu));
            colParam.Add(CreateParam("@IDKho",SqlDbType.Int,pXepGia_ThanhLyInfo.IDKho));
            colParam.Add(CreateParam("@IDLyDoThanhLy",SqlDbType.Int,pXepGia_ThanhLyInfo.IDLyDoThanhLy));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_XepGia_ThanhLy_Add", colParam);
        }
        
        public void Update(XepGia_ThanhLyInfo pXepGia_ThanhLyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaXepGia",SqlDbType.VarChar,pXepGia_ThanhLyInfo.MaXepGia));
            colParam.Add(CreateParam("@LuuThong",SqlDbType.Bit,pXepGia_ThanhLyInfo.LuuThong));
            colParam.Add(CreateParam("@DangMuon",SqlDbType.Bit,pXepGia_ThanhLyInfo.DangMuon));
            colParam.Add(CreateParam("@Shelf",SqlDbType.NVarChar,pXepGia_ThanhLyInfo.Shelf));
            colParam.Add(CreateParam("@KiemNhan",SqlDbType.Bit,pXepGia_ThanhLyInfo.KiemNhan));
            colParam.Add(CreateParam("@NgayThanhLy",SqlDbType.DateTime,pXepGia_ThanhLyInfo.NgayThanhLy));
            colParam.Add(CreateParam("@NgayXepGia",SqlDbType.DateTime,pXepGia_ThanhLyInfo.NgayXepGia));
            colParam.Add(CreateParam("@IDTaiLieu",SqlDbType.Int,pXepGia_ThanhLyInfo.IDTaiLieu));
            colParam.Add(CreateParam("@IDKho",SqlDbType.Int,pXepGia_ThanhLyInfo.IDKho));
            colParam.Add(CreateParam("@IDLyDoThanhLy",SqlDbType.Int,pXepGia_ThanhLyInfo.IDLyDoThanhLy));
            colParam.Add(CreateParam("@ID",SqlDbType.Int,pXepGia_ThanhLyInfo.ID));

            RunProcedure("sp_XepGia_ThanhLy_Update", colParam);
        }
        
        public void Delete(XepGia_ThanhLyInfo pXepGia_ThanhLyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ID",SqlDbType.Int,pXepGia_ThanhLyInfo.ID));

            RunProcedure("sp_XepGia_ThanhLy_Delete", colParam);
        }
    }
}
