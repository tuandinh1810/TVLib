
// Check for Addnew
function CheckInputNhanGay()
{
   if (CheckNull(document.forms[0].txtTenMau,'Bạn chưa điền đầy đủ thông tin!') == false)
       {
         return false ;
       }
	else
	 {
      //  document.forms[0].txtTenMau.value=ReplaceString(document.forms[0].txtTenMau.value,1)
         if (  CheckNull(document.forms[0].txtNoiDung,'Bạn chưa điền đầy đủ thông tin!') == false)
         {
            return false ;
         }
//	    else
//	     {
//            document.forms[0].txtNoiDung.value=ReplaceString(document.forms[0].txtNoiDung.value,1)
//          
//	    }
	}
   return(true);
}
function ReplaceText()
{
    document.forms[0].txtTenMau.value=ReplaceString(document.forms[0].txtTenMau.value,1)
    document.forms[0].txtNoiDung.value=ReplaceString(document.forms[0].txtNoiDung.value,1)
}
// replace string
function ReplaceString(strField,intcheck)
{
    if (intcheck==1)
     for(i=0;i<strField.length;i++)
	   {
	        strField= strField.replace("<", "&lt;")
            strField = strField.replace(">", "&gt;")
        }	
   else
      for(i=0;i<strField.length;i++)
	   {
	       strField = strField.value.replace("&lt;","<")
           strField = strField.replace("&gt;",">")
        }	
   return strField;
        
}