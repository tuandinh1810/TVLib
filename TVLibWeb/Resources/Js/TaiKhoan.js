function CheckTaiKhoanInfor()
{
   
 if (  CheckNull(document.forms[0].txtTenDayDu,'Họ tên không được để trống!') == false        )
   {
     return false ;
   }
   else
   {
  
        if ( CheckNull(document.forms[0].txtTenDangNhap,'Tên đăng nhập không được để trống!')  == false        )
           {
             return false ;
           }
           else
           {
             if ( CheckNull(document.forms[0].txtEmail,'Địa chỉ Email không được để trống!')  == false        )
             {
                 return false ;
             }
            else
             {
                
                 if ( CheckNum(document.forms[0].txtMucDoMat,'Mức độ mật không đúng dịnh dạng kiểu số!')  == false        )
                 {
                     return false ;
                 }
                 else
                 {
                   if ( CheckNull(document.forms[0].txtDiaChi,'Địa chỉ không được để trống!')  == false        )
                     {
                         return false ;
                     }
                    else
                    {
                    if (document.forms[0].hidPassword.value == "")
                    {
                        if ( CheckNull(document.forms[0].txtMatKhau,'Mật khẩu không được để trống!') == true)
                        {
                            if (document.forms[0].txtMatKhau.value != document.forms[0].txtGoLaiMatKhau.value)
                                {
                                   alert ("Gõ lại mật khẩu không chính xác!");
                                   document.forms[0].txtGoLaiMatKhau.focus();
                                   return false ;
                                }
                         }
                         else
                          {
                            return false ;
                          }
                    }
                    else
                    {
                        if (document.forms[0].txtMatKhau.value != document.forms[0].txtGoLaiMatKhau.value)
                            {
                               alert ("Gõ lại mật khẩu không chính xác!");
                               document.forms[0].txtGoLaiMatKhau.focus();
                               return false ;
                            }
                    }
                   }
                  }
               
            }
           }
     }
}