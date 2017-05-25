<%@ Page ContentType="text/html" Language="C#" Inherits="SpbDev.DotNetInfo.Index" %>

<%@ Register TagPrefix="spbdev" Namespace="SpbDev.DotNetInfo" Assembly="SpbDev.DotNetInfo" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
     <title>系统属性</title>
</head>
<body> 
    <table width="760" border="1" align="center" cellspacing="0" class="tj" >
        <tr>
        <th>
        服务器信息
        </th>
        </tr>
        <tr>
            <td align="center">
                
                <table width="95%" align="center" class="tj" style="margin-top:12px;">
                  
                    <tr>
                        <td colspan="2" class="TrHead">
                            服务器基本信息</td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            服务器计算机名</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerName" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            服务器IP地址</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerIP" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            服务器域名</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerDomain" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            服务器端口</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerPort" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            服务器IIS版本</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerIIS" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            执行文件绝对路径</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerFilePath" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            站点虚拟目录绝对路径</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerPhyAppPath" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            站点虚拟目录名称</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerAppPath" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            服务器操作系统</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerOS" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            服务器操作系统安装目录</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerRoot" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            服务器应用程序安装目录</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerProgramRoot" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            .NET Framework语言种类</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerDotNetLang" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            .NET Framework 版本</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerDotNetVer" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            服务器当前时间</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerNowDate" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            服务器上次启动到现在已运行</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerLastStartToNow" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                </table>
                <br>
                <table width="95%" align="center"  class="tj">
                   
                    <tr>
                        <td colspan="2" class="TrHead">
                            服务器相关硬件信息</td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            逻辑驱动器</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerLogicalDriver" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            物理内存总数</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerMemSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td height="26">
                            可用物理内存</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerMemFreeSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td height="26">
                            正使用的内存</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerMemUseSize" AllowHtml="false" runat="server" />
                            %</td>
                    </tr>
                    <tr>
                        <td height="26">
                            交换文件大小</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerExFileSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td height="26">
                            交换文件可用大小</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerExFileFreeSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td height="26">
                            总虚拟内存</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerExMemSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td height="26">
                            剩余虚拟内存</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerExMemFreeSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            CPU 数目</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerCpuCount" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            CPU 标识</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerCpuIdent" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            CPU 类型</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerCpuType" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            CPU 等级</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerCpuGrade" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            CPU OEM ID</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerCpuOemID" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            CPU 页面大小</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerPageSize" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                </table>
                <br>
                <table width="95%" align="center" border="1"   class="tj" cellspacing="0">
                
                    <tr>
                        <td colspan="2" class="TrHead">
                            服务器COM组件安装检测</td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            数据库访问组件(Adodb.Recordset)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComAdodb" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            JRO数据库压缩组件(JRO.JetEngine)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComJro" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            FSO文件操作组件(Scripting.FileSystemObject)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComFso" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            CDONTS邮件发送组件(CDONTS.NewMail)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComCdonts" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            JMail邮件组件(Jmail.Message)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComJMail" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            Persits文件上传组件(Persits.Upload.1)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComPersitsUp" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            SoftArtisans文件上传组件(SoftArtisans.FileUp)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComSAUp" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            Dundas文件上传组件(Dundas.Upload)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComDundasUp" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            其它COM组件检测</td>
                        <td width="492">
                            <form method="post">
                                <input type="text" name="ComProgID" value="<%=ProgID%>" class="InputTxt">&nbsp;&nbsp;<input
                                    type="submit" value="检测" class="Button">&nbsp;<font color="#FF3333"><spbdev:SpbLabel
                                        ID="ServerComCheckRslt" AllowHtml="false" Visible="false" runat="server" />
                                    </font>
                            </form>
                        </td>
                    </tr>
                </table>
                <br>
                <table width="95%" align="center"  class="tj">
                    <tr>
                        <td colspan="2" class="TrHead">
                            服务器运算性能检测</td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            2000万次整数运算性能</td>
                        <td width="492">
                            <form method="post">
                                <input type="hidden" name="IntCalCheck" value="2000"><input type="submit" value="检测"
                                    class="Button">&nbsp;&nbsp;<font color="#FF3333"><spbdev:SpbLabel ID="ServerIntCalCheck"
                                        AllowHtml="false" Visible="false" runat="server" />
                                    </font>
                            </form>
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            500万次浮点运算性能</td>
                        <td width="492">
                            <form method="post">
                                <input type="hidden" name="DblCalCheck" value="500"><input type="submit" value="检测"
                                    class="Button">&nbsp;&nbsp;<font color="#FF3333"><spbdev:SpbLabel ID="ServerDblCalCheck"
                                        AllowHtml="false" Visible="false" runat="server" />
                                    </font>
                            </form>
                        </td>
                    </tr>
                </table>
                <table border="0" width="95%" class="tj" style="margin-top:12px; margin-bottom:12px;">
                    <tr>
                        <td align="center" style="height: 30px">
                           &nbsp;&nbsp;&nbsp;执行时间：<%=ProcessTime%>
                            毫秒</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>
