function checknotice()
{  
    txtitle=document.getElementById("txtTitle1");
    starttime=document.getElementById("txtstarttime");
    endtime=document.getElementById("txtendtime");
    
    if(txtitle.value=="" )
    {
        alert("标题不能为空！");
        txtitle.focus();
        return false;
    }
    if(starttime.value=="" )
    {
        alert("开始日期不能为空！");
        starttime.focus();
        return false;
    }
    if(endtime.value =="" )
    {
        alert("结束日期不能为空！");
        endtime.focus();
        return false;
    }
    if(endtime.value < starttime.value )
    {
        alert("结束日期要比开始日期迟！");
        endtime.focus();
        return false;
    }
    return true;
}

function checknotice2()
{  
    txtitle=document.getElementById("txtTitle2");
    starttime=document.getElementById("txtstarttime2");
    endtime=document.getElementById("txtendtime2");
    
    if(txtitle.value=="" )
    {
        alert("标题不能为空！");
        txtitle.focus();
        return false;
    }
    if(starttime.value=="" )
    {
        alert("开始日期不能为空！");
        starttime.focus();
        return false;
    }
    if(endtime.value =="" )
    {
        alert("结束日期不能为空！");
        endtime.focus();
        return false;
    }
    if(endtime.value < starttime.value )
    {
        alert("结束日期要比开始日期迟！");
        endtime.focus();
        return false;
    }
    return true;
}
