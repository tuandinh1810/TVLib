using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.Lib.Win
{
    public class TVCurrency : LibBase
    {
        private static string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bẩy", " tám", " chín" };
        private static string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
        
        /// <summary>
        /// Chuyển từ cách viết số tiền không được ngăn cách
        /// bởi dấu , thành dạng được ngăn cách bởi dấu ,.
        /// VD: 12345000  --> 12,345,000
        /// </summary>
        public static string LongToText(long SoTien)
        {
            return SoTien.ToString("#,###");
        }
        /// <summary>
        /// Chuyển từ cách viết số tiền có dấu cách
        /// thành dạng không có dấu cách
        /// VD: 12,345,000  --> 12345000
        /// </summary>
        public static long TextToLong(string str)
        {
            string[] arrLong = str.Split(new Char[] { ',' });
            string strTmp = "";
            for (int i = 0; i < arrLong.Length; i++)
            {
                strTmp += arrLong[i].ToString();
            }
            return long.Parse(strTmp);
        }
        public static string TextToText(string str)
        {
            if (str.Trim() == "")
                return "";
            long n;
            if (!long.TryParse(str, out n))
                return "";
            return n.ToString("#,###");
        }

        public static string DocTienBangChu(long SoTien, string strTail)
        {
            int lan, i;
            long so;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];

            if (SoTien < 0) return "Số tiền âm !";
            if (SoTien == 0) return "Không đồng !";
            //so = (SoTien > 0) ? SoTien : -SoTien;//Nếu SoTien>0 thì trả về số tiền nếu không thì lấy ngược dấu lại
            so = SoTien;
            if (SoTien > 8999999999999999)
            {
                ThongBaoWinForms("Chương trình chỉ đọc được các số từ 8.999.999.999.999.999 trở xuống. Con số này quá lớn, chương trình không đọc được !", "Chu' y'!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
            {
                lan = 5;
            }
            else if (ViTri[4] > 0)
            {
                lan = 4;
            }
            else if (ViTri[3] > 0)
            {
                lan = 3;
            }
            else if (ViTri[2] > 0)
            {
                lan = 2;
            }
            else if (ViTri[1] > 0)
            {
                lan = 1;
            }
            else
            {
                lan = 0;
            }

            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
            }

            //sqlSELECT = sqlSELECT.Substring(0, sqlSELECT.Length - " AND CanBo_ID IN( ".Length); // Cat bo CanBo_ID IN( 
            if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + strTail;
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }

        /// <summary>
        /// Đọc 3 chữ số 
        /// </summary>
        /// <param name="baso"></param>
        /// <returns></returns>
        private static string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";

            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }

            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }

            if (chuc == 1) KetQua += " mười";

            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else
                    {
                        KetQua += " lăm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
        }
    }
}