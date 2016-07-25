function CheckNhapTien()
{
   
 if (  CheckNull(document.forms[0].txtMaTaiKhoan,'Bạn chưa nhập đầy đủ thông tin!') == false        )
   {
     return false ;
   }
   else
   {
         if ( CheckNum(document.forms[0].txtTienNap,'Dữ liệu không phải kiểu số!')  == false )
         
         {
                     return false ;
        }
         
     }
}

function CheckCurrencyInfor()
{
if (  CheckNull(document.forms[0].txtMaTien,'Bạn chưa nhập đầy đủ thông tin!') == false        )
   {
     return false ;
   }
   else
   {
         if ( CheckNum(document.forms[0].txtTyGia,'Dữ liệu không phải kiểu số!')  == false )
         
         {
                     return false ;
        }
         
     }
}