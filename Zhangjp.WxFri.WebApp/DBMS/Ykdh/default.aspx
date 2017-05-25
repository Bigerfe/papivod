<%@ Page Language="C#" AutoEventWireup="true" Codebehind="default.aspx.cs" Inherits="Easo.Web.DBMS.Ykdh._default" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>预科导航</title>
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
                    预科导航信息设置</th> 
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';">
                <td colspan="3" style="height: 38px">
                    <ul>
                     <li><a href="default.aspx?id=200">课程介绍 </a> </li>  
                        <li><a href="default.aspx?id=201">课程优势 </a> </li>
                        <li><a href="default.aspx?id=202">课程设置 </a></li>
                         <li><a href="default.aspx?id=203">报考指南</a></li>
                          <li><a href="default.aspx?id=204">报考方式</a></li> <li><a href="default.aspx?id=205">招生简章</a></li>
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
                    <asp:Button ID="btn" runat="server" OnClick="btn_Click" Text="提交信息" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
