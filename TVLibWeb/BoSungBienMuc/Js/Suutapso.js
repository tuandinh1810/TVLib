
function CheckBoSuuTapInfo()
{
   if(CheckNull(document.forms[0].TxtTenBoSuuTap))
   {
      alert('Bạn phải nhập tên bộ sưu tập');
      return false;
   }
   return true;
}
function ConfirmDelete()
{
   if(confirm('Bạn có thật sự muốn xóa không'))
   { 
    alert('Toi vao day roi');
     return true;
    
   }
   else
   { 
     return false;
   }
   
}
function SetAttributes(strPath, strComment){
	strAttributes = prompt(strComment + '\n' + 'A=Archive, R=ReadOnly, H=Hidden, S=System, (space)=None:', '');
	strAttributes=strAttributes.toUpperCase();
	if ((strAttributes) && (strAttributes!="")) {
		if (strAttributes=="A" || strAttributes=="R" || strAttributes=="S" || strAttributes==" "){
			document.forms[0].hidFunc.value = "SetAttributes";
			document.forms[0].hidLoc.value = strPath;
			document.forms[0].hidAttr.value = strAttributes;
			document.forms[0].submit();
		}
		else{
			alert(document.forms[0].hidAttribute.value);
			return false;
		}
	}else
	{
		alert(document.forms[0].hidAttribute.value);
		return false;
	}
}

/*
	ImportFromFS function
	Purpose: Import from file system
*/
function ImportFromFS(strPath, strComment){
	strFolder = prompt(strComment, '');
	if ((strFolder) && (strFolder!="")) {
		document.forms[0].hidFunc.value = "ImportFromFS";
		document.forms[0].hidLoc.value = strPath;
		document.forms[0].hidFolder.value = strFolder;
		document.forms[0].submit();
	}
}
/*
	ImportFileOverWrite function
	Purpose: Import OverWrite file system
*/
function ImportFileOverWrite(){ 
	document.forms[0].hidFunc.value = "ImportFileOverWrite";
	document.forms[0].submit();
}
/*	
	CreateFolder function
	Purpose: xu ly chuoi nhap vao
*/
function CheckNameofFolder(strFormat){
		if ( strFormat.indexOf("'") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf(":") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("=") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("!") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("$") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("#") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("@") >= 0 )		
			{
				return false;
			}
		if ( strFormat.indexOf("  ") >= 0 )		
			{
				return false;
			}
		return true;
}
/*
	CreateFolder function
	Purpose: Create new folder
*/
function CreateFolder(strPath, strComment,strMsg,strMsgErr){
	strFolderName = prompt(strComment, '');
	if ((strFolderName) && (strFolderName!="")) {
		if (CheckNameofFolder(strFolderName)) {
			document.forms[0].hidFunc.value = "TaoFolder";
			document.forms[0].hidLoc.value = strPath;
			document.forms[0].hidFolder.value = strFolderName				
			document.forms[0].submit();
		}
		else {
			alert(strMsgErr);
			return false;
		}
	}
}

/*
	RenameFolder function
	Purpose: Rename the existing folder
*/
function RenameFolder(strPath, strComment, strMsg,strMsgErr){
	strFolderName = prompt(strComment, '');
	if ((strFolderName) && (strFolderName!="")) {
		if (CheckNameofFolder(strFolderName)) {
			document.forms[0].hidFunc.value = "SuaTenThuMuc";
			document.forms[0].hidLoc.value = strPath;
			document.forms[0].hidFolder.value = strFolderName;
			document.forms[0].submit();		
		}
		else {
			alert(strMsgErr);
			return false;
		}
	}
}

/*
	RenameFolder function
	Purpose: Rename the existing folder
*/
function Synchronize(strPath, strMsg){
	if ((strPath) && (strPath!="")) {
		document.forms[0].hidFunc.value = "DongBoDuLieu";
		document.forms[0].hidLoc.value = strPath;
		//alert(strMsg + ' ' + strPath)
		document.forms[0].submit();
	}
}

/*
	RemoveFolder function
	Purpose: Remove the existing folder
*/
function RemoveFolder(strPath, strMsg) {
	if (confirm(strMsg)) {
		document.forms[0].hidFunc.value = "XoaThuMuc";
		document.forms[0].hidLoc.value = strPath;
		parent.location.href='DuLieuSoFrame.aspx';
		document.forms[0].submit();
	}
}

/*
	ClickMe function
	Purpose: archive/unarrchive file values
*/
function ClickMe(obj) {
	var strTemp; 
	strTemp = document.forms[0].hidIDs.value;
	if (obj.checked) {
		strTemp = strTemp + obj.value + ",";
	} else {
		strTemp = strTemp.replace("," + obj.value + ",", ",");
	}
	document.forms[0].hidIDs.value = strTemp;
	document.forms[0].hidIDs.value;
}

/*
	SetSecretLevel function
	Purpose: Check the input box is null before Set the secret level for the selected files
*/
function SetSecretLevel(strMsg, strComment,strIsNumber){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		strSetLevel = prompt(strComment, '');
		if ((strSetLevel) && (strSetLevel!="") && !isNaN(strSetLevel)) 
		{
			if (parseFloat(strSetLevel) >= 0 && parseFloat(strSetLevel) <= 9)
			{
				document.forms[0].hidFunc.value = "SetSecretLevel";
				document.forms[0].hidSecretLevel.value = strSetLevel;
				document.forms[0].submit();
			}
			else
			{
				return false;
			}
		}
		else
		if (isNaN(strSetLevel)){
			alert(strIsNumber);
			return false;
		}else
		{
			return false;
		}
	}
	return;
}

/*
	SetSecretLevel function
	Purpose: Check the input box is null before change the status for the selected files
*/
function ChangeStat(strMsg, strComment,strNotOK1,strNotOK2){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		strStatus = prompt(strComment, '');
		if ((strStatus) && (strStatus!="") && !isNaN(strStatus)) 
		{
			if (strStatus.indexOf(".")>=0 || strStatus.indexOf(",")>=0)
				{
					alert(strNotOK1);
					return false;
				}else{
					if (parseFloat(strStatus) >= 1 && parseFloat(strStatus) <= 4)
					{
						document.forms[0].hidFunc.value = "ChangeStatus";
						document.forms[0].hidStatus.value = strStatus;
						document.forms[0].submit();
					}
					else
					{
						alert(strNotOK2);
						return false;
					}
				}
		}
		else
		if (isNaN(strStatus)){
			 alert(strNotOK1);
			 return false;
		}
		else
		{
		 return false;
		}
	}
	return;
}


/*
	DeleteLogical function
	Purpose: Check the input box is null before delete the logical files
*/
function DeleteLogical(strMsg, strConfirm){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "DeleteLogical";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}
function DeleteLink(strMsg, strConfirm){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "DeleteLink";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}

/*
	Move function
	Purpose: Move file to another folder
*/
function Move(strPath, strComment, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		OpenWindow('WMoveFrame.aspx?objID='+ eval(document.forms[0].hidIDs).value +'&loc='+ strPath,'WMove',300,250,50,25);
		return false;
		/*
		strFolderName = prompt(strComment, '');
		if ((strFolderName) && (strFolderName!="")) {
			document.forms[0].hidFunc.value = "Move";
			document.forms[0].hidLoc.value = strPath;
			document.forms[0].hidFolder.value = strFolderName;
			document.forms[0].submit();
		}
		else
		{
			return false;
		}*/
	}
	return;
}
function CreateLink(strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		OpenWindow('WMegerFile.aspx?FileIDs='+ eval(document.forms[0].hidIDs).value,'Meger',700,500,50,50);
		return false;		
	}
	return;
}

/*
	Delete function
	Purpose: Check the input box is null before delete the logical and physical files
*/
function Delete(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "Delete";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}

/*
	ChangeFree function
	Purpose: Check the input box is null before changing the file to the free cost
*/
function ChangeFree(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "ChangeFree";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}

/*
	ChangeCost function
	Purpose: Check the input box is null before changing the file to the not free cost
*/
function ChangeCost(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "ChangeCost";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}

/*
	Catalogue function
	Purpose: Check the radio button is null before delete the logical and physical files
*/
function Catalogue(strMsg){
var strTemp;
var arrIDs;
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
	}
	else
	{
		strTemp = document.forms[0].hidIDs.value;
		arrIDs = strTemp.split(",");
		OpenWindow('WCatalogue.aspx?objID='+ arrIDs[arrIDs.length - 2],'WCatalogue',780,450,50,25);
	}
}

/*
	Attach function
	Purpose: Check the input box is null before delete the logical and physical files
*/
function Attach(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		    strFolderName = prompt(strConfirm, '');
		    //if ((strFolderName) && (strFolderName!="") && !isNaN(strFolderName)) 
		    if (strFolderName!="") 
			{
				alert(strFolderName);
				document.forms[0].hidFunc.value = "Attach";
				document.forms[0].hidFolder.value = strFolderName;
				document.forms[0].submit();
			}
			else
			{
				return false;
			}
	}
	return;
}

/*
	Detach function
	Purpose: Check the input box is null before delete the logical and physical files
*/
function Detach(strConfirm, strMsg,strMsg1){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{		
		var arrDetach=document.forms[0].hidIDs.value.split(",");
		var i;
		var strDetachIDs=document.forms[0].hidAttachedIDs.value;				
		for(i=0;i<arrDetach.length;i++) {
			if (strDetachIDs.indexOf("," + arrDetach[i] + ",")>-1) {
				document.forms[0].hidFunc.value = "Detach";
				document.forms[0].submit();
				return;				
			}
		}
		alert(strMsg1);
		return false;
	}
	return;
}

/*
	SetCollection function
	Purpose: Check the input box is null before delete the logical and physical files
*/
function SetCollection(strMsg,strMsg1){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		var arrDetach=document.forms[0].hidIDs.value.split(",");
		var i;
		var strDetachIDs=document.forms[0].hidAttachedIDs.value;
		for(i=0;i<arrDetach.length;i++) {
			if (strDetachIDs.indexOf("," + arrDetach[i] + ",")>-1) {
				alert(strMsg1);
				return false;				
			}
		}
		return true;
	}
}
function CheckNull(obj){	
	var strValue;
    strValue=trim(eval(obj).value);
    if (strValue == "") {
       return true;
    }
}
function trim(str){
	return 	str.replace(/^\s*|\s*$/g,"");
}
/*
	Export function
	Purpose: Check the input box is null before Export record(s) to XML file
*/
function Export(strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		return true;
	}
}

/*
	ImportToFS function
	Purpose: Check the input box is null before import from file system
*/
function ImportToFS(strPath, strMsg, strMsgConfirm){
	
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strMsgConfirm)) {
			document.forms[0].hidFunc.value = "ImportFiles";
			document.forms[0].hidLoc.value = strPath;
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}

/*
	ClickMe function
	Purpose: check/uncheck all checkbox
*/
function MarkAll(obj, intMax,intStart) {
	var intIndex;
	
	document.forms[0].hidIDs.value = ',';
	
	if (eval("document.forms[0].chkFile" + intStart )) {
		for (intIndex=intStart; intIndex<intMax; intIndex++) {
			eval("document.forms[0].chkFile" + intIndex + ".checked = obj.checked");
			ClickMe(eval("document.forms[0].chkFile" + intIndex));
		}
	}
}




/*
	ResetValue function
	Purpose: Reset the value
*/
function ResetValue(){
	var intIndex;
	
	for (intIndex = 0; intIndex<50; intIndex++) {
		if (eval("document.forms[0].chkFile" + intIndex) && eval("document.forms[0].chkFile" + intIndex).checked)
		{
			eval("document.forms[0].chkFile" + intIndex).checked = false;
		}
	}	
}

/*
	DownLoad function
	Purpose: Refresh the page
*/
function DownLoad(strFile){
		document.forms[0].hidFunc.value = "DownLoad";
		document.forms[0].hidLoc.value = strFile;
		document.forms[0].submit();
}

/*
	ChangeToMap function
	Purpose: Check the input box is null before change the item to map type
*/
function ChangeToMap(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "ChangeToMap";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}

/*
	ChangeToImage function
	Purpose: Check the input box is null before change the item to imâge type
*/
function ChangeToImage(strConfirm, strMsg){
	if (CheckNull(document.forms[0].hidIDs) || document.forms[0].hidIDs.value == ",") 
	{
		alert(strMsg);
		return false;
	}
	else
	{
		if (confirm(strConfirm)) {
			document.forms[0].hidFunc.value = "ChangeToImage";
			document.forms[0].submit();
		}
		else
		{
			return false;
		}
	}
	return;
}


function OpenWindow(strUrl,strWinname,intWidth,intHeight,intLeft,intTop){
		popUp = window.open(strUrl,strWinname, "width=" + intWidth + ",height=" + intHeight + ",left=" + intLeft+ ",top=" + intTop+ ",menubar=yes,resizable=no,scrollbars=yes");
		popUp.focus()
}