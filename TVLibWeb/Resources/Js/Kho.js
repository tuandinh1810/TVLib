function CheckAddThuVien()
{

 if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtTenThuVien,'Tên thư viện không được để trống!') == false        )
   {
     return false ;
   }
   else
   {
       if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtMaThuVien,'Mã thư viện không được để trống!') == false        )
       {
         return false ;
       }
    }
 }
 
 function CheckAddKho()
{

 if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtTenKho,'Tên kho không được để trống!') == false        )
   {
     return false ;
   }
   else
   {
     if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtMaKho,'Mã kho không được để trống!') == false        )
       {
         return false ;
       }
    }
 }