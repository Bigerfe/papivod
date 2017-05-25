using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Linda.Entity;
using Linda.Dal.NewsDAL;
 namespace Linda.DAL.IServer
{
    public class SendRequest : IHttpHandler
    {
        #region IHttpHandler 成员

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {

            HttpResponse response = context.Response;
            string action = CRequest.GetString("action");

            if (action == "htuserloout")
            {
                //后台用户退出登录

                DoClass.AdminLoginOut();
            }
            else if (action == "getbaomignziliao")
            {

                string name = CRequest.GetString("name");

                int sex = CRequest.GetInt("sex",0);

                string mobile = CRequest.GetString("mobile");

                string email = CRequest.GetString("email");

                int engscore = CRequest.GetInt("engscore", 0);

                int ylxgj = CRequest.GetInt("ylxgj", 0);

                int szx = CRequest.GetInt("city", 0);

                GetZhaoi md = new GetZhaoi();
                md.name = name;
                md.sex = sex;
                md.dianh = mobile;
                md.email = email;
                md.engscore = engscore.ToString();
                md.ylxgj = ylxgj;
                md.city = szx;

                response.Write(DalGetZhaoi.CreateInstance().Add(md));  

            }

            response.End();

        }

        #endregion
    }
}

