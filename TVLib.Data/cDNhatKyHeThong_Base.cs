using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDNhatKyHeThong : cDBase
    {
        public DataTable Get(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NhatKy_ID",SqlDbType.Int,pNhatKyHeThongInfo.NhatKy_ID));

            return RunProcedureGet("sp_NhatKyHeThong_Get", colParam);            
        }

        public void Add(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IPMay",SqlDbType.VarChar,pNhatKyHeThongInfo.IPMay));
            colParam.Add(CreateParam("@TenDangNhap",SqlDbType.NVarChar,pNhatKyHeThongInfo.TenDangNhap));
            colParam.Add(CreateParam("@CongViec",SqlDbType.NVarChar,pNhatKyHeThongInfo.CongViec));
            colParam.Add(CreateParam("@ID_ChucNang",SqlDbType.Int,pNhatKyHeThongInfo.IDChucNang));           

            RunProcedure("sp_NhatKyHeThong_Add", colParam);
        }
        
        public void Update(NhatKyHeThongInfo pNhatKyHeThongInfo)
        {
            
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IPMay",SqlDbType.VarChar,pNhatKyHeThongInfo.IPMay));
            colParam.Add(CreateParam("@TenDangNhap",SqlDbType.NVarChar,pNhatKyHeThongInfo.TenDangNhap));
            colParam.Add(CreateParam("@CongViec",SqlDbType.NVarChar,pNhatKyHeThongInfo.CongViec));
            colParam.Add(CreateParam("@ThoiGian",SqlDbType.DateTime,pNhatKyHeThongInfo.ThoiGian));
            colParam.Add(CreateParam("@NhatKy_ID",SqlDbType.Int,pNhatKyHeThongInfo.NhatKy_ID));

            RunProcedure("sp_NhatKyHeThong_Update", colParam);
        }
    
        public void Delete(NhatKyHeThongInfo pNhatKyHeThongInfo)
           
         {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NhatKy_ID",SqlDbType.Int,pNhatKyHeThongInfo.NhatKy_ID));

            RunProcedure("sp_NhatKyHeThong_Delete", colParam);
        }
        public void DeleteLogs(string FromTime, string ToTime)
        {
            ArrayList colParam = new ArrayList();
            if (FromTime != "")
            {
                colParam.Add(CreateParam("@FromDate", SqlDbType.VarChar, 50, ConvertDateBack(FromTime, false).ToString()));
            }
            else
            {
                colParam.Add(CreateParam("@FromDate", SqlDbType.VarChar, 50, FromTime));

            }
            if (ToTime != "")
            {
                colParam.Add(CreateParam("@ToDate", SqlDbType.VarChar, 50, ConvertDateBack(ToTime, false).ToString()));
            }
            else
            {
                colParam.Add(CreateParam("@ToDate", SqlDbType.VarChar, 50, ToTime));
            } 
            

            RunProcedure("sp_Delete_Logs", colParam);
        }
        public DataTable Search(string strPhanHeIDs, string strChucNangIDs, string strChuoi, string strFromTime, string strToTime, string strTenDangNhap)
        {
             ArrayList colParam = new ArrayList();
             colParam.Add(CreateParam("@PhanHeIDs",SqlDbType.VarChar, 100 ,strPhanHeIDs  ));
             colParam.Add(CreateParam("@ChucNangIDs", SqlDbType.VarChar, 1000, strChucNangIDs));
             colParam.Add(CreateParam("@TenDangNhap", SqlDbType.VarChar,50,strTenDangNhap));
             colParam.Add(CreateParam("@Chuoi", SqlDbType.NVarChar, 500, strChuoi));
             if (strFromTime != "")
             {
                 colParam.Add(CreateParam("@FromDate", SqlDbType.VarChar, 50, ConvertDateBack(strFromTime, false).ToString()));
             }
             else
             {
                 colParam.Add(CreateParam("@FromDate", SqlDbType.VarChar, 50, strFromTime));

             }
             if (strToTime != "")
             {
                 colParam.Add(CreateParam("@ToDate", SqlDbType.VarChar, 50, ConvertDateBack(strToTime, false).ToString()));
             }
             else
             {
                 colParam.Add(CreateParam("@ToDate", SqlDbType.VarChar, 50, strToTime));
             }
             return RunProcedureGet("sp_NhatKyHeThong_Search", colParam);
                      
        }
    }
}
