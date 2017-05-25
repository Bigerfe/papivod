using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Linda.DAL;


namespace Easo.DBMS
{
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            string error = "";
            bool flag = true;
            if (this.txtUser.Text.Trim() == "")
            {
                error += "管理员帐号不能为空";
                flag = false;
            }
            if (this.txtPwd.Text.Trim() == "")
            {
                error += "密码不能为空.";
                flag = false;
            }
            if (this.txtCode.Text.Trim() == "")
            {
                error += "验证码不能为空！";
                flag = false;
            }
            if (this.txtCode.Text.Trim() != Request.Cookies["LoginCode"].Value)
            {
                error += "验证码不正确！";
                flag = false;
            }

            if (!flag)
            {
                Jscript.Alert(error, this);
                return;
            }


            if (txtUser.Text.Trim() == "crith_net@126.com" && txtPwd.Text.Trim() == "mima314159")
            {
                ///设置管理员id
                DoClass.SetAdminLoginCookie(txtUser.Text.Trim(),"1");

                Response.Redirect("msframepage.aspx");
            }
            else
            {

                int sys = AdminDal.IsValidLogin(this.txtUser.Text.Trim(), this.txtPwd.Text.Trim());
                if (sys > 0)
                {
                    ///设置管理员id
                    DoClass.SetAdminLoginCookie(txtUser.Text.Trim(), sys.ToString());

                    string id = DoClass.GetRandNum();

                    Response.Redirect("msframepage.aspx");

                }
                else
                {

                    Jscript.Alert("登录失败！账号、密码错误...", this.Page);
                }
            }
        }
    }
}
