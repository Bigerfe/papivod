<%@ Page Language="C#" AutoEventWireup="true" Inherits="Easo.Web.DBMS.Link.articleadmin_link_Default"
    Codebehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�޸���������</title>
    <link href="../style/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="tj">
                <tr>
                    <th>
                        �������ӹ���
                    </th>
                </tr>
                <tr>
                    <td align="center" style="height: 37px">
                        �����Ʋ�ѯ��<asp:TextBox ID="txtname" runat="server" MaxLength="20" Width="181px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="center" style="height: 37px">
                        ѡ�������������<asp:DropDownList ID="DropDownList1" runat="server" Width="103px">
                            <asp:ListItem Value="1"  Selected="True">�������֣���</asp:ListItem>
                            <asp:ListItem Value="0">����ͼƬ����</asp:ListItem>
                        </asp:DropDownList>&nbsp;&nbsp;&nbsp; ѡ����Ŀ��<asp:DropDownList ID="ddllocationtype"
                            runat="server" DataTextField="TypeName" DataValueField="SetNum">
                        </asp:DropDownList>
                        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;�������ͣ�<asp:DropDownList ID="dropsort" runat="server">
                          
                            <asp:ListItem Value="ID">ʱ��</asp:ListItem>
                            <asp:ListItem Value="sort">���</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp; &nbsp;
                        <asp:Button ID="btnsear" runat="server" OnClick="btnsear_Click" Text="����" />&nbsp;
                        &nbsp; &nbsp; <a href="add.aspx">�����������</a>
                    </td>
                </tr>
                <tr>
                    <td class="gridrow">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None"
                            Width="100%">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="ѡ��">
                                    <HeaderTemplate>
                                        <div>
                                            ѡ��</div>
                                        <input type="checkbox" onclick="call(this,'che');" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" name="che" value='<%# Eval("ID") %>' />
                                    </ItemTemplate>
                                    <ItemStyle Width="80px" />
                                </asp:TemplateField> 
                                <asp:BoundField DataField="Name" HeaderText="����">
                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="ͼƬ">
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl='<%# Eval("Pic") %>'
                                            Width="139px" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="130px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="URL��ַ">
                                 
                                    <ItemTemplate>
                                        <a href='<%#Eval("url") %>' target="_blank">
                                            <%# Eval("URL") %>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Sort" HeaderText="����" >
                                    <ItemStyle Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="addtime" HeaderText="ʱ��">
                                    <ItemStyle Width="120px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="�༭">
                                  
                                    <ItemTemplate>
                                        <a href="update.aspx?linkid=<%#Eval("id") %>">�༭</a>
                                    </ItemTemplate>
                                    <ItemStyle Width="60px" />
                                </asp:TemplateField>
                                
                            </Columns>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EmptyDataTemplate>
                                <div style="text-align: center">
                                    ����Ϊ��!</div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="height: 27px">
                        <asp:DropDownList ID="ddlCaozuo" runat="server">
                            <asp:ListItem Value=" ">ѡ�����</asp:ListItem>
                            <asp:ListItem Value="del">ɾ��</asp:ListItem>
                            
                        </asp:DropDownList>
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btn" runat="server" OnClick="btn_Click" OnClientClick='return confirm("��ȷʵҪִ����")'
                            Text=" ִ�� " /></td>
                </tr>
                <tr>
                    <td style="padding-bottom: 12px; padding-top: 12px; height: 52px;">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%CurrentPageIndex%ҳ����%PageCount%ҳ��ÿҳ%PageSize%��"
                            FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" OnPageChanged="AspNetPager1_PageChanged1"
                            PrevPageText="��һҳ" ShowCustomInfoSection="Left" PageIndexBoxType="DropDownList"
                            ShowBoxThreshold="5" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="ҳ"
                            TextBeforePageIndexBox="ת��" PageSize="20">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
