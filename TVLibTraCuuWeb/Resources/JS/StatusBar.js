function scrollit_r2l(seed)

{

        var m1  = ShowDate() + tick() + "Chào mừng bạn đến với Website Sổ tay hướng dẫn! ";

  var msg=m1;

        var out = " ";

        var c   = 1;

        if (seed > 100) {

                seed--;

                var cmd="scrollit_r2l(" + seed + ")";

                timerTwo=window.setTimeout(cmd,100);

        }

        else if (seed <= 100 && seed > 0) {

                for (c=0 ; c < seed ; c++) {

                        out+=" ";

                }

                out+=msg;

                seed--;

                var cmd="scrollit_r2l(" + seed + ")";

                    window.status=out;

                timerTwo=window.setTimeout(cmd,100);

        }

        else if (seed <= 0) {

                if (-seed < msg.length) {

                        out+=msg.substring(-seed,msg.length);

                        seed--;

                        var cmd="scrollit_r2l(" + seed + ")";

                        window.status=out;

                        timerTwo=window.setTimeout(cmd,100);

                }

                else {

                        window.status=" ";

                        timerTwo=window.setTimeout("scrollit_r2l(100)",75);

                }

        }

}

function tick() {     //Compose Time String
  var hours, minutes, seconds;
  var intHours, intMinutes, intSeconds;
  var today;

  today = new Date();

  intHours = today.getHours();
  intMinutes = today.getMinutes();
  intSeconds = today.getSeconds();

    hours = intHours + ":";

   if (intMinutes < 10) {
     minutes = "0"+intMinutes+":";
  } else {
     minutes = intMinutes+":";
  }

  if (intSeconds < 10) {
     seconds = "0"+intSeconds+". ";
  } else {
     seconds = intSeconds+". ";
  }

  timeString = hours+minutes+ seconds;

	return timeString;   
}

function ShowDate(){
	var mydate=new Date()
	var year=mydate.getFullYear()
	var day=mydate.getDay()
	var month=mydate.getMonth()
	var daym=mydate.getDate()
	if (daym<10)
	daym="0"+daym
	var dayarray=new Array("Chủ nhật","Thứ hai","Thứ ba","Thứ tư","Thứ năm","Thứ sáu","Thứ bảy")
	var montharray=new Array("một","hai","ba","tư","năm","sáu","bảy","tám","chín","mười","mười một","mười hai")
	return dayarray[day] + " ngày " + daym + " tháng " + montharray[month] + " năm " + year + " - ";
}