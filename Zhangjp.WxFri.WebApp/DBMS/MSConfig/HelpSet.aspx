<%@ Page Language="C#" AutoEventWireup="true" Codebehind="HelpSet.aspx.cs" Inherits="Easo.Web.DBMS.MSConfig.HelpSet" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>帮助信息设置</title>
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    ul {
    float:left;
    }
    ul li{
    float:left;
    width:80px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tj">
            <tr>
                <th colspan="3">
                    单&nbsp; 页&nbsp; 信 息 设 置</th> 
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';">
                <td colspan="3" style="height: 38px">
                    <ul>
                     <li><a href="helpset.aspx?id=101">关于我们</a> </li>  
                        <li><a href="helpset.aspx?id=100">联系我们</a> </li> 
                           <li><a href="helpset.aspx?id=300">加盟合作</a> </li> 
                             <li><a href="helpset.aspx?id=301">英才招聘</a> </li> 
                              <li><a href="helpset.aspx?id=302">法律声明</a> </li> 
                     </ul>
                </td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';">
                <td align="center" style="height: 36px" colspan="3">
                    <asp:Label ID="laname" runat="server" style="font-size:120%; "></asp:Label></td>
            </tr>
            <tr onmouseout="this.className='left';" onmouseover="this.className='over';">
                <td align="center" colspan="3" style="height: 36px">
                
                   <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Height="400px" ToolbarSet="Normal">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
            <tr onmouseout="this.className='left';" onmouseover="this.className='over';">
                <td align="center" colspan="3" style="height: 36px">
                    <asp:Button ID="btn" runat="server" OnClick="btn_Click" Text="提交信息" /> </td>
            </tr>
        </table>
    </form>
</body>
</html>
