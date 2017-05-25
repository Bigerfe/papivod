<%@ Page Language="C#" AutoEventWireup="true" Codebehind="default.aspx.cs" Inherits="Easo.Web.DBMS.MsBaoming._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报名管理</title>
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="tj">
            <tr>
                <th align="center" colspan="2" style="width: 15%; height: 28px;">
                    报名管理</th>
            </tr>
            <tr>
                <td align="left" class=" " colspan="2" style="height: 30px">
                    &nbsp;查询&nbsp; &nbsp; 姓名：<asp:TextBox ID="txtitle" runat="server" MaxLength="30"
                        Width="128px"></asp:TextBox>&nbsp; &nbsp; 手机号：<asp:TextBox ID="txtmobile" runat="server"
                            MaxLength="20" Width="94px"></asp:TextBox>
                   <%-- &nbsp;&nbsp;第一志愿：<asp:DropDownList ID="dr_z1"
                            runat="server" DataTextField="cname" DataValueField="id">
                        </asp:DropDownList>
                    &nbsp; 第二志愿：<asp:DropDownList ID="dr_z2" runat="server" DataTextField="cname" DataValueField="id">
                    </asp:DropDownList>&nbsp;--%> 学校：<asp:DropDownList ID="dr_xuexiao" runat="server" DataTextField="title" DataValueField="id">
                                        </asp:DropDownList> 学历：<asp:DropDownList ID="dr_xl" runat="server" DataTextField="cname"
                        DataValueField="id">
                    </asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:Button ID="btnsear" runat="server" OnClick="btnsear_Click" Text="查 询" Width="65px" />&nbsp;</td>
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
                                    <input class="checkche" type="checkbox" name="che" value="<%#Eval("id") %>" />
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="xuexiaoname" HeaderText="学校">
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="姓名">
                                <ItemTemplate>
                                    <a href="#/news<%#Eval("id") %>.aspx" >
                                        <%#Eval("pname") %>
                                    </a>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="性别">
                                <ItemTemplate>
                                    <%# Eval("sex").ToString()=="1"?"男":"女" %>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="tel" HeaderText="电话">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="xueliname" HeaderText="学历">
                                <ItemStyle Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="card" HeaderText="身份证号" Visible="False">
                                <ItemStyle Width="140px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="firstname" HeaderText="第一志愿" Visible="False">
                                <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="secondname" HeaderText="第二志愿" Visible="False">
                                <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="addtime" HeaderText="报名日期">
                                <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="查看详细">
                                <ItemTemplate>
                                    <a href="update.aspx?action=update&nid=<%#Eval("id") %>">详细</a>
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
                        Text="删除选择信息" OnClick="btndelete_Click" />&nbsp;</td>
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

