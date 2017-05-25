

///产生卡号 
function bringCards(money,stime,etime,count)
{
    	var url = "/cmdpage.aspx";
		var pars ="action=bringcards&money="+money+"&stime="+stime+"&etime="+etime+"&count="+count;		
		var myAjax = new Ajax.Request(url, {method: "post", parameters: pars, onComplete: function (req) { bringCards_CallBack(req); } });

}


///处理返回值

function bringCards_CallBack(req)
{
    var rev = eval("obj="+req.responseText);
    

    
    alert("批量生成卡号完毕! 成功数"+obj.success+"   "+"失败数"+obj.fail+"       ");  
    
     
   var btn = $('btnrequest');
           
   btn.disabled=false;
   btn.value="开始生成.......";  
}



///产生代金券卡号 
function bringGiftCards(money,count,stime,etime,rid)
{
    	var url = "/cmdpage.aspx";
		var pars ="action=bringgiftcards&money="+money+"&count="+count+"&stime="+stime+"&etime="+etime+"&rid="+rid;
		
		 
		var myAjax = new Ajax.Request(url, {method: "post", parameters: pars, onComplete: function (req) { bringCards_CallBack(req); } }); 
}





///发送城市请求
function GetCityList(proid,selectcityid,hcityid)
{
    	var url = "/cmdpage.aspx";
		var pars ="action=getcity&proid="+proid;
		
		var myAjax = new Ajax.Request(url, {method: "post", parameters: pars, onComplete: function (req) { bringCityList_CallBack(req,selectcityid,hcityid); } });
 
}


///处理城市列表  请求 对象，select城市id，隐藏的input的城市id 供修改时候 选择的参数
function bringCityList_CallBack(req,selectcityid,hcityid)
{  
    
    var rev = req.responseText;  
//    
//    if(rev=="")
//    {
//        select.options.length=0;
//        select.options.add(new Option("请选择城市",""));
//        return false;
//    }
    var select = document.getElementById(selectcityid);
   
    select.options.length=0;
   
    select.options.add(new Option("请选择城市","")); 
    
    if(select)
    {    
        var arr = rev.split(",");
        
        if(arr.length>0)
        {
            for(var i=0;i<arr.length;i++)
            { 
                var option = new Option(arr[i].split("|")[1],arr[i].split("|")[0]);
                select.options.add(option);
            }
        } 
        if(hcityid &&  $(hcityid).value !="")
         $(selectcityid).value = $(hcityid).value;        
    }      
  
}

//选定城市
function selectItem(selectinputid,selectvalue)
{
    var obj = document.getElementById(selectinputid);
    alert(obj.length);
    if(obj)    
    {
        for(var i=0;i<obj.length;i++)        
        {           
            obj.options[i].value = selectvalue;
            obj.options[i].selected=true;
            break;
        }
    }
    
    
} 
 
 

///发送分店请求  1 2  
function GetBranchServerList(serverid,selectfd)
{ 
    
    	var url = "/cmdpage.aspx";
		var pars ="action=getbranchserver&serverid="+serverid;
		
		var myAjax = new Ajax.Request(url, {method: "post", parameters: pars, onComplete: function (req) { bringBranchServerList_CallBack(req,selectfd); } });

}


///处理返回的分店列表
function bringBranchServerList_CallBack(req,selectfd)
{     
    
    var rev = req.responseText;     
 
    var select = document.getElementById(selectfd);
   
    select.options.length=0;
   
    select.options.add(new Option("请选择分店",""));   
    
    
    if(select)
    {    
        var arr = rev.split(",");
        
        if(arr.length>0)
        {
            for(var i=0;i<arr.length;i++)
            { 
                var option = new Option(arr[i].split("|")[1],arr[i].split("|")[0]);
                select.options.add(option);
            }
        }        
       
    } 
    
  
}



///发送配送方式请求
function GetSendTypeList(serverid,selectfd)
{  
    if(serverid =="")
    {
          var select = document.getElementById(selectfd);
          select.options.length=0;   
          select.options.add(new Option("请选择配送方式",""));   
          return false;    
    }    
    	var url = "/cmdpage.aspx";
		var pars ="action=getsendtypelist&locationid="+serverid;
		
		var myAjax = new Ajax.Request(url, {method: "post", parameters: pars, onComplete: function (req) { brigSendTypeList_CallBack(req,selectfd); } });
}


///处理返回的配送方式
function brigSendTypeList_CallBack(req,selectfd)
{     
    
    var rev = req.responseText;     
 
    var select = document.getElementById(selectfd);
   
    select.options.length=0;
   
    select.options.add(new Option("请选择配送方式",""));   
    
    
    if(select)
    {    
        var arr = rev.split(",");
        
        if(arr.length>0)
        {
            for(var i=0;i<arr.length;i++)
            { 
                var option = new Option(arr[i].split("|")[1],arr[i].split("|")[0]);
                select.options.add(option);
            }
        }        
        
    }      
}