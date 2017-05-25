<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Addnews.aspx.cs" Inherits=" Easo.Web.DBMS.MsNews.Addnews" %>


<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加或者修改</title>
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="tj">
                <tr>
                    <th align="center" colspan="2" style="width: 15%">
                        <asp:Label ID="msgtitle" runat="server" Text=""></asp:Label></th>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        请设置新闻类别：</td>
                    <td colspan="1" style="height: 19px">
                        <asp:DropDownList ID="dropmenu" runat="server" DataTextField="Cname" DataValueField="ID" onchange="setdownfile(this);">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dropmenu"
                            Display="Dynamic" ErrorMessage="请选择新闻类别！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        新闻标题：</td>
                    <td colspan="1" style="height: 19px">
                        <asp:TextBox ID="txtitle" runat="server" dataType="Limit" max="50" msg="请输入标题!" require="true"
                            MaxLength="200" Width="448px"></asp:TextBox>&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtitle"
                            ErrorMessage="请输入！" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" style="height: 29px; display: none;">
                        是否置顶：</td>
                    <td colspan="1" style="height: 29px; display: none;">
                        <asp:RadioButtonList ID="raiftop" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:RadioButtonList>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 29px; display: none;">
                        置顶排序数字：</td>
                    <td colspan="1" style="height: 29px; display: none;">
                        <asp:TextBox ID="txtopnumber" runat="server" MaxLength="10">100</asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        是否推荐：</td>
                    <td colspan="1" style="height: 19px">
                        <asp:RadioButtonList ID="raifcommend" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:RadioButtonList>&nbsp; 如果选择推荐的话，这条信息发布后会在首页滚动区域显示。</td>
                </tr>
                <tr>
                    <td align="right" style="display: none;">
                        推荐排序数字：</td>
                    <td colspan="1" style="display: none;">
                        <asp:TextBox ID="txtcommendnumber" runat="server" MaxLength="7">100</asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        来源：</td>
                    <td colspan="1" style="height: 19px">
                        <asp:TextBox ID="txt_Source" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="display: none;">
                        标签：</td>
                    <td colspan="1" style="display: none;">
                        <asp:TextBox ID="txtlabel" runat="server" MaxLength="100" Width="343px"></asp:TextBox></td>
                </tr>
                <tr  id="tr_down" style="display:none; background-color:#f0f0f0;">
                    <td align="right" style="width: 15%">
                        上传文件：</td>
                    <td colspan="1" style="line-height: 23px; height: 19px">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="406px" />&nbsp;<br />
                        只能上传<span style="color: #ff0033">压缩包，word文档，图片文件，pdf文件</span>文件.
                        文件最大不能超过1M； &nbsp;
                        <asp:Label ID="lafile" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        添加日期：</td>
                    <td colspan="1" style="height: 19px">
                        <input id="txtaddtime" onfocus="setday(this);" runat="server" maxlength="20" type="text" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtaddtime"
                            Display="Dynamic" ErrorMessage="请输入！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                    </td>
                    <td colspan="1">
                        <span style="color: #ff0066">注意</span>：您在添加详细内容的时候，请不要直接将内容从word文档中复制过来，需要放到文本文档中保存后在复制到编辑器内，然后重新编辑格式。<br />
                        因为word中的内容和html的格式不同，会导致网页垃圾增多，文本显示错乱，不利于客户浏览。</td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        内容：</td>
                    <td colspan="1">
                         <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Height="400px" ToolbarSet="Normal">
                    </FCKeditorV2:FCKeditor>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                    </td>
                    <td colspan="1" style="height: 19px">
                        <asp:Button ID="add_update" runat="server" OnClick="add_update_Click" Text="添加" Width="57px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<script type="text/javascript" src="../js/mcalendar.js"></script>

<script type="text/javascript">
function setdownfile(obj)
{
    if(obj.value=="4" || obj.value=="3")
    {
        document.getElementById("tr_down").style.display="";
    }
    else
    document.getElementById("tr_down").style.display="none";
}

setdownfile(document.getElementById("dropmenu"));
</script>

