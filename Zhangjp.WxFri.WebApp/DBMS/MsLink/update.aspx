<%@ Page Language="C#" AutoEventWireup="true" Inherits="Easo.Web.DBMS.Link.articleadmin_link_udpate" Codebehind="update.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>���������޸�</title>
    <link href="../style/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table class="tj" style="height: 167px">
            <tr>
                <th colspan=2>
                    ���������޸�
                </th>
            </tr>
        <tr>
            <td align="right" >
                ����λ�ã�</td>
            <td>
                <asp:DropDownList ID="ddllocationtype" runat="server" DataTextField="typename" DataValueField="setnum">
                   
                </asp:DropDownList></td>
        </tr>
            <tr>
                <td  align="right">
            ���⣺ 
                    
                </td>
                <td>
            <asp:TextBox ID="title" runat="server" Width="201px"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="title"
                        Display="Dynamic" ErrorMessage="���������!" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
        <tr>
            <td align="right">
            ���ӵ�ַ��</td>
            <td>
                <asp:TextBox ID="url" runat="server" Width="301px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
            �������ͣ�</td>
            <td>
                <asp:DropDownList ID="drtype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drtype_SelectedIndexChanged"
                Width="72px">
                <asp:ListItem Text="����" Value="1"></asp:ListItem>
                <asp:ListItem Text="ͼƬ" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <asp:FileUpload ID="file1" runat="server" />
            <asp:Label ID="h1" runat="server"></asp:Label></td>
        </tr>
        
         <tr>
            <td align="right" style="width: 264px">
                ��飺</td>
            <td>
                <asp:TextBox ID="txtdes" runat="server" Height="106px" TextMode="MultiLine" Width="303px"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 264px">
                ����</td>
            <td>
                <asp:TextBox ID="txtSort" runat="server" MaxLength="5" Width="49px"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" BorderStyle="None" ControlToValidate="txtSort"
                    ErrorMessage="����������" MaximumValue="99999" MinimumValue="-99999" Type="Integer"></asp:RangeValidator></td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 24px">
            <asp:Button ID="add" runat="server" OnClick="add_Click" Text="�޸�" Width="71px" /></td>
        </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
