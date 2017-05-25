<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sNewsClass.aspx.cs" Inherits="Easo.Web.DBMS.MsNews.sNewsClass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>类别管理</title>
    <link href="../../DBMS/style/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      <table class="tj">
            <tr>
                <th align="center" colspan="2" style="width: 15%">
                    类别管理</th>
            </tr>
            <tr>
                <td align="center" class="gridrow" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Width="80%">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="KEY" />
                            <asp:BoundField DataField="CName" HeaderText="名称" />
                            <asp:BoundField DataField="Description" HeaderText="描述" />
                            <asp:BoundField DataField="OrderNum" HeaderText="排序设置" />
                            <asp:BoundField DataField="addtime" HeaderText="添加时间" />
                            <asp:TemplateField>                                 
                                <ItemTemplate>
                                   <a href="sNewsClass.aspx?cid=<%#Eval("id") %>&action=delete&typeid=<%=typeid %>" onclick="return confirm('确实删除所选择的数据吗? 其所包含的信息信息也会同时删除..');">删除</a>  <a href="sNewsClass.aspx?action=update&cid=<%#Eval("id") %>&typeid=<%=typeid %>">修改</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                     <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条"
                                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged1"
                                PageIndexBoxType="DropDownList" PageSize="50" PrevPageText="上一页" ShowBoxThreshold="5"
                                ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go"
                                TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                            </webdiyer:AspNetPager>
                </td>
            </tr>
          <tr>
              <td align="right" style="width: 35%; height: 26px">
                  <asp:Label ID="lamsg" runat="server" Text="添加数据" Font-Bold="True" Font-Italic="False"></asp:Label></td>
              <td colspan="1" style="height: 26px">
              </td>
          </tr>
        <tr>
            <td align="right" style="width: 35%; height: 26px;">
                名称：</td>
            <td colspan="1" style="height: 26px">
                <asp:TextBox ID="txtname" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入名称." ControlToValidate="txtname" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                排序：</td>
            <td colspan="1" style="height: 19px">
                <asp:TextBox ID="txtsort" runat="server" MaxLength="10">100</asp:TextBox></td>
        </tr>
          <tr>
              <td align="right" style="width: 15%">
                  描述：</td>
              <td colspan="1" style="height: 19px">
                  <asp:TextBox ID="txtdes" runat="server" MaxLength="80" Width="304px"></asp:TextBox></td>
          </tr>
          <tr>
              <td align="right" style="width: 15%">
              </td>
              <td colspan="1" style="height: 19px">
                  <asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click" Text="添加" />
                  &nbsp;&nbsp;
                  <asp:Button ID="btncancle" runat="server" OnClick="btncancle_Click" Text="取消更改" Visible="False" /></td>
          </tr>
            
            </table>
    </form>
</body>
</html>
