<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ms.aspx.cs" Inherits="Easo.DBMS.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��վ��̨����</title>
    <link href="style/login_page.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function login()
        {
            if(document.getElementById("txtUser").value=="")
            {
                alert("����Ա�ʺŲ���Ϊ�գ�");
                document.getElementById("txtUser").focus();
                return false;
            }
           else if(document.getElementById("txtPwd").value=="")
            {
                alert("����Ա���벻��Ϊ�գ�");
                document.getElementById("txtPwd").focus();
                return false;
            }
           else if(document.getElementById("txtCode").value=="")
            {
                alert("��֤�벻��Ϊ�գ�");
                document.getElementById("txtCode").focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table align="center" border="0">
            <tr>
                <td style="width: 3px">
                    <div id="bgimg">
                        <div id="idname">
                            <span>�˺ţ�</span></div>
                        <div id="idname1">
                            <asp:TextBox ID="txtUser" runat="server" Width="150px" MaxLength="20"></asp:TextBox>
                        </div>
                        <div id="idpsw">
                            <span>���룺</span></div>
                        <div id="idpsw1">
                            <asp:TextBox ID="txtPwd" runat="server" Width="150px" TextMode="Password" MaxLength="20"></asp:TextBox>
                        </div>
                        <div id="idyz">
                            <span>��֤�룺</span></div>
                        <div id="idyz1">
                            <asp:TextBox ID="txtCode" runat="server" Width="60px" MaxLength="4"></asp:TextBox>
                        </div>
                        <div id="idyz2">
                            <img src="../PrintImage/default.aspx" style="border: 0;" alt="ͼƬ��֤��" /></div>
                        <div id="iddl">
                            <asp:ImageButton ID="ImageButton1" ImageUrl="imgs/GLLogin.gif" runat="server" Width="50"
                                Height="50" OnClientClick="return login();" OnClick="ImageButton1_Click"></asp:ImageButton>
                        </div>
                        <div id="idcopy" style="text-align: left;">
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; font-size: 12px; color: #666; height: 23px; line-height: 23px;">
                    �Ѻ���ʾ������ IE6 ���� IE7 ��ʹ�ô˺�̨! ��Ļ�ֱ��� 1024*768 Ϊ�������!&nbsp; <a href='http://www.bjfar.com'
                        target="_blank" style="color: #666; text-decoration: none;">��վ��������Ŷ�</a></td>
            </tr>
        </table>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    document.getElementById("txtUser").focus();
</script>

