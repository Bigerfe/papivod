//����ִ����ִ������ķ���
function Exec()
{
	if(getCheckedCount()=="0")
	{
		alert("��ѡ����Ҫִ�еĲ����ļ�¼��");
		return false;
	}
	var dwl=document.getElementById("dwlstate").value;//��ȡ�������͵�ֵ
	var ok=confirm("ȷ��ִ�в�����?")
	if(!ok)
	{
		return false;
	}
	else
	{
		return true;
	}
}
//�ж�CheckBox�Ƿ�ѡ��
function getCheckedCount()
{
	var elements=document.getElementsByTagName("input");
	var intCheckCount=0;
	for(var i=0;i<elements.length;i++)
	{
		var e=elements[i];
		if(e.type=="checkbox"&&e.checked)
		{
			intCheckCount++;
		}
	}
	return intCheckCount;
}

//checkboxȫѡ
function SelectAllCheckboxes(spanChk){

   // Added as ASPX uses SPAN for checkbox
   var oItem = spanChk.children;
   var theBox= (spanChk.type=="checkbox") ? 
        spanChk : spanChk.children.item[0];
   xState=theBox.checked;
   elm=theBox.form.elements;

   for(i=0;i<elm.length;i++)
     if(elm[i].type=="checkbox" && 
              elm[i].id!=theBox.id)
     {
       //elm[i].click();
       if(elm[i].checked!=xState)
         elm[i].click();
       //elm[i].checked=xState;
     }
 }

function WinFullOpen(url){
	var newwin=window.open("","","scrollbars");
	if(document.all){
		newwin.moveTo(0,0);
		newwin.resizeTo(screen.width,screen.height);
	}
	newwin.location=url;
}