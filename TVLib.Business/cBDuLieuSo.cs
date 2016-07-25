using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;
using TruongViet.TVLib.Entity;
using TruongViet.TVLib.Data;

namespace TruongViet.TVLib.Business
{
    public class cBDuLieuSo
    {
        public static Boolean TaoThuMuc(string strduongdan, string strtenthumuc)
        {
            DirectoryInfo objThuMuc;
            DirectoryInfo objExitThuMuc;
            Boolean blntaothumuc = false;
            try
            {
                objThuMuc = new DirectoryInfo(strduongdan);
                objExitThuMuc = new DirectoryInfo(strduongdan + "\\" + strtenthumuc);
                if (objThuMuc.Exists)
                {
                    if (!objExitThuMuc.Exists)
                    {
                        objThuMuc.CreateSubdirectory(strtenthumuc);
                        blntaothumuc = true;
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return blntaothumuc;
        }
        public static Boolean DoiTenThuMuc(string strduongdan, string strtenthumuc, ref string strtenthumucmoi)
        {

            DirectoryInfo objThuMuc;
            DirectoryInfo objCheckThuMuc;
            string strTenThuMucCu = "";
            Boolean blnDoiTenThuMuc = false;
            cBFiLes objFiles = new cBFiLes();
            try
            {
                if (strtenthumuc.Trim() == "")
                {
                    strtenthumuc = "null";
                }
                objThuMuc = new DirectoryInfo(strduongdan);
                if (objThuMuc.Exists)
                {
                    strTenThuMucCu = objThuMuc.Parent.FullName + "\\" + objThuMuc.Name;
                    if (objThuMuc.FullName.Substring(objThuMuc.FullName.Length - 2, 2) == ":\\")
                    {
                        strtenthumucmoi = objThuMuc.Parent.FullName + "\\" + strtenthumuc;
                    }
                    else
                    {
                        strtenthumucmoi = objThuMuc.Parent.FullName + "\\" + strtenthumuc;
                    }
                    objCheckThuMuc = new DirectoryInfo(strtenthumucmoi);
                    if (!objCheckThuMuc.Exists)
                    {
                        objThuMuc.MoveTo(strtenthumucmoi);
                        objFiles.Update_DuongDan(strduongdan,strtenthumucmoi);
                        blnDoiTenThuMuc = true;
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return blnDoiTenThuMuc;
        }
        public static Boolean XoaThuMuc(string strduongdan)
        {
            DirectoryInfo objThuMuc;
            Boolean blnxoathumuc = false;
            objThuMuc = new DirectoryInfo(strduongdan);
            try
            {
                if (objThuMuc.Exists)
                {
                    if (objThuMuc.GetFiles().Length > 0)
                    {
                        foreach (FileInfo objFile in objThuMuc.GetFiles())
                        {
                            objFile.Delete();
                        }
                    }
                } objThuMuc.Delete();
                blnxoathumuc = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnxoathumuc;
        }
        public static int DongBoDuLieu(string strduongdan)
        {
            int intdongbodulieu = 0;
            DirectoryInfo DirInfor;
            DataTable dtbDulieuso;
            FiLesInfo objFileInfor = new FiLesInfo();
            cBFiLes cBobjFile = new cBFiLes();
            FileInfo objFiles;
            objFileInfor.FileID = 0;
            dtbDulieuso = cBobjFile.Get(objFileInfor);
            DirInfor = new DirectoryInfo(strduongdan);
            try
            {
                //Check Data
                if (dtbDulieuso != null)
                {
                    if (dtbDulieuso.Rows.Count > 0)
                    {
                        for (int intIndex = 0; intIndex < dtbDulieuso.Rows.Count; intIndex++)
                        {
                            //Kiem tra su ton tai cua file
                            objFiles = new FileInfo(dtbDulieuso.Rows[intIndex][objFileInfor.strDuongDanVatLy].ToString());
                            if (!objFiles.Exists && (Boolean)dtbDulieuso.Rows[intIndex][objFileInfor.strExisted] == true)
                            {
                                objFileInfor = new FiLesInfo();
                                objFileInfor.Existed = false;
                                objFileInfor.FileID = int.Parse(dtbDulieuso.Rows[intIndex][objFileInfor.FileID].ToString());
                                cBobjFile.UpdateExisted(objFileInfor);
                            }
                            else
                                if (objFiles.Exists && (Boolean)dtbDulieuso.Rows[intIndex][objFileInfor.strExisted] == false)
                                {
                                    objFileInfor = new FiLesInfo();
                                    objFileInfor.Existed = true;
                                    objFileInfor.FileID = (int)dtbDulieuso.Rows[intIndex][objFileInfor.FileID];
                                    cBobjFile.UpdateExisted(objFileInfor);
                                }
                        }
                    }
                }


                foreach (FileInfo objFile in DirInfor.GetFiles("*"))
                {
                    string strduongdanfile = strduongdan + "\\" + objFile.Name;
                    dtbDulieuso.DefaultView.RowFilter = "DuongDanVatLy='" + strduongdanfile + "'";
                    if (dtbDulieuso != null && dtbDulieuso.DefaultView.Count == 0)
                    {
                        objFileInfor.TenFile = objFile.Name;
                        objFileInfor.KichCoFile = objFile.Length;
                        objFileInfor.DangFile = objFile.Extension.Replace(".", "");
                        objFileInfor.DuongDanVatLy = strduongdanfile;
                        objFileInfor.MaTrangThai = "1";
                        objFileInfor.SoTrang = 0;
                        objFileInfor.CapDoMat = 1;
                        objFileInfor.GiaTien = 1;
                        objFileInfor.DuongDanThuMuc = strduongdan;
                        objFileInfor.NgayUpLoad = DateTime.Now;
                        objFileInfor.NguoiUpLoad = "";
                        objFileInfor.SoLanDownLoad = 0;
                        objFileInfor.ThuPhi = false;
                        objFileInfor.Existed = true;
                        intdongbodulieu = cBobjFile.Add(objFileInfor);
                    }
                    else
                    {
                        objFileInfor.KichCoFile = objFile.Length;
                        objFileInfor.Existed = true;
                        objFileInfor.FileID = (int)dtbDulieuso.DefaultView[0][0];
                        cBobjFile.UpdateExisted(objFileInfor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intdongbodulieu;

        }
        public static void ImportFileToDataBase(string strThuMucUpLoad,string strTenFile)
        {
            FileInfo objFile;
            FiLesInfo objFileInfo=new FiLesInfo();
            cBFiLes cBobjFile=new cBFiLes();
            string strFilePath = "";
            DataTable dtbFiles;
            int ImportFile;
            strFilePath = strThuMucUpLoad + "\\" + strTenFile;
            objFile = new FileInfo(strFilePath);
            dtbFiles=cBobjFile.GetFileByDuongDanVatLy(strFilePath);
            if (dtbFiles != null && dtbFiles.Rows.Count > 0)
            {
                objFileInfo.FileID = (int)dtbFiles.Rows[0][objFileInfo.strFileID];
                objFileInfo.KichCoFile = objFile.Length;
                objFileInfo.NguoiUpLoad = "Admin";
                objFileInfo.NgayUpLoad = DateTime.Now;
                objFileInfo.Existed = true;
                cBobjFile.Update_Existed(objFileInfo);
            }
            else
            {
                objFileInfo.TenFile = objFile.Name;
                objFileInfo.KichCoFile = objFile.Length;
                objFileInfo.DangFile = objFile.Extension.Replace(".", "");
                objFileInfo.DuongDanVatLy = strFilePath;
                objFileInfo.MaTrangThai = "1";
                objFileInfo.SoTrang = 0;
                objFileInfo.CapDoMat = 1;
                objFileInfo.GiaTien = 1;
                objFileInfo.DuongDanThuMuc = strThuMucUpLoad;
                objFileInfo.NgayUpLoad = DateTime.Now;
                objFileInfo.NguoiUpLoad = "";
                objFileInfo.SoLanDownLoad = 0;
                objFileInfo.ThuPhi = false;
                objFileInfo.Existed = true;
                ImportFile = cBobjFile.Add(objFileInfo);
            }
        }
        public static void DoiTrangThai(string strFileID,string strMaTrangThai)
        {
            cBFiLes objFile = new cBFiLes();
            string[] arrFileID;
            strFileID = strFileID.Substring(1, strFileID.Length - 2);
            arrFileID = strFileID.Split(',');
            if(arrFileID.Length>0)
            {
                try
                {
                    for (int i = 0; i < arrFileID.Length; i++)
                    {
                        objFile.Update_TrangThai(strMaTrangThai, int.Parse(arrFileID[i].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static void CapDoMat(string strFileID, int intCapDoMat)
        {
            cBFiLes objFile = new cBFiLes();
            string[] arrFileID;
            strFileID = strFileID.Substring(1, strFileID.Length - 2);
            arrFileID = strFileID.Split(',');
            if (arrFileID.Length > 0)
            {
                try
                {
                    for (int i = 0; i < arrFileID.Length; i++)
                    {
                        objFile.Update_CapDoMat(intCapDoMat, int.Parse(arrFileID[i].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static void ThuPhi(string strFileID, Boolean blnThuPhi)
        {
            cBFiLes objFile = new cBFiLes();
            string[] arrFileID;
            strFileID = strFileID.Substring(1, strFileID.Length - 2);
            arrFileID = strFileID.Split(',');
            if (arrFileID.Length > 0)
            {
                try
                {
                    for (int i = 0; i < arrFileID.Length; i++)
                    {
                        objFile.Update_ThuPhi(blnThuPhi, int.Parse(arrFileID[i].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static void XoaFile(string strFileID)
        {
            cBFiLes objFile = new cBFiLes();
            FiLesInfo objFilesInFor;
            string[] arrFileID;
            strFileID = strFileID.Substring(1, strFileID.Length - 2);
            arrFileID = strFileID.Split(',');
            if (arrFileID.Length > 0)
            {
                try
                {
                    for (int i = 0; i < arrFileID.Length; i++)
                    {
                        objFilesInFor=new FiLesInfo();
                        objFilesInFor.FileID=int.Parse( arrFileID[i].ToString());
                        objFile.Delete(objFilesInFor);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static Boolean Xoa(string strFileID)
        {
            Boolean bnlXoa = false;
            FileInfo objFileInfor;
            FiLesInfo objFilesInfor;
            cBFiLes objFiles;
            string[] arrFileID;
            DataTable dtbFile;
            strFileID = strFileID.Substring(1, strFileID.Length - 2);
            arrFileID = strFileID.Split(',');
            if (arrFileID.Length > 0)
            {
                try
                {
                    for (int i = 0; i < arrFileID.Length; i++)
                    {
                        dtbFile = new DataTable();
                        
                        objFiles = new cBFiLes();
                        objFilesInfor = new FiLesInfo();
                        objFilesInfor.FileID = int.Parse(arrFileID[i].ToString());
                        dtbFile = objFiles.Get(objFilesInfor);
                        if (dtbFile.Rows.Count > 0)
                        {
                            objFileInfor = new FileInfo(dtbFile.Rows[0]["DuongDanVatLy"].ToString());
                            if (objFileInfor.Exists)
                            {
                                objFileInfor.Delete();
                                bnlXoa = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return bnlXoa;
          
        }
    
        //public static void SuaTenThuMuc()
        public static string FormatSize(double kichcofile)
        {
            if (kichcofile < 1024)
            {
                return String.Format("{0:N0} B", kichcofile);
            }
            else
                if (kichcofile < 1024 * 1024)
                {
                    return String.Format("{0:N0} B", kichcofile / 1024);
                }
                else
                {
                    return String.Format("{0:N2} MB", kichcofile / (1024 * 1024));
                }
        }


        public static bool CheckSysDir(string strLoc)
        {
            bool functionReturnValue = false;
            //  string[] strURLPaths = null;
            //int i = 0;

            try
            {
                functionReturnValue = false;
                // if (!string.IsNullOrEmpty(objSysPara(7).ToString.Trim)) {
                //strSysDirs = Strings.Split(objSysPara(7).Trim, ";");
                // if ((strSysDirs != null) && Information.UBound(strSysDirs) > 0) 
                //{
                //   for (i = Information.LBound(strSysDirs); i <= Information.UBound(strSysDirs) - 1; i++) 
                // {
                // if (Strings.InStr(Strings.LCase(strLoc + "\\"), Strings.LCase(Strings.Replace(strSysDirs(i), "/", "\\"))) > 0)
                // {
                //   functionReturnValue = true;
                //   return;
                //}
                if (strLoc.ToLower().IndexOf("C:\\TruongViet".ToLower()) >= 0)
                {
                    functionReturnValue = true;
                }
                //        }
                //}
            }
            //}
            catch (Exception ex)
            {
                functionReturnValue = false;
                throw ex;
            }
            return functionReturnValue;
        }
      

        public Boolean CheckSize(long lngSizeF)
        {
        // default = 10 MB
             if (lngSizeF >= (10 * 1024))
            {
              return false;
            }
             else 
            {
              return true;
            }
        }
      
    }
    }


