using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI;

namespace Linda.DAL.IServer
{
    /// <summary>
    /// �û����Ĺ�����Ϣ����
    /// </summary>
    public class AdminPage : System.Web.UI.Page
    {
        string strjs2 = @" 
         function call(obj,name)
            {
                var m = document.getElementsByName(name);
                var l = m.length;
                for ( var i=0; i< l; i++)
                {
                    
                    m[i].checked =  obj.checked;
                        
                }
            }

        ";
 
        /// <summary>
        /// Ȩ�޲���ʱ�� ��ת�ĵ�ַ
        /// </summary>
        protected virtual string Gourl
        {
            get
            {
                return (ViewState["Gourl"] == null ? "../main.aspx" : ViewState["Gourl"].ToString());
            }
            set
            {
                ViewState["Gourl"] = value;
            }
        }


        protected override void OnInit(EventArgs e)
        {
            ////�ж�Ȩ�� 

            if (!DoClass.AdminIsLogin(this, 1))
            {
                Jscript.WriteInfo("�����ʵ�ҳ�治��..");
            }

            this.ClientScript.RegisterStartupScript(this.GetType(), "strchealljskey", strjs2, true);

            base.OnInit(e);
        }



    }


}