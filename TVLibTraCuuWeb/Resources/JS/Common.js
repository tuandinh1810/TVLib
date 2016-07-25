var oldColor = '';
function Goto(strLink){
	top.location.href = strLink; 
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
           alert(strMsg);
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
	if ((isNaN(strValue)) || (!CheckNull(obj))) {
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
// Open Window 
function OpenWindow(strUrl,strWinname, w, h){
		winl = (screen.width - w) / 2;
		wint = (screen.height - h) / 2;				
		popWindow=window.open(strUrl,strWinname,"top="+wint+",left="+winl+", width="+w+", height="+h+"resizable=0");
		popWindow.focus()
}

// Open Window 
function OpenWindow1(strUrl,strWinname, w, h){
		winl = (screen.width - w) / 2;
		wint = (screen.height - h) / 2;				
		popWindow=window.open(strUrl,strWinname,"top="+wint+",left="+winl+", width="+w+", height="+h);
		popWindow.focus()
}
// Open Window 
function OpenWindow2(strUrl,strWinname,intParameters){		
		popWindow=window.open(strUrl,strWinname,intParameters);		
		popWindow.focus()
}

// popCenter
function popModalCenter(URL,name,w,h) {	
	l = (screen.width - w) / 2 ;
	t = (screen.height - h) / 2;	
	window.showModalDialog(URL,name,"dialogHeight: " + h + "px; dialogWidth: " + w + "px; dialogTop: " + t + "px; dialogLeft: " + l + "px; edge: Raised; center: Yes; help: Yes; resizable: Yes; status: Yes;");
	return false;
}

// Hoan doi mau nen cho mot dong trong Datagrid
function dtgSwapBG(obj, bgColor) 
{	
	var tmpColor;
	if (obj){
		tmpColor = obj.parentElement.parentElement.style.backgroundColor;		
		if (bgColor != tmpColor)
			oldColor = tmpColor;						
		obj.parentElement.parentElement.style.backgroundColor = (tmpColor==bgColor) ? oldColor:bgColor;
	}
}
// Print
function Print(){
	self.focus();
    setTimeout('self.print()', 1);
}

/* Check value is empty
	if obj's value is null return true 
	else return false
*/
function CheckNullInput(obj){	
    strValue=eval(obj).value;
    if (strValue == "") {
       return true;
    }
    else {
      Status = 0;
      for (i = 0; i < strValue.length; i++) {
        if (strValue.charAt(i) != " ") {
           Status = 1;
           break;                      
        }
      }         
      if (Status == 0) {          
	      return true;
      }
      else {
          return false;
      }
    }
}
function LoadBackData(ControlName){
	if(document.forms[0].flage.value > 0){
		if(document.forms[0].lsbDictionary.options.selectedIndex >=0){
			eval('opener.document.forms[0].' + ControlName).value=document.forms[0].lsbDictionary.options[document.forms[0].lsbDictionary.options.selectedIndex].text;
			self.close();
			opener.focus();
			return(false);//close current form		
		}
		else{
			return(true);//allow submit current form
		}		
	}
	else{
		return(true);//allow submit current form
	}
}
function OpenDictionary(DangTL, dicId,ControlName){	
	DicWin = window.open('Dictionary.aspx?DTL=' + DangTL + '&pattern=' + eval('document.forms[0].' + ControlName + '.value') + '&dicId=' + dicId + '&ControlName=' + ControlName, 'DicWin', 'top=70,left=250,width=340,height=370,resizable,scrollbars=yes');
	DicWin.focus();
}
//COPY from libolcommon 5.5
function Esc(inval, utf) {
	inval = escape(inval);
	if (utf == 0) 	{
		return inval;
	}
	outval = "";
	while (inval.length > 0) {
		p = inval.indexOf("%"); 
		if (p >= 0) {
			if (inval.charAt(p + 1) == "u") {
				outval = outval + inval.substring(0, p) + JStoURLEncode(eval("0x" + inval.substring(p + 2, p + 6)));
				inval = inval.substring(p +6, inval.length);
			} else {
				outval = outval + inval.substring(0, p) + JStoURLEncode(eval("0x" + inval.substring(p + 1, p + 3)));
				inval = inval.substring(p + 3, inval.length);
			}
		} else {
			outval = outval + inval;
			inval = "";
		}
	}
	return outval;
}

if (document.images) {
 img_on =new Image();  img_on.src ="../Images/111.gif"; 
 img_off=new Image();  img_off.src="../Images/112.gif"; 
}

function handleOver() { 
 if (document.images) document.imgName.src=img_on.src;
}

function handleOut() {
 if (document.images) document.imgName.src=img_off.src;
}
