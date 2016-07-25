using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TruongViet.Lib.Web
{
    public class TVValidate : LibBase
    {
        /// <summary>
        /// Kiểm tra một TextBox có nội dung đúng định dạng Ngày/Tháng/Năm,
        /// nếu đúng, sẽ trả về kết quả trong biến dtOut,
        /// ngược lại, sẽ thông báo sai, và yêu cầu nhập lại (từ TextBox)
        /// </summary>
        public static bool KiemTraNgayThang(TextBox textBox, string ThongBao, ref DateTime dtOut)
        {
            string sValue = textBox.Text;
            if (sValue.Trim() == "")
            {
                return true;
            }

            string[] arrDate = sValue.Split(new Char[] { '/' });
            if (arrDate.Length != 3)
            {
                ThongBaoWebForms(ThongBao + " không hợp lệ!\n\nĐịnh dạng: Ngày/tháng/năm");
                textBox.Focus();
                return false;
            }
            try
            {
                dtOut = new DateTime(int.Parse(arrDate[2]), int.Parse(arrDate[1]), int.Parse(arrDate[0]));
            }
            catch
            {
                ThongBaoWebForms(ThongBao + " không hợp lệ!\n\nĐịnh dạng: Ngày/tháng/năm");
                textBox.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra ngày tháng trên TextBox không cần giá trị trả về
        /// </summary>
        public static bool KiemTraNgayThang(TextBox textBox, string ThongBao)
        {
            DateTime dtOut = DateTime.MaxValue;
            return KiemTraNgayThang(textBox, ThongBao, ref dtOut);
        }

    }
}