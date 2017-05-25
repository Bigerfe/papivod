<%@ Page Language="C#" AutoEventWireup="true" Codebehind="update.aspx.cs" Inherits="Easo.Web.DBMS.AminManager.update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员信息修改</title>
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" class="tj" width="100%">
            <tr>
                <th align="center" colspan="2" style="width: 15%">
                    后台管理用户信息修改</th>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    管理员账号：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtuserid" runat="server" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuserid"
                        Display="Dynamic" ErrorMessage="请输入管理员账号！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    姓名：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtusername" runat="server" MaxLength="20"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    登陆密码：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtpwd" runat="server" MaxLength="20" TextMode="Password" Width="131px"></asp:TextBox>
                    （不修改密码，此项留空）</td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    确认密码：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtpwd1" runat="server" MaxLength="20" TextMode="Password" Width="132px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpwd1"
                        ControlToValidate="txtpwd" Display="Dynamic" ErrorMessage="密码不一致！"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    个人照片：</td>
                <td align="left" class="tdleftspace">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Label ID="laimg" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    证件名称：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtcardname" runat="server" MaxLength="20"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    证件号码：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtcardid" runat="server" MaxLength="20"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    邮编：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtpost" runat="server" MaxLength="8"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    联系地址：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtaddress" runat="server" MaxLength="50" Width="242px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    联系电话：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txttel" runat="server" MaxLength="20"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    手机：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtmobile" runat="server" MaxLength="20"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    传真：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtfax" runat="server" MaxLength="20"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    QQ：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtqq" runat="server" MaxLength="10"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    称呼：</td>
                <td align="left" class="tdleftspace">
                    <asp:RadioButtonList ID="racall" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                        Width="161px">
                        <asp:ListItem Value="1" Selected="True">先生</asp:ListItem>
                        <asp:ListItem Value="2">女士</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    职务：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtduty" runat="server" MaxLength="20" Width="136px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    是否冻结：</td>
                <td align="left" class="tdleftspace">
                    <asp:RadioButtonList ID="radongjie" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                        Width="161px">
                        <asp:ListItem Selected="True" Value="1">冻结帐户</asp:ListItem>
                        <asp:ListItem Value="0">未冻结</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr style="display: none;">
                <td align="right" class="tdleftspace" style="width: 15%">
                    是否暂时删除：</td>
                <td align="left" class="tdleftspace">
                    <asp:RadioButtonList ID="radel" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                        Width="161px">
                        <asp:ListItem Selected="True" Value="1">暂时删除</asp:ListItem>
                        <asp:ListItem Value="0">未删除</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="right" class="tdleftspace" style="width: 15%">
                    备注：</td>
                <td align="left" class="tdleftspace">
                    <asp:TextBox ID="txtremark" runat="server" Height="102px" MaxLength="300" TextMode="MultiLine"
                        Width="289px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="width: 15%;">
                    <asp:Button ID="btnmodify" runat="server" OnClick="btnmodify_Click" Text="修改" Width="59px" />&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Button1" runat="server" Text="返回" PostBackUrl="default.aspx" ValidationGroup="ff"
                        Width="67px" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
