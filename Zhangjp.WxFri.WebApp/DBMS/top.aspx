<%@ Page Language="C#" AutoEventWireup="true" Codebehind="top.aspx.cs" Inherits="Easo.Web.DBMS.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>后台管理系统</title>
    <!--不能脱离框架结构的判断 -->
    <%--	<script language="javascript" type="text/javascript">
if(self==top){self.location.href="Index.aspx";}
	</script>--%>

    <script language="javascript" type="text/javascript">
<!--

function logout()
{
	if (confirm("确认退出系统吗？"))
	{
		window.parent.top.location.href="/sendrequest.aspx?action=htuserloout";
	}
}
function fhindex()
{
    top.location.href='/dbms/';
}
//-->
    </script>

    <script language="javascript" type="text/javascript">
<!-- Begin
var Message="后台管理系统！！！";
var place=1;
function scrollIn() {
window.status=Message.substring(0, place);
if (place >= Message.length) {
place=1;
window.setTimeout("scrollOut()",300);
} else {
place++;
window.setTimeout("scrollIn()",150);
}
}
function scrollOut() {
window.status=Message.substring(place, Message.length);
if (place >= Message.length) {
place=1;
window.setTimeout("scrollIn()", 100);
} else {
place++;
window.setTimeout("scrollOut()", 50);
}
}
// End -->
    </script>

    <link href="style/admin.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table style="height: 30px; width: 100%; border: 0;" cellspacing="0" cellpadding="3">
            <tr>
                <td style="padding-left: 10px; width: 16%; background-image: url(imgs/forum_r1_c1.gif);
                    height: 30px;">
                    <a class="blue" href="/" target="_blank">进入网站首页</a></td>
                <td style="padding-right: 5px; background-image: url(imgs/forum_r1_c1.gif); width: 55%;"
                    valign="middle" align="left">
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="3" style="height: 34px; width: 100%; border: 0;
            border-bottom: solid 1px #ccc;">
            <tr style="border-bottom: #ccc 1px solid;">
                <td class="tpl" style="padding-left: 10px; width: 30%; background-color: #ffffff;
                    height: 34px;">
                    <a class="pre" href="javascript:top.main.history.go(-1);">后退</a> <a class="ne" href="javascript:top.main.history.go(1);">
                        前进</a> <a class="flush" href="javascript:top.main.location.reload();">刷新</a>
                    <a class="logout" href="javascript:logout();">退出</a>&nbsp;&nbsp;&nbsp;<a href="javascript:fhindex();">后台首页</a></td>
                <td class="tpl" valign="middle" align="right" style="width: 49%; background-color: #ffffff;">
                    <span style="padding-right: 12px; font-size: 12px; margin-right: 20px;">
                        <!--当前角色名称-->
                        &nbsp;&nbsp;&nbsp; 当前身份:系统管理员 </span>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript">
function topage(obj)
{
    window.top.location.href=obj.name;
}   
</script>

