<%@ Page Language="C#" AutoEventWireup="true" Codebehind="msframepage.aspx.cs" Inherits="Easo.Web.DBMS.msframepage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>后台管理</title>
</head>
<frameset rows="80,*" cols="*" frameborder="NO" border="0" framespacing="0">
    <frame src="top.aspx" name="topFrame" scrolling="NO" noresize>
    <frameset cols="176,14,*" frameborder="NO" border="0" framespacing="0" id="mainFrm">
        <frame src="left.aspx" name="leftFrame" scrolling="auto" noresize>
        <frame src="hidden.htm" scrolling="NO" name="switch" noresize>
        <frame src="main.aspx" style="overflow-x: hidden; overflow-y: scroll;" scrolling="yes"
            name="main" noresize>
    </frameset>
</frameset>
<body>
</body>
</NOFRAMES>
</html>
