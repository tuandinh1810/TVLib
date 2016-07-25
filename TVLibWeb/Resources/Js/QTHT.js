function CheckUserInfor()
{
   
 if (  CheckNull(document.forms[0].txthoten,'Họ tên không được để trống!') == false        )
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
          
                if (document.forms[0].hdPassword.value == "")
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


// If find an check object, check, if not, through away
function CheckOptionVisible(strDtgName, strOptionName, intvalue){	
	var blnStatus;						
	
	if (eval('document.forms[0].' + strDtgName + '_ctl' + intvalue + '_' + strOptionName))
	{
	if (eval('document.forms[0].' + strDtgName + '_ctl' + intvalue + '_' + strOptionName).checked) 
	{
		blnStatus = false;
	}
	else
	{
		blnStatus = true;	
	}	
	eval('document.forms[0].' + strDtgName + '_ctl' + intvalue + '_' + strOptionName).checked = blnStatus;			
	}			
	
}

// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg){	
	var intCounter;	          			
	var intCount;          
	
	intCount = 0;
	
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++)
	 {
	     if (intCounter >10)
	    {				  
	      if (eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName).checked)
		    {
			    intCount = intCount + 1		
		    }
		}
		else
		{
		      if (eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName).checked)
		{
			intCount = intCount + 1		
		}
		}			
	}
	
	if (intCount != 0) {
		return true;
	}
	else
	{
		alert(strMsg);
		return false;
	}
}

