using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;
 namespace Linda.DAL.IServer
{

     public class NewPageEnd : System.Web.UI.Page
    {
        string keyword = "";
       


        /// <summary>
        /// ÍøÕ¾Ãû³Æ
        /// </summary>
        public string WebSiteName
        {
            get
            {
                return "-"+DalTb_Easo_Sys_set.ReturnCatchValue(3);
            }
        } 
     
        /// <summary>
        /// ÍøÒ³¹Ø¼ü×ÖÉèÖÃ
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

    }
}
 
