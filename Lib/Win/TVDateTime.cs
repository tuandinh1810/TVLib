using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TruongViet.Lib.Win
{
    public class TVDateTime : LibBase
    {
        /// <summary>
        /// Kiểm tra một chuỗi có đúng định dạng ngày/tháng/năm
        /// </summary>
        public static bool KiemTraNgayThang(string NgayThangCanKiemTra, string ThongBao)
        {
            string sValue = NgayThangCanKiemTra;
            DateTime dtOut = new DateTime();
            if (sValue.Trim() == "")
            {
                return true;
            }

            string[] arrDate = sValue.Split(new Char[] { '/' });
            if (arrDate.Length != 3)
            {
                ThongBaoWinForms(ThongBao + " không hợp lệ!\n\nĐịnh dạng: Ngày/tháng/năm", "Chu' y'!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            try
            {
                dtOut = new DateTime(int.Parse(arrDate[2]), int.Parse(arrDate[1]), int.Parse(arrDate[0]));
            }
            catch
            {
                ThongBaoWinForms(ThongBao + " không hợp lệ!\n\nĐịnh dạng: Ngày/tháng/năm", "Chu' y'!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Chuyển đổi kiểu ngày tháng từ Việt sang Anh. 
        /// Nếu có lỗi sẽ trả về ngày lớn nhất (31/12/9999)
        /// </summary>
        public static DateTime ChuyenVietSangAnh(string sDate)
        {
            if (sDate == "")
                return DateTime.MaxValue;
            DateTime dtOut = DateTime.MaxValue;
            string[] arrDate = sDate.Split(new Char[] { '/' });
            try
            {
                dtOut = new DateTime(int.Parse(arrDate[2]), int.Parse(arrDate[1]), int.Parse(arrDate[0]));
                return dtOut;
            }
            catch
            {
                return DateTime.MaxValue;
            }
        }

        /// <summary>
        /// Chuyển đổi kiểu ngày tháng từ Anh sang Việt. 
        /// </summary>
        public static string ChuyenAnhSangViet(string sDate)
        {
            if (sDate == "")
                return "";
            string[] arrDate = sDate.Split(new Char[] { '/' });
            return arrDate[1].ToString() + "/" + arrDate[0].ToString() + "/" + arrDate[2].ToString();
        }        

        /// <summary>
        /// Đọc ngày/tháng/năm.
        /// VD: 2/3/2005 --> Hà Nội, ngày 2 tháng 3 năm 2005
        /// trong đó "Hà Nội" được lấy từ trường TenTinhThanh trong bảng HangSo
        /// </summary>
        public static string DocNgayThangNam(DateTime dt)
        {
            if (dt != DateTime.MaxValue)
                return "Ngày " + dt.Day.ToString("00") + " tháng " + dt.Month.ToString("00") + " năm " + dt.Year.ToString("0000");
            else
                return "Ngày ... tháng ... năm ......";
        }

        /// <summary>
        /// Tính ngày mới
        /// </summary>
        public static DateTime TinhNgay(DateTime TuNgay, int SoNgay)
        {
            return TuNgay.AddDays(SoNgay);
            //TimeSpan duration = new TimeSpan(SoNgay, 0, 0, 0);
            //return TuNgay.Add(duration);
        }

        /// <summary>
        /// Tạo ra một biến kiểu DateTime với các tham số [Ngay, Thang, Nam]
        /// </summary>
        public static DateTime TaoNgay(int ngay, int thang, int nam)
        {
            DateTime dt = new DateTime(nam, thang, ngay);
            return dt;
        }

        /// <summary>
        /// Kiểm tra một chuỗi có đúng định dạng tháng/năm
        /// </summary>
        public static bool KiemTraThangNam(string sThangNam)
        {
            string sTmp = sThangNam;
            if (sTmp.IndexOf('/') < 0)
            {
                ThongBaoWinForms("Định dạng tháng năm không hợp lệ!\n\nĐịnh dạng: Tháng/năm (mm/yyyy)", "Chu' y'!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            string[] arrTmp = sTmp.Split(new char[] {'/'});
            if (arrTmp.Length != 2) {
                ThongBaoWinForms("Định dạng tháng năm không hợp lệ!\n\nĐịnh dạng: Tháng/năm (mm/yyyy)", "Chu' y'!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            int Thang, Nam;
            if (!int.TryParse(arrTmp[0], out Thang))
            {
                ThongBaoWinForms("Định dạng tháng năm không hợp lệ!\n\nĐịnh dạng: Tháng/năm (mm/yyyy)", "Chu' y'!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (!int.TryParse(arrTmp[1], out Nam))
            {
                ThongBaoWinForms("Định dạng tháng năm không hợp lệ!\n\nĐịnh dạng: Tháng/năm (mm/yyyy)", "Chu' y'!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (Thang<=0 || Thang > 12)
            {
                ThongBaoWinForms("Định dạng tháng năm không hợp lệ!\n\nĐịnh dạng: Tháng/năm (mm/yyyy)", "Chu' y'!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (Nam < 1900)
            {
                ThongBaoWinForms("Định dạng tháng năm không hợp lệ!\n\nĐịnh dạng: Tháng/năm (mm/yyyy)", "Chu' y'!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Chuyển một chuỗi định dạng tháng/năm sang kiểu 
        /// DateTime để có thể lưu vào CSDL
        /// </summary>
        public static DateTime ChuyenThangNamSangDateTime(string sThangNam)
        {
            if (string.IsNullOrEmpty(sThangNam))
                return DateTime.MaxValue;
            return ChuyenVietSangAnh("1/" + sThangNam);
        }

        /// <summary>
        /// Chuyển một chuỗi định dạng DateTime
        /// sang định dạng tháng/năm
        /// </summary>
        public static string ChuyenDateTimeSangThangNam(string sDate)
        {
            DateTime dtTmp;
            if (DateTime.TryParse(sDate, out dtTmp))
                return dtTmp.Month.ToString() + '/' + dtTmp.Year.ToString();
            else
                return "";
        }
    }
}