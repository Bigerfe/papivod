<%@ Page ContentType="text/html" Language="C#" Inherits="SpbDev.DotNetInfo.Index" %>

<%@ Register TagPrefix="spbdev" Namespace="SpbDev.DotNetInfo" Assembly="SpbDev.DotNetInfo" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
     <title>ϵͳ����</title>
</head>
<body> 
    <table width="760" border="1" align="center" cellspacing="0" class="tj" >
        <tr>
        <th>
        ��������Ϣ
        </th>
        </tr>
        <tr>
            <td align="center">
                
                <table width="95%" align="center" class="tj" style="margin-top:12px;">
                  
                    <tr>
                        <td colspan="2" class="TrHead">
                            ������������Ϣ</td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            �������������</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerName" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            ������IP��ַ</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerIP" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            ����������</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerDomain" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            �������˿�</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerPort" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            ������IIS�汾</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerIIS" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            ִ���ļ�����·��</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerFilePath" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            վ������Ŀ¼����·��</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerPhyAppPath" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            վ������Ŀ¼����</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerAppPath" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            ����������ϵͳ</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerOS" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            ����������ϵͳ��װĿ¼</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerRoot" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            ������Ӧ�ó���װĿ¼</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerProgramRoot" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            .NET Framework��������</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerDotNetLang" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            .NET Framework �汾</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerDotNetVer" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            ��������ǰʱ��</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerNowDate" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            �������ϴ�����������������</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerLastStartToNow" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                </table>
                <br>
                <table width="95%" align="center"  class="tj">
                   
                    <tr>
                        <td colspan="2" class="TrHead">
                            ���������Ӳ����Ϣ</td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            �߼�������</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerLogicalDriver" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            �����ڴ�����</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerMemSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td height="26">
                            ���������ڴ�</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerMemFreeSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td height="26">
                            ��ʹ�õ��ڴ�</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerMemUseSize" AllowHtml="false" runat="server" />
                            %</td>
                    </tr>
                    <tr>
                        <td height="26">
                            �����ļ���С</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerExFileSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td height="26">
                            �����ļ����ô�С</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerExFileFreeSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td height="26">
                            �������ڴ�</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerExMemSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td height="26">
                            ʣ�������ڴ�</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerExMemFreeSize" AllowHtml="false" runat="server" />
                            MB</td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            CPU ��Ŀ</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerCpuCount" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            CPU ��ʶ</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerCpuIdent" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            CPU ����</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerCpuType" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="26">
                            CPU �ȼ�</td>
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
                            CPU ҳ���С</td>
                        <td>
                            <spbdev:SpbLabel ID="ServerPageSize" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                </table>
                <br>
                <table width="95%" align="center" border="1"   class="tj" cellspacing="0">
                
                    <tr>
                        <td colspan="2" class="TrHead">
                            ������COM�����װ���</td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            ���ݿ�������(Adodb.Recordset)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComAdodb" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            JRO���ݿ�ѹ�����(JRO.JetEngine)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComJro" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            FSO�ļ��������(Scripting.FileSystemObject)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComFso" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            CDONTS�ʼ��������(CDONTS.NewMail)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComCdonts" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            JMail�ʼ����(Jmail.Message)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComJMail" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            Persits�ļ��ϴ����(Persits.Upload.1)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComPersitsUp" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            SoftArtisans�ļ��ϴ����(SoftArtisans.FileUp)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComSAUp" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            Dundas�ļ��ϴ����(Dundas.Upload)</td>
                        <td width="492">
                            <spbdev:SpbLabel ID="ServerComDundasUp" AllowHtml="false" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            ����COM������</td>
                        <td width="492">
                            <form method="post">
                                <input type="text" name="ComProgID" value="<%=ProgID%>" class="InputTxt">&nbsp;&nbsp;<input
                                    type="submit" value="���" class="Button">&nbsp;<font color="#FF3333"><spbdev:SpbLabel
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
                            �������������ܼ��</td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            2000���������������</td>
                        <td width="492">
                            <form method="post">
                                <input type="hidden" name="IntCalCheck" value="2000"><input type="submit" value="���"
                                    class="Button">&nbsp;&nbsp;<font color="#FF3333"><spbdev:SpbLabel ID="ServerIntCalCheck"
                                        AllowHtml="false" Visible="false" runat="server" />
                                    </font>
                            </form>
                        </td>
                    </tr>
                    <tr>
                        <td width="252" height="26">
                            500��θ�����������</td>
                        <td width="492">
                            <form method="post">
                                <input type="hidden" name="DblCalCheck" value="500"><input type="submit" value="���"
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
                           &nbsp;&nbsp;&nbsp;ִ��ʱ�䣺<%=ProcessTime%>
                            ����</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>
