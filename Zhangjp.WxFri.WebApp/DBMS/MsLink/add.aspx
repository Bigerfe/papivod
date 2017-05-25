<%@ Page Language="C#" AutoEventWireup="true" Inherits="Easo.Web.DBMS.Link.articleadmin_link_add"
    Codebehind="add.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加有情连接</title>
    <link href="../style/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="tj" width="100%">
                <tr>
                    <th class="tj" colspan="2">
                        添加友情链接
                    </th>
                </tr>
                <tr>
                    <td align="right" style="width: 264px">
                        栏目：</td>
                    <td>
                        <asp:DropDownList ID="ddllocationtype" runat="server" DataTextField="typename" DataValueField="setnum"> 
                          
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 264px" align="right">
                        标题：
                    </td>
                    <td>
                        <asp:TextBox ID="title" runat="server" Width="299px"></asp:TextBox>&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="title"
                            Display="Dynamic" ErrorMessage="请输入标题!" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 264px" align="right">
                        连接地址：
                    </td>
                    <td>
                        <asp:TextBox ID="url" runat="server" Width="301px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="url"
                            ErrorMessage="url地址输入错误！" ValidationExpression="[a-zA-z]+://[^\s]*" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="url"
                            Display="Dynamic" ErrorMessage="请输入连接地址"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" style="width: 264px">
                        链接类型：</td>
                    <td>
                        <asp:DropDownList ID="drtype" runat="server" Width="72px" AutoPostBack="True" OnSelectedIndexChanged="drtype_SelectedIndexChanged">
                            <asp:ListItem Value="1" Text="文字"></asp:ListItem>
                            <asp:ListItem Value="0" Text="图片"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right" style="width: 264px">
                        简介：</td>
                    <td>
                        <asp:TextBox ID="txtdes" runat="server" Height="106px" TextMode="MultiLine" Width="303px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 264px">
                        排序：</td>
                    <td>
                        <asp:TextBox ID="txtSort" runat="server" MaxLength="5" Width="65px">1000</asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtSort"
                            ErrorMessage="请输入数字" MaximumValue="99999" MinimumValue="-9999" Type="Integer"></asp:RangeValidator></td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="height: 51px">
                        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" Width="57px" /></td>
                </tr>
            </table>
            <br />
            <br />
            &nbsp;</div>
    </form>
</body>
</html>
