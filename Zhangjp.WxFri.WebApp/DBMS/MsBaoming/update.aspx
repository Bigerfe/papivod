<%@ Page Language="C#" AutoEventWireup="true" Codebehind="update.aspx.cs" Inherits=" Easo.Web.DBMS.MsBaoming.Addnews" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�鿴��ϸ�ı�����Ϣ</title>
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
    .tj tr td{  height:30px; line-height:30px; padding-right:5px;}
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <table style="border-collapse: collapse;" cellpadding="0" cellspacing="0" class="tj">
            <tr>
                <th align="center" colspan="2" style="height: 28px">
                    
                    �鿴������Ϣ����/�޸�</th>
            </tr>
            <tr>
                <td align="right" class="lefttd">
                    ¼ȡ״̬</td>
                <td class="righttd">
                    <asp:RadioButtonList ID="rapass" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0">δ¼ȡ</asp:ListItem>
                        <asp:ListItem Value="1">��¼ȡ</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="right" class="lefttd">
                    ¼ȡ��ע</td>
                <td class="righttd">
                    <asp:TextBox ID="txtpassremark" runat="server" Height="44px" TextMode="MultiLine" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    ��ѧ��һ־Ը
                </td>
                <td class="righttd">
                    <asp:DropDownList ID="dr_z1" runat="server" DataTextField="cname" DataValueField="id">
                    </asp:DropDownList>
                    <span>*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dr_z1"
                        Display="Dynamic" ErrorMessage="��ѡ��" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    ��ѧ�ڶ�־Ը
                </td>
                <td class="righttd">
                    <asp:DropDownList ID="dr_z2" runat="server" DataTextField="cname" DataValueField="id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    ��ʵ����
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtname" maxlength="20" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    ���֤��
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtcard" maxlength="20" runat="server" />
                    <span>*�����֤��Ϊ¼ȡ��ѯΨһ��ʶ��</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcard"
                        Display="Dynamic" ErrorMessage="�����룡" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    ѧ��
                </td>
                <td class="righttd">
                    <asp:DropDownList ID="dr_xl" runat="server" DataTextField="cname" DataValueField="id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    �Ա�
                </td>
                <td class="righttd">
                    <asp:DropDownList ID="dr_sex" runat="server">
                        <asp:ListItem Value="1">��</asp:ListItem>
                        <asp:ListItem Value="0">Ů</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    ����
                </td>
                <td class="righttd">
                    <input type="text" class="text textsmall" id="txtprovince" maxlength="20" runat="server" />
                    ʡ
                    <input type="text" class="text textsmall" id="txtcity" maxlength="20" runat="server" />
                    ��
                    <input type="text" class="text textsmall" id="txtarea" maxlength="20" runat="server" />
                    ��
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    �߿��ɼ�
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtgaokchengj" maxlength="20" runat="server" />
                    <span>*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtgaokchengj"
                        Display="Dynamic" ErrorMessage="������߿��ɼ�������" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    Ӣ��ɼ�
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtengchengj" maxlength="20" runat="server" />
                    <span>*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtengchengj"
                        Display="Dynamic" ErrorMessage="������Ӣ��ɼ�������" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    �ֻ�
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txttel" maxlength="20" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    ��ͥ��ַ
                </td>
                <td class="righttd">
                    <input type="text" class="text" style="width: 379px" id="txtaddress" maxlength="100"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    �ʱ�
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtpost" maxlength="6" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    �ռ�������
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtreceiver" maxlength="20" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    ���߷�ʽ
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtonlinetype" maxlength="20" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    E-MAIL
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtemail" maxlength="100" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    ������ע
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtremark" maxlength="500" runat="server" style="width: 568px" />
                </td>
            </tr>
            <tr>
                <td class="lefttd">
                    &nbsp;
                </td>
                <td class="righttd">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="�� ��" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" onclick="window.history.go(-1);" value="ȡ ��" />
                </td>
            </tr> <tr>
                <td class="lefttd" align="right">
                      &nbsp;
                </td>
                <td class="righttd">
                     
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript" src="../js/mcalendar.js"></script>

