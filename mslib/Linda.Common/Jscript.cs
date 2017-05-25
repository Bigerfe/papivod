using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// �����������ĵ������ڹ���
/// </summary>
public class Jscript
{
    public Jscript()
    {
        //
        // TODO: �ڴ˴����ӹ��캯���߼�
        //
    }

    /// <summary>
    /// �����ʾ��Ϣ
    /// </summary>
    /// <param name="url"></param>
    public static void WriteInfo(string str)
    {
        HttpContext.Current.Response.Write("<div style='height:100px; color:red; border:solid 1px #ccc; line-height:100px;  text-align:center; width:250px; font-size:14px; letter-spacing:2px;  margin-left:350px; margin-top:100px;;' class='infoermsg'>" + str + "���  <a style='color:green; font-size:13px;'  href=# onclick='window.history.go(-1);'>����</a></div>");
        HttpContext.Current.Response.End();
    }

    /// <summary>
    /// ��תҳ��
    /// </summary>
    /// <param name="url"></param>
    public static void RedirectTo(string url)
    {
        HttpContext.Current.Response.Write("<script>window.top.location.href='" + url + "'</script>");
    }

    /// <summary>
    /// �������˵���alert�Ի���
    /// </summary>
    /// <param name="str_Message">��ʾ��Ϣ,���ӣ�"������������!"</param>
    /// <param name="page">Page��</param>
    public static void Alert(string str_Message, Page page)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script>alert('" + str_Message + "');</script>");
    }

    /// <summary>
    /// ϵͳ�Զ�����ʾ
    /// </summary>
    public static void DamicAlert()
    {
        Jscript.AlertAndRedirectJstr("�����ʵ����ݲ�����!", "window.history.go(-1);");
    }

    /// <summary>
    /// �Լ�����ű�
    /// </summary>
    /// <param name="str_Message">��ʾ��Ϣ</param>
    /// <param name="url">�ű�����</param>
    public static void AlertAndRedirectJstr(string str_Message, string strjs)
    {
        HttpContext.Current.Response.Write("<script>alert('" + str_Message + "');" + strjs + "</script>");

    }

    /// <summary>
    /// д��ű�
    /// </summary>   
    /// <param name="url">�ű�����</param>
    public static void WriteJs(string strjs)
    {
        HttpContext.Current.Response.Write("<script>" + strjs + "</script>");

    }




    /// <summary>
    /// Ȩ����תҳ��
    /// </summary>
    /// <param name="str_Message">��ʾ��Ϣ</param>
    /// <param name="url">��תҳ��</param>
    public static void PopedomRedirect(string str_Message, string url)
    {
        HttpContext.Current.Response.Write("<script>alert('" + str_Message + "');window.top.location.href='" + url + "'</script>");
    }


    /// <summary>
    /// ����JavaScriptС����
    /// </summary>
    /// <param name="js">������Ϣ</param>
    public static void Alert(string message)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    alert('" + message + "');</Script>";
        HttpContext.Current.Response.Write(js);
        #endregion
    }

    /// <summary>
    /// ������Ϣ����ת���µ�URL
    /// </summary>
    /// <param name="message">��Ϣ����</param>
    /// <param name="toURL">���ӵ�ַ</param>
    public static void AlertAndRedirect(string message, string toURL)
    {
        #region
        string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
        HttpContext.Current.Response.Write(string.Format(js, message, toURL));
        #endregion
    }

    /// <summary>
    /// �ص���ʷҳ��
    /// </summary>
    /// <param name="value">-1/1</param>
    public static void GoHistory(int value)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    history.go({0});  
                  </Script>";
        HttpContext.Current.Response.Write(string.Format(js, value));
        #endregion
    }

    /// <summary>
    /// �رյ�ǰ����
    /// </summary>
    public static void CloseWindow()
    {
        #region
        string js = @"<Script language='JavaScript'>
                    parent.opener=null;window.close();  
                  </Script>";
        HttpContext.Current.Response.Write(js);
        HttpContext.Current.Response.End();
        #endregion
    }

    /// <summary>
    /// ˢ�¸�����
    /// </summary>
    public static void RefreshParent(string url)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    window.opener.location.href='" + url + "';window.close();</Script>";
        HttpContext.Current.Response.Write(js);
        #endregion
    }


    /// <summary>
    /// ˢ�´򿪴���
    /// </summary>
    public static void RefreshOpener()
    {
        #region
        string js = @"<Script language='JavaScript'>
                    opener.location.reload();
                  </Script>";
        HttpContext.Current.Response.Write(js);
        #endregion
    }


    /// <summary>
    /// ��ָ����С���´���
    /// </summary>
    /// <param name="url">��ַ</param>
    /// <param name="width">��</param>
    /// <param name="heigth">��</param>
    /// <param name="top">ͷλ��</param>
    /// <param name="left">��λ��</param>
    public static void OpenWebFormSize(string url, int width, int heigth, int top, int left)
    {
        #region
        string js = @"<Script language='JavaScript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";

        HttpContext.Current.Response.Write(js);
        #endregion
    }

    /// <summary>
    /// ���´���
    /// </summary>    
    public static void OpenWebFormSize(string mess, string url)
    {
        #region
        string js = @"<Script language='JavaScript'>alert('" + mess + "'); window.open('" + url + @"');</Script>";

        HttpContext.Current.Response.Write(js);
        #endregion
    }



    /// <summary>
    /// ת��Url�ƶ���ҳ��
    /// </summary>
    /// <param name="url">���ӵ�ַ</param>
    public static void JavaScriptLocationHref(string url)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
        js = string.Format(js, url);
        HttpContext.Current.Response.Write(js);
        #endregion
    }

    /// <summary>
    /// ��ָ����Сλ�õ�ģʽ�Ի���
    /// </summary>
    /// <param name="webFormUrl">���ӵ�ַ</param>
    /// <param name="width">��</param>
    /// <param name="height">��</param>
    /// <param name="top">������λ��</param>
    /// <param name="left">������λ��</param>
    public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
    {
        #region
        string features = "dialogWidth:" + width.ToString() + "px"
            + ";dialogHeight:" + height.ToString() + "px"
            + ";dialogLeft:" + left.ToString() + "px"
            + ";dialogTop:" + top.ToString() + "px"
            + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
        ShowModalDialogWindow(webFormUrl, features);
        #endregion
    }

    public static void ShowModalDialogWindow(string webFormUrl, string features)
    {
        string js = ShowModalDialogJavascript(webFormUrl, features);
        HttpContext.Current.Response.Write(js);
    }

    public static string ShowModalDialogJavascript(string webFormUrl, string features)
    {
        #region
        string js = @"<script language=javascript>							
							showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
        return js;
        #endregion
    }

}