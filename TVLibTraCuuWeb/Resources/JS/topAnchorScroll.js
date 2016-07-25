var menuTopMargin	= -60;
var menuSpeed		= 4;
var timerSpeed		= 100;
var timer;
var heightLimit	= 0;

function checkMenuRight() {
	if(document.body.offsetHeight > heightLimit) {
		var reTimer = timerSpeed;
		var startPoint = parseInt(document.all.rightMenu.style.top,10);
		var endPoint = document.body.scrollTop;
		endPoint = (menuTopMargin <= endPoint ) ? endPoint - menuTopMargin : 0;
		if(startPoint != endPoint) {
			moveAmount = Math.ceil(Math.abs(endPoint - startPoint) / 15);
			document.all.rightMenu.style.top = parseInt(document.all.rightMenu.style.top,10) + ((endPoint<startPoint) ? -moveAmount : moveAmount);
			reTimer = menuSpeed;
		}
	} else document.all.sMenu.style.top = 0;
	timer = setTimeout("checkMenuRight();",reTimer);
}
function initMenuRight() {
	if(document.body.offsetHeight > heightLimit) document.all.leftMenu.style.top = document.body.scrollTop;
	checkMenuLeft();
}
function checkMenuLeft() {
	if(document.body.offsetHeight > heightLimit) {
		var reTimer = timerSpeed;
		var startPoint = parseInt(document.all.leftMenu.style.top,10);
		var endPoint = document.body.scrollTop;
		endPoint = (menuTopMargin <= endPoint ) ? endPoint - menuTopMargin : 0;
		if(startPoint != endPoint) {
			moveAmount = Math.ceil(Math.abs(endPoint - startPoint) / 15);
			document.all.leftMenu.style.top = parseInt(document.all.leftMenu.style.top,10) + ((endPoint<startPoint) ? -moveAmount : moveAmount);
			reTimer = menuSpeed;
		}
	} else document.all.sMenu.style.top = 0;
	timer = setTimeout("checkMenuLeft();",reTimer);
}
function initMenuLeft() {
	if(document.body.offsetHeight > heightLimit) document.all.leftMenu.style.top = document.body.scrollTop;
	checkMenuRight();
}