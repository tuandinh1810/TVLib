function CheckGhiMuon()
{

 if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtSoThe,'') == false && document.forms[0].ctl00$ContentPlaceHolder1$ddlBanDoc.selectedIndex == 0)
   {
        alert('Bạn phải chọn thông tin bạn đọc!');
        return false ;
   }
   else
   {
        if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtDKCB,'Đăng ký cá biệt không được để trống!') == false        )
       {
         return false ;
       }
       else
       {
              if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayMuon,'Ngày mượn không được để trống!') == false        )
               {
                 return false ;
               }
               else
               {
                        if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayTra,'Ngày trả không được để trống!') == false        )
                       {
                         return false ;
                       }
                       else
                       {
                               if (  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayMuon,'Không đúng kiểu dữ liệu ngày tháng!') == false        )
                                   {
                                     return false ;
                                   }
                                   else
                                   {
                                         if (  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayTra,'Không đúng kiểu dữ liệu ngày tháng!') == false        )
                                           {
                                             return false ;
                                           }
                                  }
                         }
                  }
       }
    }
 }
 
 function CheckGhiTra()
{

 if (CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtDKCB,'Đăng ký cá biệt không được để trống!') == false  )
   {
      return false ;
     
   }
 
 }
 