<%@ Page Language="C#" AutoEventWireup="true" Inherits="Easo.Web.DBMS.Link.articleadmin_link_udpate" Codebehind="update.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>友情链接修改</title>
    <link href="../style/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table class="tj" style="height: 167px">
            <tr>
                <th colspan=2>
                    友情链接修改
                </th>
            </tr>
        <tr>
            <td align="right" >
                所在位置：</td>
            <td>
                <asp:DropDownList ID="ddllocationtype" runat="server" DataTextField="typename" DataValueField="setnum">
                   
                </asp:DropDownList></td>
        </tr>
            <tr>
                <td  align="right">
            标题： 
                    
                </td>
                <td>
            <asp:TextBox ID="title" runat="server" Width="201px"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="title"
                        Display="Dynamic" ErrorMessage="请输入标题!" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
        <tr>
            <td align="right">
            连接地址：</td>
            <td>
                <asp:TextBox ID="url" runat="server" Width="301px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
            连接类型：</td>
            <td>
                <asp:DropDownList ID="drtype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drtype_SelectedIndexChanged"
                Width="72px">
                <asp:ListItem Text="文字" Value="1"></asp:ListItem>
                <asp:ListItem Text="图片" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <asp:FileUpload ID="file1" runat="server" />
            <asp:Label ID="h1" runat="server"></asp:Label></td>
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
                <asp:TextBox ID="txtSort" runat="server" MaxLength="5" Width="49px"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" BorderStyle="None" ControlToValidate="txtSort"
                    ErrorMessage="请输入整数" MaximumValue="99999" MinimumValue="-99999" Type="Integer"></asp:RangeValidator></td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 24px">
            <asp:Button ID="add" runat="server" OnClick="add_Click" Text="修改" Width="71px" /></td>
        </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
