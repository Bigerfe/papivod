function checknotice()
{  
    txtitle=document.getElementById("txtTitle1");
    starttime=document.getElementById("txtstarttime");
    endtime=document.getElementById("txtendtime");
    
    if(txtitle.value=="" )
    {
        alert("���ⲻ��Ϊ�գ�");
        txtitle.focus();
        return false;
    }
    if(starttime.value=="" )
    {
        alert("��ʼ���ڲ���Ϊ�գ�");
        starttime.focus();
        return false;
    }
    if(endtime.value =="" )
    {
        alert("�������ڲ���Ϊ�գ�");
        endtime.focus();
        return false;
    }
    if(endtime.value < starttime.value )
    {
        alert("��������Ҫ�ȿ�ʼ���ڳ٣�");
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
        alert("���ⲻ��Ϊ�գ�");
        txtitle.focus();
        return false;
    }
    if(starttime.value=="" )
    {
        alert("��ʼ���ڲ���Ϊ�գ�");
        starttime.focus();
        return false;
    }
    if(endtime.value =="" )
    {
        alert("�������ڲ���Ϊ�գ�");
        endtime.focus();
        return false;
    }
    if(endtime.value < starttime.value )
    {
        alert("��������Ҫ�ȿ�ʼ���ڳ٣�");
        endtime.focus();
        return false;
    }
    return true;
}
