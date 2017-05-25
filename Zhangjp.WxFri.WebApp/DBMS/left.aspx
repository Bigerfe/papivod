<%@ Page Language="C#" AutoEventWireup="true" Codebehind="left.aspx.cs" Inherits="Easo.DBMS.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>左侧菜单</title>
    <link href="style/admin.css" type="text/css" rel="stylesheet" />

    <script src="js/menu.js" language="javascript" type="text/javascript"></script>

</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" oncontextmenu="window.event.returnValue=false"
    onselectstart="event.returnValue=false" ondragstart="window.event.returnValue=false"
    onsource="event.returnValue=false">
    <form id="form1" runat="server">
        <div style="padding-top: 6px">
            <table class="Menu" cellspacing="0" align="center">
                <tbody>
                    <tr>
                        <th onclick="javascript:void(0);" name="4" align="center" class="atitle">
                            ≡ 系统基础 ≡</th>
                    </tr>
                    <tr id="opt_4" class="option">
                        <td>
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <td>
                                            <a href="MSConfig/DotNetInfo.aspx" target="main">系统属性</a></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="Msconfig/netconfig.aspx" target="main">网站配置</a></td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            <a href="JsTurnPIc/" target="main">首页幻灯片</a></td>
                                    </tr> 
                                   
                                     <tr>
                                        <td>
                                            <a href="MSConfig/helpset.aspx?id=101" target="main">关于我们</a></td>
                                    </tr>
                                    
                                    
                                     <tr>
                                        <td>
                                            <a href="MsLink/" target="main">友情链接管理</a></td>
                                    </tr>
                                          <tr>
                                        <td>
                                            <a href="Zhiyuan/sNewsClass.aspx?typeid=10000" target="main">电影-国家</a></td>
                                    </tr>
                                        <tr>
                                        <td>
                                            <a href="Zhiyuan/sNewsClass.aspx?typeid=10001" target="main">电影-类型</a></td>
                                    </tr>  <tr>
                                         <tr>
                                        <td>
                                            <a href="Zhiyuan/sNewsClass.aspx?typeid=10002" target="main">电影-年代</a></td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <a href="Zhiyuan/sNewsClass.aspx?typeid=10020" target="main">电视剧-国家</a></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="Zhiyuan/sNewsClass.aspx?typeid=10021" target="main">电视剧-类型</a></td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <a href="Zhiyuan/sNewsClass.aspx?typeid=10050" target="main">影视剧-分类</a></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
               <table class="menu_bg" cellspacing="0" cellpadding="0" align="center" border="0" style="display:none;">
                <tbody>
                    <tr>
                        <td style="height: 2px;">
                        </td>
                    </tr>
                </tbody>
            </table>
            <table class="Menu" cellspacing="0" align="center" style="display:none;">
                <tbody>
                    <tr>
                        <th onclick="javascript:void(114);" name="365" align="center" class="atitle">
                            ≡ 院校动态 ≡</th>
                    </tr>
                    <tr id="opt_365" class="option">
                        <td>
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <td>
                                            <a href="YuanXiaoDongtai/?typeid=1" target="main">新闻列表</a></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="YuanXiaoDongtai/Addnews.aspx?action=add&typeid=1" target="main">发布新闻</a></td>
                                    </tr>
                                   
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            
               <table class="menu_bg" cellspacing="0" cellpadding="0" align="center" border="0">
                <tbody>
                    <tr>
                        <td style="height: 2px;">
                        </td>
                    </tr>
                </tbody>
            </table>
            <table class="Menu" cellspacing="0" align="center">
                <tbody>
                    <tr>
                        <th onclick="javascript:void(1141);" name="3651" align="center" class="atitle">
                            ≡ 文章管理 ≡</th>
                    </tr>
                    <tr id="opt_3651" class="option">
                        <td>
                            <table width="100%">
                                <tbody>
                                    
                                 <tr>
                                        <td>
                                            <a href="YuanXiaoDongtai/?typeid=8" target="main">影视剧管理</a> <a href="YuanXiaoDongtai/Addnews.aspx?action=add&typeid=8" target="main">发布</a></td>
                                    </tr> 
                                  
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            
           
             <table class="menu_bg" cellspacing="0" cellpadding="0" align="center" border="0" style="display:none;">
                <tbody>
                    <tr>
                        <td style="height: 2px;">
                        </td>
                    </tr>
                </tbody>
            </table>
            <table class="Menu" cellspacing="0" align="center"  style="display:none;">
                <tbody>
                    <tr>
                        <th onclick="javascript:void(1111);" name="1111" align="center" class="atitle">
                            ≡ 国外合作大学 ≡</th>
                    </tr>
                    <tr id="opt_1111" class="option">
                        <td>
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <td>
                                            <a href="HasClassNews/?typeid=4" target="main">信息列表</a></td>
                                    </tr>
                                    
                                      <tr>
                                        <td>
                                            <a href="HasClassNews/sNewsClass.aspx?typeid=4" target="main">类别管理</a></td>
                                    </tr>
                                   
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            
            
           
            
              <table class="menu_bg" cellspacing="0" cellpadding="0" align="center" border="0"  style="display:none;">
                <tbody>
                    <tr>
                        <td style="height: 2px;">
                        </td>
                    </tr>
                </tbody>
            </table>
            <table class="Menu" cellspacing="0" align="center"  style="display:none;">
                <tbody>
                    <tr>
                        <th onclick="javascript:void(111111);" name="111111" align="center" class="atitle">
                            ≡ 预科导航 ≡</th>
                    </tr>
                    <tr id="opt_111111" class="option">
                        <td>
                            <table width="100%">
                                <tbody>
                                   <tr>
                                        <td>
                                            <a href="Ykdh/" target="main">信息列表</a></td>
                                    </tr>
                                    
                                   
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table> 
         
           
            
             <table class="menu_bg" cellspacing="0" cellpadding="0" align="center" border="0" style="display:none;">
                <tbody>
                    <tr>
                        <td style="height: 2px;">
                        </td>
                    </tr>
                </tbody>
            </table>
            <table class="Menu" cellspacing="0" align="center"  style="display:none;">
                <tbody>
                    <tr>
                        <th onclick="javascript:void(111222);" name="111222" align="center" class="atitle">
                            ≡ 大学/专业排名 ≡</th>
                    </tr>
                    <tr id="opt_111222" class="option">
                        <td>
                            <table width="100%">
                                <tbody>
                                   <tr>
                                        <td>
                                            <a href="YuanXiaoDongtai/?typeid=10" target="main">大学排名</a></td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <a href="YuanXiaoDongtai/?typeid=11" target="main">专业排名</a></td>
                                    </tr>
                                 
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table> 
            
           
            <table class="menu_bg" cellspacing="0" cellpadding="0" align="center" border="0">
                <tbody>
                    <tr>
                        <td style="height: 2px; width: 11px;">
                        </td>
                    </tr>
                </tbody>
            </table>
            
            <table class="Menu" cellspacing="0" align="center">
                <tbody>
                    <tr>
                        <th onclick="javascript:void(114);" name="365aaa" align="center" class="atitle">
                            ≡ 系统用户 ≡</th>
                    </tr>
                    <tr id="opt_365aaa" class="option">
                        <td>
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <td>
                                            <a href="AminManager/" target="main">用户列表</a></td>
                                    </tr>
                                   
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
           
        </div>
    </form>
</body>
</html>
