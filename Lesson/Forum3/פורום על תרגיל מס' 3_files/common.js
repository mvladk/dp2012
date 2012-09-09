PROPERTIES_COOKIE = 'HLPropList'
//---- replace parameter in given url---//
var INITIAL_DATE = '1/1/1990'
var isE = isClientIE();

function isClientIE()
{
   var isIE = true;
   var browser = navigator.userAgent;
   
   if(browser.indexOf("MSIE") == -1)
         isIE = false;
   return isIE 
}	
	
function ReplaceURL(strOrginalParam, strReplaceParam, strURL)
{
	var arrOrgs = (strOrginalParam+'').split(',')
	var arrReps = (strReplaceParam+'').split(',')
	
	for (var c = 0; c < arrOrgs.length; c++)
	{	
		var pos = strURL.indexOf(arrOrgs[c] + '=')
		if ( pos != -1)
		{
			var pos1 = strURL.indexOf('&', pos + 1)
			if (pos1 != -1)
				var ParamPart = strURL.substring(pos, pos1)
			else
				var ParamPart = strURL.substr(pos, strURL.length)
			var strURLAfter = strURL.replace(ParamPart, arrOrgs[c] + '=' + arrReps[c])
		}
		else
		{
			//check if has anyparameters
			posBeginParam = strURL.indexOf('?') 
			if (posBeginParam != -1 && strURL.substr(posBeginParam + 1, strURL.length).length > 0)
				var strURLAfter = strURL + '&' + arrOrgs[c] + '=' + arrReps[c]
			else
				var strURLAfter = strURL + '?' + arrOrgs[c] + '=' + arrReps[c]
		}
	}
	return strURLAfter
}

function overPortalLink(a)
{
	a.style.textDecoration = 'underline'
}

function outPortalLink(a)
{
	a.style.textDecoration = 'none'
}

function sendXmlMetadata( page, message ) {
	var xmlhttp = new ActiveXObject( 'Microsoft.XMLHTTP' );
	xmlhttp.Open( 'POST', page, false );
	if( message == null || message == '' ) message = '<root></root>';
	xmlhttp.Send( message );
	return xmlhttp.responseText;
}


function DisplayHLDate(strDate, HLDateFormat)
{
	//get date in format DMY. check HLFormat, fix if needed for display
	if (strDate == '')
		return ''

	var arrDate = (strDate+ '').split('/')
	if (arrDate.length != 3)
		return ''
	var dateD = arrDate[0]
	var dateM = arrDate[1]
	var dateY = arrDate[2]
	if (dateD.length == 1)
		dateD = '0' + dateD
	if (dateM.length == 1)
		dateM = '0' + dateM
	if (dateY.length == 2)
		dateY = '20' + dateY
		
	if (HLDateFormat == 'dd/mm/yyyy')
		return ( dateD  +'/' + dateM + '/' + dateY)
	else
		return ( dateM  +'/' + dateD + '/' + dateY)
}	

function InsertHLDate(strDate, HLDateFormat)
{
	//get date in HLFormat, fix if needed for insertion as DMY
	var arrDate = (strDate+ '').split('/')
	if (arrDate.length != 3)
		return ''

	if (HLDateFormat == 'dd/mm/yyyy')
	{
		var dateD = arrDate[0]
		var dateM = arrDate[1]
		var dateY = arrDate[2]
	}
	else
	{
		var dateD = arrDate[1]
		var dateM = arrDate[0]
		var dateY = arrDate[2]
	}
	if (dateD.length == 1)
		dateD = '0' + dateD
	if (dateM.length == 1)
		dateM = '0' + dateM
	if (dateY.length == 2)
		dateY = '20' + dateY
	return ( dateD  +'/' + dateM + '/' + dateY)
}

function getDiffDays (EndD, BeginD)
{
	//the date except the format mmddyyyy
	//the dates parameters come in the fomat ddmmyyyy
	
	msecondsPerDay = 1000 * 60 * 60 * 24
	BDay = BeginD.substr(0,BeginD.indexOf('/'))
	BMonth = BeginD.substr(BeginD.indexOf('/')+1, BeginD.indexOf('/'))
	BYear = BeginD.substr(BeginD.lastIndexOf('/') + 1, BeginD.length)
	EDay = EndD.substr(0,EndD.indexOf('/'))
	EMonth = EndD.substr(EndD.indexOf('/')+1, EndD.indexOf('/'))
	EYear = EndD.substr(EndD.lastIndexOf('/') + 1, EndD.length)
	BD = new Date(BMonth + '/' + BDay + '/' + BYear)
	ED = new Date(EMonth + '/' + EDay + '/' + EYear)
	Dif = ED.getTime() - BD.getTime()
	DifDays =  Dif / msecondsPerDay 
	return DifDays
}

function getDiffDaysWithFormat (EndD, BeginD,FormatDate)
{
	//the date except the format mmddyyyy
	//the dates parameters come in the fomat ddmmyyyy
	if(FormatDate=="dd/mm/yyyy")
	{
	    msecondsPerDay = 1000 * 60 * 60 * 24
	    BDay = BeginD.substr(0,BeginD.indexOf('/'))
	    BMonth = BeginD.substr(BeginD.indexOf('/')+1, BeginD.indexOf('/'))
	    BYear = BeginD.substr(BeginD.lastIndexOf('/') + 1, BeginD.length)
	    EDay = EndD.substr(0,EndD.indexOf('/'))
	    EMonth = EndD.substr(EndD.indexOf('/')+1, EndD.indexOf('/'))
	    EYear = EndD.substr(EndD.lastIndexOf('/') + 1, EndD.length)
	    BD = new Date(BMonth + '/' + BDay + '/' + BYear)
	    ED = new Date(EMonth + '/' + EDay + '/' + EYear)
	    Dif = ED.getTime() - BD.getTime()
	    DifDays =  Dif / msecondsPerDay 
	    return DifDays
	}
	else
	{
	    msecondsPerDay = 1000 * 60 * 60 * 24
	    BMonth = BeginD.substr(0,BeginD.indexOf('/'))
	    BDay = BeginD.substr(BeginD.indexOf('/')+1, BeginD.indexOf('/'))
	    BYear = BeginD.substr(BeginD.lastIndexOf('/') + 1, BeginD.length)
	    EMonth = EndD.substr(0,EndD.indexOf('/'))
	    EDay = EndD.substr(EndD.indexOf('/')+1, EndD.indexOf('/'))
	    EYear = EndD.substr(EndD.lastIndexOf('/') + 1, EndD.length)
	    BD = new Date(BMonth + '/' + BDay + '/' + BYear)
	    ED = new Date(EMonth + '/' + EDay + '/' + EYear)
	    Dif = ED.getTime() - BD.getTime()
	    DifDays =  Dif / msecondsPerDay 
	    return DifDays
	}
}
function DateAddDays(d,  num, hlDateFormat)
{
	var arrDate = d.split('/')
	if (arrDate.length < 3)
		return ''
   
    var d,m;
    if(typeof(hlDateFormat)=='undefined' || hlDateFormat=='' || hlDateFormat=='dd/mm/yyyy')
    {
	   d = Number(arrDate[0]) + Number(num)
	   m = arrDate[1]-1
	}
	else
	{
	   d = Number(arrDate[1]) + Number(num)
	   m = arrDate[0]-1
	}
	var y = arrDate[2]
	newd= new Date(y,m,d)
	if(hlDateFormat=='mm/dd/yyyy')
	    tmp = (newd.getMonth()+1) + "/" +newd.getDate() + "/" +  newd.getYear();
	else
	    tmp = newd.getDate() + "/" + (newd.getMonth()+1) + "/" + newd.getYear();
	return tmp
}
function validEmail(strAllEmails, charSplit)
	{
		var ValidEmails='';
		var InvalidEmails='';
		var arrMails = strAllEmails.split(charSplit)
		for (var m=0; m < arrMails.length; m++)
		{
			var strEmail = arrMails[m]
			var at = strEmail.indexOf('@');
			if (at < 1 || at == strEmail.length - 1)
			{
				InvalidEmails = InvalidEmails + strEmail + charSplit;
				continue;
			}
			var last = strEmail.lastIndexOf('@');
			if (last > at)
			{
				InvalidEmails = InvalidEmails + strEmail + charSplit;
				continue;
			}
			at = strEmail.indexOf('.');
			if (at < 1 || at == strEmail.length - 1)
			{
				InvalidEmails = InvalidEmails + strEmail + charSplit;
				continue;
			}
			ValidEmails = ValidEmails + strEmail + charSplit;
		}
	if (ValidEmails != '')
		ValidEmails = ValidEmails.substr(0, ValidEmails.length - 1)
	if (InvalidEmails != '')
		InvalidEmails = InvalidEmails.substr(0, InvalidEmails.length - 1)
	return ValidEmails + '$$$' + InvalidEmails;
	}

function hideElement(id)
	{
	var elem = document.getElementById(id);
	if (elem != null)
		elem.style.display = 'none'
	}

function showElement(id)
	{
	var elem = document.getElementById(id);
	if (elem != null)
		elem.style.display = 'block'
	}

function showOrHideElement(id)
	{
	var elem = document.getElementById(id);
	if (elem == null)
		return;
	if (elem.style.display == 'none')
		elem.style.display = 'block'
	else
		elem.style.display = 'none'
	}

function setCase(e)
	{
	var val = trim(e.value);
	e.value = val.charAt(0).toUpperCase() + val.substring(1, val.length).toLowerCase();
	}

function legalName(box, strAlert, illegal)
	{
	var str = trim(box.value);
	for (var c = 0; c < illegal.length; c++)
		if (parseInt(str.indexOf(illegal[c])) > -1)
			{
			alert(strAlert);
			box.focus();
			return false
			}
	return true
	}

function NotlegalPasswordCharacters(str)
{
    return IsMatch("[^\\w!@#$%^&*]", str)
}

function ChecklegalNamePositive(str)
	{
		
		for(var c=0; c< str.length;c++)
		{
			if ((str.charCodeAt(c) < 48 || str.charCodeAt(c) > 122)&&(str.charAt(c)!="_" && str.charAt(c)!="-"))
				return false;
			else if ((str.charCodeAt(c) > 57 && str.charCodeAt(c) < 65)&&(str.charAt(c)!="_" && str.charAt(c)!="-"))
				return false;
			else if ((str.charCodeAt(c) > 90 && str.charCodeAt(c) < 97)&&(str.charAt(c)!="_" && str.charAt(c)!="-"))
				return false;	
		}
		return true;
		
	}

function legalNamePositive(str)
//check if the string contains only English chars and numbers
// 0-9 [48-57]; A-Z [65-90]; a-z [97-122]
	{

		for(var c=0; c< str.length;c++)
		{
			if (str.charCodeAt(c) < 48 || str.charCodeAt(c) > 122)
				return false;
			else if (str.charCodeAt(c) > 57 && str.charCodeAt(c) < 65)
				return false;
			else if (str.charCodeAt(c) > 90 && str.charCodeAt(c) < 97)
				return false;	
		}
		return true;
	}
function legalNamePositiveEx(str)
//check if the string contains only English chars, Hebrew chars, numbers and the space, the apostrophy, the hifen chars
// 0-9 [48-57]; A-Z [65-90]; a-z [97-122]; Alef - Tav [1488-1514] ;  - [45]; space [32]; () [40-41]; . [46]; : [58]
	{
		for(var c=0; c< str.length;c++)
		{

			if (str.charCodeAt(c) < 32 || str.charCodeAt(c) > 1514)
				return false;
			else if (str.charCodeAt(c) > 58 && str.charCodeAt(c) < 65)
				return false;
			else if (str.charCodeAt(c) > 90 && str.charCodeAt(c) < 97)
				return false;	
			else if (str.charCodeAt(c) > 122 && str.charCodeAt(c) < 1488)
				return false;
			else if (str.charCodeAt(c) > 32 && str.charCodeAt(c) < 40)
				return false;
			else if (str.charCodeAt(c) > 41 && str.charCodeAt(c) < 45)
				return false;
			else if (str.charCodeAt(c) == 47)
				return false;
		
		}
		return true;
	}

function legalNamePositiveEx3(str)
{
	for(var c=0; c< str.length;c++)
		{
		    
		    if (str.charCodeAt(c) < 32 || str.charCodeAt(c) > 1514 &&(str.charAt(c)!="_" && str.charAt(c)!="&" && str.charAt(c)!="-" &&  str.charAt(c)!="~" && str.charAt(c)!=":" && str.charAt(c)!="\\" && str.charAt(c)!="/" && str.charAt(c)!="=" && str.charAt(c)!="’" && str.charAt(c)!=";" && str.charAt(c)!="." && str.charAt(c)!="," && str.charAt(c)!="?" && str.charAt(c)!="(" && str.charAt(c)!=")" && str.charAt(c)!="!" && str.charAt(c)!="@" && str.charAt(c)!="#" && str.charAt(c)!="$" && str.charAt(c)!="%" && str.charAt(c)!="^" && str.charAt(c)!="*"))
				return false;
			else if (str.charCodeAt(c) > 58 && str.charCodeAt(c) < 65 &&(str.charAt(c)!="_" && str.charAt(c)!="&" && str.charAt(c)!="-" &&  str.charAt(c)!="~" && str.charAt(c)!=":" && str.charAt(c)!="\\" && str.charAt(c)!="/" && str.charAt(c)!="=" && str.charAt(c)!="’" && str.charAt(c)!=";" && str.charAt(c)!="." && str.charAt(c)!="," && str.charAt(c)!="?" && str.charAt(c)!="(" && str.charAt(c)!=")" && str.charAt(c)!="!" && str.charAt(c)!="@" && str.charAt(c)!="#" && str.charAt(c)!="$" && str.charAt(c)!="%" && str.charAt(c)!="^" && str.charAt(c)!="*" ))
				return false;
			else if (str.charCodeAt(c) > 90 && str.charCodeAt(c) < 97 &&(str.charAt(c)!="_" && str.charAt(c)!="&" && str.charAt(c)!="-" &&  str.charAt(c)!="~" && str.charAt(c)!=":" && str.charAt(c)!="\\" && str.charAt(c)!="/" && str.charAt(c)!="=" && str.charAt(c)!="’" && str.charAt(c)!=";" && str.charAt(c)!="." && str.charAt(c)!="," && str.charAt(c)!="?" && str.charAt(c)!="(" && str.charAt(c)!=")" && str.charAt(c)!="!" && str.charAt(c)!="@" && str.charAt(c)!="#" && str.charAt(c)!="$" && str.charAt(c)!="%" && str.charAt(c)!="^" && str.charAt(c)!="*" ))
				return false;	
			else if (str.charCodeAt(c) > 122 && str.charCodeAt(c) < 1488 &&(str.charAt(c)!="_" && str.charAt(c)!="&" && str.charAt(c)!="-" &&  str.charAt(c)!="~" && str.charAt(c)!=":" && str.charAt(c)!="\\" && str.charAt(c)!="/" && str.charAt(c)!="=" && str.charAt(c)!="’" && str.charAt(c)!=";" && str.charAt(c)!="." && str.charAt(c)!="," && str.charAt(c)!="?" && str.charAt(c)!="(" && str.charAt(c)!=")" && str.charAt(c)!="!" && str.charAt(c)!="@" && str.charAt(c)!="#" && str.charAt(c)!="$" && str.charAt(c)!="%" && str.charAt(c)!="^" && str.charAt(c)!="*" ))
				return false;
			else if (str.charCodeAt(c) > 34 && str.charCodeAt(c) < 39 &&(str.charAt(c)!="_" && str.charAt(c)!="&" && str.charAt(c)!="-" &&  str.charAt(c)!="~" && str.charAt(c)!=":" && str.charAt(c)!="\\" && str.charAt(c)!="/" && str.charAt(c)!="=" && str.charAt(c)!="’" && str.charAt(c)!=";" && str.charAt(c)!="." && str.charAt(c)!="," && str.charAt(c)!="?" && str.charAt(c)!="(" && str.charAt(c)!=")" && str.charAt(c)!="!" && str.charAt(c)!="@" && str.charAt(c)!="#" && str.charAt(c)!="$" && str.charAt(c)!="%" && str.charAt(c)!="^" && str.charAt(c)!="*" ))
				return false;
			else if (str.charCodeAt(c) > 41 && str.charCodeAt(c) < 45 &&(str.charAt(c)!="_" && str.charAt(c)!="&" && str.charAt(c)!="-" &&  str.charAt(c)!="~" && str.charAt(c)!=":" && str.charAt(c)!="\\" && str.charAt(c)!="/" && str.charAt(c)!="=" && str.charAt(c)!="’" && str.charAt(c)!=";" && str.charAt(c)!="." && str.charAt(c)!="," && str.charAt(c)!="?" && str.charAt(c)!="(" && str.charAt(c)!=")" && str.charAt(c)!="!" && str.charAt(c)!="@" && str.charAt(c)!="#" && str.charAt(c)!="$" && str.charAt(c)!="%" && str.charAt(c)!="^" && str.charAt(c)!="*" ))
				return false;
			else if (str.charCodeAt(c) == 33 &&(str.charAt(c)!="_" && str.charAt(c)!="&" && str.charAt(c)!="-" &&  str.charAt(c)!="~" && str.charAt(c)!=":" && str.charAt(c)!="\\" && str.charAt(c)!="/" && str.charAt(c)!="=" && str.charAt(c)!="’" && str.charAt(c)!=";" && str.charAt(c)!="." && str.charAt(c)!="," && str.charAt(c)!="?" && str.charAt(c)!="(" && str.charAt(c)!=")" && str.charAt(c)!="!" && str.charAt(c)!="@" && str.charAt(c)!="#" && str.charAt(c)!="$" && str.charAt(c)!="%" && str.charAt(c)!="^" && str.charAt(c)!="*" ))
				return false;
		
		}
		return true;
		
}	

function legalNamePositiveEx1(str)
{
	for(var c=0; c< str.length;c++)
		{
		    
		    if (str.charCodeAt(c) < 32 || str.charCodeAt(c) > 1514 &&(str.charAt(c)!="_" && str.charAt(c)!="-"))
				return false;
			else if (str.charCodeAt(c) > 58 && str.charCodeAt(c) < 65 &&(str.charAt(c)!="_" && str.charAt(c)!="-"))
				return false;
			else if (str.charCodeAt(c) > 90 && str.charCodeAt(c) < 97 &&(str.charAt(c)!="_" && str.charAt(c)!="-"))
				return false;	
			else if (str.charCodeAt(c) > 122 && str.charCodeAt(c) < 1488 &&(str.charAt(c)!="_" && str.charAt(c)!="-"))
				return false;
			else if (str.charCodeAt(c) > 34 && str.charCodeAt(c) < 39 &&(str.charAt(c)!="_" && str.charAt(c)!="-" && str.charAt(c)!="&"))
				return false;
			else if (str.charCodeAt(c) > 41 && str.charCodeAt(c) < 45 &&(str.charAt(c)!="_" && str.charAt(c)!="-" && str.charAt(c)!=","))
				return false;
			else if (str.charCodeAt(c) == 47 || str.charCodeAt(c) == 33 &&(str.charAt(c)!="_" && str.charAt(c)!="-"))
				return false;
		
		}
		return true;
		
}	
	
function legalNamePositiveEx2(str)
//check if the string contains only English chars, Hebrew chars, numbers and the space, the apostrophy, the hyphen chars
// 0-9 [48-57]; A-Z [65-90]; a-z [97-122]; Alef - Tav [1488-1514] ;  - [45]; space [32]; () [40-41]; . [46]; : [58]; " [34]; ' [39]
	{
		for(var c=0; c< str.length;c++)
		{

			if (str.charCodeAt(c) < 32 || str.charCodeAt(c) > 1514)
				return false;
			else if (str.charCodeAt(c) > 58 && str.charCodeAt(c) < 65)
				return false;
			else if (str.charCodeAt(c) > 90 && str.charCodeAt(c) < 97)
				return false;	
			else if (str.charCodeAt(c) > 122 && str.charCodeAt(c) < 1488)
				return false;
			else if (str.charCodeAt(c) > 34 && str.charCodeAt(c) < 39)
				return false;
			else if (str.charCodeAt(c) > 41 && str.charCodeAt(c) < 45)
				return false;
			else if (str.charCodeAt(c) == 47 || str.charCodeAt(c) == 33)
				return false;
		
		}
		return true;
	}
	
function legalNamePositiveEx4(str)
//check if the string contains only English chars, Hebrew chars, numbers and the space
// 0-9 [48-57]; A-Z [65-90]; a-z [97-122]; Alef - Tav [1488-1514] ;  - [45]; space [32]; () [40-41]; . [46]; : [58]; " [34]; ' [39]
{
	for(var c=0; c< str.length;c++)
	{

		if (str.charCodeAt(c) < 32 || str.charCodeAt(c) > 1514)
			return false;
		else if (str.charCodeAt(c) > 58 && str.charCodeAt(c) < 65)
			return false;
		else if (str.charCodeAt(c) > 90 && str.charCodeAt(c) < 97)
			return false;	
		else if (str.charCodeAt(c) > 122 && str.charCodeAt(c) < 1488)
			return false;
		else if (str.charCodeAt(c) < 48 && str.charCodeAt(c) != 32)
			return false;	
	}
	return true;
}
function legalNameEnglish(str, strAlert)
//check if the string does not contain a hebrew char
	{
		for (var c=0; c<str.length; c++)
		{
			if (str.charCodeAt(c) >= 1488 && str.charCodeAt(c) <= 1514)
			{
				alert(strAlert);
				return false;
			}
		}
		return true;	
	}	

function legalCourseNum(str)
//check if the string contains English chars and numbers, Hyphen char
// 0-9 [48-57]; A-Z [65-90]; a-z [97-122]; - [45]
	{

		for(var c=0; c< str.length;c++)
		{
			if (str.charCodeAt(c) == 46 || str.charCodeAt(c) == 47)
				return false;
			else if (str.charCodeAt(c) < 45 || str.charCodeAt(c) > 122)
				return false;
			else if (str.charCodeAt(c) > 57 && str.charCodeAt(c) < 65)
				return false;
			else if (str.charCodeAt(c) > 90 && str.charCodeAt(c) < 97)
				return false;	
		}
		return true;
	}
	
function legalName2(str, illegal)
	{
	for (var c = 0; c < illegal.length; c++)
	{	
		if (parseInt(str.indexOf(illegal[c])) > -1)
			return false
	}
	return true
	}

function verifyBox(box, strAlert)
	{
	
	if (trim(box.value) == '')
		{
		alert(strAlert);
		box.focus();
		return false
		}
	return true
	}

	
function trim(str)
	{
	var result = new String(str);
	while (result.charAt(result.length - 1) == ' ')
		result = result.substring(0, result.length - 1);
	while (result.charAt(0) == ' ')
		result = result.substring(1, result.length);
	return result
	}
function makeRequest(frame)
	{
	//	Receives a frame and return an associated array that reflects the frame's
	//	querystring paramethers (similar to the Request.querystring collection in ASP)

	var href = frame.location.href;
	var qs = href.substring(href.indexOf('?') + 1, href.length);

	var pairs = qs.split('&');
	var request = [];

	var pair;
	var equal;

	for (var p = 0; p < pairs.length; p++)
		{
		pair = pairs[p];
		equal = pair.indexOf('=');
		request[pair.substring(0, equal)] = unescape(pair.substring(equal + 1, pair.length).replace(/\+/g, ' '))
		}
	return request
	}

function legalDate(strDate)
{
	var err2 = 0;
	var arrDate = strDate.split('/')
	if (arrDate.length < 3)
	{
		return false
	}
	else
	{
		//init the values
		var d = arrDate[0]
		var m = arrDate[1]
		var y = arrDate[2]
		if (d.length == 1)
			d = '0' + d
		if (m.length == 1)
			m = '0' + m
		if (y.length == 2)
			y = '20' + y
		if (d.length != 2 || m.length != 2 || y.length != 4)
			return false

		//check the values
		if (isNaN(d) || d<0 || d.indexOf(',')!=-1 || d.indexOf('.')!=-1 || d.indexOf('-')!=-1) err2 = 1
		if (isNaN(m) || m<0 || m.indexOf(',')!=-1 || m.indexOf('.')!=-1 || m.indexOf('-')!=-1) err2 = 1
		if (isNaN(y) || y<0 || y.indexOf(',')!=-1 || y.indexOf('.')!=-1 || y.indexOf('-')!=-1) err2 = 1
		if (m<1 || m>12) err2 = 1
		if (d<1 || d>31) err2 = 1
		if (y<1990 || y>3000) err2 = 1
		//check months with 30 days
		if (m==4 || m==6 || m==9 || m==11)
		{
			if (d==31) err2=1
		}
		// february, leap year
		if (m==2)
		{
			// feb
			var feb=parseInt(y/4)
			if (isNaN(feb)) 
			{
				err2=1
			}

			if (d>29) err2=1
			if (d==29 && ((y/4)!=parseInt(y/4))) err2=1
		}
		if (err2 != 0)
			return false
	}		
	return true
}

function legalDateWithFormat(strDate,DateFormat)
{
    var err2 = 0;
	var arrDate = strDate.split('/')
	if (arrDate.length < 3)
	{
		return false
	}
	else
	{
		//init the values
		if(DateFormat=="dd/mm/yyyy")
		{
		    var d = arrDate[0]
		    var m = arrDate[1]
		    var y = arrDate[2]
		    if (d.length == 1)
			    d = '0' + d
		    if (m.length == 1)
			    m = '0' + m
		    if (y.length == 2)
			    y = '20' + y
		    if (d.length != 2 || m.length != 2 || y.length != 4)
			    return false

		    //check the values
		    if (isNaN(d) || d<0 || d.indexOf(',')!=-1 || d.indexOf('.')!=-1 || d.indexOf('-')!=-1) err2 = 1
		    if (isNaN(m) || m<0 || m.indexOf(',')!=-1 || m.indexOf('.')!=-1 || m.indexOf('-')!=-1) err2 = 1
		    if (isNaN(y) || y<0 || y.indexOf(',')!=-1 || y.indexOf('.')!=-1 || y.indexOf('-')!=-1) err2 = 1
		    if (m<1 || m>12) err2 = 1
		    if (d<1 || d>31) err2 = 1
		    if (y<1990 || y>3000) err2 = 1
		    //check months with 30 days
		    if (m==4 || m==6 || m==9 || m==11)
		    {
			    if (d==31) err2=1
		    }
		    // february, leap year
		    if (m==2)
		    {
			    // feb
			    var feb=parseInt(y/4)
			    if (isNaN(feb)) 
			    {
				    err2=1
			    }

			    if (d>29) err2=1
			    if (d==29 && ((y/4)!=parseInt(y/4))) err2=1
		    }
		    if (err2 != 0)
			    return false
	    }
	    else
	    {
	        var d = arrDate[1]
		    var m = arrDate[0]
		    var y = arrDate[2]
		    if (d.length == 1)
			    d = '0' + d
		    if (m.length == 1)
			    m = '0' + m
		    if (y.length == 2)
			    y = '20' + y
		    if (d.length != 2 || m.length != 2 || y.length != 4)
			    return false

		    //check the values
		    if (isNaN(d) || d<0 || d.indexOf(',')!=-1 || d.indexOf('.')!=-1 || d.indexOf('-')!=-1) err2 = 1
		    if (isNaN(m) || m<0 || m.indexOf(',')!=-1 || m.indexOf('.')!=-1 || m.indexOf('-')!=-1) err2 = 1
		    if (isNaN(y) || y<0 || y.indexOf(',')!=-1 || y.indexOf('.')!=-1 || y.indexOf('-')!=-1) err2 = 1
		    if (m<1 || m>12) err2 = 1
		    if (d<1 || d>31) err2 = 1
		    if (y<1990 || y>3000) err2 = 1
		    //check months with 30 days
		    if (m==4 || m==6 || m==9 || m==11)
		    {
			    if (d==31) err2=1
		    }
		    // february, leap year
		    if (m==2)
		    {
			    // feb
			    var feb=parseInt(y/4)
			    if (isNaN(feb)) 
			    {
				    err2=1
			    }

			    if (d>29) err2=1
			    if (d==29 && ((y/4)!=parseInt(y/4))) err2=1
		    }
		    if (err2 != 0)
			    return false
	    }
	}		
	return true
}

function strFromDate(strDate)
{
	var arrDate = strDate.split('/')
	if (arrDate.length < 3)
		return ''
	else
	{
		//init the values
		var d = arrDate[0]
		var m = arrDate[1]
		var y = arrDate[2]
		if (d.length == 1)
			d = '0' + d
		if (m.length == 1)
			m = '0' + m
		if (y.length == 2)
			y = '20' + y
		if (d.length != 2 || m.length != 2 || y.length != 4)
			return ''
	}
	var str = y + m + d + '000000'
	return str
}

function myParseInt(strTmp)
{
	//return a decimal integer
	return parseInt(strTmp, 10)
}

function dateFromStr(str)
{
	if (trim(str) != '')
	{
		var y = str.substring(0,4)
		var m = str.substring(4,6)
		var d = str.substring(6,8)
		var strDate = d +'/' + m + '/' + y
	}
	else
		var strDate = '';
	return strDate
}

function CheckDatesDiffs(Date1,Date2)
{
	
	
	if (trim(Date1) != '')
	{
		var y = Date1.substring(0,4)
		var m = Date1.substring(4,6)
		var d = Date1.substring(6,8)
		var strDate1 = d +'/' + m + '/' + y
	}
	else
		return false;
	
	if (trim(Date2) != '')
	{
		var y2 = Date2.substring(0,4)
		var m2 = Date2.substring(4,6)
		var d2 = Date2.substring(6,8)
		var strDate2 = d2 +'/' + m2 + '/' + y2
	}
	else
		return false;
		
	if(y>y2)
		return true;
	if(m>m2 && y==y2)
		return true;
	if(d>d2 && m==m2 && y==y2)
		return true;
	
	
		
		
return false		
	
	
}


function SetCookieJs(CookieName,CookieValue)
{
	var NewCookie
	var aCookie = document.cookie.split("; ");
	prop_found=0
	for (var i=0; i < aCookie.length; i++)
	{
		var pair = aCookie[i].split("=");
		if (PROPERTIES_COOKIE == pair[0])
		{
			prop_found=1
			if (aCookie[i].indexOf(CookieName+'=') != -1)
				return
			else
				NewCookie=aCookie[i].substr(0,aCookie[i].length)+'&'+CookieName+'='+escape(CookieValue)+';'
		}
    }
    if (!prop_found)
		document.cookie=PROPERTIES_COOKIE + '='+CookieName+'=' + escape(CookieValue) + ';path=/;' 
	else
		document.cookie= NewCookie + ';path=/;' 
}


function GetWindowPos(width, height)
{
	var t, l, params
	
	t = (window.screen.height-height)/2		// top
	l = (window.screen.width-width)/2		//left
	params = ",top=" + t + ",left=" + l
	return params
}
function VerifyChars( El, AllowChars, ForbiddenChars, isMandatory, strErrMand, strErrChars)
{

	curStr = trim(El.value)
	if (isMandatory == '1' && curStr == '')
	{
		alert (strErrMand)
		El.focus();
		return false
	}
	//AllowChars & ForbiddenChars are in Format [char1 -  char2][char3]...
	if (trim(AllowChars + '').length > 0)
	{
		var AllowCells = (AllowChars + '').split(']')
		strOK = 1
		c = 0
		while (c < curStr.length && strOK == 1)
		{
			charOK = 0
			j = 0
			while  ( j < (AllowCells.length - 1) && charOK == 0)
			{

				var curChars = AllowCells[j].substring(1, AllowCells[j].length)
				var MinMax = curChars.split('-')
				if (MinMax.length == 1)
				{
					//one character
					if (curStr.charCodeAt(c) == MinMax[0])
						charOK = 1
					
				}
				else
				{
					//range
					if (curStr.charCodeAt(c) >= MinMax[0] && curStr.charCodeAt(c) <= MinMax[1])
						charOK = 1
					
				}
				j++
			}
			if (charOK == 0)
			{
				strOK = 0
			}
			c++
		}
		if (strOK == 0)
		{
			alert (strErrChars)
			El.focus()
			return false;
		}
	}
	if (trim(ForbiddenChars + '').length > 0)
	{
		var ForbiddenCells = (ForbiddenChars + '').split(']')
		strOK = 1
		c = 0
		while (c< curStr.length && strOK == 1)
		{
		
			charOK = 1
			j = 0
			while  ( j < AllowCells.length && charOK == 1)
			{
				var curChars = AllowCells[j].substring(1, AllowCells[j].length)
				var MinMax = curChars.split('-')
				if (MinMax.length == 1)
				{
					//one character
					if (curStr.charCodeAt(c) == MinMax[0])
						charOK = 0
				}
				else
				{
					//range
					if (curStr.charCodeAt(c) >= MinMax[0] && curStr.charCodeAt(c) <= MinMax[1])
						charOK = 0
				}
				j++
			}
			if (charOK == 0)
				strOK = 0
			c++
		}
		if (strOK == 0)
		{
			alert (strErrChars)
			El.focus()
			return false;
		}
	}	
	return true;
}
function WinWidth(Per)
{
	return Per/100 * screen.width
}
function WinHeight(Per)
{
	return Per/100 * screen.height
}
function findRootChildFrame( name ) 
{
	var currentFrame = this;
	var index = 0; // prevents endless loop
	while( currentFrame.name != name && currentFrame != null && index < 50 ) 
	{
		if( currentFrame.frames[ name ] != null ) currentFrame = currentFrame.frames[ name ];
		else if( currentFrame.parent != currentFrame ) currentFrame = currentFrame.parent;
		else if( currentFrame.window.opener != null ) currentFrame = currentFrame.window.opener;
		index++;
	}
	return currentFrame;
}

function toggleProgressBar( on, parentName ) 
{
	var name = ( parentName == null ? 'ProgressBar' : parentName );
	var fs = findRootChildFrame( name );
	var rows = fs.rows.split( ',' );
	rows[ rows.length - 1 ] = ( on ? 20 : 0 );
	fs.rows = rows.join();
}

function SendRequest(Page, Data)
{
		
	if (window.ActiveXObject)
	{
		var xmlhttp = new ActiveXObject("Microsoft.XMLHTTP")
		xmlhttp.open ("POST", Page, false);
		xmlhttp.send(Data)		
		
		return xmlhttp.responseText
	}
	else
	{
		var xmlhttp = new XMLHttpRequest();
		xmlhttp.open ("POST", Page, false);
		xmlhttp.send('');
		
		
		return xmlhttp.responseText
	}
	
}

function SetSiteLanguage(Lang)
{
	document.cookie='cetLanguage=site=' + Lang + ';'
}

function SetCookieJs2(MainCookie,CookieName,CookieValue)
{
	var NewCookie
	var aCookie = document.cookie.split("; ");
	prop_found=0
	for (var i=0; i < aCookie.length; i++)
	{
		var pair = aCookie[i].split("=");
		if (MainCookie == pair[0])
		{
			prop_found=1
			if (aCookie[i].indexOf(CookieName+'=') != -1)
				return
			else
				NewCookie=aCookie[i].substr(0,aCookie[i].length)+'&'+CookieName+'='+escape(CookieValue)+';'
		}
    }
    if (!prop_found)
		document.cookie=MainCookie + '='+CookieName+'=' + escape(CookieValue) + ';path=/;' 
	else
		document.cookie= NewCookie + ';path=/;' 
}
function OpenLESkin(Path,NewWin)
{
	

	try{
	if(NewWin==1)
		newWin=window.open(Path,'InfoMode','top=0,left=0,width='+(screen.width-10)+',height='+(screen.height-60)+',resizable=yes')
	else
		parent.parent.parent.frames['vcMain'].location.href=Path
	}
	catch(e)
	{
		try{
		top.opener.top.parent.parent.parent.frames['vcMain'].location.href=Path
		top.close();
		}
		catch(e)
		{
			alert(e.description)
		}
		
	}
}
function DateOBjFromStrDate(d)
{
	var arrDate = d.split('/')
	if (arrDate.length < 3)
		return ''
	var d = arrDate[0]
	var m = arrDate[1]
	var y = arrDate[2]
	return new Date(y,m-1,d)
}

function DateOBjFromStrDateWithDateFormat(d,DateFormat)
{
    if(DateFormat=="dd/mm/yyyy")
    {
	    var arrDate = d.split('/')
	    if (arrDate.length < 3)
		    return ''
	    var d = arrDate[0]
	    var m = arrDate[1]
	    var y = arrDate[2]
	    return new Date(y,m-1,d)
	}
	else
	{
	    var arrDate = d.split('/')
	    if (arrDate.length < 3)
		    return ''
	    var d = arrDate[1]
	    var m = arrDate[0]
	    var y = arrDate[2]
	    return new Date(y,m-1,d)
	}
}
/*function getCookieVal (offset) 
{ 
	var endstr = document.cookie.indexOf (";", offset); 
	if (endstr == -1) 
	endstr = document.cookie.length; 
	return unescape(document.cookie.substring(offset, endstr)); 
} */
function GetOperatingSystem()
{

	var str=navigator.appVersion
	var oper_sys=str.split(";")[2]
	var oper_sys_final=oper_sys.split(")")[0]
	oper_sys_final= oper_sys_final.slice(1)	
	return oper_sys_final;
}
function SetScreenSize(heght,width)
{
	opSys = GetOperatingSystem()
	var span = document.all['SpanForHeight']
	
	if (span!=null)
	{
		if ( opSys =='Windows NT 5.1')
			h = screen.availHeight-heght-18
		else
			h = screen.availHeight-heght
		if ( width!=-1)
		{
			w = screen.availWidth-width
			//w=150
			try{
			span.style.width = w
			}catch(e)
			{
			}
		}
		try{
		//h=200
		
		span.style.height = h
		}catch(e)
		{
		}

	}
}
function sendXml( page, message ) 
{
	if(isE)
		var xmlhttp = new ActiveXObject( 'Microsoft.XMLHTTP' );
	else
		var xmlhttp = new XMLHttpRequest(); 
	
	xmlhttp.open( 'GET', page, false );
	xmlhttp.setRequestHeader("Content-Type", "xml/text; Charset=windows-1255");
	
	if( message == null || message == '' ) message = '<root></root>';
		xmlhttp.send( message );
	return xmlhttp.responseText;
}
function sendXmlRequest( page, message ) 
{
	if(isE)
		var xmlhttp = new ActiveXObject( 'Microsoft.XMLHTTP' );
	else
		var xmlhttp = new XMLHttpRequest(); 
	
	xmlhttp.open( 'GET', page, false );
	if( message == null || message == '' ) message = '<root></root>';
		xmlhttp.send( message );
	return xmlhttp.status;
}

function ExportEvaluationData(departmentID, groupID, courseID, userIDList, searchStr)
{
	var page = "/HighLearnNet/ShaharSheli/ShaharSheliActions.aspx";
	var request = 'ActionType=ExportEvalData&DepartmentID=' + departmentID + '&GroupID=' +
				  groupID + '&CourseID=' + courseID + '&UserIDList=' + userIDList +
				  '&SearchStr=' + escape(searchStr);
	var result = sendXmlPost( page, request, null )
	return result;
}

function sendXmlPost( page, request, message ) 
{
	if(isE)
		var objHTTP = new ActiveXObject("Microsoft.XMLHTTP");
	else
		var objHTTP = new XMLHttpRequest(); 
    
    var httpMethod = "POST";
    objHTTP.open(httpMethod, page, false);
    objHTTP.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    objHTTP.send(request);
    var reply = objHTTP.responseText;
    return reply;
}

function SendXmlHttpRequest(page)
{
	if(isE)
		var xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
	else
		var xmlhttp = new XMLHttpRequest();
	
	xmlhttp.open( 'GET', page, false );
	xmlhttp.send(null);
	var result = xmlhttp.responseText;
	return result;
}
function DateSelector(Element)
{
				
   remote=window.open('/DateToReport.asp?Date=' + escape( document.all[ Element ].value ) + '&Element='+ escape( Element ),'Calendar', 'width=188,height=220,resizable=no,scrollbars=no,status=0');
	if (remote != null)
	{
		if (remote.opener == null)
			remote.opener = self;
			remote.focus();
	}
}
			

function legalDate(strDate)
{
	var err2 = 0;
	var arrDate = strDate.split('/')
	if (arrDate.length < 3)
	{
		return false
	}
	else
	{
		//init the values
		var d = arrDate[0]
		var m = arrDate[1]
		var y = arrDate[2]
		if (d.length == 1)
			d = '0' + d
		if (m.length == 1)
			m = '0' + m
		if (y.length == 2)
			y = '20' + y
		if (d.length != 2 || m.length != 2 || y.length != 4)
			return false

		//check the values
		if (isNaN(d) || d<0 || d.indexOf(',')!=-1 || d.indexOf('.')!=-1 || d.indexOf('-')!=-1) err2 = 1
		if (isNaN(m) || m<0 || m.indexOf(',')!=-1 || m.indexOf('.')!=-1 || m.indexOf('-')!=-1) err2 = 1
		if (isNaN(y) || y<0 || y.indexOf(',')!=-1 || y.indexOf('.')!=-1 || y.indexOf('-')!=-1) err2 = 1
		if (m<1 || m>12) err2 = 1
		if (d<1 || d>31) err2 = 1
		if (y<1990 || y>3000) err2 = 1
		//check months with 30 days
		if (m==4 || m==6 || m==9 || m==11)
		{
			if (d==31) err2=1
		}
		// february, leap year
		if (m==2)
		{
			// feb
			var feb=parseInt(y/4)
			if (isNaN(feb)) 
			{
				err2=1
			}

			if (d>29) err2=1
			if (d==29 && ((y/4)!=parseInt(y/4))) err2=1
		}
		if (err2 != 0)
			return false
	}		
	return true
}

// Initializes a new instance of the StringBuilder class
// and appends the given value if supplied
function StringBuilder(value)
{
	
    this.strings = new Array("");
    this.append(value);
}

// Appends the given value to the end of this instance.
StringBuilder.prototype.append = function (value)
{
	if (value)
    {
        this.strings.push(value);
    }
}

// Clears the string buffer
StringBuilder.prototype.clear = function ()
{
	this.strings.length = 1;
}

// Converts this instance to a String.
StringBuilder.prototype.toString = function ()
{
    return this.strings.join("");
}

function param( ExtraParam ) {
	var width = arguments[ 1 ];
	
	var params = "";
	w = ( arguments[ 1 ] ? arguments[ 1 ] : window.screen.width * 0.9 ); // width
	h = ( arguments[ 2 ] ? arguments[ 2 ] : window.screen.height * 0.8 ); // height
	l = ( arguments[ 3 ] ? arguments[ 3 ] : ( window.screen.width - w ) / 2 );// left
	t = ( arguments[ 4 ] ? arguments[ 4 ] : ( window.screen.height - h ) / 4 );// top
	//t = ( window.screen.height - h ) / 4; // top
	
	if( ExtraParam.indexOf( "TB" ) != -1 ) { // toolbar=yes
		h = h - 60;
		params = params + "toolbar=yes,";
	}
	if( ExtraParam.indexOf( "MB" ) != -1 ) { // menubar=yes
		h = h - 30;
		params = params + "menubar=yes,";
	}	
	if( ExtraParam.indexOf( "LO" ) != -1 ) { // location=yes
		h = h - 30;
		params = params + "location=yes,";
	}
	if( ExtraParam.indexOf( "ST" ) != -1 ) { // status=yes
		h = h - 30;
		params = params + "status=yes,";
	}
	if( ExtraParam.indexOf( "RE" ) != -1 ) { // resizable=yes
		params = params + "resizable=yes,";
	}
	if( ExtraParam.indexOf( "SB" ) != -1 ) { // scrollbars=yes
		params = params + "scrollbars=yes,";
	}
	if( ExtraParam.indexOf( "FS" ) != -1 ) { // fullscreen=yes
		params = params + "fullscreen=yes,";
	}
	params = params + "height=" + h + ",width=" + w + ",top=" + t + ",left=" + l;
	return( params );
}
	function focus( win ) {
	if( win ) win.focus();
}
function cmdItemEdit(SubjectId,ItemId,HeaderType,CourseId) {
	var bareketPath = '/bareket/';
	var params = 'RE,SB';
	if( HeaderType != 60 && HeaderType != 61) params += ',TB';
	if(HeaderType == 34)
	{
	AddWindow = window.open( 
			bareketPath + 'EditItemByType.asp' 
				+ '?sid=' + SubjectId
				+ '&iid=' + ItemId
				+ '&IH_Type=' + HeaderType
				+ '&vcCourseID=' + CourseId,
			'AddWindow', 
			'toolbar=yes,resizable=yes,scrollbars=yes,height=630,width=500,top=38,left=200');
		}	
		else if(HeaderType == 36)	
			{
			AddWindow = window.open( 
			bareketPath + 'EditItemByType.asp' 
				+ '?sid=' + SubjectId
				+ '&iid=' + ItemId
				+ '&IH_Type=' + HeaderType
				+ '&vcCourseID=' + CourseId,		
			'AddWindow', 
			'resizable=no,scrollbars=yes,height=410,width=650,top=58,left=200');
		}
		else if (HeaderType == 1)
	{	
	     AddWindow = window.open( 
			bareketPath + 'EditItemByType.asp' 
				+ '?sid=' + SubjectId
				+ '&iid=' + ItemId
				+ '&IH_Type=' + HeaderType
				+ '&vcCourseID=' + CourseId,
	           'AddWindow', 
		        param( params ));
		
		 AddWindow.moveTo( 0, 0 );
		 AddWindow.resizeTo( screen.availWidth, screen.availHeight );
		}
		else
		{
         AddWindow = window.open( 
			bareketPath + 'EditItemByType.asp' 
				+ '?sid=' + SubjectId
				+ '&iid=' + ItemId
				+ '&IH_Type=' + HeaderType
				+ '&vcCourseID=' + CourseId,
				'AddWindow', 
			param( params ));
			}
			focus( AddWindow );

				
}

function openmainwin(iid,ObjType)
{

 AddWindow = window.open
 ('/HighLearnNet/kb/ListDeleteFromMain.aspx'
 + '?iid=' +iid 
 + '&ObjType=' +ObjType 
 ,'DeleteFromList'
 ,'height=400,width=500,top=58,left=200');
 
}

/////////////////////////////////////////////////////////////////////////////////////
// Check the BROWSER :
function check_Brow()
{
	str=navigator.appVersion
	brow_sys=str.split(";")[1]
	version= brow_sys.split(" ")[2]
	client_browser=navigator.appName +" "+version 
	// Disable Internet Explorer 5.5 : (version!="5.5" &&) 
	if(navigator.appName!="Microsoft Internet Explorer" || version.split(".")[0]!="6" && version.split(".")[0]!="7")
	  {	
			// NOT IE or less then IE 6.0 :													
			return 0
	  }
	else
	  {
			return 2
	  }
}
////////////////////////////////////////////////////////////////////////////////////
// Check Operating System :
function check_OpSys()
{
	str=navigator.appVersion
	oper_sys=str.split(";")[2]
	oper_me=""
	try{oper_me = str.split(";")[3]}catch(e){}
	oper_sys_final=oper_sys.split(")")[0]
	oper_sys_final= oper_sys_final.slice(1)
	if(oper_sys_final == "Macintosh")
	{
		// Mackintosh = NOT GOOD
		return 0
	}
	else
	{
		if(oper_sys_final.split(" ")[1]=="98" || oper_sys_final.split(" ")[1]=="NT")
		{
			// WINDOWS 98 and higher : GOOD
			return 2
		}
		else
		{
			// less then WINDOWS 98 : NOT GOOD
			return 0
		}
	}
	if (oper_sys_final=="Windows NT 5.0")
		//document.all['operatingTD'].innerText= "Windows 2000"
		return 2					//  GOOD
	else if(oper_sys_final=="Windows NT 5.1")
		//document.all['operatingTD'].innerText= "Windows XP"
		return 2					//  GOOD
	else if (oper_sys_final=="Windows 98" && oper_me=="Win 9x 4.90") 
		//document.all['operatingTD'].innerText= "Windows Me"
		return 2					//  GOOD
	else
		document.all['operatingTD'].innerText= oper_sys_final
}
///////////////////////////////////////////////////////////////////////////////////////
// Check Platform :
function check_Platform()
{
	if(navigator.platform != opt[2])
	{	// Platform = WIN32 :  GOOD
		return 0
	}
	else
	{	// Platform else : NOT GOOD
		return 2
	}
}
////////////////////////////////////////////////////////////////////////////////////
// Check Screen Resolution :
function check_Resolution()
{
	client_resolution=screen.width + "*" + screen.height
	if(client_resolution != opt[3])
	{
		if(screen.width == opt[6] && screen.height == opt[7])
			return 2					// GOOD
		else if(screen.width > opt[6] && screen.height > opt[7])
			return 1					// OK (less then GOOD)
		else
			return 0					// NOT GOOD
	}
	else
	{	// GOOD :
		return 2
	}
}
//////////////////////////////////////////////////////////////////////////////////////
// Check Cookies :
function check_Cookie()
{
	if(navigator.cookieEnabled)
	{
		return 2
	}
	else
	{
		return 0
	}
}
/////////////////////////////////////////////////////////////////////////////////////
// Check Media Player :
function check_Media()
{
	var obj =document.all("LoginLinksClientCaps")
	var client_media;
	if(obj.isComponentInstalled("{22D6F312-B0F6-11D0-94AB-0080C74C7E95}","ComponentID") || obj.isComponentInstalled("{6BF52A52-394A-11d3-B153-00C04F79FAA6}","ComponentID"))
		return 2
	else
		return 0
}
///////////////////////////////////////////////////////////////////////////////////
// Check Java Virtual Machine :
function check_JVM()
{
	var obj =document.all("LoginLinksClientCaps")
	
	var client_JVM = obj.isComponentInstalled("MSJava", "progid") || obj.isComponentInstalled("{8AD9C840-044E-11D1-B3E9-00805F499D93}","ComponentID")|| obj.isComponentInstalled("{08B0E5C0-4FCB-11CF-AAA5-00401C608500}","ComponentID")
	if(client_JVM)
	{
		return 2
	}
	else
	{
		return 0
	}
}
///////////////////////////////////////////////////////////////////////////////////
// Check Web :
function check_Web()
{
	var obj =document.all("LoginLinksClientCaps")
	
	//var client_web= obj.isComponentInstalled("{73fa19d0-2d75-11d2-995d-00c04f98bbc9}","clsid")
	var client_web= obj.isComponentInstalled("{08B0E5C0-4FCB-11CF-AAA5-00401C608500}","componentID")
	if(client_web)
	{
		return 2
	}
	else
	{
		return 0
	}
}
//////////////////////////////////////////////////////////////////////
// Check For PopUp Blocker:
function check_PopUpBlocker()
{  
	
	//var oWin = window.open("","testpopupblocker","width=1,height=1,top=-3000,left=-3000");
	var oWin = window.open("","","width=10,height=10,top=-5000,left=-5000");
	//oWin.moveTo( 0, 0 );
	//oWin.resizeTo( screen.availWidth, screen.availHeight );
	//oWin.moveTo(-200,-200)
	if ( oWin==null || typeof(oWin)=="undefined" ) 
	{
		PopUpOn = true
		return 0
	} 
	else 
	{
		
		PopUpOn = false
		oWin.close();
		return 2
	} 
}
//////////////////////////////////////////////////////////////////////////////////////

// Status of all checks :
function check_Status()
{
	
	status=0
	if(check_Brow()==0 ||check_OpSys()==0 ||  check_Platform()==0 || check_Resolution()==0 ||check_Cookie()==0 || check_Media()==0 || check_JVM()==0 || check_Web()==0 || check_PopUpBlocker()==0 )
		status = 1
	
	if (status>0)
	{
		animation_Sys_Chk(index)
		interval_Status_ID = setTimeout('clear_Interval()',10000)
	}
	
}
///////////////////////////////////////////////////////////////////////////////////////
// Animation for "System Check" Button : (in case of bad status)
function animation_Sys_Chk(x)
{
	if(index == 0)
	{
		if (interval_Animation_ID != null)
			clearTimeout(interval_Animation_ID)
		if (x == 0)
		{
			document.all['sys_chk'].style.visibility = "visible"
			interval_Animation_ID = setTimeout('animation_Sys_Chk(1)',500)
		}
		else if (x==1)
		{
			document.all['sys_chk'].style.visibility = "hidden"
			interval_Animation_ID = setTimeout('animation_Sys_Chk(0)',500)
		}
	}
}
///////////////////////////////////////////////////////////////////////////////////////
function clear_Interval()
{
	index = 3							// Stop Loop Value
	clearTimeout(interval_Status_ID)
	clearTimeout(interval_Animation_ID)
	document.all['sys_chk'].style.visibility = "visible"
}
//////////////////////////////////////////////////////////////////////////////////////
// Parameter for SchoolCity : <body onload="chk_SchoolCity_Param(schoolCity)">
	function chk_SchoolCity_Param(schoolCity)
	{
		if(schoolCity == 1)
			check_Status()
	}
 function FixFlow()
 {
        document.getElementById('RadGrid1_GridData').style.overflowX="hidden"
 }
 
 function OpenAdvancedSearch(TypesList, CourseID, GetAll, Title, HasTitle, CloseOnSave, ChooseOne, WindowName, SecondWindow)
 {
    var url = '/highlearnnet/administration/advancedsearch/advancedsearch.aspx?TypesList='+TypesList
    if (CourseID != '' && CourseID != null)
        url += '&CourseID='+CourseID
    if (GetAll == "1")
        url += '&GetAll=1'
    if (Title != '' && Title != null)
        url += '&Title='+Title
    if (HasTitle != '' && HasTitle != null)
        url += '&HasTitle='+HasTitle
    if (CloseOnSave == '1')
        url += '&CloseOnSave='+CloseOnSave
    if (ChooseOne == '1')
        url += '&ChooseOne=1'
    if (SecondWindow == '1')
        url += '&SecondWindow=1'
    var width=window.screen.width * 0.80;
    var height=window.screen.height * 0.75;
    var top = (window.screen.height-height)/2
	var left = (window.screen.width-width)/2
    var params='top='+top+',left='+left+',width='+width+',height='+height+',resizable=yes,scrollbars=yes,toolbar=no'
    var tmpname;
    if (WindowName != null && WindowName != '')
        tmpname = WindowName;
    else
        tmpname='AdvSearchWin';
    var AdvWin = window.open(url,tmpname,params)
    AdvWin.focus();
 }
 
 function AdvancedSearchFrames(TypesList, CourseID, GetAll, Title, HasTitle, View, EntitiesListUrl)
 {
    var url = '/highlearnnet/administration/advancedsearch/advancedsearch.aspx?TypesList='+TypesList
    if (CourseID != '' && CourseID != null)
        url += '&CourseID='+CourseID
    if (EntitiesListUrl != '' && EntitiesListUrl != null)
        url  += '&EntitiesListUrl='+EntitiesListUrl
     if (GetAll == "1")
        url += '&GetAll=1'
    if (Title != '' && Title != null)
        url += '&Title='+Title
    if (HasTitle != '' && HasTitle != null)
        url += '&HasTitle='+HasTitle
    if (View == "1")
        url += '&View=1'
    location.href = url;
 }
 
 function IIF(expr, truepart, falsepart)
{
    if(expr)return truepart
    else return falsepart
}

//////////////////////////////////////////////////////////////////////////////////////
// Password Restriction check

function IsMatch(Expression, PassValue)
{
    RegularExpression  = new RegExp(Expression);
    var match = PassValue.match(RegularExpression);
    if(match != null)return true
    else return false
}


function CreateRegularExpression (Limitation, StartLetter, EndLetter)
{
	
		ResultString = "("

		var StartIndex = StartLetter.charCodeAt(0)
		var EndIndex = EndLetter.charCodeAt(0)
		while (StartIndex < EndIndex-Limitation+2)
		{
			var PromString = "("
			for  (var i=0;i<Limitation;i++)
				PromString += String.fromCharCode(StartIndex+i) 
				
			PromString += ")";
			ResultString += PromString;
			if (StartIndex < EndIndex-Limitation+1)
				ResultString += "|";
			StartIndex += 1;
		}
		ResultString += ")"
		
		return ResultString
}

function ltrim(str) 
{ 
    return str.replace(/^[ ]+/, ''); 
} 
 
function rtrim(str) 
{ 
    return str.replace(/[ ]+$/, ''); 
} 
 
function trim(str) 
{ 
    return ltrim(rtrim(str)); 
} 
//***** Get window's width/height ***** //

function GetWindowWidth()
{
    if (typeof(window.innerWidth) != "undefined")
        return window.innerWidth;
    else if (document.documentElement.clientWidth > 0)
        return document.documentElement.clientWidth;
    else
        return document.documentElement.offsetWidth;
}

function GetWindowHeight()
{
    
    if (typeof(window.innerHeight) != "undefined")
        return window.innerHeight;
    else if (document.documentElement.clientHeight > 0)
        return document.documentElement.clientHeight;
    else
        return document.documentElement.offsetHeight;
}
function SetScreenSizeByResolution(elementID,height,width)
{
	
	var span = document.getElementById(elementID)
	
	if (span!=null)
	{
		
		h = GetWindowHeight()-height
		w = GetWindowWidth()-width
			//w=150
			try{
			span.style.width = w
			}catch(e)
			{
			}
		
		try{
	    
		span.style.height = h
	   
		}catch(e)
		{
		    alert()
		}

	}
}
 
/////////////////////////////////////////////////////////////////////////
// Set image Height (and adjust width as well to keep its proportions
/////////////////////////////////////////////////////////////////////////
function SetImageHeight(imageObject, newHeight, maxWidth)
{
    if (imageObject == null || imageObject.src == "")
        return;
        
    var tmpImage = new Image();
    tmpImage.src = imageObject.src;
    var originalHeight = tmpImage.height;
    var originalWidth = tmpImage.width;
    var newWidth = newHeight * (originalWidth / originalHeight);
    if (typeof(maxWidth) != "undefined" && newWidth > maxWidth)
        newWidth = maxWidth;
    
    imageObject.style.height = newHeight + "px";
    imageObject.style.width = newWidth + "px";
}

/////////////////////////////////////////////////////////////////////////
// Set image width (and adjust height as well to keep its proportions
/////////////////////////////////////////////////////////////////////////
function SetImageWidth(imageObject, newWidth, maxHeight)
{
    if (imageObject == null || imageObject.src == "")
        return;
        
    var tmpImage = new Image();
    tmpImage.src = imageObject.src;
    var originalHeight = tmpImage.height;
    var originalWidth = tmpImage.width;
    var newHeight = maxHeight * (originalHeight / originalWidth);
    if (typeof(newHeight) != "undefined" && newHeight > maxHeight)
        newHeight = maxHeight;
    
    imageObject.style.height = newHeight + "px";
    imageObject.style.width = newWidth + "px";
}
function SelectSingleNode(xmlNode, elementPath) 
{ 
    if (xmlNode == null)
        return null;
        
    if(typeof(xmlNode.selectSingleNode) != "undefined")
    { 
        return xmlNode.selectSingleNode(elementPath); 
    } 
    else if (typeof(XPathEvaluator) != "undefined")
    { 
        var xpathEvaluator = new XPathEvaluator();
        var docElement = xmlNode.ownerDocument == null ? xmlNode.documentElement : xmlNode.ownerDocument.documentElement;
    
        var nsResolver = xpathEvaluator.createNSResolver(docElement); 
        var results = xpathEvaluator.evaluate(elementPath, xmlNode, nsResolver, XPathResult.FIRST_ORDERED_NODE_TYPE, null);
        return results.singleNodeValue; 
    } 
    return null;
} 
function GetXmlString(xmlElement)
{
    if (xmlElement == null)
        return "";        
    else if (typeof(xmlElement.xml) != "undefined")
        return xmlElement.xml;    
    else if (typeof(XMLSerializer) != "undefined")
        return new XMLSerializer().serializeToString(xmlElement);
    
    return "";
}