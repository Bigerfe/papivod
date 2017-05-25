<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Eakia.Web.MS.JsTurnPIc.Defaultl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>js 轮换图片管理</title>
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
 </head>
<body>
    <form id="form1" runat="server">
        <table class="tj">
            <tr>
                <th colspan="2">
                    首页轮换图片管理</th>
            </tr>
            <tr>
                <td align="left" class="gridrow" style="padding-left: 250px">
                    <asp:Button ID="Button1" runat="server" OnClientClick="window.location.href='add.aspx'; return false;"
                        Text="添加图片" />&nbsp;&nbsp; 前台最多显示6张图片。可减少图片.</td>
            </tr>
            <tr>
                <td class="gridrow" align="center">
                    <asp:GridView ID="GridList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="信息标题">
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <a title="点击---->查看并修改内容" href='Add.aspx?action=update&id=<%# Eval("ID")%>'>
                                            <%# Eval("title") %>
                                        </a>
                                    </div>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ordernum" HeaderText="排序" >
                                <ItemStyle Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="addtime" HeaderText="发布时间">
                                <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="编辑">
                                <ItemTemplate>
                                    <a  href='Add.aspx?action=update&id=<%# Eval("ID")%>'>编辑</a> <a href="?action=delete&id=<%#Eval("ID") %>" onclick="return confirm('确认删除吗 ?');">删除</a>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#F7F6F3" HorizontalAlign="Center" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EmptyDataTemplate>
                            没有数据..
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" class="gridrow">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged1"
                        PageIndexBoxType="DropDownList" PageSize="20" PrevPageText="上一页" ShowBoxThreshold="5"
                        ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go"
                        TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript" src="../js/newobjectjs.js"></script>

<script type="text/javascript">
GridViewColor('GridList','#fff','#f0f0f0','#ccc',''); 
</script>

