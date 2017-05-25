using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using System.Web.SessionState;
 /// <summary>
/// 前台和后台的权限设置
/// </summary>
public class DoClass
{
    public DoClass()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 后台管理是否用cookie
    /// </summary>
    public static bool IsAdminUseeCookie = ConfigHelper.GetConfigInt("IsUserCookie") == 1 ? true : false;

    private static ArrayList Arr = new ArrayList();

    /// <summary>
    /// 返回自定义编号     
    /// </summary>
    /// <param name="num"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    private static string GetNumber(long num, int length)
    {

        StringBuilder sb = new StringBuilder();
        int count = length - num.ToString().Length;
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                sb.Append("0");
            }
        }
        return sb.ToString() + num.ToString();
    }

    /// <summary>
    /// 返回自定义编号 
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string GetNumber(long num)
    {
        return GetNumber(num, 6);
    }

    /// <summary>
    /// 判断用户是否访问过当前页面 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool InthisArray(string path)
    {
        if (Arr.Contains(path))
        {
            return true;
        }
        else
        {
            Arr.Add(path);
            return false;
        }
    }

    ///// <summary>
    ///// 将c1的项移除c2的项
    ///// </summary>
    ///// <param name="c1">第一个控件</param>
    ///// <param name="c2"></param>
    //public static void RemoveList1OfList2(Control c1, Control c2)
    //{
    //    if (c1 is ListBox)
    //    {
    //        ListBox li = (ListBox)c1;

    //        ListBox li2 = (ListBox)c2;

    //        if (li.Items.Count > 0 && li2.Items.Count > 0)
    //        {
    //            foreach (ListItem item in li2.Items)
    //            {
    //                li.Items.Remove(item);
    //            }
    //        }
    //    }
    //    if (c1 is DropDownList)
    //    {
    //        DropDownList dr = (DropDownList)c1;
    //        DropDownList dr2 = (DropDownList)c2;

    //        if (dr.Items.Count > 0 && dr2.Items.Count > 0)
    //        {
    //            foreach (ListItem item in dr2.Items)
    //            {
    //                dr.Items.Remove(item);
    //            }
    //        }
    //    }
    //}

    ///// <summary>
    ///// 将一个项从c1到c2,或者是c2到c1
    ///// </summary>
    ///// <param name="c1"></param>
    ///// <param name="c2"></param>
    ///// <param name="item"></param>
    ///// <param name="to"></param>
    //public static void RemoveTo(Control c1, Control c2, ListItem item, string to)
    //{
    //    ListBox li1 = (ListBox)c1;
    //    ListBox li2 = (ListBox)c2;
    //    if (to == "<<")
    //    {
    //        li1.Items.Add(item);
    //        li2.Items.Remove(item);
    //    }
    //    if (to == ">>")
    //    {
    //        li2.Items.Add(item);
    //        li1.Items.Remove(item);
    //    }


    //}


    #region 权限判断

    /// <summary>
    /// 判断是否已经登录,下面将验证是否具有一定的角色
    /// </summary>
    /// <param name="isparent">表示当前页面为几级页面,如果为根目录一层就为0,为根目录文件夹下面一层的为1</param>
    public static bool CheckLogin(int isparent)
    {
        string cname = ConfigHelper.GetConfigString("AdminLogin");
        Cookie c = new Cookie();
        string str = c.getCookie(cname);
        if (str == "")
        {
            string url = "login.aspx";
            switch (isparent)
            {
                case 0:
                    break;
                case 1:
                    url = "../" + url;
                    break;
                case 2:
                    url = "../../" + url;
                    break;
                case 3:
                    url = "../../../" + url;
                    break;
                case 4:
                    url = "../../../../" + url;
                    break;
                case -1:

                    break;

            }
            if (isparent == -1)
            {
                Jscript.RedirectTo(url);
                return false;
            }
            else if (isparent == -2) //判断是否通过登录验证  
            {
                return false;
            }
            else
            {
                Jscript.AlertAndRedirect("您未登录或者您的身份验证已经过期，请您重新登录或者与管理员联系!!", url);
                return false;
            }

        }
        else
            return true;
    } 
 

    /// <summary>
    /// 是否登陆后台系统系统
    /// </summary>
    /// <param name="p"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static bool AdminIsLogin(Page p, int parent)
    {
        string Uid = DoClass.GetAdminUserID();

        if (Uid == "0")
        {
            ReturnLogin(parent);
            return false;
        }
        return true;

    }


    /// <summary>
    /// 判断是否已经登录,下面将验证是否具有一定的角色
    /// </summary>
    /// <param name="isparent">表示当前页面为几级页面,如果为根目录一层就为0,为根目录文件夹下面一层的为1</param>
    public static void ReturnLogin(int isparent)
    {
        string url = "login.aspx";
        switch (isparent)
        {
            case 0:
                break;
            case 1:
                url = "../" + url;
                break;
            case 2:
                url = "../../" + url;
                break;
            case 3:
                url = "../../../" + url;
                break;
            case 4:
                url = "../../../../" + url;
                break;
        }
      //  Jscript.AlertAndRedirectJstr("您访问的页面不存在...", "window.top.location.href='"+url+"'");

        Jscript.WriteInfo("The system info that this page is not founded. please return ....");
    }

    #endregion

    #region 上传文件封装函数

    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="File1">对象</param>
    /// <param name="fileSize">大小</param>
    /// <param name="Extensioin">扩展名</param>
    /// <param name="savepath">保存位置</param>
    /// <returns>Return -1="文件类型错误" 0=“文件太大”else=“ok”</returns>
    public static string UploadFile(HtmlInputFile File1, int fileSize, string Extensioin, string savepath)
    {

        FileUpload1 up = new FileUpload1();
        up.PostedFile = File1.PostedFile;
        up.Extension = Extensioin;
        up.SavePath = HttpContext.Current.Server.MapPath(savepath);
        up.FileLength = fileSize;
        string s = up.Upload();
        return s;

    }


    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="File1">对象</param>
    /// <param name="fileSize">大小</param>
    /// <param name="Extensioin">扩展名</param>
    /// <param name="savepath">保存位置</param>
    /// <returns>Return -1="文件类型错误" 0=“文件太大”else=“ok”</returns>
    public static string UploadFile(HttpPostedFile postFile1, int fileSize, string Extensioin, string savepath)
    {
        if (postFile1.FileName == null || postFile1.FileName == "")
            return "";

        FileUpload1 up = new FileUpload1();
        up.PostedFile = postFile1;
        up.Extension = Extensioin;
        up.SavePath = HttpContext.Current.Server.MapPath(savepath);
        up.FileLength = fileSize;
        string s = up.Upload();
        return s;

    }


    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="File1">对象</param>
    /// <param name="fileSize">大小</param>
    /// <param name="Extensioin">扩展名</param>
    /// <param name="savepath">保存位置</param>
    /// <returns>Return -1="文件类型错误" 0=“文件太大”else=“ok”</returns>
    public static string UploadFile(HttpPostedFile postFile1, int fileSize, string Extensioin, string savepath, string filename)
    {

        if (postFile1.FileName == null || postFile1.FileName == "")
            return "";


        FileUpload1 up = new FileUpload1();
        up.PostedFile = postFile1;
        up.Extension = Extensioin;
        up.SavePath = HttpContext.Current.Server.MapPath(savepath);
        up.FileLength = fileSize;
        up.SetFileName = filename;
        string s = up.Upload();
        return s;

    }

    #endregion

    /// <summary>
    /// 后台用户退出登陆
    /// </summary>
    public static void AdminLoginOut()
    {
        if (IsAdminUseeCookie)
        {
            Cookie c = new Cookie();
            c.delCookie(ConfigHelper.GetConfigString("AdminLogin"));
            c.delCookie(ConfigHelper.GetConfigString("AdminName"));
        }
        else
        {
            SessionLogginOut();
        }

        Jscript.RedirectTo("/");

    }


    /// <summary>
    /// 管理员登录后台 并设置后台参数
    /// </summary>
    /// <param name="uid">用户的自增id 主键 int类型</param>
    /// <param name="username">管理员的用户名</param>
    public static void AdminLogin(string uid, string username)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("AdminLogin"), uid, 0);
        c.setCookie(ConfigHelper.GetConfigString("AdminName"), username, 0);
    }


    /// <summary>
    /// 用户退出 登陆
    /// </summary>
    public static void UserLoginOut()
    {
        Cookie c = new Cookie();
        c.delCookie(ConfigHelper.GetConfigString("UserID"));
        c.delCookie(ConfigHelper.GetConfigString("UserName"));
        c.delCookie(ConfigHelper.GetConfigString("UserLoginType"));
        c.delCookie(ConfigHelper.GetConfigString("UserLoginState"));  
    }

    /// <summary>
    /// 判断用户是否登录
    /// </summary>
    public static string CheckUserLogin(string msg)
    {
        Cookie c = new Cookie();
        if (c.getCookie(ConfigHelper.GetConfigString("UserName")) == "")
        {
            if (msg == "")
            {
                Jscript.AlertAndRedirectJstr("您还没有登录！", "window.top.location.href=''");
                return "";
            }
            else
            {
                Jscript.AlertAndRedirectJstr(msg, "window.top.location.href=''");
                return "";
            }

        }
        else
        {
            return c.getCookie(ConfigHelper.GetConfigString("UserName"));
        }
    }


    /// <summary>
    /// 判断用户是否登录
    /// </summary>
    public static string CheckUserLogin(string msg, string url)
    {
        Cookie c = new Cookie();
        if (c.getCookie(ConfigHelper.GetConfigString("UserName")) == "")
        {
            if (msg == "")
            {
                HttpContext.Current.Response.Redirect(url, true);

                return "";
            }
            else
            {
                Jscript.AlertAndRedirectJstr(msg, url);
                return "";
            }

        }
        else
        {
            return c.getCookie(ConfigHelper.GetConfigString("UserName"));
        }
    }



    /// <summary>
    /// 获得用户名 
    /// </summary>
    /// <returns></returns>
    public static string GetUserName()
    {
        Cookie c = new Cookie();
        return c.getCookie(ConfigHelper.GetConfigString("UserName"));
    }

    /// <summary>
    /// 获得服务商0采购商1
    /// </summary>
    /// <returns></returns>
    public static string GetServerType()
    {
        Cookie c = new Cookie();
        return c.getCookie(ConfigHelper.GetConfigString("ServerType"));
    }


    /// <summary>
    /// 获得管理员的用户id
    /// </summary>
    /// <returns></returns>
    public static string GetAdminUserID()
    {
         string s="";
         if (IsAdminUseeCookie)
         {
             Cookie c = new Cookie();
             s = c.getCookie(ConfigHelper.GetConfigString("AdminLogin"));
         }
         else
         {
             s = SessionGetAdminID().ToString();
         }

        if (s == "")
            return "0";
        return s;
    }

    /// <summary>
    /// 返回管理员id
    /// </summary>
    /// <returns></returns>
    public static int GetAdminUserIDInt()
    {
        string s = "";
        if (IsAdminUseeCookie)
        {
            Cookie c = new Cookie();
            s = c.getCookie(ConfigHelper.GetConfigString("AdminLogin"));
        }
        else
        {
             s = SessionGetAdminID().ToString();
        }
        return Utils.StrToInt(s); 
    }

    /// <summary>
    /// 获得管理员的用户名称
    /// </summary>
    /// <returns></returns>
    public static string GetAdminUserName()
    {
        Cookie c = new Cookie();
        return c.getCookie(ConfigHelper.GetConfigString("AdminName"));
    }

    /// <summary>
    /// 获得用户ID  int类型的值
    /// </summary>
    /// <returns></returns>
    public static string GetUserID()
    {
        Cookie c = new Cookie();
        string s = c.getCookie(ConfigHelper.GetConfigString("UserID"));
        if (s == "")
            return "0";
        return s;
    }


    /// <summary>
    /// 获得用户权限ID
    /// </summary>
    /// <returns></returns>
    public static string GetUserTypeID()
    {
        Cookie c = new Cookie();
        return c.getCookie(ConfigHelper.GetConfigString("UserTypeID"));
    }
    /// <summary>
    /// 退出登录  
    /// </summary>
    public static void RemoveUserCookie()
    {
        Cookie c = new Cookie();
        c.delCookie(ConfigHelper.GetConfigString("UserName"));
        c.delCookie(ConfigHelper.GetConfigString("UserID"));
    }


    #region   
 
    /// <summary>
    /// 设置用户ID  int类型的值
    /// </summary>
    /// <param name="uid"></param>
    public static void SetUserID(string uid)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("UserID"), uid, 0);
    }


    /// <summary>
    /// 设置用户ID  int类型的值
    /// </summary>
    /// <param name="uid"></param>
    public static void SetUserID(string uid,int day)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("UserID"), uid, day);
    }
    
    
    /// <summary>
    /// 设置用户名 唯一的用户名称
    /// </summary>
    /// <param name="username"></param>
    public static void SetUserName(string username)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("UserName"), username, 0);
    }


    /// <summary>
    /// 设置用户名 唯一的用户名称
    /// </summary>
    /// <param name="username"></param>
    public static void SetUserName(string username,int day)
    {
        Cookie c = new Cookie();
        c.setCookie(ConfigHelper.GetConfigString("UserName"), username, day);
    }
 
    #endregion 

    /// <summary>
    /// 绑定年     
    /// </summary>
    /// <param name="start">开始时间</param>
    /// <param name="end">结束日期</param>
    public static void BindDate(int start, int end, Control c)
    {
        if (c is DropDownList)
        {
            DropDownList drli = (DropDownList)c;

            for (int i = start; i <= end; i++)
            {
                drli.Items.Add(i + "");
            }
            drli.Items.Insert(0, new ListItem("年", "-1"));
        }
    }



    /// <summary>
    /// 分割字符串     
    /// </summary>
    public static string[] SplitString(string strContent, string strSplit)
    {
        if (strContent.IndexOf(strSplit) < 0)
        {
            string[] tmp = { strContent };
            return tmp;
        }
        return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
    }


    /// <summary>
    /// 进行指定的替换(脏字过滤)
    /// </summary>
    public static string StrFilter(string str, string zangzi)
    {
        string bantext = zangzi;
        string text1 = "";
        string text2 = "";
        string[] textArray1 = SplitString(bantext, "\r\n");
        for (int num1 = 0; num1 < textArray1.Length; num1++)
        {
            text1 = textArray1[num1].Substring(0, textArray1[num1].IndexOf("="));
            text2 = textArray1[num1].Substring(textArray1[num1].IndexOf("=") + 1);
            str = str.Replace(text1, text2);
        }
        return str;
    } 

    /// <summary>
    /// 返回按照时间组合的数据
    /// </summary>
    /// <returns></returns>
    public static string GetRandNum()
    {
        System.Threading.Thread.Sleep(5);
       
        string str = DateTime.Now.ToString("yyMMddHHmmssfffff")+GetRandom(3);

        System.Threading.Thread.Sleep(5);

        return str;
    }

 

    #region 设置服务验证吗

    /// <summary>
    /// 设置服务验证吗
    /// </summary>
    /// <param name="storeid"></param>
    public static void SetCodeSn(string sn)
    {
        Cookie c = new Cookie();
        c.setCookie("LoginCode", sn, 0);
    }

    /// <summary>
    /// 获取服务验证吗
    /// </summary>
    /// <param name="storeid"></param>
    public static string GetCodeSn()
    {
        Cookie c = new Cookie();
        return c.getCookie("LoginCode");
    }

    #endregion


    #region 数据库操作

     
    /// <summary>
    /// 返回随机数 
    /// </summary>
    /// <returns></returns>
    public static string GetRandom(int len)
    {
        Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
        //int[] arrNum = new int[10];
        string intr = "";
        int tmp = 0;
        int minValue = 1;
        int maxValue = 10;
        for (int i = 0; i < len; i++)
        {
            tmp = ra.Next(minValue, maxValue); //随机取数
            // arrNum[i] = getNum(arrNum, tmp, minValue, maxValue, ra); //取出值赋到数组中
            intr += tmp;
        }

        return intr;
    } 

    /// <summary>
    /// /设置管理员登陆的信息
    /// </summary>
    /// <param name="username"></param>
    /// <param name="adminid"></param>
    public static void SetAdminLoginCookie(string username, string adminid)
    {
        if (IsAdminUseeCookie)
        {
            Cookie c = new Cookie();
            c.setCookie(ConfigHelper.GetConfigString("AdminLogin"), adminid, 0);//记录管理员ID
            c.setCookie(ConfigHelper.GetConfigString("AdminName"), username, 0);
        }
        else
        { 
            //使用session
            SessionSetAdminID(adminid, username); 
        } 
    } 

    #endregion 

    #region 管理员的登录设置成session


   static  string sessionid = ConfigHelper.GetConfigString("AdminLogin");
   static  string sessionname = ConfigHelper.GetConfigString("AdminName");

    /// <summary>
    /// 设置管理员的登录
    /// </summary>
    /// <param name="adminid"></param>
    public static void SessionSetAdminID(string adminid,string adminusername)
    {
        HttpContext.Current.Session[sessionid] = adminid;
        HttpContext.Current.Session[sessionname] = adminusername;
    }

    /// <summary>
    /// 获取管理员的用户id
    /// </summary>
    /// <returns></returns>
    public static int SessionGetAdminID()
    {
        try
        {
            if (HttpContext.Current.Session[sessionid] != null)
                return Utils.StrToInt(HttpContext.Current.Session[sessionid].ToString());
            return 0;
        }
        catch 
        {
           
            return 0;
        }
       
    }

    /// <summary>
    /// 返回当前管理员的用户名
    /// </summary>
    /// <returns></returns>
    public static string SessionGetAdminUserName()
    {
        try
        {
            if (HttpContext.Current.Session[sessionname] != null)
                return HttpContext.Current.Session[sessionname].ToString();
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }


    /// <summary>
    /// 退出管理员登陆session
    /// </summary>
    /// <param name="adminid"></param>
    public static void SessionLogginOut()
    {
        HttpContext.Current.Session[sessionname] = null; ;
        HttpContext.Current.Session[sessionid] = null;
    }

    #endregion

}

    

 
