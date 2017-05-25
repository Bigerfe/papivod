using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;
 namespace Linda.DAL.IServer
{

    public class BasePage : System.Web.UI.Page
    {
        string keyword = "";
        string description = "";  


        /// <summary>
        /// 网站名称
        /// </summary>
        public string WebSiteName
        {
            get
            {
                return "-"+DalTb_Easo_Sys_set.ReturnCatchValue(3);
            }
        }

        /// <summary>
        /// 网页描述
        /// </summary>
        public string Description
        {

            get
            {
                return DalTb_Easo_Sys_set.ReturnCatchValue(10); ;
            }
            set
            {
                description = value;
            }
        }

        /// <summary>
        /// 网页关键字设置
        /// </summary>
        public string KeyWord
        {
            get
            {

                return DalTb_Easo_Sys_set.ReturnCatchValue(9); ; ;
            }
            set
            {
                keyword = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {

            HtmlMeta meta = new HtmlMeta();
            meta.Name = "KeyWords";
            meta.Content = KeyWord;

            HtmlHead head = this.Header;

            HtmlMeta metacontent = new HtmlMeta();
            metacontent.HttpEquiv = "Content-Type";
            metacontent.Content = "text/html";
            metacontent.Attributes.Add("charset", "gb2312");

            HtmlMeta metades = new HtmlMeta();
            metades.Name = "Description";
            metades.Content = Description;

            HtmlMeta metaauthor = new HtmlMeta();
            metaauthor.Name = "author";
            metaauthor.Content = "张鹏 qq 223344386";

            LiteralControl lit = new LiteralControl();
            lit.Text = "\n";
            LiteralControl lit1 = new LiteralControl();
            lit1.Text = "\n";
            LiteralControl lit2 = new LiteralControl();
            lit2.Text = "\n";
            LiteralControl lit3 = new LiteralControl();
            lit3.Text = "\n";
            LiteralControl lit4 = new LiteralControl();
            lit4.Text = "\n";      
            head.Controls.AddAt(1, lit3);
            head.Controls.AddAt(2, metacontent);
            head.Controls.AddAt(3, lit);
            head.Controls.AddAt(4, meta);
            head.Controls.AddAt(5, lit1);
            head.Controls.AddAt(6, metades);
            head.Controls.AddAt(7, lit2);
            head.Controls.AddAt(8, metaauthor);
            head.Controls.AddAt(9, lit4);

            //根据主机头判断是哪个分站的


            //结束
            

            base.OnInit(e);

        }

    }
}
 
