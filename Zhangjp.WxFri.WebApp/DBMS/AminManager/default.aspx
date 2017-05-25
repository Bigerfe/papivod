<%@ Page Language="C#" AutoEventWireup="true" Codebehind="default.aspx.cs" Inherits="Easo.Web.DBMS.AminManager.defaultl" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员管理</title>
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tj">
            <tr>
                <th align="center">
                    后台管理员管理</th>
            </tr>
            <tr>
                <td align="left" style="height: 45px">
                    &nbsp;管理姓名：<asp:TextBox ID="txtuname" runat="server" MaxLength="20" Width="77px"></asp:TextBox>
                    &nbsp;&nbsp; &nbsp; &nbsp;管理员账号：<asp:TextBox ID="txtuesrid" runat="server" MaxLength="20"
                        Width="65px"></asp:TextBox>&nbsp; 
                </td>
            </tr>
            <tr>
                <td align="left" style="height: 45px">
                    搜索 &nbsp;是否冻结：<asp:DropDownList ID="dropdongjie" runat="server">
                            <asp:ListItem Value="">全部</asp:ListItem>
                            <asp:ListItem Value="1">冻结</asp:ListItem>
                            <asp:ListItem Value="0">未冻结</asp:ListItem>
                        </asp:DropDownList>
                  <span style="display:none">
                  &nbsp; &nbsp; &nbsp; 是否最高权限：<asp:DropDownList ID="dropistoppermissions" runat="server">
                        <asp:ListItem Value=" ">请选择</asp:ListItem>
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:DropDownList>
                  </span>  
                    &nbsp;&nbsp;
                    <asp:Button ID="btnsear" runat="server" Text="查询" OnClick="btnsear_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="添加用户" /></td>
            </tr>
            <tr>
                <td align="center" class="gridrow">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Width="100%" OnRowEditing="GridView1_RowEditing">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="che" onclick="call(this,'che');" title="全选/反选" type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input id="che" class="checkche" value='<%#Eval("iManagerId") %>' name="che" type="checkbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="iManagerId" HeaderText="序号">
                                <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="账号">
                                <ItemTemplate>
                                    <a style="color: red;" title="编辑信息" href="update.aspx?id=<%#Eval("iManagerId") %>">
                                        <%# Eval("sManager")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="sManagerName" HeaderText="姓名" />
                            <asp:BoundField DataField="sCertName" HeaderText="证件名称" />
                            <asp:BoundField DataField="sCertId" HeaderText="证件号码" />
                            <asp:BoundField DataField="sMail" HeaderText="邮编" />
                            <asp:BoundField DataField="sTel" HeaderText="联系电话" />
                            <asp:BoundField DataField="dtLogin" HeaderText="创建时间" />
                            <asp:BoundField DataField="sLogin" HeaderText="创建人" />
                            <asp:BoundField DataField="dtUpd" HeaderText="更新时间" />
                            <asp:BoundField DataField="supd" HeaderText="更新人" />
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
                        <asp:ListItem Value="dongjie">冻结帐户</asp:ListItem>
                        <asp:ListItem Value="nodongjie">取消冻结</asp:ListItem>
                        <asp:ListItem Value="delete">删除所选项 </asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" OnClientClick="return confirm('确认执行操作吗？');"
                        Text="执行操作" OnClick="Button1_Click" /></td>
            </tr>
            <tr>
                <td align="center">
                    <br />
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged1"
                        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowDisabledButtons="False" PageSize="13">
                    </webdiyer:AspNetPager>
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
