<%@ Page Language="C#" AutoEventWireup="true" Codebehind="update.aspx.cs" Inherits=" Easo.Web.DBMS.MsBaoming.Addnews" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看详细的报名信息</title>
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
                    
                    查看报名信息详情/修改</th>
            </tr>
            <tr>
                <td align="right" class="lefttd">
                    录取状态</td>
                <td class="righttd">
                    <asp:RadioButtonList ID="rapass" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0">未录取</asp:ListItem>
                        <asp:ListItem Value="1">已录取</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="right" class="lefttd">
                    录取备注</td>
                <td class="righttd">
                    <asp:TextBox ID="txtpassremark" runat="server" Height="44px" TextMode="MultiLine" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    留学第一志愿
                </td>
                <td class="righttd">
                    <asp:DropDownList ID="dr_z1" runat="server" DataTextField="cname" DataValueField="id">
                    </asp:DropDownList>
                    <span>*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dr_z1"
                        Display="Dynamic" ErrorMessage="请选择！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    留学第二志愿
                </td>
                <td class="righttd">
                    <asp:DropDownList ID="dr_z2" runat="server" DataTextField="cname" DataValueField="id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    真实姓名
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtname" maxlength="20" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    身份证号
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtcard" maxlength="20" runat="server" />
                    <span>*（身份证号为录取查询唯一标识）</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcard"
                        Display="Dynamic" ErrorMessage="请输入！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    学历
                </td>
                <td class="righttd">
                    <asp:DropDownList ID="dr_xl" runat="server" DataTextField="cname" DataValueField="id">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    性别
                </td>
                <td class="righttd">
                    <asp:DropDownList ID="dr_sex" runat="server">
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="0">女</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    地区
                </td>
                <td class="righttd">
                    <input type="text" class="text textsmall" id="txtprovince" maxlength="20" runat="server" />
                    省
                    <input type="text" class="text textsmall" id="txtcity" maxlength="20" runat="server" />
                    市
                    <input type="text" class="text textsmall" id="txtarea" maxlength="20" runat="server" />
                    区
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    高考成绩
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtgaokchengj" maxlength="20" runat="server" />
                    <span>*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtgaokchengj"
                        Display="Dynamic" ErrorMessage="请输入高考成绩分数！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    英语成绩
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtengchengj" maxlength="20" runat="server" />
                    <span>*</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtengchengj"
                        Display="Dynamic" ErrorMessage="请输入英语成绩分数！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    手机
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txttel" maxlength="20" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    家庭地址
                </td>
                <td class="righttd">
                    <input type="text" class="text" style="width: 379px" id="txtaddress" maxlength="100"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    邮编
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtpost" maxlength="6" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    收件人名称
                </td>
                <td class="righttd">
                    <input type="text" class="text" id="txtreceiver" maxlength="20" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="lefttd" align="right">
                    在线方式
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
                    其他备注
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
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提 交" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" onclick="window.history.go(-1);" value="取 消" />
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

