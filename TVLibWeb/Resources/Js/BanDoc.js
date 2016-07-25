function CheckAddTinh()
{

 if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtDescription,'Tên tỉnh (thành phố) không được để trống!') == false        )
   {
     return false ;
   }
   else
   {
    return true ;
    }
 }

function CheckAddNgheNghiep()
{

 if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtDescription,'Tên nghề nghiệp không được để trống!') == false        )
   {
     return false ;
   }
   else
   {
    return true ;
    }
 }
  
function CheckAddDanToc()
{

 if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtDescription,'Tên dân tộc không được để trống!') == false        )
   {
     return false ;
   }
   else
   {
    return true ;
    }
 }
 
function CheckAddTrinhDo()
{

 if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtDescription,'Tên trình độ không được để trống!') == false        )
   {
     return false ;
   }
   else
   {
    return true ;
    }
 }
 
function CheckAddNhomBanDoc()
{

 if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtNhomBanDoc,'Tên nhóm bạn đọc không được để trống!') == false        )
   {
     return false ;
   }
   else
   {
        if (  CheckNum(document.forms[0].ctl00$ContentPlaceHolder1$txtSoSachMuonVe,'Không đúng kiểu dữ liệu số!') == false        )
       {
         return false ;
       }
       else
       {
          
            strStoreIDs="";	
	            for (i = 0; i < document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.length; i++)
	             {			
		            strStoreIDs=strStoreIDs+document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.options[i].value+",";		
	            }
	          //strStoreIDs=strStoreIDs.substr(0,strStoreIDs.length-1);
	            document.forms[0].ctl00$ContentPlaceHolder1$hidKhoIDs.value=strStoreIDs;
          
       }
    }
 }
 
 
function AddItem(){
	var k = 0;
	var i=0;
	for (i = 0; i < document.forms[0].ctl00$ContentPlaceHolder1$lstKho.length; i++) {
		if(document.forms[0].ctl00$ContentPlaceHolder1$lstKho.options[i].selected) {
			document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.length++;
			document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.options[(document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.length)- 1].value = document.forms[0].ctl00$ContentPlaceHolder1$lstKho.options[i].value;
			document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.options[(document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.length)- 1].text = document.forms[0].ctl00$ContentPlaceHolder1$lstKho.options[i].text;		
		}
		else {document.forms[0].ctl00$ContentPlaceHolder1$lstKho.options[k].value =document.forms[0].ctl00$ContentPlaceHolder1$lstKho.options[i].value;
			document.forms[0].ctl00$ContentPlaceHolder1$lstKho.options[k].text =document.forms[0].ctl00$ContentPlaceHolder1$lstKho.options[i].text;
			document.forms[0].ctl00$ContentPlaceHolder1$lstKho.options[k].selected = false;
            k = k + 1;
		}		
	}
	document.forms[0].ctl00$ContentPlaceHolder1$lstKho.length = k;
}

function RemoveItem(){
	var k=0;              
	var i=0;
	for (i = 0; i < document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.length; i++) {	
		if(document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.options[i].selected) {
			
				document.forms[0].ctl00$ContentPlaceHolder1$lstKho.length++;
				document.forms[0].ctl00$ContentPlaceHolder1$lstKho.options[(document.forms[0].ctl00$ContentPlaceHolder1$lstKho.length)- 1].value = document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.options[i].value;
				document.forms[0].ctl00$ContentPlaceHolder1$lstKho.options[(document.forms[0].ctl00$ContentPlaceHolder1$lstKho.length)- 1].text = document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.options[i].text;	
			
		}
		else {document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.options[k].value =document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.options[i].value;
		document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.options[k].text =document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.options[i].text;
		document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.options[k].selected = false;		
		k=k+1;
		}
	}			
	document.forms[0].ctl00$ContentPlaceHolder1$lstKhoBanDoc.length = k;
}


function CheckThongTinBanDoc()
{
    if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtHoVaTen,'Tên bạn đọc không được để trống!') == false        )
   {
     return false ;
   }
   else
   {
        if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtSoThe,'Số thẻ bạn đọc không được để trống!') == false        )
       {
         return false ;
       }
       else
       {
           if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayCap,'Ngày cấp thẻ không được để trống!') == false        )
           {
             return false ;
           }
           else
           {
                if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayHieuLuc,'Ngày hiệu lực không được để trống!') == false        )
               {
                 return false ;
               }
               else
               {
                        if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayHetHan,'Ngày hết hạn không được để trống!') == false        )
                       {
                         return false ;
                       }
                       else
                       {
                            if (  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayHetHan,'Không đúng kiểu dữ liệu ngày tháng!') == false        )
                           {
                             return false ;
                           }
                           else
                           {
                                     if (  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayHieuLuc,'Không đúng kiểu dữ liệu ngày tháng!') == false        )
                                       {
                                         return false ;
                                       }
                                       else
                                        
                                       {
                                                  if (  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayCap,'Không đúng kiểu dữ liệu ngày tháng!') == false        )
                                                  {
                                                             return false ;
                                                   }
                                                  else
                                                  {          
                                                                if (  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtNgaySinh,'Không đúng kiểu dữ liệu ngày tháng!') == false        )
                                                                  {
                                                                             return false ;
                                                                   }
                                                                  else
                                                                  {         
                                                                      if (  document.forms[0].ctl00$ContentPlaceHolder1$drdlNhomBanDoc.options[0].selected ==  true  )
                                                                       {
                                                                            alert('Chưa chọn nhóm bạn đọc!');
                                                                            
                                                                            return false ;
                                                                       }
                                                                  }
                                               }
                                         }
                              }
                       }
               }
          }
       }
    }
}

function CheckKhoaThe()
{
 if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtSoThe,'Số thẻ bạn đọc không được để trống!') == false        )
   {
     return false ;
   }
   else
   {
        if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayBatDau,'Chưa điền đầy đủ thông tin!') == false        )
       {
         return false ;
       }
       else
       {
           if (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtSoNgay,'Chưa điền đầy đủ thông tin!') == false        )
           {
             return false ;
           }
           else
           {
                if (  CheckNum(document.forms[0].ctl00$ContentPlaceHolder1$txtSoNgay,'Không đúng kiểu dữ liệu số!') == false        )
                   {
                     return false ;
                   }
                   else
                   {
                          if (  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtNgayBatDau,'Không đúng kiểu dữ liệu ngày tháng!') == false        )
                           {
                             return false ;
                           }
                   }
          }
       }
    }
}



function CheckThongTinXoaBanDoc()
{
    if ((  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtKhoa,'') == false        )  &&  (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtLop,'') == false        ) && (  CheckNull(document.forms[0].ctl00$ContentPlaceHolder1$txtTuNgay,'') == false        ) && (  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtDenNgay,'Không đúng kiểu dữ liệu ngày tháng') == false        ))
   {
                alert('Bạn chưa điền thông tin xoá bạn đọc');
               return false ;
   }
   else
   {
       if (  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtDenNgay,'Không đúng kiểu dữ liệu ngày tháng') == false        )
           {
                 return false ;
           }
          else
          {
                 if (  CheckDate(document.forms[0].ctl00$ContentPlaceHolder1$txtTuNgay,'Không đúng kiểu dữ liệu ngày tháng') == false        )
                    {
                        return false ;
                    }
                  else
                  {
                     return true;
                   }
          }
                
      }
 }
 
 function AddImage() {
	
		OpenWindow('WUpLoad.aspx?Code=' + document.forms[0].ctl00$ContentPlaceHolder1$txtCode.value,'PatronImage',340,60,50,050);
}