 
function AddItem()
{
	var k = 0;
	var i=0;
	for (i = 0; i < document.forms[0].lsbKhongDuocCap.length; i++)
	 {
		if(document.forms[0].lsbKhongDuocCap.options[i].selected) 
		{
		   
			document.forms[0].lsbDuocCap.length++;
			document.forms[0].lsbDuocCap.options[(document.forms[0].lsbDuocCap.length)- 1].value = document.forms[0].lsbKhongDuocCap.options[i].value;
			document.forms[0].lsbDuocCap.options[(document.forms[0].lsbDuocCap.length)- 1].text = document.forms[0].lsbKhongDuocCap.options[i].text;		
			opener.document.getElementById('ctl00_ContentPlaceHolder1_hidQuyenIDs').value += document.forms[0].lsbKhongDuocCap.options[i].value + ',';
			//opener.document.getElementById('hidDir').value += document.forms[0].lsbKhongDuocCap.options[i].value + ',';
		}
		else
		 {
		    document.forms[0].lsbKhongDuocCap.options[k].value =document.forms[0].lsbKhongDuocCap.options[i].value;
			document.forms[0].lsbKhongDuocCap.options[k].text =document.forms[0].lsbKhongDuocCap.options[i].text;
			document.forms[0].lsbKhongDuocCap.options[k].selected = false;
            k = k + 1;
		}		
	}
	document.forms[0].lsbKhongDuocCap.length = k;
}

function RemoveItems()
{
	var k=0;              
	var i=0;
	for (i = 0; i < document.forms[0].lsbDuocCap.length; i++)
	{
	    //alert(document.forms[0].lsbDuocCap.options[i].selected);	
		if(document.forms[0].lsbDuocCap.options[i].selected) 
		{
			document.forms[0].lsbKhongDuocCap.length++;
			document.forms[0].lsbKhongDuocCap.options[(document.forms[0].lsbKhongDuocCap.length)- 1].value = document.forms[0].lsbDuocCap.options[i].value;
			document.forms[0].lsbKhongDuocCap.options[(document.forms[0].lsbKhongDuocCap.length)- 1].text = document.forms[0].lsbDuocCap.options[i].text;	
			RemoveItem(document.forms[0].lsbDuocCap.options[i].value);
		}
		else
		 {
    		document.forms[0].lsbDuocCap.options[k].value =document.forms[0].lsbDuocCap.options[i].value;
	    	document.forms[0].lsbDuocCap.options[k].text =document.forms[0].lsbDuocCap.options[i].text;
		    document.forms[0].lsbDuocCap.options[k].selected = false;		
		    k=k+1;
		}
	}			
	document.forms[0].lsbDuocCap.length = k;
	//alert(opener.document.getElementById('ctl00_ContentPlaceHolder1_hidQuyenIDs').value);
}

// Remove 1 Item ra khoi mot xau
function RemoveItem(Item)
{
	Item = Item + ',';
	
	Str = opener.document.getElementById('ctl00_ContentPlaceHolder1_hidQuyenIDs').value + '';
	if (Str.indexOf(Item) != -1)
	 {
		Str = Str.replace(Item, '')
	}
    opener.document.getElementById('ctl00_ContentPlaceHolder1_hidQuyenIDs').value = Str;
}
//Phan Quyen Ban Doc

function AddItem_NhomBanDoc()
{
	var k = 0;
	var i=0;
	for (i = 0; i < document.forms[0].lsbKhongDuocCap.length; i++)
	 {
		if(document.forms[0].lsbKhongDuocCap.options[i].selected) 
		{
		   
			document.forms[0].lsbDuocCap.length++;
			document.forms[0].lsbDuocCap.options[(document.forms[0].lsbDuocCap.length)- 1].value = document.forms[0].lsbKhongDuocCap.options[i].value;
			document.forms[0].lsbDuocCap.options[(document.forms[0].lsbDuocCap.length)- 1].text = document.forms[0].lsbKhongDuocCap.options[i].text;		
			//opener.document.getElementById('hidQuyenIDs').value += document.forms[0].lsbKhongDuocCap.options[i].value + ',';
			document.getElementById('hidChuoiQuyenBanDoc').value += document.forms[0].lsbKhongDuocCap.options[i].value + ',';
			//alert(opener.document.getElementById('ctl00_ContentPlaceHolder1_hidQuyenIDs').value );
		}
		else
		 {
		    document.forms[0].lsbKhongDuocCap.options[k].value =document.forms[0].lsbKhongDuocCap.options[i].value;
			document.forms[0].lsbKhongDuocCap.options[k].text =document.forms[0].lsbKhongDuocCap.options[i].text;
			document.forms[0].lsbKhongDuocCap.options[k].selected = false;
            k = k + 1;
		}		
	}
	document.forms[0].lsbKhongDuocCap.length = k;
}

function RemoveItems_NhomBanDoc()
{
	var k=0;              
	var i=0;
	for (i = 0; i < document.forms[0].lsbDuocCap.length; i++)
	{
	    //alert(document.forms[0].lsbDuocCap.options[i].selected);	
		if(document.forms[0].lsbDuocCap.options[i].selected) 
		{
			document.forms[0].lsbKhongDuocCap.length++;
			document.forms[0].lsbKhongDuocCap.options[(document.forms[0].lsbKhongDuocCap.length)- 1].value = document.forms[0].lsbDuocCap.options[i].value;
			document.forms[0].lsbKhongDuocCap.options[(document.forms[0].lsbKhongDuocCap.length)- 1].text = document.forms[0].lsbDuocCap.options[i].text;	
			RemoveItem_NhomBanDoc(document.forms[0].lsbDuocCap.options[i].value);
		}
		else
		 {
    		document.forms[0].lsbDuocCap.options[k].value =document.forms[0].lsbDuocCap.options[i].value;
	    	document.forms[0].lsbDuocCap.options[k].text =document.forms[0].lsbDuocCap.options[i].text;
		    document.forms[0].lsbDuocCap.options[k].selected = false;		
		    k=k+1;
		}
	}			
	document.forms[0].lsbDuocCap.length = k;
}

// Remove 1 Item ra khoi mot xau
function RemoveItem_NhomBanDoc(Item)
{
	Item = Item + ',';
	
	Str = document.getElementById('ctl00_ContentPlaceHolder1_hidChuoiQuyenBanDoc').value + '';
	if (Str.indexOf(Item) != -1)
	 {
		Str = Str.replace(Item, '')
	}
   document.getElementById('ctl00_ContentPlaceHolder1_hidChuoiQuyenBanDoc').value = Str;
}