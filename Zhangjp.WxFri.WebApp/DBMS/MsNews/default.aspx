<%@ Page Language="C#" AutoEventWireup="true" Codebehind="default.aspx.cs" Inherits="Easo.Web.DBMS.MsNews._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新闻列表</title>
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="tj">
            <tr>
                <th align="center" colspan="2" style="width: 15%; height: 28px;">
                    新闻列表</th>
            </tr>
            <tr>
                <td align="left" class=" " colspan="2" style="height: 30px">
                    &nbsp;查询&nbsp; &nbsp;&nbsp; 当前栏目：<asp:DropDownList ID="dropmenu" runat="server" DataTextField="Cname"
                        DataValueField="ID">
                    </asp:DropDownList>&nbsp; &nbsp;标题：<asp:TextBox ID="txtitle" runat="server" MaxLength="30"
                        Width="230px"></asp:TextBox>&nbsp; <span style="display: none;">是否置顶：<asp:DropDownList
                            ID="dropiftop" runat="server">
                            <asp:ListItem Value="-1">全部</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:DropDownList>
                        </span>&nbsp; 是否推荐首页：<asp:DropDownList ID="dropifcomomend" runat="server">
                            <asp:ListItem Value="-1">全部</asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnsear" runat="server" OnClick="btnsear_Click" Text="查 询" Width="65px" />
                    &nbsp;&nbsp; &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClientClick="window.location.href='addnews.aspx?action=add'; return false;"
                        Text="发布信息" /></td>
            </tr>
            <tr>
                <td align="left" class=" " colspan="2" style="height: 30px">
                    ×设为推荐的公司新闻会在网站首页滚动区域显示！</td>
            </tr>
            <tr>
                <td align="center" class="gridrow" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input type="checkbox" onclick="call(this,'che')" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" name="che" value="<%#Eval("id") %>" />
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="标题">
                                <ItemTemplate>
                                    <a href="/news<%#Eval("id") %>.aspx" target="_blank" title="点击链接，查看内容.">
                                        <%#Eval("title") %>
                                    </a>
                                </ItemTemplate>
                                <ItemStyle Width="450px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="classname" HeaderText="所属类别">
                                <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Label" HeaderText="标签" Visible="False" />
                            <asp:TemplateField HeaderText="置顶" Visible="False">
                                <ItemTemplate>
                                    <%# Eval("IfTop").ToString()=="1"?"是":"否" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TopOrderNum" HeaderText="置顶排序" Visible="False" />
                            <asp:TemplateField HeaderText="推荐">
                                <ItemTemplate>
                                    <%# Eval("IfRecommend").ToString()=="1"?"<font color=red>是</font>":"否" %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="推荐排序">
                                <ItemTemplate>
                                    <input type="text" style="display: none" id="txtid" runat="server" value='<%#Eval("id") %>' />
                                    <input type="text" id="txtorder" runat="server" value='<%#Eval("RecommendOrderNum") %>'
                                        maxlength="7" style="width: 50px;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="addtime" HeaderText="发布日期">
                                <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="修改">
                                <ItemTemplate>
                                    <a href="Addnews.aspx?action=update&nid=<%#Eval("id") %>">修改</a>
                                </ItemTemplate>
                                <ItemStyle Width="120px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left" class=" " colspan="2">
                    <asp:Button ID="btndelete" runat="server" OnClientClick="return confirm('确认删除吗?');"
                        Text="删除选择信息" OnClick="btndelete_Click" />
                    &nbsp; &nbsp;&nbsp;
                    <asp:Button ID="btnsetop" runat="server" Text="设为置顶" OnClick="btnsetop_Click" Visible="False" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnsetnotop" runat="server" Text="取消置顶" OnClick="btnsetnotop_Click" Visible="False" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnsetcommend" runat="server" Text="设为推荐" OnClick="btnsetcommend_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnnocommend" runat="server" Text="取消推荐" OnClick="btnnocommend_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnpx" runat="server" OnClick="btnpx_Click" Text="批量更新排序" /></td>
            </tr>
            <tr>
                <td align="center" class=" " colspan="2">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged1"
                        PageIndexBoxType="DropDownList" PageSize="15" PrevPageText="上一页" ShowBoxThreshold="5"
                        ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go"
                        TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
            <tr>
                <td align="center" class=" " colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript" src="../js/newobjectjs.js"></script>

<script type="text/javascript">
GridViewColor('GridView1','#fff','#f0f0f0','#ccc',''); 
</script>

