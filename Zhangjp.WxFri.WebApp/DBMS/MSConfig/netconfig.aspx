<%@ Page Language="C#" AutoEventWireup="true" Codebehind="netconfig.aspx.cs" Inherits="Web.DBMS.MSConfig.netconfig" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站信息配置</title>
    <link href="../style/admin.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .over{
        background-color:#ddd;
    }
    .left{
    background-color:#fff;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tj">
            <tr>
                <th colspan="3">
                    网 站 信 息 配 置</th>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';" style="display:none">
                <td align="right" width="20%" style="height: 38px">
                    缓存清理：</td>
                <td style="height: 38px">
                    <asp:Button ID="Button19" runat="server" OnClick="Button19_Click" Text="清空网站所有缓存" />（请慎用此操作！）</td>
                <td width="15%" style="height: 38px">
                </td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';"  style="display:none">
                <td align="right" width="20%" style="height: 36px">
                    网站网址：</td>
                <td style="height: 36px">
                    <asp:TextBox ID="txtUrl" runat="server" Width="332px" MaxLength="200"></asp:TextBox>
                    请设置此项</td>
                <td width="15%" style="height: 36px">
                    <asp:Button ID="Button20" runat="server" OnClick="Button20_Click" Text="更新" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';"  style="display:none">
                <td align="right" width="20%" style="height: 39px">
                    网站状态：</td>
                <td style="height: 39px">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="rad" Text="开" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="rad" Text="关" /></td>
                <td width="15%" style="height: 39px">
                    <asp:Button ID="Button11" runat="server" Text="更新" OnClick="Button11_Click" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';">
                <td align="right" width="20%" style="height: 38px">
                    网站名称：</td>
                <td style="height: 38px">
                    <asp:TextBox ID="txtNetName" runat="server" Width="300px"></asp:TextBox></td>
                <td width="15%" style="height: 38px">
                    <asp:Button ID="Button1" runat="server" Text="更新" OnClick="Button1_Click" /></td>
            </tr>
            <tr style="display: none;" >
                <td align="right" width="20%" style="height: 43px">
                    网站LOGO：</td>
                <td style="height: 43px">
                    <asp:Image ID="ImageLogo" runat="server" />
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="263px" /></td>
                <td width="15%" style="height: 43px">
                    <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="更新" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';"  style="display:none">
                <td align="right" width="20%" style="height: 41px">
                    公司名称：</td>
                <td style="height: 41px">
                    <asp:TextBox ID="txtCompany" runat="server" Width="300px"></asp:TextBox></td>
                <td width="15%" style="height: 41px">
                    <asp:Button ID="Button2" runat="server" Text="更新" OnClick="Button2_Click" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';"  style="display:none">
                <td align="right" width="20%" style="height: 43px">
                    公司电话：</td>
                <td style="height: 43px">
                    <asp:TextBox ID="txtTel" runat="server"></asp:TextBox></td>
                <td width="15%" style="height: 43px">
                    <asp:Button ID="Button3" runat="server" Text="更新" OnClick="Button3_Click" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';"  style="display:none">
                <td align="right" width="20%" style="height: 44px">
                    公司 Email：</td>
                <td style="height: 44px">
                    <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox></td>
                <td width="15%" style="height: 44px">
                    <asp:Button ID="Button4" runat="server" Text="更新" OnClick="Button4_Click" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';">
                <td align="right" width="20%" style="height: 147px">
                    (关键字)Keywords值：</td>
                <td style="height: 147px">
                    <asp:TextBox ID="txtKeywords" runat="server" Height="92px" TextMode="MultiLine" Width="520px"></asp:TextBox><br />
                    (用，号 或者 | 分割多个关键词，关键词个数最好不要多余3个)</td>
                <td width="15%" style="height: 147px">
                    <asp:Button ID="Button6" runat="server" Text="更新" OnClick="Button6_Click" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';">
                <td align="right" width="20%" style="height: 149px">
                    (描述)Description值：</td>
                <td style="height: 149px">
                    <asp:TextBox ID="txtDescription" runat="server" Height="92px" TextMode="MultiLine"
                        Width="520px"></asp:TextBox><br />
                    (最好写成一句通顺的话，并包含1-2个关键字。不要多余200个汉字.标点符号包括在内.)</td>
                <td width="15%" style="height: 149px">
                    <asp:Button ID="Button7" runat="server" Text="更新" OnClick="Button7_Click" /></td>
            </tr>
            <tr>
                <td align="right" width="20%" style="height: 79px">
                    版权及公司备案信息：
                </td>
                <td style="height: 79px">
                    
                     <FCKeditorV2:FCKeditor ID="txticp" runat="server" Height="280px" ToolbarSet="Normal">
                    </FCKeditorV2:FCKeditor>
                    </td>
                <td width="15%" style="height: 79px">
                    <asp:Button ID="Button5" runat="server" Text="更新" OnClick="Button5_Click" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';"  style="display:none">
                <td align="right" width="20%" style="height: 138px">
                    不良信息过滤：</td>
                <td style="height: 138px">
                    <asp:TextBox ID="txtBword" runat="server" Height="92px" TextMode="MultiLine" Width="520px"></asp:TextBox><br />
                    (用|线分割字符串)</td>
                <td width="15%" style="height: 138px">
                    <asp:Button ID="Button8" runat="server" Text="更新" OnClick="Button8_Click" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';"  style="display:none">
                <td align="right" width="20%" style="height: 120px">
                    联系我们</td>
                <td style="height: 120px">
                    <asp:TextBox ID="txtLXWM" runat="server" Height="92px" TextMode="MultiLine" Width="520px"></asp:TextBox></td>
                <td width="15%" style="height: 120px">
                    <asp:Button ID="Button16" runat="server" OnClick="Button16_Click" Text="更新" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';"  style="display:none">
                <td align="right" style="height: 122px" width="20%">
                    个人注册协议：</td>
                <td style="height: 122px">
                    <asp:TextBox ID="txtGrxieyi" runat="server" Height="92px" TextMode="MultiLine" Width="520px"></asp:TextBox></td>
                <td style="height: 122px" width="15%">
                    <asp:Button ID="Button17" runat="server" OnClick="gerxie" Text="更新" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';"  style="display:none">
                <td align="right" style="height: 122px" width="20%">
                    网站关闭提信息：</td>
                <td style="height: 122px">
                    <asp:TextBox ID="txtcloseinfo" runat="server" Height="92px" TextMode="MultiLine"
                        Width="520px"></asp:TextBox></td>
                <td style="height: 122px" width="15%">
                    <asp:Button ID="Button9" runat="server" OnClick="closeclick" Text="更新" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';"  style="display:none">
                <td align="right" width="20%">
                    留言内容显示：</td>
                <td>
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="rep" Text="审核通过显示" />
                    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="rep" Text="关闭留言内容显示" /></td>
                <td width="15%">
                    <asp:Button ID="Button10" runat="server" Text="更新" OnClick="Button10_Click" /></td>
            </tr>
            <tr onmouseover="this.className='over';" onmouseout="this.className='left';"  style="display:none">
                <td align="right" width="20%" style="height: 27px">
                    是否显示IP地址：</td>
                <td style="height: 27px">
                    <asp:RadioButton ID="RadioButton5" runat="server" GroupName="ip" Text="显示" />
                    <asp:RadioButton ID="RadioButton6" runat="server" GroupName="ip" Text="不显示" /></td>
                <td width="15%" style="height: 27px">
                    <asp:Button ID="Button13" runat="server" Text="更新" OnClick="Button13_Click" /></td>
            </tr>
            <tr onmouseout="this.className='left';" onmouseover="this.className='over';"  style="display:none">
                <td align="right" style="height: 27px" width="20%">
                </td>
                <td style="height: 27px">
                    &nbsp;<asp:Button ID="Button14" runat="server" OnClick="Button66_Click" Text="全部生成静态页面" />
                    &nbsp; &nbsp;
                    <asp:Button ID="Button15" runat="server" OnClick="Button77_Click" Text="生成首页静态" /></td>
                <td style="height: 27px" width="15%">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
