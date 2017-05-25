<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Addnews.aspx.cs" Inherits=" Easo.Web.DBMS.AboutUs.Addnews" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                        分类：</td>
                    <td colspan="1" style="height: 19px">      
                            <asp:DropDownList ID="dropmenu" runat="server" DataTextField="Cname" DataValueField="ID">
                        </asp:DropDownList>           
                      
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dropmenu"
                            Display="Dynamic" ErrorMessage="请选择类别！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        设置类别：</td>
                    <td colspan="1" style="height: 19px">
                    
                           <asp:DropDownList ID="drop_dyguojia" runat="server" DataTextField="Cname" DataValueField="ID">
                        </asp:DropDownList>
                          <asp:DropDownList ID="drop_dytype" runat="server" DataTextField="Cname" DataValueField="ID">
                        </asp:DropDownList>
                          <asp:DropDownList ID="drop_dyyear" runat="server" DataTextField="Cname" DataValueField="ID">
                        </asp:DropDownList>

                        |||||    <asp:DropDownList ID="drop_dsjguojia" runat="server" DataTextField="Cname" DataValueField="ID">
                        </asp:DropDownList>
                         <asp:DropDownList ID="drop_dsjtype" runat="server" DataTextField="Cname" DataValueField="ID">
                        </asp:DropDownList>
                     
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dropmenu"
                            Display="Dynamic" ErrorMessage="请选择类别！" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
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
                    <td align="right" style="height: 29px;">
                        是否置顶：</td>
                    <td colspan="1" style="height: 29px; ">
                        <asp:RadioButtonList ID="raiftop" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:RadioButtonList>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 29px;">
                        置顶排序数字：</td>
                    <td colspan="1" style="height: 29px;">
                        <asp:TextBox ID="txtopnumber" runat="server" MaxLength="10">100</asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        文章描述：</td>
                    <td colspan="1" style="height: 19px">
                        <asp:TextBox ID="txtdes" runat="server" dataType="Limit" Height="126px" max="50"
                            MaxLength="1800" msg="请输入标题!" require="true" TextMode="MultiLine" Width="453px"></asp:TextBox>
                        200字内为佳!<br />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        是否推荐：</td>
                    <td colspan="1" style="height: 19px">
                        <asp:RadioButtonList ID="raifcommend" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:RadioButtonList>&nbsp; 如果选择推荐的话，这条信息将替换现有首页显示的信息。</td>
                </tr>
                <tr>
                    <td align="right">
                        推荐排序数字：</td>
                    <td colspan="1">
                        <asp:TextBox ID="txtcommendnumber" runat="server" MaxLength="7">100</asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        来源：</td>
                    <td colspan="1" style="height: 19px">
                        <asp:TextBox ID="txt_Source" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">
                        标签：</td>
                    <td colspan="1">
                        <asp:TextBox ID="txtlabel" runat="server" MaxLength="100" Width="343px"></asp:TextBox></td>
                </tr>
                <tr  id="tr_down" style=" background-color:#f0f0f0;">
                    <td align="right" style="width: 15%">
                        上传图片：</td>
                    <td colspan="1" style="line-height: 23px; height: 19px">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="406px" />&nbsp;<br />
                        只能上传<span style="color: #ff0033">jpg，gif，png的图片</span>文件.
                        文件最大不能超过100KB； &nbsp; 如果您的页面需要上传请上传！
                        <asp:Label ID="lafile" runat="server"></asp:Label>
                        <br />
                        <br />
                        或者输入图片地址：<asp:TextBox ID="txtpicurl" runat="server" Width="382px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td align="right" style="width: 15%">
                        虚拟浏览次数：</td>
                    <td colspan="1" style="height: 19px">
                        <input id="txtviewcount"  runat="server" maxlength="20" type="text"  />
                      
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        电影评分：</td>
                    <td colspan="1" style="height: 19px">
                        <input id="txtcommentcount"  runat="server" maxlength="20" type="text"  />
                        </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        上线日期：</td>
                    <td colspan="1" style="height: 19px">
                        <input id="txtaddtime" onclick="WdatePicker()" runat="server" maxlength="20" type="text" readonly="readonly" />
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
                        <CKEditor:CKEditorControl ID="txtContent" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                    </td>
                    <td colspan="1" style="height: 19px">
                        <asp:Button ID="add_update" runat="server" OnClick="add_update_Click" Text="添加" Width="157px" Height="50px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html><script language="javascript" type="text/javascript" src="/scripts/My97DatePicker/WdatePicker.js"></script>

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

//setdownfile(document.getElementById("dropmenu"));
</script>

