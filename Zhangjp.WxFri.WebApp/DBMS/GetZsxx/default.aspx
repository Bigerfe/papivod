<%@ Page Language="C#" AutoEventWireup="true" Codebehind="default.aspx.cs" Inherits="Easo.Web.DBMS.GetZsxx.defaultl" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>获取招生信息</title>
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tj">
            <tr>
                <th align="center">
                    获取招生信息</th>
            </tr>
            <tr>
                <td align="left" style="height: 45px">
                    姓名：<asp:TextBox ID="txtuname" runat="server" MaxLength="20" Width="77px"></asp:TextBox>
                    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 手机：<asp:TextBox ID="txtsj" runat="server" MaxLength="20"
                        Width="165px"></asp:TextBox>&nbsp; 
                    <asp:Button ID="btnsear" runat="server" Text="查询" OnClick="btnsear_Click" /></td>
            </tr>
            <tr>
                <td align="center" class="gridrow">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" OnRowEditing="GridView1_RowEditing" HorizontalAlign="Center">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="che" onclick="call(this,'che');" title="全选/反选" type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input id="che" class="checkche" value='<%#Eval("id") %>' name="che" type="checkbox" />
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="name" HeaderText="姓名" >
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="性别">
                               
                                <ItemTemplate>
                                  <%# Eval("sex").ToString()=="1"?"男":"女" %>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="dianh" HeaderText="手机" >
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="email" HeaderText="邮箱" >
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="engscore" HeaderText="英语成绩" >
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="lxgjname" HeaderText="预留学国家" >
                                <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cityname" HeaderText="所在地" >
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="addtime" HeaderText="时间" >
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EmptyDataTemplate>
                            暂时没有数据！
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:DropDownList ID="dropcmd" runat="server">
                        <asp:ListItem Value="">选择操作</asp:ListItem>
                      
                        <asp:ListItem Value="delete">删除所选项 </asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" OnClientClick="return confirm('确认执行操作吗？');"
                        Text="执行操作" OnClick="Button1_Click" /></td>
            </tr>
            <tr>
                <td align="center">
                 
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged1"
                        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowDisabledButtons="False" PageSize="13">
                    </webdiyer:AspNetPager>
                   ;</td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript" src="../js/newobjectjs.js"></script>

<script type="text/javascript">
GridViewColor('GridView1','#fff','#f0f0f0','#ccc',''); 
</script>
