using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public class clsStringHelper
    {

        #region Đọc tiền bằng tiếng Anh
        String[] millionsName = { "", " thousand", " million", " billion", " trillion", " quadrillion", " quintillion" };

        String[] tensNames = { "", " ten", " twenty", " thirty", " fourty", " fifty", " sixty", " seventy", " eighty", " ninety" };

        String[] numNames = { "", " one", " two", " three", " four", " five", " six", " seven", " eight", " nine", " ten", " eleven", " twelve", " thirteen", " fourteen", " fifteen", " sixteen", " seventeen", " eighteen", " nineteen" };

        private string convertLessThanOneThousand(int number)
        {
            String soFar;

            if (number % 100 < 20)
            {
                soFar = numNames[number % 100];
                number /= 100;
            }
            else
            {
                soFar = numNames[number % 10];
                number /= 10;

                soFar = tensNames[number % 10] + soFar;
                number /= 10;
            }
            if (number == 0) return soFar;
            return numNames[number] + " hundred" + soFar;
        }

        public string convert(int number)
        {
            /* special case */
            if (number == 0) { return "zero"; }

            String prefix = "";

            if (number < 0)
            {
                number = -number;
                prefix = "negative";
            }

            String soFar = "";
            int place = 0;

            do
            {
                int n = number % 1000;
                if (n != 0)
                {
                    String s = convertLessThanOneThousand(n);
                    soFar = s + millionsName[place] + soFar;
                }
                place++;
                number /= 1000;
            } while (number > 0);

            return (prefix + soFar).Trim();
        }

        #endregion


        #region Đọc tiền bằng tiếng việt

        private string ReadGroup3(string G3)
        {
            string[] ReadDigit = new string[10] { " Không", " Một", " Hai", " Ba", " Bốn", " Năm", " Sáu", " Bảy", " Tám", " Chín" };
            string temp = "";
            
            if (G3 == "000") return "";

            //Đọc số hàng trăm
            temp = ReadDigit[int.Parse(G3[0].ToString())] + " Trăm";
            //Đọc số hàng chục
            if (G3[1].ToString() == "0")
                if (G3[2].ToString() == "0") return temp;
                else
                {
                    temp += " Lẻ" + ReadDigit[int.Parse(G3[2].ToString())];
                    return temp;
                }
            else
                temp += ReadDigit[int.Parse(G3[1].ToString())] + " Mươi";
            //--------------Đọc hàng đơn vị

            if (G3[2].ToString() == "5") temp += " Lăm";
            else if (G3[2].ToString() != "0") temp += ReadDigit[int.Parse(G3[2].ToString())];
            return temp;


        }

        public string ReadMoney(string Money)
        {
            Money = double.Parse(Money).ToString("N0").Replace(",","").Replace(".","");
            string temp = "";
            // Cho đủ 12 số
            while (Money.Length < 12)
            {
                Money = "0" + Money;
            }
            string g1 = Money.Substring(0, 3);
            string g2 = Money.Substring(3, 3);
            string g3 = Money.Substring(6, 3);
            string g4 = Money.Substring(9, 3);

            //Đọc nhóm 1 ---------------------
            if (g1 != "000")
            {
                temp = ReadGroup3(g1);
                temp += " Tỷ";
            }
            //Đọc nhóm 2-----------------------
            if (g2 != "000")
            {
                temp += ReadGroup3(g2);
                temp += " Triệu";
            }
            //---------------------------------
            if (g3 != "000")
            {
                temp += ReadGroup3(g3);
                temp += " Ngàn";
            }
            //-----------------------------------
            //Chỗ này ko biết có nên ko ?
            //temp =temp + ReadGroup3(g4).Replace("Không Trăm Lẻ","Lẻ"); // Đọc 1000001 là Một Triệu Lẻ Một thay vì Một Triệu Không Trăm Lẻ 1;
            temp = temp + ReadGroup3(g4);
            //---------------------------------
            // Tinh chỉnh
            temp = temp.Replace("Một Mươi", "Mười");
            temp = temp.Trim();
            if (temp.IndexOf("Không Trăm") == 0)
                temp = temp.Remove(0, 10);
            temp = temp.Trim();
            if (temp.IndexOf("Lẻ") == 0)
                temp = temp.Remove(0, 2);
            temp = temp.Trim();
            temp = temp.Replace("Mươi Một", "Mươi Mốt");
            temp = temp.Trim();
            //Change Case
            if (temp != "")
            {
                return temp.Substring(0, 1).ToUpper() + temp.Substring(1).ToLower();
            }
            else
            {
                return "0.00";
            }

        }

        #endregion
        
        public string FormatTenVietTat(string Ho_ten)
        {
            string TenVT = null;
            string[] str = null;
            str = Ho_ten.Trim().Split(new char[] { ' ' });
            if (str.Length > 1)
            {
                TenVT = str[str.Length - 1];
                for (int i = 0; i <= str.Length - 2; i++)
                {
                    if (str[i] != string.Empty)
                    {
                        TenVT += str[i].Substring(0, 1);
                    }
                }
                return TenVT;
            }
            else
            {
                return Ho_ten;
            }
        }

        public string GetTen(string Ho_ten)
        {
            string Ten = null;
            string[] str = null;
            str = Ho_ten.Trim().Split(new char[] { ' ' });
            Ten = str[str.Length - 1];
            return Ten;
        }

        private string GetNextSring(string value)
        {
            string res = string.Empty;
            char[] Charactors = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] Numbers = "0123456789".ToCharArray();
            char[] cValue = value.ToCharArray();

            int idxThem = -1;
            for (int i = cValue.Length - 1; i >= 0; i--)
            {
                if (char.IsNumber(cValue[i]))
                {
                    if (cValue[i].CompareTo(Numbers[Numbers.Length - 1]) < 0)
                    {
                        idxThem = i;
                        break;
                    }
                }
                else
                {
                    if (cValue[i].CompareTo(Charactors[Charactors.Length - 1]) < 0)
                    {
                        idxThem = i;
                        break;
                    }
                }
            }

            if (idxThem == -1)
            {
                if (char.IsNumber(cValue[0]))
                    cValue = (Numbers[1].ToString() + value).ToCharArray();
                else
                    cValue = (Charactors[0].ToString() + value).ToCharArray();
                idxThem++;
            }
            else
            {
                if (char.IsNumber(cValue[idxThem]))
                {
                    string temp = (Int32.Parse(cValue[idxThem].ToString()) + 1).ToString();
                    cValue[idxThem] = temp.ToCharArray()[0];
                }
                else
                {
                    for (int i = 0; i < Charactors.Length; i++)
                        if (Charactors[i].CompareTo(cValue[idxThem]) == 0)
                        {
                            cValue[idxThem] = Charactors[i + 1];
                            break;
                        }

                }
            }


            for (int i = cValue.Length - 1; i > idxThem; i--)
            {
                if (char.IsNumber(cValue[i]))
                    cValue[i] = Numbers[0];
                else
                    cValue[i] = Charactors[0];
            }

            for (int i = 0; i < cValue.Length; i++)
                res += cValue[i].ToString();

            return res;
        }

        /// <summary>
        /// Tạo một mảng chuỗi tăng
        /// TrungVK
        /// </summary>
        /// <param name="strBatDau"></param>
        /// <param name="iLenght"></param>
        /// <returns></returns>
        public string[] GetStringsIncrease(string strBatDau, int iLenght)
        {
            string[] strKetQua = new string[iLenght];
            strKetQua[0] = strBatDau;
            for (int i = 1; i <= iLenght - 1; i++)
            {
                strKetQua[i] = GetNextSring(strKetQua[i - 1]);
            }
            return strKetQua;
        }
    }

}
