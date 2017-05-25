<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Add.aspx.cs" Inherits="Eakia.Web.MS.JsTurnPIc.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加轮换图片 修改轮换图片</title>
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
 </head>
<body>
    <form id="form1" runat="server">
        <table class="tj">
            <tr>
                <th align="center" colspan="2">
                    &nbsp;<asp:Label ID="msgtitle" runat="server" Text=""></asp:Label>
                    首页轮换图片</th>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                    信息名称：</td>
                <td colspan="1" style="height: 19px">
                    <asp:TextBox ID="txttitle" runat="server" dataType="Limit" max="50" msg="请输入标题!" require="true"
                        MaxLength="200" Width="425px"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttitle"
                        ErrorMessage="请输入！" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                    图片：</td>
                <td colspan="1" style="height: 19px">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    &nbsp;
                    <asp:Label ID="lapic1" runat="server"></asp:Label>&nbsp; 图片大小最好不要超过300kb, 尺寸：275×186；</td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                    连接地址：</td>
                <td colspan="1" style="height: 19px">
                    <asp:TextBox ID="txthttp" runat="server" Width="270px" CausesValidation="True">#</asp:TextBox>
                    没有跳转地址 可以 填写 #.</td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; height: 26px">
                    排序：</td>
                <td colspan="1" style="height: 26px">
                    <asp:TextBox ID="txtordernum" runat="server" MaxLength="7" Width="45px">100</asp:TextBox>
                    &nbsp;
                    默认值为0.&nbsp; 控制前台的显示顺序 。升序显示.</td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; height: 41px">
                </td>
                <td colspan="1" style="height: 41px">
                    <asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click" Text="添加" Width="57px" />
                    &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClientClick="window.location.href=''; return false;"
                        Text="返回图片列表" /></td>
            </tr>
            <tr>
            </tr>
        </table>
    </form>
</body>
</html>
