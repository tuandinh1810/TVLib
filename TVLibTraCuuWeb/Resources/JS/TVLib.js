// Creator: Kiemdv
function dtgSwapBG(obj, bgNew) {	
		tmp=obj.parentElement.parentElement.style.backgroundColor;		
		if (bgNew!=tmp) 
			bgOld=obj.parentElement.parentElement.style.backgroundColor;
		obj.parentElement.parentElement.style.backgroundColor=(obj.parentElement.parentElement.style.backgroundColor==bgNew) ?   bgOld : bgNew ;
}

// popCenter
function popCenter(URL,name,w,h) {	
	l = (screen.width - w) / 2 ;
	t = (screen.height - h) / 2;
		
	params = '';
	//params = 'toolbars=1, location=0, statusbars=0, menubars=1, resizable=1,';
	popCenterWin = window.open(URL, name, params + 'width=' + w + ', height=' + h + ', left=' + l + ', top=' + t + ', location=0,status=0,scrollbars=1');
	popCenterWin.focus();
	return false;
}

// popCenter
function popCenterSV(URL,name) {	
    w = screen.width;
    h = screen.height;
	l = (screen.width - w) / 2 ;
	t = (screen.height - h) / 2;
		
	params = '';
	//params = 'toolbars=1, location=0, statusbars=0, menubars=1, resizable=1,';
	popCenterWin = window.open(URL, name, params + 'width=' + w + ', height=' + h + ', left=' + l + ', top=' + t + ', location=0,status=0,scrollbars=1');
	popCenterWin.focus();
	return false;
}
// popCenter
function popModalCenter(URL,name,w,h) {	
	l = (screen.width - w) / 2 ;
	t = (screen.height - h) / 2;	
	window.showModalDialog(URL,name,"dialogHeight: " + h + "px; dialogWidth: " + w + "px; dialogTop: " + t + "px; dialogLeft: " + l + "px; edge: Raised; center: Yes; help: Yes; resizable: Yes; status: Yes;");
	return false;
}

//Check Date of dateobjects.
function CheckDate(obj, strMsg){	
	var strDate, strDay, strMonth, strYear;
	var dtDate, dtDay, dtMonth, dtYear;
	if (obj)
		strDate = eval(obj).value;	
	else
		strDate = obj;
	if (strDate != "") {
		strDay = strDate.substring(0, strDate.indexOf("/"));
		strMonth = strDate.substring(strDate.indexOf("/") + 1, strDate.lastIndexOf("/"));
		strYear = strDate.substring(strDate.lastIndexOf("/") + 1, strDate.length);
		dtDate = new Date (strMonth + "/" + strDay + "/" + strYear);
		dtDay = dtDate.getDate();
		dtMonth = dtDate.getMonth() + 1;
		dtYear = dtDate.getYear();
		if ((parseFloat(strDay) != parseFloat(dtDay)) || (parseFloat(strMonth) != parseFloat(dtMonth))|| (isNaN(strYear))){
				alert(strMsg);
				if (obj){
					obj.value = "";					
					obj.focus();
				}
				return false;
		}		
	}		
	return true;
}

//Check value of dateobjects is empty.
function CheckNullGrd(obj, strMsg){	
	var strValue;
	var blnEmpty = true;			
	strValue = obj;    
	if (strValue != ""){	
	for (i = 0; i < strValue.length; i++) {
		if (strValue.charAt(i) != " ") {
		blnEmpty = false;           
		break;
		}
	}               
	}
	if (blnEmpty){
		alert(strMsg);				
		return false;
	}
	return true;
}


//Check value of dateobjects is empty.
function CheckNull(obj, strMsg){	
	var strValue;
	var blnEmpty = true;
	if (obj)
		strValue =eval(obj).value;
	else
		strValue = obj;    
    if (strValue != ""){	
      for (i = 0; i < strValue.length; i++) {
        if (strValue.charAt(i) != " ") {
		   blnEmpty = false;           
           break;
        }
      }               
    }
    if (blnEmpty){
    if (strMsg=='')
    {
    }
    else            alert(strMsg);
           if (eval(obj))
				eval(obj).focus();
		   return false;
	}
    return true;
}

//Check a variable is number
function CheckNum(obj, msg) {	
	var strValue;	
	if (obj)
		strValue = eval(obj).value;
	else
		strValue = obj;			
	if ((isNaN(strValue)) || (!CheckNull(obj,''))) {
		alert(msg);
		if (obj){
			eval(obj).value = '';
			eval(obj).focus();
		}
		return false;
	} else {
		return true;
	}
}

function DAChange(obj){		
	if(obj.value=='')
		obj.value='..........';	
	//	if (obj.value!='..........')
	//		alert(obj.value);
}
function DAClick(obj){	
	if(obj.value=='..........')
		obj.value='';
}


//window.onload = loadHandler


function OpenWindow(strUrl,strWinname,intWidth,intHeight,intLeft,intTop)
{
		popUp = window.open(strUrl,strWinname, "width=" + intWidth + ",height=" + intHeight + ",left=" + intLeft+ ",top=" + intTop+ ",menubar=no,resizable=no,scrollbars=yes");
		popUp.focus()
}


// If find an check object, check, if not, through away

function CheckAllOptionsVisible(strDtgName, strOptionName, intStart, intMax){	
	var intCounter;	
	var blnStatus;	
	blnStatus = false;
					
	if (eval('document.forms[0].CheckAll')) {
		if (eval('document.forms[0].CheckAll').checked)
			blnStatus = true;
	}
	else {
		if (eval('document.forms[0].chkCheckAll')) {
			if (eval('document.forms[0].chkCheckAll').checked)
				blnStatus = true;
		}
	}	
		
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {	
	 		
	if (intCounter <10)
	{		  
	  if (eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName)){			
			eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName).checked = blnStatus;			
		}
					
	}
	else
	{
	      if (eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName)){			
			eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName).checked = blnStatus;			
		}
	}
	}
}



function CheckAllOptionsVisible(strDtgName, strOptionName, intStart, intMax)
{	
	var intCounter;	
	var blnStatus;
	
	blnStatus = false;
					
	if (eval('document.forms[0].CheckAll')) {
		if (eval('document.forms[0].CheckAll').checked)
			blnStatus = true;
	}
	else {
		if (eval('document.forms[0].chkCheckAll')) {
			if (eval('document.forms[0].chkCheckAll').checked)
				blnStatus = true;
		}
	}	
		
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) 
	{	
	    if (intCounter >9)
	    {
	        kytu='_ctl'; 
	    }
	    else
	    {
	        kytu='_ctl0';
	    }			  
	  if (eval('document.forms[0].' + strDtgName + kytu + intCounter + '_' + strOptionName)){			
			eval('document.forms[0].' + strDtgName + kytu + intCounter + '_' + strOptionName).checked = blnStatus;			
		}			
	}
}



