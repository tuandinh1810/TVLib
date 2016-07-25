using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.TVLib.Entity;

namespace TruongViet.TVLib.Data
{
    public partial class cDXepGia_LyDoThanhLy : cDBase
    {
        public DataTable Get(XepGia_LyDoThanhLyInfo pXepGia_LyDoThanhLyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LyDoID",SqlDbType.Int,pXepGia_LyDoThanhLyInfo.LyDoID));

            return RunProcedureGet("sp_XepGia_LyDoThanhLy_Get", colParam);            
        }

        public int Add(XepGia_LyDoThanhLyInfo pXepGia_LyDoThanhLyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NoiDungLyDo",SqlDbType.NVarChar,pXepGia_LyDoThanhLyInfo.NoiDungLyDo));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return RunProcedureOut("sp_XepGia_LyDoThanhLy_Add", colParam);
        }
        
        public void Update(XepGia_LyDoThanhLyInfo pXepGia_LyDoThanhLyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NoiDungLyDo",SqlDbType.NVarChar,pXepGia_LyDoThanhLyInfo.NoiDungLyDo));
            colParam.Add(CreateParam("@LyDoID",SqlDbType.Int,pXepGia_LyDoThanhLyInfo.LyDoID));

            RunProcedure("sp_XepGia_LyDoThanhLy_Update", colParam);
        }
        
        public void Delete(XepGia_LyDoThanhLyInfo pXepGia_LyDoThanhLyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LyDoID",SqlDbType.Int,pXepGia_LyDoThanhLyInfo.LyDoID));

            RunProcedure("sp_XepGia_LyDoThanhLy_Delete", colParam);
        }
    }
}
