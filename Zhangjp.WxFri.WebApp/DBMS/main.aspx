<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Easo.DBMS.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>欢迎页面</title>
    <link href="style/admin.css" type="text/css" rel="stylesheet"/>
    <!--不能脱离框架结构的判断 -->
	<script language="javascript" type="text/javascript">
    if(self==top){self.location.href="Index.aspx";}
	</script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="textbgset"><br />
				<br />
				<div style="TEXT-ALIGN: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
				<div style="TEXT-ALIGN: center">尊敬的网站管理员：<font color="red"><%=DoClass.GetAdminUserName()%></font>
					,&nbsp;您好！&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
				<div style="TEXT-ALIGN: center">请从左侧导航栏选择进入相应的管理界面。&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    <br />
                    <br />
                    </div>
				<br />
			</div>
    </form>
</body>
</html>
