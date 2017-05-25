//批量执行里执行下面的方法
function Exec()
{
	if(getCheckedCount()=="0")
	{
		alert("请选择您要执行的操作的记录！");
		return false;
	}
	var dwl=document.getElementById("dwlstate").value;//获取操作类型的值
	var ok=confirm("确定执行操作吗?")
	if(!ok)
	{
		return false;
	}
	else
	{
		return true;
	}
}
//判断CheckBox是否被选中
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

//checkbox全选
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